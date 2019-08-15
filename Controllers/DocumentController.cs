using System;
using Document.Dto;
using Document.Extension;
using Document.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Document.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly ILogger<DocumentController> _logger;
        private readonly IDocumentService _documentService;

        public DocumentController(ILogger<DocumentController> logger, IDocumentService documentService)
        {
            _logger = logger;
            _documentService = documentService;
        }
        [HttpPost("insert")]
        public void Insert([FromBody] JObject obj)
        {
            try
            {
                var document = obj.DeserializesToDocumentDto();
                _documentService.Insert(document);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}