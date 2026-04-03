namespace Project.PathFinding;

public class BellmanFord
{
    public (int[] distances, int[] predecsors) FindShortestPath(int[,] adjacencyLists, int source) 
    {
        int vertexCount = adjacencyLists.GetLength(0);
        int[] distances = new int[vertexCount];
        int[] predecessors = new int[vertexCount];
        for (int i = 0; i < vertexCount; i++)
        {
            distances[i] = int.MaxValue;
            predecessors[i] = -1;
        }
        distances[source] = 0;
        for (int i = 0; i< vertexCount - 1; i++)
        {
            // Despite the 2 for loops, this is only O(E) as we only consider edges that exist.
            // Including the outer loop, this is O(VE)
            for (int u = 0; u < vertexCount; u++)
            {
                for (int v = 0; v < vertexCount; v++)
                {
                    if (adjacencyLists[u, v] != int.MaxValue)
                    {
                        if (distances[u] != int.MaxValue && distances[u] + adjacencyLists[u, v] < distances[v])
                        {
                            distances[v] = distances[u] + adjacencyLists[u, v];
                            predecessors[v] = u;
                        }
                    }
                }
            }
        }
        return (distances, predecessors);
    }
}