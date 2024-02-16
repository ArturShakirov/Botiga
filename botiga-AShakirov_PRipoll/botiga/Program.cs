string[] productesBotiga = {"Pomes", "Platans", "Datils", "Pinya", "Raïm", "Taronjes", "LLimones", "Prunes", "Peres", "Cireres", "Maduixes", "Kiwis"};
double[] preus = { 3.17 , 1.88 , 7.5, 5, 7,75, 1.3, 2.25, 5.5, 3, 12.20, 6.10, 5.15 };
string textOpcio, nom, liniaFitxer;
int numElementsBotiga = 12, opcio, indexProducteModificar = -1;
char valorModificar;
bool sortir = false;


do
{
    Console.Clear();
    Console.WriteLine(Menu());
    Console.WriteLine("────────────────────");
    Console.Write("Introdueix una opció: ");
    opcio = Console.ReadKey().KeyChar;

    switch (opcio)
    {
        case '0' or 'q' or 'Q':
            sortir = true;
            break;
        case '1':
            textOpcio = "Afegir producte";
            MostrarCapcelera(textOpcio);
            AfegirProducte(ref productesBotiga, ref preus, ref numElementsBotiga);
            Contador();
            break;
        case '2':
            textOpcio = "Afegir productes";
            MostrarCapcelera(textOpcio);
            AfegirProductes(ref productesBotiga, ref preus, ref numElementsBotiga);
            Contador();
            break;
        case '3':
            textOpcio = "Ampliar botiga";
            MostrarCapcelera(textOpcio);
            AmpliarBotiga(ref productesBotiga, ref preus);
            Contador();
            break;
        case '4':
            textOpcio = "Modificar preu.";
            valorModificar = 'P';
            MostrarCapcelera(textOpcio);
            Console.Write("Introdueix el nom del producte (no cal INTRO): ");
            nom = AutocompletarNoms(productesBotiga, numElementsBotiga, textOpcio);
            liniaFitxer = BuscarElementArray(nom, numElementsBotiga, productesBotiga, textOpcio, ref indexProducteModificar);
            if (liniaFitxer != "")
                Modificar(valorModificar, ref preus, ref productesBotiga, indexProducteModificar);
            Contador();
            break;
        case '5':
            textOpcio = "Modificar producte";
            valorModificar = 'N';
            MostrarCapcelera(textOpcio);
            Console.Write("Introdueix el nom del producte (no cal INTRO): ");
            nom = AutocompletarNoms(productesBotiga, numElementsBotiga, textOpcio);
            liniaFitxer = BuscarElementArray(nom, numElementsBotiga, productesBotiga, textOpcio, ref indexProducteModificar);
            if (liniaFitxer != "")
                Modificar(valorModificar, ref preus, ref productesBotiga, indexProducteModificar);
            Contador();
            break;
        case '6':
            textOpcio = "Ordenar per productes";
            MostrarCapcelera(textOpcio);
            OrdenarPerNom(productesBotiga, preus, numElementsBotiga);
            Console.WriteLine("Els productes s'han ordenat pel nom dels productes!");
            Contador();
            break;
        case '7':
            textOpcio = "Ordenar per preus";
            MostrarCapcelera(textOpcio);
            OrdenarPerPreu(productesBotiga, preus, numElementsBotiga);
            Console.WriteLine("Els productes s'han ordenat per preus!");
            Contador();
            break;
        case '8':
            textOpcio = "Mostrar productes";
            MostrarCapcelera(textOpcio);
            MostrarProductes(productesBotiga, preus);
            PremeuPerTornar();
            break;
    }

    static string Menu()
    {
        string menu;

        Console.WriteLine(Capcelera());
        menu = "\x1b[47m\x1b[30m╔════════════════════════════════╗\n" +
               "║                                ║\n" +
               "║     1. Afegir producte         ║\n" +
               "║     ----------------------     ║\n" +
               "║     2. Afegir productes        ║\n" +
               "║     ----------------------     ║\n" +
               "║     3. Ampliar botiga          ║\n" +
               "║     ----------------------     ║\n" +
               "║     4. Modificar preu          ║\n" +
               "║     ----------------------     ║\n" +
               "║     5. Modificar producte      ║\n" +
               "║     ----------------------     ║\n" +
               "║     6. Ordenar per productes   ║\n" +
               "║     ----------------------     ║\n" +
               "║     7. Ordenar per preus       ║\n" +
               "║     ----------------------     ║\n" +
               "║     8. Mostrar productes       ║\n" +
               "║                                ║\n" +
               "║     ----------------------     ║\n" +
               "║     \x1b[31mQ. SORTIR\x1b[30m                  ║\n" +
               "║                                ║\n" +
               "╚════════════════════════════════╝\n\x1b[0m";


        return menu;
    }

    static string Capcelera()
    {
        string capcelera;

        capcelera = "\x1b[47m\x1b[30m╔════════════════════════════════╗\n" +
                    "║             \x1b[31mBOTIGA\x1b[30m             ║\n" +
                    "╚════════════════════════════════╝\x1b[0m";

        return capcelera;
    }

    static string CapceleraOpcio(string textOpcio)
    {
        string capceleraOpcio, linies = "";
        int contador;

        for (contador = 0; contador < textOpcio.Length; contador++)
        {
            linies = linies + "═";
        }

        capceleraOpcio = "╔══" + linies + "══╗\n" +
                         "║  " + textOpcio + "  ║\n" +
                         "╚══" + linies + "══╝" + "\n";

        return capceleraOpcio;
    }

    static void MostrarCapcelera(string textOpcio)
    {
        Console.Clear();
        Console.WriteLine(Capcelera());
        Console.WriteLine(CapceleraOpcio(textOpcio));
    }

    static void Contador()
    {
        int contador = 2;

        Console.WriteLine("\n");
        Console.Write("Temps per tornar al menú: " + (contador + 1) + "\r");
        while (contador >= 0)
        {
            Thread.Sleep(1000);
            Console.Write("Temps per tornar al menú: " + contador + "\r");
            contador--;
        }
    }

    static void PremeuPerTornar()
    {
        char opcio;

        Console.Write("\nPremeu qualsevol tecla per tornar al menú: ");
        opcio = Console.ReadKey().KeyChar;
    }

    static void AfegirProductes(ref string[] productes, ref double[] preus, ref int numElements)
    {
        string nom;
        double preu;
        char opcio;
        bool sortir = false;

        while (!sortir)
        {
            if (numElements == productes.Length)
            {
                Console.WriteLine("Oops! La botiga està plena " + numElements + "/" + numElements);
                Console.Write("Voleu ampliar la botiga?: ");
                opcio = Console.ReadKey().KeyChar;

                if (opcio.ToString().ToUpper() == "S")
                    AmpliarBotiga(ref productes, ref preus);
                else
                    sortir = true;
            }
            else
            {
                Console.Write("\nIndica el nom del producte que voleu afegir: ");
                nom = Console.ReadLine();
                Console.Write("Indica el seu preu: ");
                preu = Convert.ToDouble(Console.ReadLine());

                productes[numElements] = nom;
                preus[numElements] = preu;

                numElements++;

                Console.Write("\nVols afegir un altre producte?: ");
                char decisiu = Console.ReadKey().KeyChar;
                Console.Write("\n");

                if (decisiu.ToString().ToUpper() == "S")
                    sortir = false;
                else
                    sortir = true;
            }
        }
    }

    static void AfegirProducte(ref string[] productes, ref double[] preus, ref int numElements)
    {
        string nom;
        double preu;
        char opcio;
        bool sortir = false;

        if (numElements == productes.Length)
        {
            Console.WriteLine("\nOops! La botiga està plena " + numElements + "/" + numElements);
            Console.Write("Voleu ampliar la botiga?: ");
            opcio = Console.ReadKey().KeyChar;

            if (opcio.ToString().ToUpper() == "S")
                AmpliarBotiga(ref productes, ref preus);
        }
        else
        {
            Console.Write("Indica el nom del producte que voleu afegir: ");
            nom = Console.ReadLine();
            Console.Write("Indica el seu preu: ");
            preu = Convert.ToDouble(Console.ReadLine());

            productes[numElements] = nom;
            preus[numElements] = preu;

            numElements++;
        }
    }

    static void AmpliarBotiga(ref string[] productes, ref double[] preus)
    {
        int numeroAfegir;

        Console.Write("\nIndica el número d'espais que vols ampliar la botiga: ");
        numeroAfegir = Convert.ToInt32(Console.ReadLine());

        string[] auxProductes = new string[productes.Length + numeroAfegir];
        double[] auxPreus = new double[preus.Length + numeroAfegir];

        for (int i = 0; i < productes.Length; i++)
        {
            auxPreus[i] = preus[i];
            auxProductes[i] = productes[i];
        }

        productes = auxProductes;
        preus = auxPreus;

        Console.WriteLine("S'ha ampliat la botiga! La capacitat a augmentat de " + (productes.Length - numeroAfegir) + " a " + productes.Length + " productes!");
    }

    static void MostrarProductes(string[] productes, double[] preus)
    {
        string botiga;

        botiga = BotigaToString(productes, preus);
        Console.WriteLine(botiga);
    }

    static string BotigaToString(string[] productes, double[] preus)
    {
        string botiga = "", linia;

        for (int i = 0; i < productes.Length && i < preus.Length; i++)
        {
            linia = "Nom producte: " + productes[i] + "\tPreu: " + preus[i] + "\n";
            botiga = botiga + linia;
        }

        return botiga;
    }

    static void Modificar(char valorModificar, ref double[] preus, ref string[] productes, int indexProducteModificar)
    {
        double nouPreu;
        string nouNom;

        if (valorModificar == 'P')
        {
            Console.Write("\n\nIndica el nou preu del producte (actual " + preus[indexProducteModificar] + "): ");
            nouPreu = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);

            preus[indexProducteModificar] = nouPreu;
        }
        else if (valorModificar == 'N')
        {
            Console.Write("\n\nIndica el nou nom del producte (actual " + productes[indexProducteModificar] + "): ");
            nouNom = Console.ReadLine();

            productes[indexProducteModificar] = nouNom;
        }

        Console.WriteLine("\nProducte actualitzat!");
        Console.WriteLine("Nom producte: " + productes[indexProducteModificar] + "\tPreu: " + preus[indexProducteModificar]);
    }
    static string AutocompletarNoms(string[] productes, int numElements, string textOpcio)
    {
        char caracterActual;
        string nom = "", opcionsPossibles = "/", linia = "";
        bool igual = false, sortida = false;
        int cont = 0;

        while (nom != opcionsPossibles && !sortida)
        {
            opcionsPossibles = "";
            caracterActual = Console.ReadKey().KeyChar;
            nom = nom + caracterActual;
            if (nom.Length == 1)
                nom = nom.ToUpper();

            for (int i = 0; i < numElements; i++)
            {
                if (productes[i] != null)
                {
                    igual = true;
                    linia = productes[i];
                }
                if (linia != "")
                {
                    for (int j = 0; j != nom.Length && igual; j++)
                    {
                        if (linia[j] != nom[j])
                            igual = false;
                    }
                    if (igual && linia != "")
                    {
                        opcionsPossibles = opcionsPossibles + linia + '/';
                        cont++;
                    }
                }
            }
            MostrarCapcelera(textOpcio);
            Console.Write("\nValor: ");
            Console.WriteLine(nom);
            if (cont == 0)
                sortida = true;
            else Console.Write("Possibles opcions: " + opcionsPossibles);
            cont = 0;
            if (!sortida)
                opcionsPossibles = opcionsPossibles.Substring(0, opcionsPossibles.IndexOf('/'));
        }
        return nom;
    }

    static string BuscarElementArray(string nom, int numElements, string[] productes, string textOpcio, ref int indexProducteModificar)
    {
        string valorArray = "";
        bool trobat = false;
        char decisiu;

        while (!trobat)
        {
            for (int i = 0; i < numElements; i++)
            {
                valorArray = productes[i];

                if (valorArray == nom)
                {
                    trobat = true;
                    indexProducteModificar = i;
                }
            }
            if (!trobat)
            {
                MostrarCapcelera(textOpcio);
                Console.Write("\nEl producte no existeix, vols introduir-ne un altre?\nIntrodueix una 'S', per introduir-ne un altre o una 'N' per no fer-ho: ");
                decisiu = Console.ReadKey().KeyChar;
                MostrarCapcelera(textOpcio);
                if (decisiu == 's' || decisiu == 'S')
                {
                    Console.Write("\nValor: ");
                    nom = AutocompletarNoms(productes, numElements, textOpcio);
                }
                else
                {
                    trobat = true;
                    valorArray = "";
                }
            }
        }
        return valorArray;
    }

    static void OrdenarPerPreu(string[] productes, double[] preus, int numElements)
    {
        int mesPetit;
        for (int volta = 0; volta < numElements - 1; volta++)
        {
                mesPetit = volta;
            for (int i = volta + 1; i < numElements; i++)
                if (preus[mesPetit] > preus[i])
                    mesPetit = i;
            if (mesPetit != volta)
            {
                double auxPreus = preus[mesPetit];
                string auxNoms = productes[mesPetit];
                preus[mesPetit] = preus[volta];
                productes[mesPetit] = productes[volta];
                preus[volta] = auxPreus;
                productes[volta] = auxNoms;
            }
        }
    }

    static void OrdenarPerNom(string[] productes, double[] preus, int numElements)
    {
        int mesPetit;
        for (int volta = 0; volta < numElements - 1; volta++)
        {
            mesPetit = volta;
            for (int i = volta + 1; i < numElements; i++)
                if (productes[mesPetit] != null && productes[mesPetit].CompareTo(productes[i]) > 0)
                    mesPetit = i;
            if (mesPetit != volta)
            {
                double auxPreus = preus[mesPetit];
                string auxNoms = productes[mesPetit];
                preus[mesPetit] = preus[volta];
                productes[mesPetit] = productes[volta];
                preus[volta] = auxPreus;
                productes[volta] = auxNoms;
            }
        }
    }

} while (!sortir);