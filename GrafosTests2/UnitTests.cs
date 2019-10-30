using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grafos;

namespace GrafosTests2
{
    [TestClass()]
    public class UnitTests
    {
        [TestMethod()]
        public void isCompletoTest()
        {
            GrafoNaoDirigido grafo = new GrafoNaoDirigidoBuilder()
                .GrafoCompleto()
                .Build();

            Assert.AreEqual(grafo.isCompleto(), true);
        }

        [TestMethod()]
        public void isAdjacenteTest()
        {
            GrafoNaoDirigido grafo = new GrafoNaoDirigidoBuilder()
                .GrafoCompleto()
                .Build();

            Vertice v1 = grafo.vertices[0];
            Vertice v2 = grafo.vertices[1];

            Assert.AreEqual(grafo.isAdjacente(v1, v2), true);
        }

        [TestMethod()]
        public void isNotCompletoTest()
        {
            GrafoNaoDirigido grafo = new GrafoNaoDirigidoBuilder()
                .GrafoNaoCompleto()
                .Build();

            Assert.AreEqual(grafo.isCompleto(), false);
        }
        [TestMethod()]
        public void isRegular()
        {
            GrafoNaoDirigido grafo = new GrafoNaoDirigidoBuilder()
            .Regular()
            .Build();

            Assert.AreEqual(grafo.isRegular(), true);
        }

        [TestMethod()]
        public void getGrauEntradaTest()
        {
            GrafoDirigido grafo = new GrafoDirigidoBuilder()
                .GrafoComum()
                .Build();

            Vertice v1 = grafo.vertices[0];
            Vertice v2 = grafo.vertices[1];
            Vertice v3 = grafo.vertices[2];

            Assert.AreEqual(grafo.getGrauEntrada(v1), 1);
            Assert.AreEqual(grafo.getGrauEntrada(v2), 2);
            Assert.AreEqual(grafo.getGrauEntrada(v3), 1);
        }

        [TestMethod()]
        public void getGrauSaidaTest()
        {
            GrafoDirigido grafo = new GrafoDirigidoBuilder()
                .GrafoComum()
                .Build();

            Vertice v1 = grafo.vertices[0];
            Vertice v2 = grafo.vertices[1];
            Vertice v3 = grafo.vertices[2];

            Assert.AreEqual(grafo.getGrauSaida(v1), 2);
            Assert.AreEqual(grafo.getGrauSaida(v2), 1);
            Assert.AreEqual(grafo.getGrauSaida(v3), 1);

        }

    }
}
