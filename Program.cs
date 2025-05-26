using System;
using System.Threading;
using System.Runtime.InteropServices;
using System.Collections.Generic;

class Program
{
    // Stores user information during the session
    private static Dictionary<string, string> userMemory = new Dictionary<string, string>();
    private static Random random = new Random();

    static void Main(string[] args)
    {
        Console.Clear();
        PlayAudio(); //play welcome sound 
        DisplayWelcomeScreen();
        string userName = GetUserName();
        RunChatLoop(userName);
    }

    static void DisplayWelcomeScreen()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
               ___.                                .__                  .__   
  ____ ___.__.\_ |__   ___________    ______ ____ |  |__   ____   ____ |  |  
_/ ___<   |  | | __ \_/ __ \_  __ \  /  ___// ___\|  |  \ /  _ \ /  _ \|  |  
\  \___\___  | | \_\ \  ___/|  | \/  \___ \\  \___|   Y  (  <_> |  <_> )  |__
 \___  > ____| |___  /\___  >__|    /____  >\___  >___|  /\____/ \____/|____/
     \/\/          \/     \/             \/     \/     \/                         
");
        Console.ResetColor();
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("==============================================");
        Console.WriteLine("  CYBERSECURITY AWARENESS CHATBOT ");
        Console.WriteLine("==============================================");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("Welcome to the Cybersecurity Awareness Bot!");
        Console.WriteLine("I'm here to help you stay safe online.");
        Console.WriteLine();
    }
// Handles audio playback with different operating systems (MacOS,Windows,Linux)
    static void PlayAudio() 
{
    try
    {
        var process = new System.Diagnostics.Process();
        
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            // Windows - using Media Player 
            process.StartInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/C start mplay32 /play /close welcome.wav",
                UseShellExecute = false,
                CreateNoWindow = true
            };
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            // macOS - using afplay 
            process.StartInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "afplay",
                Arguments = "welcome.wav",
                UseShellExecute = false,
                CreateNoWindow = true
            };
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            // Linux - using aplay (ALSA) or paplay (PulseAudio)
            process.StartInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "bash",
                Arguments = "-c \"aplay welcome.wav || paplay welcome.wav\"",
                UseShellExecute = false,
                CreateNoWindow = true
            };
        }
        else
        {
            Console.WriteLine("Audio playback not supported on this platform");
            return;
        }

        using (process)
        {
            process.Start();
            Thread.Sleep(2000); // Let audio play for 2 seconds
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Couldn't play audio: {ex.Message}");
    }
}

    static string GetUserName() 
    {
        Console.Write("Hello! What's your name? ");
        string name = Console.ReadLine();
        
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please enter a valid name.");
            Console.ResetColor();
            Console.Write("Hello! What's your name? ");
            name = Console.ReadLine();
        }
        
        userMemory["name"] = name;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Nice to meet you, {name}! Let's talk about cybersecurity.");
        Console.ResetColor();
        Console.WriteLine();
        
        return name;
    }
    
    //conversation handler
    static void RunChatLoop(string userName)
    {
        bool continueChat = true;
        int conversationDepth = 0;
        
        DisplayHelpMenu();
        
        while (continueChat)
        {
            Console.Write($"{userName}: ");
            string input = Console.ReadLine()?.ToLower() ?? "";
            
            if (string.IsNullOrWhiteSpace(input))
            {
                ShowErrorMessage("I didn't quite understand that. Could you rephrase?");
                continue;
            }
            
            if (ProcessBasicCommands(input, userName, ref continueChat)) continue;
            if (ProcessSecurityTopics(input)) continue;
            if (ProcessFollowUpQuestions(input, ref conversationDepth)) continue;
            
            ShowErrorMessage("I didn't understand that. Try asking about:\n" +
                            "- Password safety\n- Phishing\n- Malware\n- Social media\n- VPNs\n" +
                            "- Two-factor auth\n- Data backups\n- Or say 'help' for more options");
        }
    }

    static bool ProcessBasicCommands(string input, string userName, ref bool continueChat) //(Static bool is always true, 2013)
    {
        if (input.Contains("bye") || input.Contains("exit") || input.Contains("quit"))
        {
            continueChat = false;
            ShowFarewellMessage(userName);
            return true;
        }
        else if (input.Contains("help"))
        {
            DisplayHelpMenu();
            return true;
        }
        else if (input.Contains("thanks") || input.Contains("thank you"))
        {
            ShowResponse(GetRandomResponse(new[] {
                "You're welcome!",
                "Happy to help!",
                "That's what I'm here for!"
            }));
            return true;
        }
        else if (input.Contains("how are you"))
        {
            ShowResponse(GetRandomResponse(new[] {
                "I'm just a bot, but I'm functioning well! Ready to help with cybersecurity questions:)",
                "Doing great! Let me know how I can help with cybersecurity today ;)",
                "I don't have feelings, but my threat detection algorithms are at 100% ;)"
            }));
            return true;
        }
        else if (input.Contains("purpose") || input.Contains("what do you do"))
        {
            ShowResponse("I'm here to educate you about cybersecurity best practices and help you stay safe online.");
            return true;
        }
        
        return false;
    }

    static bool ProcessSecurityTopics(string input)
    {
        if (input.Contains("password") || input.Contains("credential"))
        {
            ShowPasswordTips();
            return true;
        }
        else if (input.Contains("phish") || input.Contains("scam"))
        {
            ShowPhishingTips();
            return true;
        }
        else if (input.Contains("brows") || input.Contains("internet"))
        {
            ShowBrowsingTips();
            return true;
        }
        else if (input.Contains("privacy"))
        {
            ShowPrivacyTips();
            return true;
        }
        else if (input.Contains("malware") || input.Contains("virus"))
        {
            ShowMalwareTips();
            return true;
        }
        else if (input.Contains("social media") || input.Contains("facebook") || input.Contains("instagram"))
        {
            ShowSocialMediaTips();
            return true;
        }
        else if (input.Contains("vpn"))
        {
            ShowVPNTips();
            return true;
        }
        else if (input.Contains("two factor") || input.Contains("2fa"))
        {
            ShowTwoFactorAuthTips();
            return true;
        }
        else if (input.Contains("backup") || input.Contains("ransomware"))
        {
            ShowBackupTips();
            return true;
        }
        
        return false;
    }

    static bool ProcessFollowUpQuestions(string input, ref int conversationDepth)
    {
        if (input.Contains("more") || input.Contains("detail") || input.Contains("explain"))
        {
            conversationDepth++;
            ShowResponse(GetRandomResponse(new[] {
                "Let me go into more detail about that...",
                "Here's some additional information:",
                "I'd be happy to elaborate:"
            }));
            return true;
        }
        else if (input.Contains("example") || input.Contains("show me"))
        {
            ShowResponse("Here's a practical example scenario...");
            return true;
        }
        
        return false;
    }

    static void DisplayHelpMenu()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("You can ask me about:");
        Console.WriteLine("- Password safety            - Social media risks");
        Console.WriteLine("- Phishing scams             - VPN benefits");
        Console.WriteLine("- Malware protection         - Two-factor auth");
        Console.WriteLine("- Privacy tips               - Data backups");
        Console.WriteLine("- Safe browsing");
        Console.WriteLine("\nOr say 'bye' to exit, 'help' to see this again, or 'more' for details");
        Console.ResetColor();
        Console.WriteLine();
    }

    static string GetRandomResponse(string[] responses)
    {
        return responses[random.Next(responses.Length)];
    }

    static void ShowResponse(string message)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(message);
        Console.ResetColor();
        Console.WriteLine();
    }

    static void ShowErrorMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
        Console.WriteLine();
    }

    static void ShowFarewellMessage(string userName)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Goodbye, {userName}! Stay safe online!");
        Console.ResetColor();
    }

    // Expanded security topic methods
    static void ShowPasswordTips() //(Password best practices, 2025)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Password safety is crucial! Here are comprehensive tips:");
        Console.WriteLine("- Use at least 12 characters (16+ for important accounts)");
        Console.WriteLine("- Create passphrases: 'PurpleTiger$JumpsHigh!' is better than 'P@ssw0rd'");
        Console.WriteLine("- Never reuse passwords across sites");
        Console.WriteLine("- Enable biometric authentication where available");
        Console.WriteLine("- Use a reputable password manager (Bitwarden, 1Password)");
        Console.WriteLine("- Change passwords immediately after a data breach");
        Console.ResetColor();
        Console.WriteLine();
    }

    static void ShowPhishingTips() //(How to recognize and avoid phishing scams, 2019)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Phishing scams try to trick you into giving personal information:");
        Console.WriteLine("- Verify sender email addresses (hover to see the real address)");
        Console.WriteLine("- Watch for urgency tactics ('Your account will be closed!')");
        Console.WriteLine("- Never click links in unsolicited messages - go directly to the site");
        Console.WriteLine("- Check for poor grammar/spelling (but some attacks are well-written)");
        Console.WriteLine("- Report phishing attempts to your IT department or email provider");
        Console.ResetColor();
        Console.WriteLine();
    }

    static void ShowBrowsingTips() //(Anastasiia, 2021)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Safe browsing practices:");
        Console.WriteLine("- Look for 'https://' and padlock icon (but know some malicious sites use HTTPS too)");
        Console.WriteLine("- Use browser extensions like uBlock Origin and Privacy Badger");
        Console.WriteLine("- Clear cookies regularly or use private browsing mode");
        Console.WriteLine("- Be extremely cautious with browser extensions - only install from official stores");
        Console.WriteLine("- Consider using a separate browser for sensitive activities (banking)");
        Console.ResetColor();
        Console.WriteLine();
    }

    static void ShowPrivacyTips() //(Online privacy and safety tips —, 2023)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Advanced privacy protection:");
        Console.WriteLine("- Use encrypted messaging apps (Signal, WhatsApp) instead of SMS");
        Console.WriteLine("- Review app permissions monthly and revoke unnecessary access");
        Console.WriteLine("- Consider using an alias email for non-critical accounts");
        Console.WriteLine("- Enable 'Find My Device' and remote wipe capabilities");
        Console.WriteLine("- Regularly check haveibeenpwned.com for data breaches");
        Console.ResetColor();
        Console.WriteLine();
    }

    static void ShowMalwareTips() //(Radwan, 2024)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Malware protection strategies:");
        Console.WriteLine("- Keep all software updated, especially your OS and browser");
        Console.WriteLine("- Use reputable antivirus software (Windows Defender is sufficient for most)");
        Console.WriteLine("- Never disable security features to run suspicious software");
        Console.WriteLine("- Be extremely cautious with email attachments and USB drives");
        Console.WriteLine("- Regular scans even if you don't notice symptoms");
        Console.ResetColor();
        Console.WriteLine();
    }

    static void ShowSocialMediaTips() //(Share with care: Staying safe on social media - national cybersecurity alliance, 2023)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Social media safety:");
        Console.WriteLine("- Review privacy settings monthly (platforms often change defaults)");
        Console.WriteLine("- Be cautious with quizzes/apps that request permissions");
        Console.WriteLine("- Don't post sensitive info (vacation dates, license plates)");
        Console.WriteLine("- Enable login approvals/notifications");
        Console.WriteLine("- Assume anything you post could become public");
        Console.ResetColor();
        Console.WriteLine();
    }

    static void ShowVPNTips() //(14 most interesting uses of a VPN, 2025)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("VPN guidance:");
        Console.WriteLine("- Essential on public WiFi (airports, coffee shops)");
        Console.WriteLine("- Choose reputable providers (avoid free VPNs)");
        Console.WriteLine("- Understand VPNs don't make you anonymous - they just encrypt traffic");
        Console.WriteLine("- Enable kill switch feature if available");
        Console.WriteLine("- Consider setting up your own VPN for maximum control");
        Console.ResetColor();
        Console.WriteLine();
    }

    static void ShowTwoFactorAuthTips() //(Your two-factor authentication methods – ranked, 2024)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Two-Factor Authentication (2FA):");
        Console.WriteLine("- Always enable for email, banking, and social media");
        Console.WriteLine("- Use authenticator apps (Google/Microsoft Authenticator) over SMS");
        Console.WriteLine("- Store backup codes securely (password manager or printed)");
        Console.WriteLine("- Consider hardware security keys for high-value accounts");
        Console.WriteLine("- Be wary of 2FA fatigue attacks (pushing approvals until you accept)");
        Console.ResetColor();
        Console.WriteLine();
    }

    static void ShowBackupTips() //(6 simple backup tips for your computer, 2022)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Data backup best practices:");
        Console.WriteLine("- Follow the 3-2-1 rule: 3 copies, 2 media types, 1 offsite");
        Console.WriteLine("- Test restores periodically - backups are useless if they don't work");
        Console.WriteLine("- Cloud backups should be encrypted before upload");
        Console.WriteLine("- Automate backups to prevent human error");
        Console.WriteLine("- For ransomware protection, maintain air-gapped backups");
        Console.ResetColor();
        Console.WriteLine();
    }
}

/*
Reference List:

6 simple backup tips for your computer (2022) Kingston Technology Company. Available at: https://www.kingston.com/en/blog/personal-storage/computer-backup-tips (Accessed: April 22, 2025).


14 most interesting uses of a VPN (2025) Nordvpn.com. Available at: https://nordvpn.com/blog/interesting-vpn-uses/ (Accessed: April 22, 2025).


Anastasiia (2021) How to browse the internet safely: 10 tips, Swiss Cyber Institute. Available at: https://swisscyberinstitute.com/blog/10-tips-on-how-to-browse-the-internet-safely/ (Accessed: April 22, 2025).


How to recognize and avoid phishing scams (2019) Consumer Advice. Available at: https://consumer.ftc.gov/articles/how-recognize-and-avoid-phishing-scams (Accessed: April 22, 2025).


Online privacy and safety tips — (2023) Safety Net Project. Available at: https://www.techsafety.org/onlineprivacyandsafetytips (Accessed: April 10, 2025).


Password best practices (2025) UC Santa Barbara Information Technology. Available at: https://it.ucsb.edu/general-security-resources/password-best-practices (Accessed: April 22, 2025).


Radwan, A. (2024) MalwareTips review: A helpful community or a famous hoax?, Internet Safety Statistics. Available at: https://www.internetsafetystatistics.com/malwaretips-review/ (Accessed: April 22, 2025).


Share with care: Staying safe on social media - national cybersecurity alliance (2023) Staysafeonline.org. Available at: https://www.staysafeonline.org/articles/share-with-care-staying-safe-on-social-media (Accessed: April 21, 2025).


Static bool is always true (2013) Stack Overflow. Available at: https://stackoverflow.com/questions/15229487/static-bool-is-always-true (Accessed: January 22, 2025).


Your two-factor authentication methods – ranked (2024) Own Your Online. Available at: https://www.ownyouronline.govt.nz/news-and-alerts/most-secure-2fa-method/ (Accessed: April 22, 2025).


*/