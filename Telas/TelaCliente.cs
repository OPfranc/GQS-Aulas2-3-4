using System.Collections.Generic;
using ex1.Entidades;
using System.Linq;

namespace ex1.Telas
{
    public class TelaCliente : TelaBase
    {
        public List<Cliente> Clientes;

        public TelaCliente()
        {
            Clientes = new List<Cliente>();
            PopularClientesFakes();
        }
        public void Executar()
        {
            var executando = true;
            do
            {
                LimparTela();

                Escrever("Menu de opções");
                Escrever("1 - Listar");
                Escrever("2 - Inserir");
                Escrever("3 - Remover");
                Escrever("4 - Sair");

                int opcao = LerInt();
                switch (opcao)
                {
                    case 1:
                        Listar();
                        break;

                    case 2:
                        Inserir();
                        break;

                    case 3:
                        Remover();
                        break;

                    case 4:
                        executando = false;
                        break;

                    default:
                        OpcaoInvalida();
                        break;
                }

            } while (executando);
        }
        public void Remover()
        {
            var executando = true;
            do
            {
                LimparTela();

                Escrever("-- Remover cliente --");

                ListarClientes();

                var opcao = LerString("Informe o Cpf para remover o cliente? (deixe em branco caso queira voltar)");
                if (string.IsNullOrWhiteSpace(opcao))
                {
                    executando = false;
                }
                else
                {
                    var resutl = Clientes
                        .Where(cliente => cliente.RetornarCpf() == opcao)
                        .FirstOrDefault();
                    if (resutl != null)
                    {
                        Clientes.Remove(resutl);
                        AguardarTecla("Cliente removido com sucesso.");
                    }
                    else
                    {
                        AguardarTecla("Cliente não encontrado.");
                    }
                }

            } while (executando);
        }
        public bool ChecarCpf(string cpf)
        {

            var resutl = Clientes
                        .Where(cliente => cliente.RetornarCpf() == cpf)
                        .FirstOrDefault();

            return (resutl == null);
        }
        public void ListarClientes()
        {
            foreach (var cliente in Clientes)
            {
                Escrever(cliente.RetornarCpfNome());
            }
        }

        public void Listar()
        {
            LimparTela();

            Escrever("-- Listagem de clientes --");

            ListarClientes();

            var opcao = LerInt("Você gostaria de mais informacoes? (1 - sim / 2 - Não)");
            if (opcao == 1)
            {
                var cpf = LerString("Informe o cpf do cliente");
                DetalhesCliente(cpf);
            }


        }

        public void DetalhesCliente(string cpf)
        {
            var resutl = Clientes
                       .Where(cliente => cliente.RetornarCpf() == cpf)
                       .FirstOrDefault();
            if (resutl == null)
            {
                AguardarTecla("CPF nao encontrado");
                return;
            }
            LimparTela();
            Escrever("-- Informacoes do cliente --");
            Escrever(resutl.RetornarDados());

            var opcao = LerInt("Você gostaria de modificar as informacoes? (1 - sim / 2 - Não)");
            if (opcao == 1)
            {
                Alterar(resutl);
            }
        }
        public void Inserir()
        {
            int opcao;
            var executando = true;
            do
            {
                LimparTela();

                var cpf = LerString("Informe o cpf:");
                if (!ChecarCpf(cpf))
                {
                    Escrever("Cpf informado ja esta na lista!");
                    AguardarTecla();
                    continue;
                }
                var nome = LerString("Informe o nome:");
                var idade = LerInt("Informe a idade:");
                var sexoStr = LerString("Informe o sexo (m/f):");
                var sexo = (sexoStr == "m")
                    ? EnumSexo.Masculino
                    : EnumSexo.Feminino;
                var carteiraMotorista = 0;
                var carteiraReservista = 0;

                #region Endereco
                var endereco = new Endereco();
                opcao = LerInt("Você gostaria de adicionar um endereco? (1 - sim / 2 - Não)");
                switch (opcao)
                {
                    case 1:
                        var rua = LerString("Informe a rua:");
                        var numero = LerString("Informe a numero da rua:");
                        var cidade = LerString("Informe a cidade:");
                        var estado = LerString("Informe o estado:");
                        var cep = LerString("Informe o cep:");
                        endereco = new Endereco(rua, numero, cep, cidade, estado);
                        break;

                    default:
                        break;
                }
                var obj = new Cliente(cpf, nome, idade, sexo, endereco);

                if (obj.PossuiCarteiraMotorista())
                {
                    opcao = LerInt("Gostaria de adicionar Carteira de Motorista (1 - sim / 2 - Não)");
                    if (opcao == 1)
                        carteiraMotorista = LerInt("Informe o numero da carteira de Motorista:");
                        obj.AdicionarCarteiraMotorista(carteiraMotorista);
                }
                
                if (obj.PossuiCarteiraReservista())
                {
                    opcao = LerInt("Gostaria de adicionar Carteira de Reservista (1 - sim / 2 - Não)");
                    if (opcao == 1)
                        carteiraReservista = LerInt("Informe o numero da carteira de Reservista:");
                        obj.AdicionarCarteiraReservista(carteiraReservista);
                }

                Clientes.Add(obj);

                #endregion

                Escrever("Cliente inserido com sucesso\n\n");

                opcao = LerInt("Você gostaria de adicionar outro cliente? (1 - sim / 2 - Não)");
                if (opcao == 2)
                    executando = false;

            } while (executando);
        }

        public void OpcaoInvalida()
        {
            AguardarTecla("Opção inválida");
        }

        public void Alterar(Cliente cliente)
        {
            LimparTela();
            Escrever("-- Alterando informacoes do cliente --");

            var nome = LerString("Informe o novo nome:");
            var idade = LerInt("Informe a nova idade:");
            var sexoStr = LerString("Informe o sexo (m/f):");
            var sexo = (sexoStr == "m")
                ? EnumSexo.Masculino
                : EnumSexo.Feminino;

            var endereco = cliente.RetornaEndereco();

            int opcao = LerInt("Você gostaria de Modificar o endereco? (1 - sim / 2 - Não)");
            switch (opcao)
            {
                case 1:
                    var rua = LerString("Informe a rua:");
                    var numero = LerString("Informe a numero da rua:");
                    var cidade = LerString("Informe a cidade:");
                    var estado = LerString("Informe o estado:");
                    var cep = LerString("Informe o cep:");
                    endereco = new Endereco(rua, numero, cep, cidade, estado);
                    break;

                default:
                    break;
            }
            cliente.AlterarCliente(nome, idade, sexo, endereco);
            AguardarTecla("Dados alterados. Precione qualquer tecla para voltar");
        }

        public void PopularClientesFakes()
        {
            var endereco = new Endereco("rua", "123", "99999999-9", "cidade", "XX");
            var obj = new Cliente("333", "cccccc", 17, EnumSexo.Masculino, endereco);
            Clientes.Add(obj);

            var endereco1 = new Endereco("rua", "555", "99999999-9", "cidade", "XX");
            var obj1 = new Cliente("555", "rtw", 19, EnumSexo.Masculino, endereco1);
            Clientes.Add(obj1);

            var endereco2 = new Endereco("rua", "123", "99999999-9", "cidade", "XX");
            var obj2 = new Cliente("111", "mm", 17, EnumSexo.Feminino, endereco2);
            Clientes.Add(obj2);

            var endereco3 = new Endereco("rua", "123", "99999999-9", "cidade", "XX");
            var obj3 = new Cliente("222", "yyyy", 59, EnumSexo.Feminino, endereco3);
            Clientes.Add(obj3);
        }
    }
}