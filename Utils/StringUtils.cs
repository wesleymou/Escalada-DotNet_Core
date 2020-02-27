using System.Globalization;
using System.Linq;
using System.Text;

namespace Escalada_DotNet_Core.Utils
{
    public static class StringUtils
    {
        // public static string RemoveAccents(this string text)
        // {
        //     StringBuilder sbReturn = new StringBuilder();
        //     var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
        //     foreach (char letter in arrayText)
        //     {
        //         if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
        //             sbReturn.Append(letter);
        //     }
        //     return sbReturn.ToString();
        // }

        public static string RemoveAccents(this string text)
        {
            return new string(text
                .Normalize(NormalizationForm.FormD)
                .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        }
    }

}