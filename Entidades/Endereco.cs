namespace aula4.Entidades
{
    public class Endereco
    {
        private string Rua;
        private string Numero;
        private string Cep;
        private string Cidade;
        private string Estado;


        public string RetornarRua() => Rua;

        public void AtribuirRua(string rua)
        {
            Rua = rua;
        }


        public string RetornarNumero() => Numero;

        public void AtribuirNumero(string numero)
        {
            Numero = numero;
        }


        public string RetornarCep() => Cep;

        public void AtribuirCep(string cep)
        {
            Cep = cep;
        }


        public string RetornarCidade() => Cidade;

        public void AtribuirCidade(string cidade)
        {
            Cidade = cidade;
        }


        public string RetornarEstado() => Estado;

        public void AtribuirEstado(string estado)
        {
            Estado = estado;
        }


        public Endereco()
        {
            AtribuirRua("nao informado");
            AtribuirNumero("nao informado");
            AtribuirCep("nao informado");
            AtribuirCidade("nao informado");
            AtribuirEstado("nao informado");
        }

        public Endereco(string rua, string numero, string cep, string cidade, string estado)
        {
            AtribuirRua(rua);
            AtribuirNumero(numero);
            AtribuirCep(cep);
            AtribuirCidade(cidade);
            AtribuirEstado(estado);
        }
        public string RetornarDados()
        {
            return $"Endereço:\nRua: {Rua}, Numero:{Numero}\nCidade:{Cidade}/{Estado} CEP:({Cep})";
        }
        public string RetornaDadosSalvar()
        {
            return $"{Rua};{Numero};{Cep};{Cidade};{Estado}";
        }
    }
}
