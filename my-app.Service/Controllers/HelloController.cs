using Microsoft.AspNetCore.Mvc;

namespace my_app.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        [Route("hello")]
        public IActionResult GetHello()
        {
            return Ok("Hello, World!");
        }

         [HttpGet]
        [Route("employ")]
        public IActionResult GetEmploy()
        {
            return Ok("Golan Maimon");
        }

        [HttpGet]
         [Route("GetEmployees")]
        public async  Task<IActionResult> GetEmployees()
        {
            using HttpClient client = new();
            string url = "https://jsonplaceholder.typicode.com/users";
            try
            {
                var response = await client.GetAsync(url);
                string responseBody = await response.Content.ReadAsStringAsync();

                response.EnsureSuccessStatusCode();

                Console.WriteLine(responseBody);
                return Ok(responseBody);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound("Not found");
            }


        }
    }
}
