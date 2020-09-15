

namespace GL2017.API.Utilidades
{
    using System;
    using System.Security.Cryptography;
    using System.Text;
    public class MetodosEncriptacion
    {
        public static string Desencriptar(string textoEncriptado)
        {
            try
            {
                while (textoEncriptado.Length % 4 != 0)
                    textoEncriptado += "=";
                textoEncriptado = textoEncriptado.Replace('-', '+').Replace('_', '/');

                string key = "keyparaasegurarlascomunicacionconlospasswords";
                byte[] keyArray;
                byte[] Array_a_Descifrar = Convert.FromBase64String(textoEncriptado);

                //algoritmo MD5
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                hashmd5.Clear();

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();

                byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);

                tdes.Clear();
                textoEncriptado = UTF8Encoding.UTF8.GetString(resultArray);

            }
            catch (Exception)
            {

            }
            return textoEncriptado;
        }
    }
}
