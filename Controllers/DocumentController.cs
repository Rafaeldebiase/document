using System.Collections.Generic;
using System.Threading.Tasks;
using Document.Domain;
using Document.Dto;
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
        
        [HttpGet("getcode/{key}")]
        public async Task<ActionResult<IList<DocumentModel>>> GetByCode(int key)
        {

        }

        [HttpPost("insert/{key}")]
        [ProducesResponseType(typeof(DocumentDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] DocumentDto documentDto, int key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var documentModel = await _documentService.GetId(key);

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

            var documentModel = await _documentService.GetId(key);

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