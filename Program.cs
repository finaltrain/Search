// 参考　https://tech-camp.in/note/technology/1050/
// 線形探索から選択ソートまでは上記ウェブサイトを参考にした
// 探索アルゴリズム及びソートアルゴリズムをC#で記述した

using System;

namespace ConsoleApp2
{
    class Program
    {
        static int[] input = { 3, 5, 9, 12, 15, 21, 29, 35, 42, 51, 62, 78, 81, 87, 92, 93 };
        static int[] raw_data = { 42, 21, 10, 2, 30, 51, 80, 90, 18, 56, 50, 25, 15, 95, 44, 69 };
        static int[] sorted_data = raw_data;

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
        static int[] Bubble_sort(int[] raw_data)
        {
            int[] data = (int[])raw_data.Clone();
            // tmp_dataを操作する。dataを操作するとそれ自体の値が変わってしまう。
            // C#では配列は参照型なので関数に渡してそのまま操作すると関数の中で値が変わる。
            // (int[])は型変換。

            for (int i = 0; i < data.Length; i++) // for文の初期化部で変数を宣言するパターン
            {
                for (int j = 1; j < data.Length; j++)
                {
                    if (data[j - 1] > data[j]) // ここの不等号変えると順番逆になる
                    {
                        int tmp = data[j - 1];
                        data[j - 1] = data[j];
                        data[j] = tmp;
                    }
                }
                //Lineup(tmp_data); // オンにすると配列の要素の変化が見れる
            }

            return data;
        }

        // 選択ソート
        static int[] Selection_sort(int[] raw_data)
        {
            int[] data = (int[])raw_data.Clone();

            for (int i = 0; i < data.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < data.Length; j++)
                {
                    if (data[min] > data[j]) min = j;
                }
                int tmp = data[min];
                data[min] = data[i];
                data[i] = tmp;
                //Lineup(tmp_data); 
            }

            return data;
        }

        // 自分で再発明した挿入ソート
        static int[] Re_Insertion_sort(int[] raw_data)
        {
            int[] data = (int[])raw_data.Clone();

            for (int i = 1; i < data.Length; i++)
            {
                int tmp = data[i];
                for (int j = 0; j < i; j++)
                {
                    if (data[j] > data[i])
                    {
                        int tmp_j = j;
                        for (j = i; tmp_j < j; j--)
                        {
                            data[j] = data[j - 1];
                        }
                        data[j] = tmp;
                        break;
                    }
                }
            }

            return data;
        }

        // 挿入ソート
        static int[] Insertion_sort(int[] raw_data)
        {
            int[] data = (int[])raw_data.Clone();
            for (int i = 1; i < data.Length; i++)
            {
                int tmp = data[i];
                if (data[i - 1] > tmp)
                {
                    int j = i;
                    do
                    {
                        data[j] = data[j - 1];
                        j--;
                    } while (j > 0 && data[j - 1] > tmp); // 継続条件式
                    data[j] = tmp;
                }
            }
            return data;
        }

        // マージソート
        static int[] Merge_sort(int[] raw_data)
        {
            int[] data = (int[])raw_data.Clone();

            int[] work = new int[(data.Length + 1) / 2];

            Merge_sort(data, 0, data.Length - 1, work);

            return data;
        }

        static void Merge_sort(int[] data, int left, int right, int[] work)
        {
            int mid = (right + left) / 2;
            if (left == right)
            {
                return;
            }
            Merge_sort(data, left, mid, work);
            Merge_sort(data, mid + 1, right, work);
            Merge(data, left, right, mid, work);
        }

        static void Merge(int[] data, int left, int right, int mid, int[] work)
        {
            for (int i = left; i <= mid; i++) // 左半分をworkへ
            {
                work[i - left] = data[i];
            }
            int l = left; // 右半分の最初
            int r = mid + 1; // 右半分の最後

            while (true)
            {
                int k = l + r - (mid + 1); // lにrの増分を加える
                if (l > mid) break; // 開始点がmidを超えたら終了
                if (r > right)
                {
                    while (l <= mid) // 開始点がmidを超えたらループを抜ける
                    {
                        k = l + r - (mid + 1); // lにrの増分を加える
                        // "l++ - left"は0,1,2,...ってなる
                        // kは0,1,2,...
                        data[k] = work[l++ - left];
                    }
                    break;
                }
                // 3項演算子 条件式?trueの場合の戻り値:falseの場合の戻り値
                // A.CompareTo(B) A-Bの結果と一致
                // ココを通過するとlかrがインクリメントされる
                data[k] = work[l - left].CompareTo(data[r]) < 0 ? work[l++ - left] : data[r++]; // workの[l - left]とtmp_dataの[r]を比較して
            }
        }

        // 自分で再発明したマージソート
        static int[] Re_Merge_sort(int[] raw_data)
        {
            int[] data = (int[])raw_data.Clone();
            int right = data.Length - 1; // 右端はdata.length "- 1"！！
            int left = 0;
            int mid = (right + left) / 2;
            int[] work = new int[data.Length];

            Re_Merge_sort(data, left, right, mid, work);

            return data;
        }

        static void Re_Merge_sort(int[] data, int left, int right, int mid, int[] work)
        {
            // まずは分割
            if (left == right) return;
            mid = (left + right) / 2;

            Re_Merge_sort(data, left, mid, mid, work);
            Re_Merge_sort(data, mid + 1, right, mid, work);

            // ここからマージ
            // 左右に分けて左と右の先頭を比較していき、小さい方をwork[]に並べていく
            // i,jは比較の対象の配列内の位置(iは左側、jは右側)
            // iとjは比較されるたびにインクリメントされるので、初期値を引けばカウンターとして使える
            for (int i = left, j = mid + 1; i <= mid;)
            {
                do
                {
                    if (data[i] < data[j])
                    {
                        work[i + j - left - mid - 1] = data[i++];
                        break;
                    }
                    else
                    {
                        work[i + j - left - mid - 1] = data[j++];
                    }
                } while (j <= right);

                if (i <= mid && j > right) // 比較対象が無くなって左が残った場合
                {
                    for (; i <= mid; i++)
                    {
                        work[i + j - left - mid - 1] = data[i];
                    }
                    break;
                }

                if (j <= right && i > mid) // 比較対象が無くなって右が残った場合
                {
                    for (; j <= right; j++)
                    {
                        work[i + j - left - mid - 1] = data[j];
                    }
                    break;
                }
            }

            //workからtmpdataへコピー
            for (int i = left; i <= right; i++)
            {
                data[i] = work[i - left];
            }
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
            Lineup(raw_data);
            sorted_data = Bubble_sort(raw_data);
            Lineup(sorted_data);

            sorted_data = raw_data;

            Console.WriteLine("\n選択ソート");
            Lineup(raw_data);
            sorted_data = Selection_sort(raw_data);
            Lineup(sorted_data);

            sorted_data = raw_data;

            Console.WriteLine("\n自分で再発明した挿入ソート");
            Lineup(raw_data);
            sorted_data = Re_Insertion_sort(raw_data);
            Lineup(sorted_data);

            sorted_data = raw_data;

            Console.WriteLine("\n挿入ソート");
            Lineup(raw_data);
            sorted_data = Re_Insertion_sort(raw_data);
            Lineup(sorted_data);

            sorted_data = raw_data;

            Console.WriteLine("\nマージソート");
            Lineup(raw_data);
            sorted_data = Merge_sort(raw_data);
            Lineup(sorted_data);

            sorted_data = raw_data;

            Console.WriteLine("\n自分で再発明したマージソート");
            Lineup(raw_data);
            sorted_data = Re_Merge_sort(raw_data);
            Lineup(sorted_data);

            return;
        }
    }
}