using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails2.Persistence.Misc;

public class ImageConverterService
{
    public static async Task<byte[]> ConvertUriToByteArrayAsync(string imageUri)
    {
        try
        {
            using (WebClient webClient = new WebClient())
            {
                return await webClient.DownloadDataTaskAsync(new Uri(imageUri));
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions, e.g., network issues
            return null;
        }
    }
}