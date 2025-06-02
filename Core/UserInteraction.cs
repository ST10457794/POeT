using CybersecurityChatbot.UI;
using CybersecurityChatbot.Topics;
using CybersecurityChatbot.Utils;

namespace CybersecurityChatbot.Core;

public class UserInteraction
{
    private readonly ChatbotUI _ui;
    private readonly MemorySystem _memory;
    private readonly SecurityTopicManager _topicManager;
    private readonly Random _random = new Random();
    private string _currentTopic = string.Empty;
    
    // Sentiment keywords for basic emotion detection
    private readonly Dictionary<string, string> _sentiments = new Dictionary<string, string>
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
    
    public UserInteraction(ChatbotUI ui, MemorySystem memory, SecurityTopicManager topicManager)
    {
        _ui = ui;
        _memory = memory;
        _topicManager = topicManager;
    }
    
    public string GetUserName()
    {
        _ui.WritePrompt("Hello! What's your name? ");
        string name = Console.ReadLine() ?? string.Empty;
        
        while (string.IsNullOrWhiteSpace(name))
        {
            _ui.WriteError("Please enter a valid name.");
            _ui.WritePrompt("Hello! What's your name? ");
            name = Console.ReadLine() ?? string.Empty;
        }
        
        _memory.StoreUserInfo("name", name);
        _ui.WriteHighlight($"Nice to meet you, {name}! Let's talk about cybersecurity.");
        Console.WriteLine();
        
        return name;
    }
    
    public void RunChatLoop(string userName)
    {
        bool continueChat = true;
        
        _ui.DisplayHelpMenu();
        
        while (continueChat)
        {
            _ui.WritePrompt($"{userName}: ");
            string input = Console.ReadLine()?.ToLower() ?? string.Empty;
            
            if (string.IsNullOrWhiteSpace(input))
            {
                _ui.WriteError("I didn't quite understand that. Could you rephrase?");
                continue;
            }

            // Store user input in conversation history
            _memory.AddToHistory(input);
            
            // Detect sentiment and adjust response accordingly
            string detectedSentiment = DetectSentiment(input);
            
            if (ProcessBasicCommands(input, userName, ref continueChat)) 
                continue;
            
            // Check for security assessment request
            if (input.Contains("assessment") || input.Contains("evaluate") || input.Contains("check my security"))
            {
                RunSecurityAssessment(userName);
                continue;
            }
            
            // Check if this is a follow-up question about the current topic
            if (!string.IsNullOrEmpty(_currentTopic) && 
                (input.Contains("more") || input.Contains("explain") || 
                 input.Contains("example") || input.Contains("details")))
            {
                _topicManager.ProcessFollowUpQuestion(_currentTopic, detectedSentiment);
                continue;
            }
            
            // Process security topics and update current topic
            string newTopic = _topicManager.ProcessSecurityTopics(input, detectedSentiment);
            if (!string.IsNullOrEmpty(newTopic))
            {
                _currentTopic = newTopic;
                _memory.StoreUserInfo("last_topic", newTopic);
                _memory.TrackTopicInterest(newTopic);
                continue;
            }
            
            _ui.WriteError("I didn't understand that. Try asking about:\n" +
                         "- Password safety\n- Phishing\n- Malware\n- Social media\n- VPNs\n" +
                         "- Two-factor auth\n- Data backups\n- Privacy\n- Safe browsing\n" +
                         "Or say 'help' for more options");
        }
    }
    
    private string DetectSentiment(string input)
    {
        foreach (var sentiment in _sentiments)
        {
            if (input.Contains(sentiment.Key))
            {
                return sentiment.Value;
            }
        }
        return "neutral";
    }
    
    private bool ProcessBasicCommands(string input, string userName, ref bool continueChat)
    {
        if (input.Contains("bye") || input.Contains("exit") || input.Contains("quit"))
        {
            continueChat = false;
            ShowFarewellMessage(userName);
            return true;
        }
        else if (input.Contains("help"))
        {
            _ui.DisplayHelpMenu();
            return true;
        }
        else if (input.Contains("clear") || input.Contains("reset"))
        {
            Console.Clear();
            _ui.DisplayHeader();
            return true;
        }
        else if (input.Contains("thanks") || input.Contains("thank you"))
        {
            _ui.WriteResponse(GetRandomResponse(new[] {
                "You're welcome! Is there anything else you'd like to know about cybersecurity?",
                "Happy to help! Remember, staying safe online is a continuous journey.",
                "That's what I'm here for! Let me know if you have more questions."
            }));
            return true;
        }
        else if (input.Contains("how are you"))
        {
            _ui.WriteResponse(GetRandomResponse(new[] {
                "I'm functioning well and ready to help you stay safe online!",
                "I'm here and eager to share cybersecurity knowledge with you.",
                "All systems operational! What would you like to learn about cybersecurity?"
            }));
            return true;
        }
        else if (input.Contains("purpose") || input.Contains("what do you do"))
        {
            _ui.WriteResponse("I'm your cybersecurity awareness assistant, here to help you understand and implement better online safety practices. What specific aspect of cybersecurity would you like to learn about?");
            return true;
        }
        
        return false;
    }
    
    private void RunSecurityAssessment(string userName)
    {
        _ui.WriteHighlight("Let's perform a quick security assessment to identify areas for improvement.");
        
        int score = 0;
        int maxScore = 5;
        
        // Question 1
        _ui.WritePrompt("Do you use different passwords for different accounts? (yes/no): ");
        string answer = Console.ReadLine()?.ToLower() ?? "no";
        if (answer.Contains("yes"))
        {
            score++;
            _ui.WriteSuccess("Good practice! Using unique passwords limits damage from breaches.");
        }
        else
        {
            _ui.WriteWarning("Using the same password across accounts is risky. If one account is compromised, all are vulnerable.");
        }
        
        // Question 2
        _ui.WritePrompt("Do you have two-factor authentication enabled on important accounts? (yes/no): ");
        answer = Console.ReadLine()?.ToLower() ?? "no";
        if (answer.Contains("yes"))
        {
            score++;
            _ui.WriteSuccess("Excellent! 2FA significantly improves account security.");
        }
        else
        {
            _ui.WriteWarning("Two-factor authentication adds a critical second layer of protection.");
        }
        
        // Question 3
        _ui.WritePrompt("Do you regularly update your devices and software? (yes/no): ");
        answer = Console.ReadLine()?.ToLower() ?? "no";
        if (answer.Contains("yes"))
        {
            score++;
            _ui.WriteSuccess("Great! Updates often contain security patches for known vulnerabilities.");
        }
        else
        {
            _ui.WriteWarning("Outdated software can contain known security vulnerabilities that hackers exploit.");
        }
        
        // Question 4
        _ui.WritePrompt("Do you back up your important data? (yes/no): ");
        answer = Console.ReadLine()?.ToLower() ?? "no";
        if (answer.Contains("yes"))
        {
            score++;
            _ui.WriteSuccess("Smart choice! Backups are your safety net against data loss and ransomware.");
        }
        else
        {
            _ui.WriteWarning("Without backups, you risk permanent data loss from device failure or ransomware.");
        }
        
        // Question 5
        _ui.WritePrompt("Can you identify phishing attempts in emails? (yes/no): ");
        answer = Console.ReadLine()?.ToLower() ?? "no";
        if (answer.Contains("yes"))
        {
            score++;
            _ui.WriteSuccess("Excellent awareness! Phishing is one of the most common attack vectors.");
        }
        else
        {
            _ui.WriteWarning("Phishing awareness is critical as these attacks become increasingly sophisticated.");
        }
        
        // Display results with a progress bar
        Console.WriteLine();
        _ui.WriteHighlight($"Security Assessment Results for {userName}:");
        _ui.DisplayProgressBar(score, maxScore);
        
        if (score <= 1)
        {
            _ui.WriteWarning($"Score: {score}/{maxScore} - Your online security needs significant improvement.");
            _ui.WriteResponse("Let's start with the basics. Would you like to learn about password management first?");
        }
        else if (score <= 3)
        {
            _ui.WriteWarning($"Score: {score}/{maxScore} - Your security practices are basic but need strengthening.");
            _ui.WriteResponse("You've got some good habits, but there's room for improvement. What area would you like to focus on?");
        }
        else
        {
            _ui.WriteSuccess($"Score: {score}/{maxScore} - You have good security awareness!");
            _ui.WriteResponse("Excellent practices! Let's talk about advanced security topics to make you even more secure.");
        }
    }
    
    private string GetRandomResponse(string[] responses)
    {
        return responses[_random.Next(responses.Length)];
    }
    
    private void ShowFarewellMessage(string userName)
    {
        _ui.WriteHighlight($"Goodbye, {userName}! Stay safe online!");
        
        // Personalized farewell based on conversation history
        if (_memory.HasUserInfo("last_topic"))
        {
            _ui.WriteHighlight($"Remember to implement the {_memory.GetUserInfo("last_topic")} safety tips we discussed!");
        }
        
        // Suggest topics of interest for next time
        var interestedTopics = _memory.GetMostInterestedTopics();
        if (interestedTopics.Count > 0)
        {
            _ui.WriteResponse("For your next visit, consider exploring these related topics:");
            foreach (var topic in interestedTopics)
            {
                Console.WriteLine($" - More about {topic}");
            }
        }
    }
}