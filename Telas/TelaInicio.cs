using System;

using aula4.Entidades;

namespace aula4.Telas
{
    public class TelaInicio : TelaBase
    {
        private static TelaInicio _instance;

        public static TelaInicio Instance()
        {
            if (_instance == null)
            {
                _instance = new TelaInicio();
            }
            return _instance;
        }

        public void Executar()
        {

            var executando = true;
            do
            {
                Titulo($"Escolha o tipo de entidade");
                Escrever("1 - Clientes", ConsoleColor.DarkCyan);
                Escrever("2 - Animais", ConsoleColor.DarkGreen);
                Escrever("0 - Sair");

                int opcao = LerInt();
                switch (opcao)
                {
                    case 1:
                        Tela telaCliente = Tela.Instance(EnumTipoEntidade.Cliente);
                        telaCliente.Executar();
                        break;

                    case 2:
                        Tela telaAnimal = Tela.Instance(EnumTipoEntidade.Animal);
                        telaAnimal.Executar();
                        break;

                    case 0:
                        executando = false;
                        break;

                    default:
                        OpcaoInvalida();
                        break;
                }
                
            } while (executando);
        }
    }
}