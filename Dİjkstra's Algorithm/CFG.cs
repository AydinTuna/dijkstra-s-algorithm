using System;

public class CFG
{
    static int V = 9;

    int minDistance(int[] dist, bool[] sptSet)
    {
        int min = int.MaxValue;
        int min_index = -1;

        for (int v = 0; v < V; v++)
        {
            if (sptSet[v] == false && dist[v] <= min)
            {
                min = dist[v];
                min_index = v;
            }
        }
        return min_index;
    }

    void printSolution(int[] dist, int target)
    {
        Console.WriteLine("Vertex \t\t Distance " + "from Source\n");

        for (int i = 0; i < V; i++)
        {

            if (i == target)
            {
                Console.WriteLine("The target: " + i + " \t\t " + "Shortest Distance: " + dist[i] + "\n");
                continue;
            }

            Console.WriteLine(i + " \t\t " + dist[i] + "\n");
        }

    }

    public void dijkstra(int[,] graph, int src, int targetV)
    {
        int[] dist = new int[V];

        bool[] sptSet = new bool[V];

        for (int i = 0; i < V; i++)
        {
            dist[i] = int.MaxValue;
            sptSet[i] = false;
        }

        dist[src] = 0;

        for (int count = 0; count < V - 1; count++)
        {
            int u = minDistance(dist, sptSet);

            sptSet[u] = true;

            for (int v = 0; v < V; v++)
            {
                if (!sptSet[v] && graph[u, v] != 0
                && dist[u] != int.MaxValue
                && dist[u] + graph[u, v] < dist[v])
                {
                    dist[v] = dist[u] + graph[u, v];
                }
            }
        }

        printSolution(dist, targetV);
    }
}


