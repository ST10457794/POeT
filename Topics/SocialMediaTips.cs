namespace CybersecurityChatbot.Topics;

public static class SocialMediaTips
{
    public static void Show(string sentiment)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        
        if (sentiment == "concerned")
        {
            Console.WriteLine("Social media privacy is important. Here's how to stay safe while staying connected:");
        }
        else if (sentiment == "uncertain")
        {
            Console.WriteLine("Social media can be safe when you follow these guidelines:");
        }
        
        Console.WriteLine("Social media safety:");
        Console.WriteLine("- Review privacy settings monthly (platforms often change defaults)");
        Console.WriteLine("- Be cautious with quizzes/apps that request permissions");
        Console.WriteLine("- Don't post sensitive info (vacation dates, license plates)");
        Console.WriteLine("- Enable login approvals/notifications");
        Console.WriteLine("- Be selective about friend/connection requests");
        Console.WriteLine("- Review tagged photos before allowing on your profile");
        Console.WriteLine("- Assume anything you post could become public");
        Console.ResetColor();
        Console.WriteLine();
    }
    
    public static void ShowDetailed()
    {
        Console.WriteLine("Platform-specific social media security strategies:");
        Console.WriteLine();
        Console.WriteLine("1. Facebook Security:");
        Console.WriteLine("   • Run the Privacy Checkup and Security Checkup tools quarterly");
        Console.WriteLine("   • Set default audience for posts to 'Friends' instead of 'Public'");
        Console.WriteLine("   • Review and limit data used for ad targeting");
        Console.WriteLine("   • Disable facial recognition features");
        Console.WriteLine("   • Review apps with access to your Facebook account");
        Console.WriteLine();
        Console.WriteLine("2. Instagram Privacy:");
        Console.WriteLine("   • Consider a private account for personal content");
        Console.WriteLine("   • Disable 'Similar Account Suggestions'");
        Console.WriteLine("   • Review tagged photos before they appear on your profile");
        Console.WriteLine("   • Limit location sharing in posts");
        Console.WriteLine("   • Use Close Friends for more sensitive content");
        Console.WriteLine();
        Console.WriteLine("3. LinkedIn Protection:");
        Console.WriteLine("   • Adjust visibility of your connections");
        Console.WriteLine("   • Control profile visibility to third-party services");
        Console.WriteLine("   • Manage what others see when you view their profile");
        Console.WriteLine("   • Be cautious with connection requests from unknown profiles");
        Console.WriteLine();
        Console.WriteLine("4. General Safety Practices:");
        Console.WriteLine("   • Create unique passwords for each social platform");
        Console.WriteLine("   • Enable two-factor authentication on all accounts");
        Console.WriteLine("   • Log out when using shared devices");
        Console.WriteLine("   • Periodically review and delete old posts and photos");
        Console.WriteLine("   • Be cautious about biographical information that could be used in security questions");
    }
}