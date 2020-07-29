using System;

namespace ex1.Telas
{
public class TelaBase
    {


        public void Escrever(string mensagem)
        {
            Console.WriteLine(mensagem);
        }

        public string LerString()
        {
            return Console.ReadLine();
        }
        
        public string LerString(string mensagem)
        {
            Escrever(mensagem);

            return LerString();
        }

        public int LerInt()
        {
            return int.Parse(Console.ReadLine());
        }
        
        public int LerInt(string mensagem)
        {
            Escrever(mensagem);

            return LerInt();
        }
        public void LimparTela()
        {
            Console.Clear();
        }

        public void AguardarTecla()
        {
            Console.ReadKey();
        }

        public void AguardarTecla(string mensagem)
        {
            Escrever(mensagem);

            AguardarTecla();
        }


    }
}