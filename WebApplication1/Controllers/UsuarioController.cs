using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SeriesApp.Business.Entities;
using SeriesApp.Business.Repository;
using SeriesApp.Configurations;
using SeriesApp.Models.Usuarios;
using Swashbuckle.AspNetCore.Annotations;

namespace SeriesApp.Controllers
{
    [Route("api/v1/usuario/")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationService _authenticationService;
        public UsuarioController(IUsuarioRepository usuarioRepository, 
            IConfiguration configuration,
            IAuthenticationService authenticationService)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
            _authenticationService = authenticationService;
        }

        ///<summary>
        ///Login
        ///</summary>
        ///<param name="loginViewModelInput"/>
        ///<returns></returns>

        [HttpPost]
        [Route("logar")]
        // [ValidacaoModelStateCustomizado]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            Usuario usuario = _usuarioRepository.ObterUsuario(loginViewModelInput.Login);
            var usuarioViewModelOutput = new UsuarioViewModelOutput() // Serve para gerar o token
            {
                Codigo = usuario.Codigo,
                Login =  usuario.Login,
                Email =  usuario.Email
            };
            var token = _authenticationService.GenerateToken(usuarioViewModelOutput);
            
            return Ok(new
            {
                Token = token,
                Usuario = loginViewModelInput
            });
        }
        ///<summary>
        ///Registro usuario
        ///</summary>
        ///<param name="registroViewModelInput">View Model de Registro de Login</param>
        ///<returns></returns>

        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
        [HttpPost]
        [Route("registrarUsuario")]
        public IActionResult Registrar(RegistroViewModelInput registroViewModelInput)
        {


            var usuario = new Usuario();
            usuario.Login = registroViewModelInput.Login;
            usuario.Senha = registroViewModelInput.Senha;
            usuario.Email = registroViewModelInput.Email;

            _usuarioRepository.Adicionar(usuario);
            _usuarioRepository.Commit();


            return Created("", registroViewModelInput);
        }
    }
}
