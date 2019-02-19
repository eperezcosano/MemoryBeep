using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MB_Prototipo1
{
    class MemoryBeep
    {
        /* * * * * * * * *
         *               *
         *    CLASES     *
         *               *
         * * * * * * * * */

        public class Partida
        {
            public int puntuacion;
            public string tituloCancion;
            public string nombre;
        }

        public class CancionData
        {
            public int id;
            public string titulo;
            public string[] musicnotes;
            public string[] durationnotes;
        }

        const int maxCanciones = 20;
        const int maxPartidas = 20;

        public static CancionData[] ListaCanciones = new CancionData[maxCanciones];
        public static Partida[] ListaPartidas = new Partida[maxPartidas];
        public static int numeroPartidasGuardadas = 0;

        /* * * * * * * * *
         *               *
         *   FUNCIONES   *
         *               *
         * * * * * * * * */

        // Activar el menú principal en el que se mostrarán las opciones disponibles para el usuario.
        static int mostrarMenuPrincipal(int numeromenu = 0)
        {
            string message_error = "";
            while (numeromenu == 0)
            {
                // TÍTULO
                Console.Write("\n\n\n\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                textoCentrado(">>>  Menú Principal  <<<");
                Console.ResetColor();
                Console.Write("\n");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                textoCentrado(message_error);
                message_error = "";
                Console.Write("\n");

                // OPCIONES
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("                  1> ");
                Console.ResetColor();
                mostrarPalabraConDelay("Ver lista de canciones\n\n", 10, 20);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("                  2> ");
                Console.ResetColor();
                mostrarPalabraConDelay("Jugar\n\n", 10, 20);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("                  3> ");
                Console.ResetColor();
                mostrarPalabraConDelay("Últimas 10 partidas\n\n", 10, 20);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("                  4> ");
                Console.ResetColor();
                mostrarPalabraConDelay("Salir y guardar\n\n", 10, 20);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("                  5> ");
                Console.ResetColor();
                mostrarPalabraConDelay("Salir sin guardar\n\n", 10, 20);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("                  > ");
                string output = Console.ReadKey().KeyChar.ToString();
                try
                {
                    numeromenu = Convert.ToInt32(output);
                    if (numeromenu < 1 || numeromenu > 5)
                    {
                        numeromenu = 0;
                        message_error = "Número inválido. Inténtalo de nuevo.";
                    }
                }
                catch (FormatException)
                {
                    message_error = "Formato inválido. Inténtalo de nuevo.";
                }
                Console.ResetColor();
                Console.Clear();
            }
            return numeromenu;
        }//Correcto


        // Pantalla de carga
        static void mostrarPantallaCarga()
        {
            Console.Write("\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            textoCentrado("███╗   ███╗███████╗███╗   ███╗ ██████╗ ██████╗ ██╗   ██╗");
            textoCentrado("████╗ ████║██╔════╝████╗ ████║██╔═══██╗██╔══██╗╚██╗ ██╔╝");
            textoCentrado("██╔████╔██║█████╗  ██╔████╔██║██║   ██║██████╔╝ ╚████╔╝ ");
            textoCentrado("██║╚██╔╝██║██╔══╝  ██║╚██╔╝██║██║   ██║██╔══██╗  ╚██╔╝  ");
            textoCentrado("██║ ╚═╝ ██║███████╗██║ ╚═╝ ██║╚██████╔╝██║  ██║   ██║   ");
            textoCentrado("╚═╝     ╚═╝╚══════╝╚═╝     ╚═╝ ╚═════╝ ╚═╝  ╚═╝   ╚═╝   ");
            textoCentrado("██████╗ ███████╗███████╗██████╗ ");
            textoCentrado("██╔══██╗██╔════╝██╔════╝██╔══██╗");
            textoCentrado("██████╔╝█████╗  █████╗  ██████╔╝");
            textoCentrado("██╔══██╗██╔══╝  ██╔══╝  ██╔═══╝ ");
            textoCentrado("██████╔╝███████╗███████╗██║     ");
            textoCentrado("╚═════╝ ╚══════╝╚══════╝╚═╝     ");

            Console.WriteLine("\n\n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            textoCentrado("Creado por:");
            Console.WriteLine("\n");

            Console.ForegroundColor = ConsoleColor.Gray;

            mostrarPalabraConDelay("Luís Picó", 20, 20, true);
            System.Threading.Thread.Sleep(500);
            mostrarPalabraConDelay("Izan Pérez", 20, 20, true);
            System.Threading.Thread.Sleep(500);
            mostrarPalabraConDelay("Sergio Ornaque", 20, 20, true);
            System.Threading.Thread.Sleep(500);

            Console.ResetColor();
            Console.Clear();
        }//Correcto

        // Esta función sirve para hacer que un texto se muestre centrado en la pantalla.
        // Tienes que poner el texto como parámetro de la función.
        static void textoCentrado(String str)
        {
            string s = str;
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
        }//Correcto

        // Esta función transforma el nombre de una nota a su frecuencia.
        // Tienes que poner el nombre de la nota como parámetro de la función.
        static int freqnote(string nota)
        {
            switch (nota)
            {
                case "Do_4":
                    return (int)261.63;
                case "Do_S4":
                    return (int)277.18;
                case "Re_4":
                    return (int)293.66;
                case "Re_S4":
                    return (int)311.13;
                case "Mi_4":
                    return (int)329.63;
                case "Fa_4":
                    return (int)349.23;
                case "Fa_S4":
                    return (int)369.99;
                case "Sl_4":
                    return (int)392.00;
                case "Sl_S4":
                    return (int)415.30;
                case "La_4":
                    return (int)440.00;
                case "La_S4":
                    return (int)466.16;
                case "Si_4":
                    return (int)493.88;
                case "Do_5":
                    return (int)523.25;
                case "Do_S5":
                    return (int)554.37;
                case "Re_5":
                    return (int)587.33;
                case "Re_S5":
                    return (int)622.25;
                case "Mi_5":
                    return (int)659.26;
                case "Fa_5":
                    return (int)698.46;
                case "Fa_S5":
                    return (int)739.99;
                case "Sl_5":
                    return (int)783.99;
                case "Sl_S5":
                    return (int)830.61;
                case "La_5":
                    return (int)880.00;
                case "La_S5":
                    return (int)932.33;
                case "Si_5":
                    return (int)987.77;
                case "Do_6":
                    return (int)1046.50;
                case "Do_S6":
                    return (int)1108.73;
                case "Re_6":
                    return (int)1174.66;
                case "Re_S6":
                    return (int)1244.51;
                case "Mi_6":
                    return (int)1318.51;
                case "Fa_6":
                    return (int)1396.91;
                case "Fa_S6":
                    return (int)1479.98;
                case "Sl_6":
                    return (int)1567.98;
                case "Sl_S6":
                    return (int)1661.22;
                case "La_6":
                    return (int)1760.00;
                case "La_S6":
                    return (int)1864.66;
                case "Si_6":
                    return (int)1975.53;
                case "Do_7":
                    return (int)2093.00;
                case "Do_S7":
                    return (int)2217.46;
                case "Re_7":
                    return (int)2349.32;
                case "Re_S7":
                    return (int)2489.02;
                case "Mi_7":
                    return (int)2637.02;
                case "Fa_7":
                    return (int)2793.83;
                case "Fa_S7":
                    return (int)2959.96;
                case "Silencio":
                    return (int)37.0;
                default:
                    return 0;
            }
        }//Correcto

        // Transforma un tipo de notas a su tiempo.
        static int temponote(string tempo, int redonda = 900)
        {
            switch (tempo)
            {
                case "redonda":
                    return redonda;
                case "blanca_punto":
                    return 3 * redonda / 4;
                case "blanca":
                    return redonda / 2;
                case "negra_punto":
                    return 3 * redonda / 8;
                case "negra":
                    return redonda / 4;
                case "corchea_punto":
                    return 3 * redonda / 16;
                case "corchea":
                    return redonda / 8;
                case "semicorchea_punto":
                    return 3 * redonda / 32;
                case "semicorchea":
                    return redonda / 16;
                default:
                    return 0;
            }
        }//Correcto

        // Esta función hace que un texto se muestre de poco en poco.
        // Los parámetros son:
        // String str -> El texto que quieres mostrar.
        // int delay -> El tiempo entre letra y letra.
        // int delayFinal -> El tiempo que esperará después de escribir el string str antes de continuar con el programa.
        // boolean centrado -> Mostrar el texto en el centro de la pantalla.
        static void mostrarPalabraConDelay(String str, int delay, int delayFinal, bool centrado = false)
        {
            if (centrado)
            {
                Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, Console.CursorTop);
            }
            char[] caracteres = str.ToCharArray();
            int i = 0;
            while (i < caracteres.Length)
            {
                Console.Write(Convert.ToString(caracteres[i]));
                System.Threading.Thread.Sleep(delay);
                i++;
            }
            System.Threading.Thread.Sleep(delayFinal);
        }//Correcto

        // Iniciar el menú de selección de canciones.
        static int SeleccionJuego_Cancion()
        {
            string output, message_error = "";
            int i = 1, numero_seleccion = 0;
            while (numero_seleccion == 0)
            {
                //TITULO
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n\n\n\n");
                textoCentrado("Canciones disponibles:");
                Console.ResetColor();
                Console.Write("\n");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                textoCentrado(message_error);
                message_error = "";
                Console.Write("\n");

                //CANCIONES
                i = 1;
                while (ListaCanciones[i - 1] != null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("                  " + i + "> ");
                    Console.ResetColor();
                    Console.Write(ListaCanciones[i - 1].titulo + "\n\n");
                    i++;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("                   > ");

                output = Console.ReadKey().KeyChar.ToString();
                try
                {
                    numero_seleccion = Convert.ToInt32(output);
                    if (numero_seleccion > i - 1)
                    {
                        numero_seleccion = 0;
                        message_error = "Número inválido. Inténtalo de nuevo.";
                    }
                }
                catch (FormatException)
                {
                    message_error = "Formato inválido. Inténtalo de nuevo.";
                }
                Console.ResetColor();
                Console.Clear();
            }

            return numero_seleccion - 1;
        }//Correcto

        // Mostrar el menú de selección de dificultad
        static int SeleccionJuego_Dificultad()
        {
            int numero_seleccion = 0;
            string output, message_error = "";
            while (numero_seleccion == 0)
            {
                //TITULO
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n\n\n\n");
                textoCentrado("Selecciona la Dificultad:");
                Console.ResetColor();
                Console.Write("\n");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                textoCentrado(message_error);
                message_error = "";
                Console.Write("\n\n");

                //OPCIONES

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("                  1> Fácil\n\n\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("                  2> Media\n\n\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("                  3> Difícil\n\n\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("                   > ");

                output = Console.ReadKey().KeyChar.ToString();
                try
                {
                    numero_seleccion = Convert.ToInt32(output);
                    if (numero_seleccion > 3)
                    {
                        numero_seleccion = 0;
                        message_error = "Número inválido. Inténtalo de nuevo.";
                    }
                }
                catch (FormatException)
                {
                    message_error = "Formato inválido. Inténtalo de nuevo.";
                }
                Console.ResetColor();
                Console.Clear();
            }
            return numero_seleccion;
        }//Correcto

        // Iniciar el juego
        // Parámetros:
        // int idcancion -> El id de la canción que se reproducirá
        // int dificultad -> Nivel de dificultad (1, 2 o 3)
        static void Juego(int idcancion, int dificultad)
        {

            int notepos = 0, puntos_ingame = 0, rapidez = 500;
            string difd, message_error = "";
            bool game_over = false;

            switch (dificultad)
            {
                case 1:
                    difd = "Fácil";
                    rapidez = 500;
                    break;
                case 2:
                    difd = "Media";
                    rapidez = 250;
                    break;
                case 3:
                    difd = "Difícil";
                    rapidez = 125;
                    break;
                default:
                    difd = "Fácil";
                    rapidez = 500;
                    break;
            }

            while (puntos_ingame < ListaCanciones[idcancion].musicnotes.Length && game_over == false)
            {
                notepos = 0;

                //REPRODUCTOR
                while (notepos < puntos_ingame + 1)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine();
                    Console.WriteLine("Canción: {0} - {1}  -  Puntos: {2}/{3}", ListaCanciones[idcancion].titulo, difd, puntos_ingame, ListaCanciones[idcancion].musicnotes.Length);
                    Console.WriteLine("_______________________________________________________________________________\n\n\n\n\n\n");
                    Console.ResetColor();
                    Console.WriteLine();

                    TecladoNotas(NombreNota(ListaCanciones[idcancion].musicnotes[notepos]));

                    Console.Write("\n\n\n\n\n\n");
                    textoCentrado("¡Memoriza!");
                    Console.SetCursorPosition((Console.WindowWidth - 1) / 2, Console.CursorTop);

                    Console.Beep(freqnote(ListaCanciones[idcancion].musicnotes[notepos]), rapidez);
                    System.Threading.Thread.Sleep(rapidez);

                    notepos++;
                }

                //COMPOSITOR
                int input = 0, h = -1;
                string input_key = "", input_nota = "";

                while (h < puntos_ingame + 1)
                {
                    Console.Clear();
                    //Arreglar
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Canción: {0} - {1}  -  Puntos: {2}/{3}", ListaCanciones[idcancion].titulo, difd, puntos_ingame, ListaCanciones[idcancion].musicnotes.Length);
                    Console.WriteLine("_______________________________________________________________________________\n\n\n\n\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    textoCentrado("  1>       2>       3>       4>       5>       6>       7>  ");
                    Console.ResetColor();
                    Console.WriteLine();

                    if (h != -1)
                    {
                        try
                        {
                            input = Convert.ToInt32(input_key);

                            if (input != 1 && input != 2 && input != 3 && input != 4 && input != 5 && input != 6 && input != 7)
                            {
                                input = 0;
                                message_error = "Número inválido. Inténtalo de nuevo.";
                                TecladoNotas(input_nota);
                            }
                            else
                            {
                                switch (input)
                                {
                                    case 1:
                                        input_nota = "Do";
                                        break;
                                    case 2:
                                        input_nota = "Re";
                                        break;
                                    case 3:
                                        input_nota = "Mi";
                                        break;
                                    case 4:
                                        input_nota = "Fa";
                                        break;
                                    case 5:
                                        input_nota = "Sl";
                                        break;
                                    case 6:
                                        input_nota = "La";
                                        break;
                                    case 7:
                                        input_nota = "Si";
                                        break;
                                    default:
                                        input_nota = "";
                                        break;
                                }

                                if (input_nota == NombreNota(ListaCanciones[idcancion].musicnotes[h]))
                                {
                                    TecladoNotas(input_nota);
                                    Console.Beep(freqnote(ListaCanciones[idcancion].musicnotes[h]), 500);
                                    h++;
                                }
                                else
                                {
                                    game_over = true;
                                    break;
                                }
                            }
                        }
                        catch (FormatException)
                        {
                            message_error = "Formato inválido. Inténtalo de nuevo.";
                            TecladoNotas(input_nota);
                        }

                    }
                    else
                    {
                        TecladoNotas(input_nota);
                        h++;
                    }
                    Console.Write("\n\n\n\n");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    textoCentrado(message_error);
                    message_error = "";
                    Console.ResetColor();
                    Console.WriteLine();
                    textoCentrado("¡Te Toca!");
                    Console.SetCursorPosition((Console.WindowWidth - 1) / 2, Console.CursorTop);
                    if (h < puntos_ingame + 1)
                    {
                        input_key = Console.ReadKey().KeyChar.ToString();
                    }
                    else
                    {
                        puntos_ingame++;
                        break;
                    }
                }
            }
            finalizarJuego(puntos_ingame, idcancion);
        }//Correcto

        // Función que se ejecutará cuando el usuario gane o pierda una partida.
        // Iniciará una pantalla con la información de tu partida y te pedirá que introduzcas tu nombre para su posterior almacenamiento.
        // Parámetros:
        // int puntuacion -> La puntuación que ha logrado el usuario
        // int idCancion -> La canción que ha reproducido.
        static void finalizarJuego(int puntuacion, int idCancion)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\n\n\n\n");
            textoCentrado(">>> Game Over <<<");
            Console.WriteLine("\n\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("\n                 > ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            mostrarPalabraConDelay("Tu Puntuación: " + puntuacion + "\n", 10, 20);

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("\n                 > ");
            mostrarPalabraConDelay("Puntuación Máxima Posible: " + ListaCanciones[idCancion].musicnotes.Length + "\n\n\n\n", 10, 20);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            mostrarPalabraConDelay("                 > Introduce tu nombre de jugador: ", 10, 20);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n\n                 > ");

            Partida p = new Partida();
            p.nombre = Console.ReadLine();
            p.puntuacion = puntuacion;
            p.tituloCancion = ListaCanciones[idCancion].titulo;

            int i = numeroPartidasGuardadas;
            while (i >= 1)
            {
                ListaPartidas[i] = ListaPartidas[i - 1];
                i--;
            }
            ListaPartidas[0] = p;
            numeroPartidasGuardadas++;

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("\n\n\n");
            textoCentrado("Información almacenada en caché.");
            textoCentrado("Guarda al salir para aplicar los cambios.");
            textoCentrado("Regresando al menú principal...");
            System.Threading.Thread.Sleep(3000);
            Console.Clear();
        }//Correcto

        // Esta función cambia la apariencia del menú de notas.
        static void TecladoNotas(string note)
        {
            switch (note)
            {
                case "Do":
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("╔════╗");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("   ╔════╗   ╔════╗   ╔════╗   ╔════╗   ╔════╗   ╔════╗");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("║    ║   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("║    ║   ║    ║   ║    ║   ║    ║   ║    ║   ║    ║");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("║ Do ║   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("║ Re ║   ║ Mi ║   ║ Fa ║   ║ Sl ║   ║ La ║   ║ Si ║");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("║    ║   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("║    ║   ║    ║   ║    ║   ║    ║   ║    ║   ║    ║");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("╚════╝   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("╚════╝   ╚════╝   ╚════╝   ╚════╝   ╚════╝   ╚════╝");
                    Console.ResetColor();
                    break;
                case "Re":
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("╔════╗   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("╔════╗   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("╔════╗   ╔════╗   ╔════╗   ╔════╗   ╔════╗");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("║    ║   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("║    ║   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("║    ║   ║    ║   ║    ║   ║    ║   ║    ║");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("║ Do ║   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("║ Re ║   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("║ Mi ║   ║ Fa ║   ║ Sl ║   ║ La ║   ║ Si ║");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("║    ║   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("║    ║   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("║    ║   ║    ║   ║    ║   ║    ║   ║    ║");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("╚════╝   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("╚════╝   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("╚════╝   ╚════╝   ╚════╝   ╚════╝   ╚════╝");
                    Console.ResetColor();
                    break;
                case "Mi":
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("╔════╗   ╔════╗   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("╔════╗   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("╔════╗   ╔════╗   ╔════╗   ╔════╗");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("║    ║   ║    ║   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("║    ║   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("║    ║   ║    ║   ║    ║   ║    ║");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("║ Do ║   ║ Re ║   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("║ Mi ║   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("║ Fa ║   ║ Sl ║   ║ La ║   ║ Si ║");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("║    ║   ║    ║   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("║    ║   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("║    ║   ║    ║   ║    ║   ║    ║");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("╚════╝   ╚════╝   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("╚════╝   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("╚════╝   ╚════╝   ╚════╝   ╚════╝");
                    Console.ResetColor();
                    break;
                case "Fa":
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("╔════╗   ╔════╗   ╔════╗   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("╔════╗   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("╔════╗   ╔════╗   ╔════╗");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("║    ║   ║    ║   ║    ║   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("║    ║   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("║    ║   ║    ║   ║    ║");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("║ Do ║   ║ Re ║   ║ Mi ║   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("║ Fa ║   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("║ Sl ║   ║ La ║   ║ Si ║");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("║    ║   ║    ║   ║    ║   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("║    ║   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("║    ║   ║    ║   ║    ║");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("╚════╝   ╚════╝   ╚════╝   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("╚════╝   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("╚════╝   ╚════╝   ╚════╝");
                    Console.ResetColor();
                    break;
                case "Sl":
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("╔════╗   ╔════╗   ╔════╗   ╔════╗   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("╔════╗   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("╔════╗   ╔════╗");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("║    ║   ║    ║   ║    ║   ║    ║   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("║    ║   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("║    ║   ║    ║");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("║ Do ║   ║ Re ║   ║ Mi ║   ║ Fa ║   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("║ Sl ║   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("║ La ║   ║ Si ║");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("║    ║   ║    ║   ║    ║   ║    ║   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("║    ║   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("║    ║   ║    ║");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("╚════╝   ╚════╝   ╚════╝   ╚════╝   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("╚════╝   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("╚════╝   ╚════╝");
                    Console.ResetColor();
                    break;
                case "La":
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("╔════╗   ╔════╗   ╔════╗   ╔════╗   ╔════╗   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("╔════╗   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("╔════╗");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("║    ║   ║    ║   ║    ║   ║    ║   ║    ║   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("║    ║   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("║    ║");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("║ Do ║   ║ Re ║   ║ Mi ║   ║ Fa ║   ║ Sl ║   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("║ La ║   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("║ Si ║");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("║    ║   ║    ║   ║    ║   ║    ║   ║    ║   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("║    ║   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("║    ║");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("╚════╝   ╚════╝   ╚════╝   ╚════╝   ╚════╝   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("╚════╝   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("╚════╝");
                    Console.ResetColor();
                    break;
                case "Si":
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("╔════╗   ╔════╗   ╔════╗   ╔════╗   ╔════╗   ╔════╗   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("╔════╗");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("║    ║   ║    ║   ║    ║   ║    ║   ║    ║   ║    ║   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("║    ║");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("║ Do ║   ║ Re ║   ║ Mi ║   ║ Fa ║   ║ Sl ║   ║ La ║   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("║ Si ║");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("║    ║   ║    ║   ║    ║   ║    ║   ║    ║   ║    ║   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("║    ║");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("╚════╝   ╚════╝   ╚════╝   ╚════╝   ╚════╝   ╚════╝   ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("╚════╝");
                    Console.ResetColor();
                    break;
                default:
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("╔════╗   ╔════╗   ╔════╗   ╔════╗   ╔════╗   ╔════╗   ╔════╗");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.WriteLine("║    ║   ║    ║   ║    ║   ║    ║   ║    ║   ║    ║   ║    ║");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.WriteLine("║ Do ║   ║ Re ║   ║ Mi ║   ║ Fa ║   ║ Sl ║   ║ La ║   ║ Si ║");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.WriteLine("║    ║   ║    ║   ║    ║   ║    ║   ║    ║   ║    ║   ║    ║");
                    Console.SetCursorPosition((Console.WindowWidth - 60) / 2, Console.CursorTop);
                    Console.WriteLine("╚════╝   ╚════╝   ╚════╝   ╚════╝   ╚════╝   ╚════╝   ╚════╝");
                    Console.ResetColor();
                    break;
            }
        }//Correcto

        // Esta función carga las canciones del fichero canciones.txt
        static int LeerDatos_Canciones()
        {
            int i = 0, j = 0;
            string s;
            string[] datasong, pentagrama, parts;
            StreamReader F;

            try
            {
                F = new StreamReader("canciones.txt");
            }
            catch (FileNotFoundException)
            {
                return 0;
            }

            s = F.ReadLine();
            while (s != null && i < maxCanciones)
            {
                CancionData u = new CancionData();

                datasong = s.Split(' ');

                u.id = Convert.ToInt32(datasong[0]);
                u.titulo = datasong[1];

                pentagrama = datasong[2].Split(',');

                u.musicnotes = new string[pentagrama.Length];
                u.durationnotes = new string[pentagrama.Length];

                j = 0;
                while (j < pentagrama.Length)
                {
                    parts = pentagrama[j].Split('/');

                    u.musicnotes[j] = parts[0];
                    u.durationnotes[j] = parts[1];

                    j++;
                }

                ListaCanciones[i] = u;
                i++;
                s = F.ReadLine();
            }
            F.Close();
            return 1;
        }//Correcto

        // Esta función carga los datos de las últimas 10 partidas
        static int LeerDatos_Partidas()
        {
            int i = 0;
            string s;
            string[] partes;
            StreamReader F;

            try
            {
                F = new StreamReader("partidas.txt");
            }
            catch (FileNotFoundException)
            {
                return 0;
            }

            s = F.ReadLine();
            while (s != null && i < (maxCanciones - 1))
            {
                Partida p = new Partida();
                // Ejemplo: Sergio/16/Cancion
                partes = s.Split('/');

                p.nombre = partes[0];
                p.puntuacion = Convert.ToInt32(partes[1]);
                p.tituloCancion = partes[2];

                numeroPartidasGuardadas++;
                ListaPartidas[i] = p;
                i++;
                s = F.ReadLine();
            }
            F.Close();
            return 1;
        }//Correcto

        // Guarda las 10 últimas partidas en el archivo partidas.txt
        static void guardarPartida()
        {
            int i = 0;

            // SOBRESCRIBIMOS EL ARCHIVO
            File.WriteAllText("partidas.txt", String.Empty);

            // GUARDAMOS LA INFORMACIÓN
            while (ListaPartidas[i] != null && i < maxPartidas)
            {
                File.AppendAllText("partidas.txt",
                   ListaPartidas[i].nombre + "/" + ListaPartidas[i].puntuacion + "/" + ListaPartidas[i].tituloCancion + Environment.NewLine);
                i++;
            }
        }//Correcto

        // Activar el menú en el que aparece la información de las 10 últimas partidas.
        static void ultimasPartidas()
        {
            int i = 0;

            Console.Clear();

            Console.Write("\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            textoCentrado(">>>  ÚlLTIMAS PARTIDAS  <<<");
            Console.ResetColor();
            Console.Write("\n\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;

            while (i < 10 && ListaPartidas[i] != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("                  " + (i + 1) + ") ");
                Console.ResetColor();
                Console.Write(ListaPartidas[i].nombre + " - Puntuación: " + ListaPartidas[i].puntuacion + " - Canción: " + ListaPartidas[i].tituloCancion + "\n\n");
                i++;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("                  > Pulsa cualquier tecla para volver");
            Console.ReadKey();
            Console.Clear();
        }

        // Activar el menú en el que aparece las canciones disponibles.
        static void mostrarCanciones_rep()
        {
            int i = 1, numero_output = 0;
            string message_error = "";
            while (numero_output == 0)
            {
                // TÍTULO
                Console.Write("\n\n\n\n");
                Console.ForegroundColor = ConsoleColor.Green;
                textoCentrado(">>>  Lista de Canciones  <<<");
                Console.ResetColor();
                Console.Write("\n");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                textoCentrado(message_error);
                message_error = "";
                i = 1;
                while (ListaCanciones[i - 1] != null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("                  " + i + "> ");
                    Console.ResetColor();
                    Console.Write(ListaCanciones[i - 1].titulo + "\n\n");
                    i++;
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("                  9> Volver\n\n");
                Console.Write("                  > ");

                string output = Console.ReadKey().KeyChar.ToString();
                try
                {
                    numero_output = Convert.ToInt32(output);
                    if ((numero_output > i - 1 || numero_output == 0) && numero_output != 9)
                    {
                        numero_output = 0;
                        message_error = "Número inválido. Inténtalo de nuevo.";
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Clear();

                        if (numero_output != 9)
                        {
                            ReproducirCancion(numero_output - 1);
                            numero_output = 0;
                        }
                    }
                }
                catch (FormatException)
                {
                    message_error = "Formato inválido. Inténtalo de nuevo.";
                }
                Console.ResetColor();
                Console.Clear();
            }
        }//Correcto

        // Coge la canción de la posición n de la lista de canciones almacenada en caché y la reproduce.
        static void ReproducirCancion(int n)
        {
            int i = 0;

            try
            {
                string[] notes = ListaCanciones[n].musicnotes;
                string[] tempo = ListaCanciones[n].durationnotes;

                // TÍTULO
                Console.Write("\n\n\n\n\n\n\n\n\n\n\n");
                Console.ForegroundColor = ConsoleColor.Green;
                textoCentrado(">>>  Reproduciendo  <<<");
                Console.ResetColor();
                Console.Write("\n");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                textoCentrado(ListaCanciones[n].titulo);
                Console.SetCursorPosition((Console.WindowWidth - 1) / 2, Console.CursorTop);


                while (i < notes.Length)
                {
                    Console.Beep(freqnote(notes[i]), temponote(tempo[i]));
                    i++;
                }

            }
            catch (Exception)
            {
                textoCentrado("Hubo un error al cargar los datos.");
                Console.ReadLine();
            }

            Console.ResetColor();
            Console.Clear();
        }//Correcto

        // Separa la información de una nota y refresa el nombre de esta.
        static string NombreNota(string s)
        {
            string[] trozos = s.Split('_');
            string nom = trozos[0];
            return nom;
        }//Correcto

        /* * * * * * * * *
         *               *
         *     MAIN      *
         *               *
         * * * * * * * * */

        static void Main(string[] args)
        {

            if (LeerDatos_Canciones() == 0)
            {
                Console.WriteLine("No se encuentra el archivo canciones.txt");
                Console.ReadLine();
            }
            else if (LeerDatos_Partidas() == 0)
            {
                Console.WriteLine("No se encuentra el archivo partidas.txt");
                Console.ReadLine();
            }
            else
            {
                mostrarPantallaCarga();

                bool exit = false;
                while (!exit)
                {
                    switch (mostrarMenuPrincipal())
                    {
                        case 1:     //Lista de Canciones
                            mostrarCanciones_rep();
                            break;
                        case 2:     //Jugar
                            Juego(SeleccionJuego_Cancion(), SeleccionJuego_Dificultad());
                            break;
                        case 3:     //Últimas 10 partidas
                            ultimasPartidas();
                            break;
                        case 4:     //Salir y Guradar
                            guardarPartida();
                            exit = true;
                            break;
                        case 5:   // Salir sin guardar
                            exit = true;
                            break;
                    }
                }
            }
        }//Correcto
    }
}