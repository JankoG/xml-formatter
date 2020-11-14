using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace copy
{

    class Program
    {
        static Regex r = new Regex(@"<");
        static Regex x = new Regex(@">");
        static string first(Match m)
        {
            return "&it;";
        }
        static string second(Match m)
        {
            return "&gt;";
        }
        static string changeMsg()
        {
            string s="";
            s = Clipboard.GetText();

            if (s.Substring(0, 5) == "<?xml")
            {
                s=r.Replace(s, new MatchEvaluator(Program.first));
                s=x.Replace(s, new MatchEvaluator(Program.second));

                Clipboard.SetText(s);
                Console.WriteLine("text swapped");
            }
            return s;
        }
        [STAThread]
        static void Main(string[] args)
        {
            string s = Clipboard.GetText();
            while (true)
            {
                s=changeMsg();
                while (true)
                {
                    try
                    {
                        if (s != Clipboard.GetText()) break;
                    }
                    catch {
                        Console.WriteLine("clipboard in use, wait");
                    }
                    System.Threading.Thread.Sleep(1000);
                    continue;
                }
            }
        }
    }




}
