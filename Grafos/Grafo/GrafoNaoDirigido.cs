using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public class GrafoNaoDirigido : Grafo
    {
        public GrafoNaoDirigido(Vertice[] vertices) : base(vertices)
        {

        }

        public bool isAdjacente(Vertice v1, Vertice v2)
        {
            foreach (Aresta a in v1.adjacentes)
            {
                if (a.vertice == v2) { return true; }
            }

            return false;
        }


        public int getGrau(Vertice v1)
        {
            return v1.adjacentes.Count();
        }

        public bool isIsolado(Vertice v1)
        {
            return getGrau(v1) == 0;
        }


        // Pendentes são vertices que possuem somente uma aresta adjacente
        public bool isPendente(Vertice v1)
        {
            return getGrau(v1) == 1;
        }

        // Vertice Regular -> Todos os vértices tem o mesmo grau
        public bool isRegular()
        {
            for (int i = 1; i < vertices.Length; i++)
            {
                if (getGrau(vertices[0]) != getGrau(vertices[i])) { return false; }
            }
            return true;
        }

        public bool isNulo()
        {
            foreach (Vertice vertice in vertices)
            {
                if (this.getGrau(vertice) != 0) { return false; }
            }
            return true;
        }

        public bool isCompleto()
        {
            int numeroVertices = vertices.Count();

            foreach (Vertice vertice in vertices)
            {
                if (getGrau(vertice) < numeroVertices - 1)
                {
                    return false;
                }
            }

            return true;
        }

        public bool isConexo()
        {
            int componentes = 0;

            this.LimparCorVertices();

            //Faz uma busca em profundidade para descobrir a quantidade de componentes conexos;
            foreach (Vertice vertice in vertices)
            {
                if (vertice.cor == "BRANCO")
                {
                    VisitarDFS(vertice);
                    componentes++;
                }
            }

            return componentes == 1;
        }

        //Metodo Visitar da busca em profundidade
        private void VisitarDFS(Vertice vertice)
        {
            vertice.cor = "CINZA";

            foreach (var aresta in vertice.adjacentes)
            {
                if (aresta.vertice.cor == "BRANCO")
                {
                    VisitarDFS(aresta.vertice);
                }
            }

            vertice.cor = "PRETO";
        }

        public bool isEuleriano()
        {
            //Um grafo que não é conexo não pode ser Euleriano
            if (!isConexo())
            {
                return false;
            }

            foreach (Vertice vertice in vertices)
            {
                //Verifica se todos os vertices possuem grau par, caso contráio o mesmo não é euleriano
                if ((getGrau(vertice) % 2) != 0)
                {
                    return false;
                }
            }

            //Significa que todos os vertices tem grau par 
            return true;

        }

        public bool isUnicursal()
        {
            //Um grafo que não é conexo não pode ser Unicursal
            if (!isConexo())
            {
                return false;
            }

            int verticesGrauImpar = 0;

            foreach (Vertice vertice in vertices)
            {
                //Verifica quantos vértices possuem grau par
                if ((getGrau(vertice) % 2) != 0)
                {
                    verticesGrauImpar++;
                }
            }

            //O grafo é Unicursal se 2 vértices possuem grau impar
            if (verticesGrauImpar == 2)
            {
                return true;
            }
            else { return false; }
        }

        public GrafoNaoDirigido getComplementar()
        {
            //Gera um grafo completo
            GrafoNaoDirigido grafoComplementar = this.GerarGrafoCompleto();

            //Percorre todos os vertices e retira do grafo completo as arestas que existem no grafo original,
            //Resultando em seu grafo complementar.
            for (int i = 0; i < vertices.Length; i++)
            {
                foreach (var aresta in vertices[i].adjacentes)
                {
                    grafoComplementar.vertices[i].RemoveVerticeAdjacente(aresta.vertice.id);
                }
            }

            return grafoComplementar;
        }

        private GrafoNaoDirigido GerarGrafoCompleto()
        {
            Vertice[] verts = this.gerarGrafoNulo();

            for (int i = 0; i < verts.Length; i++)
            {
                for (int j = 0; j < verts.Length; j++)
                {
                    if (i != j)
                    {
                        verts[i].AddVerticeAdjacente(verts[j], 1);
                    }
                }

            }

            return new GrafoNaoDirigido(verts);
        }

        public Vertice[] gerarGrafoNulo()
        {
            Vertice[] verts = new Vertice[NumeroVertices()];

            for (int i = 0; i < verts.Length; i++)
            {
                verts[i] = new Vertice(i + 1);
            }

            return verts;
        }

        public GrafoNaoDirigido getAGMPrim(Vertice v1)
        {
            this.LimparCorVertices();

            return Prim.execute(v1, this);
        }

        public void adicionarAresta(int idVertice1, int idVertice2, int peso)
        {
            vertices[idVertice1 - 1].AddVerticeAdjacente(vertices[idVertice2 - 1], peso);
            vertices[idVertice2 - 1].AddVerticeAdjacente(vertices[idVertice1 - 1], peso);
        }

        public GrafoNaoDirigido getAGMKruskal()
        {
            this.LimparCorVertices();
            return Kruskal.execute(this);
        }


        public int getCutVertices()
        {
            if (isConexo())
            {
                return TARJAN.execute(this);
            }
            else { return 0; }
            
        }

        

        

        public void Imprimir()
        {
            List<ParVertices> verts = new List<ParVertices>();

            Console.WriteLine(NumeroVertices());

            foreach (Vertice v in vertices)
            {
                foreach (Aresta a in v.adjacentes)
                {
                    if (!existParVertices(verts, v.id, a.vertice.id))
                    {
                        verts.Add(new ParVertices(v.id, a.vertice.id));
                        Console.WriteLine(v.id + "; " + a.vertice.id + "; " + a.peso);
                    }

                }
            }
        }

        private bool existParVertices(List<ParVertices> verts, int v1, int v2)
        {
            foreach (ParVertices p in verts)
            {
                if (p.v1 == v2 && p.v2 == v1)
                {
                    return true;
                }
            }

            return false;
        }

        private class ParVertices
        {
            public int v1;
            public int v2;

            public ParVertices(int v1, int v2)
            {
                this.v1 = v1;
                this.v2 = v2;
            }
        }

    }
}
