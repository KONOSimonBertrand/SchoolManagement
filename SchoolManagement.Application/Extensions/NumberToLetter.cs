

using System.Text;
using static SchoolManagement.Application.Extensions.NumberToLetter;

namespace SchoolManagement.Application.Extensions
{
    public static class NumberToLetterExtension
    {
        /// <summary>
        /// Méthode d'extension de la classe double écrivant le nombre en lettres
        /// </summary>
        /// <param name="Nombre">Nombre à écrire</param>
        /// <param name="Language">La langue utilisé FR pour le français et EN pour l'anglais</param>
        /// <param name="TheCurrency">Devise à utliser</param>
        /// <returns></returns>
        public static string ToLetter(this double Number, CountryLanguage Language, Currency TheCurrency)
        {
            var numberToLetter = new NumberToLetter();
            return numberToLetter.ToLetter((int)Number,Language, TheCurrency);
        }
    }
    internal class NumberToLetter
    {
        private Dictionary<int, string> textStrings = new Dictionary<int, string>();
        private Dictionary<int, string> scales = new Dictionary<int, string>();
        private StringBuilder builder;

        public NumberToLetter()
        {
            Initialize();
        }

        public string ToLetter(int number, CountryLanguage language,Currency currency)
        {
            if(language==CountryLanguage.English)
            return GetEnglishVersion(number,currency);
            else 
                return GetFrenchVersion(number,currency);
        }
        private string GetEnglishVersion(int number, Currency theCurrency)
        {
            builder = new StringBuilder();

            if (number == 0)
            {
                builder.Append(textStrings[number]);
                return builder.ToString();
            }

            number = scales.Aggregate(number, (current, scale) => Append(current, scale.Key));
            AppendLessThanOneThousand(number);
            switch (theCurrency)
            {
                case Currency.CFA:
                    return builder.ToString().Trim() + " CFA";
                case Currency.Dollar:
                    return builder.ToString().Trim() + " $";
                case Currency.Euro:
                    return builder.ToString().Trim() + " €";
               default: return builder.ToString();
            }
            
        }

        private int Append(int num, int scale)
        {
            if (num > scale - 1)
            {
                var baseScale = ((int)(num / scale));
                AppendLessThanOneThousand(baseScale);
                builder.AppendFormat("{0} ", scales[scale]);
                num = num - (baseScale * scale);
            }
            return num;
        }

        private int AppendLessThanOneThousand(int num)
        {
            num = AppendHundreds(num);
            num = AppendTens(num);
            AppendUnits(num);
            return num;
        }

        private void AppendUnits(int num)
        {
            if (num > 0)
            {
                builder.AppendFormat("{0} ", textStrings[num]);
            }
        }

        private int AppendTens(int num)
        {
            if (num > 20)
            {
                var tens = ((int)(num / 10)) * 10;
                builder.AppendFormat("{0} ", textStrings[tens]);
                num = num - tens;
            }
            return num;
        }

        private int AppendHundreds(int num)
        {
            if (num > 99)
            {
                var hundreds = ((int)(num / 100));
                builder.AppendFormat("{0} hundred ", textStrings[hundreds]);
                num = num - (hundreds * 100);
            }
            return num;
        }
        private void Initialize()
        {
            textStrings.Add(0, "zero");
            textStrings.Add(1, "one");
            textStrings.Add(2, "two");
            textStrings.Add(3, "three");
            textStrings.Add(4, "four");
            textStrings.Add(5, "five");
            textStrings.Add(6, "six");
            textStrings.Add(7, "seven");
            textStrings.Add(8, "eight");
            textStrings.Add(9, "nine");
            textStrings.Add(10, "ten");
            textStrings.Add(11, "eleven");
            textStrings.Add(12, "twelve");
            textStrings.Add(13, "thirteen");
            textStrings.Add(14, "fourteen");
            textStrings.Add(15, "fifteen");
            textStrings.Add(16, "sixteen");
            textStrings.Add(17, "seventeen");
            textStrings.Add(18, "eighteen");
            textStrings.Add(19, "nineteen");
            textStrings.Add(20, "twenty");
            textStrings.Add(30, "thirty");
            textStrings.Add(40, "forty");
            textStrings.Add(50, "fifty");
            textStrings.Add(60, "sixty");
            textStrings.Add(70, "seventy");
            textStrings.Add(80, "eighty");
            textStrings.Add(90, "ninety");
            textStrings.Add(100, "hundred");

            scales.Add(1000000000, "billion");
            scales.Add(1000000, "million");
            scales.Add(1000, "thousand");
        }

        private string[] firstSixteenNumbers = { "zéro", "un", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf", "dix", "onze", "douze", "treize", "quatorze", "quinze", "seize" };

        private  string[] tensNumbers = { "rien", "dix", "vingt", "trente", "quarante", "cinquante", "soixante", "soixante", "quatre-vingt", "quatre-vingt" };

        private  List<string> result;
        private string GetFrenchVersion(int number,Currency theCurrency)
        {
            result = new List<string>();

            switch (Math.Sign(number))
            {
                case -1:
                    result.Add("moins ");
                    number *= -1;
                    break;
                case 0:
                    return firstSixteenNumbers[0];
            }

            if (number >= 1e16)
                return "Nombre trop grand";


            Int64 intPart = (Int64)(number);
            double decimalPart = number - intPart;

            string[] thousands = { "", "mille", "million", "milliard", "billion", "billiard" };

            if (intPart > 0)
            {
                List<int> threeDigits = new List<int>();//liste qui scinde la partie entière en morceaux de 3 chiffres

                while (intPart > 0)
                {
                    threeDigits.Add((int)(intPart % 1000));
                    intPart /= 1000;
                }

                double reste = number - intPart;

                for (int i = threeDigits.Count - 1; i >= 0; i--)
                {
                    int nombre = threeDigits[i];

                    if (nombre > 1)//valeurs de milliers au pluriel
                    {
                        result.Add(WriteThreeDigits(threeDigits[i], i == 0));
                        if (i > 1)// mille est invariable et "" ne prend pas de s 
                            result.Add(thousands[i] + "s");
                        else if (i == 1)
                            result.Add(thousands[i]);
                    }
                    else if (nombre == 1)
                    {
                        if (i != 1) result.Add("un");//on dit un million, mais pas un mille
                        result.Add(thousands[i]);
                    }
                    //on ne traite pas le 0, car on ne dit pas X millions zéro mille Y.
                }
            }
            else
                result.Add(firstSixteenNumbers[0]);

            switch (theCurrency)
            {
                case Currency.CFA:
                    result.Add("CFA");
                    break;
                case Currency.Dollar:
                    result.Add("$");
                    break;

                case Currency.Euro:
                    result.Add("€");
                    break;              
            }

            if (theCurrency != Currency.No)
            {
                decimalPart = Math.Round(decimalPart, 2);
                if (decimalPart != 0)
                {
                    result.Add("et");
                    result.Add(WriteTwoDigits((int)(decimalPart * 100)));
                    result.Add("centimes");
                }
            }
            else
            {
                thousands = new[] { "millième", "millionième", "milliardième" };

                //avec l'imprécision des nombres à virgules flotantes,  1234562.789 - 1234562 donne 0.78900000010617077 il faut donc compter le nombre de chiffres décimaux du nombre original et arrondir le resultat de la soustraction 
                string[] morceaux = number.ToString("G25").Split(new[] { '.', ',' });//par défaut ToString arrondi à 10^-8, le format G25 oblige à écrire 25 caractères s'ils sont présents soit (au pire) 15 avant la virgule, la virgule et 9 après, split permet de découper le string obtenu

                if (morceaux.Length == 2)//il y a une partie décimale
                {
                    result.Add("et");

                    int lenghtPartieDecimale = morceaux[1].Length;
                    if (lenghtPartieDecimale > 9)
                        lenghtPartieDecimale = 9;//on se limite à 10^-9

                    decimalPart = Math.Round(decimalPart, lenghtPartieDecimale);

                    int i = 0;
                    while (decimalPart > 0)
                    {
                        decimalPart = decimalPart * 1000;
                        int valeur = (int)decimalPart;
                        lenghtPartieDecimale -= 3;
                        if (lenghtPartieDecimale < 0)
                            lenghtPartieDecimale = 0;
                        decimalPart = Math.Round(decimalPart - valeur, lenghtPartieDecimale);

                        if (valeur != 0)
                        {
                            result.Add(WriteThreeDigits(valeur, false));
                            if (valeur > 1)
                                result.Add(thousands[i++] + "s");
                            else
                                result.Add(thousands[i++]);

                        }
                    }


                }
            }

            return string.Join(" ", result);
        }
        private string WriteThreeDigits(int number, bool ruleOfHundred)
        {
            if (number == 100)
                return "cent";

            if (number < 100)
                return WriteTwoDigits(number);

            int centaine = number / 100;
            int reste = number % 100;

            if (reste == 0)
                if (ruleOfHundred)//Cent prend un s quand il est multiplié et non suivi d'un nombre, comme le cas de 100 est déjà traité on est face à un multiple
                    return firstSixteenNumbers[centaine] + " cents";
                else
                    return firstSixteenNumbers[centaine] + " cent";// par contre s'il est suivi de mille, millions, millièmes etc... pas de s

            if (centaine == 1)
                return "cent " + WriteTwoDigits(reste);//on ne dit pas un cent X, mais cent X

            return firstSixteenNumbers[centaine] + " cent " + WriteTwoDigits(reste);
        }
        private  string WriteTwoDigits(int Number)
        {

            if (Number < 17)
                return firstSixteenNumbers[Number];

            switch (Number)//cas particuliers de 71, 80 et 81
            {
                case 71:// au Cameroun et en France 71 prend un et
                    return "soixante et onze";
                case 80://au Cameroun et en France le vingt prend un s
                    return tensNumbers[8] + "s";
                case 81:// au Cameroun et en France il n'y a pas de et
                    return tensNumbers[8] + "-un";
            }

            int tens = Number / 10;
            int unit = Number % 10;

            string theTens = tensNumbers[tens];

            if (tens == 7 || tens == 9)
            {
                tens--;
                unit += 10;
            }


            switch (unit)
            {
                case 0:
                    return theTens;

                case 1:
                    return theTens + " et un";

                case 17://pour 77 à 79 et 97 à 99
                case 18:
                case 19:
                    unit = unit % 10;
                    return theTens + "-dix-" + firstSixteenNumbers[unit];

                default:
                    return theTens + "-" + firstSixteenNumbers[unit];
            }
        }

    }
    public enum CountryLanguage
    {
       French,
       English
    }

    public enum Currency
    {
        No,
        CFA,
        Euro,
        FrancSuisse,
        Dollar
    }
}
