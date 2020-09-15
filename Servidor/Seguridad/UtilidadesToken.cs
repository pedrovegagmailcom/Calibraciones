

namespace ApiWebNetCore.Seguridad
{
    using ApiWebNetCore.Modelo;
    using Microsoft.AspNetCore.Http;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    public static class UtilidadesToken
    {
        public const string TokenSecurityKey = "claveParaEncriptarLasComunicacionesConTokenDeSeguritdad";

        enum TokenClaimNames
        {
            PkUsuario,
            HostName,
            AplicationID
        }

        //"the secret that needs to be at least 16 characeters long for HmacSha256"
        public static string GenerateToken(UsuarioSesionDTO usuario, string hostName, Guid aplicactionID)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, usuario.CodigoUsuario),
                new Claim(nameof(TokenClaimNames.PkUsuario),usuario.PkUsuario.ToString()),
                new Claim(nameof(TokenClaimNames.HostName),hostName),
                new Claim(nameof(TokenClaimNames.AplicationID),aplicactionID.ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddMinutes(1)).ToUnixTimeSeconds().ToString()),
            };

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenSecurityKey)),
                                             SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



       
        public static string ConseguiHostNameDelToken(HttpContext httpContextAccessor)
        {
            var claims = httpContextAccessor.User.Claims.ToList();
            var claimIdioma = claims.FirstOrDefault(c => c.Type == nameof(TokenClaimNames.HostName));
            if (claimIdioma != null)
                return claimIdioma.Value;
            else
                return "";
        }

        internal static Guid ConseguiAplicacionIDDelToken(HttpContext httpContextAccessor)
        {
            var claims = httpContextAccessor.User.Claims.ToList();
            var claimIdioma = claims.FirstOrDefault(c => c.Type == nameof(TokenClaimNames.AplicationID));
            if (claimIdioma != null)
                return Guid.Parse(claimIdioma.Value);
            else
                return Guid.Empty;
        }


        internal static Guid ConseguiUsuarioDelToken(HttpContext httpContextAccessor)
        {
            var claims = httpContextAccessor.User.Claims.ToList();
            var claimIdioma = claims.FirstOrDefault(c => c.Type == nameof(TokenClaimNames.PkUsuario));
            if (claimIdioma != null)
                return Guid.Parse(claimIdioma.Value);
            else
                return Guid.Empty;
        }
    }
}
