using System;
using System.Text;
using QuanLySinhVien.Controller;

namespace QuanLySinhVien
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            SinhVienController sinhVienController = new SinhVienController();
            sinhVienController.batDau();
            sinhVienController.docDuLieu();
            sinhVienController.inChucNang();

        }
    }
}
