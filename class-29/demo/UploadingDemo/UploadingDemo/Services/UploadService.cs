using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadingDemo.Models;


//  How do we test things like this ... 3rd Party Services
//  Inspiration (but this won't actually work ...)
//  https://gist.github.com/trailmax/7505283

namespace UploadingDemo.Services
{

  public interface IUploadService
  {
    Task<Document> Upload(IFormFile file);
  }

  public class UploadService : IUploadService
  {

    private IConfiguration Configuration { get; }

    public UploadService(IConfiguration config)
    {
      Configuration = config;
    }

    public async Task<Document> Upload(IFormFile file)
    {

      BlobContainerClient container = new BlobContainerClient(Configuration.GetConnectionString("StorageAccount"), "images");

      // If we don't have an "images" container, make it
      await container.CreateIfNotExistsAsync();

      // Get a reference to the REMOTE file
      BlobClient blob = container.GetBlobClient(file.FileName);

      using var stream = file.OpenReadStream();

      /*
       * Upload to your file system instead of azure
       * var filePath = Path.GetTempFileName();
       * using( var stream = System.IO.File.Create(filePath))
       * { 
       *   await file.CopyToAsync(stream);
       * }
       */

      BlobUploadOptions options = new BlobUploadOptions()
      {
        //HttpHeaders = new BlobHttpHeaders() { ContentType = file.ContentType }
      };

      if (!blob.Exists())
      {
        await blob.UploadAsync(stream, options);
      }

      Document document = new Document()
      {
        Name = file.FileName,
        Type = file.ContentType,
        Size = file.Length,
        Url = blob.Uri.ToString(),
      };

      return document;


    }
  }
}
