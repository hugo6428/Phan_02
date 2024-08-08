using System;

class Program
{
    static void Main()
    {
        // Số lượng vật phẩm
        int n = 3;

        // Trọng lượng tối đa của balo
        int maxWeight = 60;

        // Mảng lưu trọng lượng và giá trị của các vật phẩm
        int[] weights = { 30, 25, 20 };
        int[] values = { 40, 30, 25 };

        // Mảng lưu trạng thái đã chọn của các vật phẩm
        bool[] selectedItems = new bool[n];

        // Tổng giá trị và tổng trọng lượng
        int totalValue = 0;
        int totalWeight = 0;

        // Áp dụng thuật toán tham lam
        for (int i = 0; i < n; i++)
        {
            if (totalWeight + weights[i] <= maxWeight)
            {
                selectedItems[i] = true;
                totalValue += values[i];
                totalWeight += weights[i];
            }
        }

        // Xuất thông tin vật phẩm được chọn
        Console.WriteLine("Các vat pham đuoc chon:");
        for (int i = 0; i < n; i++)
        {
            if (selectedItems[i])
            {
                Console.WriteLine($"Vat pham {i + 1}: Trong luong {weights[i]}, Gia tri {values[i]}");
            }
        }

        Console.WriteLine($"Tong gia tri: {totalValue}");
        Console.WriteLine($"Tong trong luong: {totalWeight}");
    }
}
