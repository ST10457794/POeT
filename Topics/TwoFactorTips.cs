namespace CybersecurityChatbot.Topics;

public static class TwoFactorTips
{
    public static void Show(string sentiment)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        
        if (sentiment == "concerned")
        {
            Console.WriteLine("2FA is one of the best ways to protect your accounts. Here's why and how:");
        }
        else if (sentiment == "uncertain")
        {
            Console.WriteLine("Two-factor authentication is simpler than it sounds. Let me explain:");
        }
        
        Console.WriteLine("Two-Factor Authentication (2FA):");
        Console.WriteLine("- Always enable for email, banking, and social media");
        Console.WriteLine("- Use authenticator apps (Google/Microsoft Authenticator) over SMS");
        Console.WriteLine("- Store backup codes securely (password manager or printed)");
        Console.WriteLine("- Consider hardware security keys for high-value accounts");
        Console.WriteLine("- Enable push notifications for authentication attempts");
        Console.WriteLine("- Be wary of 2FA fatigue attacks (pushing approvals until you accept)");
        Console.ResetColor();
        Console.WriteLine();
    }
    
    public static void ShowDetailed()
    {
        Console.WriteLine("In-depth guide to two-factor authentication methods:");
        Console.WriteLine();
        Console.WriteLine("1. 2FA Methods Ranked by Security:");
        Console.WriteLine("   • Hardware Security Keys (YubiKey, Titan): Most secure, phishing-resistant");
        Console.WriteLine("   • Authenticator Apps: Very secure, not tied to phone number");
        Console.WriteLine("   • Push Notifications: Convenient but vulnerable to approval fatigue");
        Console.WriteLine("   • SMS: Better than nothing but vulnerable to SIM swapping");
        Console.WriteLine("   • Email: Generally not recommended as a second factor");
        Console.WriteLine();
        Console.WriteLine("2. Setting Up Authenticator Apps:");
        Console.WriteLine("   • Use apps that support encrypted backups (Authy, 2FAS)");
        Console.WriteLine("   • Set up on multiple devices when possible");
        Console.WriteLine("   • Use separate authentication apps for highest-value accounts");
        Console.WriteLine("   • Always save backup codes in multiple secure locations");
        Console.WriteLine();
        Console.WriteLine("3. Hardware Security Key Strategy:");
        Console.WriteLine("   • Register at least two keys for redundancy");
        Console.WriteLine("   • Keep one key in a secure offsite location");
        Console.WriteLine("   • Consider keys with biometric verification");
        Console.WriteLine("   • Select FIDO2/WebAuthn compatible devices");
        Console.WriteLine();
        Console.WriteLine("4. Common 2FA Attack Vectors:");
        Console.WriteLine("   • SIM swapping: Attackers transfer your phone number to their device");
        Console.WriteLine("   • Phishing: Fake sites that capture both password and 2FA code");
        Console.WriteLine("   • Approval bombing: Repeatedly sending authentication requests");
        Console.WriteLine("   • Man-in-the-middle: Real-time interception and replay of credentials");
    }
}