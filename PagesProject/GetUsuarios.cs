using System.IO;
using Core;
using Microsoft.Extensions.Configuration;

namespace PagesProject
{
    public class GetUsuarios
    {
        private DatosUsuarios usuario = new DatosUsuarios();

        public GetUsuarios(Usuarios rol)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "usuarios.json");
            var config = new ConfigurationBuilder()
            .AddJsonFile(path, false)
            .Build();

            AppSettingsConfiguration app = new AppSettingsConfiguration();
            
            var usuarios = config.GetSection(app.Enviroment);
            usuario.Email = usuarios.GetSection(rol.ToString())["email"];
            usuario.Password = usuarios.GetSection(rol.ToString())["password"];

        }

        public DatosUsuarios Usuario
        {
            get => usuario;
        }

    }

    public class DatosUsuarios
    {
        private string email;
        private string password;

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
