using System.Text.Json.Serialization;

namespace SimaWeb2App.Models.TsContainer;

internal sealed record Contract
{
    /// <summary>
    /// The container that holds all the signable data, including protocol info, operation info, client info, and optionally data info.
    /// </summary>
    [JsonPropertyName("SignableContainer")]
    public SignableContainer SignableContainer { get; init; } = default!;

    /// <summary>
    /// The header information for the contract, including the algorithm name and the signature.
    /// </summary>
    [JsonPropertyName("Header")]
    public Header Header { get; init; } = new();
}