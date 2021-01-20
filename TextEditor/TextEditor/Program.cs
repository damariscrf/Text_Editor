using System;
using System.IO;
using System.Threading;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("--------------------");
            Console.WriteLine("0 - Para Sair");
            Console.WriteLine("1 - Criar novo arquivo (Pressione Esc para sair)");
            Console.WriteLine("2 - Abrir");
            short opcao = short.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Editar(); break;
                case 2: Abrir(); break;
                default: Menu(); break;
            }
        }
        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto aqui");
            Console.WriteLine("(Para sair pressione Enter e depois Esc)");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += System.Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
            
            Salvar(text);
                      
        }
        static void Abrir() 
        {
            Console.Clear();
            Console.WriteLine("Escreva o caminho, nome do arquivo e a extenção (txt) do arquivo que deseja abrir");
            string path =  Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }
        static void Salvar(string text) {
            Console.Clear();
            Console.WriteLine("informe o local, nome do arquivo e a extenção (txt) para salvar");
            Console.WriteLine();
            Console.WriteLine(@"Exemplo c:\Caminho\arquivo.txt ");
            
            string path = Console.ReadLine();
                                   
            using(var file = new StreamWriter(path)) 
            {
                file.Write(text);
            }
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Salvo com sucesso!");
            Thread.Sleep(1000);
            Menu();
        }
    }
}

