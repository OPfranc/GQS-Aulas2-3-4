using System.IO;
using System.Collections.Generic;

using aula4.Entidades;

namespace aula4.Output
{
    public class SalvarDados : IExportar
    {
        public SalvarDados(string nomeArquivo)
        {
            NomeArquivo = nomeArquivo;
        }  
        public string NomeArquivo { get; set; }

        public void Exportar(List<IExportarDados> dados)
        {
            using (var file = new StreamWriter($"{NomeArquivo}"))
            {
                foreach (var dado in dados)
                {
                    file.WriteLine(dado.SalvarDados());
                }
            }
        }
    }
}