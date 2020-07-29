
namespace aula4.Entidades
{
    public partial class Animal : Entidade
    {

        private string Registro;
        

        public string RetornarRegistro() => Registro;
        public void AtribuirRegistro(string registro)
        {
            Registro = registro;
        }


        public Animal()
        {
        
        }
        public Animal(string nome, int idade, EnumSexo sexo) : base(nome, idade, sexo)
        {

        }
        public Animal(string identificacao, string nome, int idade, EnumSexo sexo) : base(identificacao, nome, idade, sexo)
        {
            AtribuirRegistro(identificacao);
        }
        public Animal(string identificacao, Entidade entidade) : this(identificacao, entidade.RetornarNome(), entidade.RetornarIdade(), entidade.RetornarSexo())
        {

        }
        public Animal(string[] dadosCarregados)
        {
            AtribuirNome(dadosCarregados[1]);
            AtribuirRegistro(dadosCarregados[0]);
            AtribuirIdade(int.Parse(dadosCarregados[2]));
            AtribuirSexo(dadosCarregados[3] == "Masculino" ? EnumSexo.Masculino : EnumSexo.Feminino);
        }


         public string RetornarDadosSalvar()
        {
            return $"{Registro};{RetornarNome()};{RetornarIdadeString()};{RetornarSexoString()}";
        }

        private string RetornarRegistroNome()
        {
            return $"n de Registro: {Registro} - Nome: {RetornarNome()}";
        }

        private string RetornarDados()
        {
            return $"\nn de Registro: {Registro}\nNome: {RetornarNome()}\nIdade: {RetornarIdadeString()}({RetornarAnoNascimentoString()})\nSexo: {RetornarSexoString()}";
        }
            

    }
}