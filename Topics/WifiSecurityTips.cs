namespace CybersecurityChatbot.Topics;

public static class WifiSecurityTips
{
    public static void Show(string sentiment)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        
        if (sentiment == "concerned")
        {
            Console.WriteLine("Wireless networks can be vulnerable. Here's how to use them safely:");
        }
        else if (sentiment == "uncertain")
        {
            Console.WriteLine("Let me explain how to keep your Wi-Fi connections secure:");
        }
        
        Console.WriteLine("Wi-Fi security essentials:");
        Console.WriteLine("- Use a VPN when connecting to public Wi-Fi");
        Console.WriteLine("- Verify network names before connecting (watch for similar-looking fakes)");
        Console.WriteLine("- Keep Wi-Fi turned off when not in use");
        Console.WriteLine("- Use HTTPS websites exclusively on public networks");
        Console.WriteLine("- Consider using mobile data instead of public Wi-Fi for sensitive tasks");
        Console.WriteLine("- Secure your home network with WPA3 and a strong password");
        Console.WriteLine("- Change default router admin credentials");
        Console.ResetColor();
        Console.WriteLine();
    }
    
    public static void ShowDetailed()
    {
        Console.WriteLine("Comprehensive Wi-Fi security guide for both home and public networks:");
        Console.WriteLine();
        Console.WriteLine("1. Home Wi-Fi Network Hardening:");
        Console.WriteLine("   • Update router firmware regularly");
        Console.WriteLine("   • Use WPA3 encryption (or WPA2-AES if WPA3 unavailable)");
        Console.WriteLine("   • Create a complex network password (16+ characters)");
        Console.WriteLine("   • Change default SSID to something neutral (not your name/address)");
        Console.WriteLine("   • Enable guest network for visitors and IoT devices");
        Console.WriteLine("   • Use MAC address filtering as an additional layer");
        Console.WriteLine("   • Disable WPS (Wi-Fi Protected Setup)");
        Console.WriteLine();
        Console.WriteLine("2. Public Wi-Fi Protection Strategy:");
        Console.WriteLine("   • Use a VPN for all public Wi-Fi connections");
        Console.WriteLine("   • Disable file sharing when on public networks");
        Console.WriteLine("   • Enable firewall before connecting");
        Console.WriteLine("   • Forget networks after use");
        Console.WriteLine("   • Watch for shoulder surfing in public places");
        Console.WriteLine("   • Avoid accessing sensitive accounts when possible");
        Console.WriteLine();
        Console.WriteLine("3. Evil Twin Attack Prevention:");
        Console.WriteLine("   • Verify network name exactly (including spelling/capitalization)");
        Console.WriteLine("   • Ask staff for the correct network name");
        Console.WriteLine("   • Be suspicious of multiple similarly-named networks");
        Console.WriteLine("   • Use network trust features on your device");
        Console.WriteLine();
        Console.WriteLine("4. Mobile Hotspot Security:");
        Console.WriteLine("   • Change default hotspot password");
        Console.WriteLine("   • Use WPA3 encryption when available");
        Console.WriteLine("   • Turn off when not in use");
        Console.WriteLine("   • Set data limits to prevent overuse");
        Console.WriteLine("   • Hide SSID for additional obscurity");
    }
}