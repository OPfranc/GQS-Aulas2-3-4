using System;
using System.Linq;

using aula4.Entidades;

namespace aula4.Telas
{

    public partial class Tela
    {
        private void ListarEntidades()
        {
            foreach (var entidade in Entidades)
            {
                Escrever(entidade.RetornoParaListagem());
            }
        }
        private void AlterarEntidade(IEntidade entidadeAAlterar)
        {

            entidadeAAlterar = (IEntidade)LerDadosEntidade();

            if (TipoEntidade == EnumTipoEntidade.Cliente)
            {
                LerDadosCliente((Cliente)entidadeAAlterar);
            }
        }

        private void Alterar()
        {
            var executando = true;
            do
            {
                Titulo($"-- Alterando informacoes do {RetornarTipoEntidadeString()} --", CorTitulo);
                ListarEntidades();

                var identificacao = LerString($"Informe o {TipoIdentificador} a ser Alterado. (deixe em branco caso queira voltar)");
                if (string.IsNullOrWhiteSpace(identificacao))
                {
                    executando = false;
                }
                else
                {
                    var entidadeAAlterar = BuscarEntidade(identificacao);
                    if (entidadeAAlterar != null)
                    {
                        AlterarEntidade(entidadeAAlterar);
                        AguardarTecla($"{RetornarTipoEntidadeString()} alterado com sucesso.", ConsoleColor.Green);
                    }
                    else
                    {
                        AguardarTecla($"{RetornarTipoEntidadeString()} não encontrado.", ConsoleColor.DarkRed);
                    }
                }
            } while (executando);

        }

        private void DetalhesEntidade(string identificacao)
        {
            var entidadeADetalhar = BuscarEntidade(identificacao);
            if (entidadeADetalhar == null)
            {
                AguardarTecla($"{RetornarTipoEntidadeString()} nao encontrado", ConsoleColor.DarkRed);
                return;
            }
            Titulo($"-- Informacoes do {RetornarTipoEntidadeString()} --", CorTitulo);
            Escrever(entidadeADetalhar.RetornoParaDetalhes());

            var opcao = LerInt("Você gostaria de modificar as informacoes? (1 - sim / 2 - Não)");
            if (opcao == 1)
            {
                AlterarEntidade(entidadeADetalhar);
            }

        }


        private IEntidade BuscarEntidade(string identificacao)
        {
            return Entidades
                    .Where(entidade => entidade.RetornaIdentificacao() == identificacao)
                    .FirstOrDefault();
        }

        private void Listar()
        {
            Titulo($"-- Listando --", CorTitulo);
            ListarEntidades();

            var opcao = LerInt("Você gostaria de mais informacoes? (1 - sim / 2 - Não)");
            if (opcao == 1)
            {
                var identificacao = LerString($"Informe o {TipoIdentificador} do {RetornarTipoEntidadeString()}");
                DetalhesEntidade(identificacao);
            }
        }

        private void InserirNovo()
        {
            var executando = true;
            do
            {
                Titulo($"-- Criando novo {RetornarTipoEntidadeString()} --", CorTitulo);
                if (!LerDados())
                {
                    continue;
                }

                Escrever($"{RetornarTipoEntidadeString()} inserido com sucesso", ConsoleColor.Green, espacoEmBranco: 2);

                var opcao = LerInt($"Gostaria de adicionar outro {RetornarTipoEntidadeString()}? (1 - sim / 2 - Não)");
                if (opcao == 2)
                    executando = false;

            } while (executando);
        }
        private void Remover()
        {
            var executando = true;
            do
            {
                Titulo($"-- Remover {RetornarTipoEntidadeString()} --", CorTitulo);
                ListarEntidades();

                var identificacao = LerString($"Informe o {TipoIdentificador} a ser removido. (deixe em branco caso queira voltar)");
                if (string.IsNullOrWhiteSpace(identificacao))
                {
                    executando = false;
                }
                else
                {
                    var entidadeARemover = BuscarEntidade(identificacao);
                    if (entidadeARemover != null)
                    {
                        Entidades.Remove(entidadeARemover);
                        AguardarTecla($"{RetornarTipoEntidadeString()} removido com sucesso.", ConsoleColor.Green);
                    }
                    else
                    {
                        AguardarTecla($"{RetornarTipoEntidadeString()} não encontrado.", ConsoleColor.DarkRed);
                    }
                }
            } while (executando);
        }
    }
}
