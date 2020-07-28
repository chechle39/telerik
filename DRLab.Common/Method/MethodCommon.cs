
using System;
using System.Collections.Generic;
using System.IO;

namespace DRLab.Common.Method
{
    public class MethodCommon
    {
        public static string InputString(string value)
        {
            int carry = 1;
            string res = "";
            for (int i = value.Length - 1; i > 0; i--)
            {
                int chars = 0;
                chars += ((int)value[i]);
                chars += carry;
                if (chars > 90)
                {
                    chars = 65;
                    carry = 1;
                }
                else
                {
                    carry = 0;
                }

                if (chars > 57 && chars < 65)
                {
                    carry = 1;
                }

                res = Convert.ToChar(chars) + res;

                if (carry != 1)
                {
                    res = value.Substring(0, i) + res;
                    break;
                }
            }
            if (carry == 1)
            {
                res = Convert.ToChar(value[0] + 1) + res;
            }
            string resStr = res.Replace(":", "0");
            return resStr;
        }

        public static string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
        private static Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}
