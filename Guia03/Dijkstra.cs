using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia03
{
    public class Dijkstra
    {
        public int[] D { get; private set; }
        private int[,] graph;
        private int nodesCount;

        public Dijkstra(int nodesCount, int[,] graph)
        {
            this.nodesCount = nodesCount;
            this.graph = graph;
            D = new int[nodesCount];
        }

        public void RunDijkstra(int startNode)
        {
            bool[] shortestPathTreeSet = new bool[nodesCount];

            for (int i = 0; i < nodesCount; i++)
            {
                D[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            D[startNode] = 0;

            for (int count = 0; count < nodesCount - 1; count++)
            {
                int u = MinDistance(D, shortestPathTreeSet);

                shortestPathTreeSet[u] = true;

                for (int v = 0; v < nodesCount; v++)
                {
                    if (!shortestPathTreeSet[v] && graph[u, v] != -1 &&
                        D[u] != int.MaxValue && D[u] + graph[u, v] < D[v])
                    {
                        D[v] = D[u] + graph[u, v];
                    }
                }
            }
        }

        private int MinDistance(int[] dist, bool[] sptSet)
        {
            int min = int.MaxValue, minIndex = -1;

            for (int v = 0; v < nodesCount; v++)
            {
                if (!sptSet[v] && dist[v] <= min)
                {
                    min = dist[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }
    }

}
