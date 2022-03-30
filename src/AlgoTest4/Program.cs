using System;
using System.Collections.Generic;

namespace AlgoTest4
{

    class Graph
    {
        int[,] adj = new int[6, 6]
        {
            {0,1,0,1,0,0 },
            {1,0,1,1,0,0 },
            {0,1,0,0,0,0 },
            {1,1,0,0,1,0 },
            {0,0,0,1,0,1 },
            //{1,1,0,0,0,0 },
            //{0,0,0,0,0,1 },
            {0,0,0,0,1,0 },
        };

        List<int>[] adj2 = new List<int>[]
        {
            new List<int>(){ 1, 3 },
            new List<int>(){ 0,2,3 },
            new List<int>(){ 1 },
            new List<int>(){ 0,1,4},
            new List<int>(){ 3,5 },
            //new List<int>(){ 0,1},
            //new List<int>(){ 5 },
            new List<int>(){ 4},
        };


        public void BFS(int start)
        {
            bool[] found = new bool[6];
            int[] parent = new int[6];
            int[] distance = new int[6];

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            found[start] = true;

            parent[start] = start;
            distance[start] = 0;

            while (queue.Count > 0)
            {
                int now = queue.Dequeue();
                Console.WriteLine(now);

                for (int next = 0; next < 6; next++)
                {
                    if (adj[now, next] == 0)   // 인접하지 않았으면 스킵
                        continue;
                    if (found[next])    // 이미 발견한 애라면 스킵
                        continue;
                    queue.Enqueue(next);    
                    found[next] = true;

                    parent[next] = now;
                    distance[next] = distance[now] + 1;

                }
            }
        }


        bool[] visited = new bool[6];

        // DFS는 시작점이 필요함 = now
        // 1. now 부터 방문
        // 2. now와 연결된 정점들을 하나씩 확인해서, [아직 미발견(미방문)] 상태라면 방문한다.
        public void DFS(int now)
        {
            Console.WriteLine(now);
            visited[now] = true;    // now 부터 방문

            for (int next = 0; next < 6; next++)
            {
                if (adj[now, next] == 0)  // 연결되어 있지 않으면 스킵.
                    continue;

                if (visited[next])  // 이미 방문했으면 스킵
                    continue;

                // 재귀함수
                DFS(next);
            }
        }

        public void DFS2(int now)
        {
            Console.WriteLine(now);
            visited[now] = true;    // now 부터 방문

            foreach (int next in adj2[now])
            {
                if (visited[next])  // 이미 방문했으면 스킵
                    continue;

                DFS2(next);
            }

        }

        // 단절된 길을 방문하기 위해
        public void SearchAll()
        {
            visited = new bool[6];
            for (int now = 0; now < 6; now++)
            {
                if (visited[now] == false)
                {
                    DFS(now);
                }
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            // 그래프
            // 현실 세계의 사물이나 추상적인 개념 간의 연결관계를 표현
            // 정점(vertex) : 데이터를 표현(사물,개념 등)
            // 간선(edge) : 정점들을 연결하는 데 사용

            // 가중치 그래프
            // ex ) 지하철 노선도
            // 방향 그래프
            // ex ) 일방 통행이 포함된 도로망

            // list를 이용한 그래프 표현
            // 메모리를 아낄 수 있지만, 접근 속도에서 손해를 본다.

            // 행렬(2차원배열) 이용
            // 메모리 소모가 심하지만, 빠른 접근이 가능하다.

            // DFS (DEPTH FIRST SEARCH 깊이 우선 탐색)
            // BFS (BREADTH FIRST SEARCH 너비 우선 탐색)


            Graph graph = new Graph();
            graph.DFS(3);

            graph.DFS2(3);

            graph.SearchAll();

            graph.BFS(0);


        }
    }
}
