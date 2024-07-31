using Servicios.Core.DTOs;
using Servicios.Core.Interfaces;
using System.Security.Cryptography;
using System.Text;

#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace Servicios.Api.Helpers
{
    /******
     * Developed By: Juan Daniel Colorado Molina
     * Modified by: Jose Julian Martinez
     */


    public class EncryptHelper : IEncryptHelper
    { 
        // general key
        private readonly string key = "Emtelco-IVR@2022";

        private readonly ILogger _logger;
        private ServiceHelperDTO response;

        public EncryptHelper(ILogger<ServiceHelperDTO> logger)
        {
            this._logger = logger;
            this.response = new ServiceHelperDTO();
        }
        public async Task<ServiceHelperDTO> DecryptText(string? textToDecrypt)
        {
            try
            {
                this.response.data = await DecryptStringFromBytes_Aes(Convert.FromBase64String(textToDecrypt), Encoding.UTF8.GetBytes(key), Encoding.UTF8.GetBytes(key));
                this.response.message = "text decrypted!";
                this.response.success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error decrypting text: {ex.Message}");
                this.response.message = "Error decrypting text";
            }

            return response;
        }

        public async Task<ServiceHelperDTO> EncryptText(string textToEncrypt)
        {
            try
            {
                this.response.data = await EncryptStringToBytesAes(textToEncrypt, Encoding.UTF8.GetBytes(key), Encoding.UTF8.GetBytes(key));
                this.response.message = "text encrypted!";
                this.response.success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error encrypting text: {ex.Message}");
                this.response.message = "Error encrypting text";
            }

            return response;
        }

        //documentacion algoritmo AES: https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.aes?view=net-5.0
        private static async Task<string> EncryptStringToBytesAes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an AesManaged object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create("AesManaged"))
            {

                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;
                aesAlg.FeedbackSize = 128;
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            await swEncrypt.WriteAsync(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return Convert.ToBase64String(encrypted);
        }

        private static async Task<string> DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an AesManaged object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create("AesManaged"))
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = await srDecrypt.ReadToEndAsync();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8604 // Possible null reference argument.