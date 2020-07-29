namespace aula4.Entidades
{
    public partial class Cliente : IEntidade
    {

        public string RetornoParaListagem()
        {
            return RetornarCpfNome();
        }

        public string RetornaIdentificacao()
        {
            return RetornarCpf();
        }

        public string RetornoParaDetalhes()
        {
            return RetornarDados();
        }

    }
}
