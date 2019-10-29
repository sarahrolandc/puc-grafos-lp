using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    static class TARJAN
    {
        public static int execute(Grafo grafo)
        {

            int cont = 0;
            InicializarPontosArticulacao(grafo);
            grafo.LimparCorVertices();

            foreach (Vertice v in grafo.vertices)
            {
                if (v.cor == "BRANCO")
                {
                    Tarjan(v, v, 0, ref cont);

                    if (cont >= 2)
                    {
                        v.pontoArticulacao = true;
                    }
                    else { v.pontoArticulacao = false; }

                }
            }

            return CountPontoArticulacao(grafo);

        }

        private static void Tarjan(Vertice v, Vertice verticeOrigem, int time, ref int cont)
        {
            time += 1;
            v.tempoDescoberta = v.m = time;
            v.cor = "CINZA";

            foreach (Aresta a in v.adjacentes)
            {
                if (a.vertice.cor == "BRANCO")
                {
                    v.idSucessor = a.vertice.id;

                    if (v.id == verticeOrigem.id) { cont += 1; }

                    Tarjan(a.vertice, verticeOrigem, time, ref cont);

                    if (a.vertice.m >= v.tempoDescoberta) { v.pontoArticulacao = true; }

                    v.m = Min(v.m, a.vertice.m);
                }
                else if (a.vertice.id != v.idSucessor)
                {
                    v.m = Min(v.m, a.vertice.tempoDescoberta);
                }
            }

            v.cor = "PRETO";
        }

        private static int Min(int val1, int val2)
        {
            return Math.Min(val1, val2);
        }

        private static int CountPontoArticulacao(Grafo g)
        {
            int cont = 0;
            foreach (var j in g.vertices)
            {
                if (j.pontoArticulacao)
                {
                    cont++;
                }
            }

            return cont;
        }

        private static void InicializarPontosArticulacao(Grafo grafo)
        {
            foreach (Vertice v in grafo.vertices)
            {
                v.pontoArticulacao = false;
            }
        }

    }






}
