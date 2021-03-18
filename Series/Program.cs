using Series.Classes;
using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repo = new SerieRepositorio();

        static void Main(string[] args)
        {
            var opcao = ObterOcoesUsuario();

            while (opcao.ToUpper () != "X")
            {
                switch (opcao)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        RemoverSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcao = ObterOcoesUsuario();
            }
        }

        private static string ObterOcoesUsuario  ()
        {
            Console.WriteLine();
            Console.WriteLine("Series:");
            Console.WriteLine("Digite a opção");
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Adicionar série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Remover série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void ListarSeries ()
        {
            var lista = repo.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série encontrada");
                return;
            }

            foreach (var serie in lista)
            {
                Console.WriteLine("#ID {0}: {1} - {2}", serie.GetId(), serie.GetTitulo(),
                    serie.GetDescricao ());
            }
        }

        static void InserirSerie ()
        {
            Console.WriteLine("Inserir nova série");

            Console.WriteLine("Digite o gênero desta lista: ");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            int entGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string entTitulo = Console.ReadLine();

            Console.WriteLine("Digita o Ano da Série: ");
            int entAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entDesc = Console.ReadLine();

            Serie serie = new Serie(id: repo.ProximoId(),
                gen: (Genero)entGenero,
                titulo: entTitulo,
                ano: entAno,
                desc: entDesc);

            repo.Insere(serie);
        }

        static void AtualizarSerie()
        {
            ListarSeries();
            var serie = RequestUserSerie();

            var rawGen = Console.ReadLine();            
            if (rawGen != null)
            {
                serie.UpdateGenero((Genero)(int.Parse(rawGen)));
            }

            Console.WriteLine("Digite o novo Título da Série ou pressione Enter: ");
            string entTitulo = Console.ReadLine();
            if (entTitulo != null)
            {
                serie.UpdateTitulo(entTitulo);
            }

            Console.WriteLine("Digita o novo Ano da Série ou pressione Enter: ");
            var rawAno = Console.ReadLine();            
            if (rawAno != null)
            {
                serie.UpdateAno(int.Parse(rawAno));
            }

            Console.WriteLine("Digite a nova Descrição da Série ou pressione Enter: ");
            string entDesc = Console.ReadLine();
            if (entDesc != null)
            {
                serie.UpdateDesc(entDesc);
            }
        }
        static void RemoverSerie()
        {
            ListarSeries();

            Console.WriteLine("Escolha o ID da Série");
            var rid = int.Parse(Console.ReadLine());

            if (rid >= repo.ProximoId())
                throw new ArgumentOutOfRangeException();

            repo.Excluir(rid);
        }
        static void VisualizarSerie()
        {
            ListarSeries();

            var serie = RequestUserSerie();

            Console.WriteLine("#ID {0} Titulo:{1} - Descrição:{2}, Ano:{3}", serie.GetId(), 
                serie.GetTitulo(), 
                serie.GetDescricao(),
                serie.GetAno());
        }

        static Serie RequestUserSerie()
        {
            Console.WriteLine("Escolha o ID da Série");
            var rid = int.Parse(Console.ReadLine());

            if (rid >= repo.ProximoId())
                throw new ArgumentOutOfRangeException();

            var serie = repo.RetornaPorId(rid);

            if (serie.GetExcluido())
                throw new ArgumentException();

            return serie;
        }

    }
}
