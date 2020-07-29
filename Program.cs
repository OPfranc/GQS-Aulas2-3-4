using System;
using aula4.Telas;

namespace aula4
{
    class Program
    {
        static void Main(string[] args)
        {
            var telaInicio = TelaInicio.Instance();
            telaInicio.Executar();
        }
    }
}
