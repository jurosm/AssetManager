using AssetManager.Application.Handlers.Categories.Queries.GetCategoryList;
using AssetManager.Domain.Entities;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Api.Tests.Integration
{
    public class CategoryTests(TestWebApplicationFactory<Program> factory) : TestBase(factory)
    {
        [Fact]
        public async void CreateCategory_ValidData_ReturnsCreated()
        {
            var client = _factory.CreateClient();

            Category categoryPayload = new() { Name = "Electronics" };
            var createCategoryRes = await client.PostAsync("/category", new StringContent(JsonConvert.SerializeObject(categoryPayload), Encoding.UTF8, "application/json"));

            Assert.NotNull(createCategoryRes);
            Assert.Equal(HttpStatusCode.Created, createCategoryRes.StatusCode);

            var categoryResBodyString = await createCategoryRes.Content.ReadAsStringAsync();
            var categoryResBody = JsonConvert.DeserializeObject<Category>(categoryResBodyString)!;

            Assert.True(categoryResBody.Id > 0);
            Assert.Equal(categoryPayload.Name, categoryResBody.Name);
        }

        [Fact]
        public async void GetCategoryList_ValidData_ReturnsOk()
        {
            var client = _factory.CreateClient();

            var getCategoryRes = await client.GetAsync("/category");

            Assert.NotNull(getCategoryRes);
            Assert.Equal(HttpStatusCode.OK, getCategoryRes.StatusCode);

            var categoryResBodyString = await getCategoryRes.Content.ReadAsStringAsync();
            var categoryResBody = JsonConvert.DeserializeObject<List<GetCategoryListModel>>(categoryResBodyString);

            Assert.NotNull(categoryResBody);
        }
    }
}
