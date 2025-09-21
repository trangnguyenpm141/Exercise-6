using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

internal class Exercise_06
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1. Bai 1 - Jagged Array");
            Console.WriteLine("2. Bai 2 - Quan ly cong ty X");
            Console.WriteLine("0. Thoat");
            Console.Write("Chon bai: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Ex01();
                    break;
                case 2:
                    Ex02();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Lua chon khong hop le.");
                    break;
            }
        }
    }

    /* ================= BAI 1 ================= */
    static void Ex01()
    {
        Console.WriteLine("\n Bai 1: Jagged Array");

        // Y/c 1: Tao jagged array co dinh va in ra
        Console.WriteLine("\nYeu cau 1: Jagged array co dinh");
        int[][] a = new int[4][];
        a[0] = new int[5] { 1, 1, 1, 1, 1 };
        a[1] = new int[2] { 2, 2 };
        a[2] = new int[4] { 3, 3, 3, 3 };
        a[3] = new int[2] { 4, 4 };
        int rows = a.Length;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < a[i].Length; j++)
            {
                Console.Write($"{a[i][j]}\t");
            }
            Console.WriteLine();
        }

        // Y/c 2: Tao jagged array ngau nhien va thuc hien cac yeu cau
        Console.WriteLine("\nYeu cau 2: Tao Jagged array ngau nhien va thuc hien cac yeu cau ");
        Console.Write("Nhap so dong: ");
        int rows2 = int.Parse(Console.ReadLine());
        int[][] jagged2 = new int[rows2][];
        Random rand = new Random();

        for (int i = 0; i < rows2; i++)
        {
            Console.Write($"Nhap so cot cho dong {i + 1}: ");
            int cols = int.Parse(Console.ReadLine());
            jagged2[i] = new int[cols];

            for (int j = 0; j < cols; j++)
            {
                jagged2[i][j] = rand.Next(1, 100);
            }
        }

        Console.WriteLine("Mang vua tao:");
        InJaggedArray(jagged2);

        // 2.1 In ra so lon nhat moi hang va so lon nhat toan mang
        Console.WriteLine("\n-- 2.1. So lon nhat moi hang va toan mang --");
        int max_arr = jagged2[0][0];
        for (int i = 0; i < jagged2.Length; i++)
        {
            int maxRow = jagged2[i][0];
            for (int j = 1; j < jagged2[i].Length; j++)
            {
                if (maxRow < jagged2[i][j])
                    maxRow = jagged2[i][j];
            }
            Console.WriteLine($"So lon nhat cua hang {i} la: {maxRow}");
            if (max_arr < maxRow)
                max_arr = maxRow;
        }
        Console.WriteLine($"Gia tri lon nhat toan mang la: {max_arr}");

        // 2.2 Sap xep tang dan tung dong
        Console.WriteLine("\n-- 2.2. Sap xep tang dan tung dong --");
        for (int i = 0; i < jagged2.Length; i++)
        {
            Array.Sort(jagged2[i]);
        }
        InJaggedArray(jagged2);

        // 2.3 In ra cac so nguyen to trong mang
        Console.WriteLine("\n-- 2.3. Cac so nguyen to trong mang --");
        for (int i = 0; i < jagged2.Length; i++)
        {
            for (int j = 0; j < jagged2[i].Length; j++)
            {
                if (LaSoNguyenTo(jagged2[i][j]))
                {
                    Console.Write(jagged2[i][j] + " ");
                }
            }
        }
        Console.WriteLine();

        // 2.4 Tim tat ca vi xuat hien cua mot so
        static bool LaSoNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0) return false;
            return true;
        }
        Console.WriteLine("\n-- 2.4. Tim vi tri xuat hien cua mot so --");
        Console.Write("Nhap so can tim: ");
        int x = int.Parse(Console.ReadLine());
        bool found = false;
        for (int i = 0; i < jagged2.Length; i++)
        {
            for (int j = 0; j < jagged2[i].Length; j++)
            {
                if (jagged2[i][j] == x)
                {
                    Console.WriteLine($"So {x} xuat hien tai dong {i + 1}, cot {j + 1}");
                    found = true;
                }
            }
        }
        if (!found)
        {
            Console.WriteLine($"So {x} khong tom tai trong mang.");
        }
    }

    static void InJaggedArray(int[][] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine("Hang " + (i + 1) + ": " + string.Join(" ", arr[i]));
        }
    }

    /* ================= BAI 2 ================= */
    class Member
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public int CompletedTasks { get; set; }
    }

    static void Ex02()
    {
        Console.WriteLine("\n===== Bai 2: Quan ly cong ty X =====");

        // 1. Khoi tao du lieu voi cac gia tri duoc gan san
        List<Member>[] groups = new List<Member>[3];
        groups[0] = new List<Member>();
        groups[1] = new List<Member>();
        groups[2] = new List<Member>();

        groups[0].Add(new Member { ID = 1, FullName = "Nguyen Van A", CompletedTasks = 12 });
        groups[0].Add(new Member { ID = 2, FullName = "Tran Thi B", CompletedTasks = 8 });
        groups[0].Add(new Member { ID = 3, FullName = "Le Van C", CompletedTasks = 15 });
        groups[0].Add(new Member { ID = 4, FullName = "Pham Thi D", CompletedTasks = 9 });
        groups[0].Add(new Member { ID = 5, FullName = "Hoang Van E", CompletedTasks = 20 });

        groups[1].Add(new Member { ID = 6, FullName = "Nguyen Van F", CompletedTasks = 7 });
        groups[1].Add(new Member { ID = 7, FullName = "Tran Thi G", CompletedTasks = 14 });
        groups[1].Add(new Member { ID = 8, FullName = "Le Van H", CompletedTasks = 10 });

        groups[2].Add(new Member { ID = 9, FullName = "Pham Van I", CompletedTasks = 22 });
        groups[2].Add(new Member { ID = 10, FullName = "Nguyen Thi J", CompletedTasks = 18 });
        groups[2].Add(new Member { ID = 11, FullName = "Tran Van K", CompletedTasks = 30 });
        groups[2].Add(new Member { ID = 12, FullName = "Le Thi L", CompletedTasks = 12 });
        groups[2].Add(new Member { ID = 13, FullName = "Hoang Van M", CompletedTasks = 25 });
        groups[2].Add(new Member { ID = 14, FullName = "Pham Thi N", CompletedTasks = 9 });

    
       //2. In danh sach tat ca thanh vien
       Console.WriteLine("\nYeu cau 2: In danh sach tat ca thanh vien");
       Console.WriteLine("\nDanh sach thanh vien:");
       for (int i = 0; i < groups.Length; i++)
       {
            Console.WriteLine($"Nhom {i + 1}");
            foreach (var m in groups[i])
            {
                Console.WriteLine($"ID: {m.ID}, Ten: {m.FullName}, Task: {m.CompletedTasks}");
            }
       }
    
       //3. Tim thanh vien theo ID
       Console.WriteLine("\nYeu cau 3: Tim thanh vien theo ID");
       Console.Write("Nhap ID can tim: ");
       int id = int.Parse(Console.ReadLine());
       bool found = false;
        foreach (var group in groups)
        {
            foreach (var m in group)
            {
                if (m.ID == id)
                {
                    Console.WriteLine($"ID: {m.ID}, Ten: {m.FullName}, Task: {m.CompletedTasks}");
                    found = true;
                }
            }
        }
        if (!found)
        {
            Console.WriteLine("Khong tim thay thanh vien co ID " + id);
        }

        //4. Tim thanh vien hoan thanh nhieu task nhat
        Console.WriteLine("\nYeu cau 4: Tim thanh vien hoan thanh nhieu task nhat");
        Member best = null;
        foreach (var group in groups)
        {
            foreach (var m in group)
            {
                if (best == null || m.CompletedTasks > best.CompletedTasks)
                {
                    best = m;
                }
            }
        }
        Console.WriteLine($"Thanh vien nhieu task nhat: ID {best.ID}, Ten: {best.FullName}, Task: {best.CompletedTasks}");
    }
}