using HrPlatform.Application.Abstractions;
using Microsoft.Extensions.Logging;
using Minio;
using Minio.DataModel.Args;

namespace HrPlatform.Infrastructure.FileStorage;

class MinioFileStorage : IFileStorage
{
    private readonly MinioClient _client;
    private readonly ILogger<MinioFileStorage> _logger;

    public MinioFileStorage(MinioClient client,
        ILogger<MinioFileStorage> logger)
    {
        _client = client;
        _logger = logger;
    }

    public async Task PutFile(string bucketName, string objectName, string fileName, CancellationToken cancellationToken = default)
    {
        var args = new PutObjectArgs()
            .WithBucket(bucketName)
            .WithObject(objectName)
            .WithFileName(fileName);

        await _client.PutObjectAsync(args, cancellationToken)
            .ConfigureAwait(false);

        _logger.LogInformation("Object: {ObjectName} with name: {FileName} saved to bucket: {BucketName}", objectName, fileName, bucketName);
    }

    public async Task<Uri> GetPresigned(string bucketName, string objectName, int expiry, CancellationToken cancellationToken = default)
    {
        var args = new PresignedGetObjectArgs()
            .WithBucket(bucketName)
            .WithObject(objectName)
            .WithExpiry(expiry);

        var url = await _client.PresignedGetObjectAsync(args)
            .ConfigureAwait(false);

        return new Uri(url);
    }
}
