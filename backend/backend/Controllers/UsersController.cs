using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using backend.Services;

namespace backend.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UsersController : Controller
  {
      private readonly JsonPlaceholderClient _jsonPlaceholderClient;

      public UsersController(JsonPlaceholderClient jsonPlaceholderClient)
      {
        _jsonPlaceholderClient = jsonPlaceholderClient;
      }
      // private readonly IHttpClientFactory _httpClientFactory;
      //
      // public UsersController(IHttpClientFactory httpClientFactory)
      // {
      //   _httpClientFactory = httpClientFactory;
      // }

      [HttpGet]
      [Route("getUsers")]
      public async Task<IEnumerable<Users>> Get()
      {
        var users = await _jsonPlaceholderClient.GetUsers();
        return users;
      }

      //
      // public async Task<IActionResult> GetAllAsync()
      // {
      //   var request = new HttpRequestMessage(HttpMethod.Get, "https://jsonplaceholder.typicode.com/users");
      //
      //   var httpClient = _httpClientFactory.CreateClient();
      //
      //   var response = await httpClient.SendAsync(request);
      //
      //   if (!response.IsSuccessStatusCode)
      //   {
      //     return NotFound();
      //   }
      //
      //   var responseString = await response.Content.ReadAsStringAsync();
      //   var options = new JsonSerializerOptions
      //   {
      //     PropertyNameCaseInsensitive = true
      //   };
      //
      //   List<Users> users = JsonSerializer.Deserialize<List<Users>>(responseString, options);
      //
      //   return Ok(users);
      // }
    }
  }
