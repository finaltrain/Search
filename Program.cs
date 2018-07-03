// 参考　https://tech-camp.in/note/technology/1050/
// 線形探索から選択ソートまでは上記ウェブサイトを参考にした
// 探索アルゴリズム及びソートアルゴリズムをC#で記述した

using System;

namespace ConsoleApp2
{
    class Program
    {
        static int[] input = { 3, 5, 9, 12, 15, 21, 29, 35, 42, 51, 62, 78, 81, 87, 92, 93 };
        static int[] data = { 42, 21, 10, 2, 30, 51, 80, 90, 18, 56, 50, 25, 15, 95, 44, 69 };
        static int[] sorted_data = data;

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

            while (search_left < search_right) // この条件から外れることは無いはず？
            {
                pivot = (search_left + search_right) / 2;
                //Console.WriteLine("[" + search_left + "]から[" + search_right + "]の中心の" + pivot + "番を参照"); // オンにすると探索の流れがわかる
                if (input[pivot] == key)
                {
                    find_flag = true;
                    break;
                }
                if (pivot == search_left || pivot == search_right) break; // find_flag = falseでbreak
                if (key < input[pivot]) search_right = pivot;
                if (key > input[pivot]) search_left = pivot;
            }

            if (find_flag == true) Console.WriteLine(key + "を" + pivot + "番で発見しました");
            else Console.WriteLine(key + "は見つかりませんでした");
        }

        // バブルソート
        static int[] Bubble_sort(int[] data)
        {
            int[] tmp_data = (int[])data.Clone();
            // tmp_dataを操作する。dataを操作するとそれ自体の値が変わってしまう。
            // C#では配列は参照型なので関数に渡してそのまま操作すると関数の中で値が変わる。
            // (int[])は型変換。

            for (int i = 0; i < tmp_data.Length; i++) // for文の初期化部で変数を宣言するパターン
            {
                for (int j = 1; j < tmp_data.Length; j++)
                {
                    if (tmp_data[j - 1] > tmp_data[j]) // ここの不等号変えると順番逆になる
                    {
                        int tmp = tmp_data[j - 1];
                        tmp_data[j - 1] = tmp_data[j];
                        tmp_data[j] = tmp;
                    }
                }
                //Lineup(tmp_data); // オンにすると配列の要素の変化が見れる
            }

            return tmp_data;
        }

        // 選択ソート
        static int[] Selection_sort(int[] data)
        {
            int[] tmp_data = (int[])data.Clone();

            for (int i = 0; i < tmp_data.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < tmp_data.Length; j++)
                {
                    if (tmp_data[min] > tmp_data[j]) min = j;
                }
                int tmp = tmp_data[min];
                tmp_data[min] = tmp_data[i];
                tmp_data[i] = tmp;
                //Lineup(tmp_data); 
            }

            return tmp_data;
        }

        // 自分で再発明した挿入ソート
        static int[] Re_Insertion_sort(int[] data)
        {
            int[] tmp_data = (int[])data.Clone();

            for (int i = 1; i < tmp_data.Length; i++)
            {
                int tmp = tmp_data[i];
                for (int j = 0; j < i; j++)
                {
                    if (tmp_data[j] > tmp_data[i])
                    {
                        int tmp_j = j;
                        for (j = i; tmp_j < j; j--)
                        {
                            tmp_data[j] = tmp_data[j - 1];
                        }
                        tmp_data[j] = tmp;
                        break;
                    }
                }
            }

            return tmp_data;
        }

        // 挿入ソート
        static int[] Insertion_sort(int[] data)
        {
            int[] tmp_data = (int[])data.Clone();
            for (int i = 1; i < tmp_data.Length; i++)
            {
                int tmp = tmp_data[i];
                if (tmp_data[i - 1] > tmp)
                {
                    int j = i;
                    do
                    {
                        tmp_data[j] = tmp_data[j - 1];
                        j--;
                    } while (j > 0 && tmp_data[j - 1] > tmp); // 継続条件式
                    tmp_data[j] = tmp;
                }
            }
            return tmp_data;
        }

        // 配列の各要素を表示
        static void Lineup(int[] data)
        {
            for (int i = 0; i < data.Length; i++) Console.Write(data[i] + ";");
            Console.Write("\n");
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
            Lineup(data);
            sorted_data = Bubble_sort(data);
            Lineup(sorted_data);

            sorted_data = data;

            Console.WriteLine("\n選択ソート");
            Lineup(data);
            sorted_data = Selection_sort(data);
            Lineup(sorted_data);

            sorted_data = data;

            Console.WriteLine("\n自分で再発明した挿入ソート");
            Lineup(data);
            sorted_data = Re_Insertion_sort(data);
            Lineup(sorted_data);

            sorted_data = data;

            Console.WriteLine("\n挿入ソート");
            Lineup(data);
            sorted_data = Re_Insertion_sort(data);
            Lineup(sorted_data);

            return;
        }
    }
}