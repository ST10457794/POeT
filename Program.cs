using System;
using System.Threading;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Enhanced memory system to store user information and conversation context
    private static Dictionary<string, string> userMemory = new Dictionary<string, string>();
    private static List<string> conversationHistory = new List<string>();
    private static Random random = new Random();
    
    // Sentiment keywords for basic emotion detection
    private static readonly Dictionary<string, string> sentiments = new Dictionary<string, string>
    {
        { "worried", "concerned" },
        { "scared", "concerned" },
        { "anxious", "concerned" },
        { "confused", "uncertain" },
        { "unsure", "uncertain" },
        { "don't understand", "uncertain" },
        { "happy", "positive" },
        { "excited", "positive" },
        { "interested", "positive" },
        { "frustrated", "negative" },
        { "angry", "negative" },
        { "annoyed", "negative" }
    };

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

    static void PlayAudio() 
    {
        try
        {
            var process = new System.Diagnostics.Process();
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
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
                Thread.Sleep(2000);
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
    
    static void RunChatLoop(string userName)
    {
        bool continueChat = true;
        int conversationDepth = 0;
        string currentTopic = "";
        
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

            // Store user input in conversation history
            conversationHistory.Add(input);
            
            // Detect sentiment and adjust response accordingly
            string detectedSentiment = DetectSentiment(input);
            
            if (ProcessBasicCommands(input, userName, ref continueChat)) continue;
            
            // Check if this is a follow-up question about the current topic
            if (currentTopic != "" && (input.Contains("more") || input.Contains("explain") || input.Contains("example")))
            {
                ProcessFollowUpQuestion(currentTopic, detectedSentiment);
                continue;
            }
            
            // Process security topics and update current topic
            currentTopic = ProcessSecurityTopics(input, detectedSentiment);
            if (!string.IsNullOrEmpty(currentTopic)) continue;
            
            ShowErrorMessage("I didn't understand that. Try asking about:\n" +
                           "- Password safety\n- Phishing\n- Malware\n- Social media\n- VPNs\n" +
                           "- Two-factor auth\n- Data backups\n- Or say 'help' for more options");
        }
    }

    static string DetectSentiment(string input)
    {
        foreach (var sentiment in sentiments)
        {
            if (input.Contains(sentiment.Key))
            {
                return sentiment.Value;
            }
        }
        return "neutral";
    }

    static bool ProcessBasicCommands(string input, string userName, ref bool continueChat)
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
                "You're welcome! Is there anything else you'd like to know about cybersecurity?",
                "Happy to help! Remember, staying safe online is a continuous journey.",
                "That's what I'm here for! Let me know if you have more questions."
            }));
            return true;
        }
        else if (input.Contains("how are you"))
        {
            ShowResponse(GetRandomResponse(new[] {
                "I'm functioning well and ready to help you stay safe online!",
                "I'm here and eager to share cybersecurity knowledge with you.",
                "All systems operational! What would you like to learn about cybersecurity?"
            }));
            return true;
        }
        else if (input.Contains("purpose") || input.Contains("what do you do"))
        {
            ShowResponse("I'm your cybersecurity awareness assistant, here to help you understand and implement better online safety practices. What specific aspect of cybersecurity would you like to learn about?");
            return true;
        }
        
        return false;
    }

    static string ProcessSecurityTopics(string input, string sentiment)
    {
        string topic = "";
        
        if (input.Contains("password") || input.Contains("credential"))
        {
            ShowPasswordTips(sentiment);
            topic = "password";
        }
        else if (input.Contains("phish") || input.Contains("scam"))
        {
            ShowPhishingTips(sentiment);
            topic = "phishing";
        }
        else if (input.Contains("brows") || input.Contains("internet"))
        {
            ShowBrowsingTips(sentiment);
            topic = "browsing";
        }
        else if (input.Contains("privacy"))
        {
            ShowPrivacyTips(sentiment);
            topic = "privacy";
        }
        else if (input.Contains("malware") || input.Contains("virus"))
        {
            ShowMalwareTips(sentiment);
            topic = "malware";
        }
        else if (input.Contains("social media") || input.Contains("facebook") || input.Contains("instagram"))
        {
            ShowSocialMediaTips(sentiment);
            topic = "social";
        }
        else if (input.Contains("vpn"))
        {
            ShowVPNTips(sentiment);
            topic = "vpn";
        }
        else if (input.Contains("two factor") || input.Contains("2fa"))
        {
            ShowTwoFactorAuthTips(sentiment);
            topic = "2fa";
        }
        else if (input.Contains("backup") || input.Contains("ransomware"))
        {
            ShowBackupTips(sentiment);
            topic = "backup";
        }
        
        if (!string.IsNullOrEmpty(topic))
        {
            userMemory["last_topic"] = topic;
            return topic;
        }
        
        return "";
    }

    static void ProcessFollowUpQuestion(string topic, string sentiment)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Let me provide more detailed information about {topic}...");
        
        switch (topic.ToLower())
        {
            case "password":
                Console.WriteLine("Here's a practical example of a strong password system:");
                Console.WriteLine("1. Use a password manager like Bitwarden or 1Password");
                Console.WriteLine("2. Generate unique 16+ character passwords for each account");
                Console.WriteLine("3. Use the password manager's security check features");
                break;
                
            case "phishing":
                Console.WriteLine("Here's a real-world example of a phishing attempt:");
                Console.WriteLine("1. Email claims to be from your bank about suspicious activity");
                Console.WriteLine("2. Creates urgency: 'Account will be locked in 24 hours!'");
                Console.WriteLine("3. Links to a fake website that looks legitimate");
                Console.WriteLine("4. Asks for login credentials or personal information");
                break;
                
            // Add similar detailed responses for other topics
            
            default:
                Console.WriteLine("I'll be happy to explain more about any specific aspect you're interested in.");
                break;
        }
        
        Console.ResetColor();
        Console.WriteLine();
    }

    static void DisplayHelpMenu()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("You can ask me about:");
        Console.WriteLine("- Password safety            - Social media risks");
        Console.WriteLine("- Phishing scams            - VPN benefits");
        Console.WriteLine("- Malware protection        - Two-factor auth");
        Console.WriteLine("- Privacy tips              - Data backups");
        Console.WriteLine("- Safe browsing");
        Console.WriteLine("\nYou can also:");
        Console.WriteLine("- Ask for more details or examples");
        Console.WriteLine("- Share how you feel about cybersecurity");
        Console.WriteLine("- Say 'bye' to exit or 'help' to see this again");
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
        if (userMemory.ContainsKey("last_topic"))
        {
            Console.WriteLine($"Remember to implement the {userMemory["last_topic"]} safety tips we discussed!");
        }
        Console.ResetColor();
    }

    // Enhanced security topic methods with sentiment awareness
    static void ShowPasswordTips(string sentiment)
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
        Console.ResetColor();
        Console.WriteLine();
    }

    static void ShowPhishingTips(string sentiment)
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
        Console.WriteLine("- Report phishing attempts to your IT department or email provider");
        Console.ResetColor();
        Console.WriteLine();
    }

    static void ShowBrowsingTips(string sentiment)
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
        Console.ResetColor();
        Console.WriteLine();
    }

    static void ShowPrivacyTips(string sentiment)
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
        Console.WriteLine("- Regularly check haveibeenpwned.com for data breaches");
        Console.ResetColor();
        Console.WriteLine();
    }

    static void ShowMalwareTips(string sentiment)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        
        if (sentiment == "concerned")
        {
            Console.WriteLine("Malware can be scary, but there are effective ways to protect yourself:");
        }
        else if (sentiment == "uncertain")
        {
            Console.WriteLine("Let me explain malware protection in simple terms:");
        }
        
        Console.WriteLine("Malware protection strategies:");
        Console.WriteLine("- Keep all software updated, especially your OS and browser");
        Console.WriteLine("- Use reputable antivirus software (Windows Defender is sufficient for most)");
        Console.WriteLine("- Never disable security features to run suspicious software");
        Console.WriteLine("- Be extremely cautious with email attachments and USB drives");
        Console.WriteLine("- Regular scans even if you don't notice symptoms");
        Console.ResetColor();
        Console.WriteLine();
    }

    static void ShowSocialMediaTips(string sentiment)
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
        Console.WriteLine("- Assume anything you post could become public");
        Console.ResetColor();
        Console.WriteLine();
    }

    static void ShowVPNTips(string sentiment)
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
        Console.WriteLine("- Consider setting up your own VPN for maximum control");
        Console.ResetColor();
        Console.WriteLine();
    }

    static void ShowTwoFactorAuthTips(string sentiment)
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
        Console.WriteLine("- Be wary of 2FA fatigue attacks (pushing approvals until you accept)");
        Console.ResetColor();
        Console.WriteLine();
    }

    static void ShowBackupTips(string sentiment)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        
        if (sentiment == "concerned")
        {
            Console.WriteLine("Data loss can be prevented with proper backups. Here's how to protect your files:");
        }
        else if (sentiment == "uncertain")
        {
            Console.WriteLine("Backups don't have to be complicated. Here's what you need to know:");
        }
        
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