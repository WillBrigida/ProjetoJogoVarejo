using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace JogoVarejo.Client.Services.Auth
{
    public class TokenAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;

        string token = string.Empty;

        public TokenAuthenticationStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _http = httpClient;
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            token = await _localStorage.GetItemAsync<string>("authToken");

            if (string.IsNullOrWhiteSpace(token))
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt")));
        }

        public async Task MarkUserAsAuthenticated(string email)
        {
            token = await _localStorage.GetItemAsync<string>("authToken");

            ClaimsPrincipal authenticatedUser = null;

            if (string.IsNullOrEmpty(token))
                authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, email) }, "apiauth"));
            else
                 authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt"));

            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));

            await Task.Run(() => NotifyAuthenticationStateChanged(authState));
        }

        public async Task MarkUserAsLoggedOut()
        {
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(anonymousUser));
            await Task.Run(() => NotifyAuthenticationStateChanged(authState));
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            return claims;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
