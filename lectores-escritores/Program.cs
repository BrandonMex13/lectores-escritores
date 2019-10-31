using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lectores_escritores
{
    class Program
    {
        static Random numrandom = new Random();
        static int contadorescritores = 0;

        static int max;
        static int frente;
        static int atras;
        static int posicion = 0;
        static int[] elem;

        static int ultimo; // nueva variable

        static void crear(int n)
        {
            elem = new int[n];
            max = n - 1;
            frente = -1;
            atras = -1;
        }

        static void encolar( int x)
        {
            frente = 0;

            string nombre;
            if ( x == 0)
            {
                nombre = "Lector";
            }
            else
            {
                nombre = "Escritor";
            }
            if (atras < max)
            {
                atras++;
                elem[atras] = x;
                Console.WriteLine("Encolado: {0}", nombre);
            }
            else if (atras == max && atras != frente)
            {
                if (elem[0] == 0)
                {
                    atras = 0;
                    elem[atras] = x;
                    Console.WriteLine("Encolado: {0}", nombre);
                }
            }
            else
                Console.WriteLine("cola llena");


        }

        static int desencolar()
        {
            int x = -1;
            if (atras > -1)
            {
                try
                {
                    elem[frente] = 0;
                    frente++;
                    //c.frente = 0;
                    //c.atras--;
                }
                catch
                {
                    imprimir();
                }
            }
            else
                Console.WriteLine("Cola vacia");
            return x;
        }

        static void imprimir()
        {
            if (frente == -1 && atras == -1)
            {
                Console.WriteLine("La cola esta vacia...");
                elem[0] = 0;
            }
            else
            {
                posicion = 0;
                if (frente < atras)
                {
                    for (int a = 0; a <= max; a++)
                    {
                        if (elem[a] != 0)
                        {
                            if (elem[a] == 1)
                            {
                                Console.WriteLine("Posicion {0}: Escritor", posicion);
                            }
                            else
                            {
                                Console.WriteLine("Posicion {0}: Lector", posicion);
                            }
                            posicion++;
                        }
                    }
                }
                else
                {
                    for (int a = max; a >= 0; a--)
                    {
                        if (elem[a] != 0)
                        {
                            if (elem[a] == 0)
                            {
                                Console.WriteLine("Posicion {0}: Lector", posicion);
                            }
                            else
                            {
                                Console.WriteLine("Posicion {0}: Escritor", posicion);
                            }
                            posicion++;
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                int turno;
                int temp;

                Console.WriteLine("¿Cuantos lectores habra?");
                int lectores = numrandom.Next(5,9);
                Console.WriteLine("Habra: {0}", lectores);
                //int lectores = Int16.Parse(Console.ReadLine());
                int contadorlectores = 0;
                temp = lectores;

                crear(lectores);

                while (true)
                {
                    turno = numrandom.Next(0, 2);

                    if (turno == 0)
                    {
                        if (lectores > 0)
                        {
                            encolar(0);
                            imprimir();
                            lectores--;
                            contadorlectores++;
                        }
                    }
                    else if (turno == 1)
                    {
                        if (contadorescritores == 0)
                        {
                            if (elem[0] != 0)
                            {
                                encolar(1);
                                imprimir();
                                desencolar();
                                Console.WriteLine("Un Escritor SALIO");
                                contadorescritores++;
                            }
                            else if (contadorlectores > 0)
                            {
                                Console.WriteLine("No puede entrar el ESCRITOR por que hay LECTORES en la cola");
                            }
                            else
                            {
                                encolar(1);
                                //imprimir();
                                desencolar();
                                Console.WriteLine("Un Escritor SALIO");
                                contadorescritores++;
                            }

                        }
                        else if (contadorlectores == 1)
                        {
                            Console.WriteLine("Ya no hay escritores...");
                            contadorlectores++;
                        }


                    }

                    //Console.WriteLine(contadorlectores);
                    if (lectores == 0)
                    {
                        for (int a = 0; a < contadorlectores; a++)
                        {
                            desencolar();
                            Console.WriteLine("Un Lector Salio...");
                        }
                        lectores = -1;
                        contadorlectores = 0;
                        break;
                    }

                    //Console.ReadKey();
                }
                contadorescritores = 0;
                System.Threading.Thread.Sleep(4000);
                //Console.ReadKey();
                Console.Clear();
            }
            
            
        }
    }
}

// lector = 1
// escritor = 2