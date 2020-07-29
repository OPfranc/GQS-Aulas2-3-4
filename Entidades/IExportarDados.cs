using System.Xml;

namespace aula4.Entidades
{
    public interface IExportarDados
    {
        string ExportarCsv();

        XmlElement ExportarXml(XmlDocument doc);
        
        string SalvarDados();

        string ExportarEmail();
    }
}