using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace Framework.Util
{
    /// <summary>
    /// To Validate strings against Regular Expression strings.
    /// </summary>
    /// <example>clsRegExValidateUtil.ProcessRegEx(ValidationTypes.Email, "test@test.com")</example>
    public class clsRegExValidateUtil
    {
        static ArrayList RegexStrings;

        static clsRegExValidateUtil()
        {
            RegexStrings = new ArrayList();

            //Positive Decimal Number
            RegexStrings.Insert((int)ValidationTypes.PositiveDecimal, @"^[0-9][0-9]*(\.[0-9]*)?$");

            //Number
            RegexStrings.Insert((int)ValidationTypes.Numeric, @"^\d+$");

            //Decimal Number (+ or -)
            RegexStrings.Insert((int)ValidationTypes.Decimal, @"^(\+|-)?[0-9][0-9]*(\.[0-9]*)?$");


            //Dates(DD/MM/YYYY)
            RegexStrings.Insert((int)ValidationTypes.DatesDDMMYYYY,
             @"((0[1-9]|[12][0-9]|3[01]))[/|-](0[1-9]|1[0-2])
        		[/|-]((?:\d{4}|\d{2}))");
            //Dates(DD/MM/YY)
            RegexStrings.Insert((int)ValidationTypes.DatesDDMMYY,
             @"((0[1-9]|[12][0-9]|3[01]))[/|-](0[1-9]|1[0-2])[/|-]((?:\d{2}))");
            //Dates(DD MMM YYYY) English
            RegexStrings.Insert((int)ValidationTypes.DatesDD_MMM_YYYY,
             @"^((31(?!\ (Feb(ruary)?|Apr(il)?|June?|
		        (Sep(?=\b|t)t?|Nov)(ember)?)))|
	 	        ((30|29)(?!\ Feb(ruary)?))|(29(?=\ 
		        Feb(ruary)?\ (((1[6-9]|[2-9]\d)(0[48]|
		        [2468][048]|[13579][26])|((16|[2468][048]|
		        [3579][26])00)))))|(0?[1-9])|1\d|2[0-8])\ 
		        (Jan(uary)?|Feb(ruary)?|Ma(r(ch)?|y)|Apr(il)?|
		        Ju((ly?)|(ne?))|Aug(ust)?|
		        Oct(ober)?|(Sep(?=\b|t)t?|Nov|Dec)(ember)?)\ 
		        ((1[6-9]|[2-9]\d)\d{2})");
            //Email
            RegexStrings.Insert((int)ValidationTypes.Email,
              @"^(([^<>()[\]\\.,;áàãâäéèêëíìîïóòõôöúùûüç:\s@\""]+"
              + @"(\.[^<>()[\]\\.,;áàãâäéèêëíìîïóòõôöúùûüç:\s@\""]+)*)|(\"".+\""))@"
              + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|"
              + @"(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$");
            //IPAddress
            RegexStrings.Insert((int)ValidationTypes.IPAddress,
              @"(?<First>2[0-4]\d|25[0-5]|[01]?\d\d?)\.(?<Second>
		        2[0-4]\d|25[0-5]|[01]?\d\d?)\.(?<Third>
		        2[0-4]\d|25[0-5]|[01]?\d\d?)\.
		        (?<Fourth>2[0-4]\d|25[0-5]|[01]?\d\d?)");
            //URL
            RegexStrings.Insert((int)ValidationTypes.URL,
              @"(?\w+):\/\/(?<Domain>[\w.]+\/?)\S*");
            //CEP
            RegexStrings.Insert((int)ValidationTypes.CEP,
             @"/^[0-9]{5}-[0-9]{3}$/");

            // CNPJ
            RegexStrings.Insert((int)ValidationTypes.CNPJ,
             @"^((\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14}))$");

            // CPF
            RegexStrings.Insert((int)ValidationTypes.CPF,
             @"^((\d{3}.\d{3}.\d{3}-\d{2})|(\d{11}))$");

            // String Vazia ou com espaço em Branco
            RegexStrings.Insert((int)ValidationTypes.StringNullEspacoEmBranco,
             @"^$");
        }

        /// <summary>
        /// Method returns true if unknown string matches the 
        /// regular expression defined by type
        /// </summary>
        /// <param name="type">ValidationTypes enum</param>
        /// <param name="textValidate">String to validate</param>
        /// <returns>True if string validates</returns>
        /// <example>Validating e-mail. clsRegExValidateUtil.ProcessRegEx(ValidationTypes.Email, "test@test.com");</example>
        public static bool ProcessRegEx(ValidationTypes type, string textValidate)
        {
            string test = RegexStrings[(int)type].ToString();
            // Create a new Regex object.
            Regex r = new Regex(RegexStrings[(int)type].ToString());
            // Find a single match in the string.
            Match m = r.Match(textValidate);
            return m.Success;
        }

        /// <summary>
        /// Validates an Regex Expression (string) against an string expression
        /// </summary>
        /// <param name="regExpression">Regex Expression to Use</param>
        /// <param name="strValidate">String to Validate</param>
        /// <returns></returns>
        public static bool RegExValidate(string regExpression, string strValidate)
        {
            // Create a new Regex object.
            Regex r = new Regex(regExpression);
            // Find a single match in the string.
            Match m = r.Match(strValidate);
            return m.Success;
        }
                
        public static bool ValidaCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito = "";
            int soma;
            int endfile = 0;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if ((cpf.Length != 11) || (cpf == 00000000000.ToString()) || (cpf == 11111111111.ToString()) || (cpf == 22222222222.ToString()) || (cpf == 33333333333.ToString()) || (cpf == 44444444444.ToString()) || (cpf == 55555555555.ToString()) || (cpf == 66666666666.ToString()) || (cpf == 77777777777.ToString()) || (cpf == 88888888888.ToString()) || (cpf == 99999999999.ToString()))
            {
                return false;
            }

            // tempCpf está recebendo os caracteres da posição 0 até a posição 9
            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma = soma + Convert.ToInt32(tempCpf.Substring(i, 1)) * multiplicador1[i];
                endfile = soma % 11;
            }

            if (endfile < 2)
            {
                endfile = 0;
            }
            else
            {
                endfile = 11 - endfile;
                digito = endfile.ToString();
                tempCpf = tempCpf + digito;
                soma = 0;
            }

            for (int i = 0; i < 10; i++)
            {
                soma = soma + Convert.ToInt32(tempCpf.Substring(i, 1)) * multiplicador2[i];
                endfile = soma % 11;
            }

            if (endfile < 2)
                endfile = 0;
            else
            {
                endfile = 11 - endfile;
                digito = digito + endfile.ToString();
            }
            return true;
        }

        public static bool ValidaCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }
    }
}