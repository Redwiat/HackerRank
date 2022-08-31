//#define Test
class Solution
{
    private static readonly Dictionary<int, string> TranslateNumber = new Dictionary<int, string>()
    {
        {1000,"M" },
        {900,"CM" },
        {500,"D" },
        {400,"CD" },
        {100,"C" },
        {90,"XC" },
        {50,"L" },
        {40,"XL" },
        {10,"X" },
        {9,"IX" },
        {5,"V" },
        {4,"IV" },
        {1,"I" },
    };

    private static Dictionary<char, int> TranslateChar = new Dictionary<char, int>()
    {
        {'I',1 },
        {'V',5 },
        {'X' ,10},
        {'L' ,50},
        {'C', 100 },
        {'D', 500 },
        {'M' ,1000}
    };
    private static Dictionary<string, int> TranslateString = new Dictionary<string, int>()
    {
        {"CM",900},
        {"CD",400 },
        {"XC" ,90},
        {"XL" ,40},
        {"IX", 9 },
        {"IV", 4 }
    };


    private static string GetRomanTextFromValue(int numberAsValue)
    {
        var result = string.Empty;
        foreach (var item in TranslateNumber)
        {
            while (numberAsValue>=item.Key)
            {
                numberAsValue -= item.Key;
                result +=item.Value;
            }
        }

        return result;
    }

    private static int GetValueFromRomanNumberText(string numberAsRomanText)
    {
        var total = 0;
        foreach (var item in TranslateString)
        {
            if (numberAsRomanText.Contains(item.Key))
            {
                total+=item.Value;
                numberAsRomanText = numberAsRomanText.Replace(item.Key,string.Empty);
            }
        }

        var splitByChar = numberAsRomanText.ToCharArray();
        foreach (var item in splitByChar)
            total += TranslateChar[item];

        return total;
    }

    private static string SimplifiedVersion(string numberAsRomanText)
    {
        var numberAsValue = GetValueFromRomanNumberText(numberAsRomanText);

        return GetRomanTextFromValue(numberAsValue);
    }

    static void Main(String[] args)
    {
#if Test
        Console.WriteLine(SimplifiedVersion("IIIII"));
        Console.WriteLine(SimplifiedVersion("VVVVVVVVV"));
        Console.WriteLine(SimplifiedVersion("MMMMMMMMMMMMMIIII"));
        Console.WriteLine(SimplifiedVersion("LLLXXXXX"));
        Console.WriteLine(SimplifiedVersion("CCXX"));
        Console.WriteLine(SimplifiedVersion("VVVI"));
        Console.WriteLine(SimplifiedVersion("CMXCIX"));
        Console.ReadLine();
#else
        int numberOfProblemsToSolve = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < numberOfProblemsToSolve; i++)
        {
            var numberAsRoman = Console.ReadLine()!;
            Console.WriteLine(SimplifiedVersion(numberAsRoman));
        }
#endif
    }
}
