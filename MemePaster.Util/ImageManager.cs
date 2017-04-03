using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MemePaster.Util
{
    public class ImageManager
    {
        public static BitmapImage ChangeImageSize(short xSize, short ySize, BitmapImage image)
        {
            var newImage = new BitmapImage();
            newImage.BeginInit();
            // Set properties.
            newImage.CacheOption = BitmapCacheOption.OnDemand;
            newImage.CreateOptions = BitmapCreateOptions.DelayCreation;
            newImage.DecodePixelHeight = ySize;
            newImage.DecodePixelWidth = xSize;
            newImage.UriSource = image.UriSource;
            newImage.EndInit();
            return newImage;
        }
    }
}
