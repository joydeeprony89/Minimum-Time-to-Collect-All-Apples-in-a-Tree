// See https://aka.ms/new-console-template for more information

Solution s = new Solution();
var edges = new int[3][] { new int[] {0, 2 }, new int[] { 0, 3 }, new int[] { 1, 2 } };
var hasApple = new List<bool> { false, true, false, false };
int n = 4;
var answer = s.MinTime(n, edges, hasApple);
Console.WriteLine(answer);

public class Solution
{
  public int MinTime(int n, int[][] edges, IList<bool> hasApple)
  {
    var adj = new Dictionary<int, List<int>>();
    foreach (var edge in edges)
    {
      var s = edge[0];
      var d = edge[1];
      if (!adj.ContainsKey(s)) adj.Add(s, new List<int>());
      if (!adj.ContainsKey(d)) adj.Add(d, new List<int>());
      adj[s].Add(d);
      adj[d].Add(s);
    }

    var visited = new HashSet<int>();
    int Helper(int node)
    {
      visited.Add(node);
      int count = 0;
      if (adj.ContainsKey(node))
      {
        foreach (var e in adj[node])
        {
          if (!visited.Contains(e))
          {
            count += Helper(e);
          }
        }
      }
      if ((count > 0 || hasApple[node]) && node != 0) count += 2;

      return count;
    }
    return Helper(0);
  }
}
