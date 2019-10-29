using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public abstract class Grafo
    {
        public Vertice[] vertices { get; set; }

        public Grafo(Vertice[] vertices)
        {
            this.vertices = vertices;
        }

        public void LimparCorVertices()
        {
            foreach (Vertice vertice in vertices)
            {
                vertice.cor = "BRANCO";
            }

        }

        public int NumeroVertices()
        {
            return this.vertices.Length;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((GrafoNaoDirigido)obj);
        }

        public bool Equals(GrafoNaoDirigido obj)
        {
            if (this.NumeroVertices() == obj.NumeroVertices())
            {
                for (int i = 0; i < this.vertices.Length; i++)
                {
                    if (obj.vertices[i].adjacentes.Count() != this.vertices[i].adjacentes.Count())
                    {
                        return false;
                    }

                }

                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
