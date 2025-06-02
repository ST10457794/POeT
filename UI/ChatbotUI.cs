using CybersecurityChatbot.Utils;

namespace CybersecurityChatbot.UI;

public class ChatbotUI
{
    private readonly AudioManager _audioManager;
    
    public ChatbotUI(AudioManager audioManager)
    {
        _audioManager = audioManager;
    }
    
    public void DisplayWelcomeScreen()
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
        
        DisplayHeader();
        Console.WriteLine();
        Console.WriteLine("Welcome to the Cybersecurity Awareness Bot!");
        Console.WriteLine("I'm here to help you stay safe online.");
        Console.WriteLine();
    }
    
    public void DisplayHeader()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("==============================================");
        Console.WriteLine("  CYBERSECURITY AWARENESS CHATBOT ");
        Console.WriteLine("==============================================");
        Console.ResetColor();
    }
    
    public void DisplayHelpMenu()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("You can ask me about:");
        Console.WriteLine("- Password safety            - Social media risks");
        Console.WriteLine("- Phishing scams             - VPN benefits");
        Console.WriteLine("- Malware protection         - Two-factor auth");
        Console.WriteLine("- Privacy tips               - Data backups");
        Console.WriteLine("- Safe browsing              - Security assessment");
        Console.WriteLine("\nYou can also:");
        Console.WriteLine("- Ask for more details or examples");
        Console.WriteLine("- Share how you feel about cybersecurity");
        Console.WriteLine("- Type 'clear' to reset the screen");
        Console.WriteLine("- Say 'bye' to exit or 'help' to see this again");
        Console.ResetColor();
        Console.WriteLine();
    }
    
    public void WriteResponse(string message)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        // Animated typing effect for responses
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(5); // Small delay for typing effect
        }
        Console.WriteLine();
        Console.ResetColor();
        Console.WriteLine();
    }
    
    public void WriteError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
        Console.WriteLine();
    }
    
    public void WriteHighlight(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ResetColor();
        Console.WriteLine();
    }
    
    public void WriteSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    
    public void WriteWarning(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    
    public void WritePrompt(string prompt)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(prompt);
        Console.ResetColor();
    }
    
    public void DisplayProgressBar(int current, int max)
    {
        const int barWidth = 40;
        int progress = (int)((double)current / max * barWidth);
        
        Console.Write("[");
        Console.ForegroundColor = current < max / 2 ? ConsoleColor.Red : 
                                 current < max * 0.8 ? ConsoleColor.Yellow : 
                                 ConsoleColor.Green;
                                 
        for (int i = 0; i < barWidth; i++)
        {
            if (i < progress)
                Console.Write("█");
            else
                Console.Write(" ");
        }
        
        Console.ResetColor();
        Console.WriteLine($"] {current}/{max}");
        Console.WriteLine();
    }
}