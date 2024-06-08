using System.Security.Cryptography;
using System.Text;

namespace SimaWeb2App.Helpers;

internal static class CryptHelper
{
    /// <summary>
    /// Computes the SHA-256 hash of the given raw data and returns it as a byte array.
    /// </summary>
    /// <param name="rawData">The raw string data to be hashed.</param>
    /// <returns>A byte array representing the SHA-256 hash of the input data.</returns>
    internal static byte[] ComputeSha256HashAsByte(string rawData) => SHA256.HashData(Encoding.UTF8.GetBytes(rawData));

    /// <summary>
    /// Generates an HMAC using the given SHA-256 hash byte array and secret key.
    /// </summary>
    /// <param name="computedSha256AsByte">The SHA-256 hash byte array.</param>
    /// <param name="secretKey">The secret key used for generating the HMAC.</param>
    /// <returns>A byte array representing the generated HMAC.</returns>
    internal static byte[] GetHmac(byte[] computedSha256AsByte, string secretKey)
    {
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey));
        return hmac.ComputeHash(computedSha256AsByte);
    }
}