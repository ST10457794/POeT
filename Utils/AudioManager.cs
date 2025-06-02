using System.Runtime.InteropServices;

namespace CybersecurityChatbot.Utils;

public class AudioManager
{
    public void PlayWelcomeSound()
    {
        PlayAudio("Audio/welcome.wav");
    }
    
    public void PlayNotificationSound()
    {
        PlayAudio("Audio/notification.wav");
    }
    
    private void PlayAudio(string audioFile)
    {
        try
        {
            var process = new System.Diagnostics.Process();
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                process.StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/C start mplay32 /play /close \"{audioFile}\"",
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                process.StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "afplay",
                    Arguments = audioFile,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                // Try multiple audio players for better Linux compatibility
                process.StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "bash",
                    Arguments = $"-c \"aplay '{audioFile}' || paplay '{audioFile}' || mplayer '{audioFile}'\"",
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
}