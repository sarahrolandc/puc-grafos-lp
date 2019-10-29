using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public static class LeituraArquivo
    {
        public static GrafoNaoDirigido GrafoNaoDirigido(String nomeArquivo)
        {
            String s;
            String[] aux;

            StreamReader arquivoGrafo;

            try
            {
                arquivoGrafo = new StreamReader(nomeArquivo);

                int qtdVertices = int.Parse(arquivoGrafo.ReadLine());
                s = arquivoGrafo.ReadLine();

                Vertice[] vertices = new Vertice[qtdVertices];

                int verticeX;
                int verticeY;

                while (s != null)
                {
                    aux = s.Split(';');

                    verticeX = int.Parse(aux[0]) - 1;
                    verticeY = int.Parse(aux[1]) - 1;

                    if (vertices[verticeX] == null)
                    {
                        vertices[verticeX] = new Vertice(verticeX + 1);
                    }

                    if (vertices[verticeY] == null)
                    {
                        vertices[verticeY] = new Vertice(verticeY + 1);
                    }

                    vertices[verticeX].AddVerticeAdjacente(vertices[verticeY], int.Parse(aux[2]));
                    vertices[verticeY].AddVerticeAdjacente(vertices[verticeX], int.Parse(aux[2]));

                    s = arquivoGrafo.ReadLine();

                }

                GrafoNaoDirigido grafo = new GrafoNaoDirigido(VerticesPendentes(vertices));

                arquivoGrafo.Close();

                return grafo;

            }

            catch (FileNotFoundException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Metodo para verificar se não existem vertices pendentes, que não se ligam a nenhum outro
        //Porém precisam ser incluido no vetor de vertices do grafo
        private static Vertice[] VerticesPendentes(Vertice[] vertices)
        {
            for(int i = 0; i < vertices.Length; i++)
            {
                if (vertices[i] == null)
                {
                    vertices[i] = new Vertice(i + 1);
                }
            }

            return vertices;
        }

        public static GrafoDirigido GrafoDirigido(String nomeArquivo)
        {
            String s;
            String[] aux;

            StreamReader arquivoGrafo;

            try
            {
                arquivoGrafo = new StreamReader(nomeArquivo);

                int qtdVertices = int.Parse(arquivoGrafo.ReadLine());
                s = arquivoGrafo.ReadLine();

                Vertice[] vertices = new Vertice[qtdVertices];

                int verticeX;
                int verticeY;

                while (s != null)
                {
                    aux = s.Split(';');

                    verticeX = int.Parse(aux[0]) - 1;
                    verticeY = int.Parse(aux[1]) - 1;

                    if (vertices[verticeX] == null)
                    {

                        vertices[verticeX] = new Vertice(verticeX + 1);
                    }

                    if (vertices[verticeY] == null)
                    {

                        vertices[verticeY] = new Vertice(verticeY + 1);
                    }

                    int adjacencia = int.Parse(aux[3]);

                    if (adjacencia > 0)
                    {
                        vertices[verticeX].AddVerticeAdjacente(vertices[verticeY], int.Parse(aux[2]));
                    }
                    else
                    {
                        vertices[verticeY].AddVerticeAdjacente(vertices[verticeX], int.Parse(aux[2]));
                    }

                    s = arquivoGrafo.ReadLine();

                }

                GrafoDirigido grafo = new GrafoDirigido(VerticesPendentes(vertices));

                arquivoGrafo.Close();

                return grafo;

            }

            catch (FileNotFoundException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
