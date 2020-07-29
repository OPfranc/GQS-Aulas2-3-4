using System;
using System.IO;
using System.Collections.Generic;

using aula4.Entidades;

namespace aula4.Telas
{

    public partial class Tela
    {

        private bool LerDados()
        {
            var identificacao = LerString($"Informe o {TipoIdentificador}");
            if (BuscarEntidade(identificacao) != null)
            {
                AguardarTecla($"{TipoIdentificador} informado ja esta cadastrado!", ConsoleColor.DarkRed);
                return false;
            }
            var entidade = LerDadosEntidade();

            if (TipoEntidade.Equals(EnumTipoEntidade.Animal))
            {
                var novoAnimal = new Animal(identificacao, entidade);
                Entidades.Add(novoAnimal);
            }
            else
            {
                var novoCliente = new Cliente(identificacao, entidade);
                LerDadosCliente(novoCliente);
                Entidades.Add(novoCliente);
            }
            return true;
        }
        private Entidade LerDadosEntidade()
        {
            var nome = LerString("Informe o nome:");
            var idade = LerInt("Informe a idade:");
            var sexoStr = LerString("Informe o sexo (m/f):");
            var sexo = (sexoStr == "m")
                ? EnumSexo.Masculino
                : EnumSexo.Feminino;
            return new Entidade(nome, idade, sexo);
        }

        private void LerDadosCliente(Cliente novoCliente)
        {

            LerDadosEndereco(novoCliente);
            LerDadosCarteiras(novoCliente);
        }
        private void LerDadosEndereco(Cliente novoCliente)
        {
            var endereco = new Endereco();
            int opcao = LerInt("Você gostaria de adicionar um endereco? (1 - sim / 2 - Não)");
            if (opcao == 1)
            {
                endereco.AtribuirRua(LerString("Informe a rua:"));
                endereco.AtribuirNumero(LerString("Informe a numero da rua:"));
                endereco.AtribuirCidade(LerString("Informe a cidade:"));
                endereco.AtribuirEstado(LerString("Informe o estado:"));
                endereco.AtribuirCep(LerString("Informe o cep:"));
            }
            novoCliente.AtribuirEndereco(endereco);

        }
        private void LerDadosCarteiras(Cliente novoCliente)
        {
            int opcao;
            int carteiraMotorista = 0;
            int carteiraReservista = 0;
            if (novoCliente.PossuiMaioridade())
            {
                Escrever();
                opcao = LerInt("Gostaria de adicionar Carteira de Motorista (1 - sim / 2 - Não)");
                if (opcao == 1)
                    carteiraMotorista = LerInt("Informe o numero da carteira de Motorista:");
            }

            if (novoCliente.PossuiCarteiraReservista())
            {
                Escrever();
                opcao = LerInt("Gostaria de adicionar Carteira de Reservista (1 - sim / 2 - Não)");
                if (opcao == 1)
                    carteiraReservista = LerInt("Informe o numero da carteira de Reservista:");
            }

            novoCliente.AtribuirCarteiras(carteiraMotorista, carteiraReservista);
        }
        private void CarregarEntidades()
        {
            try
            {
                if (!File.Exists($"{RetornarTipoEntidadeString().ToLower()}dados"))
                {
                    SalvarEntidades();
                }
                List<string> dadosCarregados = new List<string>();
                using (StreamReader streamReader = new StreamReader($"{RetornarTipoEntidadeString().ToLower()}dados"))
                {
                    while (streamReader.Peek() >= 0)
                    {
                        dadosCarregados.Add(streamReader.ReadLine());
                    }
                }
                foreach (var dado in dadosCarregados)
                {
                    string[] entidade = dado.Split(";");

                    if (TipoEntidade == EnumTipoEntidade.Animal)
                    {
                        var novaEntidade = new Animal(entidade);
                        Entidades.Add(novaEntidade);
                    }
                    else
                    {
                        var novaEntidade = new Cliente(entidade);
                        Entidades.Add(novaEntidade);
                    }
                }
                Escrever("Dados lidos da memoria!", ConsoleColor.Green);
            }
            catch
            {
                Escrever("Erro ao Ler da memoria", ConsoleColor.DarkRed);
            }
        }

    }
}