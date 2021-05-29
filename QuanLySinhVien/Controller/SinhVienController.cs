using System;
using System.Collections.Generic;
using QuanLySinhVien.Model;
using QuanLySinhVien.Service;

namespace QuanLySinhVien.Controller
{
    class SinhVienController
    {
        SinhVienService sinhVienService;
        public SinhVienController()
        {
            sinhVienService = new SinhVienService();
        }
        public void batDau()
        {
            Console.WriteLine("                                      CHƯƠNG TRÌNH QUẢN LÝ THÔNG TIN SINH VIÊN");
        }

        public bool docDuLieu()
        {
            return sinhVienService.readData();
        }

        public void inChucNang()
        {
            Console.WriteLine("Danh sách chức năng chương trình: ");
            Console.WriteLine("1.Hiển thị danh sách sinh viên");
            Console.WriteLine("2.Thêm mới sinh viên");
            Console.WriteLine("3.Sửa thông tin sinh viên");
            Console.WriteLine("4.Xóa thông tin sinh viên");
            Console.WriteLine("5.Tìm kiếm sinh viên theo điểm trung bình");
            Console.WriteLine("6.Thoát chương trình");
            xuLiChucNangChinh(chonChucNang());
        }
        private string chonChucNang()
        {
            bool phuHop;
            string soNhap;

            do
            {
                Console.Write("Chọn chức năng: ");

                soNhap = Console.ReadLine();
                phuHop = kiemTraSoNhap(soNhap, 6);
            } while (!phuHop);
            Console.Clear();
            batDau();
            return soNhap;
        }

        private void xuLiChucNangChinh(string soNhap)
        {
            switch (soNhap)
            {
                case "1":
                    sinhVienService.hienThiDanhSachSinhVien();
                    Console.WriteLine("Ấn phím bất kỳ để quay lại");
                    Console.ReadKey();
                    Console.Clear();
                    batDau();
                    inChucNang();
                    break;

                case "2":
                    if (sinhVienService.themMoiSinhVien())
                    {
                        Console.WriteLine("Thêm thành công. Ấn phím bất kỳ để quay lại");
                        Console.ReadKey();
                        Console.Clear();
                        batDau();
                        inChucNang();
                    }
                    
                    break;

                case "3":
                    sinhVienService.capNhatThongTinSinhVien();
                    Console.WriteLine("Ấn phím bất kỳ để quay lại");
                    Console.ReadKey();
                    Console.Clear();
                    batDau();
                    inChucNang();
                    break;

                case "4":
                    sinhVienService.xoaThongTinSinhVien();

                    Console.WriteLine("Ấn phím bất kỳ để quay lại");
                    Console.ReadKey();
                    Console.Clear();
                    batDau();
                    inChucNang();
                    break;

                case "5":
                    sinhVienService.timKiemSinhVienTheoDtb();

                    Console.WriteLine("Ấn phím bất kỳ để quay lại");
                    Console.ReadKey();
                    Console.Clear();
                    batDau();
                    inChucNang();
                    break;

                case "6":
                    break;
            }
        }

        private bool kiemTraSoNhap(string soNhap, int max)
        {
            try
            {
                int so = int.Parse(soNhap);
                if (so < 1 || so > max)
                {
                    Console.WriteLine("Dữ liệu nhập vào không phù hợp");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                Console.WriteLine("Dữ liệu nhập vào không phù hợp");
                return false;
            }
        }

    }
}
