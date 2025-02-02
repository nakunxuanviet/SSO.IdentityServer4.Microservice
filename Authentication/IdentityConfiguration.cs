﻿using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace Authentication
{
    public class IdentityConfiguration
    {
        public static List<TestUser> TestUsers =>
             new List<TestUser>
             {
                    new TestUser
                    {
                        SubjectId = "1234",
                        Username = "viettx",
                        Password = "admin@1234",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Tran Xuan Viet"),
                            new Claim(JwtClaimTypes.GivenName, "NaKun"),
                            new Claim(JwtClaimTypes.FamilyName, "Xuan Viet"),
                            new Claim(JwtClaimTypes.WebSite, "http://nakun.io"),
                        }
                    }
         };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("myApi.read"),
                new ApiScope("myApi.write"),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("myApi")
                {
                    Scopes = new List<string>{ "myApi.read","myApi.write" },
                    ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "cwm.client",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "myApi.read" }
                },
            };
    }
}