using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grafos;

namespace GrafosTests2
{
    [TestClass()]
    public class IntegrationTests
    {
        //Testes de integração considerando métodos de interação intra classe

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