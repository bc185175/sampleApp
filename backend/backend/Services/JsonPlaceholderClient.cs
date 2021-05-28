using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Services
{
  public class JsonPlaceholderClient
  {
    private readonly IHttpClientFactory _httpClientFactory;
    private HttpClient _httpClient;

    public JsonPlaceholderClient(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
      _httpClient = _httpClientFactory.CreateClient();
      _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
    }

    //get user --------------------------------------------------------------------------------
    public async Task<IEnumerable<Users>> GetUsers()
    {
      var users = new List<Users>();

      var request = new HttpRequestMessage(HttpMethod.Get, "users");
      var response = await _httpClient.SendAsync(request);

      if (response.IsSuccessStatusCode)
      {
        await using var responseStream = await response.Content.ReadAsStreamAsync();

        var options = new JsonSerializerOptions
        {
          PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        users = await JsonSerializer.DeserializeAsync
          <List<Users>>(responseStream, options);
      }

      return users;
    }

    //get albums  ------------------------------------------------------------------------------
    public async Task<IEnumerable<Albums>> GetAlbums()
    {
      var albums = new List<Albums>();

      var request = new HttpRequestMessage(HttpMethod.Get, "albums");
      var response = await _httpClient.SendAsync(request);

      if (response.IsSuccessStatusCode)
      {
        await using var responseStream = await response.Content.ReadAsStreamAsync();

        var options = new JsonSerializerOptions
        {
          PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        albums = await JsonSerializer.DeserializeAsync
          <List<Albums>>(responseStream, options);

        //get thumbnail photo for album --------------------------------------------------------
        foreach(var album in albums)
        {
          var req = new HttpRequestMessage(HttpMethod.Get,
                          "photos?albumId=" + album.Id + "&_limit=1");
          var res = await _httpClient.SendAsync(req);

          if (res.IsSuccessStatusCode)
          {
            await using var resStream = await res.Content.ReadAsStreamAsync();
            var opt = new JsonSerializerOptions
            {
              PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            IEnumerable<Photos> thumbnail = await JsonSerializer.DeserializeAsync
                                        <IEnumerable<Photos>>(resStream, opt);
            album.Thumbnail = thumbnail.ToArray()[0].ThumbnailUrl;
          }
        }
      }

      return albums;
    }

    //get photos -----------------------------------------------------------------------------
    public async Task<IEnumerable<Photos>> GetPhotos()
    {
      var photos = new List<Photos>();

      var request = new HttpRequestMessage(HttpMethod.Get, "photos");
      var response = await _httpClient.SendAsync(request);

      if (response.IsSuccessStatusCode)
      {
        await using var responseStream = await response.Content.ReadAsStreamAsync();

        var options = new JsonSerializerOptions
        {
          PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        photos = await JsonSerializer.DeserializeAsync
          <List<Photos>>(responseStream, options);
      }

      return photos;
    }
  }
}
