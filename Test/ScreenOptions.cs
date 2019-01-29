using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PasswortRaten
{
    class ScreenOptions
    {

        int l = 0;
        List<Wort> AllWords = new List<Wort>();
        List<Wort> RandomWords = new List<Wort>();
        List<Wort> ArrayAusgabe = new List<Wort>();
        List<int> RandomArray = new List<int>();
        public string password = "";
        int t = 0;
        int k = 3;
        int likeness = 0;
        int count = 3;
        public string[] temp = new string[20];



        /////////////////////////////////////////////////////////////////////
        //////////////////////////  Start Ausgabe  //////////////////////////
        /////////////////////////////////////////////////////////////////////
        public void StartScreen()
        {
            StreamReader sr = new StreamReader("StartScreenv2.txt");
            string s = sr.ReadLine();
            int a = 0;

            while (s != null)
            {
                string[] Line = s.Split(';');

                if (a == 4)
                {
                    if (Console.ReadKey(true).Key == ConsoleKey.N)
                        Environment.Exit(0);  
                }

                if (Line[0] == "y")
                    Console.WriteLine();
                else
                {
                    Write(Line[1]);
                    temp[t] = Line[1];
                    t++;
                }
                    

                a++;
                s = sr.ReadLine();
            }

            SecondScreen();
        }



        /////////////////////////////////////////////////////////////////////
        //////////////////////////  Second Ausgabe  /////////////////////////
        /////////////////////////////////////////////////////////////////////
        public void SecondScreen()
        {
            Random r = new Random();
            int ra = 0;

            StreamReader sr = new StreamReader("Words.txt");
            string s = sr.ReadLine();


            //////////////////Alle Wörter auslesen//////////////////
            for (int i = 0; i < 200; i++)
            {
                Wort a = new Wort(s.ToUpper());
                AllWords.Add(a);
                s = sr.ReadLine();
            }


            ////////////////Random Wörter auswählen//////////////////
            for (int i = 0; i < 10; i++)
            {
                ra = no_double_numbers(199);

                RandomWords.Add(AllWords[ra]);
            }

            ////////////////////Password setzen/////////////////////
            password = RandomWords[r.Next(0, 9)].Name;


            //////////////////Zeilen rausschreiben//////////////////
            PrintLine();

            Console.WriteLine("");
            Console.Write("> ");
            

        }


        /////////////////////////////////////////////////////////////////////
        /////////////////////////  Verloren Ausgabe  ////////////////////////
        /////////////////////////////////////////////////////////////////////
        public void GameOver()
        {
            Console.Clear();

            WriteSlow("You entert too often the wrong password");
            Console.WriteLine();
            WriteSlow("Deleting all data  "); WriteVerySlow("......");
            Console.WriteLine();
            WriteSlow("Goodbye");
            System.Threading.Thread.Sleep(500);
        }

        /////////////////////////////////////////////////////////////////////
        /////////////////////////  Gewonnen Ausgabe  ////////////////////////
        /////////////////////////////////////////////////////////////////////
        public void GameWon()
        {
            Console.Clear();

            WriteSlow("You entered the right password ");
            Console.WriteLine();
            WriteSlow("now you have unlimited access to the Data  ");
            Console.WriteLine();
            Console.WriteLine();
            WriteSlow("just click any key ");

            if (Console.ReadKey(true).Key == ConsoleKey.N)
                Environment.Exit(0);

            Console.WriteLine();
            Console.WriteLine();
            Writefast("there is no data prcccccc ");
            Writefast("caooo");
            System.Threading.Thread.Sleep(1000);
        }

        /////////////////////////////////////////////////////////////////////
        ///////////////////////////  NEW AUSGABE  ///////////////////////////
        /////////////////////////////////////////////////////////////////////
        public void write_new(int Versuche, string Eingabe)
        {

            likeness_Ausgabe(Eingabe);
            
            Wort v1 = new Wort("  " + Eingabe);
            ArrayAusgabe.Add(v1);
            Wort v2 = new Wort("  Entry denied");
            ArrayAusgabe.Add(v2);
            Wort v3 = new Wort("  likeness=" + likeness);
            ArrayAusgabe.Add(v3);

            //////////////////Schreibt verbleibende Versuche auf//////////////////
            string b = "Attempts Remaining:  ";
            int a = 0;

            for (int j = 0; j < Versuche; j++)
            {
                b += "X  ";
            }

            Console.Clear();

            
            a = temp.Length - 2 - k;

            for (int i = 0; i < temp.Length - 1; i++)
            {
                
                temp[2] = b;

                if (i == 0)
                {
                    Console.WriteLine(temp[i]);
                    Console.WriteLine();
                }
                else if(i == 2 || i == 1)
                {
                    Console.WriteLine(temp[i]);
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else if(i >= a && k != 0)
                {
                    Console.Write(temp[i]);
                    Console.WriteLine(ArrayAusgabe[i-a].Name);
                    k--; 
                }
                else
                    Console.WriteLine(temp[i]); 
            }

            count += 3;
            k = count;
            Console.Write("> ");
        }

        /////////////////////////////////////////////////////////////////////
        ///////////////////////////  NEW AUSGABE  ///////////////////////////
        /////////////////////////////////////////////////////////////////////
        public void write_new_v2(int Versuche, string Eingabe)
        {
            //////////////////Schreibt verbleibende Versuche auf//////////////////
            string b = "Attempts Remaining:  ";
            int a = 0;

            for (int j = 0; j < Versuche; j++)
            {
                b += "X  ";
            }

            Console.Clear();

            k -= 3;
            a = temp.Length - 2 - k;

            for (int i = 0; i < temp.Length - 1; i++)
            {

                temp[2] = b;

                if (i == 0)
                {
                    Console.WriteLine(temp[i]);
                    Console.WriteLine();
                }
                else if (i == 2 || i == 1)
                {
                    Console.WriteLine(temp[i]);
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else if (i >= a && k != 0)
                {
                    Console.Write(temp[i]);
                    Console.WriteLine(ArrayAusgabe[i - a].Name);
                    k--;
                }
                else
                    Console.WriteLine(temp[i]);
            }

            k = count;

            Console.Write( password + " > ");
        }


        /////////////////////////////////////////////////////////////////////
        //////////////////////////  Writes a Line   /////////////////////////
        /////////////////////////////////////////////////////////////////////
        public void PrintLine()
        {

            ////////////////////////Variablen////////////////////////
            Random r = new Random();
            string a = "";
            string b = "";
            string c = "";
            string d = "";


            /////////////////////temp aus null setzen/////////////////////
            for (int m = 0; m < RandomWords.Count; m++)
            {
                RandomWords[m].temp = 0;
            }

            RandomArray.Clear();


            for (
                int i = 0; i < 15; i++)
            {


                int random = no_double_numbers(15);

                for (int j = 0; j < 15; j++)
                {
                    b += Convert.ToChar(r.Next(33, 63));
                    c += Convert.ToChar(r.Next(33, 63));
                    d += Convert.ToChar(r.Next(33, 63));
                }


                ////////////////////Zeilen schreiben////////////////////
                if (l <= 9)
                {
                    if (random <= 4)
                    {
                        a = "0x" + r.Next(1000, 2000) + "  " + RandomWords[l].Ausgabe(RandomWords[l]) + "     0x" + r.Next(1000, 2000) + "  " + c + "     0x" + r.Next(1000, 2000) + "  " + d;
                        temp[t] = a;
                        t++;
                        l++;
                    }
                    else if (random <= 9 && random >= 4)
                    {
                        a = "0x" + r.Next(1000, 2000) + "  " + b + "     0x" + r.Next(1000, 2000) + "  " + RandomWords[l].Ausgabe(RandomWords[l]) + "     0x" + r.Next(1000, 2000) + "  " + d;
                        temp[t] = a;
                        t++;
                        l++;
                    }
                    else if (random <= 14 && random >= 9)
                    {
                        a = "0x" + r.Next(1000, 2000) + "  " + b + "     0x" + r.Next(1000, 2000) + "  " + c + "     0x" + r.Next(1000, 2000) + "  " + RandomWords[l].Ausgabe(RandomWords[l]);
                        temp[t] = a;
                        t++;
                        l++;
                    }
                    else
                    {
                        a = "0x" + r.Next(1000, 2000) + "  " + b + "     0x" + r.Next(1000, 2000) + "  " + c + "     0x" + r.Next(1000, 2000) + "  " + d;
                        temp[t] = a;
                        t++;
                    }
                        
                }
                else
                {
                    a = "0x" + r.Next(1000, 2000) + "  " + b + "     0x" + r.Next(1000, 2000) + "  " + c + "     0x" + r.Next(1000, 2000) + "  " + d;
                    temp[t] = a;
                    t++;
                }
                   

                b = "";
                c = "";
                d = "";

                Writefast(a);

            }
            
        }



        /////////////////////////////////////////////////////////////////////
        ////////////////////////// Likeness Ausgabe /////////////////////////
        /////////////////////////////////////////////////////////////////////
        public void likeness_Ausgabe(string Eingabe)
        {
            string[] ArrayPass = special_split(password);
            string[] ArrayEingabe = special_split(Eingabe.ToUpper());
            int loops = 0;
            likeness = 0;
            likeness = 0;



            if (ArrayPass.Length > ArrayEingabe.Length)
                loops = ArrayEingabe.Length;
            else
                loops = ArrayPass.Length;

            for (int i = 0; i < loops; i++)
            {
                if (ArrayEingabe[i] == ArrayPass[i])
                {
                    likeness++;
                }
            }

        }







        /////////////////////////////////////////////////////////////////////
        /////////////////////Doppelte zahlen ausschliesen////////////////////
        /////////////////////////////////////////////////////////////////////
        public int no_double_numbers(int bis)
        {


            //int[] RandomArray = new int[20];
            int temp = 0;
            Random r = new Random();


            temp = r.Next(1, bis);

            for (int j = 0; j < RandomArray.Count; j++)
            {
                if (temp == RandomArray[j])
                {
                    temp = r.Next(1, bis);
                    j = 0;
                }
            }

            RandomArray.Add(temp);
            return temp;
        }


        /////////////////////////////////////////////////////////////////////
        ////////////////////////  Special Methoden //////////////////////////
        /////////////////////////////////////////////////////////////////////
        public void Write(string x)
        {
            foreach (char letter in x)
            {
                Console.Write(letter);
                System.Threading.Thread.Sleep(15);
            }

            Console.WriteLine();
        }

        static void Writefast(string x)
        {
            foreach (char letter in x)
            {
                Console.Write(letter);
                System.Threading.Thread.Sleep(2);
            }

            Console.WriteLine();
        }

        static void WriteSlow(string x)
        {
            foreach (char letter in x)
            {
                Console.Write(letter);
                System.Threading.Thread.Sleep(80);
            }
        }

        static void WriteVerySlow(string x)
        {
            foreach (char letter in x)
            {
                Console.Write(letter);
                System.Threading.Thread.Sleep(750);
            }

            Console.WriteLine();
        }

        public void SpecialWrite(string x)
        {
            foreach (char letter in x)
            {
                Console.Write(letter);
                System.Threading.Thread.Sleep(1);
            }
            Console.WriteLine();
        }

        static string[] special_split(string x)
        {
            string[] Array = new string[x.Length];
            int i = 0;

            foreach (char letter in x)
            {
                Array[i] += Convert.ToString(letter);
                i++;
            }

            return Array;
        }
    }
}
