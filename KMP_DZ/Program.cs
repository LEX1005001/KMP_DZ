using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class KMPAlgorithm
{
    static int KMPSearch(string pattern, string text)
    {
        int m = pattern.Length;
        int n = text.Length;

        int[] lps = new int[m];
        int len = 0;
        int maxLength = 0;

        // Предобработка шаблона для построения таблицы длин префиксов-суффиксов (lps)
        ComputeLPSArray(pattern, m, lps);

        int i = 0;
        while (i < n)
        {
            if (pattern[0] == text[i])
            {
                len++;
                i++;
                maxLength = Math.Max(maxLength, len);
            }
            else
            {
                if (len != 0)
                {
                    len = lps[0];
                }
                else
                {
                    i++;
                }
            }
        }

        return maxLength;
    }

    static void ComputeLPSArray(string pattern, int m, int[] lps)
    {
        int len = 0;
        int i = 1;
        lps[0] = 0;

        while (i < m)
        {
            if (pattern[i] == pattern[len])
            {
                len++;
                lps[i] = len;
                i++;
            }
            else
            {
                if (len != 0)
                {
                    len = lps[len - 1];
                }
                else
                {
                    lps[i] = 0;
                    i++;
                }
            }
        }
    }

    static void Main()
    {
        string text = System.IO.File.ReadAllText("k7-96.txt");
        string pattern = "C";

        int maxLength = KMPSearch(pattern, text);

        Console.WriteLine("Длина самой длинной подцепочки символов 'C': " + maxLength);
        Console.ReadKey();
    }
}

