using System.Text.Json.Serialization;

namespace SimaWeb2App.Models.TsContainer;

public sealed record DataInfo
{
    /// <summary>
    /// URI of the data behind the contract.
    /// </summary>
    [JsonPropertyName("DataURI")]
    public required string DataUri { get; init; }

    /// <summary>
    /// Name of the hash algorithm used (e.g., SHA256).
    /// </summary>
    [JsonPropertyName("AlgName")]
    public string? AlgName { get; init; }

    /// <summary>
    /// Checksum of the data behind the contract, in base64 format.
    /// </summary>
    [JsonPropertyName("FingerPrint")]
    public string? FingerPrint { get; init; }
}