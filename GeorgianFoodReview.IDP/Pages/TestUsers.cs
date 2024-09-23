// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

using IdentityModel;
using System.Security.Claims;
using System.Text.Json;
using Duende.IdentityServer;
using Duende.IdentityServer.Test;

namespace GeorgianFoodReview.IDP;

public static class TestUsers
{
    public static List<TestUser> Users =>
              new List<TestUser>
                      {
                     new TestUser
                     {
                     SubjectId = "a9ea0f25-b964-409f-bcce-c923266249b4",
                     Username = "John",
                     Password = "JohnPassword",
                     Claims = new List<Claim>
                     {
                     new Claim("given_name", "John"),
                     new Claim("family_name", "Doe"),
                     new Claim("address","John Doe's Boulevard 323")
                     }
             },
                     new TestUser
                     {
                     SubjectId = "c95ddb8c-79ec-488a-a485-fe57a1462340",
                     Username = "Jane",
                     Password = "JanePassword",
                     Claims = new List<Claim>
                     {
                     new Claim("given_name", "Jane"),
                     new Claim("family_name", "Doe"),
                     new Claim("address","Jane Doe's Boulevard 323")
                     }
             }
  };
}