using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace ServiceMarketplace.Services;

public class AppAuthStateProvider : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var anonymous = new ClaimsIdentity();
        return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
    }
}
