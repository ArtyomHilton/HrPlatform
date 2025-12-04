using System.Text.Json.Serialization;

namespace HrPlatform.Common.Options;

public class MessageBusOptions
{
    [JsonPropertyName("MESSAGE_BUS_CONNECTION_STRING")]
    public string ConnectionString { get; set; } = string.Empty;

    [JsonPropertyName("MESSAGE_BUS_QUEUE_NAME")]
    public string InputQueueName { get; set; } = string.Empty;
}
