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

    public async Task<bool> PutFile(string bucketName, string objectName, Stream fileStream, CancellationToken cancellationToken = default)
    {
        if (!await BucketExist(bucketName, cancellationToken))
        {
            await CreateBucket(bucketName, cancellationToken);
        }

        try
        {
            var args = new PutObjectArgs()
                .WithBucket(bucketName)
                .WithObject(objectName)
                .WithStreamData(fileStream)
                .WithObjectSize(fileStream.Length);

            await _client.PutObjectAsync(args, cancellationToken);

            _logger.LogInformation("Object: {ObjectName} saved to bucket: {BucketName}", objectName, bucketName);

            return true;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Object: {ObjectName} don't save. Exception: {Exception}", objectName, exception.GetType().Name);

            return false;
        }
    }

    public async Task DeleteFile(string bucketName, string objectName, CancellationToken cancellationToken = default)
    {
        var args = new RemoveObjectArgs()
            .WithBucket(bucketName)
            .WithObject(objectName);

        await _client.RemoveObjectAsync(args, cancellationToken);
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

    private async Task<bool> BucketExist(string bucketName, CancellationToken cancellationToken = default)
    {
        var args = new BucketExistsArgs()
            .WithBucket(bucketName);

        return await _client.BucketExistsAsync(args, cancellationToken);
    }

    private async Task CreateBucket(string bucketName, CancellationToken cancellationToken = default)
    {
        var args = new MakeBucketArgs()
            .WithBucket(bucketName);

        await _client.MakeBucketAsync(args, cancellationToken);
    }
}
