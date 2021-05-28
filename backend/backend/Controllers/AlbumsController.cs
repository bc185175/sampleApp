using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AlbumsController : ControllerBase
  {
    private readonly JsonPlaceholderClient _jsonPlaceholderClient;

    public AlbumsController(JsonPlaceholderClient jsonPlaceholderClient)
    {
      _jsonPlaceholderClient = jsonPlaceholderClient;
    }
    // private readonly IHttpClientFactory _httpClientFactory;
    //
    // public AlbumsController(IHttpClientFactory httpClientFactory)
    // {
    //   _httpClientFactory = httpClientFactory;
    // }

    [HttpGet]
    [Route("getAlbums")]
    public async Task<IEnumerable<Albums>> Get() {
      var albums = await _jsonPlaceholderClient.GetAlbums();
      return albums;
    }

  // public async Task<IActionResult> GetAllAsync()
  // {
    //   var request = new HttpRequestMessage(HttpMethod.Get, "https://jsonplaceholder.typicode.com/albums");
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
    //   List<Albums> albums = JsonSerializer.Deserialize<List<Albums>>(responseString, options);
    //
    //   return Ok(albums);
    // }
  }
}
