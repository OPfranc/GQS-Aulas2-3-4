using System.Xml;
using System.Collections.Generic;

using aula4.Entidades;

namespace aula4.Output
{
    public class ExportarXml : IExportar
    {
        public string NomeArquivo { get; set; }

        public ExportarXml(string nomeArquivo)
        {
            NomeArquivo = nomeArquivo;
        }
        public void Exportar(List<IExportarDados> dados)
        {
            var doc = new XmlDocument();

            var xmlDado = doc.CreateElement("dados");
            doc.AppendChild(xmlDado);

            foreach (var item in dados)
            {
                xmlDado.AppendChild(item.ExportarXml(doc));
            }

            doc.Save($"{NomeArquivo}.xml");
        }
    }
}