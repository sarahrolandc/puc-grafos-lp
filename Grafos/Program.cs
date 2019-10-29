using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    class Program
    {
        static void Main(string[] args)
        {

            GrafoNaoDirigido g1 = LeituraArquivo.GrafoNaoDirigido(@"..\..\..\GrafosTests2\txts\NaoDirigido\Prim.txt");

            GrafoDirigido gDirigido = LeituraArquivo.GrafoDirigido(@"..\..\..\GrafosTests2\txts\Dirigido\SemCiclo.txt");
            
            Console.WriteLine("São adjacentes: " + g1.isAdjacente(g1.vertices[0], g1.vertices[1]));
            Console.WriteLine("Grau: " + g1.getGrau(g1.vertices[0]));
            Console.WriteLine("É isolado: " + g1.isIsolado(g1.vertices[0]));
            Console.WriteLine("É pendente: " + g1.isPendente(g1.vertices[0]));
            Console.WriteLine("É regular: " + g1.isRegular());
            Console.WriteLine("É nulo: " + g1.isNulo());
            Console.WriteLine("Completo: " + g1.isCompleto());
            Console.WriteLine("É conexo: " + g1.isConexo());
            Console.WriteLine("Numero de Cut Vértice: " + g1.getCutVertices());
            Console.WriteLine("É Euleriano: " + g1.isEuleriano());
            Console.WriteLine("É Unicursal: " + g1.isUnicursal());
            Console.WriteLine("Grafo Complementar: ");
            g1.getComplementar().Imprimir();
            Console.WriteLine("Arvore Geradora Prim: ");
            g1.getAGMPrim(g1.vertices[0]).Imprimir();
            Console.WriteLine("Arvore Geradora Kruskal");
            g1.getAGMKruskal().Imprimir();


            Console.ReadKey();

        }
    }
}
