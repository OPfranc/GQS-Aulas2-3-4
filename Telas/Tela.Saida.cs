using System;
using System.IO;
using System.Linq;

using aula4.Output;
using aula4.Entidades;

namespace aula4.Telas
{

    public partial class Tela
    {
        private void SalvarEntidades()
        {
            try
            {
                if (!File.Exists($"{RetornarTipoEntidadeString().ToLower()}dados"))
                {
                    File.Delete($"{RetornarTipoEntidadeString().ToLower()}dados");
                }
                IExportar exportador = FactoryExportar.RetornarExportador(EnumTipoExportacao.SalvarDados, $"{RetornarTipoEntidadeString().ToLower()}dados");
                exportador.Exportar(Entidades.Cast<IExportarDados>().ToList());
            }
            catch (System.Exception)
            {
                Escrever("Erro ao Salvar na memoria", ConsoleColor.DarkRed);
            }
        }

        private void ExportarDados()
        {
            Titulo("-- Exportação de dados --", CorTitulo);

            var opt = LerInt("1 - CSV / 2 - Xml / 3 - e-mail");

            var nomeArquivo = LerString("Qual o nome do arquivo?");
            var emailDados = new string[5];

            if (opt == 3)
            {
                emailDados[0] = LerString("Informe seu endereco de e-mail");
                emailDados[1] = LerString("Informe sua senha");
                emailDados[2] = LerString("Informe o endereco de e-mail destino");
                emailDados[3] = LerString("Adicione o assunto da mensagem");
                emailDados[4] = LerString("Escreva o corpo da mensagem");
            }

            IExportar exportador = FactoryExportar.RetornarExportador((EnumTipoExportacao)opt - 1, nomeArquivo, emailDados);
            exportador.Exportar(Entidades.Cast<IExportarDados>().ToList());

        }

    }
}