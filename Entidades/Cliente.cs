using System;

namespace ex1.Entidades
{
    public class Cliente
    {
        private string Cpf;
        private string Nome;
        private int Idade;
        private EnumSexo Sexo;
        private int NumeroCarteiraMotorista;
        private int CarteiraReservista;
        private Endereco Endereco;
        
        public Cliente(string cpf, string nome, int idade, EnumSexo sexo)
        {            
            Cpf = cpf;
            Nome = nome;
            Idade = idade;
            Sexo = sexo;
        }

        public Cliente(string cpf, string nome, int idade, EnumSexo sexo, Endereco endereco) : this(cpf, nome, idade, sexo)
        {
            Endereco = endereco;            
        }

        public bool PossuiMaioridade()
        {
            return (Idade >= 18);
        }

        public bool PossuiCarteiraReservista(){

            if(!PossuiMaioridade())
                return false;

            if(Sexo == EnumSexo.Feminino)
                return false;

            return true;
        }
        
        public bool PossuiCarteiraMotorista(){
            
            if(!PossuiMaioridade())
                return false;

            return true;
        }
        public void AdicionarCarteiraReservista(int carteiraReservista)
        {
            CarteiraReservista = carteiraReservista;
        }

        public void AdicionarCarteiraMotorista(int numeroCarteiraMotorista)
        {
            NumeroCarteiraMotorista = numeroCarteiraMotorista;            
        }

        public string RetornarDados()
        {
            var carteiraMotorista = PossuiMaioridade() 
                ? NumeroCarteiraMotorista.ToString()
                : "nao se aplica";

            var carteiraReservista = PossuiMaioridade() && Sexo == EnumSexo.Masculino 
                ? CarteiraReservista.ToString()
                : "nao se aplica";

            var info = $"\nCPF: {Cpf}\nNome: {Nome}\nIdade: {Idade}-({RetornarAnoNascimento()})\nSexo: {Sexo.ToString()}\nCarteira de Motorista: {carteiraMotorista}\nCarteira de Reservista: {carteiraReservista}\n{Endereco.RetornarDados()}";

            return info;
        }

        public int RetornarAnoNascimento()
        {
            var anoNascimento = DateTime.Now.Year - Idade;

            return anoNascimento;
        }

        public string RetornarCpfNome()
        {
            return $"Cpf: {Cpf} - Nome: {Nome}";
        }

        public string RetornarCpf()
        {
            return Cpf;
        }
        public void AlterarCliente(string nome, int idade, EnumSexo sexo, Endereco endereco){
            Nome = nome;
            Idade = idade;
            Sexo = sexo;
            Endereco = endereco;
        }
        public Endereco RetornaEndereco(){
            return Endereco;
        }
    }
}
