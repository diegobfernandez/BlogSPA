using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace BlogSPA.Domain.Extenders
{
    public static class StringExtender
    {
        public static string Slugify(this string phrase)
        {
            string str = phrase.RemoveAccents().ToLower();

            str = Regex.Replace(str, @"[^a-z0-9\s-]", ""); // invalid chars          
            str = Regex.Replace(str, @"\s+", " ").Trim(); // convert multiple spaces into one space  
            str = str.Substring(0, str.Length <= 128 ? str.Length : 128).Trim(); // cut and trim it  
            str = Regex.Replace(str, @"\s", "-"); // hyphens  

            return str;
        }

        public static string RemoveAccents(this string s)
        {
            if (s == null)
                return String.Empty;
            String normalizedString = s.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < normalizedString.Length; ++i)
            {
                Char c = normalizedString[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }
    }
}
