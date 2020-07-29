using System;
using System.Collections.Generic;

using aula4.Entidades;

namespace aula4.Telas
{

    public partial class Tela : TelaBase
    {

        private static Tela _instance;
        private List<IEntidade> Entidades;
        private EnumTipoEntidade TipoEntidade;
        private ConsoleColor CorTitulo;
        private string TipoIdentificador;


        public EnumTipoEntidade RetornarTipoEntidade() => TipoEntidade;
        public string RetornarTipoEntidadeString() => TipoEntidade.ToString();
        public void AtribuirTipoEntidade(EnumTipoEntidade tipoEntidade)
        {
            TipoEntidade = tipoEntidade;
        }


        public ConsoleColor RetornarCorTitulo() => CorTitulo;
        public void AtribuirCorTitulo(ConsoleColor corTitulo)
        {
            CorTitulo = corTitulo;
        }


        public string RetornarTipoIdentificador() => TipoIdentificador;
        public void AtribuirTipoIdentificador(string tipoIdentificador)
        {
            TipoIdentificador = tipoIdentificador;
        }


        protected Tela(EnumTipoEntidade tipoEntidade)
        {

            Entidades = new List<IEntidade>();
            AtribuirTipoEntidade(tipoEntidade);
            AtribuirCorTitulo(TipoEntidade == EnumTipoEntidade.Animal ? ConsoleColor.DarkGreen : ConsoleColor.DarkCyan);
            AtribuirTipoIdentificador(TipoEntidade == EnumTipoEntidade.Animal ? "n de Registro" : "CPF");
            CarregarEntidades();
        }

        public static Tela Instance(EnumTipoEntidade tipoEntidade)
        {
            if (_instance == null)
            {
                _instance = new Tela(tipoEntidade);
            }
            return _instance;
        }

        public void ResetInstance()
        {
            _instance = null;

        }
        public void Executar()
        {
            var executando = true;
            do
            {
                Titulo($"-- Menu de opções --", CorTitulo);
                Escrever($"1 - Listar");
                Escrever($"2 - Inserir");
                Escrever($"3 - Remover");
                Escrever($"4 - Alterar");
                Escrever($"5 - Exportar");
                Escrever($"6 - Salvar Lista");
                Escrever($"7 - Voltar");
                Escrever($"0 - Sair");

                var opcao = LerInt();

                switch (opcao)
                {
                    case 1:
                        Listar();
                        break;

                    case 2:
                        InserirNovo();
                        break;

                    case 3:
                        Remover();
                        break;

                    case 4:
                        Alterar();
                        break;

                    case 5:
                        ExportarDados();
                        break;

                    case 6:
                        SalvarEntidades();
                        break;
                    case 7:
                        Sair();
                        executando = false;
                        break;

                    case 0:
                        Sair();
                        Environment.Exit(0);
                        break;

                    default:
                        OpcaoInvalida();
                        break;

                }

            } while (executando);
        }

        private void Sair()
        {
            var opcao = LerInt("Gostaria de Salvar antes de sair? (1 - sim / 2 - Não)", ConsoleColor.DarkYellow);
            if (opcao == 1)
            {
                SalvarEntidades();
            }
            ResetInstance();

        }
    }
}