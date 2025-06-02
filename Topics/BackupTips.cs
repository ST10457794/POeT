namespace CybersecurityChatbot.Topics;

public static class BackupTips
{
    public static void Show(string sentiment)
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
        Console.WriteLine("- Include system settings and application data");
        Console.WriteLine("- For ransomware protection, maintain air-gapped backups");
        Console.ResetColor();
        Console.WriteLine();
    }
    
    public static void ShowDetailed()
    {
        Console.WriteLine("Complete backup strategy for personal data protection:");
        Console.WriteLine();
        Console.WriteLine("1. The 3-2-1-1-0 Modern Backup Strategy:");
        Console.WriteLine("   • 3 copies of your data (original + 2 backups)");
        Console.WriteLine("   • 2 different storage media types (e.g., SSD and cloud)");
        Console.WriteLine("   • 1 copy stored offsite (cloud or physical location)");
        Console.WriteLine("   • 1 copy that's air-gapped (completely disconnected)");
        Console.WriteLine("   • 0 errors (verify backups through regular testing)");
        Console.WriteLine();
        Console.WriteLine("2. Backup Types and Scheduling:");
        Console.WriteLine("   • Full backup: Complete copy of all data (weekly)");
        Console.WriteLine("   • Incremental backup: Changes since last backup (daily)");
        Console.WriteLine("   • Critical documents: Real-time sync to secure cloud");
        Console.WriteLine("   • System images: Before major OS/software changes");
        Console.WriteLine();
        Console.WriteLine("3. Encryption Considerations:");
        Console.WriteLine("   • Use AES-256 encryption for all backups");
        Console.WriteLine("   • Store encryption keys separately from backups");
        Console.WriteLine("   • Consider a password manager for key management");
        Console.WriteLine("   • Use end-to-end encrypted cloud services when possible");
        Console.WriteLine();
        Console.WriteLine("4. Ransomware-Resistant Backup Practices:");
        Console.WriteLine("   • Use write-once media for critical backups");
        Console.WriteLine("   • Configure backup software with unique credentials");
        Console.WriteLine("   • Maintain versioned backups (point-in-time recovery)");
        Console.WriteLine("   • Test restoration in an isolated environment");
        Console.WriteLine("   • Consider immutable storage options (cannot be modified once written)");
    }
}