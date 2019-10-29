using System.Collections.Generic;

namespace Grafos
{
    public class Vertice
    {
        public int id { get; set; }

        public string cor { get; set; }

        public int idSucessor { get; set; }

        public int tempoDescoberta { get; set; }

        public int m { get; set; }

        public bool pontoArticulacao { get; set; }


        //Lisa de vértices adjacentes (Contendo o vértice e o peso da aresta)
        public List<Aresta> adjacentes { get; set; }

        public Vertice(int id)
        {
            this.id = id;
            this.adjacentes = new List<Aresta>();
        }

        public void AddVerticeAdjacente(Vertice vertice, int peso)
        {
            adjacentes.Add(new Aresta(vertice, peso));
        }

        public void RemoveVerticeAdjacente(int id)
        {
            Aresta arestaRetirar = null;

            foreach (var aresta in adjacentes)
            {
                if (aresta.vertice.id == id)
                {
                    arestaRetirar = aresta;
                    break;
                }
            }

            adjacentes.Remove(arestaRetirar);
        }


        
    }
}