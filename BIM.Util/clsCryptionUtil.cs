using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;


namespace ACE.Util
{
    /// <summary>
    /// Enumerator com os tipos de classes para criptografia.
    /// </summary>
    public enum CryptProvider
    {
        /// <summary>
        /// Representa a classe base para implementações criptografia dos algoritmos simétricos Rijndael.
        /// </summary>
        Rijndael,

        /// <summary>
        /// Representa a classe base para implementações do algoritmo RC2.
        /// </summary>
        RC2,

        /// <summary>
        /// Representa a classe base para criptografia de dados padrões (DES - Data Encryption Standard).
        /// </summary>
        DES,

        /// <summary>
        /// Representa a classe base (TripleDES - Triple Data Encryption Standard).
        /// </summary>
        TripleDES
    }

    /// <summary>
    /// Classe de Criptografia
    /// </summary>
    public class clsCryptionUtil
    {
        #region Destrutor
        ~clsCryptionUtil() { }
        #endregion

        #region Variáveis e Métodos Privados

        private string _key = string.Empty;
        private CryptProvider _cryptProvider;
        private SymmetricAlgorithm _algorithm;


        /// <summary>
        /// Inicialização do vetor do algoritmo simétrico
        /// </summary>
        private void SetIV()
        {
            switch (_cryptProvider)
            {
                case CryptProvider.Rijndael:
                    _algorithm.IV = new byte[] { 0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9, 0x5, 0x46, 0x9c, 0xea, 0xa8, 0x4b, 0x73, 0xcc };
                    break;

                default:
                    _algorithm.IV = new byte[] { 0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9 };
                    break;
            }
        }
        #endregion

        #region Properties

        /// <summary>
        /// Chave secreta para o algoritmo simétrico de criptografia.
        /// </summary>
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Contrutor padrão da classe, é setado um tipo de criptografia padrão (Rijndael).
        /// </summary>
        public clsCryptionUtil()
        {
            _algorithm = new RijndaelManaged();
            _algorithm.Mode = CipherMode.CBC;
            _cryptProvider = CryptProvider.Rijndael;
        }

        /// <summary>
        /// Construtor com o tipo de criptografia a ser usada Você pode escolher o tipo pelo Enum chamado CryptProvider.
        /// </summary>
        /// <param name="cryptProvider">Tipo de criptografia.</param>
        public clsCryptionUtil(CryptProvider cryptProvider)
        {

            // Seleciona algoritmo simétrico
            switch (cryptProvider)
            {

                case CryptProvider.Rijndael:
                    _algorithm = new RijndaelManaged();
                    _cryptProvider = CryptProvider.Rijndael;
                    break;
                case CryptProvider.RC2:
                    _algorithm = new RC2CryptoServiceProvider();
                    _cryptProvider = CryptProvider.RC2;
                    break;
                case CryptProvider.DES:
                    _algorithm = new DESCryptoServiceProvider();
                    _cryptProvider = CryptProvider.DES;
                    break;
                case CryptProvider.TripleDES:
                    _algorithm = new TripleDESCryptoServiceProvider();
                    _cryptProvider = CryptProvider.TripleDES;
                    break;

            }
            _algorithm.Mode = CipherMode.CBC;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Gera a chave de criptografia válida dentro do array.
        /// </summary>
        /// <returns>Chave com array de bytes.</returns>
        public virtual byte[] GetKey()
        {
            string salt = string.Empty;

            // Ajusta o tamanho da chave se necessário e retorna uma chave válida
            if (_algorithm.LegalKeySizes.Length > 0)
            {

                // Tamanho das chaves em bits
                int keySize = _key.Length * 8;
                int minSize = _algorithm.LegalKeySizes[0].MinSize;
                int maxSize = _algorithm.LegalKeySizes[0].MaxSize;
                int skipSize = _algorithm.LegalKeySizes[0].SkipSize;

                if (keySize > maxSize)
                {
                    // Busca o valor máximo da chave
                    _key = _key.Substring(0, maxSize / 8);
                }

                else if (keySize < maxSize)
                {
                    // Seta um tamanho válido
                    int validSize = (keySize <= minSize) ? minSize : (keySize - keySize % skipSize) + skipSize;

                    if (keySize < validSize)
                    {
                        // Preenche a chave com arterisco para corrigir o tamanho
                        _key = _key.PadRight(validSize / 8, '*');
                    }
                }
            }
            PasswordDeriveBytes key = new PasswordDeriveBytes(_key, ASCIIEncoding.ASCII.GetBytes(salt));
            return key.GetBytes(_key.Length);

        }


        /// <summary>
        /// Gera a chave de criptografia válida em string.
        /// </summary>
        /// <returns>Chave em string.</returns>
        public virtual string GetStringKey()
        {
            string salt = string.Empty;

            // Ajusta o tamanho da chave se necessário e retorna uma chave válida
            if (_algorithm.LegalKeySizes.Length > 0)
            {

                // Tamanho das chaves em bits
                int keySize = _key.Length * 8;
                int minSize = _algorithm.LegalKeySizes[0].MinSize;
                int maxSize = _algorithm.LegalKeySizes[0].MaxSize;
                int skipSize = _algorithm.LegalKeySizes[0].SkipSize;

                if (keySize > maxSize)
                {
                    // Busca o valor máximo da chave
                    _key = _key.Substring(0, maxSize / 8);
                }

                else if (keySize < maxSize)
                {
                    // Seta um tamanho válido
                    int validSize = (keySize <= minSize) ? minSize : (keySize - keySize % skipSize) + skipSize;

                    if (keySize < validSize)
                    {
                        // Preenche a chave com arterisco para corrigir o tamanho
                        _key = _key.PadRight(validSize / 8, '*');
                    }
                }
            }
            PasswordDeriveBytes key = new PasswordDeriveBytes(_key, ASCIIEncoding.ASCII.GetBytes(salt));
            return System.Text.Encoding.Default.GetString(key.GetBytes(_key.Length));
            
        }

        /// <summary>
        /// Encripta o dado solicitado.
        /// </summary>
        /// <param name="texto">Texto a ser criptografado.</param>
        /// <returns>Texto criptografado.</returns>
        /// <example>
        ///string Key = "@*--Sace/@" //Chave é definida pelo utilizador da classe no momento de encryptar. Sem essa mesma chave que foi definida no momento de encryptar, não será possível decriptar a string;
        ///string texto = "Ace_Seguros";
        ///clsCryptionUtil crip = new clsCryptionUtil(CryptProvider.DES);
        ///crip.Key = Key;
        ///string _ret = crip.Encrypt(texto);
        /// </example>
        public virtual string Encrypt(string texto)
        {
        
            byte[] plainByte = Encoding.UTF8.GetBytes(texto);
            byte[] keyByte = GetKey();

            //Seta a chave privada
            _algorithm.Key = keyByte;
            SetIV();

            //Interface de criptografia / Cria objeto de criptografia
            ICryptoTransform cryptoTransform = _algorithm.CreateEncryptor();
            MemoryStream _memoryStream = new MemoryStream();
            CryptoStream _cryptoStream = new CryptoStream(_memoryStream, cryptoTransform, CryptoStreamMode.Write);

            // Grava os dados criptografados no MemoryStream
            _cryptoStream.Write(plainByte, 0, plainByte.Length);
            _cryptoStream.FlushFinalBlock();

            // Busca o tamanho dos bytes encriptados
            byte[] cryptoByte = _memoryStream.ToArray();

            // Converte para a base 64 string para uso posterior em um xml
            return Convert.ToBase64String(cryptoByte, 0, cryptoByte.GetLength(0));

            #region "TripleDESCryptoServiceProvider "


            //TripleDESCryptoServiceProvider objcriptografaSenha = new TripleDESCryptoServiceProvider();
            //MD5CryptoServiceProvider objcriptoMd5 = new MD5CryptoServiceProvider();

            //byte[] byteHash, byteBuff;
            //string strTempKey = GetStringKey();

            //byteHash = objcriptoMd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey));
            //objcriptoMd5 = null;
            //objcriptografaSenha.Key = byteHash;
            //objcriptografaSenha.Mode = CipherMode.ECB;

            //byteBuff = ASCIIEncoding.ASCII.GetBytes(texto);
            //return Convert.ToBase64String(objcriptografaSenha.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));   
            #endregion
        }


        /// <summary>
        /// Desencripta o dado solicitado.
        /// </summary>
        /// <param name="textoCriptografado">Texto a ser descriptografado.</param>
        /// <returns>Texto descriptografado.</returns>
        /// <example>
        ///string Key = "@*--Sace/@" //Chave é definida pelo utilizador da classe. Sem essa a mesma chave que ecryptou não será possível decriptar a string;
        ///string texto = "Ace_Seguros";
        ///clsCryptionUtil crip = new clsCryptionUtil(CryptProvider.DES);
        ///crip.Key = Key;
        ///string _decry = crip.Decrypt(_ret);
        /// </example>
        public virtual string Decrypt(string textoCriptografado)
        {

            // Converte a base 64 string em num array de bytes
            byte[] cryptoByte = Convert.FromBase64String(textoCriptografado);

            byte[] keyByte = GetKey();

            // Seta a chave privada
            _algorithm.Key = keyByte;
            SetIV();

            // Interface de criptografia / Cria objeto de descriptografia
            ICryptoTransform cryptoTransform = _algorithm.CreateDecryptor();

            try
            {
                MemoryStream _memoryStream = new MemoryStream(cryptoByte, 0, cryptoByte.Length);
                CryptoStream _cryptoStream = new CryptoStream(_memoryStream, cryptoTransform, CryptoStreamMode.Read);

                // Busca resultado do CryptoStream
                StreamReader _streamReader = new StreamReader(_cryptoStream);
                return _streamReader.ReadToEnd();
            }
            catch
            {
                return null;
            }
            #region " TripleDESCryptoServiceProvider "
            //try
            //{

            //    TripleDESCryptoServiceProvider objdescriptografaSenha = new TripleDESCryptoServiceProvider();
            //    MD5CryptoServiceProvider objcriptoMd5 = new MD5CryptoServiceProvider();

            //    byte[] byteHash, byteBuff;
            //    string strTempKey = GetStringKey();

            //    byteHash = objcriptoMd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey));
            //    objcriptoMd5 = null;
            //    objdescriptografaSenha.Key = byteHash;
            //    objdescriptografaSenha.Mode = CipherMode.ECB;

            //    byteBuff = Convert.FromBase64String(textoCriptografado);
            //    string strDecrypted = ASCIIEncoding.ASCII.GetString(objdescriptografaSenha.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            //    objdescriptografaSenha = null;

            //    return strDecrypted;  
            //}
            //catch
            //{
            //    return null;
            //}
            #endregion
        }

    
        #endregion
    }
}
