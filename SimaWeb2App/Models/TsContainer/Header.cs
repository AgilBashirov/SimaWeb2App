using System.Text.Json.Serialization;

namespace SimaWeb2App.Models.TsContainer;

public sealed record Header
{
    /// <summary>
    /// Algorithm name used for the contract's signature (e.g., HMACSHA256).
    /// </summary>
    [JsonPropertyName("AlgName")]
    public string AlgorithmName { get; init; }

    /// <summary>
    /// Base64 encoded signature of the contract.
    /// </summary>
    [JsonPropertyName("Signature")]
    public byte[] Signature { get; init; }
}