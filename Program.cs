using System;
using System.Threading;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        PlayAudio(); //calling the play audio function 
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
    if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
    {
        try
        {
            using var process = new System.Diagnostics.Process
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "afplay",
                    Arguments = "welcome.wav",
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            process.Start();
            Thread.Sleep(2000); // Wait for audio to play
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Couldn't play audio: {ex.Message}");
        }
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
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Nice to meet you, {name}! Let's talk about cybersecurity.");
        Console.ResetColor();
        Console.WriteLine();
        
        return name;
    }

    static void RunChatLoop(string userName)
    {
        bool continueChat = true;
        
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
            
            if (input.Contains("bye") || input.Contains("exit") || input.Contains("quit"))
            {
                continueChat = false;
                ShowFarewellMessage(userName);
            }
            else if (input.Contains("how are you"))
            {
                ShowResponse("I'm just a bot, but I'm functioning well! Ready to help with cybersecurity questions.");
            }
            else if (input.Contains("purpose") || input.Contains("what do you do"))
            {
                ShowResponse("I'm here to educate you about cybersecurity best practices and help you stay safe online.");
            }
            else if (input.Contains("password"))
            {
                ShowPasswordTips();
            }
            else if (input.Contains("phish") || input.Contains("scam"))
            {
                ShowPhishingTips();
            }
            else if (input.Contains("brows") || input.Contains("internet"))
            {
                ShowBrowsingTips();
            }
            else if (input.Contains("privacy"))
            {
                ShowPrivacyTips();
            }
            else if (input.Contains("help"))
            {
                DisplayHelpMenu();
            }
            else
            {
                ShowErrorMessage("I didn't understand that. Try asking about: password safety, phishing, safe browsing, or privacy.");
            }
        }
    }

    static void DisplayHelpMenu()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("You can ask me about:");
        Console.WriteLine("- Password safety");
        Console.WriteLine("- Phishing scams");
        Console.WriteLine("- Safe browsing");
        Console.WriteLine("- Privacy tips");
        Console.WriteLine("Or just say 'bye' to exit.");
        Console.ResetColor();
        Console.WriteLine();
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

    static void ShowPasswordTips()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Password safety is crucial! Here are some tips:");
        Console.WriteLine("- Use at least 12 characters");
        Console.WriteLine("- Include numbers, symbols, and both uppercase and lowercase letters");
        Console.WriteLine("- Don't use personal information or common words");
        Console.WriteLine("- Use a unique password for each account");
        Console.WriteLine("- Consider using a password manager");
        Console.ResetColor();
        Console.WriteLine();
    }

    static void ShowPhishingTips()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Phishing scams try to trick you into giving personal information. Be cautious of:");
        Console.WriteLine("- Emails asking for passwords or financial info");
        Console.WriteLine("- Messages creating a sense of urgency");
        Console.WriteLine("- Links that don't match the company's real website");
        Console.WriteLine("- Requests for sensitive information via email");
        Console.ResetColor();
        Console.WriteLine();
    }

    static void ShowBrowsingTips()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Safe browsing practices:");
        Console.WriteLine("- Look for 'https://' and padlock icon in address bar");
        Console.WriteLine("- Don't download files from untrusted sources");
        Console.WriteLine("- Keep your browser and plugins updated");
        Console.WriteLine("- Use ad-blockers to avoid malicious ads");
        Console.WriteLine("- Be cautious with public WiFi - use VPN if possible");
        Console.ResetColor();
        Console.WriteLine();
    }

    static void ShowPrivacyTips()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Privacy protection tips:");
        Console.WriteLine("- Review privacy settings on social media");
        Console.WriteLine("- Be careful what personal info you share online");
        Console.WriteLine("- Use two-factor authentication where available");
        Console.WriteLine("- Regularly check app permissions on your devices");
        Console.WriteLine("- Consider using privacy-focused browsers/extensions");
        Console.ResetColor();
        Console.WriteLine();
    }
}
