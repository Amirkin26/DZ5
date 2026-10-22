class Graph
{
    private List<int>[] adjacency;

    public Graph(int count)
    {
        adjacency = new List<int>[count];

        for (int i = 0; i < count; i++) adjacency[i] = new List<int>();
    }

    public void AddEdge(int a, int b)
    {
        adjacency[a].Add(b);
        adjacency[b].Add(a);
    }

    public List<int> ShortestPath(int start, int end)
    {
        Queue<int> queue = new Queue<int>();
        bool[] visited = new bool[adjacency.Length];
        int[] previous = new int[adjacency.Length];

        for (int i = 0; i < previous.Length; i++) previous[i] = -1;

        queue.Enqueue(start);
        visited[start] = true;

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            if (current == end)
                break;

            for (int i = 0; i < adjacency[current].Count; i++)
            {
                int next = adjacency[current][i];

                if (!visited[next])
                {
                    visited[next] = true;
                    previous[next] = current;
                    queue.Enqueue(next);
                }
            }
        }

        List<int> path = new List<int>();

        if (!visited[end])
            return path;

        int vertex = end;

        while (vertex != -1)
        {
            path.Add(vertex);
            vertex = previous[vertex];
        }

        path.Reverse();

        return path;
    }
}