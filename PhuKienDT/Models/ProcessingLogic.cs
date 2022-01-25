using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhuKienDT.Models
{
    public class ProcessingLogic
    {
        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] buffer;
            byte[] inputBuffer = Convert.FromBase64String(cipherString);
            string s = "Duy To";
            if (!useHashing)
            {
                buffer = Encoding.UTF8.GetBytes(s);
            }
            else
            {
                MD5CryptoServiceProvider provider2 = new MD5CryptoServiceProvider();
                buffer = provider2.ComputeHash(Encoding.UTF8.GetBytes(s));
                provider2.Clear();
            }
            TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider
            {
                Key = buffer,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            byte[] bytes = provider.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
            provider.Clear();
            return Encoding.UTF8.GetString(bytes);
        }

        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] buffer;
            byte[] bytes = Encoding.UTF8.GetBytes(toEncrypt);
            string s = "Duy To";
            if (!useHashing)
            {
                buffer = Encoding.UTF8.GetBytes(s);
            }
            else
            {
                MD5CryptoServiceProvider provider2 = new MD5CryptoServiceProvider();
                buffer = provider2.ComputeHash(Encoding.UTF8.GetBytes(s));
                provider2.Clear();
            }
            TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider
            {
                Key = buffer,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            byte[] inArray = provider.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
            provider.Clear();
            return Convert.ToBase64String(inArray, 0, inArray.Length);
        }

        public string GetEnCode(string chuoi) =>
            Encrypt(chuoi, true);

        private static readonly string[] VietnameseSigns = new string[]
        {
            "aAeEoOuUiIdDyY",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };

        public string RemoveSign4VietnameseString(string str)
        {
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            return str;
        }

        public string ToTitleCase(string s)
        {
            s = s.ToLower();
            char[] charArr = s.ToCharArray();
            charArr[0] = Char.ToUpper(charArr[0]);
            foreach (Match m in Regex.Matches(s, @"(\s\S)"))
            {
                charArr[m.Index + 1] = m.Value.ToUpper().Trim()[0];
            }

            return new String(charArr);
        }

        public string DecodeFromUtf8(string utf8String)
        {
            // copy the string as UTF-8 bytes.
            byte[] utf8Bytes = new byte[utf8String.Length];
            for (int i = 0; i < utf8String.Length; ++i)
            {
                //Debug.Assert( 0 <= utf8String[i] && utf8String[i] <= 255, "the char must be in byte's range");
                utf8Bytes[i] = (byte)utf8String[i];
            }

            return Encoding.UTF8.GetString(utf8Bytes, 0, utf8Bytes.Length);
        }

        public string GetFileName(string path)
        {
            string filename = "";
            //Lấy vị trí xuất hiện cuối cùng dấu "/"
            int index = path.LastIndexOf("/");
            //Cắt chuỗi s tính từ vị trí index + 1
            filename = path.Substring(index + 1);
            ////Lấy vị trí xuất hiện dấu "."
            //index = tenBaiHat.LastIndexOf(".");
            //Lấy tên bài hát (không có phần mở rộng)
            //filename = filename.Substring(0, index);
            return filename;
        }

        public string GetExtension(string path)
        {
            string extension = "";
            int index = path.LastIndexOf(".");
            extension = path.Substring(index + 1);
            return extension;
        }
    }
}
