using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using TRUCK_STD.DbBase;
using TRUCK_STD.Functions;

namespace TRUCK_STD.Function
{
    class Func_Report
    {
        //public static string rtp_ordernumber { get; set; }
        //public static string rtp_station { get; set; }
        //public static string rtp_HeadCompany { get; set; }
        //public static string rtp_HeadAddress { get; set; }
        //public static string rtp_HeadPhone { get; set; }
        //public static string rtp_customer { get; set; }
        //public static string rtp_product { get; set; }
        //public static string rtp_dateIn { get; set; }
        //public static string rtp_dateOut { get; set; }
        //public static string rtp_timeIn { get; set; }
        //public static string rtp_timeOut { get; set; }
        //public static string rtp_carnumber { get; set; }
        //public static string rtp_wghIn { get; set; }
        //public static string rtp_wghOut { get; set; }
        //public static string rtp_wghNet { get; set; }
        //public static string rtp_gross { get; set; }
        //public static string rtp_price { get; set; }
        //public static string rtp_priceNet { get; set; }

        //// Prop Image LPR
        //public static string pictureIn { get; set; }
        //public static string pictureOut { get; set; }
        //public static string piclicenseIn { get; set; }
        //public static string piclicenseOut { get; set; }


        static List<string> licensePicture = new List<string>();
        static List<string> pictureFront = new List<string>();
        static List<string> pictureBack = new List<string>();
        static List<string> dates = new List<string>();
        static List<string> Times = new List<string>();
        static List<string> weigth = new List<string>();
        static string jobOrder = "";
        static string licenseHead = "";
        static string licenseTail = "";
        static string customerName = "";
        static string productName = "";
        static double productPrice = 0;
        static double netWeight = 0;
        static double huminityPercent = 0;
        static double impurityPercent = 0;
        static double powderPercent = 0;
        static double priceNet = 0;
        static string priceOther = "";
        static double totalHuminity = 0;
        static double weightProcess = 0;
        static double weightHuminity = 0;
        static double priceProcess = 0;
        static string carNumber = "";
        static byte[] qrCode = null;


        static double huminityBase = 0;
        static double huminityNet = 0;
        static double impurityNet = 0;

        public static void ReportLPR(ReportViewer reportViewer1)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "TRUCK_STD.Report.rptLPR.rdlc";
            //DefineParameter("LPR", reportViewer1);
        }

        static void DefineParameterOnReport(string table, DataSet dataSet, ReportViewer reportViewer)
        {
            ReportParameter rptCarnumber = new ReportParameter("rtpHeadCompany", registy.tickets.company);
            ReportParameter rptDateIn = new ReportParameter("rtpHeadPhone", registy.tickets.address);
            ReportParameter rptTimeIn = new ReportParameter("rtpHeadAddress", registy.tickets.phone);
            ReportParameter rptDateOut = new ReportParameter("rtpDateIn", dates[0]);
            ReportParameter rptTimeOut = new ReportParameter("rtpDateOut", dates[1]);
            ReportParameter rptWghIn = new ReportParameter("rtpTimeIn", Times[0]);
            ReportParameter rptwghOut = new ReportParameter("rtpTimeOut", Times[1]);
            ReportParameter rptOrdernumber = new ReportParameter("rtpWeightIn", weigth[0]);
            ReportParameter rptGross = new ReportParameter("rtpWeightOut", weigth[1]);

            reportViewer.LocalReport.SetParameters(new ReportParameter[] {
                    rptCarnumber,rptDateIn,rptTimeIn,rptDateOut,rptTimeOut,
                    rptWghIn, rptwghOut, rptOrdernumber, rptGross});

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dataSet.Tables[table]));

            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.PageSetupDialog();
            reportViewer.RefreshReport();
        }

        static void GetDataFormDatabase()
        {
            foreach (DataRow rw in job.tb.Rows)
            {
                // Main data
                jobOrder = rw["jobOrder"].ToString();
                licenseHead = rw["licenseHead"].ToString();
                licenseTail = rw["licenseTail"].ToString();
                customerName = rw["customerName"].ToString();
                productName = rw["productName"].ToString();
                productPrice = double.Parse(rw["productPrice"].ToString());
                netWeight = double.Parse(rw["netWeight"].ToString());
                powderPercent = double.Parse(rw["powderPercent"].ToString());
                huminityPercent = double.Parse(rw["huminityPercent"].ToString());
                impurityPercent = double.Parse(rw["impurityPercent"].ToString());
                priceNet = double.Parse(rw["priceNet"].ToString());
                priceOther = rw["priceOther"].ToString();

                // Sub data
                DateTime dateTime = DateTime.Parse(rw["dateTimes"].ToString());
                dates.Add(dateTime.ToString("dd-MM-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("TH-th")));
                Times.Add(dateTime.ToString("HH:mm:ss", System.Globalization.CultureInfo.CreateSpecificCulture("TH-th")));
                weigth.Add(rw["weight"].ToString());
            }
        }

        public static void ReportManual(ReportViewer reportViewer, int id)
        {
            reportViewer.LocalReport.ReportEmbeddedResource = "TRUCK_STD.Report.rptNoMoney.rdlc";

            DataSet1 dataSet1 = new DataSet1();

            if (job.SelectId(id))
            {
                GetDataFormDatabase();
                carNumber = $"{licenseHead}/{licenseTail}";
                qrCode = Func_GenQrCode.GenerateQRCode($"{licenseHead}|{licenseHead}|{licenseHead}|{licenseHead}");

                //dataSet1.Tables["tbimg"].Rows.Add(jobOrder, carNumber, powderPercent, productName, customerName, netWeight, qrCode);
                dataSet1.Tables["tbWeight"].Rows.Add(jobOrder, carNumber, productName, customerName, netWeight, qrCode, huminityPercent, impurityPercent, powderPercent);

                DefineParameterOnReport("tbWeight", dataSet1, reportViewer);

            }
        }

        public static void ReportCassava(ReportViewer reportViewer1, int id)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "TRUCK_STD.Report.rptCassava.rdlc";

            DataSet1 dataSet1 = new DataSet1();

            if (job.SelectId(id))
            {
                GetDataFormDatabase();
                carNumber = $"{licenseHead}/{licenseTail}";
                qrCode = Func_GenQrCode.GenerateQRCode($"{licenseHead}|{licenseHead}|{licenseHead}|{licenseHead}");

                dataSet1.Tables["tbWeight"].Rows.Add(jobOrder, carNumber, powderPercent, productName, customerName, netWeight, qrCode);

                DefineParameterOnReport("tbWeight", dataSet1, reportViewer1);
            }
        }

        public static void ReportPaddy(ReportViewer reportViewer1, int id)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "TRUCK_STD.Report.rptPaddy.rdlc";
            DataSet1 dataSet1 = new DataSet1();

            if (job.SelectId(id))
            {
                GetDataFormDatabase();
                qrCode = Func_GenQrCode.GenerateQRCode($"{licenseHead}|{licenseHead}|{licenseHead}|{licenseHead}");
                dataSet1.Tables["tbWeight"].Rows.Add(jobOrder, carNumber, productName, customerName, netWeight, qrCode, huminityPercent, impurityPercent);
                DefineParameterOnReport("tbWeight", dataSet1, reportViewer1);
            }
        }

        public static void ReportCorn(ReportViewer reportViewer1, int id)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "TRUCK_STD.Report.rptCorn.rdlc";
            DataSet1 dataSet1 = new DataSet1();

            if (job.SelectId(id))
            {
                carNumber = $"{licenseHead}/{licenseTail}";
                qrCode = Func_GenQrCode.GenerateQRCode($"{licenseHead}|{licenseHead}|{licenseHead}|{licenseHead}");
                dataSet1.Tables["tbWeight"].Rows.Add(jobOrder, carNumber, productName, customerName, netWeight, qrCode, huminityPercent);
                DefineParameterOnReport("tbWeight", dataSet1, reportViewer1);
            }
        }
    }
}
