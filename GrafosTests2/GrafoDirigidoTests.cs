using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grafos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafosTests2
{
    [TestClass()]
    public class GrafoDirigidoTests
    {
        [TestMethod()]
        public void hasCicloTest()
        {
            GrafoDirigido grafo = new GrafoDirigidoBuilder()
                .GrafoComCiclo()
                .Build();

            Assert.AreEqual(grafo.hasCiclo(), true);
        }

        [TestMethod()]
        public void hasNotCicloTest()
        {
            GrafoDirigido grafo = new GrafoDirigidoBuilder()
                .GrafoSemCiclo()
                .Build();

            Assert.AreEqual(grafo.hasCiclo(), false);
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
