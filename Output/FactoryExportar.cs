namespace aula4.Output
{
    public class FactoryExportar
    {
        public static IExportar RetornarExportador(EnumTipoExportacao tipo, string nomeArquivo, string[] emailDados = default(string[]))
        {
            IExportar exporta;

            switch (tipo)
            {
                case EnumTipoExportacao.Csv:
                    exporta = new ExportarCsv(nomeArquivo);
                    break;

                case EnumTipoExportacao.SalvarDados:
                    exporta = new SalvarDados(nomeArquivo);
                    break;

                case EnumTipoExportacao.Email:
                    exporta = new ExportarEmail(nomeArquivo, mailOrigem : emailDados[0], mailSenha : emailDados[1], mailDestino : emailDados[2], mailAssunto : emailDados[3], mailCorpo : emailDados[4]);
                    break;

                default:
                    exporta = new ExportarXml(nomeArquivo);
                    break;
            }

            return exporta;
        }
    }
}