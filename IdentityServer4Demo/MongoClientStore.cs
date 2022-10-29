using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using IdentityServer4.Validation;
using MongoDB.Driver;
using MongoDB.Entities;

namespace IdentityServer4Demo;

public class ResourcePasswordValidator: IResourceOwnerPasswordValidator
{
    public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
    {
        // 自己去数据库判断账号密码是否正确,并且从数据库里返回用户的个人信息放到claims字段
        if (context.UserName == "lizhenghao" && context.Password == "lizhenghao")
        {
            context.Result = new GrantValidationResult(
                subject: "userInfo",
                authenticationMethod: OidcConstants.AuthenticationMethods.Password,
                claims: GetUserClaims());
        }
        else
        {
            //验证失败
            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "用户名密码错误");
        }
    }

    //可以根据需要设置相应的Claim/需要实现IProfileService接口
    private Claim[] GetUserClaims()
    {
        return new Claim[]
        {
            new Claim("userId","123456"),
            new Claim(JwtClaimTypes.Name,"李正浩"),
            new Claim(JwtClaimTypes.Role,"admin"),
            new Claim("自定义属性","自定义结果")
        };
    }
}

public class ProfileService : IProfileService
{
    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        try
        {
            //depending on the scope accessing the user data.
            var claims = context.Subject.Claims.ToList();

            //set issued claims to return
            context.IssuedClaims = claims.ToList();
        }
        catch (Exception ex)
        {
            //log your error
        }
    }

    public async Task IsActiveAsync(IsActiveContext context)
    {
        context.IsActive = true;
    }
}