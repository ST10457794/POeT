using CybersecurityChatbot.UI;
using CybersecurityChatbot.Core;
using CybersecurityChatbot.Topics;
using CybersecurityChatbot.Utils;

namespace CybersecurityChatbot;

class Program
{
    static void Main(string[] args)
    {
        // Initialize core systems
        var audioManager = new AudioManager();
        var memorySystem = new MemorySystem();
        var chatbotUI = new ChatbotUI(audioManager);
        var topicManager = new SecurityTopicManager();
        var userInteraction = new UserInteraction(chatbotUI, memorySystem, topicManager);
        
        // Start chatbot
        Console.Clear();
        audioManager.PlayWelcomeSound();
        chatbotUI.DisplayWelcomeScreen();
        
        // Get user name and start conversation
        string userName = userInteraction.GetUserName();
        userInteraction.RunChatLoop(userName);
    }
}