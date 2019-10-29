using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public static class Kruskal
    {
        private static GrafoNaoDirigido arvore;
        private static Vertice verticeOrigem;
        private static GrafoNaoDirigido grafoOrigem;

        public static GrafoNaoDirigido execute(GrafoNaoDirigido grafo)
        {
            grafoOrigem = new GrafoNaoDirigido(grafo.vertices);
            arvore = new GrafoNaoDirigido(grafo.gerarGrafoNulo());

            Aresta aresta = FindArestaMenorPeso();

            while (aresta != null)
            {
                if (!HasCiclo(verticeOrigem, aresta))
                {
                    arvore.adicionarAresta(verticeOrigem.id, aresta.vertice.id, aresta.peso);
                }

                RemoveArestaGrafoCompleto(verticeOrigem, aresta);

                aresta = FindArestaMenorPeso();
            }

            return arvore;
        }

        // Busca a aresta de menor peso
        private static Aresta FindArestaMenorPeso()
        {
            int pesoMenor = 1000;
            Aresta arestaMenorPeso = null;

            grafoOrigem.LimparCorVertices();

            foreach (Vertice vertice in grafoOrigem.vertices)
            {
                foreach (Aresta aresta in vertice.adjacentes)
                {
                    if (aresta.peso <= pesoMenor && aresta.vertice.cor == "BRANCO")
                    {
                        if (aresta.peso == pesoMenor)
                        {
                            Aresta arestaEscolhida = Prim.ArestasComMesmoPeso(arestaMenorPeso, verticeOrigem, aresta, vertice);
                            pesoMenor = arestaEscolhida.peso;
                            arestaMenorPeso = arestaEscolhida;
                        }
                        else
                        {
                            pesoMenor = aresta.peso;
                            arestaMenorPeso = aresta;
                            verticeOrigem = vertice;
                        }
                    }

                }
                vertice.cor = "VERDE";
            }

            return arestaMenorPeso;
        }

        private static bool HasCiclo(Vertice verticeOrigem, Aresta aresta)
        {
            arvore.LimparCorVertices();

            return VerificaArestaCiclo(verticeOrigem, aresta);
        }


        // Para verificar se a aresta que será incluida é de ciclo e feita uma busca em profundidade
        // percorrendo todos os vertices de origem da subArvore procurando algum vértice que tenha alguma
        // ligação com o vértice da aresta. Se tiver possui ciclo.
        private static bool VerificaArestaCiclo(Vertice verticeOrigem, Aresta aresta)
        {
            arvore.vertices[verticeOrigem.id - 1].cor = "VERDE";

            if (aresta.vertice.id == verticeOrigem.id) { return true; }
            else
            {
                foreach (var a in arvore.vertices[verticeOrigem.id - 1].adjacentes)
                {
                    if (a.vertice.cor == "BRANCO")
                    {
                        if (VerificaArestaCiclo(a.vertice, aresta)) { return true; }

                    }
                }

                return false;
            }
        }

        private static void RemoveArestaGrafoCompleto(Vertice v1, Aresta aresta)
        {
            grafoOrigem.vertices[v1.id - 1].adjacentes.Remove(aresta);
            grafoOrigem.vertices[aresta.vertice.id - 1].RemoveVerticeAdjacente(v1.id);

        }

    }
}
