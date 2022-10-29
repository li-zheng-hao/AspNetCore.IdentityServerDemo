using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer4Demo;

public class ClientInit
{
    public static IEnumerable<Client> GetClients()
    {
        return new List<Client>()
        {
            // 浏览器应用
            new Client()
            {
                ClientId = "browser",
                ClientSecrets = {
                    new Secret( "browser".Sha256() )
                },
                // 使用用户名密码登录 还需要提交用户的用户名和密码
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                // 这个机器能够访问的api
                AllowedScopes = {
                    "Scope1"
                },
                //RefreshToken的最长生命周期
                // AbsoluteRefreshTokenLifetime = 2592000,

                //RefreshToken生命周期以秒为单位。默认为1296000秒
                SlidingRefreshTokenLifetime = 2592000,//以秒为单位滑动刷新令牌的生命周期。

                //刷新令牌时，将刷新RefreshToken的生命周期。RefreshToken的总生命周期不会超过AbsoluteRefreshTokenLifetime。
                RefreshTokenExpiration = TokenExpiration.Sliding,

                //AllowOfflineAccess 允许使用刷新令牌的方式来获取新的令牌
                AllowOfflineAccess = true,
            },
            // 控制台应用
            new Client()
            {
                ClientId = "consoleapp",
                ClientSecrets = {
                    new Secret( "consoleapp".Sha256() )
                },
                // 使用用户名密码登录 还需要提交用户的用户名和密码
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                // 这个机器能够访问的api
                AllowedScopes = {
                    "Scope2"
                },
                //RefreshToken的最长生命周期
                // AbsoluteRefreshTokenLifetime = 2592000,

                //RefreshToken生命周期以秒为单位。默认为1296000秒
                SlidingRefreshTokenLifetime = 2592000,//以秒为单位滑动刷新令牌的生命周期。

                //刷新令牌时，将刷新RefreshToken的生命周期。RefreshToken的总生命周期不会超过AbsoluteRefreshTokenLifetime。
                RefreshTokenExpiration = TokenExpiration.Sliding,

                //AllowOfflineAccess 允许使用刷新令牌的方式来获取新的令牌
                AllowOfflineAccess = true,
            },
            
        };
    }

    public static IEnumerable<ApiScope> GetApiScopes()
    {
        return new List<ApiScope>()
        {
            new ApiScope("Scope1"),
            new ApiScope("Scope2")
        };
    }

    public static IEnumerable<ApiResource> GetApiResources()
    {
        return new List<ApiResource>()
        {
            new ApiResource("ApiResource1", "用户获取api")
            {
                Scopes = { "Scope1" }
            },
            new ApiResource("UserApi", "用户信息api")
            {
                Scopes = { "Scope1" }
            }
        };
    }
    /// <summary>
    /// 用不上了
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<IdentityResource> GetIdentityResources()
    {
        return new List<IdentityResource>()
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };
    }
  
}