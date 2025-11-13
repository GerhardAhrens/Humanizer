//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="PTA GmbH">
//     Class: Program
//     Copyright © PTA GmbH 2025
// </copyright>
// <Template>
// 	Version 2, 18.7.2025
// </Template>
//
// <author>Gerhard Ahrens - PTA GmbH</author>
// <email>gerhard.ahrens@pta.de</email>
// <date>12.11.2025 12:01:44</date>
//
// <summary>
// Konsolen Applikation mit Menü
// </summary>
//-----------------------------------------------------------------------

namespace Humanizer
{
    /* Imports from NET Framework */
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Text;
    using System.Text.RegularExpressions;


    /* Imports from ModernUI Framework */
    using ModernConsole.Menu;

    public class Program
    {
        private static void Main(string[] args)
        {
            SmartMenu.Menu("Humanizer Beispiel")
                .Add("Text (3 Teile, zwei Segmente) für plural/singular", () => { MenuPoint1(); })
                .Add("Text (2 Teile) ein Segment für plural/singular", () => { MenuPoint2(); })
                .Add("Text (3 Teile) ein Segment für plural/singular", () => { MenuPoint3(); })
                .Add("Zahl nach Worten umwandeln", () => { MenuPoint4(); })
                .Add("Vergangene Zeit in Worten", () => { MenuPoint5(); })

                .Add(SmartMenu.Menu("Humanize Test/String")
                .Add("Test to Humanize TitleCase", () => { MenuPoint6(); }, 1)
                .Add("Test to Humanize PascalCase", () => { MenuPoint7(); }, 1)
                .Add("Test to Humanize CamelCase", () => { MenuPoint8(); }, 1)
                .Add("Test to Humanize SnakeCase", () => { MenuPoint9(); }, 1)
                .Add("Test to Humanize KebabCase", () => { MenuPoint10(); }, 1)
                )
                .Show();

        }

        private static void MenuPoint1()
        {
            MConsole.Clear();

            string aa1 = Humanizer.Message("Bereit: [kein/ein/{0}] - [Datensatz/Datensatz/Datensätze]", 0);
            MConsole.WriteInfoLine(aa1);
            string aa2 = Humanizer.Message("Bereit: [kein/ein/{0}] - [Datensatz/Datensatz/Datensätze]", 1);
            MConsole.WriteInfoLine(aa2);
            string aa3 = Humanizer.Message("Bereit: [kein/ein/{0}] - [Datensatz/Datensatz/Datensätze]", 2);
            MConsole.WriteInfoLine(aa3);
            string aa4 = Humanizer.Message("Bereit: [kein/ein/{0}] [Datensatz/Datensatz/Datensätze] gefunden", 21);
            MConsole.WriteInfoLine(aa4);
            string aa5 = Humanizer.Message("[kein/ein/{0}] [Datensatz/Datensatz/Datensätze]", 42);
            MConsole.WriteInfoLine(aa5);

            MConsole.Wait();
        }

        private static void MenuPoint2()
        {
            MConsole.Clear();

            string var1 = Humanizer.Message("[Es ist kein Datensatz vorhanden/Es sind mehrere Datenätze vorhanden]", 0);
            MConsole.WriteInfoLine(var1);
            string var2 = Humanizer.Message("[Es ist kein Datensatz vorhanden/Es ist ein oder mehrere Datensätze vorhanden]", 2);
            MConsole.WriteInfoLine(var2);
            MConsole.Wait();
        }

        private static void MenuPoint3()
        {
            MConsole.Clear();

            string del1 = Humanizer.Message("[Es wurde kein Datensatz zum löschen gefunden/Soll der gefundene Datensatz gelöscht werden/Sollen die gefunden '{0}' Datensätze gelöscht werden]", 0);
            MConsole.WriteInfoLine(del1);
            string del2 = Humanizer.Message("[Es wurde kein Datensatz zum löschen gefunden/Soll der gefundene Datensatz gelöscht werden/Sollen die gefunden '{0}' Datensätze gelöscht werden]", 1);
            MConsole.WriteInfoLine(del2);
            string del3 = Humanizer.Message("[Es wurde kein Datensatz zum löschen gefunden/Soll der gefundene Datensatz gelöscht werden/Sollen die gefunden '{0}' Datensätze gelöscht werden]", 2);
            MConsole.WriteInfoLine(del3);

            MConsole.Wait();
        }

        private static void MenuPoint4()
        {
            MConsole.Clear();

            string w1 = Humanizer.ToWord(0);
            MConsole.WriteInfoLine(w1);

            string w21 = Humanizer.ToWord(1);
            MConsole.WriteInfoLine(w21);

            string w2 = Humanizer.ToWord(100);
            MConsole.WriteInfoLine(w2);

            string w3 = Humanizer.ToWord(101);
            MConsole.WriteInfoLine(w3);

            string w4 = Humanizer.ToWord(342);
            MConsole.WriteInfoLine(w4);

            string w5 = Humanizer.ToWord(100.99m," und ");
            MConsole.WriteInfoLine(w5);

            string w51 = Humanizer.ToWord(88.88);
            MConsole.WriteInfoLine(w51);

            string w6 = Humanizer.ToWord(123456);
            MConsole.WriteInfoLine(w6);

            MConsole.Wait();
        }

        private static void MenuPoint5()
        {
            MConsole.Clear();

            DateTime vergangen = DateTime.Now.AddMinutes(-2);
            string t1 = Humanizer.ToTimeText(vergangen);
            MConsole.WriteInfoLine(t1);

            vergangen = DateTime.Now.AddMinutes(-30);
            t1 = Humanizer.ToTimeText(vergangen);
            MConsole.WriteInfoLine(t1);

            MConsole.Wait();
        }

        private static void MenuPoint6()
        {
            MConsole.Clear();

            string t1 = Humanizer.Humanize("DIES_IST_EIN_TEST");
            MConsole.WriteInfoLine(t1);

            string t2 = Humanizer.Humanize("dies ist ein test");
            MConsole.WriteInfoLine(t2);

            MConsole.Wait();
        }

        private static void MenuPoint7()
        {
            MConsole.Clear();

            string t1 = Humanizer.Humanize("DIES_IST_EIN_TEST",HumanizeCase.PascalCase);
            MConsole.WriteInfoLine(t1);

            string t2 = Humanizer.Humanize("dies ist ein test", HumanizeCase.PascalCase);
            MConsole.WriteInfoLine(t2);

            string t3 = Humanizer.Humanize("Dies|ist|ein|Test", HumanizeCase.PascalCase);
            MConsole.WriteInfoLine(t3);

            string t4 = Humanizer.Humanize("ABC42ZYX", HumanizeCase.PascalCase);
            MConsole.WriteInfoLine(t4);

            MConsole.Wait();
        }

        private static void MenuPoint8()
        {
            MConsole.Clear();

            string t1 = Humanizer.Humanize("DIES_IST_EIN_TEST",HumanizeCase.CamelCase);
            MConsole.WriteInfoLine(t1);

            string t2 = Humanizer.Humanize("dies ist ein test", HumanizeCase.CamelCase);
            MConsole.WriteInfoLine(t2);

            MConsole.Wait();
        }

        private static void MenuPoint9()
        {
            MConsole.Clear();

            string t1 = Humanizer.Humanize("TestSC", HumanizeCase.SnakeCase);
            MConsole.WriteInfoLine(t1);

            t1 = Humanizer.Humanize("testSC", HumanizeCase.SnakeCase);
            MConsole.WriteInfoLine(t1);

            t1 = Humanizer.Humanize("DiesIstEinTest", HumanizeCase.SnakeCase);
            MConsole.WriteInfoLine(t1);

            t1 = Humanizer.Humanize("TestSnakeCase", HumanizeCase.SnakeCase);
            MConsole.WriteInfoLine(t1);

            t1 = Humanizer.Humanize("testSnakeCase", HumanizeCase.SnakeCase);
            MConsole.WriteInfoLine(t1);

            t1 = Humanizer.Humanize("TestSnakeCase123", HumanizeCase.SnakeCase);
            MConsole.WriteInfoLine(t1);

            t1 = Humanizer.Humanize("_testSnakeCase123", HumanizeCase.SnakeCase);
            MConsole.WriteInfoLine(t1);

            t1 = Humanizer.Humanize("test_SC", HumanizeCase.SnakeCase);
            MConsole.WriteInfoLine(t1);

            MConsole.Wait();
        }

        private static void MenuPoint10()
        {
            MConsole.Clear();

            string t1 = Humanizer.Humanize("KebabAusPascalCase", HumanizeCase.KebabCase);
            MConsole.WriteInfoLine(t1);

            t1 = Humanizer.Humanize("KebabAusCamelCase", HumanizeCase.KebabCase);
            MConsole.WriteInfoLine(t1);

            t1 = Humanizer.Humanize("Kebab aus Leerstellen", HumanizeCase.KebabCase);
            MConsole.WriteInfoLine(t1);

            t1 = Humanizer.Humanize("KebabMitZahlen12345", HumanizeCase.KebabCase);
            MConsole.WriteInfoLine(t1);

            t1 = Humanizer.Humanize("Kebab mit Zahlen 12345", HumanizeCase.KebabCase);
            MConsole.WriteInfoLine(t1);

            t1 = Humanizer.Humanize("Kebab--mit--Dash", HumanizeCase.KebabCase);
            MConsole.WriteInfoLine(t1);

            t1 = Humanizer.Humanize("Kebab%mit§$Sondärzeichön?", HumanizeCase.KebabCase);
            MConsole.WriteInfoLine(t1);

            t1 = Humanizer.Humanize("-kebab mit dash am anfang und ende-", HumanizeCase.KebabCase);
            MConsole.WriteInfoLine(t1);

            MConsole.Wait();
        }
    }

    public static class Humanizer
    {
        public static string Message(string msg, int count)
        {
            string result = string.Empty;
            List<string> msgSource = msg.ExtractFromString("[", "]").ToList();
            if (msgSource != null)
            {
                int countSegments = msgSource.Count;
                if (countSegments == 0 || countSegments > 2)
                {
                    return "Fehler im Textsegment!!";
                }
                else if (countSegments == 1 && msgSource[0]?.Split('/').Length == 2)
                {
                    string[] segmentTextA = msgSource[0]?.Split('/') ?? [];
                    if (count == 0)
                    {
                        result = $"{segmentTextA.First()}";
                    }
                    else if (count > 0)
                    {
                        result = $"{segmentTextA.Last()}";
                    }
                }
                else if (countSegments == 1 && msgSource[0]?.Split('/').Length == 3)
                {
                    string[] segmentTextA = msgSource[0]?.Split('/') ?? [];
                    if (count == 0)
                    {
                        result = $"{segmentTextA.First()}";
                    }
                    else if (count == 1)
                    {
                        result = $"{segmentTextA[1]}";
                    }
                    else if (count > 1)
                    {
                        result = String.Format(CultureInfo.CurrentCulture, $"{segmentTextA.Last()}", count);
                    }
                }
                else if (countSegments == 2 && msgSource[0]?.Split('/').Length == 3)
                {
                    string[] segmentTextA = msgSource[0]?.Split('/') ?? [];
                    string[] segmentTextB = msgSource[1]?.Split('/') ?? [];
                    if (count == 0)
                    {
                        result = msg.Replace($"[{msgSource.First()}]", segmentTextA.First()).Replace($"[{msgSource.Last()}]", segmentTextB.First());
                    }
                    else if (count == 1)
                    {
                        result = msg.Replace($"[{msgSource.First()}]", segmentTextA[1]).Replace($"[{msgSource.Last()}]", segmentTextB[1]);
                    }
                    else if (count > 1)
                    {
                        string message = msg.Replace($"[{msgSource.First()}]", segmentTextA.Last()).Replace($"[{msgSource.Last()}]", segmentTextB.Last());
                        result = String.Format(CultureInfo.CurrentCulture, message, count);
                    }
                }
            }

            return result;
        }

        public static string Humanize(string msg, HumanizeCase humanizeCase = HumanizeCase.TitleCase)
        {
            if (humanizeCase == HumanizeCase.TitleCase)
            {
                return ToTitleCase(msg);
            }
            else if (humanizeCase == HumanizeCase.PascalCase)
            {
                return ToPascalCase(msg);
            }
            else if (humanizeCase == HumanizeCase.CamelCase)
            {
                TextInfo textInfo = new CultureInfo("de-DE").TextInfo;
                string titleCase = textInfo.ToTitleCase(msg.Replace("_", " ").ToLower());
                char[] camelCase = textInfo.ToTitleCase(titleCase).Replace(" ", string.Empty).ToCharArray();
                camelCase[0] = char.ToLower(camelCase[0]);
                return new string(camelCase);
            }
            else if (humanizeCase == HumanizeCase.SnakeCase)
            {
                return ToSnakeCase(msg);
            }
            else if (humanizeCase == HumanizeCase.KebabCase)
            {
                return ToKebabCase(msg);
            }

            return msg;
        }

        public static string ToWord(long number)
        {
            return NumberToWord.InWorten(number);
        }

        public static string ToWord(decimal number, string decimalSeparator = ",")
        {
            return NumberToWord.InWorten(number, decimalSeparator);
        }

        public static string ToWord(double number, string decimalSeparator = ",")
        {
            return NumberToWord.InWorten(Convert.ToDecimal(number), decimalSeparator);
        }

        public static string ToTimeText(DateTime currentTime)
        {
            return TimeFormatter.TimeDiffToText(currentTime);
        }

        private static string ToPascalCase(string original)
        {
            if (string.IsNullOrEmpty(original) == true)
            {
                throw new ArgumentNullException(nameof(original));
            }

            Regex invalidCharsRgx = new Regex("[^_a-zA-Z0-9]");
            Regex whiteSpace = new Regex(@"(?<=\s)");
            Regex startsWithLowerCaseChar = new Regex("^[a-z]");
            Regex firstCharFollowedByUpperCasesOnly = new Regex("(?<=[A-Z])[A-Z0-9]+$");
            Regex lowerCaseNextToNumber = new Regex("(?<=[0-9])[a-z]");
            Regex upperCaseInside = new Regex("(?<=[A-Z])[A-Z]+?((?=[A-Z][a-z])|(?=[0-9]))");

            var pascalCase = invalidCharsRgx.Replace(whiteSpace.Replace(original, "_"), string.Empty)
                .Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(w => startsWithLowerCaseChar.Replace(w, m => m.Value.ToUpper()))
                .Select(w => firstCharFollowedByUpperCasesOnly.Replace(w, m => m.Value.ToLower()))
                .Select(w => lowerCaseNextToNumber.Replace(w, m => m.Value.ToUpper()))
                .Select(w => upperCaseInside.Replace(w, m => m.Value.ToLower()));

            return string.Concat(pascalCase);
        }

        private static string ToTitleCase(string original)
        {
            if (string.IsNullOrEmpty(original) == true)
            {
                throw new ArgumentNullException(nameof(original));
            }

            TextInfo cultureInfo = new CultureInfo("de-DE").TextInfo;
            return cultureInfo.ToTitleCase(original.Replace("_", " ").ToLower());
        }

        private static string ToCamelCase(string original)
        {
            if (string.IsNullOrEmpty(original) == true)
            {
                throw new ArgumentNullException(nameof(original));
            }

            TextInfo textInfo = new CultureInfo("de-DE").TextInfo;
            string titleCase = textInfo.ToTitleCase(original.Replace("_", " ").ToLower());
            char[] camelCase = textInfo.ToTitleCase(titleCase).Replace(" ", string.Empty).ToCharArray();
            camelCase[0] = char.ToLower(camelCase[0]);
            return new string(camelCase);
        }

        public static string ToSnakeCase(string original)
        {
            if (string.IsNullOrEmpty(original) == true)
            {
                throw new ArgumentNullException(nameof(original));
            }

            if (original.Length < 2)
            {
                return original.ToLowerInvariant();
            }

            var builder = new StringBuilder(original.Length + Math.Min(2, original.Length / 5));
            var previousCategory = default(UnicodeCategory?);

            for (var currentIndex = 0; currentIndex < original.Length; currentIndex++)
            {
                var currentChar = original[currentIndex];
                if (currentChar == '_')
                {
                    builder.Append('_');
                    previousCategory = null;
                    continue;
                }

                var currentCategory = char.GetUnicodeCategory(currentChar);
                switch (currentCategory)
                {
                    case UnicodeCategory.UppercaseLetter:
                    case UnicodeCategory.TitlecaseLetter:
                        if (previousCategory == UnicodeCategory.SpaceSeparator ||
                            previousCategory == UnicodeCategory.LowercaseLetter ||
                            previousCategory != UnicodeCategory.DecimalDigitNumber &&
                            previousCategory != null &&
                            currentIndex > 0 &&
                            currentIndex + 1 < original.Length &&
                            char.IsLower(original[currentIndex + 1]))
                        {
                            builder.Append('_');
                        }

                        currentChar = char.ToLower(currentChar, CultureInfo.InvariantCulture);
                        break;

                    case UnicodeCategory.LowercaseLetter:
                    case UnicodeCategory.DecimalDigitNumber:
                        if (previousCategory == UnicodeCategory.SpaceSeparator)
                        {
                            builder.Append('_');
                        }
                        break;

                    default:
                        if (previousCategory != null)
                        {
                            previousCategory = UnicodeCategory.SpaceSeparator;
                        }
                        continue;
                }

                builder.Append(currentChar);
                previousCategory = currentCategory;
            }

            return builder.ToString();
        }

        private static string ToKebabCase(string original)
        {
            if (string.IsNullOrEmpty(original) == true)
            {
                throw new ArgumentNullException(nameof(original));
            }

            // finde and ersetze alle Teile, die mit einem Großbuchstaben starten (z.B. Net)
            original = Regex.Replace(original, "[A-Z][a-z]+", m => $"-{m.ToString().ToLower()}");

            // finde and ersetze alle Teile, die nur aus Großbuchstaben bestehen (z.B. NET)
            original = Regex.Replace(original, "[A-Z]+", m => $"-{m.ToString().ToLower()}");

            // Ersetze alle Nicht-Alphanummerischen Zeichen mit einem Dash (z.B. $%)
            original = Regex.Replace(original, @"[^0-9a-zA-Z]", "-");

            // Ersetze alle mehrfach hintereinander vorkommenden Dashes durch einen einzelnen Dash (z.B. ---)
            original = Regex.Replace(original, @"[-]{2,}", "-");

            // Entferne alle Dashes am Ende
            original = Regex.Replace(original, @"-+$", string.Empty);

            // Entferne alle Dashes am Anfang
            if (original.StartsWith("-")) original = original.Substring(1);

            // Lowercase und return
            return original.ToLower();
        }
    }

    public enum HumanizeCase
    {
        PascalCase,
        CamelCase,
        SnakeCase,
        KebabCase,
        TitleCase,
    }

    internal class NumberToWord
    {
        private static readonly string[] Einheiten = { "null", "eins", "zwei", "drei", "vier", "fünf", "sechs", "sieben", "acht", "neun",
          "zehn", "elf", "zwölf", "dreizehn", "vierzehn", "fünfzehn", "sechzehn", "siebzehn", "achtzehn", "neunzehn" };

        private static readonly string[] Zehner = { "", "", "zwanzig", "dreißig", "vierzig", "fünfzig", "sechzig", "siebzig", "achtzig", "neunzig" };

        internal static string InWorten(decimal zahl, string decimalSeparator = ",")
        {
            int ganz = (int)Math.Floor(zahl);
            int nachkomma = (int)((zahl - ganz) * 100);

            string ergebnis = FirstCharUpper(NumberToText(ganz));

            if (nachkomma > 0)
            {
                ergebnis += $"{decimalSeparator}{nachkomma}";
            }

            return ergebnis;
        }

        private static string NumberToText(int zahl)
        {
            if (zahl == 0)
            {
                return "null";
            }

            if (zahl < 0)
            {
                return $"minus {NumberToText(-zahl)}";
            }

            string worte = "";

            if (zahl >= 1000000)
            {
                int millionen = zahl / 1000000;
                worte += NumberToText(millionen) + (millionen == 1 ? " Million " : " Millionen ");
                zahl %= 1000000;
            }

            if (zahl >= 1000)
            {
                int tausend = zahl / 1000;
                worte += (tausend == 1 ? "eintausend" : $"{NumberToText(tausend)}tausend");
                zahl %= 1000;
            }

            if (zahl >= 100)
            {
                int hunderter = zahl / 100;
                string einhundert = Einheiten[hunderter].Substring(0,Einheiten[hunderter].Length -1);
                worte += $"{einhundert}hundert";
                zahl %= 100;
            }

            if (zahl > 0)
            {
                if (zahl < 20)
                    worte += Einheiten[zahl];
                else
                {
                    int z = zahl / 10;
                    int e = zahl % 10;
                    if (e > 0)
                    {
                        worte += $"{Einheiten[e]}und{Zehner[z]}";
                    }
                    else
                    {
                        worte += Zehner[z];
                    }
                }
            }

            return worte;
        }

        private static string FirstCharUpper(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            return $"{char.ToUpper(text[0])}{text.Substring(1)}";
        }
    }

    internal class TimeFormatter
    {
        internal static string TimeDiffToText(DateTime vergangen)
        {
            TimeSpan differenz = DateTime.Now - vergangen;

            if (differenz.TotalSeconds < 60)
            {
                return "Vor wenigen Sekunden";
            }
            else if (differenz.TotalMinutes < 1)
            {
                return "Vor weniger als einer Minute";
            }
            else if (differenz.TotalMinutes < 5)
            {
                return "Vor wenigen Minuten";
            }
            else if (differenz.TotalMinutes < 60)
            {
                return $"Vor {Math.Floor(differenz.TotalMinutes)} Minuten";
            }
            else if (differenz.TotalHours < 24)
            {
                return $"Vor {Math.Floor(differenz.TotalHours)} Stunden";
            }
            else if (differenz.TotalDays < 30)
            {
                return $"Vor {Math.Floor(differenz.TotalDays)} Tagen";
            }
            else if (differenz.TotalDays < 365)
            {
                int monate = (int)(differenz.TotalDays / 30);
                return $"Vor {monate} Monaten";
            }
            else
            {
                int jahre = (int)(differenz.TotalDays / 365);
                return $"Vor {jahre} Jahren";
            }
        }
    }

    internal static class StringExtractExtensions
    {
        public static IEnumerable<string> ExtractFromString(this string @this, string startString, string endString)
        {
            if (@this == null || startString == null || endString == null)
            {
                yield return null;
            }

            Regex r = new Regex(Regex.Escape(startString!) + "(.*?)" + Regex.Escape(endString!));
            MatchCollection matches = r.Matches(@this!);
            foreach (Match match in matches)
            {
                yield return match.Groups[1].Value;
            }
        }

        public static T[] ExtractContent<T>(this string @this, string regPattern)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(T));
            if (tc.CanConvertFrom(typeof(string)) == false)
            {
                throw new ArgumentException("Type does not have a TypeConverter from string", "T");
            }

            if (string.IsNullOrEmpty(@this) == false)
            {
                return Regex.Matches(@this, regPattern)
                    .Cast<Match>()
                    .Select(f => f.ToString())
                    .Select(f => (T)tc.ConvertFrom(f))
                    .ToArray();
            }
            else
            {
                return [];
            }
        }

        public static int[] ExtractInts(this string @this)
        {
            return @this.ExtractContent<int>(@"\d+");
        }
    }
}
