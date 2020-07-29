using System;

namespace aula4.Entidades
{
    public class Entidade
    {

        private string Identificacao;
        private string Nome;
        private int Idade;
        private EnumSexo Sexo;


        public string RetornarIdentificacao() => Identificacao;
        public void AtribuirIdentificacao(string identificacao)
        {
            Identificacao = identificacao;
        }


        public string RetornarNome() => Nome;
        public void AtribuirNome(string nome)
        {
            Nome = nome;
        }


        public int RetornarIdade() => Idade;
        public string RetornarIdadeString() => RetornarIdade().ToString();
        public void AtribuirIdade(int idade)
        {
            Idade = idade;
        }


        public EnumSexo RetornarSexo() => Sexo;
        public string RetornarSexoString() => RetornarSexo().ToString();
        public void AtribuirSexo(EnumSexo sexo)
        {
            Sexo = sexo;
        }


        public int RetornarAnoNascimento() => DateTime.Now.Year - Idade;
        public string RetornarAnoNascimentoString() => (DateTime.Now.Year - Idade).ToString();


        public Entidade()
        {

        }
        public Entidade(string nome, int idade, EnumSexo sexo)
        {
            AtribuirNome(nome);
            AtribuirIdade(idade);
            AtribuirSexo(sexo);
        }
        public Entidade(string identificacao, string nome, int idade, EnumSexo sexo) : this(nome, idade, sexo)
        {
            AtribuirIdentificacao(identificacao);
        }

    }
}