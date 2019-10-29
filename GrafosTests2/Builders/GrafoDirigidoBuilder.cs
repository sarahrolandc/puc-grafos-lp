using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grafos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafosTests2
{
    public class GrafoDirigidoBuilder
    {
        private Grafo grafo;
        public GrafoDirigidoBuilder()
        {

        }

        public GrafoDirigidoBuilder GrafoComCiclo()
        {
            this.grafo = LeituraArquivo.GrafoDirigido(@"..\..\txts\Dirigido\ComCiclo.txt");
            return this;
        }

        public GrafoDirigidoBuilder GrafoSemCiclo()
        {
            this.grafo = LeituraArquivo.GrafoDirigido(@"..\..\txts\Dirigido\SemCiclo.txt");
            return this;
        }

        public GrafoDirigidoBuilder GrafoComum()
        {
            this.grafo = LeituraArquivo.GrafoDirigido(@"..\..\txts\Dirigido\ComCiclo.txt");
            return this;
        }

        public GrafoDirigido Build()
        {
            return new GrafoDirigido(grafo.vertices);
        }


    }
}
