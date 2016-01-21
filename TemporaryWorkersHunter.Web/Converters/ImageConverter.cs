using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemporaryWorkersHunter.Web.Converters.Interfaces;

namespace TemporaryWorkersHunter.Web.Converters
{
    public class ImageConverter : IImageConverter
    {
        public byte[] ImageToByteArray(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Gif);
                return ms.ToArray();
            }
        }

        public Image ByteArrayToImage(byte[] byteArray)
        {
            using (var ms = new MemoryStream(byteArray))
            {
                var returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }
    }
}
