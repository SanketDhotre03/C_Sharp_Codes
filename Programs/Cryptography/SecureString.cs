// Program: SecureString
// Difficulty: Medium
// Description: Demonstrates secure handling of sensitive strings in memory.
using System;
using System.Runtime.InteropServices;
using System.Security;

class SecureStringDemo
{
    static SecureString GetSecureInput(string prompt)
    {
        Console.Write(prompt);
        var secure = new SecureString();
        // Simulate reading chars (in real app, read from Console one char at a time)
        foreach (char c in "P@ssw0rd!")
            secure.AppendChar(c);
        secure.MakeReadOnly();
        Console.WriteLine("(input captured)");
        return secure;
    }

    static void UseSecureString(SecureString ss)
    {
        IntPtr ptr = Marshal.SecureStringToGlobalAllocUnicode(ss);
        try
        {
            string value = Marshal.PtrToStringUni(ptr);
            Console.WriteLine($"Length: {value.Length} chars");
            Console.WriteLine($"Valid: {value.Length >= 8}");
        }
        finally { Marshal.ZeroFreeGlobalAllocUnicode(ptr); }
    }

    static void Main(string[] args)
    {
        using var password = GetSecureInput("Enter password: ");
        Console.WriteLine($"IsReadOnly: {password.IsReadOnly()}");
        UseSecureString(password);
        Console.WriteLine("SecureString cleared after use.");
    }
}
