

namespace Cocktails2.Domain.ValueObjects;

public class Picture
{
    public byte[] ImageData { get; set; }

    public Picture(string filePath) 
    {
        var file = new FileStream(filePath, FileMode.Open);
        var memoryStream = new MemoryStream();

        file.CopyTo(memoryStream);

        ImageData = memoryStream.ToArray();
    }
    public Picture(byte[] imageData)
    {
        ImageData = imageData;
    }

    public string ImageSource()
    {
        return $"data:image/jpeg;base64,{Convert.ToBase64String(ImageData)}";
    }


}
