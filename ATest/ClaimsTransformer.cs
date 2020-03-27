using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace ATest
{
    public class ClaimsTransformer : IClaimsTransformation
    {
        public ClaimsTransformer()
        {

        }

        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var transformed = new ClaimsPrincipal();
            transformed.AddIdentities(principal.Identities);
            transformed.AddIdentity(new ClaimsIdentity(new Claim[]
            {
                new Claim("Transformed", DateTime.Now.ToString())
            }));

            return Task.FromResult(transformed);
        }
    }
}
