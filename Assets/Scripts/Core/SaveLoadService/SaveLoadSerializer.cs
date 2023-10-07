#if NETFX_CORE
using System.Xml;
using System.Runtime.Serialization;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
#else
using System.Runtime.Serialization.Formatters.Binary;
#endif
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace Core
{
    public class SaveLoadSerializer
    {
        #if NETFX_CORE
    public void Save<T>(T data, string encryptKey, string encryptIV, string filePath)
    {
        try
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateBinaryWriter(ms))
                {
                    DataContractSerializer dcs = new DataContractSerializer(typeof(T));
                    dcs.WriteObject(writer, data);
                    writer.Flush();
                }
                byte[] enc = Encrypt(ms.ToArray(), encryptKey);
                File.WriteAllBytes(filePath, enc);
            }
        }
        catch
        {
            Debug.LogError("Failed to save data!");
        }
    }

    public T Load<T>(string encryptKey, string encryptIV, string filePath)
    {
        try
        {
            byte[] obj = File.ReadAllBytes(filePath);
            byte[] dec = Decrypt(obj, encryptKey);

            using (MemoryStream memoryStream = new MemoryStream(dec))
            {
                using (XmlDictionaryReader reader = XmlDictionaryReader.CreateBinaryReader(memoryStream, XmlDictionaryReaderQuotas.Max))
                {
                    DataContractSerializer dcs = new DataContractSerializer(typeof(T));
                    return (T)dcs.ReadObject(reader);
                }
            }
        }
        catch
        {
            return default(T);
        }
    }


    private byte[] Encrypt(byte[] toEncrypt, string key)
    {
        try
        {
            IBuffer keyHash = GetMD5Hash(key);
            IBuffer toEncryptBuffer = CryptographicBuffer.CreateFromByteArray(toEncrypt);
            SymmetricKeyAlgorithmProvider aes = SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.AesEcbPkcs7);
            CryptographicKey symetricKey = aes.CreateSymmetricKey(keyHash);
            IBuffer buffEncrypted = CryptographicEngine.Encrypt(symetricKey, toEncryptBuffer, null);
            byte[] result;
            CryptographicBuffer.CopyToByteArray(buffEncrypted, out result);

            return result;
        }
        catch
        {
            return null;
        }
    }

    private byte[] Decrypt(byte[] toDecrypt, string key)
    {
        try
        {
            IBuffer keyHash = GetMD5Hash(key);
            IBuffer toDecryptBuffer = CryptographicBuffer.CreateFromByteArray(toDecrypt);
            SymmetricKeyAlgorithmProvider aes = SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.AesEcbPkcs7);
            CryptographicKey symetricKey = aes.CreateSymmetricKey(keyHash);
            IBuffer buffDecrypted = CryptographicEngine.Decrypt(symetricKey, toDecryptBuffer, null);
            byte[] result;
            CryptographicBuffer.CopyToByteArray(buffDecrypted, out result);

            return result;
        }
        catch
        {
            return null;
        }
    }

    private IBuffer GetMD5Hash(string key)
    {
        IBuffer buffUtf8Msg = CryptographicBuffer.ConvertStringToBinary(key, BinaryStringEncoding.Utf8);
        HashAlgorithmProvider objAlgProv = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);
        IBuffer buffHash = objAlgProv.HashData(buffUtf8Msg);

        if (buffHash.Length != objAlgProv.HashLength)
        {
            throw new System.Exception("There was an error creating the hash");
        }

        return buffHash;
    }
#else
        public void Save(object data, string encryptKey, string encryptIV, string filePath)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();

                using (Aes aes = Aes.Create())
                {
                    aes.Key = ASCIIEncoding.ASCII.GetBytes(encryptKey);
                    aes.IV = ASCIIEncoding.ASCII.GetBytes(encryptIV);

                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(fs, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            bf.Serialize(cryptoStream, data);
                        }
                    }
                }
            }
            catch
            {
                Debug.LogError("Failed to save data!");
            }
        }

        public T Load<T>(string encryptKey, string encryptIV, string filePath)
        {
            try
            {
                object temp;
                BinaryFormatter bf = new BinaryFormatter();

                using (Aes aes = Aes.Create())
                {
                    aes.Key = ASCIIEncoding.ASCII.GetBytes(encryptKey);
                    aes.IV = ASCIIEncoding.ASCII.GetBytes(encryptIV);
                    
                    using (FileStream fs = new FileStream(filePath, FileMode.Open))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(fs, aes.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            temp = bf.Deserialize(cryptoStream);
                        }
                    }
                }
                return (T)temp;
            }
            catch
            {
                Debug.LogWarning("Failed to load data!");
                return default(T);
            }
        }
#endif

    }
}
