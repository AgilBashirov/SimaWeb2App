using System.Text.Json.Serialization;

namespace SimaWeb2App.Models.TsContainer;

public sealed record ProtoInfo
{
    /// <summary>
    /// Protocol name, default is "web2app".
    /// </summary>
    [JsonPropertyName("Name")]
    public string Name { private get; init; } = "web2app";

    /// <summary>
    /// Protocol version, default is "1.3".
    /// </summary>
    [JsonPropertyName("Version")]
    public string Version { get; init; } = "1.3";
}