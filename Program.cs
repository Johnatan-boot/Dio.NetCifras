using System;

namespace DIO.CIFRASNET
{
    class Program
    {
        static CifrasRepositorio repositorio = new CifrasRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarCifras();
						break;
					case "2":
						InserirCifras();
						break;
					case "3":
						AtualizarCifras();
						break;
					case "4":
						ExcluirCifras();
						break;
					case "5":
						VisualizarCifras();
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

        private static void ExcluirCifras()
		{
			Console.Write("Digite o id da Cifra: ");
			int indiceCifra = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceCifra);
		}

        private static void VisualizarCifras()
		{
			Console.Write("Digite o id da Cifra: ");
			int indiceCifra = int.Parse(Console.ReadLine());

			var Cifras = repositorio.RetornaPorId(indiceCifra);

			Console.WriteLine(Cifras);
		}

        private static void AtualizarCifras()
		{
			Console.Write("Digite o id da Cifra: ");
			int indiceCifra = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o Número que Corresponde ao Genêro Musical  entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Música: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Informe o Cantor da Música: ");
			string entradaCantor = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Música: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Cifra: ");
			string entradaDescricao = Console.ReadLine();

			Cifras atualizaCifra = new Cifras(id: indiceCifra,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										Cantor: entradaCantor,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceCifra, atualizaCifra);
		}
        private static void ListarCifras()
		{
			Console.WriteLine("LISTAR CIFRAS");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma Cifra cadastrada.");
				return;
			}

			foreach (var Cifras in lista)
			{
                var excluido = Cifras.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", Cifras.retornaId(), Cifras.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirCifras()
		{
			Console.WriteLine("INSERIR NOVA CIFRA");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o Número que Corresponde ao Genêro Musical  entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Musica: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Informe o Cantor da Música: ");
			string entradaCantor = Console.ReadLine();

			Console.Write("Digite o Ano da Musica: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da CIFRA: ");
			string entradaDescricao = Console.ReadLine();

			Cifras novaCifra = new Cifras(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										Cantor: entradaCantor,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaCifra);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO CIFRAS A SEU DISPOR!!!");
			Console.WriteLine("INFORME A OPÇÃO DESEJADA:");

			Console.WriteLine("1- LISTAR CIFRAS");
			Console.WriteLine("2- INSERIR NOVA CIFRA");
			Console.WriteLine("3- ATUALIZAR CIFRAS");
			Console.WriteLine("4- EXCLUIR CIFRAS");
			Console.WriteLine("5- VISUALIZAR CIFRAS");
			Console.WriteLine("C- LIMPAR TELA");
			Console.WriteLine("X- SAIR");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
