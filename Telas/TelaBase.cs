using System;

namespace aula4.Telas
{
    public class TelaBase
    {
            protected void Escrever(string mensagem = "", ConsoleColor foregroundColor = ConsoleColor.Gray, ConsoleColor backgroundColor = ConsoleColor.Black, int espacoEmBranco = 0)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;

            Console.WriteLine(mensagem.PadRight(Console.WindowWidth - 1));
            Console.ResetColor();

            for(int i = 0; i < espacoEmBranco; i++)
            {
                Escrever();
            }
        }

        protected string LerString()
        {
            var retorno = "";
            var executando = true;
            do
            {
                if (string.IsNullOrWhiteSpace(retorno = Console.ReadLine()))
                {
                    var mensagem = "Entrada invalida. Digite novamente.";
                    Escrever(mensagem, ConsoleColor.DarkRed);
                    continue;
                }
                executando = false;
            } while (executando);

            return retorno;
        }

        protected string LerString(string mensagem)
        {
            Escrever(mensagem);

            return LerString();
        }

        protected int LerInt()
        {
            var retorno = 0;
            var mensagem = "";
            var executando = true;
            do
            {
                if (!string.IsNullOrWhiteSpace(mensagem))
                {
                    Escrever(mensagem, ConsoleColor.DarkRed);
                    mensagem = "";
                }

                try
                {
                    retorno = int.Parse(Console.ReadLine());
                    executando = false;
                }
                catch
                {
                    mensagem = "Entrada invalida. Digite novamente.";
                }
            } while (executando);

            return retorno;
        }

        protected int LerInt(string mensagem, ConsoleColor foregroundColor = ConsoleColor.Gray, ConsoleColor backgroundColor = ConsoleColor.Black )
        {
            Escrever(mensagem, foregroundColor, backgroundColor);

            return LerInt();
        }
        protected void LimparTela()
        {
            Console.Clear();
        }

        protected void AguardarTecla()
        {
            Console.ReadKey();
        }

        protected void AguardarTecla(string mensagem, ConsoleColor foregroundColor = ConsoleColor.DarkYellow, ConsoleColor backgroundColor = ConsoleColor.Black ) 
        {
            Escrever(mensagem, foregroundColor, backgroundColor);
            AguardarTecla();
        }

        protected void Titulo(string mensagem, ConsoleColor backgroundColor = ConsoleColor.DarkGray)
        {
            LimparTela();
            Escrever(mensagem, ConsoleColor.White, backgroundColor, espacoEmBranco: 1);
        }

        public void OpcaoInvalida()
        {
            Escrever("Opção inválida", ConsoleColor.DarkRed);
        }
    }
}