using System.Xml;

namespace aula4.Entidades
{
    public partial class Animal : IExportarDados
    {
        public string ExportarCsv()
        {
            return RetornarDados();
        }

        public XmlElement ExportarXml(XmlDocument doc)
        {

            var xmlAnimal = doc.CreateElement("animal");

            var xmlNome = doc.CreateElement("Nome");
            xmlNome.InnerText = RetornarNome();
            xmlAnimal.AppendChild(xmlNome);

            var xmlIdade = doc.CreateElement("Idade");
            xmlIdade.InnerText = RetornarIdadeString();
            xmlAnimal.AppendChild(xmlIdade);

            var xmlSexo = doc.CreateElement("Sexo");
            xmlSexo.InnerText = RetornarSexoString();
            xmlAnimal.AppendChild(xmlSexo);

            return xmlAnimal;
        }

        public string SalvarDados()
        {
            return RetornarDadosSalvar();
        }
        public string ExportarEmail()
        {
            return RetornarDados();
        }

    }
}