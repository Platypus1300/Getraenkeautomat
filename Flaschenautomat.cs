using System;

namespace HelloWorld
{
    


    class Hello
    {   
        
        
        public static double Guthaben = 0;

        public static int num_Getraenk = 0;

        public static string[] Namen = new string[20];
        public static int[] Anzahl = new int[20];
        public static double[] Preis = new double[20];
        

        static int function() {
            return 3;
        }

        static int ErstesLeeresFach() {
            for(int i = 0; i < 20; ++i) {
                if(Namen[i] == null ) return i;
            }
            Console.WriteLine("ERROR");
            return 20;
        }

        static int Zuordnen(string eing) {
            if(eing.Length >= 4) {
            if(eing.Substring(0,4) == "buy ") return 3;
            }
            if(eing.Length >= 11) {
                if(eing.Substring(0,11) == "insertEuro ") return 1;
                if(eing.Length >= 15) {
                if(eing.Substring(0,15) == "insertGetraenk ") return 2;
                }   
            }

            Console.WriteLine("Falsche Eingabe");
            return 0;

            
            
        }

        static double fragPreis() {

            while(1 == 1) {
                Console.WriteLine("Was Preis???(nur Zahl eingeben!!!!!)");
                string ans = Console.ReadLine();
                double Preis = 0;
                if(Double.TryParse(ans, out Preis)) {
                    return Preis;
                    break;
                }else
                {
                    Console.WriteLine("Falsche Eingabe");
                }
            }
            return 0;

        }

        static void GebGeld(string name) {

            Console.WriteLine(Guthaben);    


            int[] Einteilung = new int[5];
            while(Guthaben > 0) {
                while(Guthaben >= 2) {
                    Einteilung[0]++;
                    Guthaben -= 2;
                    Guthaben = Math.Round(Guthaben, 2);
                }
                while(Guthaben >= 1) {
                    Einteilung[1]++;
                    Guthaben -= 1;
                    Guthaben = Math.Round(Guthaben, 2);
                }
                while(Guthaben >= 0.5) {
                    Einteilung[2]++;
                    Guthaben -= 0.5;
                    Guthaben = Math.Round(Guthaben, 2);
                }
                while(Guthaben >= 0.2) {
                    Einteilung[3]++;
                    Guthaben -= 0.2;
                    Guthaben = Math.Round(Guthaben, 2);
                }
                while(Guthaben >= 0.1) {
                    Einteilung[4]++;
                    Guthaben -= 0.1;
                    Guthaben = Math.Round(Guthaben, 2);
                }
            }
            Guthaben = 0;
            Console.WriteLine("Du bekommst eine " + name + ",Rückgeld ist: " + Einteilung[0] + "x2€" + Einteilung[1] + "x1€" + Einteilung[2] + "x0.50€" + Einteilung[3]
            + "x0.20€" + Einteilung[4] + "x0.10€");
            
        }

        static void insertEuro(string eing) {

            if(eing[11] > 47 && eing[11] < 58) {

                //double einzug = Double.Parse(eing.Substring(11));

                double einzug = 0;

                if(Double.TryParse(eing.Substring(11), out einzug)) {

                    if(einzug == 0.1 || einzug == 0.2 || einzug == 0.5 || einzug == 1 || einzug == 2){
                        
                        Guthaben += einzug;
                        Console.WriteLine(einzug + "€ eingeworfen, dein Guthaben beträgt" + Guthaben + "€");

                    }else{
                        Console.WriteLine("Keine Münze");
                    }

                }else{
                    Console.WriteLine("Keine Münze");
                }

                Console.WriteLine(einzug);

            }else{
                Console.WriteLine("Keine Münze");
            }
            
        }

        static void insertGetraenk(string eing) {

            if(eing.Length > 14) {
                
                string name = eing.Substring(15);
                Console.WriteLine(name);

                int index = 21;

                for(int i = 0; i < 20; ++i) {
                    if(Namen[i] == name) {
                        index = i;
                        break;
                    }
                }
                    if(index == 21) {
                        if(num_Getraenk < 20) {
                            int n = ErstesLeeresFach();
                            Namen[n] = name;
                            Preis[n] = fragPreis();
                            Anzahl[n]++; 
                            Console.WriteLine(name + " wurde in den Automaten gelegt, Anzahl " + name + ": " + Anzahl[n]);
                            n++;
                        }
                        else
                        {
                            Console.WriteLine("Alle Fächer sind belegt!");
                        }
                    }else
                    {
                        if(Anzahl[index] < 50) {
                            Anzahl[index]++;
                            Console.WriteLine(name + " wurde in den Automaten gelegt, Anzahl " + name + ": " + Anzahl[index]);
                        }
                        else
                        {
                            Console.WriteLine("Automat ist voll!");
                        }
                    }

            }else
            {
                Console.WriteLine("Falsche Eingabe!");
            }

        }

        static void buy(string eing) {
            string name = eing.Substring(4);
            Console.WriteLine(name);

            int index = 21;

            for(int i = 0; i <= num_Getraenk; ++i) {
                if(Namen[i] == name) {
                    index = i;
                    break;
                }
            }
            if(index == 21) Console.WriteLine("Gibts nicht!");
            else
            {
                if(Guthaben < Preis[index] || Anzahl[index] < 1) Console.WriteLine("Zu teuer");
                else
                {
                    Guthaben -= Preis[index];
                    Anzahl[index]--;
                    GebGeld(name);   
                    if(Anzahl[index] < 1) {
                        Namen[index] = null;
                        Anzahl[index] = 0;
                        Preis[index] = 0;
                        num_Getraenk--;
                    }
                }

            }


        }

        static void Main(string[] args)
        {
            Console.WriteLine(Namen[0]);
            if(Namen[0] == null) Console.WriteLine("Ja");
            else Console.WriteLine("Nein");

            while(1 == 1) {

                string eing = Console.ReadLine();
                Console.WriteLine(Zuordnen(eing));
                int einordnung = Zuordnen(eing);
                if(einordnung == 1) insertEuro(eing);
                if(einordnung == 2) insertGetraenk(eing);
                if(einordnung == 3) buy(eing);

            }
            

        }


    }
}