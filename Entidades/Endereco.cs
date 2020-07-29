namespace ex1.Entidades
{
    public class Endereco
    {
        public string Rua { get; set; }

        public string Numero { get; set; }

        public string Cep { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public Endereco()
        {
            Rua = "nao informado";
            Numero = "nao informado";
            Cep = "nao informado";
            Cidade = "nao informado";
            Estado = "nao informado";
        }

        public Endereco(string cep)
        {
            Cep = cep;
        }

        public Endereco(string rua, string numero, string cep, string cidade, string estado)
        {
            Rua = rua;
            Cidade = cidade;
            Cep = cep;
            Estado = estado;
            Numero = numero;
        }
        public string RetornarDados()
        {
            return $"-- Endereço ----------------------\nRua: {Rua}, Numero:{Numero}\nCidade:{Cidade}/{Estado} CEP:({Cep})";
        }
    }
}
