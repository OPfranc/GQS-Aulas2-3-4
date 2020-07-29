using System;

namespace aula4.Entidades
{
    public partial class Cliente : Entidade
    {


        private string Cpf;
        private int CarteiraMotorista;
        private int CarteiraReservista;
        private Endereco Endereco;



        public string RetornarCpf() => Cpf;

        public void AtribuirCpf(string cpf)
        {
            Cpf = cpf;
        }


        public int RetornarCarteiraMotorista() => CarteiraMotorista;
        public string RetornarCarteiraMotoristaString() => CarteiraMotorista.ToString();

        public void AtribuirCarteiraMotorista(int carteiraMotorista)
        {
            CarteiraMotorista = carteiraMotorista;
        }


        public int RetornarCarteiraReservista() => CarteiraReservista;
        public string RetornarCarteiraReservistaString() => CarteiraReservista.ToString();

        public void AtribuirCarteiraReservista(int carteiraReservista)
        {
            CarteiraReservista = carteiraReservista;
        }


        public Endereco RetornaEndereco() => Endereco;

        public void AtribuirEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }


        public Cliente()
        {

        }
        public Cliente(string nome, int idade, EnumSexo sexo) : base(nome, idade, sexo)
        {

        }
        public Cliente(string identificacao, string nome, int idade, EnumSexo sexo) : base(identificacao, nome, idade, sexo)
        {
            AtribuirCpf(identificacao);
        }
        public Cliente(string identificacao, Entidade entidade) : this(identificacao, entidade.RetornarNome(), entidade.RetornarIdade(), entidade.RetornarSexo())
        {

        }
        public Cliente(string identificacao, string nome, int idade, EnumSexo sexo, Endereco endereco) : this(identificacao, nome, idade, sexo)
        {
            AtribuirEndereco(endereco);
        }
        public Cliente(string identificacao, string nome, int idade, EnumSexo sexo, int carteiraMotorista, int carteiraReservista, Endereco endereco) : this(identificacao, nome, idade, sexo, endereco)
        {
            AtribuirCarteiras(carteiraMotorista, carteiraReservista);
        }


        public void AtribuirCarteiras(int carteiraMotorista, int carteiraReservista)
        {
            AtribuirCarteiraMotorista(carteiraMotorista);
            AtribuirCarteiraMotorista(carteiraReservista);
        }

        public Cliente(string[] dadosCarregados)
        {
            AtribuirCpf(dadosCarregados[0]);
            AtribuirNome(dadosCarregados[1]);
            AtribuirIdade(int.Parse(dadosCarregados[2]));
            AtribuirSexo(dadosCarregados[3] == "Masculino" ? EnumSexo.Masculino : EnumSexo.Feminino);
            AtribuirCarteiraMotorista(int.Parse(dadosCarregados[4]));
            AtribuirCarteiraReservista(int.Parse(dadosCarregados[5]));
            var endereco = new Endereco(dadosCarregados[6], dadosCarregados[7], dadosCarregados[8], dadosCarregados[9], dadosCarregados[10]);
            AtribuirEndereco(endereco);
        }

        public bool PossuiMaioridade() => (RetornarIdade() >= 18);


        public bool PossuiCarteiraReservista()
        {

            if (!PossuiMaioridade())
                return false;

            if (RetornarSexo() == EnumSexo.Feminino)
                return false;

            return true;
        }

        public string RetornarDados()
        {
            var carteiraMotorista = PossuiMaioridade()
                ? RetornarCarteiraMotoristaString()
                : "nao se aplica";

            var carteiraReservista = PossuiMaioridade() && RetornarSexo() == EnumSexo.Masculino
                ? RetornarCarteiraReservistaString()
                : "nao se aplica";

            var dados = $"\nCPF: {Cpf}\nNome: {RetornarNome()}\nIdade: {RetornarIdadeString()}-({RetornarAnoNascimentoString()})\nSexo: {RetornarSexoString()}\nCarteira de Motorista: {carteiraMotorista}\nCarteira de Reservista: {carteiraReservista}\n{RetornaEndereco().RetornarDados()}";

            return dados;
        }

        public string RetornarCpfNome() => $"Cpf: {Cpf} - Nome: {RetornarNome()}";

        public string RetornarDadosSalvar()
        {
            var endereco = RetornaEndereco().RetornaDadosSalvar();
            var cliente = $"{Cpf};{RetornarNome()};{RetornarIdade()};{RetornarSexo()};{RetornarCarteiraMotoristaString()};{RetornarCarteiraReservistaString()}";
            var dadosSalvar = string.Join(";", cliente, endereco);

            return dadosSalvar;
        }
        public void AlterarCliente(string nome, int idade, EnumSexo sexo, Endereco endereco, int carteiraMotorista, int carteiraReservista)
        {
            AtribuirNome(nome);
            AtribuirIdade(idade);
            AtribuirSexo(sexo);
            AtribuirEndereco(endereco);
            AtribuirCarteiraMotorista(carteiraMotorista == 0 ? CarteiraMotorista : carteiraMotorista);
            AtribuirCarteiraReservista(carteiraReservista == 0 ? CarteiraReservista : carteiraReservista);
        }
    }
}
