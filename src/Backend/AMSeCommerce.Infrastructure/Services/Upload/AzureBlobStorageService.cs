using AMSeCommerce.Domain.Contracts.Storage;
using AMSeCommerce.Domain.Entities;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;

namespace AMSeCommerce.Infrastructure.Services.Upload;

public class AzureBlobStorageService(BlobServiceClient client) : IBlobStorageService
{
    private readonly BlobServiceClient _client = client;
    public async Task<string> Upload(Customers user, Stream file, string fileName)
    {
        var container = _client.GetBlobContainerClient(user.UserIdentifier.ToString());
        await container.CreateIfNotExistsAsync();
        var blob = container.GetBlobClient(fileName);
         await blob.UploadAsync(file, overwrite: true);
         return blob.Uri.AbsoluteUri;
    }

    public async Task<string> GetUri(Customers user, string fileName)
    {
        var containerName = user.UserIdentifier.ToString();
        var container = _client.GetBlobContainerClient(containerName);
        var exist = await container.ExistsAsync();
        if (exist.Value is false)
            return string.Empty;
        var blob = container.GetBlobClient(fileName);
        exist = await blob.ExistsAsync();
        if (exist.Value)
        {
            var sassBuilder = new BlobSasBuilder
            {
                BlobContainerName = containerName,
                BlobName = fileName,
                Resource = "b",
                ExpiresOn = DateTimeOffset.UtcNow.AddHours(1)
            };
            sassBuilder.SetPermissions(BlobSasPermissions.Read);
            return blob.GenerateSasUri(sassBuilder).ToString();
        }
        return string.Empty;
    }
}