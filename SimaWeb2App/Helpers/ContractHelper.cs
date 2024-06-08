using System.Text;
using System.Text.Json;
using SimaWeb2App.Models.TsContainer;

namespace SimaWeb2App.Helpers;

public static class ContractHelper
{
    private const string AlgorithmName = "HMACSHA256";

    /// <summary>
    /// Creates a contract with the given signable container and secret key.
    /// </summary>
    /// <param name="signableContainer">The container with signable data.</param>
    /// <param name="secretKey">The secret key used for generating the signature.</param>
    /// <returns>A new Contract object containing the signable container and header information.</returns>
    internal static Contract CreateContract(SignableContainer signableContainer, string secretKey) =>
        new()
        {
            SignableContainer = signableContainer,
            Header = new Header
            {
                AlgorithmName = AlgorithmName,
                Signature = CreateSignature(signableContainer, secretKey)
            }
        };

    /// <summary>
    /// Creates a signature for the given model and secret key.
    /// </summary>
    /// <typeparam name="T">The type of the signable container.</typeparam>
    /// <param name="model">The model to be signed.</param>
    /// <param name="secretKey">The secret key used for generating the signature.</param>
    /// <returns>A byte array representing the generated signature.</returns>
    private static byte[] CreateSignature<T>(T model, string secretKey) where T : SignableContainer
    {
        var json = JsonSerializer.Serialize(model).Trim();
        var computedHashAsByte = CryptHelper.ComputeSha256HashAsByte(json);
        return CryptHelper.GetHmac(computedHashAsByte, secretKey);
    }

    /// <summary>
    /// Encodes the given contract into a base64 string.
    /// </summary>
    /// <param name="model">The contract to be encoded.</param>
    /// <returns>A base64 string representation of the encoded contract.</returns>
    internal static string EncodeContract(Contract model)
    {
        var json = JsonSerializer.Serialize(model);
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
    }
}
