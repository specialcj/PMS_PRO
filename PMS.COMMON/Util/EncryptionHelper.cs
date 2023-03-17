using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PMS.COMMON.Util
{
    public enum EncryptionKeyEnum
    {
        KeyA,
        KeyB,
        KeyC,
        KeyD
    }

    public class EncryptionHelper
    {
        string encryptionKeyA = "JC0_PROF";
        string encryptionKeyB = "JC1_SPEC";
        string encryptionKeyC = "JC2_A030";//free use for 30mins encrypt
        string encryptionKeyD = "JC3_B030";//free use for 30mins dencrypt
        string md5Begin = "Hello";
        string md5End = "NWorld";
        string encryptionKey = string.Empty;
        public EncryptionHelper()
        {
            this.InitKey();
        }
        public EncryptionHelper(EncryptionKeyEnum key)
        {
            this.InitKey(key);
        }
        private void InitKey(EncryptionKeyEnum key = EncryptionKeyEnum.KeyA)
        {
            switch (key)
            {
                case EncryptionKeyEnum.KeyA:
                    encryptionKey = encryptionKeyA;
                    break;
                case EncryptionKeyEnum.KeyB:
                    encryptionKey = encryptionKeyB;
                    break;
                case EncryptionKeyEnum.KeyC:
                    encryptionKey = encryptionKeyC;
                    break;
                case EncryptionKeyEnum.KeyD:
                    encryptionKey = encryptionKeyD;
                    break;
            }
        }

        public string EncryptString(string str)
        {
            return Encrypt(str, encryptionKey);
        }
        public string DecryptString(string str)
        {
            return Decrypt(str, encryptionKey);
        }
        public string GetMD5String(string str)
        {
            str = string.Concat(md5Begin, str, md5End);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.Unicode.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string md5String = string.Empty;
            foreach (var b in targetData)
                md5String += b.ToString("x2");
            return md5String;
        }

        private string Encrypt(string str, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(str);
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }
        private string Decrypt(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }
    }
}
