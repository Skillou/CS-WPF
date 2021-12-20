using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace TP4_CHEKATT
{
    internal static class StringTools
    {
        public static string Format(string str)
        {
            //return str.Substring(0).ToUpper();
            return char.ToUpper(str[0]) + str.Substring(1); // renvoie la chaine de caractere avec le premiere caractere en majuscule  
        }
        public static string GetString(string message)
        {
            string value = string.Empty;
            do
            {
                Console.WriteLine(message);
                value = Console.ReadLine();
            } while (value.Any(char.IsDigit));
            return value;
        }

        public static string Proper(this string str)
        {
            string ret = str;
            //permet de recupéré chaque mot contenu dans la chaine "str"
            Regex rgx = new Regex(@"(\w)+");
            MatchCollection matches = rgx.Matches(str);
            foreach (var item in matches)
            {
                // permet de metre la première lettre en majuscule et le reste en minuscule
                string rpl = char.ToUpper(item.ToString()[0]) + item.ToString().Substring(1, item.ToString().Length - 1).ToLower();
                // l'utilisation de replace permet de ne pas perdre les caractère de type '-'
                ret = ret.Replace(item.ToString(), rpl);

            }

            return ret.Trim();
        }

        public static string SupprimerSpecialChar(this string str)
        {
            var textInfo = new CultureInfo("en-US", false).TextInfo;
            return Regex.Replace(textInfo.ToTitleCase(str), "[?.!:;,]", "");
        }
    }
}
