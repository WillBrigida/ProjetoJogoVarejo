﻿using Blazored.LocalStorage;
using JogoVarejo.Shared.Models;
using JogoVarejo.Shared.Models.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JogoVarejo.Client.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<GenericResult<ApplicationUser>> Register(ApplicationUser usuario)
        {
            return await _httpClient.PostJsonAsync<GenericResult<ApplicationUser>>("api/v1/acesso/register", usuario);
        }

        public async Task<GenericResult<ApplicationUser>> Login(ApplicationUser usuario)
        {
            var loginAsJson = JsonSerializer.Serialize(usuario);
            var response = await _httpClient.PostAsync("api/v1/acesso/login", new StringContent(loginAsJson, Encoding.UTF8, "application/json"));
            var loginResult = JsonSerializer.Deserialize <GenericResult <ApplicationUser>> (await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (!response.IsSuccessStatusCode)
            {
                return loginResult;
            }

            await _localStorage.SetItemAsync("authToken", loginResult.Token);
            await ((TokenAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(usuario.Nome);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.Token);

            return loginResult;
        }
      
        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            await ((TokenAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}