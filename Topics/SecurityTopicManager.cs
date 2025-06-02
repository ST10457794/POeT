using CybersecurityChatbot.UI;

namespace CybersecurityChatbot.Topics;

public class SecurityTopicManager
{
    // Process security topics and return the identified topic
    public string ProcessSecurityTopics(string input, string sentiment)
    {
        if (input.Contains("password") || input.Contains("credential"))
        {
            PasswordTips.Show(sentiment);
            return "password";
        }
        else if (input.Contains("phish") || input.Contains("scam") || input.Contains("spam"))
        {
            PhishingTips.Show(sentiment);
            return "phishing";
        }
        else if (input.Contains("brows") || input.Contains("internet") || input.Contains("web"))
        {
            BrowsingTips.Show(sentiment);
            return "browsing";
        }
        else if (input.Contains("privacy") || input.Contains("data collection"))
        {
            PrivacyTips.Show(sentiment);
            return "privacy";
        }
        else if (input.Contains("malware") || input.Contains("virus") || input.Contains("ransomware"))
        {
            MalwareTips.Show(sentiment);
            return "malware";
        }
        else if (input.Contains("social media") || input.Contains("facebook") || 
                 input.Contains("instagram") || input.Contains("twitter") || 
                 input.Contains("tiktok") || input.Contains("linkedin"))
        {
            SocialMediaTips.Show(sentiment);
            return "social";
        }
        else if (input.Contains("vpn") || input.Contains("virtual private"))
        {
            VPNTips.Show(sentiment);
            return "vpn";
        }
        else if (input.Contains("two factor") || input.Contains("2fa") || input.Contains("mfa"))
        {
            TwoFactorTips.Show(sentiment);
            return "2fa";
        }
        else if (input.Contains("backup") || input.Contains("data loss") || input.Contains("cloud storage"))
        {
            BackupTips.Show(sentiment);
            return "backup";
        }
        else if (input.Contains("wifi") || input.Contains("wireless") || input.Contains("public network"))
        {
            WifiSecurityTips.Show(sentiment);
            return "wifi";
        }
        else if (input.Contains("phone") || input.Contains("mobile") || input.Contains("android") || 
                 input.Contains("iphone") || input.Contains("ios"))
        {
            MobileSecurityTips.Show(sentiment);
            return "mobile";
        }
        
        return string.Empty;
    }
    
    // Process follow-up questions on a specific topic
    public void ProcessFollowUpQuestion(string topic, string sentiment)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Let me provide more detailed information about {topic}...");
        
        switch (topic.ToLower())
        {
            case "password":
                PasswordTips.ShowDetailed();
                break;
                
            case "phishing":
                PhishingTips.ShowDetailed();
                break;
                
            case "browsing":
                BrowsingTips.ShowDetailed();
                break;
                
            case "privacy":
                PrivacyTips.ShowDetailed();
                break;
                
            case "malware":
                MalwareTips.ShowDetailed();
                break;
                
            case "social":
                SocialMediaTips.ShowDetailed();
                break;
                
            case "vpn":
                VPNTips.ShowDetailed();
                break;
                
            case "2fa":
                TwoFactorTips.ShowDetailed();
                break;
                
            case "backup":
                BackupTips.ShowDetailed();
                break;
                
            case "wifi":
                WifiSecurityTips.ShowDetailed();
                break;
                
            case "mobile":
                MobileSecurityTips.ShowDetailed();
                break;
                
            default:
                Console.WriteLine("I'll be happy to explain more about any specific aspect you're interested in.");
                break;
        }
        
        Console.ResetColor();
        Console.WriteLine();
    }
}