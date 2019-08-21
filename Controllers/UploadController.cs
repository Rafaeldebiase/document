using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Document.Controller
{
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> UploadAsync()
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
                        
                        
                        return Ok();
                    }
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}