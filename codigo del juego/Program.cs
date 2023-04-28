using System;

class Program
{
    static int[,] tablero;
    static int vidas = 10;


    static void Paso1_CrearTablero(int tamaño)
    {
        tablero = new int[tamaño, tamaño];
        for (int f = 0; f < tablero.GetLength(0); f++)
        {
            for (int c = 0; c < tablero.GetLength(1); c++)
            {
                tablero[f, c] = 0;
            }
        }
    }

    static void Paso2_ColocarBarcos()
    {
        Random rnd = new Random();
        int cantidadBarcos = 0;
        switch (tablero.GetLength(0))
        {
            case 3:
                cantidadBarcos = 3; // cantidad de barcos de cada nivel 
                break;
            case 5:
                cantidadBarcos = 4;
                break;
            case 7:
                cantidadBarcos = 5;
                break;
            default:
                cantidadBarcos = 2;
                break;
        }

        for (int i = 0; i < cantidadBarcos; i++)
        {
            int fila = rnd.Next(0, tablero.GetLength(0));
            int columna = rnd.Next(0, tablero.GetLength(1));
            tablero[fila, columna] = 1;
        }
    }

    static void Paso3_ImprimirTablero()
    {
        Console.Clear();
        Console.WriteLine("Vidas: " + vidas + "\n\n");  //vidas=10
        String caracter_imprimir = "";
        for (int f = 0; f < tablero.GetLength(0); f++)
        {
            for (int c = 0; c < tablero.GetLength(1); c++)
            {
                switch (tablero[f, c])
                {
                    case 0:
                        caracter_imprimir = "~";
                        break;
                    case 1:
                        caracter_imprimir = "~";    //barco
                        break;
                    case -1:
                        caracter_imprimir = "*";
                        break;
                    case -2:
                        caracter_imprimir = "X";
                        break;
                    default:
                        caracter_imprimir = "~";
                        break;
                }
                Console.Write(caracter_imprimir + " ");
            }
            Console.WriteLine();
        }
    }

    static void Paso5_SonidoDerrota()
    {
        Console.WriteLine("sigue intentando....");      // cada vez que el usuario tenga un error aparecera este comentario quitandole una vida 
        Console.WriteLine("¡se te ha quitado una vida!");//
        for (int i = 0; i < 3; i++) 
        {
           
            Console.Beep(400, 300);     //400 frecuencia lo agudo del sonido al momento de tener un error y los 300 es la duracion del sonido
            System.Threading.Thread.Sleep(200); // pausa entre cada sonido
        }
    }
    static void MostrarMensajeBarcoEncontrado()
    {
        Console.WriteLine("¡Le diste a un barco!");// aparecera cuando el usiario acierte su tiro
    }
    static void Paso4_IngresoCoordenadas()
    {
        int fila, columna = 0;
        Console.Write("Ingrese la Fila: ");
        fila = Convert.ToInt32(Console.ReadLine());
        Console.Write("Ingresa la Columna: ");
        columna = Convert.ToInt32(Console.ReadLine());

        if (tablero[fila, columna] == 1)
        {
            Console.Beep();
            tablero[fila, columna] = -1;
            Console.WriteLine("Le diste a un barco") ;//
            System.Threading.Thread.Sleep(2000);     //frecuencia para duracion del beep 
            
        }
        else
        {
            tablero[fila, columna] = -2;
            vidas--;

            if (vidas > 0)
            {
                Paso5_SonidoDerrota(); 
            }
        }
        MostrarMensajeBarcoEncontrado();//cierre de la funcion de mostrar el mensaje del barco encontrado 
        Paso3_ImprimirTablero();
    }

    static void Main(string[] args)
    {
        Console.WriteLine("REGLAS DEL JUEGO \n relga #1 solo se permite un numero a la vez \n regla #2 el usuarion ingrese un numero positivo\n regla #3 solo tiene 10 vidas en cada nivel ");
        Console.WriteLine("Elije el que mas puedas ¡Diviertete!");// interface del juego 
        Console.WriteLine("\nTienes 10 intentos en cada nivel");
        Console.WriteLine("\n Elije el nivel de dificultad:");     
        Console.WriteLine("\n 1.super Fácil (5x5)");                
        Console.WriteLine("\n 2. Normal (10x10)");                  
        Console.WriteLine("\n 3. super Difícil (20x20)");          

        int opcion = Convert.ToInt32(Console.ReadLine());

        switch (opcion)   // un menu de opciones que el usuario pueda elegir el nivel de dificultad que desee
        {
            case 1:
                Paso1_CrearTablero(5);
                break;
            case 2:
                Paso1_CrearTablero(10);
                break;
            case 3:
                Paso1_CrearTablero(20);
                break;
            default:
                Console.WriteLine("si no colocas del 1 al 3 por defecto te saldra el nivel super facil.");  // juego por defecto 
                Paso1_CrearTablero(3);
                break;
        }

        Paso2_ColocarBarcos();
        Paso3_ImprimirTablero();

        while (vidas > 0)
        {
            Paso4_IngresoCoordenadas();
        }

        Console.WriteLine("Te quedaste sin vidas"); // mensaje cuando el usuarion ya no tiene vidas 



    }
}