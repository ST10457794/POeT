namespace CybersecurityChatbot.Topics;

public static class PrivacyTips
{
    public static void Show(string sentiment)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        
        if (sentiment == "concerned")
        {
            Console.WriteLine("Privacy is a valid concern in today's digital world. Here's how to protect yours:");
        }
        else if (sentiment == "uncertain")
        {
            Console.WriteLine("Let's start with the basics of protecting your privacy online:");
        }
        
        Console.WriteLine("Advanced privacy protection:");
        Console.WriteLine("- Use encrypted messaging apps (Signal, WhatsApp) instead of SMS");
        Console.WriteLine("- Review app permissions monthly and revoke unnecessary access");
        Console.WriteLine("- Consider using an alias email for non-critical accounts");
        Console.WriteLine("- Enable 'Find My Device' and remote wipe capabilities");
        Console.WriteLine("- Use private browsing or privacy-focused browsers like Firefox or Brave");
        Console.WriteLine("- Opt out of data collection when possible");
        Console.WriteLine("- Regularly check haveibeenpwned.com for data breaches");
        Console.ResetColor();
        Console.WriteLine();
    }
    
    public static void ShowDetailed()
    {
        Console.WriteLine("Privacy protection strategy by platform:");
        Console.WriteLine();
        Console.WriteLine("1. Desktop/Laptop Privacy:");
        Console.WriteLine("   • Adjust OS privacy settings (location, telemetry, ad tracking)");
        Console.WriteLine("   • Use a privacy-focused DNS (Quad9, NextDNS)");
        Console.WriteLine("   • Install privacy extensions (uBlock Origin, Privacy Badger)");
        Console.WriteLine("   • Enable disk encryption (BitLocker, FileVault)");
        Console.WriteLine("   • Consider a webcam cover for when not in use");
        Console.WriteLine();
        Console.WriteLine("2. Mobile Device Privacy:");
        Console.WriteLine("   • Audit app permissions regularly (especially location, contacts, microphone)");
        Console.WriteLine("   • Use app alternatives that respect privacy (ProtonMail, Signal)");
        Console.WriteLine("   • Disable ad personalization in Google/Apple accounts");
        Console.WriteLine("   • Use biometric authentication with strong backup passwords");
        Console.WriteLine("   • Consider a privacy screen protector for public use");
        Console.WriteLine();
        Console.WriteLine("3. Online Services Privacy:");
        Console.WriteLine("   • Create email aliases for different service categories");
        Console.WriteLine("   • Regularly delete unused accounts (AccountKiller.com helps)");
        Console.WriteLine("   • Use private or incognito browsing for sensitive searches");
        Console.WriteLine("   • Opt out of data brokers (PrivacyDuck, DeleteMe services)");
        Console.WriteLine();
        Console.WriteLine("4. Social Media Privacy:");
        Console.WriteLine("   • Review and limit profile visibility");
        Console.WriteLine("   • Disable location tagging in posts");
        Console.WriteLine("   • Control third-party app connections to social accounts");
        Console.WriteLine("   • Regularly download and review your data");
    }
}