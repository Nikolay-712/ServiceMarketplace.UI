using ServiceMarketplace.Models;
using ServiceMarketplace.Models.Request;

namespace ServiceMarketplace.Services.Interfaces;

public interface IHttpCategoryClient
{
    Task<ResponseContent> CreateCategoryAsync(ManageCategoryRequestModel requestModel);
}
