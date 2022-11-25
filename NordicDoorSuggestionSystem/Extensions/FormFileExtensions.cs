using Microsoft.AspNetCore.Http;

namespace NordicDoorSuggestionSystem.Extensions
{
    public static class FormFileExtensions
    {
        public static byte[] GetBytes(this IFormFile formFile)
        {
             using var memoryStream = new MemoryStream();
             formFile.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
