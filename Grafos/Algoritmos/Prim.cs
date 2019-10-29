using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public static class Prim
    {
        private static List<Vertice> verticesConhecidos = new List<Vertice>();
        private static Vertice vOrigem;

        public static GrafoNaoDirigido execute(Vertice origem, GrafoNaoDirigido grafo)
        {
            GrafoNaoDirigido arvore = new GrafoNaoDirigido(grafo.gerarGrafoNulo());

            vOrigem = origem;

            Aresta aresta = selecionarAresta(origem);

            while (aresta != null)
            {
                //adiciona a aresta a arvore
                arvore.adicionarAresta(vOrigem.id, aresta.vertice.id, aresta.peso);

                //seleciona a aresta de menor peso
                aresta = selecionarAresta(aresta.vertice);
            }

            return arvore;
        }

        private static Aresta selecionarAresta(Vertice v)
        {
            v.cor = "VERDE";
            verticesConhecidos.Add(v);

            return encontrarMenorPeso();
        }

        private static Aresta encontrarMenorPeso()
        {
            int peso = 10000;

            Aresta arestaSelecionada = null;

            foreach (Vertice v in verticesConhecidos)
            {
                foreach (Aresta aresta in v.adjacentes)
                {
                    if (aresta.peso <= peso && aresta.vertice.cor == "BRANCO")
                    {
                        if (aresta.peso == peso)
                        {
                            Aresta arestaEscolhida = ArestasComMesmoPeso(arestaSelecionada, vOrigem, aresta, v);

                            peso = arestaEscolhida.peso;
                            arestaSelecionada = arestaEscolhida;
                        }
                        else
                        {
                            peso = aresta.peso;
                            arestaSelecionada = aresta;
                            vOrigem = v;
                        }

                    }

                }
            }

            return arestaSelecionada;
        }

        public static Aresta ArestasComMesmoPeso(Aresta aresta1, Vertice vertice1, Aresta aresta2, Vertice vertice2)
        {
            if ((vertice1.id + aresta1.vertice.id) >= (vertice2.id + aresta2.vertice.id))
            {
                vOrigem = vertice2;
                return aresta2;
            }
            else
            {
                if ((vertice1.id + aresta1.vertice.id) == (vertice2.id + aresta2.vertice.id))
                {
                    int indice1 = Math.Min(vertice1.id, aresta1.vertice.id);
                    int indice2 = Math.Min(vertice2.id, aresta2.vertice.id);

                    if (indice2 < indice1)
                    {
                        vOrigem = vertice2;
                        return aresta2;
                    }
                    else
                    {
                        return aresta1;
                    }

                }

                return aresta1;
            }
        }
    }
}
