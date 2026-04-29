using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proeventos.Application.Interfaces;
using Proeventos.DTO;

[Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private bool palestrante = true;
        private readonly IEventoService _eventoService;
        public EventoController(IEventoService eventoService)
        {
            this._eventoService = eventoService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var eventos = await _eventoService.GetAllEventoAsync(palestrante);
                return eventos != null ? Ok(eventos) : NoContent();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");                
            }
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var evento = await _eventoService.GetEventoByIdAsync(id,palestrante);
                return evento != null ? Ok(evento) :  NoContent();;
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar evento. Erro: {ex.Message}");                
            }
            
        }

        [HttpGet("{tema}/tema")]
        public async Task<ActionResult> GetByTema(string tema)
        {
            try
            {
                var evento = await _eventoService.GetAllEventosByTemaAsync(tema,palestrante);
                return evento != null ? Ok(evento) :  NoContent();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar evento. Erro: {ex.Message}");                
            }
            
        }

        [HttpPost]
        // [Consumes("application/json", "multipart/form-data")]
        public async Task<ActionResult> Post([FromBody] EventoDto model)
        {
            try
            {
                var evento = await _eventoService.AddEvento(model);
                return evento != null ? Ok(evento) : BadRequest("Erro ao tentar inserir evento!");
            }
            catch (Exception  ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar inserir eventos! Erro: {ex.Message}");
            }
        }  

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] EventoDto model)
        {
            try
            {
                // var evento = await _eventoService.GetEventoByIdAsync(id);
                var evento = await _eventoService.UpdateEvento(id, model);
                return evento != null ? Ok(evento): NotFound("Evento não encontrado!");
                // if (evento != null)
                // {
                //     return Ok(evento);
                // }
                // return NotFound($"Evento {id}  não encontrado!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar evento. Erro: {ex.Message}");                
            }
            
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var evento = await  _eventoService.DeleteEvento(id);
                return evento ? Ok("Deletado") : NotFound($"Evento {id}  não encontrado!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar Deletar evento. Erro: {ex.Message}");                
            }
            
        }
    }
