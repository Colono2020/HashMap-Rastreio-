//Aluno: Alison Civiero - 451219

using System;
using System.Collections.Generic;

namespace DictionaryRastreio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Dictionary<string, string> encomendas = new Dictionary<string, string>();

            while (true)
            {
                Console.WriteLine("\n===== SISTEMA DE RASTREIO DE ENCOMENDAS =====");
                Console.WriteLine("1 - Adicionar nova encomenda");
                Console.WriteLine("2 - Buscar encomenda");
                Console.WriteLine("3 - Listar das encomendas");
                Console.WriteLine("4 - Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                Console.WriteLine(); 

                switch (opcao)
                {
                    case "1":
                        CadastrarEncomenda(encomendas);
                        break;

                    case "2":
                        BuscarEncomenda(encomendas);
                        break;

                    case "3":
                        ListarEncomendas(encomendas);
                        break;

                    case "4":
                        Console.WriteLine("👋 concluido. Até logo!");
                        Console.WriteLine("Pressione qualquer tecla para fechar...");
                        Console.ReadKey();
                        return;

                    default:
                        Console.WriteLine("⚠ Opção inválida! Tente novamente.");
                        break;
                }
            }
        }

        static void CadastrarEncomenda(Dictionary<string, string> encomendas)
        {
            Console.Write("Digite o CÓDIGO DE RASTREIO: ");
            string rastreio = Console.ReadLine().Trim().ToUpper();

            Console.Write("Digite o CÓDIGO DE BARRAS da encomenda: ");
            string codigoBarras = Console.ReadLine().Trim().ToUpper();

            
            if (encomendas.ContainsKey(rastreio))
            {
                Console.WriteLine($"\n⚠ O rastreio '{rastreio}' já está cadastrado!");
                Console.WriteLine($"   Código de barras atual: {encomendas[rastreio]}");
                return;
            }

            
            foreach (var par in encomendas)
            {
                if (par.Value == codigoBarras)
                {
                    Console.WriteLine($"\n⚠ Já existe uma encomenda com o código de barras '{codigoBarras}'.");
                    Console.WriteLine($"   Ela está associada ao rastreio: {par.Key}");
                    return;
                }
            }

            encomendas.Add(rastreio, codigoBarras);
            Console.WriteLine($"\n✔ Encomenda cadastrada com sucesso!");
            Console.WriteLine($"   Rastreio: {rastreio} → Código de barras: {codigoBarras}");
        }

        static void BuscarEncomenda(Dictionary<string, string> encomendas)
        {
            if (encomendas.Count == 0)
            {
                Console.WriteLine("⚠ Nenhuma encomenda cadastrada ainda.");
                return;
            }

            Console.Write("Digite um CÓDIGO DE RASTREIO ou CÓDIGO DE BARRAS para buscar: ");
            string termo = Console.ReadLine().Trim().ToUpper();

            bool encontrado = false;

           
            if (encomendas.ContainsKey(termo))
            {
                Console.WriteLine($"\n🔎 Resultado da busca por RASTREIO:");
                Console.WriteLine($"   Rastreio: {termo}");
                Console.WriteLine($"   Código de barras: {encomendas[termo]}");
                encontrado = true;
            }
            else
            {
               
                foreach (var par in encomendas)
                {
                    if (par.Value == termo)
                    {
                        Console.WriteLine($"\n🔎 Resultado da busca por CÓDIGO DE BARRAS:");
                        Console.WriteLine($"   Código de barras: {termo}");
                        Console.WriteLine($"   Rastreio: {par.Key}");
                        encontrado = true;
                        break;
                    }
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("\n❌ Nenhuma encomenda encontrada para o termo informado.");
            }
        }

        static void ListarEncomendas(Dictionary<string, string> encomendas)
        {
            if (encomendas.Count == 0)
            {
                Console.WriteLine("⚠ Nenhuma encomenda cadastrada.");
                return;
            }

            Console.WriteLine("📦 Lista de encomendas cadastradas:");

            foreach (var par in encomendas)
            {
                Console.WriteLine($"   Rastreio: {par.Key}  |  Código de barras: {par.Value}");
            }
        }
    }
}



