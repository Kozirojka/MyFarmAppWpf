using System;
using System.Windows.Media;

namespace WpfApplication2
{
    public class SoundPlayerFacade
    {
        private MediaPlayer mediaPlayer;
        
        public SoundPlayerFacade()
        {
            mediaPlayer = new MediaPlayer();
        }
        
        
        
        public void PlaySound(string soundFilePath)
        {
            try
            {
                mediaPlayer.Open(new Uri(soundFilePath));
                mediaPlayer.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing sound: {ex.Message}");
            }
        }
        
        
        
        public void StopSound()
        {
            try
            {
                mediaPlayer.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error stopping sound: {ex.Message}");
            }
        }
        
        
        
        

        
    }
}
