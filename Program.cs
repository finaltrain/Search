// 参考　https://tech-camp.in/note/technology/1050/
// 上記ウェブサイトを参考にして探索アルゴリズム及びソートアルゴリズムをC#で記述した

using System;

namespace ConsoleApp2
{
    class Program
    {
        static int[] input = { 3, 5, 9, 12, 15, 21, 29, 35, 42, 51, 62, 78, 81, 87, 92, 93 };
        static int[] data = { 42, 21, 10, 2, 30, 51, 80, 90, 18, 56, 50, 25, 15, 95, 44, 69 };

        // 線形探索(for文)
        static void Linear_search(int key)
        {
            int i;

            bool find_flag = false;

            for (i = 0; i < input.Length; i++) // .Lengthプロパティは配列の要素の総数を取得
            {
                if (Program.input[i] == key)
                {
                    Console.WriteLine(key + "を" + i + "番で発見しました");
                    find_flag = true;
                    break;
                }
            }
            if (find_flag == false) Console.WriteLine(key + "は見つかりませんでした");
        }

        // 線形探索(foreach文で有無確認)
        static void Linear_search_foreach(int key)
        {
            bool find_flag = false;

            foreach (int i in input)
            {
                if (i == key)
                {
                    Console.WriteLine(key + "を発見しました");
                    find_flag = true;
                    break;
                }
            }
            if (find_flag == false) Console.WriteLine(key + "は見つかりませんでした");
        }

        // 二分探索
        static void Binary_serch(int key)
        {
            bool find_flag = false;

            int search_left = 0;
            int search_right = input.Length - 1;
            int pivot = 0;

            while (search_left < search_right)// この条件から外れることは無いはず？
            {
                pivot = (search_left + search_right) / 2;
                Console.WriteLine("[" + search_left + "]から[" + search_right + "]の中心の" + pivot + "番を参照");// 参考
                if (input[pivot] == key)
                {
                    find_flag = true;
                    break;
                }
                if (pivot == search_left || pivot == search_right) break;// find_flag = falseでbreak
                if (key < input[pivot]) search_right = pivot;
                if (key > input[pivot]) search_left = pivot;
            }

            if (find_flag == true) Console.WriteLine(key + "を" + pivot + "番で発見しました");
            else Console.WriteLine(key + "は見つかりませんでした");
        }

        // バブルソート
        static void Bubble_sort(int[] data)
        {
            for (int i = 0; i < data.Length; i++)// for文の初期化部で変数を宣言するパターン
            {
                for (int j = 1; j < data.Length; j++)
                {
                    if (data[j - 1] > data[j])// ここの不等号変えると順番逆になる
                    {
                        int tmp = data[j - 1];
                        data[j - 1] = data[j];
                        data[j] = tmp;
                    }
                }
            }
        }
        
        static void Main()
        {
            Console.WriteLine("線形探索(for文)");
            Linear_search(62);
            Linear_search(9);
            Linear_search(10);

            Console.WriteLine("\n線形探索(foreach文で有無確認)");
            Linear_search_foreach(62);
            Linear_search_foreach(9);
            Linear_search_foreach(10);

            Console.WriteLine("\n二分探索(ソート済みのデータにしか使えない)");
            Binary_serch(62);
            Binary_serch(9);
            Binary_serch(10);

            Console.WriteLine("\nバブルソート");
            for (int i = 0; i < data.Length; i++) Console.Write(data[i] + ";");
            Console.Write("\n");
            Bubble_sort(data);
            for (int i = 0; i < data.Length; i++) Console.Write(data[i] + ";");
            Console.Write("\n");

            return;
        }
    }
}
