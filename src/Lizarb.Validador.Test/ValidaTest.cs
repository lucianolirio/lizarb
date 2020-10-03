using NUnit.Framework;
using System;
using System.Diagnostics;
using Lizarb.Validador;

namespace Lizarb.Validador.Test
{
    public class Tests
    {
        private int _before0;
        private int _before1;
        private int _before2;
        private Stopwatch _sw;

        [SetUp]
        public void Setup()
        {
            _sw = new Stopwatch();
            _before2 = GC.CollectionCount(2);
            _before1 = GC.CollectionCount(1);
            _before0 = GC.CollectionCount(0);
            _sw.Start();
        }

        [TearDown]
        public void StopDown()
        {
            _sw.Stop();
            Console.WriteLine($"Tempo total: {_sw.ElapsedMilliseconds}ms");
            Console.WriteLine($"GC Gen #2 : {GC.CollectionCount(2) - _before2}");
            Console.WriteLine($"GC Gen #1 : {GC.CollectionCount(1) - _before1}");
            Console.WriteLine($"GC Gen #0 : {GC.CollectionCount(0) - _before0}");
            Console.WriteLine("Done!");
            Console.WriteLine();

            Span<int> teste = stackalloc int[200];
        }


        [Test]
        public void CPFTest()
        {
            for (int i = 0; i < 1_000_000; i++)
            {
                if (!"771.189.500-33".CPF())
                {
                    throw new Exception("Error!");
                }

                if ("771.189.500-34".CPF())
                {
                    throw new Exception("Error!");
                }
            }
        }

        [Test]
        public void CNPJTest()
        {
            for (int i = 0; i < 1_000_000; i++)
            {
                if (!"23.514.657/0001-72".CNPJ())
                {
                    throw new Exception("Error!");
                }

                if ("23.514.657/0001-71".CNPJ())
                {
                    throw new Exception("Error!");
                }
            }
        }
    }
}