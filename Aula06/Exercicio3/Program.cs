using System;
using System.IO;

namespace Exercicio3
{
    class Program
    {
        // Nomes dos ficheiros
        private const string filenameText = "text_file_lp2.txt";
        private const string filenameBinary = "text_file_lp2.bin";

        // Dados a escrever e ler nos ficheiros
        private const string dataString = "This is a string";
        private const int dataInt = 11;
        private const float dataFloat = 15.33f;


        static void Main(string[] args)
        {
            // String para onde ler opção inserida pelo utilizador
            string option;

            // Ciclo do menu principal
            do
            {
                // Apresentar menu principal
                Console.WriteLine("==== Que programa devo executar? ==== \n");
                Console.WriteLine("\t1. Escreve ficheiro em modo de texto");
                Console.WriteLine("\t2. Lê ficheiro em modo de texto");
                Console.WriteLine("\t3. Escreve ficheiro em modo binário");
                Console.WriteLine("\t4. Lê ficheiro em modo binário");
                Console.WriteLine("\t5. Sair");
                Console.Write("\n>");

                // Solicitar opção ao utilizador
                option = Console.ReadLine();

                // Tratar opção do utilizador
                switch (option)
                {
                    case "1":
                        Option1(); break;
                    case "2":
                        Option2(); break;
                    case "3":
                        Option3(); break;
                    case "4":
                        Option4(); break;
                    case "5":
                        Console.WriteLine("Obrigado e até à próxima!");
                        break;
                    default:
                        Console.WriteLine("**** Opção inválida! ****");
                        break;
                }

                Console.WriteLine(
                    "Pressione qualquer tecla para continuar...");
                Console.ReadKey();

            } while (option != "5");
        }

        // 1. Escreve ficheiro em modo de texto
        private static void Option1()
        {
            StreamWriter sw = File.CreateText(filenameText);
            sw.WriteLine(dataString);
            sw.WriteLine(dataInt);
            sw.WriteLine(dataFloat);
            sw.Close();
        }

        // 2. Lê ficheiro em modo de texto
        private static void Option2()
        {
            StreamReader sr = File.OpenText(filenameText);
            Console.WriteLine(sr.ReadLine());
            Console.WriteLine(Convert.ToInt32(sr.ReadLine()));
            Console.WriteLine(Convert.ToSingle(sr.ReadLine()));
            sr.Close();
        }

        // 3. Escreve ficheiro em modo binário
        private static void Option3()
        {
            BinaryWriter bw = new BinaryWriter(File.Create(filenameBinary));
            bw.Write(dataString);
            bw.Write(dataInt);
            bw.Write(dataFloat);
            bw.Close();
        }

        // 4. Lê ficheiro em modo binário
        private static void Option4()
        {
            BinaryReader br = new BinaryReader(
                File.Open(filenameBinary, FileMode.Open));
            Console.WriteLine(br.ReadString());
            Console.WriteLine(br.ReadInt32());
            Console.WriteLine(br.ReadSingle());
            br.Close();
        }
    }
}
