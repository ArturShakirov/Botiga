string[] productesBotiga = { "Pomes", "Platans", "Datils", "Pinya", "Raïm", "Taronjes", "Llimones", "Prunes", "Peres", "Cireres", "Maduixes", "Kiwis" };
double[] preus = { 3.17, 1.88, 7.5, 5, 7.75, 1.3, 2.25, 5.5, 3, 12.20, 6.10, 5.15 };
string textOpcio, nom, valorArray;
int numElementsBotiga = 12, opcio, indexProducteModificar = -1, decisorRol = 0;
char valorModificar;
bool sortir = false, sortirPrincipal = false;


while (!sortirPrincipal)
{
    Console.Clear();
    Console.WriteLine("Programa que serveix tant per al botiguer com al comprador. Introdueix el num de la funcionalitat que desitjis fer servir. \n");
    Console.WriteLine(MenuInici());
    Console.WriteLine("────────────────────");
    Console.Write("\nIntrodueix el rol: ");
    decisorRol = Convert.ToInt32(Console.ReadKey().KeyChar);
    if (decisorRol == '1')
    {
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
                    sortirPrincipal = true;
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
                    valorArray = BuscarElementArray(nom, numElementsBotiga, productesBotiga, textOpcio, ref indexProducteModificar);
                    if (valorArray != "")
                        Modificar(valorModificar, ref preus, ref productesBotiga, indexProducteModificar);
                    Contador();
                    break;
                case '5':
                    textOpcio = "Modificar producte";
                    valorModificar = 'N';
                    MostrarCapcelera(textOpcio);
                    Console.Write("Introdueix el nom del producte (no cal INTRO): ");
                    nom = AutocompletarNoms(productesBotiga, numElementsBotiga, textOpcio);
                    valorArray = BuscarElementArray(nom, numElementsBotiga, productesBotiga, textOpcio, ref indexProducteModificar);
                    if (valorArray != "")
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
                case '9':
                    sortir = true;
                    break;
            }
        } while (!sortir);
    }
    else if (decisorRol == '2')
    {
        string[] productesCistella = new string[10];
        int[] quantitat = new int[10];
        int numElemCistella = 0, quantitatActual = 0, decisor = int.MinValue;
        double diners = 0;
        string producteComprar = "", tiquetCompra;
        char acabarLlista = ' ', sortirCistella;
        bool cistellaSortir = false;

        while (!cistellaSortir)
        {
            Console.Clear();
            Console.WriteLine(MenuCistella());
            Console.WriteLine("────────────────────");
            Console.Write("Introdueix una opció: ");
            decisor = Convert.ToInt32(Console.ReadLine());
            while (producteComprar == "" && decisor > 0 && decisor <= 2)
            {
                Console.Clear();
                Console.Write("Introdueix els diners dels que disposes per a fer la compra: ");
                diners = Convert.ToDouble(Console.ReadLine());
                Console.Write("Introdueix el nom del producte que vols comprar. Productes disponibles: \n");
                for (int i = 0; i < numElementsBotiga; i++)
                {//Mostra els productes que hi ha disponibles per a comprar, productes dins l'array:arrayStockProva.
                    Console.WriteLine(i + ". " + productesBotiga[i]);
                }
                producteComprar = Console.ReadLine();
                Console.Write("Quina quantitat de " + producteComprar + " vols agafar?: ");
                quantitatActual = Convert.ToInt32(Console.ReadLine());
                if (decisor == 1)
                    producteComprar = ComprarProducte(productesBotiga, preus, ref productesCistella, ref quantitat, ref quantitatActual, ref diners, numElementsBotiga, ref numElemCistella, producteComprar);
                else producteComprar = ComprarProductes(productesBotiga, preus, ref productesCistella, ref quantitat, ref quantitatActual, ref diners, numElementsBotiga, ref numElemCistella, producteComprar);
            }
            producteComprar = "";
            if (decisor == 3)
                OrdenarCistella(productesCistella, quantitat, numElemCistella);
            if (decisor == 4)
                MostrarCistella(productesCistella, quantitat, numElemCistella, productesBotiga, preus, numElementsBotiga);
            if (decisor == 5)
                tiquetCompra = CistellaToString(productesCistella, quantitat, numElemCistella, productesBotiga, preus, numElementsBotiga);
            if (decisor != 0)
            {
                Console.WriteLine("\rIntrodueix qualsevol caracter per a continuar.");
                sortirCistella = Console.ReadKey().KeyChar;
            }
            if (decisor == 0)
            {
                cistellaSortir = true;
                sortirPrincipal = true;
            }
            if (decisor == 6)
                cistellaSortir = true;

        }
    }
    else
        sortirPrincipal = true;
}

static string MenuInici()
{
    string menuInici;
    menuInici = "\x1b[47m\x1b[30m╔════════════════════════════════╗\n" +
           "║                                ║\n" +
           "║     1. Botiguer                ║\n" +
           "║     ----------------------     ║\n" +
           "║     2. Comprador               ║\n" +
           "║                                ║\n" +
           "║     ----------------------     ║\n" +
           "║     \u001b[31m0. SORTIR\u001b[30m                  ║\n" +
           "║                                ║\n" +
           "╚════════════════════════════════╝\n\x1b[0m";
    return menuInici;
}
static string MenuCistella()
{
    string menuCistella;
    Console.WriteLine(CapceleraCistella());
    menuCistella = "\x1b[47m\x1b[30m╔════════════════════════════════╗\n" +
       "║                                ║\n" +
       "║     1. Comprar un producte     ║\n" +
       "║     ----------------------     ║\n" +
       "║     2. Comprar varis productes ║\n" +
       "║     ----------------------     ║\n" +
       "║     3. Ordenar llista          ║\n" +
       "║     ----------------------     ║\n" +
       "║     4. Mostrar tiquet          ║\n" +
       "║     ----------------------     ║\n" +
       "║     5. Crear string tiquet     ║\n" +
       "║     ----------------------     ║\n" +
       "║     6. Canviar de rol          ║\n" +
       "║                                ║\n" +
       "║     ----------------------     ║\n" +
       "║     \x1b[31m0. SORTIR\x1b[30m                  ║\n" +
       "║                                ║\n" +
       "╚════════════════════════════════╝\n\x1b[0m";
    return menuCistella;
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
           "║     ----------------------     ║\n" +
           "║     9. Canviar de rol          ║\n" +
           "║                                ║\n" +
           "║     ----------------------     ║\n" +
           "║     \x1b[31mQ. SORTIR\x1b[30m                  ║\n" +
           "║                                ║\n" +
           "╚════════════════════════════════╝\n\x1b[0m";

    return menu;
}
static string CapceleraCistella()
{
    string capceleraCistella;
    capceleraCistella = "\x1b[47m\x1b[30m╔════════════════════════════════╗\n" +
            "║             \x1b[31mCISTELLA\x1b[30m           ║\n" +
            "╚════════════════════════════════╝\x1b[0m";
    return capceleraCistella;
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
        linia = "Nom producte: " + productes[i] + "\tPreu: " + preus[i] + " euros\n";
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
    Console.WriteLine("Nom producte: " + productes[indexProducteModificar] + "\tPreu: " + preus[indexProducteModificar] + " euros");
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
static string ComprarProducte(string[] arrayStockProva, double[] arrayPreuProductesProva, ref string[] productesCistella, ref int[] quantitat, ref int quantitatActual, ref double diners, int numElemBotigaProva, ref int numElemCistella, string producteComprar)
{
    Console.Clear();
    bool existeix = false, espai = false, capacitat = false;
    double preuTotal = 0, auxiliar;
    char decisiu, mesDiners;
    int ampliacio;
    for (int i = 0; i < numElemBotigaProva; i++)
    {//Recorre tot l'array i comprova si algun element coincideix amb el que ha introduit l'usuari.
        if (producteComprar == arrayStockProva[i])
        {//Si coincideix treu existeix=true i actualitza el preu total de la comanda segons el contingut de l'array: arrayPreuProductesProva
            existeix = true;
            preuTotal = arrayPreuProductesProva[i] * quantitatActual;
        }
    }
    if (!existeix)
    {//Si no ha trobat la paraula introduida dins l'array, missatge d'error i element introduit per l'usuari borrat.
        Console.WriteLine("El producte no s'ha trobat a la botiga, error.");
        producteComprar = "";
    }
    if (numElemCistella < productesCistella.Length)//Comprova si hi ha espai lliure a l'array: productesCistella.
        espai = true;
    else
    {//Si no hi ha espai, missatge d'error, pregunta si es vol ampliar cistella.
        Console.WriteLine("Cistella plena. Vols ampliar la cistella?[s/n]");
        decisiu = Console.ReadKey().KeyChar;
        if (decisiu == 's' || decisiu == 'S')
        {//Si l'usuari vol ampliar cistella pregunta en quant la vol ampliar i crida metode AmpliacioCistella().
            Console.Clear();
            Console.WriteLine("Introdueix la quantitat d'amplicació de la cistella.");
            ampliacio = Convert.ToInt32(Console.ReadLine());
            AmpliarCistella(ref productesCistella, ref quantitat, ampliacio);
        }
        else Console.WriteLine("No es pot seguir comprant sense ampliar la cistella. S'haura de repetir la comanda.");
    }
    if (preuTotal <= diners)
    {//Comprovacio de si hi ha prous diners.
        capacitat = true;
        diners = diners - preuTotal;
    }
    else
    {//Si no hi ha prous diners. Missatge d'error i demana a l'usuari si vol posar-ne mes.
        Console.WriteLine("No hi ha prous diners. Si tens mes diners per introduir, introdueix 's' o 'S', sino qualsevol altre caracter.");
        mesDiners = Convert.ToChar(Console.ReadLine());
        if (mesDiners == 's' || mesDiners == 'S')
        {//Si vol posar mes diners. Demana quants, i actualitza els diners totals.
            Console.Clear();
            Console.WriteLine("Introdueix la quantitat que vols afegir:");
            auxiliar = Convert.ToDouble(Console.ReadLine());
            diners = diners + auxiliar;
            if (preuTotal <= diners)
            {//Actualitzacio variable bool i diners menys el que costa la comanda.
                capacitat = true;
                diners = diners - preuTotal;
            }
        }
        else
        {//Si no es volen posar mes diners, missatge d'error paraulaIntroduida=""
            producteComprar = "";
            Console.WriteLine("No hi ha prous diners, refes la comanda.");
            Thread.Sleep(1000);
        }
    }
    if (producteComprar != "")
    {//En cas d'haver-hi alguna comprovacio que falli producteComprar="", per tant només es crida metode IntroduirCistella en cas de que sigui tot correcte
        IntroduirCistella(productesCistella, quantitat, ref numElemCistella, producteComprar, quantitatActual);
    }
    Thread.Sleep(1000);
    return producteComprar;
}
static void AmpliarCistella(ref string[] productesCistella, ref int[] quantitat, int ampliacio)
{
    string[] aux = new string[productesCistella.Length + ampliacio];
    int[] aux2 = new int[quantitat.Length + ampliacio];
    for (int i = 0; i < productesCistella.Length; i++)
    {
        aux[i] = productesCistella[i];
    }
    for (int i = 0; i < quantitat.Length; i++)
    {
        aux2[i] = quantitat[i];
    }
    productesCistella = aux;
    quantitat = aux2;
}
static void IntroduirCistella(string[] productesCistella, int[] quantitat, ref int numElemCistella, string producteComprar, int quantitatActual)
{
    numElemCistella++;
    for (int i = 0; i < numElemCistella; i++)
    {
        if (i + 1 == numElemCistella)
        {//Busca la posicio de l'array cistella on s'ha d'introduir el nou producte.
            productesCistella[i] = producteComprar;
            quantitat[i] = quantitatActual;
            Console.WriteLine("Els productes s'han introduit a la cistella correctament.");
        }
    }
}
static string ComprarProductes(string[] arrayStockProva, double[] arrayPreuProductesProva, ref string[] productesCistella, ref int[] quantitat, ref int quantitatActual, ref double diners, int numElemBotigaProva, ref int numElemCistella, string producteComprar)
{
    char sortida = 's';
    while (sortida != 'n' && sortida != 'N')
    {
        if (producteComprar == "")
        {
            Console.Clear();
            Console.WriteLine("Productes disponibles:");
            for (int i = 0; i < arrayStockProva.Length; i++)
            { Console.WriteLine(arrayStockProva[i]); }
            Console.WriteLine("Nom producte:");
            producteComprar = Console.ReadLine();
            Console.WriteLine("Quantitat:");
            quantitatActual = Convert.ToInt32(Console.ReadLine());
        }
        producteComprar = ComprarProducte(arrayStockProva, arrayPreuProductesProva, ref productesCistella, ref quantitat, ref quantitatActual, ref diners, numElemBotigaProva, ref numElemCistella, producteComprar);
        Console.WriteLine("Vols seguir comprant?[s/n]");
        sortida = Console.ReadKey().KeyChar;
        if (sortida != 'N' && sortida != 'n')
            producteComprar = "";
    }
    return producteComprar;
}
static void MostrarCistella(string[] productesCistella, int[] quantitat, int numElemCistella, string[] arrayStockProva, double[] arrayPreuProductesProva, int numElemBotigaProva)
{
    double preu = 0;
    char sortida;
    Console.Clear();
    Console.WriteLine("PRODUCTES QUE TENS ACTUALMENT A LA CISTELLA:");
    Console.WriteLine();
    for (int i = 0; i < numElemCistella; i++)
    {
        Console.Write("PRODUCTE: " + productesCistella[i] + "\t");
        for (int n = 0; n < numElemBotigaProva; n++)
        {
            if (productesCistella[i] == arrayStockProva[n])
                preu = arrayPreuProductesProva[n] * quantitat[i];
        }
        Console.WriteLine("QUANTITAT: " + quantitat[i] + "\tPREU: " + Math.Round(preu, 2) + " euros.");
    }
}
static string CistellaToString(string[] productesCistella, int[] quantitat, int numElemCistella, string[] arrayStockProva, double[] arrayPreuProductesProva, int numElemBotigaProva)
{
    string tiquetCompra = "";
    double preu = 0;
    char sortida;
    Console.Clear();
    Console.WriteLine();
    for (int i = 0; i < numElemCistella; i++)
    {
        if (tiquetCompra != "")
            tiquetCompra = tiquetCompra + "\n";
        tiquetCompra = tiquetCompra + "PRODUCTE: " + productesCistella[i];
        for (int n = 0; n < numElemBotigaProva; n++)
        {
            if (productesCistella[i] == arrayStockProva[n])
                preu = arrayPreuProductesProva[n] * quantitat[i];
        }
        tiquetCompra = tiquetCompra + "\tQUANTITAT: " + quantitat[i] + "\tPREU: " + preu + " euros.";
    }
    Console.WriteLine("Vols mostrar l'string 'tiquetCompra'?[s/n]");
    sortida = Console.ReadKey().KeyChar;
    Console.Clear();
    if (sortida == 's' || sortida == 'S')
        Console.WriteLine(tiquetCompra);
    return tiquetCompra;
}
static void OrdenarCistella(string[] productesCistella, int[] quantitat, int numElemCistella)
{
    string aux;
    int intAux;
    for (int nVolta = 0; nVolta < numElemCistella - 1; nVolta++)
    {
        for (int i = 0; i < numElemCistella - 1; i++)
        {
            if (productesCistella[i].CompareTo(productesCistella[i + 1]) > 0)
            {
                //PERMUTACIO PRODUCTES CISTELLA:
                aux = productesCistella[i];
                productesCistella[i] = productesCistella[i + 1];
                productesCistella[i + 1] = aux;
                //PERMUTACIO QUANTITATS CISTELLA:
                intAux = quantitat[i];
                quantitat[i] = quantitat[i + 1];
                quantitat[i + 1] = intAux;
            }
        }
    }
    Console.WriteLine("La cistella s'ha ordenat correctament.");
}