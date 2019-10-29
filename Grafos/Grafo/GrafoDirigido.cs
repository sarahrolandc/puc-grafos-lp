using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public class GrafoDirigido : Grafo
    {
        public GrafoDirigido(Vertice[] vertices) : base(vertices)
        {

        }
        public int getGrauEntrada(Vertice v1)
        {
            int grauEntrada = 0;

            //Busca em todos os vertices e seus respectivos vertices sucessores se existe uma correspondencia com o 
            //vertice passado por parâmetro, significando 
            foreach (Vertice vertice in vertices)
            {
                foreach (var aresta in vertice.adjacentes)
                {
                    if (aresta.vertice == v1)
                    {
                        grauEntrada++;
                    }
                }
            }

            return grauEntrada;
        }
        public int getGrauSaida(Vertice v1)
        {
            return v1.adjacentes.Count();
        }

        public bool hasCiclo()
        {
            this.LimparCorVertices();

            //Faz uma busca em profundidade para descobrir se existem arestas de retorno
            foreach (Vertice vertice in vertices)
            {
                if (vertice.cor == "BRANCO")
                {
                    //Verifica se foi achada uma aresta de retorno, se sim o grafo possui um ciclo
                    if (hasArestaRetorno(vertice))
                    {
                        return true;
                    }

                }
            }

            //Caso tenha passado por todas a arestas e nenhuma de retorno, o grafo é um DAG
            return false;
        }

        //Metodo Visitar da busca em profundidade, procurando por uma aresta de retorno.
        private bool hasArestaRetorno(Vertice vertice)
        {
            vertice.cor = "CINZA";

            foreach (var aresta in vertice.adjacentes)
            {
                if (aresta.vertice.cor == "BRANCO")
                {
                    hasArestaRetorno(aresta.vertice);
                }

                //Achou uma aresta de retorno, significando que o grafo tem um ciclo
                if (aresta.vertice.cor == "CINZA")
                {
                    return true;
                }
            }

            vertice.cor = "PRETO";

            return false;
        }

        public void Imprimir()
        {
            Console.WriteLine(NumeroVertices());

            foreach (Vertice v in vertices)
            {
                foreach (Aresta a in v.adjacentes)
                {
                    Console.WriteLine(v.id + "; " + a.vertice.id + "; " + a.peso + "; 1");
                }
            }
        }
    }
}
