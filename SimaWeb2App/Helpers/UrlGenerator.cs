using SimaWeb2App.Models.TsContainer;

namespace SimaWeb2App.Helpers;

internal static class UrlGenerator
{
    /// <summary>
    /// Generates a URL for getting a file by appending an encoded query string to the base URL.
    /// </summary>
    /// <param name="getFileUrl">The base URL to get the file.</param>
    /// <param name="encodedString">The encoded query string to be appended.</param>
    /// <returns>The full URL with the encoded query string appended, or an empty string if the encoded string is null or empty.</returns>
    private static string GenerateGetFileUrl(string getFileUrl, string encodedString)
    {
        if (string.IsNullOrEmpty(encodedString))
            return string.Empty;

        return getFileUrl + "/?tsquery=" + encodedString;
    }

    /// <summary>
    /// Generates a universal link from the given URL.
    /// </summary>
    /// <param name="url">The URL to be converted into a universal link.</param>
    /// <returns>A universal link string in the format "sima://web-to-app?data={url}".</returns>
    internal static string GenerateUniversalLink(string url) => $"sima://web-to-app?data={url}";

    /// <summary>
    /// A helper method to generate a URL with a provided transformation function.
    /// </summary>
    /// <param name="getFileUrl">The base URL to get the file.</param>
    /// <param name="signableContainer">The signable container to be included in the contract.</param>
    /// <param name="secretKey">The secret key used to sign the contract.</param>
    /// <param name="transformUrlFunc">The function to transform the URL.</param>
    /// <returns>The transformed URL.</returns>
    internal static string GenerateUrl(string getFileUrl, SignableContainer signableContainer, string secretKey,
        Func<string, string> transformUrlFunc)
    {
        var contract = ContractHelper.CreateContract(signableContainer, secretKey);
        var encodedContract = ContractHelper.EncodeContract(contract);
        var url = GenerateGetFileUrl(getFileUrl, encodedContract);
        return transformUrlFunc(url);
    }
}