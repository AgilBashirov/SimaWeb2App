using System.Text.Json.Serialization;

namespace SimaWeb2App.Models.TsContainer;

public sealed record OperationInfo
{
    /// <summary>
    /// Type of the operation. The reason the contract is generated.
    /// </summary>
    [JsonPropertyName("Type")]
    public string Type { get; init; } = default!;

    /// <summary>
    /// Transaction ID for the contract. Any string data.
    /// </summary>
    [JsonPropertyName("OperationId")]
    public string OperationId { get; init; } = default!;

    /// <summary>
    /// Not before or activation date as UNIX UTC timestamp.
    /// </summary>
    [JsonPropertyName("NbfUTC")]
    public long NbfUtc { get; init; }

    /// <summary>
    /// Not after or expiration date as UNIX UTC timestamp.
    /// </summary>
    [JsonPropertyName("ExpUTC")]
    public long ExpUtc { get; init; }

    /// <summary>
    /// People that are expected to sign or authenticate. List of PINs as strings.
    /// </summary>
    [JsonPropertyName("Assignee")]
    public List<string> Assignee { get; init; } = [];
}