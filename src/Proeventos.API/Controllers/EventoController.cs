using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proeventos.Application.Interfaces;
using Proeventos.DTO;

namespace Proeventos.API
{

    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private bool palestrante = true;
        private readonly IEventoService _eventoService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        
        public EventoController(IEventoService eventoService,IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
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
        public async Task<ActionResult> Post(EventoDto model)
        {
            try
            {
                var evento = await _eventoService.AddEvento(model);
                return evento != null ? Created("",evento) : BadRequest("Erro ao tentar inserir evento!");
            }
            catch (Exception  ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar inserir eventos! Erro: {ex.Message}");
            }
        }  

        // [HttpPost("upload-image/{eventoId}")]
        // [Consumes("multipart/form-data")]
        // public async Task<IActionResult> UploadImage(
        //     [FromRoute] int eventoId,
        //     [FromForm(Name = "file")] IFormFile file)
        // {
        //     if (file == null || file.Length == 0)
        //         return BadRequest("Arquivo inválido");

        //     var nomeImagem = await SaveImage(file);

        //     return Ok(new { eventoId, nomeImagem });
        // }
        [HttpPost("upload-image/{eventoId}")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> UploadImage(int eventoId, [FromForm] IFormFile imgFile)
        {
            try
            {
                var evento = await _eventoService.GetEventoByIdAsync(eventoId);
                if (evento != null)
                {
                    var file = Request.Form.Files[0];
                    if (file.Length > 0)
                    {
                        DeleteImage(evento.ImgUrl);
                        evento.ImgUrl = await SaveImage(file);
                    }

                    var resultEvent = await _eventoService.UpdateEvento(eventoId,evento);
                    return Ok(resultEvent);
                }
                return NoContent();
            }
            catch (Exception  ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro no upload de Imagem! Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] EventoDto model)
        {
            try
            {
                var evento = await _eventoService.UpdateEvento(id, model);
                return evento != null ? Ok(evento): NotFound("Evento não encontrado!");
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
                var evento = await _eventoService.GetEventoByIdAsync(id);

                if (evento != null)
                {
                    await  _eventoService.DeleteEvento(id);
                    return Ok("Evento Deletado");
                }
                
                return NotFound($"Evento {id}  não encontrado!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar Deletar evento. Erro: {ex.Message}");                
            }
            
        }

        
        [NonAction]
        private void DeleteImage(string imgUrl)
        {
            try
            {
                var imgPath = Path.Combine(_webHostEnvironment.ContentRootPath,@"Resources/Images",imgUrl);
                if (System.IO.File.Exists(imgPath))
                {
                    System.IO.File.Delete(imgPath);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao deletar imagem: {ex.Message}");
            }
        }

        [NonAction]
        private async Task<string> SaveImage(IFormFile imgFile)
        {
            try
            {
                string nameImage = new String(Path.GetFileNameWithoutExtension(imgFile.FileName).Take(10).ToArray());
                nameImage = nameImage.Replace(' ','-');
                nameImage = $"{nameImage}{DateTime.UtcNow.ToString("yymmssfff")}{Path.GetExtension(imgFile.FileName)}";
                var imgPath = Path.Combine(_webHostEnvironment.ContentRootPath,@"Resources/Images",nameImage);
                using (var fileStream = new FileStream(imgPath,FileMode.Create))
                {
                    await imgFile.CopyToAsync(fileStream);
                }  

                return nameImage;
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao salvar imagem: {ex.Message}");
            }
            
        }

    }
}
