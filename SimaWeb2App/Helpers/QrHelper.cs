using SimaWeb2App.Models.TsContainer;
using SkiaSharp;
using SkiaSharp.QrCode;

namespace SimaWeb2App.Helpers;

internal static class QrHelper
{
    /// <summary>
    /// Generates a QR code from the given URL and returns it as a base64 string.
    /// </summary>
    /// <param name="qrUrl">The URL to encode into the QR code.</param>
    /// <returns>A base64 string representation of the generated QR code.</returns>
    internal static string GenerateQrAsBase64(string qrUrl)
    {
        var qrBytes = GenerateQrBytes(qrUrl);
        return Convert.ToBase64String(qrBytes);
    }

    /// <summary>
    /// Generates a QR code from the given URL and returns it as a byte array.
    /// </summary>
    /// <param name="qrUrl">The URL to encode into the QR code.</param>
    /// <returns>A byte array representation of the generated QR code.</returns>
    internal static byte[] GenerateQrAsByte(string qrUrl) => GenerateQrBytes(qrUrl);

    /// <summary>
    /// Generates a QR code from the given URL and returns it as a byte array.
    /// </summary>
    /// <param name="qrUrl">The URL to encode into the QR code.</param>
    /// <returns>A byte array representation of the generated QR code.</returns>
    private static byte[] GenerateQrBytes(string qrUrl)
    {
        using var generator = new QRCodeGenerator();
        // Generate QR code
        var qr = generator.CreateQrCode(qrUrl, ECCLevel.L);
        // Render to canvas
        var info = new SKImageInfo(306, 306);
        using var surface = SKSurface.Create(info);
        var canvas = surface.Canvas;
        canvas.Render(qr, info.Width, info.Height);
        // Output to Stream -> File
        using var image = surface.Snapshot();
        using var data = image.Encode(SKEncodedImageFormat.Jpeg, 100);
        return data.ToArray();
    }

    /// <summary>
    /// A helper method to generate a QR code using a provided generation function.
    /// </summary>
    /// <typeparam name="T">The return type of the QR code generation function.</typeparam>
    /// <param name="getFileUrl">The base URL to get the file.</param>
    /// <param name="signableContainer">The signable container to be included in the contract.</param>
    /// <param name="secretKey">The secret key used to sign the contract.</param>
    /// <param name="generateQrFunc">The function to generate the QR code.</param>
    /// <returns>The generated QR code in the specified format.</returns>
    internal static T GenerateQrCode<T>(string getFileUrl, SignableContainer signableContainer, string secretKey,
        Func<string, T> generateQrFunc)
    {
        var url = UrlGenerator.GenerateUrl(getFileUrl, signableContainer, secretKey,
            UrlGenerator.GenerateUniversalLink);
        return generateQrFunc(url);
    }
}