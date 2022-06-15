using meta.Domain;
using meta.DTO;
using meta.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meta.Controllers
{
    [ApiController]
    public class CaminhaoController : ControllerBase
    {
        private readonly ILogger<CaminhaoController> _logger;
        private ICaminhaoService _caminhaoService;

        public CaminhaoController(ILogger<CaminhaoController> logger, ICaminhaoService caminhaoService)
        {
            _logger = logger;
            _caminhaoService = caminhaoService;
        }

        /// <summary>
        /// Busca todos os registros de caminhão
        /// </summary>
        /// <returns>Retorna uma lista de caminhões</returns>
        [HttpGet]
        [Route("api/Caminhao")]
        public async Task<IEnumerable<Caminhao>> Get()
        {
            var result = await _caminhaoService.GetCaminhaoAsync();

            return result;
        }

        /// <summary>
        /// Deleta um caminhão
        /// </summary>
        /// <param name="idCaminhao">Id do caminhão</param>
        /// <returns>Retorna o status da transação</returns>
        [HttpDelete]
        [Route("api/Caminhao")]
        public async Task<IActionResult> Delete(long idCaminhao)
        {
            var result = await _caminhaoService.DeleteCaminhaoAsync(idCaminhao);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Edita um caminhão
        /// </summary>
        /// <param name="caminhaoParam">Parametro para passar os dados a serem editados</param>
        /// <returns>Retorna o objeto editado</returns>
        [HttpPut]
        [Route("api/Caminhao")]
        public async Task<IActionResult> Edit(CaminhaoEditDTO caminhaoParam)
        {
            var result = await _caminhaoService.EditCaminhaoAsync(caminhaoParam);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Inserir novo caminhão na base de dados
        /// </summary>
        /// <param name="caminhaoParam">Parametro para passar os dados a serem inseridos</param>
        /// <returns>Retorna o objeto inserido</returns>
        [HttpPost]
        [Route("api/Caminhao")]
        public async Task<IActionResult> Insert(CaminhaoInsertDTO caminhaoParam)
        {
            var result = await _caminhaoService.InsertCaminhaoAsync(caminhaoParam);

            return Ok(result);
        }
    }
}
