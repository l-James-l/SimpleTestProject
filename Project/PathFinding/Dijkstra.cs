namespace Project.PathFinding;

public class Dijkstra
{
    public int[] FindShortestPaths(int[,] adjacencyMatrix, int source)
    {
        int vertexCount = adjacencyMatrix.GetLength(0);
        bool[] visited = new bool[vertexCount];
        int[] distances = new int[vertexCount];

        for (int i = 0; i < vertexCount; i++)
        {
            distances[i] = int.MaxValue;
            visited[i] = false;
        }

        distances[source] = 0;
        
        for (int count = 0; count < vertexCount - 1; count++)
        {
            // This makes the time complexity O(V^2). Using a priority queue would reduce it to O(E log V)
            int u = MinDistance(distances, visited);
            visited[u] = true;
            for (int v = 0; v < vertexCount; v++)
            {
                if (!visited[v] && adjacencyMatrix[u, v] != int.MaxValue &&
                    distances[u] != int.MaxValue &&
                    distances[u] + adjacencyMatrix[u, v] < distances[v])
                {
                    distances[v] = distances[u] + adjacencyMatrix[u, v];
                }
            }
        }
        return distances;
    }

    private int MinDistance(int[] distances, bool[] visited)
    {
        int min = int.MaxValue;
        int minIndex = -1;
        for (int v = 0; v < distances.Length; v++)
        {
            if (!visited[v] && distances[v] <= min)
            {
                min = distances[v];
                minIndex = v;
            }
        }
        return minIndex;
    }

}
