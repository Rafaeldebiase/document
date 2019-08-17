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
    [Route("api/[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly ILogger<DocumentController> _logger;
        private readonly IDocumentService _documentService;

        public DocumentController(ILogger<DocumentController> logger, IDocumentService documentService)
        {
            _logger = logger;
            _documentService = documentService;
        }
        
        ///<summary>
        ///Busca o documento pelo código
        ///</summary>
        ///<param name="key"></param>
        [HttpGet("getbycode/{key}")]
        public ActionResult<DocumentModel> GetByCode(int key)
        {
            return  _documentService.GetCode(key).Result;
        }

        [HttpGet("getbytitle/{title}")]
        public ActionResult<IList<DocumentModel>> GetByTitle(string title) =>
            _documentService.GetTitle(title).ToList().Result;

        [HttpGet("getbyprocess/{process}")]
        public ActionResult<IList<DocumentModel>> GetByProcess(string process) =>
            _documentService.GetProcess(process).ToList().Result;

        [HttpGet("getbycategory/{category}")]
        public ActionResult<IList<DocumentModel>> GetByCategory(Category category) =>
            _documentService.GetCategory(category).ToList().Result;

        [HttpGet("getall")]
        public ActionResult<IList<DocumentModel>> GetAll(string category) =>
            _documentService.GetAll().ToList().Result;

        [HttpPost("insert/{key}")]
        [ProducesResponseType(typeof(DocumentDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] DocumentDto documentDto, int key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var documentModel = await _documentService.GetCode(key);

            if (documentModel != null)
            {
                return BadRequest();
            }
            var response = await _documentService.Insert(documentDto);

            if (response == 1)
            {
                return CreatedAtAction("Documento:", new { id = documentDto.Code }, documentDto);
            }
            else
            {
                return BadRequest();
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