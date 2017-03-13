using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Framework.Security
{

    /// <summary>
    /// Classe para criptografia RijndaelManaged.
    /// </summary>
    public static class clsCriptografia
    {
        /// <summary>
        /// Encripta o texto informado com o algorítmo RijndaelManaged.
        /// </summary>
        /// <param name="textoDecriptado">Texto a ser encriptado.</param>
        /// <param name="senha">Senha para a criptografia.</param>
        /// <param name="salt">Salt para a criptografia.</param>
        /// <returns></returns>
        public static string Encriptar(string textoDecriptado, string senha, string salt)
        {
            // Stream para trabalhar na memória.
            MemoryStream msEncrypt = null;

            // Objeto RijndaelManaged para criptografia
            RijndaelManaged aesAlg = null;

            try
            {
                aesAlg = new RijndaelManaged();

                // Array com o salt.
                byte[] arSalt = Encoding.ASCII.GetBytes(salt);
                // Senha para trabalhar com a chave e o salt.
                Rfc2898DeriveBytes passwordKey = new Rfc2898DeriveBytes(senha, arSalt);
                // Atribui a senha.
                aesAlg.Key = passwordKey.GetBytes(aesAlg.KeySize / 8);
                // Atribui o Initial Vector.
                aesAlg.IV = passwordKey.GetBytes(aesAlg.BlockSize / 8);

                // Criação de objeto para realilzar a criptografia.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Criação de streams para encriptação.
                msEncrypt = new MemoryStream();
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        // Grava todo o dado no stream.
                        swEncrypt.Write(textoDecriptado);
                    }
                }
            }
            finally
            {
                // Limpa o objeto RijndaelManaged.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            // Retorna a string encriptada à partir do array de bytes.
            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        /// <summary>
        /// Decripta o texto informado com o algorítimo RijndaelManaged.
        /// </summary>
        /// <param name="textoEncriptado">Texto a ser decriptado.</param>
        /// <param name="senha">Senha para a criptografia.</param>
        /// <param name="salt">Salt para a criptografia.</param>
        /// <returns></returns>
        public static string Decriptar(string textoEncriptado, string senha, string salt)
        {
            // Declara objeto RijndaelManaged para decriptação.
            RijndaelManaged aesAlg = null;

            // Conteúdo decriptado
            string textoDecriptado = null;

            try
            {
                // Cria o objeto RijndaelManaged.
                aesAlg = new RijndaelManaged();

                // Array com o salt.
                byte[] arSalt = Encoding.ASCII.GetBytes(salt);
                // Senha para trabalhar com a chave e o salt.
                Rfc2898DeriveBytes passwordKey = new Rfc2898DeriveBytes(senha, arSalt);
                // Atribui a senha.
                aesAlg.Key = passwordKey.GetBytes(aesAlg.KeySize / 8);
                // Atribui o Initial Vector.
                aesAlg.IV = passwordKey.GetBytes(aesAlg.BlockSize / 8);

                // Cria objeto para realizar a decritografia.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                // Criação de streams para decriptação.
                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(textoEncriptado)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            // Lê o texto decriptado do stream e grava na string.
                            textoDecriptado = srDecrypt.ReadToEnd();
                    }
                }
            }
            catch (Exception)
            {
                textoDecriptado = "";
            }
            finally
            {
                // Limpa o objeto.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            return textoDecriptado;
        }
        
        /// <summary>
        /// Cria um hash à partir da senha informada.
        /// </summary>
        /// <param name="senha">Senha informada.</param>
        /// <returns>Hash da senha.</returns>
        public static string CriacaoHashSenha(string senha)
        {
            SHA512Managed HashTool = new SHA512Managed();
            Byte[] PhraseAsByte = Encoding.UTF8.GetBytes(string.Concat(senha));
            Byte[] EncryptedBytes = HashTool.ComputeHash(PhraseAsByte);
            HashTool.Clear();
            return Convert.ToBase64String(EncryptedBytes);
        }

    }
}
