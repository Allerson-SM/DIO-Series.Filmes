using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static FilmeRepositorio frepositorio = new FilmeRepositorio();

        static void Main(string[] args)
        {
            Menu();
        }
        #region Series
        private static void ExcluirSerie()
        {
            Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
            Console.WriteLine("Série excluída com sucesso!");
            Console.ReadLine();
            ObterOpcaoUsuario();
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
            Console.ReadLine();
            ObterOpcaoUsuario();
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}.{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Series atualizaSerie = new Series(id: indiceSerie,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
            Console.WriteLine("Série atualizada com sucesso!");
            Console.ReadLine();
            ObterOpcaoUsuario();
        }
        private static void ListarSerie()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                Console.ReadLine();
                ObterOpcaoUsuario();
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
                Console.ReadLine();
                ObterOpcaoUsuario();
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}.{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(id: repositorio.ProximoId(),
                                          genero: (Genero)entradaGenero,
                                          titulo: entradaTitulo,
                                          ano: entradaAno,
                                          descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
            Console.WriteLine("Série cadastrada com sucesso!");
            Console.ReadLine();
            ObterOpcaoUsuario();
        }

        private static void ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries ao seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Voltar");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();

            Console.WriteLine();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        ObterOpcaoUsuario();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                //opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar o serviço DIO Séries, voltando ao início...");
            Console.ReadLine();
            Menu();
            //return opcaoUsuario;
        }
        #endregion
        #region Filmes

        private static void ExcluirFilme()
        {
            Console.Write("Digite o ID do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            frepositorio.Exclui(indiceFilme);
            Console.WriteLine("Filme excluído com sucesso!");
            Console.ReadLine();
            ObterOpcaoUsuarioFilme();
        }

        private static void VisualizarFilme()
        {
            Console.Write("Digite o ID do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = frepositorio.RetornaPorId(indiceFilme);

            Console.WriteLine(filme);
            Console.ReadLine();
            ObterOpcaoUsuarioFilme();
        }

        private static void AtualizarFilme()
        {
            Console.Write("Digite o id do filme ");
            int indiceFilme = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}.{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Filmes atualizaFilme = new Filmes(id: indiceFilme,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

            frepositorio.Atualiza(indiceFilme, atualizaFilme);
            Console.WriteLine("Filme atualizado com sucesso!");
            Console.ReadLine();
            ObterOpcaoUsuarioFilme();
        }
        private static void ListarFilme()
        {
            Console.WriteLine("Listar filmes");

            var lista = frepositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado");
                Console.ReadLine();
                ObterOpcaoUsuarioFilme();
            }

            foreach (var filmes in lista)
            {
                var excluido = filmes.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}", filmes.retornaId(), filmes.retornaTitulo(), (excluido ? "*Excluído*" : ""));
                Console.ReadLine();
                ObterOpcaoUsuarioFilme();
            }
        }

        private static void InserirFilme()
        {
            Console.WriteLine("Inserir novo filme");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}.{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título do filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição do filme: ");
            string entradaDescricao = Console.ReadLine();

            Filmes novoFilme = new Filmes(id: frepositorio.ProximoId(),
                                          genero: (Genero)entradaGenero,
                                          titulo: entradaTitulo,
                                          ano: entradaAno,
                                          descricao: entradaDescricao);

            frepositorio.Insere(novoFilme);

            Console.Write("Filme cadastrado com sucesso!");
            Console.ReadLine();
            ObterOpcaoUsuarioFilme();
        }

        private static void ObterOpcaoUsuarioFilme()
        {
            Console.WriteLine();
            Console.WriteLine("DIO filmes ao seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar filmes");
            Console.WriteLine("2 - Inserir novo filme");
            Console.WriteLine("3 - Atualizar filme");
            Console.WriteLine("4 - Excluir filme");
            Console.WriteLine("5 - Visualizar filme");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Voltar");
            Console.WriteLine();

            string opcaoUsuarioFilme = Console.ReadLine().ToUpper();

            Console.WriteLine();

            while (opcaoUsuarioFilme.ToUpper() != "X")
            {
                switch (opcaoUsuarioFilme)
                {
                    case "1":
                        ListarFilme();
                        break;
                    case "2":
                        InserirFilme();
                        break;
                    case "3":
                        AtualizarFilme();
                        break;
                    case "4":
                        ExcluirFilme();
                        break;
                    case "5":
                        VisualizarFilme();
                        break;
                    case "C":
                        Console.Clear();
                        ObterOpcaoUsuarioFilme();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                //opcaoUsuario = ObterOpcaoUsuario();

            }
            Console.WriteLine("Obrigado por utilizar o serviço DIO Filmes, voltando ao início...");
            Console.ReadLine();
            Menu();
            //return opcaoUsuario;
        }
        #endregion
        private static void Menu()
        {
            Console.WriteLine("Seja bem-vindo!");
            Console.WriteLine("Informe uma das opções abaixo para navegar entre os itens.");
            Console.WriteLine("1 - Filmes");
            Console.WriteLine("2 - Séries");
            Console.WriteLine("X - Sair");

            string menu = Console.ReadLine().ToUpper();

            while (menu.ToUpper() != "X")
            {
                switch (menu)
                {
                    case "1":
                        ObterOpcaoUsuarioFilme();
                        break;
                    case "2":
                        ObterOpcaoUsuario();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
            Environment.Exit(0);
        }

    }
}
