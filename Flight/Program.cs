using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;

namespace Flight
{
    class Program
    {

        private static string path = GetPath();
        private static int stt = 1;

        private static LinkedList<ChuyenBay> listFlight = LoadListFlight();

        private static LinkedList<MayBay> listPlane = LoadListPlane();

        private static LinkedList<Account> listAccount = LoadListAccount();

        private static LinkedList<KhachHang> listCustomer = LoadListCustomer();

        private static LinkedList<Ve> listTicket = LoadListTicket();

        private static LinkedList<Ve> listTMP = new LinkedList<Ve>();
        public static string GetPath()
        {
            String s = Environment.CurrentDirectory;
            //int k = s.LastIndexOf("\\");
            //s = s.Substring(0, k);
            return s + "\\";
        }
        public static LinkedList<ChuyenBay> LoadListFlight()
        {

            string filename = "ChuyenBay.txt";
            LinkedList<ChuyenBay> list = new LinkedList<ChuyenBay>();
            try
            {
                using (StreamReader sR = new StreamReader(path + filename))
                {
                    while (sR.Peek() != -1)
                    {
                        string[] line = sR.ReadLine().Split("#");
                        LinkedList<int> listSeats = new LinkedList<int>();
                        LinkedList<Ve> listTicket = new LinkedList<Ve>();
                        KhachHang customer = new KhachHang(line[6], line[7]);
                        Ve vv = new Ve(line[5], line[0], customer, Int32.Parse(line[8]));
                        listTicket.AddLast(vv);
                        listSeats.AddLast(Int32.Parse(line[9]));
                        ChuyenBay chuyenBay = new ChuyenBay(line[0], line[1], DateTime.ParseExact(line[2], "dd/MM/yyyy", CultureInfo.InvariantCulture), line[3],
                            Int32.Parse(line[4]), listTicket, listSeats);
                        list.AddLast(chuyenBay);
                    }
                    sR.Close();
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Khong doc duoc file!!!");
                throw;
            }
            return list;
        }

        public static LinkedList<MayBay> LoadListPlane()
        {

            string filename = "MayBay.txt";
            LinkedList<MayBay> list = new LinkedList<MayBay>();
            try
            {
                using (StreamReader sR = new StreamReader(path + filename))
                {
                    while (sR.Peek() != -1)
                    {
                        string[] line = sR.ReadLine().Split("#");
                        MayBay m = new MayBay(line[0], Int32.Parse(line[1]));
                        list.AddLast(m);
                    }
                    sR.Close();
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Khong doc duoc file!!!");
                throw;
            }
            return list;
        }

        public static LinkedList<Account> LoadListAccount()
        {

            string filename = "Admin.txt";
            LinkedList<Account> list = new LinkedList<Account>();
            try
            {
                using (StreamReader sR = new StreamReader(path + filename))
                {
                    while (sR.Peek() != -1)
                    {
                        string[] line = sR.ReadLine().Split("#");
                        Account acc = new Account(line[0], line[1]);
                        list.AddLast(acc);
                    }
                    sR.Close();
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Khong doc duoc file!!!");
                throw;
            }
            return list;
        }

        public static LinkedList<KhachHang> LoadListCustomer()
        {

            string filename = "KhachHang.txt";
            LinkedList<KhachHang> list = new LinkedList<KhachHang>();
            try
            {
                using (StreamReader sR = new StreamReader(path + filename))
                {
                    while (sR.Peek() != -1)
                    {
                        string[] line = sR.ReadLine().Split("#");
                        KhachHang customer = new KhachHang(line[0], line[1], line[2]);
                        list.AddLast(customer);
                    }
                    sR.Close();
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Khong doc duoc file!!!");
                throw;
            }
            return list;
        }
        public static LinkedList<Ve> LoadListTicket()
        {

            string filename = "Ve.txt";
            LinkedList<Ve> list = new LinkedList<Ve>();
            try
            {
                using (StreamReader sR = new StreamReader(path + filename))
                {
                    while (sR.Peek() != -1)
                    {
                        string[] line = sR.ReadLine().Split("#");
                        KhachHang customer = new KhachHang(line[2], line[3]);
                        Ve v = new Ve(line[0], line[1], customer, Int32.Parse(line[4]));
                        list.AddLast(v);
                    }
                    sR.Close();
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Khong doc duoc file!!!");
                throw;
            }
            return list;
        }



        static void Main(string[] args)
        {

            Menu();

        }
        public static string State(int s)
        {
            if (s == 0)
            {
                return "Huy Chuyen";
            }
            else if (s == 1)
            {
                return "Con ve";
            }
            else if (s == 2)
            {
                return "Het ve";
            }
            else
            {
                return "Hoan tat";
            }
        }
        static void Menu()
        {
            int chon1 = 0, chon2 = 0, chon3 = 0;
            do
            {
                Console.Clear();
                MenuChinh();
                Console.Write("Chon chuc nang: ");
                chon1 = int.Parse(Console.ReadLine());

                switch (chon1)
                {
                    case 1:
                        do
                        {
                            Console.Clear();
                            XuatThongTinChuyenBay(listFlight);
                            Console.WriteLine();
                            Console.Write("Bam phim bat ky de tiep tuc: ");
                            Console.ReadKey();
                        } while (chon2 >= 1 && chon2 <= 2);
                        break;

                    case 2:
                        do
                        {
                            Console.Clear();

                            DatVe();

                            Console.ReadKey();
                        } while (chon2 >= 1 && chon2 <= 2);
                        break;

                    case 3:
                        do
                        {
                            Console.Clear();

                            DangNhap();

                            Console.Clear();
                            MenuQuanLy();
                            Console.Write("Chon chuc nang: ");
                            chon1 = int.Parse(Console.ReadLine());

                            Console.Clear();

                            switch (chon1)
                            {
                                case 1:
                                    Console.WriteLine("Hien thi chuc nang quan ly ve");
                                    break;

                                case 2:
                                    Console.WriteLine("Hien thi chuc nang xu ly ve");
                                    break;

                                case 3:
                                    Console.WriteLine("Hien thi chuc nang thong ke");
                                    break;

                                default:
                                    break;
                            }

                            Console.ReadKey();
                        } while (chon1 >= 1 && chon1 <= 3);
                        break;

                    default:
                        break;
                }
            } while (chon1 >= 1 && chon1 <= 3);
        }
        public static void XuatThongTinChuyenBay(LinkedList<ChuyenBay> L)
        {
            Console.WriteLine("\n\n\n\n\t\t\t********************THONG TIN CHUYEN BAY*****************\n\n");
            Console.WriteLine(String.Format("|{0,15}|{1,15}|{2,15}|{3,15}|{4,30}|", "Ma Chuyen Bay", "Ngay Khoi Hanh", "San Bay",
                "Trang Thai", "Danh Sach Ve"));
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            for (LinkedListNode<ChuyenBay> p = L.First; p != null; p = p.Next)
            {
                string tmp = "";
                string listSeats = "";
                foreach (Ve kh in p.Value.danhSachVe)
                {
                    tmp += kh.mave;
                    if (kh.mave.CompareTo("") != 0)
                        tmp += ", ";
                }
                foreach (int i in p.Value.danhSachGheTrong)
                {
                    listSeats += i.ToString();
                    if (i.ToString().CompareTo("") != 0)
                        listSeats += ", ";
                }
                Console.WriteLine(String.Format("|{0,15}|{1,15}|{2,15}|{3,15}|{4,30}|", p.Value.maChuyenBay, p.Value.ngayKhoiHanh.ToString("dd/MM/yyyy"),
                    p.Value.sanBayDen, State(p.Value.trangThai), tmp));
                //Console.WriteLine();
            }
        }

        public static void DatVe()
        {

            XuatThongTinChuyenBay(listFlight);

            string maVe = "";
            string maChuyenBay = "";
            string CMND = "";
            string name = "";
            int soGhe = -1;
            do
            {

                Console.Write("Chon ma chuyen bay muon dat: ");
                maChuyenBay = Console.ReadLine();
                int isExit = 0;
                foreach (ChuyenBay c in listFlight)
                {
                    if (c.maChuyenBay.CompareTo(maChuyenBay) == 0)
                    {
                        isExit = 1;
                        if (c.danhSachGheTrong.Count <= 0)
                        {
                            isExit = 2;
                        }
                        if (c.trangThai != 3)
                        {
                            isExit = 3;
                        }
                        break;
                    }
                }
                if (isExit == 1)
                {
                    do
                    {
                        Console.Write("Nhap CMND: ");
                        CMND = Console.ReadLine();
                    } while (CMND.Trim().CompareTo("") == 0);
                    do
                    {
                        Console.Write("Nhap ten khach hang: ");
                        name = Console.ReadLine();
                    } while (name.Trim().CompareTo("") == 0);

                    foreach (ChuyenBay c in listFlight)
                    {
                        if (c.maChuyenBay.CompareTo(maChuyenBay) == 0)
                        {
                            LinkedList<int> list = c.danhSachGheTrong;
                            foreach (int i in list)
                            {
                                Console.Write("Danh sach ghe trong: " + i + " ");
                            }
                            do
                            {

                                Console.Write("\nNhap so ghe muon dat: ");
                                soGhe = Convert.ToInt32(Console.ReadLine());
                            } while (list.Find(soGhe) == null);
                            maVe = maChuyenBay + soGhe.ToString();
                            Ve v = new Ve(maVe, maChuyenBay, new KhachHang(CMND, name), soGhe);
                            listFlight.Find(c).Value.danhSachGheTrong.Remove(soGhe);
                            listTMP.AddLast(v);
                            XuatThongTinVe(v);
                        }
                    }



                }
                else if (isExit == 2)
                {
                    Console.WriteLine("Het ghe trong!");
                }
                else if (isExit == 3)
                {
                    Console.WriteLine("Trang thai chuyen bay khong hop le");
                }
                else
                {
                    Console.WriteLine("Ma chuyen bay khong hop le vui long nhap lai!");
                }

            } while (maChuyenBay.Trim().CompareTo("") == 0);

        }

        static void MenuQuanLy()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t**********************************");

            Console.Write("\t*");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\t1. Xu ly dat ve          ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("*\t\t");
            Console.WriteLine();


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\t*");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\t2. Xu ly tra ve          ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("*\t\t");
            Console.WriteLine();


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\t*");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\t3. Thong ke              ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("*\t\t");
            Console.WriteLine();


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\t*");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\t4. EXIT                  ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("*\t\t");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();

            Console.WriteLine("\t**********************************");


            Console.ForegroundColor = ConsoleColor.White;
        }

        static void DangNhap()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t*********************************");

            Console.Write("\t*");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\tDANG NHAP HE THONG");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\t*");
            Console.WriteLine();

            Console.WriteLine("\t*********************************");
            Console.ForegroundColor = ConsoleColor.White;

            Account qtc = new Account();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("\tUser:\t");

            Console.ForegroundColor = ConsoleColor.White;
            qtc.userName = Console.ReadLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("\tPassword: ");

            Console.ForegroundColor = ConsoleColor.White;
            qtc.Password = Console.ReadLine();

        }

        static void MenuChinh()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t*************************************************");

            Console.Write("\t*");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\t1. Hien thi danh sach cac chuyen bay\t");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("*\t\t\t");
            Console.WriteLine();


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\t*");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\t2. Dat ve                           \t");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("*\t\t\t");
            Console.WriteLine();


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\t*");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\t3. Quan ly                          \t");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("*\t\t\t");
            Console.WriteLine();


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\t*");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\t4. EXIT                          \t");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("*\t\t\t");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();

            Console.WriteLine("\t*************************************************");

            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void XuatThongTinVe(Ve v)
        {
            string fileName = "VeTamThoi.txt";
            //using (StreamWriter rW = new StreamWriter(
            try
            {
                using(StreamWriter sW = new StreamWriter(path + fileName))
                {
                    sW.Write(v.mave + "#" + v.maChuyenBay + "#" + v.thongTinKhachHang.CMND + "#" +
                        v.thongTinKhachHang.hoVaTen + "#" + v.sttGhe);
                    sW.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
