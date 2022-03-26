using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest1
{
    class MyList<T>
    {
        const int DEFAULT_SZIE = 1;
        T[] _data = new T[DEFAULT_SZIE];

        public int Count;       // 실제로 사용중인 데이터 개수
        public int Capacity { get { return _data.Length; } }    // 예약된 데이터 개수

        public void Add(T item)
        {
            // 1. 공간이 충분히 남아 있는지 확인한다.
            if (Count >= Capacity)
            {
                // 공간을 다시 늘려서 확보한다.

                T[] newArray = new T[Count * 2];
                for (int i = 0; i < Count; i++)
                    newArray[i] = _data[i];
                _data = newArray;
            }


            // 2. 공간에다가 데이터를 넣어 준다.
            _data[Count] = item;
            Count++;

        }

        public T this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                _data[i] = _data[i + 1];
            }
            _data[Count - 1] = default(T);
            // default(T)
            // T가 정수형이면 0을 반환
            // T가 클래스타입이라면 Null을 반환
            Count--;
        }

    }


    class MyLinkedListNode<T>
    {
        public T Data;
        public MyLinkedListNode<T> Next;
        public MyLinkedListNode<T> Prev;
    }

    class MyLinkedList<T>
    {
        public MyLinkedListNode<T> Head = null;  // 첫번째
        public MyLinkedListNode<T> Tail = null;  // 마지막
        public int Count = 0;

        public MyLinkedListNode<T> AddLast(T data)
        {
            MyLinkedListNode<T> newRoom = new MyLinkedListNode<T>();
            newRoom.Data = data; 

            // 만약 방이 없었다면, 새로 추가한 첫번째 방이 Head이다
            if(Head == null)
            {
                Head = newRoom;
            }

            // 기존에 마지막 방과 새로 추가되는 방을 연결해준다
            if(Tail != null)
            {
                Tail.Next = newRoom;
                newRoom.Prev = Tail;
            }

            // 새로 추가되는 방을 마지막방으로 지정한다.
            Tail = newRoom;
            Count++;    
            return newRoom;
        }


        public void Remove(MyLinkedListNode<T> room)
        {
            // 기존 첫번째 방의 다음방을 첫번째 방으로 인정한다.
            if(Head == room)
                Head = Head.Next;

            // 기존 마지막 방의 이전방을 마지막 방으로 인정한다.
            if (Tail == room)
                Tail = Tail.Prev;

            if (room.Prev != null)
                room.Prev.Next = room.Next;

            if (room.Next != null)
                room.Next.Prev = room.Prev;

            Count--;
        }
    }


    class Board
    {
        public int[] _data = new int[25];  //배열
        public MyList<int> _data2 = new MyList<int>();  // 동적배열
        public MyLinkedList<int> _data3 = new MyLinkedList<int>(); // 연결리스트

        public void Initialize()
        {

            _data3.AddLast(101);
            _data3.AddLast(102);
            MyLinkedListNode<int> node = _data3.AddLast(103);
            _data3.AddLast(104);
            _data3.AddLast(105);

            _data3.Remove(node);

            // _data2.Add(101);
            // _data2.Add(102);
            // _data2.Add(103);
            // _data2.Add(104);
            // _data2.Add(105);
            // 
            // int temp = _data2[2];
            // 
            // _data2.RemoveAt(2);

        }
    }
}
