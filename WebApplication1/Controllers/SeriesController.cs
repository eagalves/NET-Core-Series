using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.Annotations;
using SeriesApp.Models;

namespace SeriesApp.Controllers
{
    [Route("api/v1/series/")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        ///<summary>
        ///teste
        ///</summary>
        ///<param name="seriesViewModelsInput">View Model de Registro de Login</param>
        ///<returns></returns>
        [HttpPost]
        [Route("registrarSerie")]
        public IActionResult Registrar(SeriesViewModelsInput seriesViewModelsInput)
        {

            //################################ ESSA PARTE FOI MIGRADA PARA DENTRO DO STARTUP E OUTRAS DEPENDENCIAS
            //    // ABRINDO O BANCO DE DADOS
            //    var optionsBuilder = new DbContextOptionsBuilder<CursosDbContext>();
            //    optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CURSOS;Trusted_Connection=True");
            //    CursosDbContext contexto = new CursosDbContext(optionsBuilder.Options); //Cria o objeto contexto do banco de Dados ex: Tipagem das tabelas,
            //assim como chaves primarias e estrangeiras

            //// Caso o Banco de dados não exista, ele é criado de acordo como foi configurado no contexto
            //var migracoesPendentes = contexto.Database.GetPendingMigrations();
            //if (migracoesPendentes.Count() > 0)
            //{
            //    contexto.Database.Migrate();
            //}

            return Created("", seriesViewModelsInput);
        }
    }

}
