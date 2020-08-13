using ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.Services
{
    public class ImageRepository : IImage
    {
        private IConfiguration _config;
        public CloudStorageAccount CloudStorageAccount { get; set; }
        public CloudBlobClient CloudBlobClient { get; set; }

        public ImageRepository(IConfiguration configuration)
        {
            _config = configuration;
            var storageCredentials = new StorageCredentials(_config["BlobAccountName"], _config["BlobKey"]);
            CloudStorageAccount = new CloudStorageAccount(storageCredentials, true);
            CloudBlobClient = CloudStorageAccount.CreateCloudBlobClient();
        }

        public async Task Upload(IFormFile image, string name)
        {
            // send the incoming data into azure
            await GetContainer("products");
        }

        public async Task<CloudBlobContainer> GetContainer(string name)
        {
            CloudBlobContainer cbc = CloudBlobClient.GetContainerReference(name);
            await cbc.CreateIfNotExistsAsync();
            await cbc.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Container
            });

            return cbc;
        }

        public async Task<CloudBlob> GetBlob(string imageName, string containerName)
        {
            var container = await GetContainer(containerName);
            CloudBlob cb = container.GetBlobReference(imageName);
            return cb;
        }

        public async Task UploadFile(string containerName, string fileName, Stream image)
        {
            var container = await GetContainer(containerName);
            var blobReference = container.GetBlockBlobReference(fileName);
            await blobReference.UploadFromStreamAsync(image);
        }

        /*
         1. connect your account - done in the ctor
         2. get/create the container
         3. create the blob
         4. push blob to container
         */
    }
}