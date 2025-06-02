namespace CybersecurityChatbot.Topics;

public static class MobileSecurityTips
{
    public static void Show(string sentiment)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        
        if (sentiment == "concerned")
        {
            Console.WriteLine("Mobile devices contain our most sensitive data. Here's how to protect them:");
        }
        else if (sentiment == "uncertain")
        {
            Console.WriteLine("Let me explain the basics of keeping your smartphone secure:");
        }
        
        Console.WriteLine("Mobile device security best practices:");
        Console.WriteLine("- Keep your OS and apps updated automatically");
        Console.WriteLine("- Use biometric authentication with a strong backup PIN (6+ digits)");
        Console.WriteLine("- Only install apps from official app stores");
        Console.WriteLine("- Review app permissions regularly and limit them");
        Console.WriteLine("- Enable remote tracking and wiping capabilities");
        Console.WriteLine("- Use app-specific passwords for sensitive applications");
        Console.WriteLine("- Encrypt your device (usually enabled by default on modern phones)");
        Console.ResetColor();
        Console.WriteLine();
    }
    
    public static void ShowDetailed()
    {
        Console.WriteLine("Comprehensive mobile device security framework:");
        Console.WriteLine();
        Console.WriteLine("1. Device Setup Security:");
        Console.WriteLine("   • Use alphanumeric passcode (not just 4-6 digits)");
        Console.WriteLine("   • Configure auto-lock after 1-2 minutes of inactivity");
        Console.WriteLine("   • Enable biometrics but use passcode after restart");
        Console.WriteLine("   • Encrypt device backups");
        Console.WriteLine("   • Setup Find My Device/Find My iPhone");
        Console.WriteLine("   • Configure emergency information for first responders");
        Console.WriteLine();
        Console.WriteLine("2. App Security Management:");
        Console.WriteLine("   • Review permissions during installation");
        Console.WriteLine("   • Regularly audit existing app permissions");
        Console.WriteLine("   • Remove unused apps quarterly");
        Console.WriteLine("   • Use app-specific passwords for important services");
        Console.WriteLine("   • Install security apps from trusted providers");
        Console.WriteLine("   • Check app ratings and developer reputation before installing");
        Console.WriteLine();
        Console.WriteLine("3. Data Protection Strategies:");
        Console.WriteLine("   • Use secure messaging apps with end-to-end encryption");
        Console.WriteLine("   • Enable auto-backup to encrypted cloud storage");
        Console.WriteLine("   • Use secure folders for sensitive documents");
        Console.WriteLine("   • Clear browser data regularly");
        Console.WriteLine("   • Use privacy screens in public places");
        Console.WriteLine();
        Console.WriteLine("4. Travel Security Measures:");
        Console.WriteLine("   • Create travel profile with minimal data");
        Console.WriteLine("   • Enable travel alerts on financial apps");
        Console.WriteLine("   • Use travel-specific passwords");
        Console.WriteLine("   • Update device before travel, not during");
        Console.WriteLine("   • Be cautious of public charging stations (use power banks)");
    }
}