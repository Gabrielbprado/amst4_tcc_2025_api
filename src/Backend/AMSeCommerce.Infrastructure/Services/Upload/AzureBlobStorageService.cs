using AMSeCommerce.Domain.Contracts.Storage;
using AMSeCommerce.Domain.Entities;
using Azure.Storage.Blobs;

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
}