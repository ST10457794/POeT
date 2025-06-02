namespace CybersecurityChatbot.Topics;

public static class PhishingTips
{
    public static void Show(string sentiment)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        
        if (sentiment == "concerned")
        {
            Console.WriteLine("It's good that you're cautious about phishing. Here's how to protect yourself:");
        }
        else if (sentiment == "uncertain")
        {
            Console.WriteLine("Let me explain phishing in simple terms and how to stay safe:");
        }
        
        Console.WriteLine("Phishing scams try to trick you into giving personal information:");
        Console.WriteLine("- Verify sender email addresses (hover to see the real address)");
        Console.WriteLine("- Watch for urgency tactics ('Your account will be closed!')");
        Console.WriteLine("- Never click links in unsolicited messages - go directly to the site");
        Console.WriteLine("- Check for poor grammar/spelling (but some attacks are well-written)");
        Console.WriteLine("- Don't open unexpected attachments, even from known contacts");
        Console.WriteLine("- Use email filtering and web security tools when available");
        Console.WriteLine("- Report phishing attempts to your IT department or email provider");
        Console.ResetColor();
        Console.WriteLine();
    }
    
    public static void ShowDetailed()
    {
        Console.WriteLine("Here's a real-world example of a sophisticated phishing attempt:");
        Console.WriteLine();
        Console.WriteLine("1. Initial Contact:");
        Console.WriteLine("   • Email appears to be from your bank with correct logo and formatting");
        Console.WriteLine("   • Subject: 'URGENT: Suspicious Transaction Detected'");
        Console.WriteLine("   • Contains partial account information to seem legitimate");
        Console.WriteLine("   • Creates urgency: 'Account will be locked in 24 hours if not verified'");
        Console.WriteLine();
        Console.WriteLine("2. Red Flags to Notice:");
        Console.WriteLine("   • Sender email: support@bankname-secure.com (not the official domain)");
        Console.WriteLine("   • Link URL doesn't match the bank's official site when hovered over");
        Console.WriteLine("   • Generic greeting ('Dear Customer') rather than your name");
        Console.WriteLine("   • Subtle grammar issues or awkward phrasing");
        Console.WriteLine();
        Console.WriteLine("3. What Happens If You Click:");
        Console.WriteLine("   • Redirected to a convincing fake website mimicking your bank's login page");
        Console.WriteLine("   • After entering credentials, may ask for additional information:");
        Console.WriteLine("     - Full Social Security Number");
        Console.WriteLine("     - Card numbers, expiration dates, CVV codes");
        Console.WriteLine("     - Account authentication questions");
        Console.WriteLine();
        Console.WriteLine("4. Latest Phishing Trends:");
        Console.WriteLine("   • AI-generated messages with fewer language errors");
        Console.WriteLine("   • 'Vishing' (voice phishing) calls that follow up on emails");
        Console.WriteLine("   • Text message (SMS) phishing with package delivery themes");
        Console.WriteLine("   • QR code phishing in public places or emails");
    }
}