namespace aula4.Entidades
{
    public partial class Animal : IEntidade
    {

        public string RetornoParaListagem()
        {
            return RetornarRegistroNome();
        }

        public string RetornaIdentificacao()
        {
            return RetornarRegistro();
        }

        public string RetornoParaDetalhes()
        {
            return RetornarDados();
        }
    }
}
