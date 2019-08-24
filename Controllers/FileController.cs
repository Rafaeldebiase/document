using System;
using System.Threading.Tasks;
using Document.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace Document.Controller
{
    [Route("api/v1/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("get/{id}")]
        public async Task<FileStreamResult> GetFileAsync(int id)
        {
            return await _fileService.GetAsync(id);
        }

        [HttpPost("insert/{id}"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadAsync(int id)
        {
            try
            {
                var file = Request.Form.Files[0];

                if (file != null)
                {
                    if (
                        file.ContentType.Contains("application/msword") ||
                        file.ContentType.Contains("application/vnd.openxmlformats-officedocument.wordprocessingml.document") ||
                        file.ContentType.Contains("application/pdf") ||
                        file.ContentType.Contains("application/vnd.ms-excel") ||
                        file.ContentType.Contains("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    )
                    {
                        //todo passar rotina para o service
                        var response = await _fileService.insertAsync(file, id);

                        if (response == 1) 
                        {
                            return StatusCode(201, file);
                        }
                        else
                        {
                            var erroMessageSave = "Não foi possível salvar o documento.";
                            return BadRequest(erroMessageSave);
                        }
                    }
                }
                var erroMessageType = "Formato do documento informado não é suportado";
                return BadRequest(erroMessageType);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}