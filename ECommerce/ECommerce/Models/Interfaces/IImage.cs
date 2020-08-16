using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.Interfaces
{
    public interface IImage
    {
        public Task<CloudBlobContainer> GetContainer(string name);

        public Task<CloudBlob> GetBlob(string imageName, string containerName);

        public Task UploadFile(string containerName, string fileName, byte[] image, string contentType);
    }
}