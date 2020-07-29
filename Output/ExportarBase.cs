using System;
using System.Collections.Generic;

using aula4.Entidades;

namespace aula4.Output
{
    public class ExportarBase
    {
        public string NomeArquivo { get; private set; }

        public ExportarBase(string nomeArquivo)
        {
            NomeArquivo = nomeArquivo;
        }

        public virtual void Exportar(List<Cliente> clientes)
        {
            throw new NotImplementedException();
        }
    }
}