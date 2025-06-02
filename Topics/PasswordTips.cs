namespace CybersecurityChatbot.Topics;

public static class PasswordTips
{
    public static void Show(string sentiment)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        
        // Adjust response based on sentiment
        if (sentiment == "concerned")
        {
            Console.WriteLine("I understand your concerns about password security. Let me help you with some straightforward tips:");
        }
        else if (sentiment == "uncertain")
        {
            Console.WriteLine("Don't worry! Password security can seem complicated, but I'll break it down into simple steps:");
        }
        
        Console.WriteLine("Password safety is crucial! Here are comprehensive tips:");
        Console.WriteLine("- Use at least 12 characters (16+ for important accounts)");
        Console.WriteLine("- Create passphrases: 'PurpleTiger$JumpsHigh!' is better than 'P@ssw0rd'");
        Console.WriteLine("- Never reuse passwords across sites");
        Console.WriteLine("- Enable biometric authentication where available");
        Console.WriteLine("- Use a reputable password manager (Bitwarden, 1Password)");
        Console.WriteLine("- Change passwords immediately after a data breach");
        Console.WriteLine("- Enable login notifications for important accounts");
        Console.ResetColor();
        Console.WriteLine();
    }
    
    public static void ShowDetailed()
    {
        Console.WriteLine("Here's a practical password management strategy:");
        Console.WriteLine();
        Console.WriteLine("1. Password Manager Setup:");
        Console.WriteLine("   • Install a trusted password manager (Bitwarden, 1Password, KeePass)");
        Console.WriteLine("   • Create a strong master password you can remember (but never use elsewhere)");
        Console.WriteLine("   • Enable two-factor authentication for your password manager");
        Console.WriteLine();
        Console.WriteLine("2. Password Creation Strategy:");
        Console.WriteLine("   • Use the manager's generator to create random 16-20 character passwords");
        Console.WriteLine("   • For passwords you must memorize, use the passphrase technique:");
        Console.WriteLine("     Random words + numbers + symbols (e.g., 'Correct-Horse-Battery-Staple-42!')");
        Console.WriteLine();
        Console.WriteLine("3. Password Audit Process:");
        Console.WriteLine("   • Use the password manager's audit tool to find weak/reused passwords");
        Console.WriteLine("   • Prioritize changing passwords for financial and email accounts");
        Console.WriteLine("   • Check haveibeenpwned.com monthly to see if your data was in breaches");
        Console.WriteLine();
        Console.WriteLine("4. Recovery Planning:");
        Console.WriteLine("   • Export encrypted password backup quarterly");
        Console.WriteLine("   • Store emergency access information in a secure location");
        Console.WriteLine("   • Document account recovery procedures for critical accounts");
    }
}