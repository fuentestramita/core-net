using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{

	public class cipher 
	{
		public static string EncryptString(string plainText)
		{
			byte[] array;
			using (Aes aes = Aes.Create())
			{
				aes.Padding = PaddingMode.PKCS7;
				aes.KeySize = 256;
				aes.Key = new byte[32];
				aes.IV = new byte[16];
				aes.Padding = PaddingMode.PKCS7;
				ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
						{
							streamWriter.Write(plainText);
						}
						array = memoryStream.ToArray();
					}
				}
			}
			return Convert.ToBase64String(array);
		}

		public static string DecryptString(string cipherText)
		{
			byte[] buffer = Convert.FromBase64String(cipherText);
			using (Aes aes = Aes.Create())
			{
				aes.Padding = PaddingMode.PKCS7;
				aes.KeySize = 256;
				aes.Key = new byte[32];
				aes.IV = new byte[16];
				ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
				using (MemoryStream memoryStream = new MemoryStream(buffer))
				{
					using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
					{
						using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
						{
							return streamReader.ReadToEnd();
						}
					}
				}
			}
		}

	}
}
