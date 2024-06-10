using System.Text;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using SimaWeb2App.Helpers;
using SimaWeb2App.Models.TsContainer;

namespace SimaWeb2App;

/// <summary>
/// The SimaHelper class provides methods to generate QR codes, validate timestamp certificates, and convert paths and query strings to byte arrays.
/// </summary>
public static class SimaHelper
{
    /// <summary>
    /// Generates a QR code in base64 format from the given URL, signable container, and secret key.
    /// </summary>
    /// <param name="getFileUrl">The base URL to get the file.</param>
    /// <param name="signableContainer">The signable container to be included in the contract.</param>
    /// <param name="secretKey">The secret key used to sign the contract.</param>
    /// <returns>A base64 string representation of the generated QR code.</returns>
    public static string GenerateQrCodeAsBase64(string getFileUrl, SignableContainer signableContainer,
        string secretKey)
    {
        return QrHelper.GenerateQrCode(getFileUrl, signableContainer, secretKey, QrHelper.GenerateQrAsBase64);
    }


    /// <summary>
    /// Generates a QR code as a byte array from the given URL, signable container, and secret key.
    /// </summary>
    /// <param name="getFileUrl">The base URL to get the file.</param>
    /// <param name="signableContainer">The signable container to be included in the contract.</param>
    /// <param name="secretKey">The secret key used to sign the contract.</param>
    /// <returns>A byte array representation of the generated QR code.</returns>
    public static byte[] GenerateQrCodeAsByte(string getFileUrl, SignableContainer signableContainer, string secretKey)
    {
        return QrHelper.GenerateQrCode(getFileUrl, signableContainer, secretKey, QrHelper.GenerateQrAsByte);
    }


    /// <summary>
    /// Generates a URL link for a button from the given URL, signable container, and secret key.
    /// </summary>
    /// <param name="getFileUrl">The base URL to get the file.</param>
    /// <param name="signableContainer">The signable container to be included in the contract.</param>
    /// <param name="secretKey">The secret key used to sign the contract.</param>
    /// <returns>A URL string that can be used as a button link.</returns>
    public static string GenerateButtonLink(string getFileUrl, SignableContainer signableContainer, string secretKey)
    {
        return UrlGenerator.GenerateUrl(getFileUrl, signableContainer, secretKey, UrlGenerator.GenerateUniversalLink);
    }

    /// <summary>
    /// Validates a timestamp certificate using the given certificate, signature, signing algorithm, and process buffer.
    /// </summary>
    /// <param name="tsCert">The timestamp certificate in base64 string format.</param>
    /// <param name="tcSign">The timestamp signature in base64 string format.</param>
    /// <param name="tsSignAlg">The signing algorithm used for the timestamp.</param>
    /// <param name="processBuffer">The byte array buffer to be processed and validated.</param>
    /// <returns>True if the certificate is valid, otherwise false.</returns>
    /// <exception cref="ArgumentException">Thrown when an unsupported signing algorithm is provided.</exception>
    public static bool TsCertValidation(string tsCert, string tcSign, string tsSignAlg, byte[] processBuffer)
    {
        var certParser = new X509CertificateParser();
        var cert = certParser.ReadCertificate(Convert.FromBase64String(tsCert));

        var signAlg = tsSignAlg switch
        {
            "ECDSA_SHA256" => "SHA-256withECDSA",
            "HMACSHA256" => "HMAC-SHA256",
            _ => throw new ArgumentException($"Unsupported signing algorithm: {tsSignAlg}", nameof(tsSignAlg))
        };

        var signer = SignerUtilities.GetSigner(signAlg);
        signer.Init(false, cert.GetPublicKey());
        signer.BlockUpdate(processBuffer, 0, processBuffer.Length);
        return signer.VerifySignature(Convert.FromBase64String(tcSign));
    }


    /// <summary>
    /// Converts the given path and query string into a byte array.
    /// </summary>
    /// <param name="path">The request path.</param>
    /// <param name="queryString">The query string.</param>
    /// <returns>A byte array representation of the concatenated path and query string.</returns>
    public static byte[] GetRequestPathAndQueryStringAsBytes(string path, string queryString)
    {
        return Encoding.UTF8.GetBytes(path + queryString);
    }
}