using Api.Tests.Integration;
using AssetManager.Domain.Entities;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Api.Tests.Helpers
{
    public class CategoryHelper(TestWebApplicationFactory<Program> factory)
    {
        public async Task<Category> CreateCategory()
        {
            var client = factory.CreateClient();

            Category categoryPayload = new() { Name = "Electronics" };
            var createCategoryRes = await client.PostAsync("/category", new StringContent(JsonConvert.SerializeObject(categoryPayload), Encoding.UTF8, "application/json"));

            if(createCategoryRes.StatusCode != HttpStatusCode.Created)
            {
                throw new Exception("Error while creating the category!");
            }

            var categoryResBodyString = await createCategoryRes.Content.ReadAsStringAsync();
            var categoryResBody = JsonConvert.DeserializeObject<Category>(categoryResBodyString)!;

            return categoryResBody;
        }
    }
}
