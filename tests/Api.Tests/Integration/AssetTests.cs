using Api.Tests.Helpers;
using AssetManager.Application.Exceptions;
using AssetManager.Application.Handlers.Assets.Queries.GetAssetList;
using AssetManager.Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;

namespace Api.Tests.Integration
{
    public class AssetTests(TestWebApplicationFactory<Program> factory) : TestBase(factory)
    {
        [Fact]
        public async void CreateAsset_ValidData_ReturnsCreated()
        {
            var client = _factory.CreateClient();

            var categoryResBody = await new CategoryHelper(_factory).CreateCategory();

            Asset assetPayload = new() { Name = "GPU", Description = "The best GPU on the market", CategoryId = categoryResBody.Id, Quantity = 20 };
            var createAssetRes = await client.PostAsync("/asset", HttpUtils.Serialize(assetPayload));

            Assert.NotNull(createAssetRes);
            Assert.Equal(HttpStatusCode.Created, createAssetRes.StatusCode);

            DefaultContractResolver contractResolver = new()
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };

            var assetResBody = await createAssetRes.Content.ReadAsStringAsync();
            var createdAsset = JsonConvert.DeserializeObject<Asset>(assetResBody, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            })!;

            Assert.NotNull(createdAsset);
            Assert.Equal(assetPayload.Name, createdAsset.Name);
            Assert.Equal(assetPayload.Description, createdAsset.Description);
            Assert.Equal(assetPayload.Quantity, createdAsset.Quantity);
            Assert.Equal(assetPayload.CategoryId, createdAsset.CategoryId);  
        }

        [Fact]
        public async void CreateAsset_CategoryNotExising_ReturnsBadRequest()
        {
            var client = _factory.CreateClient();

            Asset assetPayload = new() { Name = "GPU", Description = "The best GPU on the market", CategoryId = int.MaxValue, Quantity = 20 };
            var createAssetRes = await client.PostAsync("/asset", HttpUtils.Serialize(assetPayload));

            Assert.NotNull(createAssetRes);
            Assert.Equal(HttpStatusCode.BadRequest, createAssetRes.StatusCode);

            var assetResBody = await createAssetRes.Content.ReadAsStringAsync();
            var exception = JsonConvert.DeserializeObject<BadRequestException>(assetResBody)!;

            Assert.NotNull(exception);
            Assert.Equal("asset.category.not_found", exception.ErrorCode);
            Assert.Equal($"Category with ID={int.MaxValue} not found!", exception.Message);
        }

        [Fact]
        public async void GetAssetList_ValidData_ReturnsOk()
        {
            var client = _factory.CreateClient();

            var getAssetListRes = await client.GetAsync("/asset");

            Assert.NotNull(getAssetListRes);

            var assetListString = await getAssetListRes.Content.ReadAsStringAsync();
            var assetList = JsonConvert.DeserializeObject<List<GetAssetListModel>>(assetListString);

            Assert.NotNull(assetList);
        }
    }
}
