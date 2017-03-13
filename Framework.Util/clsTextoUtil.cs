using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Util
{
    public class clsTextoUtil
    {
        /// <summary>
        /// Retira acentuação, espaços, caracteres especiais, espaços 
        /// no início e espaços duplicados, tabulações e etc
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetStringNoAccents(string str)
        {
            /** Troca os caracteres acentuados por não acentuados **/
            string[] acentos = new string[] { "ç", "Ç", "á", "é", "í", "ó", "ú", "ý", "Á", "É", "Í", "Ó", "Ú", "Ý", "à", "è", "ì", "ò", "ù", "À", "È", "Ì", "Ò", "Ù", "ã", "õ", "ñ", "ä", "ë", "ï", "ö", "ü", "ÿ", "Ä", "Ë", "Ï", "Ö", "Ü", "Ã", "Õ", "Ñ", "â", "ê", "î", "ô", "û", "Â", "Ê", "Î", "Ô", "Û" };
            string[] semAcento = new string[] { "c", "C", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "Y", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U", "a", "o", "n", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "A", "O", "N", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U" };

            for (int i = 0; i < acentos.Length; i++)
            {
                str = str.Replace(acentos[i], semAcento[i]);
            }

            /** Troca os caracteres especiais da string por "" **/
            string[] caracteresEspeciais = { "\\.", ",", "-", ":", "\\(", "\\)", "ª", "\\|", "\\\\", "°" };

            for (int i = 0; i < caracteresEspeciais.Length; i++)
            {
                str = str.Replace(caracteresEspeciais[i], "");
            }

            /** Troca os espaços no início por "" **/
            str = str.Replace("^\\s+", "");
            /** Troca os espaços no início por "" **/
            str = str.Replace("\\s+$", "");
            /** Troca os espaços duplicados, tabulações e etc por  " " **/
            str = str.Replace("\\s+", " ");
            return str;
        }
        
        /// <summary>
        /// Da Replace na string retirando os caracteres: "\\.", ",", "-", ":", "\\(", "\\)", "ª", "\\|", "\\\\", "°","'"
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReplaceCaracteresEspeciais(string str){        
            /** Troca os caracteres especiais da string por "" **/
            string[] caracteresEspeciais = { "\\.", ",", "-", ":", "\\(", "\\)", "ª", "\\|", "\\\\", "°","'"};
            for (int i = 0; i < caracteresEspeciais.Length; i++)
            {
                str = str.Replace(caracteresEspeciais[i], "");
            }
            return str;
        }
        
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
        /// Mascara de campos.
        /// Exemplo CPF: Response.write(FormataString(“###.###.###-##”, “09289209309”));
        /// Exemplo Valor: Response.write(FormataString(“##,##”, “2309”));
        /// </summary>
        /// <param name="mascara"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static string FormataMascaraString(string mascara, string valor)
        {
            string novoValor = string.Empty;
            int posicao = 0;
            for (int i = 0; mascara.Length > i; i++)
            {
                if (mascara[i].ToString() == "#")
                {
                    if (valor.Length > posicao)
                    {
                        novoValor = novoValor + valor[posicao];
                        posicao++;
                    }
                    else
                        break;
                }
                else
                {
                    if (valor.Length > posicao)
                        novoValor = novoValor + mascara[i];
                    else
                        break;
                }
            }
            return novoValor;
        }
        
        /// <summary>
        /// Separa em um list o Nome e Sobrenome. 
        /// </summary>
        /// <param name="str">String com Nome seguido do sobrenome</param>
        /// <returns>Posição zero do list é o nome e posição 1 é o sobrenome</returns>
        public static List<string> SepararNomeSobrenome(string str)
        {
            List<string> _list = new List<string>();
            int _posicao = str.IndexOf(" ");
            _list.Add(str.Substring(0, _posicao));
            _list.Add(str.Substring(_posicao, Convert.ToInt32(str.Length) - Convert.ToInt32(str.IndexOf(" "))).TrimStart());
            return _list;
        }
    }
}
