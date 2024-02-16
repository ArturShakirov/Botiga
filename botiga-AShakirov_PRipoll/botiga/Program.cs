//CISTELLA:
using System.ComponentModel.Design;

string[] productesCistella = new string[10], arrayStockProva = { "POMES", "PERAS", "PLATANS", "PATATES", "OLIVES", "BASTONETS", "LLET", "OUS", "MELONS", "CHICLETS" };
int[] quantitat = new int[10];
double[] arrayPreuProductesProva = { 1, 1.5, 2, 2.7, 2.2, 2.1, 1.2, 2.6, 1.9, 3 };
int numElemCistella = 0, numElemBotigaProva = 10, quantitatActual = 0, decisor = int.MinValue;
double diners = 0;
string producteComprar = "";
char acabarLlista = ' ';
while (decisor != 0)
{
    Console.Clear();
    Console.WriteLine("Quina opcio tries?");
    Console.WriteLine("1. Comprar un producte.");
    Console.WriteLine("2. Comprar més d'un producte.");
    Console.WriteLine("3. Ordenar llista.");
    Console.WriteLine("4. Mostrar tiquet de la compra per pantalla.");
    Console.WriteLine("5. Mostrar tiquet en string.");
    Console.WriteLine("0. Sortir.");
    decisor = Convert.ToInt32(Console.ReadLine());
    while (producteComprar == "" && decisor > 0 && decisor <= 2)
    {
        Console.Clear();
        Console.WriteLine("Introdueix els diners dels que disposes per a fer la compra:");
        diners = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Introdueix el nom del producte que vols comprar. Productes disponibles:");
        for (int i = 0; i < numElemBotigaProva; i++)
        {//Mostra els productes que hi ha disponibles per a comprar, productes dins l'array:arrayStockProva.
            Console.WriteLine(i + ". " + arrayStockProva[i]);
        }
        producteComprar = Console.ReadLine();
        Console.WriteLine("Quina quantitat de " + producteComprar + " vols agafar?");
        quantitatActual = Convert.ToInt32(Console.ReadLine());
        if (decisor == 1)
            producteComprar = ComprarProducte(arrayStockProva, arrayPreuProductesProva, productesCistella, quantitat, ref quantitatActual, ref diners, numElemBotigaProva, ref numElemCistella, producteComprar);
        else producteComprar = ComprarProductes(arrayStockProva, arrayPreuProductesProva, productesCistella, quantitat, ref quantitatActual, ref diners, numElemBotigaProva, ref numElemCistella, producteComprar);
    }
    //S'HAURA DE BORRAR--------------------------------------------------------------------------------------------------------------COMPROVADOR
    producteComprar = "";
    Console.WriteLine("PRODUCTE A ENTRAR I QUANTITAT I DINERS I NUMELEMCISTELLA: " + producteComprar + " / " + quantitatActual + " / " + diners + " / " + numElemCistella);
    for (int i = 0; i < numElemCistella; i++)
    {
        Console.WriteLine(productesCistella[i]);
    }
    for (int i = 0; i < numElemCistella; i++)
    {
        Console.WriteLine(quantitat[i]);
    }
    //S'HAURA DE BORRAR--------------------------------------------------------------------------------------------------------------COMPROVADOR
    //if (decisor == 3)
    //    //fer mètode per ordenar l'array de a cistella.
    if (decisor == 4)
        MostrarCistella(productesCistella, quantitat, numElemCistella, arrayStockProva, arrayPreuProductesProva, numElemBotigaProva);
    //if (decisor==5)
    //    fer metode per mostrar l'array de la cistella com a un string.
    Thread.Sleep(2500);
}
static string ComprarProducte(string[] arrayStockProva, double[] arrayPreuProductesProva, string[] productesCistella, int[] quantitat, ref int quantitatActual, ref double diners, int numElemBotigaProva, ref int numElemCistella, string producteComprar)
{//FUNCIONA!!!FALTA TREURE A FORA LU DE DEMANAR PRODUCTE I QUANTITAT PER PODER-HO APROFITAR PER FER EL SEGUENT METODE NOMES AMB UN BUCLE.
    Console.Clear();
    bool existeix = false, espai = false, capacitat = false;
    double preuTotal = 0, auxiliar;
    char decisiu, mesDiners;
    int ampliacio;
    for (int i = 0; i < numElemBotigaProva; i++)
    {//Recorre tot l'array i comprova si algun element coincideix amb el que ha introduit l'usuari.
        if (producteComprar.ToUpper() == arrayStockProva[i])
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
        Console.WriteLine("Cistella plena. Vols ampliar la cistella?");
        decisiu = Convert.ToChar(Console.ReadLine());
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
{//ACABAT EN TEORIA FALTA PROVAR.--------------------------------------------------------------------------------------------------------------------------------------
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
{//FUNCIONA!!----------------------------------------------------------------------------------------------------------------------------------------------------------
    numElemCistella++;
    for (int i = 0; i < numElemCistella; i++)
    {
        if (i + 1 == numElemCistella)
        {//Busca la posicio de l'array cistella on s'ha d'introduir el nou producte.
            productesCistella[i] = producteComprar.ToUpper();
            quantitat[i] = quantitatActual;
            Console.WriteLine("Els productes s'han introduit a la cistella correctament.");
        }
    }
}
static string ComprarProductes(string[] arrayStockProva, double[] arrayPreuProductesProva, string[] productesCistella, int[] quantitat, ref int quantitatActual, ref double diners, int numElemBotigaProva, ref int numElemCistella, string producteComprar)
{
    char sortida = 's';
    while (sortida != 'n' && sortida != 'N')
    {
        if (producteComprar == "")
        {
            Console.Clear();
            Console.WriteLine("Productes disponibles:");
            for (int i=0;i<arrayStockProva.Length;i++)
            { Console.WriteLine(arrayStockProva[i]); }
            Console.WriteLine("Nom producte:");
            producteComprar = Console.ReadLine();
            Console.WriteLine("Quantitat:");
            quantitatActual = Convert.ToInt32(Console.ReadLine());
        }
        producteComprar = ComprarProducte(arrayStockProva, arrayPreuProductesProva, productesCistella, quantitat, ref quantitatActual, ref diners, numElemBotigaProva, ref numElemCistella, producteComprar);
        Console.WriteLine("He sortit");
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
        Console.Write("PRODUCTE: " + productesCistella[i] + "\t\t");
        for (int n = 0; n < numElemBotigaProva; n++)
        {
            if (productesCistella[i] == arrayStockProva[n])
                preu = arrayPreuProductesProva[n] * quantitat[i];
        }
        Console.WriteLine("QUANTITAT: " + quantitat[i] + "\t" + "PREU: " + preu+" euros.");
    }
    Console.WriteLine("Premeu qualsevol caracter per a tornar:");
    sortida = Console.ReadKey().KeyChar;
}
