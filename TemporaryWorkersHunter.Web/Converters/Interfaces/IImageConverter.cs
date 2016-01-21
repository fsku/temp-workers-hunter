using System.Drawing;

namespace TemporaryWorkersHunter.Web.Converters.Interfaces
{
    public interface IImageConverter
    {
        byte[] ImageToByteArray(Image image);
        Image ByteArrayToImage(byte[] byteArray);
    }
}