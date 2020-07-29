using System.IO;
using System.Collections.Generic;

using aula4.Entidades;

namespace aula4.Output
{
    public class ExportarCsv : IExportar
    {
        public string NomeArquivo { get; set; }

        public ExportarCsv(string nomeArquivo)
        {
            NomeArquivo = nomeArquivo;
        }

        public void Exportar(List<IExportarDados> dados)
        {
            using (var file = new StreamWriter($"{NomeArquivo}.csv"))
            {
                foreach (var dado in dados)
                {
                    file.WriteLine(dado.ExportarCsv());
                }
            }
        }
    }
}