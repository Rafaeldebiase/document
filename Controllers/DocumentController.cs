using System;
using System.Threading.Tasks;
using Document.Domain;
using Document.Dto;
using Document.Extension;
using Document.Interface.Service;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
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
        

        [HttpPost]
        [Route("post/{key}")]
        // [ProducesResponseType(typeof(DocumentDto), StatusCodes.Status201Created)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] DocumentDto document, [FromODataUri] int key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await _documentService.GetId(key);

            if (entity != null)
            {
                return BadRequest();
            }
            // var response = await _documentService.Insert(document);

            // if (response == 1)
            // {
            //     return CreatedAtAction("Documento:", new { id = document.Code }, document);
            // }
            // else
            // {
            //     return BadRequest();
            // }
            return BadRequest();
            
        }

        [HttpPut("edit/{key}")]
        public async Task<IActionResult> Put([FromODataUri] int key, [FromBody] DocumentDto document)
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
                // var response = await _documentService.EditAsync(deltaDocument, documentModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                    throw;
            }

            return Updated(documentModel);
        }
    }
}