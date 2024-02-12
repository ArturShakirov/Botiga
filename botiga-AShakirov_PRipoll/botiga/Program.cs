using System.Text.RegularExpressions;

string[] productesBotiga = new string[30];
int[] preus = new int[30];
string textOpcio;
int numElementsBotiga = 10, opcio;
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
            textOpcio = "Donar d'alta usuari.";
            MostrarCapcelera(textOpcio);
            Contador();
            break;
        case '2':
            textOpcio = "Recuperar usuari.";
            MostrarCapcelera(textOpcio);
            break;
        case '3':
            textOpcio = "Modificar usuari.";
            MostrarCapcelera(textOpcio);
            Contador();
            break;
        case '4':
            textOpcio = "Eliminar usuari.";
            MostrarCapcelera(textOpcio);
            Contador();
            break;
        case '5':
            textOpcio = "Mostrar agenda.";
            MostrarCapcelera(textOpcio);
            PremeuPerTornar();
            break;
        case '6':
            textOpcio = "Ordenar agenda.";
            MostrarCapcelera(textOpcio);
            Contador();
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
               "║     2. Recuperar usuari        ║\n" +
               "║     ----------------------     ║\n" +
               "║     3. Modificar usuari        ║\n" +
               "║     ----------------------     ║\n" +
               "║     4. Eliminar usuari         ║\n" +
               "║     ----------------------     ║\n" +
               "║     5. Mostrar agenda          ║\n" +
               "║     ----------------------     ║\n" +
               "║     6. Ordenar agenda          ║\n" +
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
                    "║             \x1b[31mAGENDA\x1b[30m             ║\n" +
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
                         "╚══" + linies + "══╝";

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

} while (!sortir);