using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.Repository;
using QuanLySinhVien.Model;

namespace QuanLySinhVien.Service
{
    class SinhVienService
    {
        private SinhVienRepository sinhVienRepository;
        private List<SinhVien> sinhViens;

        public SinhVienService()
        {
            sinhVienRepository = new SinhVienRepository();
            sinhViens = new List<SinhVien>();
        }
        public void hienThiDanhSachSinhVien()
        {
            Console.WriteLine("Số lượng sinh viên hiện tại: " + sinhViens.Count);
            if (sinhViens.Count == 0)
            {
                Console.WriteLine("Danh sách trống");
            }
            else
            {
                int i = 0;
                foreach(SinhVien sinhVien in sinhViens)
                {
                    inThongTinMotSinhVien(sinhVien,i);
                    i++;
                }
            }
        }

        public bool readData()
        {
            try
            {
                string[] duLieu = sinhVienRepository.readData();
                if (duLieu.Length != 0)
                {
                    string[] tachDong;

                    foreach (string dong in duLieu)
                    {
                        if(!dong.Equals(""))
                        {
                            tachDong = dong.Split(',');
                            SinhVien sinhVien = new SinhVien();
                            sinhVien.setMaSinhVien(tachDong[0].Trim());
                            sinhVien.setTenSinhVien(tachDong[1].Trim());
                            sinhVien.setDiemTrungBinh(float.Parse(tachDong[2].Trim()));
                            sinhVien.setDiemRenLuyen(float.Parse(tachDong[3].Trim()));
                            sinhVien.setDiemCong(float.Parse(tachDong[4].Trim()));
                            sinhViens.Add(sinhVien);
                        }  
                    }

                    if(sinhViens.Count>1)
                        selectionSort();
                }
                return true;
            }
            catch
            {
                Console.WriteLine("Không tồn tại hoặc định dạng dữ liệu không đúng");
                return false;
            }
        }

        public bool themMoiSinhVien()
        {

            SinhVien sinhVien = nhapSinhVien();
            themVaoList(sinhVien);
            ghiFile();

            return true;
        }

        public void timKiemSinhVienTheoDtb()
        {
            Console.Write("Nhập điểm trung bình: ");
            string diemtb = Console.ReadLine().Trim();
            if (kiemTraHopLeDiem(diemtb))
            {
                if (float.Parse(diemtb) <= 10)
                {
                    int stt = 0;
                    foreach(SinhVien sinhVien in sinhViens)
                    {
                        if (sinhVien.getDiemTrungBinh().ToString().Equals(diemtb)){
                            inThongTinMotSinhVien(sinhVien,stt);
                            stt++;
                        }
                    }
                    Console.WriteLine("Tìm thấy " + stt + " kết quả");
                }
            }
            else
            {
                Console.WriteLine("Dữ liệu tìm kiếm không phù hợp");
            }
        }

        public void capNhatThongTinSinhVien()
        {
            Console.Write("Nhập mã sinh viên cần cập nhật: ");
            string mSV = Console.ReadLine();
            bool isTimThay = false;
            foreach(SinhVien sinhVien in sinhViens)
            {
                if (sinhVien.getMaSinhVien().Equals(mSV.Trim()))
                {
                    isTimThay = true;

                    inThongTinMotSinhVien(sinhVien, 0);

                    Console.Write("Tên cập nhật: ");
                    string ten = Console.ReadLine();
                    if (!ten.Equals(""))
                    {
                        sinhVien.setTenSinhVien(ten);
                    }

                    Console.Write("Điểm trung bình cập nhật: ");
                    string diemtb = Console.ReadLine();
                    if (kiemTraHopLeDiem(diemtb))
                    {
                        if (float.Parse(diemtb) <= 10)
                        {
                            sinhVien.setDiemTrungBinh(float.Parse(diemtb));
                        }
                    }

                    Console.Write("Điểm rèn luyện cập nhật: ");
                    string diemrl = Console.ReadLine();
                    if (kiemTraHopLeDiem(diemrl))
                    {
                        if (float.Parse(diemrl) <= 100)
                        {
                            sinhVien.setDiemRenLuyen(float.Parse(diemrl));
                        }
                    }

                    Console.Write("Điểm cộng cập nhật: ");
                    string diemCong = Console.ReadLine();
                    if (kiemTraHopLeDiem(diemCong))
                    {
                        if (float.Parse(diemrl) <= 10)
                        {
                            sinhVien.setDiemCong(float.Parse(diemCong));
                        }
                    }
                }
            }

            if(isTimThay == false)
            {
                Console.WriteLine("Không tìm thấy kết quả phù hợp");
            }
            else
            {
                ghiFile();
                Console.WriteLine("Cập nhật thành công");
            }
        }

        public void xoaThongTinSinhVien()
        {
            Console.Write("Nhập mã sinh viên cần xóa: ");
            string mSV = Console.ReadLine();
            bool isTimThay = false;
            foreach (SinhVien sinhVien in sinhViens)
            {
                if (sinhVien.getMaSinhVien().Equals(mSV.Trim()))
                {
                    isTimThay = true;

                    inThongTinMotSinhVien(sinhVien, 0);
                   
                    Console.Write("Nhấn 1 để xóa sinh viên "+sinhVien.getMaSinhVien()+" : ");
                    string xacNhan = Console.ReadLine();
                    if (xacNhan.Equals("1"))
                    {
                        sinhViens.Remove(sinhVien);
                        ghiFile();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Bỏ qua");
                    }

                }
            }

            if (isTimThay == false)
            {
                Console.WriteLine("Không tìm thấy kết quả phù hợp");
            }
        }

        private void inThongTinMotSinhVien(SinhVien sinhVien, int stt)
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("Số thứ tự:           " + stt);
            Console.WriteLine("Mã sinh viên:        " + sinhVien.getMaSinhVien());
            Console.WriteLine("Họ và tên:           " + sinhVien.getTenSinhVien());
            Console.WriteLine("Điểm trung bình:     " + sinhVien.getDiemTrungBinh().ToString());
            Console.WriteLine("Điểm rèn luyện:      " + sinhVien.getDiemRenLuyen().ToString());
            Console.WriteLine("Điểm cộng:           " + sinhVien.getDiemCong().ToString());
            Console.WriteLine("--------------------------------------------------------------");
        }

        private void selectionSort()
        {
            int giaTriNhoNhatIndex = 0;
            for (int i = sinhViens.Count - 1; i > 0 ; i--)
            {
                giaTriNhoNhatIndex = i;
                for (int j = i - 1; j>=0 ; j--)
                {
                    if (sinhViens[j].getDiemTrungBinh() < sinhViens[giaTriNhoNhatIndex].getDiemTrungBinh())
                    {
                        giaTriNhoNhatIndex = j;
                    }
                }

                if (giaTriNhoNhatIndex != i)
                {
                    SinhVien sinhVien = sinhViens[i];
                    sinhViens[i] = sinhViens[giaTriNhoNhatIndex];
                    sinhViens[giaTriNhoNhatIndex] = sinhVien;
                }
            }
        }

        private bool kiemTraHopLeMaSinhVien( string maSinhVien)
        {
            foreach(SinhVien sinhVien in sinhViens)
            {
                if (sinhVien.getMaSinhVien() == maSinhVien.Trim())
                    return false;
            }
            return true;
        }

        private bool kiemTraHopLeDiem(string diem)
        {
            try
            {
                if(float.Parse(diem)> 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        private void themVaoList(SinhVien sinhVien)
        {
            sinhViens.Add(sinhVien);
            
            for(int i = sinhViens.Count - 1; i > 0; i--)
            {
                if(sinhViens[sinhViens.Count - 1].getDiemTrungBinh() < sinhViens[i].getDiemTrungBinh())
                {
                    SinhVien sinhVienTemPo = sinhViens[i + 1];
                    sinhViens[i + 1] = sinhViens[sinhViens.Count -1];
                    sinhViens[sinhViens.Count - 1] = sinhVienTemPo;
                    break;
                }
            }
        }

        private SinhVien nhapSinhVien()
        {
            bool isThem = false;
            SinhVien sinhVien = new SinhVien();
            do
            {
                Console.Write("Nhập mã sinh viên: ");
                sinhVien.setMaSinhVien(Console.ReadLine());
                if (kiemTraHopLeMaSinhVien(sinhVien.getMaSinhVien()))
                {
                    isThem = true;
                }
                else
                {
                    Console.WriteLine("Sinh viên đã tồn tại");
                }
            } while (!isThem);

            Console.Write("Nhập họ và tên: ");
            sinhVien.setTenSinhVien(Console.ReadLine().Trim());

            do
            {
                isThem = false;
                Console.Write("Nhập điểm trung bình: ");
                string diemtb = Console.ReadLine().Trim();
                if (kiemTraHopLeDiem(diemtb))
                {
                    if (float.Parse(diemtb) <= 10)
                    {
                        sinhVien.setDiemTrungBinh(float.Parse(diemtb));
                        isThem = true;
                    }
                }
            } while (!isThem);

            do
            {
                isThem = false;
                Console.Write("Nhập điểm rèn luyện: ");
                string diemrl = Console.ReadLine().Trim();
                if (kiemTraHopLeDiem(diemrl))
                {
                    if (float.Parse(diemrl) <= 100)
                    {
                        sinhVien.setDiemRenLuyen(float.Parse(diemrl));
                        isThem = true;
                    }
                }
            } while (!isThem);

            do
            {
                isThem = false;
                Console.Write("Nhập điểm cộng: ");
                string diemCong = Console.ReadLine().Trim();
                if (kiemTraHopLeDiem(diemCong))
                {
                    if (float.Parse(diemCong) < 10)
                    {
                        sinhVien.setDiemCong(float.Parse(diemCong));
                        isThem = true;
                    }
                }
            } while (!isThem);
            return sinhVien;
        }

        private bool ghiFile()
        {
            try
            {
                string[] duLieu = new string[1000];
                for (int i = 0; i < sinhViens.Count; i++)
                {
                    duLieu[i] = sinhViens[i].getMaSinhVien() + "," +
                                sinhViens[i].getTenSinhVien() + "," +
                                sinhViens[i].getDiemTrungBinh() + "," +
                                sinhViens[i].getDiemRenLuyen() + "," +
                                sinhViens[i].getDiemCong();
                }

                sinhVienRepository.writeData(duLieu);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
