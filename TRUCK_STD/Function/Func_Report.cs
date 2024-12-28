using Guna.UI2.WinForms;
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

        public static string ERR { get; set; }
        public static ReportViewer ReportViewer { get; set; }
        public static string id { get; set; }

        static Guna2MessageDialog msg = new Guna2MessageDialog();
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

        /// <summary>
        /// กำหนดค่า localreport ให้กับ report
        /// </summary>
        /// <param name="localReportName"></param>
        /// <returns></returns>
        static bool SetLocalReport(string localReportName)
        {
            ReportViewer.LocalReport.ReportEmbeddedResource = localReportName;
            // ดึงข้อมูลจาก tbWeightDetail
            if (!jobDetail.selectOrderDetail(id))
            {
                return false;
            }
            // ดึงข้อมูลท่ี่ได้จากการหาฐานข้อมูลมาเก็บที่ตัวแปร
            if (!GetDataFormDatabase())
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// สำหรับดึงข้อมูลจากฐานข้อมูลมาเก็บไว้ที่ ตัวแปล
        /// </summary>
        /// <param name="reportViewer"></param>
        /// <returns></returns>
        static bool GetDataFormDatabase()
        {
            try
            {
                // clear ข้อมูลเก่า
                dates.Clear();
                Times.Clear();
                weigth.Clear();
                // ลูปดึงข้อมูลมาเก็บที่โปรแกรม
                foreach (DataRow rw in jobDetail.tb.Rows)
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

                carNumber = $"{licenseHead}/{licenseTail}";
                // กำหนดค่า qr code
                qrCode = Func_GenQrCode.GenerateQRCode($"{licenseHead}|{licenseHead}|{licenseHead}|{licenseHead}");
                // กำหนดค่า data set
                DataSet1 dataSet1 = new DataSet1();
                dataSet1.Tables["tbWeight"].Rows.Add(jobOrder, carNumber, productName, customerName, netWeight, qrCode, huminityPercent, impurityPercent, powderPercent);
                if (!DefineParameterOnReport("tbWeight", dataSet1))
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ERR = ex.Message;
                return false;
            }

            return true;
        }
        /// <summary>
        /// สำหรับกำหนดค่าให้กับ parameter ของ report
        /// </summary>
        /// <param name="table"></param>
        /// <param name="dataSet"></param>
        /// <param name="reportViewer"></param>
        /// <returns></returns>
        static bool DefineParameterOnReport(string table, DataSet dataSet)
        {
            try
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

                ReportViewer.LocalReport.SetParameters(new ReportParameter[] {
                    rptCarnumber,rptDateIn,rptTimeIn,rptDateOut,rptTimeOut,
                    rptWghIn, rptwghOut, rptOrdernumber, rptGross});

                ReportViewer.LocalReport.DataSources.Clear();
                ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dataSet.Tables[table]));

                ReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                // ReportViewer.PageSetupDialog();
                ReportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                ERR = ex.Message;
                return false;
            }
            return true;
        }



        public static void ReportLPR(ReportViewer reportViewer1)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "TRUCK_STD.Report.rptLPR.rdlc";
            //DefineParameter("LPR", reportViewer1);
        }



        /// <summary>
        /// สำหรับปร้ินข้อมูลตามสถานะการชั่ง Success,Process
        /// </summary>
        /// <returns></returns>
        public static bool ReportAllData(string state)
        {
            try
            {
                ReportViewer.LocalReport.ReportEmbeddedResource = "TRUCK_STD.Report.rptAllreport.rdlc";

                if (jobDetail.selectOrderMakeReport(state))
                {
                    DataSet1 dataSet = new DataSet1();

                    int rows = 1;
                    foreach (DataRow rw in jobDetail.tb.Rows)
                    {
                        string _jobOrder = rw["jobOrder"].ToString();
                        string _licenseHead = rw["licenseHead"].ToString();
                        string _licenseTail = rw["licenseTail"].ToString();
                        string _customerName = rw["customerName"].ToString();
                        string _productName = rw["productName"].ToString();
                        string _dateTime = rw["dateTimes"].ToString();
                        string _weightType = rw["weightType"].ToString();
                        string _weight = rw["weight"].ToString();
                        string _netWeight = rw["netWeight"].ToString();
                        string[] dates = _dateTime.Split(' ');
                        switch (rows)
                        {
                            case 1:
                                dataSet.Tables["tbWeightReport"].Rows.Add(_jobOrder, $"{_licenseHead}", _licenseTail, _customerName, _productName, _netWeight);
                                dataSet.Tables["tbWeightReport"].Rows.Add("", "", "", _weightType, _dateTime, _weight);
                                rows = 2;
                                break;
                            case 2:
                                dataSet.Tables["tbWeightReport"].Rows.Add("", "", "", _weightType, _dateTime, _weight);
                                rows = 1;
                                break;

                        }
                    }

                    ReportViewer.LocalReport.DataSources.Clear();
                    ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dataSet.Tables["tbWeightReport"]));

                    ReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                    //ReportViewer.PageSetupDialog();
                    ReportViewer.RefreshReport();
                }
                else
                {
                    ERR = jobDetail.ERR;
                    return false;
                }
            }
            catch (Exception ex)
            {
                ERR = ex.Message;
                return false;
            }
            return true;

        }

        /// <summary>
        /// รายงานสำหรับประเภทธุระกิจทั่วไป
        /// </summary>
        /// <param name="reportViewer"></param>
        /// <param name="id"></param>
        public static bool ReportManual()
        {
            if (!SetLocalReport("TRUCK_STD.Report.rptNomal.rdlc"))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// รายงานสำหรับประเภทธุระกิจหัวมันสด
        /// </summary>
        /// <param name="reportViewer1"></param>
        /// <param name="id"></param>
        public static bool ReportCassava()
        {
            if (!SetLocalReport("TRUCK_STD.Report.rptCassava.rdlc"))
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// รายงานสำหรับประเภทธุระกิจข้าวเปลือก
        /// </summary>
        /// <param name="reportViewer1"></param>
        /// <param name="id"></param>
        public static bool ReportPaddy()
        {
            if (!SetLocalReport("TRUCK_STD.Report.rptPaddy.rdlc"))
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// รายงานสำหรับประเภทธุระกิจข้าวโพดเลี้ยงสัตว์
        /// </summary>
        /// <param name="reportViewer1"></param>
        /// <param name="id"></param>
        public static bool ReportCorn()
        {
            if (!SetLocalReport("TRUCK_STD.Report.rptCorn.rdlc"))
            {
                return false;
            }
            return true;
        }
    }
}
