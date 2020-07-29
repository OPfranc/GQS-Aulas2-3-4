using System.Collections.Generic;

using aula4.Entidades;

namespace aula4.Output
{
    public interface IExportar
    {
        string NomeArquivo { get; set; }

        void Exportar(List<IExportarDados> dados);
    }
}