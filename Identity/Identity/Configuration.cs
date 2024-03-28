using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Identity
{
	public class Configuration
	{
		public static IEnumerable<ApiScope> ApiScopes =>
			new List<ApiScope>
			{
				new ApiScope("ResultsWebAPI", "Web API")
			};

		public static IEnumerable<IdentityResource> IdentityResources =>
			new List<IdentityResource>
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Profile()
			};

		public static IEnumerable<ApiResource> ApiResources =>
			new List<ApiResource>
			{
				new ApiResource("ResultsWebAPI", "Web API", [JwtClaimTypes.Name])
				{
					Scopes = {"ResultsWebAPI"}
				}
			};

		public static IEnumerable<Client> Clients =>
			new List<Client>
			{
				new Client
				{
					ClientId = "reaction-test-web-app",
					ClientName = "Results Web",
					AllowedGrantTypes = GrantTypes.Code,
					RequireClientSecret = false,
					RequirePkce = true,
					RedirectUris =
					{
                        "http://localhost:3000/signin-oidc"
                    },
					AllowedCorsOrigins =
					{
						"http://localhost:3000"
                    },
					PostLogoutRedirectUris =
					{
                        "http://localhost:3000/signout-oidc"
                    },
					AllowedScopes =
					{
						IdentityServerConstants.StandardScopes.OpenId,
						IdentityServerConstants.StandardScopes.Profile,
						"ResultsWebAPI"
					},
					AllowAccessTokensViaBrowser = true
				}
			};
	}
}
