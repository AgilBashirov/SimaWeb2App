using System.Text.Json.Serialization;

namespace SimaWeb2App.Models.TsContainer;

public record SignableContainer
{
    /// <summary>
    /// Contains protocol information, including the protocol name and version.
    /// </summary>
    [JsonPropertyName("ProtoInfo")]
    internal ProtoInfo ProtoInfo { get; init; } = default!;

    /// <summary>
    /// Contains information about the operation, such as type, operation ID, and timestamps.
    /// </summary>
    [JsonPropertyName("OperationInfo")]
    public OperationInfo OperationInfo { get; init; } = default!;

    /// <summary>
    /// Contains information about the client, such as client ID, name, icon URI, and callback URL.
    /// </summary>
    [JsonPropertyName("ClientInfo")]
    public ClientInfo ClientInfo { get; init; } = default!;

    /// <summary>
    /// Contains optional data information, such as data URI, algorithm name, and fingerprint.
    /// </summary>
    [JsonPropertyName("DataInfo")]
    public DataInfo? DataInfo { get; init; }
}