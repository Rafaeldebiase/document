using System;
using System.Threading.Tasks;
using Document.Domain;
using Document.Dto;
using Document.Extension;
using Document.Interface.Service;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Document.Controller
{
    [Route("api/[controller]")]
    public class DocumentController : ODataController
    {
        private readonly ILogger<DocumentController> _logger;
        private readonly IDocumentService _documentService;

        public DocumentController(ILogger<DocumentController> logger, IDocumentService documentService)
        {
            _logger = logger;
            _documentService = documentService;
        }
        [HttpPost("insert")]
        public async Task<IActionResult> Insert([FromBody] DocumentModel document)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _documentService.Insert(document);

            if (response == 1)
            {
                return Created<DocumentModel>(document);
            }
            else
            {
                return Created("não foi possível inserir o documento.");
            }
        }

        [HttpPatch("edit")]
        public async Task<IActionResult> Patch([FromODataUri] int key, Delta<DocumentModel> document)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await _documentService.GetId(key);

            if (entity == null)
            {
                return NotFound();
            }

            await _documentService.Edit(document, entity);

            try
            {
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(entity);

        }
    }
}