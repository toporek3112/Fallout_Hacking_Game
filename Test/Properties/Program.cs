using System;


namespace PasswortRaten
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "GetThePassword";

            Console.ForegroundColor = ConsoleColor.Green;

            ScreenOptions a = new ScreenOptions();
            a.StartScreen();
             
            string Eingabe = "";
            int Versuche = 5;
            int x = 0;
            bool erraten = false;

            while (erraten == false)
            {
                Eingabe = Console.ReadLine();

                if (Eingabe.ToUpper() == a.password)
                {
                    erraten = true;
                    a.GameWon();
                    Environment.Exit(0);
                }
                if (Eingabe == "karol ist der beste")
                {
                    a.write_new_v2(Versuche, Eingabe);
                }
                else
                {   
                    Versuche--;

                    if (Versuche == 0)
                    {
                        a.GameOver();
                        Environment.Exit(0);
                    }

                    a.write_new(Versuche, Eingabe);
                }
                

            }

           

            Console.ReadKey();
        }

    }
}
