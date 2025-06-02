namespace CybersecurityChatbot.Topics;

public static class BrowsingTips
{
    public static void Show(string sentiment)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        
        if (sentiment == "concerned")
        {
            Console.WriteLine("I understand your concerns about online safety. Here are proven ways to browse more securely:");
        }
        else if (sentiment == "uncertain")
        {
            Console.WriteLine("Safe browsing doesn't have to be complicated. Here are the key things to remember:");
        }
        
        Console.WriteLine("Safe browsing practices:");
        Console.WriteLine("- Look for 'https://' and padlock icon (but know some malicious sites use HTTPS too)");
        Console.WriteLine("- Use browser extensions like uBlock Origin and Privacy Badger");
        Console.WriteLine("- Clear cookies regularly or use private browsing mode");
        Console.WriteLine("- Be extremely cautious with browser extensions - only install from official stores");
        Console.WriteLine("- Consider using a separate browser for sensitive activities (banking)");
        Console.WriteLine("- Keep your browser and extensions updated automatically");
        Console.WriteLine("- Use a password manager's autofill to avoid typing credentials on fake sites");
        Console.ResetColor();
        Console.WriteLine();
    }
    
    public static void ShowDetailed()
    {
        Console.WriteLine("Advanced browser security configuration guide:");
        Console.WriteLine();
        Console.WriteLine("1. Essential Browser Security Extensions:");
        Console.WriteLine("   • uBlock Origin: Block ads and trackers");
        Console.WriteLine("   • Privacy Badger: Learn and block invisible trackers");
        Console.WriteLine("   • HTTPS Everywhere: Enforce encrypted connections");
        Console.WriteLine("   • Decentraleyes: Protect against CDN tracking");
        Console.WriteLine();
        Console.WriteLine("2. Browser Settings to Adjust:");
        Console.WriteLine("   • Disable third-party cookies or use strict tracking prevention");
        Console.WriteLine("   • Enable 'Do Not Track' (limited effectiveness but doesn't hurt)");
        Console.WriteLine("   • Disable password saving in the browser (use a password manager)");
        Console.WriteLine("   • Configure automatic HTTPS upgrades");
        Console.WriteLine("   • Disable unnecessary permissions (location, notifications, camera)");
        Console.WriteLine();
        Console.WriteLine("3. Browser Compartmentalization Strategy:");
        Console.WriteLine("   • Browser 1: For banking, email, and sensitive accounts");
        Console.WriteLine("   • Browser 2: For general browsing and social media");
        Console.WriteLine("   • Browser 3: For untrusted sites or research");
        Console.WriteLine();
        Console.WriteLine("4. Additional Protection Measures:");
        Console.WriteLine("   • Consider a DNS-level filtering service (NextDNS, AdGuard DNS)");
        Console.WriteLine("   • Use a VPN for public Wi-Fi browsing");
        Console.WriteLine("   • Periodically clear browsing data (history, cache, cookies)");
        Console.WriteLine("   • Disable JavaScript for untrusted sites (with NoScript)");
    }
}