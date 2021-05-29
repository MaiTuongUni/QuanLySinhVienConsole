using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuanLySinhVien.Repository
{
    class SinhVienRepository
    {
        private string duongDan = @"\SinhVien.txt";

        public string[] readData()
        {
            string[] dongs = System.IO.File.ReadAllLines(System.IO.Directory.GetCurrentDirectory()+duongDan);
            return dongs;
        }

        public void writeData(string[] duLieuThem)
        {
            System.IO.File.WriteAllLines(System.IO.Directory.GetCurrentDirectory() + duongDan, duLieuThem);
        }
    }
}
