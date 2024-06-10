## SimaWeb2App Integration Library

### Description:
The SimaWeb2App Integration Library provides a robust and secure way to integrate with the Sima Web2App protocol, facilitating seamless data exchange between service providers and identity providers. This library includes functionalities for generating and validating contracts, creating QR codes, and managing cryptographic operations.

### Features:
- **Contract Generation and Encoding:** Easily create and encode contracts for secure data exchange.
- **QR Code Generation:** Generate QR codes as Base64 strings or byte arrays for various use cases using public methods.
- **Timestamp Certificate Validation:** Validate timestamp certificates using provided signing algorithms.
- **Flexible and Extendable Models:** Use pre-defined models like `OperationInfo`, `ClientInfo`, `ProtoInfo`, `SignableContainer`, and more for clear and structured data representation.
- **Error Handling:** Robust error handling for unsupported signing algorithms and other edge cases.

### Installation:
Clone the repository and include the library in your .NET project.

```bash
git clone https://github.com/AgilBashirov/SimaWeb2App.git
```

### NuGet Packages:
When using this library, make sure to install the following packages from NuGet:

```powershell
Install-Package BouncyCastle.Crypto -Version 1.8.1
Install-Package SkiaSharp -Version 2.88.8
Install-Package SkiaSharp.QrCode -Version 6.4.0
```

### Usage:

#### Generating QR Codes:
Use the public methods `GenerateQrCodeAsBase64` and `GenerateQrCodeAsByte` for generating QR codes.

```csharp
using SimaWeb2App.Helpers;

string getFileUrl = "https://example.com";
var signableContainer = new SignableContainer
{
    ProtoInfo = new ProtoInfo(),
    OperationInfo = new OperationInfo
    {
        Type = "Auth", /* or "Sign" */
        OperationId = "123456789",
        NbfUtc = 1649721600,
        ExpUtc = 1650326400,
        Assignee = new List<string> { "Pin1", "Pin2" }
    },
    ClientInfo = new ClientInfo
    {
        ClientId = 1,
        ClientName = "MyApp",
        IconUri = "https://example.com/icon.png",
        Callback = "https://example.com/callback",
        RedirectUri = "https://example.com/redirect"
    },
    DataInfo = new DataInfo /* Optional */
    {
        DataUri = "https://example.com/data",
        AlgName = "SHA256",
        FingerPrint = "base64FingerPrint"
    }
};
string secretKey = "your_secret_key";

string qrCodeBase64 = SimaHelper.GenerateQrCodeAsBase64(getFileUrl, signableContainer, secretKey);
byte[] qrCodeBytes = SimaHelper.GenerateQrCodeAsByte(getFileUrl, signableContainer, secretKey);
```

#### Validating Timestamp Certificates:
Use the public method `TsCertValidation` to validate timestamp certificates.

```csharp
using SimaWeb2App;

bool isValid = SimaHelper.TsCertValidation(
    tsCert: "base64EncodedCert",
    tcSign: "base64EncodedSignature",
    tsSignAlg: "ECDSA_SHA256",
    processBuffer: new byte[] { /* your data */ }
);
```

#### Generating a Button Link:
Use the public method `GenerateButtonLink` to generate a URL link for a button.

```csharp
string buttonLink = SimaHelper.GenerateButtonLink(getFileUrl, signableContainer, secretKey);
```

#### Converting Path and Query String to Bytes:
Use the public method `GetRequestPathAndQueryStringAsBytes` to convert the path and query string into a byte array.

```csharp
byte[] pathAndQueryBytes = SimaHelper.GetRequestPathAndQueryStringAsBytes("/path", "?query=string");
```

### Contributing:
We welcome contributions! Please submit issues and pull requests for new features, bug fixes, and enhancements.

### License:
This project is licensed under the MIT License. For more details, see the [Privacy Policy](https://www.sima.az/az/privacy-policy).