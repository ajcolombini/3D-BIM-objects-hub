using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace ACE.Util
{
    public class clsTextUtil
    {
        /// <summary>
        /// Retorna apenas números de uma string
        /// </summary>
        /// <param name="expr">string com a expressa a ser avalidada</param>
        /// <example>clsTextUtil.ExtractNumber("123.456-78")   Retorna: "12345678"</example>
        /// <returns></returns>
        public static string ExtractNumbers(string expr)
        {
            return string.Join(null, System.Text.RegularExpressions.Regex.Split(expr, "[^\\d]"));
        }

        /// <summary>
        /// Detects the byte order mark of a file and returns
        /// an appropriate encoding for the file.
        /// </summary>
        /// <param name="srcFile"></param>
        /// <returns></returns>
        public static Encoding GetFileEncoding(string srcFile)
        {
            // *** Use Default of Encoding.Default (Ansi CodePage)
            Encoding enc = Encoding.Default;

            // *** Detect byte order mark if any - otherwise assume default
            byte[] buffer = new byte[5];
            FileStream file = new FileStream(srcFile, FileMode.Open);
            file.Read(buffer, 0, 5);
            file.Close();

            if (buffer[0] == 0xef && buffer[1] == 0xbb && buffer[2] == 0xbf)
                enc = Encoding.UTF8;
            else if (buffer[0] == 0xfe && buffer[1] == 0xff)
                enc = Encoding.Unicode;
            else if (buffer[0] == 0 && buffer[1] == 0 && buffer[2] == 0xfe && buffer[3] == 0xff)
                enc = Encoding.UTF32;
            else if (buffer[0] == 0x2b && buffer[1] == 0x2f && buffer[2] == 0x76)
                enc = Encoding.UTF7;

            return enc;
        }

        /// <summary>
        /// Opens a stream reader with the appropriate text encoding applied.
        /// </summary>
        /// <param name="srcFile"></param>
        public static StreamReader OpenStreamReaderWithEncoding(string srcFile)
        {
            Encoding enc = GetFileEncoding(srcFile);
            return new StreamReader(srcFile, enc);
        }

        /// <summary>
        /// Converte String (representando decimal sem ponto) para número Decimal
        /// </summary>
        /// <example>Ex: "832" para 8.32</example>
        /// <example>Ex: "5"   para 5.00</example>
        /// <param name="sDecimalToExtract"></param>
        /// <returns></returns>
        public static Nullable<Decimal> ExtractDecimalFromString(string sDecimalToExtract)
        {
            Decimal _parsed = 0;

            if (sDecimalToExtract.Length < 3) //Transforma em string legível. Ex "5" >> "500" >> 5.00
                sDecimalToExtract = sDecimalToExtract.PadRight(3, '0');

            if (Decimal.TryParse(ExtractNumbers(sDecimalToExtract), out _parsed))
            {
                string _dec = sDecimalToExtract.Substring(sDecimalToExtract.Length - 2);
                string _int = sDecimalToExtract.Substring(0, sDecimalToExtract.Length - 2);

                if (Decimal.TryParse(String.Concat(_int, ".", _dec), out _parsed))
                    return Decimal.Parse(_int + "." + _dec, CultureInfo.InvariantCulture);
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// converte string YYYYMMDD para YYYY-MM-DD (formato SQL)
        /// </summary>
        /// <param name="sDateExtract"></param>
        /// <returns></returns>
        public static string ExtractSQLDateFromString(string sDateExtract)
        {

            String _ret = string.Empty;

            if (sDateExtract.Length == 8)
            {
                string _year = sDateExtract.Substring(0, 4);
                string _month = sDateExtract.Substring(4, 2);
                string _day = sDateExtract.Substring(6, 2);

                _ret = String.Format("{0}-{1}-{2}", _year, _month, _day);

                //Valida Data para SQL Server
                if (DateTime.Parse(_ret) < System.Data.SqlTypes.SqlDateTime.MinValue | DateTime.Parse(_ret) > System.Data.SqlTypes.SqlDateTime.MaxValue)
                {
                    throw new Exception("Data Inválida para SQL Sever : " + _ret);
                }
            }

            return _ret;

        }

        public static string ExtractHourFromString(string sHour)
        {
            String _ret = string.Empty;

            if (sHour.Length < 6) //Transforma em string em hora legível. Ex "1500" >> "150000" >> "15:00:00"
                sHour = sHour.PadLeft(6, '0');

            string _hour = sHour.Substring(0, 2);
            string _minute = sHour.Substring(2, 2);
            string _second = sHour.Substring(4, 2);

            _ret = String.Format("{0}:{1}:{2}", _hour, _minute, _second);


            return _ret;
        }
    }
}
