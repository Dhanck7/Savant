using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Savant.Api.Infrastructure.Exceptions;

namespace Savant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportController : ControllerBase
    {
        private readonly ILogger log;
        private readonly IFileProvider fileProvider;
        private readonly FileExtensionContentTypeProvider contentTypeProvider;

        public ImportController(ILogger log, IWebHostEnvironment environment)
        {
            if (environment == null)
                throw new ArgumentNullException(nameof(environment));

            this.log = log;

            fileProvider = environment.WebRootFileProvider;
            contentTypeProvider = new FileExtensionContentTypeProvider();
        }

        // POST: api/import
        [HttpPost]
        public async Task<IActionResult> Post(IFormFile file)
        {
            if(!string.Equals(Path.GetExtension(file.FileName), ".csv"))
                throw new SavantDomainException("File must be .csv");

            try
            {
                if (file.Length > 0)
                {
                    using var ms = new MemoryStream();
                    await file.CopyToAsync(ms).ConfigureAwait(false);

                    using var textReader = new StreamReader(ms);
                    using var csv = new CsvReader(textReader, CultureInfo.InvariantCulture);
                    csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                   // var records = csv.GetRecords<Foo>();

                    // todo process csv
                }

                return Ok();
            }
            catch (Exception e)
            {
                log.LogError(e, "Failed to import file");
                return BadRequest();
            }
        }
    }
}