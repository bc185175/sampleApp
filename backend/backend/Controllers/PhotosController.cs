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
    public class PhotosController : ControllerBase
    {
      private readonly JsonPlaceholderClient _jsonPlaceholderClient;

      public PhotosController(JsonPlaceholderClient jsonPlaceholderClient)
      {
        _jsonPlaceholderClient = jsonPlaceholderClient;
      }
            // private readonly IHttpClientFactory _httpClientFactory;
            //
            // public PhotosController(IHttpClientFactory httpClientFactory)
            // {
            //     _httpClientFactory = httpClientFactory;
            // }

      [HttpGet]
      [Route("getPhotos")]
      public async Task<IEnumerable<Photos>> Get()
      {
        var photos = await _jsonPlaceholderClient.GetPhotos();
        return photos;
      }
            // public async Task<IActionResult> GetAllAsync()
            // {
            //   var request = new HttpRequestMessage(HttpMethod.Get, "https://jsonplaceholder.typicode.com/photos");
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
            //   List<Photos> albums = JsonSerializer.Deserialize<List<Photos>>(responseString, options);
            //
            //   return Ok(albums);
            // }
    }
}
