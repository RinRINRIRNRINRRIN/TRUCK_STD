using Microsoft.Reporting.WinForms;
using TRUCK_STD.Functions;

namespace TRUCK_STD.Function
{
    class Func_Report
    {
        public static string rtp_ordernumber { get; set; }
        public static string rtp_HeadCompany { get; set; }
        public static string rtp_HeadAddress { get; set; }
        public static string rtp_HeadPhone { get; set; }
        public static string rtp_company { get; set; }
        public static string rtp_product { get; set; }
        public static string rtp_dateIn { get; set; }
        public static string rtp_dateOut { get; set; }
        public static string rtp_timeIn { get; set; }
        public static string rtp_timeOut { get; set; }
        public static string rtp_carnumber { get; set; }
        public static string rtp_wghIn { get; set; }
        public static string rtp_wghOut { get; set; }
        public static string rtp_gross { get; set; }

        public static string rtp_price { get; set; }
        public static string rtp_priceNet { get; set; }




        public static void Report_have_price(ReportViewer reportViewer1)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "TRUCK_STD.Report.rptHaveMoney.rdlc";

            // สร้าง parameter ใหม่
            ReportParameter rptCarnumber = new ReportParameter("rtp_carnumber", rtp_carnumber);
            ReportParameter rptDateIn = new ReportParameter("rtp_dateIn", rtp_dateIn);
            ReportParameter rptTimeIn = new ReportParameter("rtp_timeIn", rtp_timeIn);
            ReportParameter rptDateOut = new ReportParameter("rtp_dateOut", rtp_dateOut);
            ReportParameter rptTimeOut = new ReportParameter("rtp_timeOut", rtp_timeOut);
            ReportParameter rptWghIn = new ReportParameter("rtp_wghIn", rtp_wghIn);
            ReportParameter rptwghOut = new ReportParameter("rtp_wghOut", rtp_wghOut);
            ReportParameter rptOrdernumber = new ReportParameter("rtp_ordernumber", rtp_ordernumber);
            ReportParameter rptGross = new ReportParameter("rtp_gross", rtp_gross);
            ReportParameter rptProduct = new ReportParameter("rtp_product", rtp_product);
            ReportParameter rptPrice = new ReportParameter("rtp_pricePerKG", rtp_price);
            ReportParameter rptPriceNet = new ReportParameter("rtp_priceNet", rtp_priceNet);
            ReportParameter rptCompany = new ReportParameter("rtp_company", rtp_company);


            // กำหนด ค่าให้กับ parameter ใน report
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptCarnumber });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptDateIn });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptTimeIn });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptDateOut });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptTimeOut });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptWghIn });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptwghOut });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptOrdernumber });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptGross });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptProduct });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptPrice });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptPriceNet });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptCompany });

            DataSet1 dataSet1 = new DataSet1();
            dataSet1.Tables["tbimg"].Rows.Clear();

            // สร้าง QR Code
            byte[] qrCode = Func_GenQrCode.GenerateQRCode($"{rtp_carnumber}|{rtp_dateOut}|{rtp_timeOut}|{rtp_gross}");
            dataSet1.Tables["tbimg"].Rows.Add(qrCode);


            // ดึงค่าจาก registry มาแสดงที่ report
            rtp_HeadCompany = registy.tickets.company;
            rtp_HeadAddress = registy.tickets.address;
            rtp_HeadPhone = registy.tickets.phone;

            ReportParameter rtpcompany = new ReportParameter("rtp_HeadCompany", rtp_HeadCompany);
            ReportParameter rtpaddress = new ReportParameter("rtp_HeadAddress", rtp_HeadAddress);
            ReportParameter rtpphone = new ReportParameter("rtp_HeadPhone", rtp_HeadPhone);

            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rtpcompany });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rtpaddress });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rtpphone });

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dataSet1.Tables["tbimg"]));


            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.PageSetupDialog();
            reportViewer1.RefreshReport();
        }


        public static void Report_no_price(ReportViewer reportViewer1)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "TRUCK_STD.Report.rptNoMoney.rdlc";

            // สร้าง parameter ใหม่
            ReportParameter rptCarnumber = new ReportParameter("rtp_carnumber", rtp_carnumber);
            ReportParameter rptDateIn = new ReportParameter("rtp_DateIn", rtp_dateIn);
            ReportParameter rptTimeIn = new ReportParameter("rtp_TimeIn", rtp_timeIn);
            ReportParameter rptDateOut = new ReportParameter("rtp_DateOut", rtp_dateOut);
            ReportParameter rptTimeOut = new ReportParameter("rtp_TimeOut", rtp_timeOut);
            ReportParameter rptWghIn = new ReportParameter("rtp_wghIn", rtp_wghIn);
            ReportParameter rptwghOut = new ReportParameter("rtp_wghOut", rtp_wghOut);
            ReportParameter rptOrdernumber = new ReportParameter("rtp_ordernumber", rtp_ordernumber);
            ReportParameter rptGross = new ReportParameter("rtp_gross", rtp_gross);
            ReportParameter rptProduct = new ReportParameter("rtp_product", rtp_product);

            // กำหนด ค่าให้กับ parameter ใน report
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptCarnumber });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptDateIn });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptTimeIn });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptDateOut });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptTimeOut });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptWghIn });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptwghOut });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptOrdernumber });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptGross });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptProduct });

            DataSet1 dataSet1 = new DataSet1();
            dataSet1.Tables["tbimg"].Rows.Clear();

            // สร้าง QR Code
            byte[] qrCode = Func_GenQrCode.GenerateQRCode($"{rtp_carnumber}|{rtp_dateOut}|{rtp_timeOut}|{rtp_gross}");
            dataSet1.Tables["tbimg"].Rows.Add(qrCode);

            // ดึงค่าจาก registry มาแสดงที่ report
            rtp_HeadCompany = registy.tickets.company;
            rtp_HeadAddress = registy.tickets.address;
            rtp_HeadPhone = registy.tickets.phone;

            ReportParameter rtpcompany = new ReportParameter("rtp_company", rtp_HeadCompany);
            ReportParameter rtpaddress = new ReportParameter("rtp_address", rtp_HeadAddress);
            ReportParameter rtpphone = new ReportParameter("rtp_phone", rtp_HeadPhone);

            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rtpcompany });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rtpaddress });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rtpphone });

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dataSet1.Tables["tbimg"]));

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.PageSetupDialog();
            reportViewer1.RefreshReport();
        }

        public static void Report_hire_weight(ReportViewer reportViewer1)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "TRUCK_STD.Report.rptHireWeigh.rdlc";

            // สร้าง parameter ใหม่
            ReportParameter rtpOrdernumber = new ReportParameter("rtp_ordernumber", rtp_ordernumber);
            ReportParameter rtpCompany = new ReportParameter("rtp_company", rtp_company);
            ReportParameter rtpDateIn = new ReportParameter("rtp_dateIn", rtp_dateIn);
            ReportParameter rtpProduct = new ReportParameter("rtp_product", rtp_product);
            ReportParameter rtpCarnumber = new ReportParameter("rtp_carnumber", rtp_carnumber);
            ReportParameter rtpTimeIn = new ReportParameter("rtp_timeIn", rtp_timeIn);
            ReportParameter rtpGross = new ReportParameter("rtp_wghIn", rtp_gross);


            // กำหนด ค่าให้กับ parameter ใน report
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rtpCompany });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rtpDateIn });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rtpProduct });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rtpCarnumber });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rtpTimeIn });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rtpGross });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rtpOrdernumber });


            DataSet1 dataSet1 = new DataSet1();
            dataSet1.Tables["tbimg"].Rows.Clear();

            // สร้าง QR Codre
            byte[] qrCode = Func_GenQrCode.GenerateQRCode($"{rtp_carnumber}|{rtp_dateOut}|{rtp_timeOut}|{rtp_gross}");
            dataSet1.Tables["tbimg"].Rows.Add(qrCode);

            // ดึงค่าจาก registry มาแสดงที่ report
            rtp_HeadCompany = registy.tickets.company;
            rtp_HeadAddress = registy.tickets.address;
            rtp_HeadPhone = registy.tickets.phone;

            ReportParameter rtpcompany = new ReportParameter("rtp_HeadCompany", rtp_HeadCompany);
            ReportParameter rtpaddress = new ReportParameter("rtp_HeadAddress", rtp_HeadAddress);
            ReportParameter rtpphone = new ReportParameter("rtp_HeadPhone", rtp_HeadPhone);

            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rtpcompany });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rtpaddress });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rtpphone });
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dataSet1.Tables["tbimg"]));


            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.PageSetupDialog();
            reportViewer1.RefreshReport();
        }
    }
}
