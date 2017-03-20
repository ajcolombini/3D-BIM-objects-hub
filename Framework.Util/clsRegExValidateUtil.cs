using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace Framework.Util
{
    public enum RegexValidationTypes
    {

        PositiveDecimal,
        Decimal,
        PositiveNonDecimal,
        NonDecimal,
        /// <summary>
        /// Dates(DD/MM/YYYY)
        /// </summary>
        DatesDDMMYYYY,
        /// <summary>
        /// Dates(DD/MM/YY)
        /// </summary>
        DatesDDMMYY,
        /// <summary>
        /// Dates(DD MMM YYYY)
        /// </summary>
        DatesDD_MMM_YYYY,
        DatesYYYYMMDD,
        Email,
        IPAddress,
        URL,
        /// <summary>
        /// Ex.: 00000-000
        /// </summary>
        CEP
    }

    /// <summary>
    /// To Validate strings against Regular Expression strings.
    /// </summary>
    /// <example>clsRegExValidateUtil.ProcessRegEx(RegexValidationTypes.Email, "test@test.com")</example>
    public class clsRegExValidateUtil
    {
        static ArrayList RegexStrings;
        static clsRegExValidateUtil()
        {
            RegexStrings = new ArrayList();
            //PositiveNumber
            RegexStrings.Insert((int)RegexValidationTypes.PositiveDecimal,
             @"^[0-9][0-9]*(\.[0-9]*)?$");
            //Number
            RegexStrings.Insert((int)RegexValidationTypes.Decimal,
             @"^(\+|-)?[0-9][0-9]*(\.[0-9]*)?$");
            //PositiveNonDecimal
            RegexStrings.Insert((int)RegexValidationTypes.PositiveNonDecimal,
             @"^[0-9][0-9]*$");
            //NonDecimal
            RegexStrings.Insert((int)RegexValidationTypes.NonDecimal,
             @"^(\+|-)?[0-9][0-9]*(\.[0-9]*)?$");
            //Dates(DD/MM/YYYY)
            RegexStrings.Insert((int)RegexValidationTypes.DatesDDMMYYYY,
             @"((0[1-9]|[12][0-9]|3[01]))[/|-](0[1-9]|1[0-2])[/|-]((?:\d{4}|\d{2}))");
            //Dates(DD/MM/YY)
            RegexStrings.Insert((int)RegexValidationTypes.DatesDDMMYY,
             @"((0[1-9]|[12][0-9]|3[01]))[/|-](0[1-9]|1[0-2])[/|-]((?:\d{2}))");
            //Dates(DD MMM YYYY)
            RegexStrings.Insert((int)RegexValidationTypes.DatesDD_MMM_YYYY,
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
            //Dates(YYYYMMDD)
            RegexStrings.Insert((int)RegexValidationTypes.DatesYYYYMMDD,
                @"(?:(?:(?<year1>(?:1[89])|(?:[2468][048]|[3579][26])(?!00))(?<year2>00|[02468][1235679]|[13579][01345789]) (?:(?:(?<month>(?:[0][13578])|(?:1[02]))(?<day>0[1-9]|[12][0-9]|3[01]))| (?:(?<month>0[469]|11)(?<day>0[1-9]|[12][0-9]|30))| (?:(?<month>02)(?<day>0[1-9]|1[0-9]|2[0-8])))| (?:(?:(?<year1>(?:[2468][048]|[3579][26])00)| (?<year1>(?:(?:1[89])|[2468][048]|[3579][26]) (?!00))(?<year2>[02468][048]|[13579][26])) (?:(?:(?<month>(?:(?:[0][13578])|(?:1[02]))) (?<day>0[1-9]|[12][0-9]|3[01]))| (?:(?<month>0[469]|11) (?<day>(?:0[1-9]|[12][0-9]|30)))| (?:(?<month>02)(?<day>0[1-9]|[12][0-9]))))))"
                );
            //Email
            RegexStrings.Insert((int)RegexValidationTypes.Email,
              @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            //IPAddress
            RegexStrings.Insert((int)RegexValidationTypes.IPAddress,
              @"(?<First>2[0-4]\d|25[0-5]|[01]?\d\d?)\.(?<Second>
		        2[0-4]\d|25[0-5]|[01]?\d\d?)\.(?<Third>
		        2[0-4]\d|25[0-5]|[01]?\d\d?)\.
		        (?<Fourth>2[0-4]\d|25[0-5]|[01]?\d\d?)");
            //URL
            RegexStrings.Insert((int)RegexValidationTypes.URL,
              @"(?\w+):\/\/(?<Domain>[\w.]+\/?)\S*");
            //CEP
            RegexStrings.Insert((int)RegexValidationTypes.CEP,
             @"/^[0-9]{5}-[0-9]{3}$/");
        }

        /// <summary>
        /// Method returns true if unknown string matches the 
        /// regular expression defined by type
        /// </summary>
        /// <param name="type">RegexValidationTypes enum</param>
        /// <param name="textValidate">String to validate</param>
        /// <returns>True if string validates</returns>
        /// <example>Validating e-mail. clsRegExValidateUtil.ProcessRegEx(RegexValidationTypes.Email, "test@test.com");</example>
        public static bool ProcessRegEx(RegexValidationTypes type, string textValidate)
        {
            string test = RegexStrings[(int)type].ToString();
            // Create a new Regex object.
            Regex r = new Regex(RegexStrings[(int)type].ToString());
            // Find a single match in the string.
            Match m = r.Match(textValidate);
            return m.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="regExpression">Expressao Regular a ser utilizada</param>
        /// <param name="strValidate">String a validar</param>
        /// <returns></returns>
        public static bool RegExValidate(string regExpression, string strValidate)
        {
            // Create a new Regex object.
            Regex r = new Regex(regExpression);
            // Find a single match in the string.
            Match m = r.Match(strValidate);
            return m.Success;
        }

        /// <summary>
        /// Extrai Numeros de String
        /// </summary>
        /// <param name="_input"></param>
        /// <returns>String com numeros apenas</returns>
        public static string ExtractNumeric(string _input)
        {
            string x;
            x = Regex.Replace(_input, "[^0-9.]", "");

            return x;
        }

        /// <summary>
        /// Extrai caracteres não numericos apenas
        /// </summary>
        /// <param name="_input"></param>
        /// <returns></returns>
        public static string ExtractAlpha(string _input)
        {
            string x;
            x = Regex.Replace(_input, "[^a-zA-Z]", "");

            return x;
        }

        ///// <summary>
        ///// Extracts valid SQL date from String YYYYMMDD format
        ///// </summary>
        ///// <param name="sDateExtract"></param>
        ///// <returns>YYYY-MM-DD</returns>
        //public static string ExtractSQLDateFromString(string sDateExtract)
        //{
        //    string test = RegexStrings[(int)RegexValidationTypes.DatesYYYYMMDD].ToString();
        //    // Create a new Regex object.
        //    Regex r = new Regex(RegexStrings[(int)RegexValidationTypes.DatesYYYYMMDD].ToString());
        //    // Find a single match in the string.
        //    Match m = r.Match(sDateExtract);

        //    String _ret = String.Format("{0}-{1}-{2}", String.Concat(m.Groups["year1"], m.Groups["year2"]), m.Groups["month"].ToString(), m.Groups["day"].ToString());  
        //    return _ret;
        //}

        //private static string ReplaceNamedGroup(string input, string groupName, string replacement, Match m)
        //{
        //    string capture = m.Value;
        //    capture = capture.Remove(m.Groups[groupName].Index - m.Index, m.Groups[groupName].Length);
        //    capture = capture.Insert(m.Groups[groupName].Index - m.Index, replacement);
        //    return capture;
        //}

       
    }

   
}