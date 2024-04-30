using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace TratamentoGlobalDeErros.Controllers;

[ApiController]
[Route("[controller]")]
public class FilesController : ControllerBase
{
    private const string DefaultDir = "Files";
    private const string DefaultContentType = "application/octet-stream";

    private readonly string _basePath;
    private readonly FileExtensionContentTypeProvider _contentTypeProvider;

    public FilesController(IWebHostEnvironment environment)
    {
        // O path base convencionado para o armazenamento dos arquivos é "{RaizProjeto}/Files/"
        _basePath = Path.Combine(environment.ContentRootPath, DefaultDir);
        _contentTypeProvider = new FileExtensionContentTypeProvider();
    }

    [HttpGet("download")]
    public async Task<IActionResult> Download(string? fileName)
    {
        if (fileName is null)
            return BadRequest("The file name is required."); //400

        var filePath = Path.Combine(_basePath, fileName);

        if (!Directory.Exists(_basePath))
            return NotFound($"File \"{fileName}\" not found."); // 404

        if (!_contentTypeProvider.TryGetContentType(fileName, out string? contentType))
            contentType = DefaultContentType;

        var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);

        return File(fileBytes, contentType, fileName); // 200
    }

    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile? file)
    {
        if (file is null)
            return BadRequest("The file was not sent."); //400    

        if (!Directory.Exists(_basePath))
            Directory.CreateDirectory(_basePath);

        var filePath = Path.Combine(_basePath, file.FileName);

        if (System.IO.File.Exists(filePath))
            return Conflict("File already exists on the server."); // 409

        using (var fileStream = new FileStream(filePath, FileMode.CreateNew))
        {
            await file.CopyToAsync(fileStream);
        }

        return Ok($"File \"{file.FileName}\" sent with success!"); // 200
    }
}