using System;

namespace CSharpTest6
{
    //    두 알고리즘을 A와 B를 비교한다면?
    //    1. A 보다 B가 "조금","많이" 빨라요 => 애매모호
    //    2. 프로그램을 짜서 실행 속도 비교 => 환경에 의존적
    //    3. 입력이 적은 구간과 많은 구간에서 성능이 확연하게 차이가 날 경우

    //    대안으로 BIG-O 표기법을 사용


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int Add(int N)
        {
            return N + N;
        }

        public int Add2(int N)
        {
            int sum = 0;
            for (int i = 0; i < N; i++)
            {
                sum += i;
            }
            return sum;
        }

        public int Add3(int N)
        {
            int sum = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    sum += i;
                }
            }
            return sum;
        }

        //  규칙 1) 영향력이 가장 큰 대표 항목만 남기고 삭제
        //  규칙 2) 상속 무시 (ex. 2N => N)

        public int Add4(int N)
        {
            int sum = 0;
            for (int i = 0; i < N; i++)
            {
                sum += i;
            }

            for (int i = 0; i < 2 * N; i++)
            {
                for (int j = 0; j < 2 * N; j++)
                {
                    sum += 1;
                }
            }

            sum += 1234567;

            return sum;

            //  O(1 + N + 4 * N² + 1)
            //  = O(4 * N²)
            //  = O(N²)

            //  * O는 Order Of 
            // 속도가 가장 빠름                       속도가 가장 느림
            // O(1) > O(Log n) > O(n) > O(n log n) > O (n²)
        }



    }
}
