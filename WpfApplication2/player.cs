using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApplication2
{
    public class playerF
    {
        public int PlayerSpeed = 5;
        public Image player;
        public double playerX, playerY;
        public int currentFrameIndex = 0; // Index of current frame
        public ScaleTransform flipTransform; // Used for flipping the image
        public BitmapImage[] animationFrames; // Array to hold animation frames
    }
    
}
