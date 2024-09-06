using Microsoft.Extensions.Logging;
using ServiceMarketplace.Models;
using ServiceMarketplace.Models.Request;
using ServiceMarketplace.Services.Interfaces;
using System.Net.Http.Json;

namespace ServiceMarketplace.Services.Implementations;

public class HttpCategoryClient : IHttpCategoryClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<HttpCategoryClient> _logger;
    private readonly string _baseUrl;

    public HttpCategoryClient(HttpClient httpClient, ILogger<HttpCategoryClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
        _baseUrl = httpClient.BaseAddress!.AbsoluteUri;
    }

    public async Task<ResponseContent> CreateCategoryAsync(ManageCategoryRequestModel requestModel)
    {
        using HttpRequestMessage requestMessage = new();

        requestMessage.Method = HttpMethod.Post;
        requestMessage.RequestUri = new Uri($"{_baseUrl}api/administration/categories/create");
        requestMessage.Content = HttpClientHelper.GenerateRequestContent(requestModel);

        using HttpResponseMessage responseMessage = await _httpClient.SendAsync(requestMessage);
        ResponseContent? responseContent = await responseMessage.Content.ReadFromJsonAsync<ResponseContent>();

        return responseContent!;

    }
}
