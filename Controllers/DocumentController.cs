using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Document.Domain;
using Document.Dto;
using Document.Enum;
using Document.Interface.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace Document.Controller
{
    [Route("api/v1/[controller]")]
    public partial class DocumentController : ControllerBase
    {
        private readonly ILogger<DocumentController> _logger;
        private readonly IDocumentService _documentService;

        public DocumentController(ILogger<DocumentController> logger, IDocumentService documentService)
        {
            _logger = logger;
            _documentService = documentService;
        }

        [HttpGet("getbycode/{key}")]
        public ActionResult<DocumentModel> GetByCode(int key) =>
            _documentService.GetCode(key).Result;

        [HttpGet("getbytitle/{title}")]
        public ActionResult<IList<DocumentModel>> GetByTitle(string title) =>
            _documentService.GetTitle(title).ToList().Result;

        [HttpGet("getbyprocess/{process}")]
        public ActionResult<IList<DocumentModel>> GetByProcess(string process) =>
            _documentService.GetProcess(process).ToList().Result;

        [HttpGet("getbycategory/{category}")]
        public ActionResult<IList<DocumentModel>> GetByCategory(int numberOfCategory) =>
            _documentService.GetCategory(numberOfCategory).ToList().Result;

        [HttpGet("getall")]
        public ActionResult<IList<DocumentModel>> GetAll(string category) =>
            _documentService.GetAll().ToList().Result;

        [HttpPost("insert/{key}")]
        public async Task<IActionResult> Post([FromBody] DocumentDto documentDto, int key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!DocumentDtoIsValid(documentDto))
            {
                return BadRequest(errorListDocumentDto.ToList());
            }

            var documentModel = await _documentService.GetCode(key);

            if (documentModel != null)
            {
                var responseBadRequest = $"O documento de cógido {key} já está cadastrado";
                return BadRequest( responseBadRequest );
            }

            var response = await _documentService.Insert(documentDto);

            if (response == 1)
            {
                return StatusCode(201, documentDto);
            }
            else
            {
                var responseForbidden = "Não foi possível cadastro o documento. Verifique os dados informados";
                return StatusCode(403, responseForbidden);
            }
            
        }

        [HttpPatch("edit/{key}"), HttpDelete("delete/{key}")]
        public async Task<IActionResult> Patch(int key, [FromBody] JsonPatchDocument<DocumentDto> documentPatch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var documentModel = await _documentService.GetCode(key);

            if (documentModel == null)
            {
                return NotFound();
            }

            try
            {
                var response = await _documentService.PacthAsync(documentPatch, documentModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                    throw;
            }

            return CreatedAtAction("x", documentPatch);
        }
    }
}