using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TP4_CHEKATT.Model
{
    internal class AreImporter
    {
        private static Dictionary<string, int> GetWordFrequency(string filePath, int minWordSize, List<string> blackList)
        {
            if (string.IsNullOrWhiteSpace(filePath)) { throw new Exception("filePath is empty !"); }
            if (!File.Exists(filePath)) { throw new Exception($"file : [{filePath}] doesnt exist !"); }
            if (Path.GetExtension(filePath).ToLower() != ".txt") { throw new Exception($"file : [{filePath}] isnt a text file !"); }
            if (blackList == null) { blackList = new List<string>(); }
            return File.ReadLines(filePath)
                .SelectMany(x => x.Split())                             //on divise le texte par mot
                .Where(x => WordValidation(x, minWordSize, blackList))  //on prend que les mots valide
                .GroupBy(x => x)                                        //on groupe par mot
                .ToDictionary(x => x.Key.SupprimerSpecialChar().Proper(), x => x.Count());               //on crée un dictionnaire avec le mot comme clé et son nombre d'itération comme frequence
        }
        private static bool WordValidation(string word, int minWordSize, List<string> blackList)
        {
            return word.Length >= minWordSize && !blackList.Contains(word);
        }

        public static void ImportBlueprintFromText(string file, int minWordSize, List<string> blackList)
        {
            Random r = new Random();
            foreach (var item in GetWordFrequency(file, minWordSize, blackList))
            {
                string nom = item.Key;
                ArmeType type = (ArmeType)r.Next(0, 3);
                int degatMax = Math.Max(item.Key.Length, item.Value);
                int degatMin = Math.Min(item.Key.Length, item.Value);
                int tpsRecharge = r.Next(0, 15);

                Armurerie.CreerArmeImporter(nom, degatMin, degatMax, type, tpsRecharge);
            }
        }

    }
}
