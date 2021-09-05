using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace CSharpApi.Commons
{
    public static class EncryptionUtilities
    {
        static string publickey = "92345678";
        static string secretkey = "87654319";

        /// <summary>
        /// Encrypt a string
        /// </summary>
        /// <param name="str">The string value to encrypt</param>
        /// <returns>string</returns>
        public static string EncryptString(string str)
        {
            try
            {
                byte[] secretkeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                byte[]  publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(str);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    return Convert.ToBase64String(ms.ToArray());
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Decrypt a string
        /// </summary>
        /// <param name="str">The string value to decrypt</param>
        /// <returns>string</returns>
        public static string DecryptString(string str)
        {
            try
            {
              
                byte[] privatekeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);

                MemoryStream ms = null;
                CryptoStream cs = null;

                string formatedStr = str.Replace(" ", "+");
                byte[] inputbyteArray = new byte[formatedStr.Length];
                inputbyteArray = Convert.FromBase64String(formatedStr);

                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    Encoding encoding = Encoding.UTF8;
                    return encoding.GetString(ms.ToArray());
                }
            }
            catch (Exception ae)
            {
                throw new Exception(ae.Message, ae.InnerException);
            }
        }

    }
}
