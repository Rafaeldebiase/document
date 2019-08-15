using System;
using Document.Domain;
using Document.Dto;
using Document.Extension;
using Document.Interface.Service;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Insert([FromBody] DocumentModel document)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = _documentService.Insert(document);

            if (response.Result == 1)
            {
                return Created<DocumentModel>(document);
            }
            else
            {
                return Created("não foi possível inserir o documento.");
            }

        }
    }
}