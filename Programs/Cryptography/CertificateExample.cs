// Program: CertificateExample
// Difficulty: High
// Description: Creates and inspects X.509 self-signed certificates.
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

class CertificateExample
{
    static void Main(string[] args)
    {
        // Create a self-signed certificate
        using var rsa = RSA.Create(2048);
        var req = new CertificateRequest("CN=Example, O=Test Org, C=US",
            rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

        req.CertificateExtensions.Add(new X509BasicConstraintsExtension(false, false, 0, true));
        req.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(req.PublicKey, false));

        DateTimeOffset notBefore = DateTimeOffset.UtcNow;
        DateTimeOffset notAfter  = notBefore.AddYears(1);
        using var cert = req.CreateSelfSigned(notBefore, notAfter);

        Console.WriteLine($"Subject:    {cert.Subject}");
        Console.WriteLine($"Thumbprint: {cert.Thumbprint}");
        Console.WriteLine($"Not Before: {cert.NotBefore:yyyy-MM-dd}");
        Console.WriteLine($"Not After:  {cert.NotAfter:yyyy-MM-dd}");
        Console.WriteLine($"Key Size:   {rsa.KeySize} bits");
        Console.WriteLine($"Has Private Key: {cert.HasPrivateKey}");

        // Export and import
        byte[] exported = cert.Export(X509ContentType.Cert);
        using var imported = new X509Certificate2(exported);
        Console.WriteLine($"Imported subject: {imported.Subject}");
    }
}
