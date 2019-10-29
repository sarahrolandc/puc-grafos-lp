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
    public class GrafoNaoDirigidoTests
    {

        [TestMethod]
        public void CutVertice()
        {
            GrafoNaoDirigido grafo = new GrafoNaoDirigidoBuilder()
            .CutVertices()
            .Build();

            Assert.AreEqual(grafo.getCutVertices(), 6);
        }

        [TestMethod()]
        public void Kruskal()
        {
            GrafoNaoDirigido grafo = new GrafoNaoDirigidoBuilder()
               .Prim()
               .Build();

            GrafoNaoDirigido grafoEsperado = new GrafoNaoDirigidoBuilder()
               .PrimEsperado()
               .Build();

            bool expected = grafo.getAGMKruskal().Equals(grafoEsperado);

            Assert.AreEqual(expected, true);
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
        public void isCompletoTest()
        {
            GrafoNaoDirigido grafo = new GrafoNaoDirigidoBuilder()
                .GrafoCompleto()
                .Build();

            Assert.AreEqual(grafo.isCompleto(), true);
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
        public void isConexoTest()
        {
            GrafoNaoDirigido grafo = new GrafoNaoDirigidoBuilder()
                .GrafoConexo()
                .Build();

            Assert.AreEqual(grafo.isConexo(), true);
        }

        [TestMethod()]
        public void isNotConexoTest()
        {
            GrafoNaoDirigido grafo = new GrafoNaoDirigidoBuilder()
                .GrafoNaoConexo()
                .Build();

            Assert.AreEqual(grafo.isConexo(), false);
        }

        [TestMethod()]
        public void isEulerianoTest()
        {
            GrafoNaoDirigido grafo = new GrafoNaoDirigidoBuilder()
                .GrafoEuleriano()
                .Build();

            Assert.AreEqual(grafo.isEuleriano(), true);
        }

        [TestMethod()]
        public void isNotEulerianoTest()
        {
            GrafoNaoDirigido grafo = new GrafoNaoDirigidoBuilder()
                .GrafoNaoEuleriano()
                .Build();

            Assert.AreEqual(grafo.isEuleriano(), false);
        }

        [TestMethod()]
        public void isUnicursalTest()
        {
            GrafoNaoDirigido grafo = new GrafoNaoDirigidoBuilder()
               .GrafoUnicursal()
               .Build();

            Assert.AreEqual(grafo.isUnicursal(), true);            
        }

        [TestMethod()]
        public void isNotUnicursalTest()
        {
            GrafoNaoDirigido grafo = new GrafoNaoDirigidoBuilder()
               .GrafoNaoUnicursal()
               .Build();

            Assert.AreEqual(grafo.isUnicursal(), false);
        }

        [TestMethod()]
        public void getComplementarTest()
        {
            GrafoNaoDirigido grafo = new GrafoNaoDirigidoBuilder()
               .GrafoNaoCompleto()
               .Build();

            GrafoNaoDirigido grafoComplentar = new GrafoNaoDirigidoBuilder()
               .GrafoComplementar()
               .Build();

            bool expected = grafo.getComplementar().Equals(grafoComplentar);

            Assert.AreEqual(expected, true);            
        }

        [TestMethod()]
        public void getAGMPrimTest()
        {
            GrafoNaoDirigido grafo = new GrafoNaoDirigidoBuilder()
               .Prim()
               .Build();

            GrafoNaoDirigido grafoEsperado = new GrafoNaoDirigidoBuilder()
               .PrimEsperado()
               .Build();

            Vertice v1 = grafo.vertices[0];

            bool expected = grafo.getAGMPrim(v1).Equals(grafoEsperado);

            Assert.AreEqual(expected, true);
        }        


    }
}