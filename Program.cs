using System;
using System.Linq;

namespace DIO.Musicas
{
    class Program
    {
        static BandaRepositorio repositorio = new BandaRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarBandas();
						break;
					case "2":
						InserirBanda();
						break;
					case "3":
						AtualizarBanda();
						break;
					case "4":
						ExcluirBanda();
						break;
					case "5":
						VisualizarBanda();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirBanda()
		{
			Console.Write("Digite o id da banda: ");
			int indiceBanda = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceBanda);
		}

        private static void VisualizarBanda()
		{
			Console.Write("Digite o id da banda: ");
			int indicebanda = int.Parse(Console.ReadLine());

			var banda = repositorio.RetornaPorId(indicebanda);

			Console.WriteLine(banda);
		}

        private static void AtualizarBanda()
		{
			Console.Write("Digite o id da banda: ");
			int indicebanda = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome da banda: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o nome dos integrantes da banda (separados por virgula)");
			string entredaIntegrantes = Console.ReadLine();
			var integrantes = entredaIntegrantes.Split(",").Select(nome => new Integrante(nome)).ToList();

			Banda atualizaBanda = new Banda(id: indicebanda,
											genero: (Genero)entradaGenero,
											nome: entradaNome,																				
											atores:integrantes);

			repositorio.Atualiza(indicebanda, atualizaBanda);
		}

        private static void ListarBandas()
		{
			Console.WriteLine("Listar bandas");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma banda cadastrada.");
				return;
			}

			foreach (var banda in lista)
			{
                var excluido = banda.RetornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", banda.RetornaId(), banda.RetornaNome(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirBanda()
		{
			Console.WriteLine("Inserir nova banda");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome da banda: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o nome dos integrantes da banda (separados por virgula)");
			string entredaIntegrantes = Console.ReadLine();
			var integrantes = entredaIntegrantes.Split(",").Select(a => new Integrante(a)).ToList();

			Banda novaBanda = new Banda(id: repositorio.ProximoId(),
											genero: (Genero)entradaGenero,
											nome: entradaNome,
											atores: integrantes);

			repositorio.Insere(novaBanda);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO bandas a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar bandas");
			Console.WriteLine("2- Inserir nova banda");
			Console.WriteLine("3- Atualizar banda");
			Console.WriteLine("4- Excluir banda");
			Console.WriteLine("5- Visualizar banda");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
