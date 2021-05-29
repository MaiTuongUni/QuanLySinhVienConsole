using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Model
{
    class SinhVien
    {
        private string maSinhVien;

        private string tenSinhVien;

        private float diemTrungBinh;

        private float diemRenLuyen;

        private float diemCong;

        public SinhVien()
        {
            maSinhVien = "null";
            tenSinhVien = "null";
            diemTrungBinh = -1;
            diemRenLuyen = -1;
            diemCong = -1;
        }

        public SinhVien(string maSinhVien, string tenSinhVien, float diemTrungBinh, float diemRenLuyen, float diemCong)
        {
            this.maSinhVien = maSinhVien;
            this.tenSinhVien = tenSinhVien;
            this.diemTrungBinh = diemTrungBinh;
            this.diemRenLuyen = diemRenLuyen;
            this.diemCong = diemCong;
        }

        public string  getMaSinhVien() { return maSinhVien; }

        public void setMaSinhVien(string maSinhVien) { this.maSinhVien = maSinhVien; }

        public string getTenSinhVien() { return tenSinhVien; }

        public void setTenSinhVien(string tenSinhVien) { this.tenSinhVien = tenSinhVien; }

        public float getDiemTrungBinh() { return diemTrungBinh; }

        public void setDiemTrungBinh(float diemTrungBinh) { this.diemTrungBinh = diemTrungBinh; }

        public float getDiemRenLuyen() { return diemRenLuyen; }

        public void setDiemRenLuyen(float diemRenLuyen) { this.diemRenLuyen = diemRenLuyen; }

        public float getDiemCong() { return diemCong; }

        public void setDiemCong(float diemCong) { this.diemCong = diemCong; }
    }
}
