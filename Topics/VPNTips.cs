namespace CybersecurityChatbot.Topics;

public static class VPNTips
{
    public static void Show(string sentiment)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        
        if (sentiment == "concerned")
        {
            Console.WriteLine("VPNs are a great tool for online privacy. Here's what you need to know:");
        }
        else if (sentiment == "uncertain")
        {
            Console.WriteLine("Let me explain VPNs in simple terms and why they're useful:");
        }
        
        Console.WriteLine("VPN guidance:");
        Console.WriteLine("- Essential on public WiFi (airports, coffee shops)");
        Console.WriteLine("- Choose reputable providers (avoid free VPNs)");
        Console.WriteLine("- Understand VPNs don't make you anonymous - they just encrypt traffic");
        Console.WriteLine("- Enable kill switch feature if available");
        Console.WriteLine("- Check for DNS leak protection");
        Console.WriteLine("- Consider setting up your own VPN for maximum control");
        Console.ResetColor();
        Console.WriteLine();
    }
    
    public static void ShowDetailed()
    {
        Console.WriteLine("Comprehensive VPN selection and usage guide:");
        Console.WriteLine();
        Console.WriteLine("1. Understanding What VPNs Do and Don't Protect Against:");
        Console.WriteLine("   • DO protect: Your browsing from ISP monitoring");
        Console.WriteLine("   • DO protect: Your traffic on unsecured Wi-Fi networks");
        Console.WriteLine("   • DO NOT protect: Against malware or phishing");
        Console.WriteLine("   • DO NOT guarantee: Complete anonymity (your VPN provider can still see your activity)");
        Console.WriteLine();
        Console.WriteLine("2. Selecting a Trustworthy VPN:");
        Console.WriteLine("   • Look for no-logs policies that have been independently audited");
        Console.WriteLine("   • Check jurisdiction (where the company is based affects data laws)");
        Console.WriteLine("   • Verify they own their servers (not renting from third parties)");
        Console.WriteLine("   • Confirm they use modern encryption protocols (WireGuard, OpenVPN)");
        Console.WriteLine("   • Evaluate their history of handling government requests");
        Console.WriteLine();
        Console.WriteLine("3. Critical VPN Features:");
        Console.WriteLine("   • Kill switch: Blocks internet if VPN disconnects");
        Console.WriteLine("   • Split tunneling: Choose which apps use the VPN");
        Console.WriteLine("   • DNS leak protection: Prevents accidental unencrypted lookups");
        Console.WriteLine("   • Multi-hop connections: Route through multiple servers");
        Console.WriteLine();
        Console.WriteLine("4. Usage Best Practices:");
        Console.WriteLine("   • Always connect before joining public Wi-Fi");
        Console.WriteLine("   • Regularly test for leaks (dnsleaktest.com)");
        Console.WriteLine("   • Consider dedicated devices for different activities");
        Console.WriteLine("   • Remember that device fingerprinting can still identify you");
    }
}