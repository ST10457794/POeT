namespace CybersecurityChatbot.Core;

public class MemorySystem
{
    private Dictionary<string, string> userMemory = new Dictionary<string, string>();
    private List<string> conversationHistory = new List<string>();
    private Dictionary<string, int> topicInterestCount = new Dictionary<string, int>();
    
    // Store user information
    public void StoreUserInfo(string key, string value)
    {
        userMemory[key] = value;
    }
    
    // Retrieve user information
    public string GetUserInfo(string key)
    {
        return userMemory.ContainsKey(key) ? userMemory[key] : string.Empty;
    }
    
    // Check if user info exists
    public bool HasUserInfo(string key)
    {
        return userMemory.ContainsKey(key);
    }
    
    // Add message to conversation history
    public void AddToHistory(string message)
    {
        conversationHistory.Add(message);
    }
    
    // Get recent conversation history
    public List<string> GetRecentHistory(int count = 5)
    {
        return conversationHistory
            .Skip(Math.Max(0, conversationHistory.Count - count))
            .Take(count)
            .ToList();
    }
    
    // Track topic interest
    public void TrackTopicInterest(string topic)
    {
        if (topicInterestCount.ContainsKey(topic))
        {
            topicInterestCount[topic]++;
        }
        else
        {
            topicInterestCount[topic] = 1;
        }
    }
    
    // Get most interested topics
    public List<string> GetMostInterestedTopics(int count = 3)
    {
        return topicInterestCount
            .OrderByDescending(x => x.Value)
            .Take(count)
            .Select(x => x.Key)
            .ToList();
    }
    
    // Clear conversation history
    public void ClearHistory()
    {
        conversationHistory.Clear();
    }
}