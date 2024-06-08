using System.Text.Json.Serialization;

namespace SimaWeb2App.Models.TsContainer;

public sealed record ClientInfo
{
    /// <summary>
    /// Client ID that is provided by the Identity Provider (IDP).
    /// </summary>
    [JsonPropertyName("ClientId")]
    public int ClientId { get; init; }

    /// <summary>
    /// The name of the resource application.
    /// </summary>
    [JsonPropertyName("ClientName")]
    public string ClientName { get; init; } = default!;

    /// <summary>
    /// Public icon URL (e.g., SVG, PNG, JPEG).
    /// </summary>
    [JsonPropertyName("IconURI")]
    public string IconUri { get; init; } = default!;

    /// <summary>
    /// Public callback URL of the system.
    /// </summary>
    [JsonPropertyName("Callback")]
    public string Callback { get; init; } = default!;

    /// <summary>
    /// List of allowed hosts, if any.
    /// </summary>
    [JsonPropertyName("HostName")]
    public string[]? HostName { get; init; }

    /// <summary>
    /// Redirect URI for the app, if any.
    /// </summary>
    [JsonPropertyName("RedirectURI")]
    public string? RedirectUri { get; init; }
}