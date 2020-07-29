using System.Xml;

namespace aula4.Entidades
{
    public partial class Cliente : IExportarDados
    {
        public string ExportarCsv()
        {
            return RetornarDados();
        }
        public XmlElement ExportarXml(XmlDocument doc)
        {

            var xmlCliente = doc.CreateElement("cliente");

            var xmlCpf = doc.CreateElement("Cpf");
            xmlCpf.InnerText = RetornarCpf();
            xmlCliente.AppendChild(xmlCpf);

            var xmlNome = doc.CreateElement("Nome");
            xmlNome.InnerText = RetornarNome();
            xmlCliente.AppendChild(xmlNome);

            var xmlIdade = doc.CreateElement("Idade");
            xmlIdade.InnerText = RetornarIdadeString();
            xmlCliente.AppendChild(xmlIdade);

            var xmlSexo = doc.CreateElement("Sexo");
            xmlSexo.InnerText = RetornarSexoString();
            xmlCliente.AppendChild(xmlSexo);

            var xmlCarteiraMotorista = doc.CreateElement("CarteiraMotorista");
            xmlCarteiraMotorista.InnerText = RetornarCarteiraMotoristaString();
            xmlCliente.AppendChild(xmlCarteiraMotorista);

            var xmlCarteiraReservista = doc.CreateElement("CarteiraReservista");
            xmlCarteiraReservista.InnerText = RetornarCarteiraReservistaString();
            xmlCliente.AppendChild(xmlCarteiraReservista);

            return xmlCliente;
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