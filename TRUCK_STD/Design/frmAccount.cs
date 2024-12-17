using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TRUCK_STD.DbBase;
using TRUCK_STD.Functions;
using TRUCK_STD.Models;
namespace TRUCK_STD.Design
{
    public partial class frmAccount : Form
    {
        public frmAccount()
        {
            InitializeComponent();
        }
        #region variable local

        List<string> menuName = new List<string>(); // array สำหรับเก็บค่า เมนู
        BunifuSnackbar msg = new BunifuSnackbar();
        #endregion

        /// <summary>
        /// สำหรับดึงข้อมูลจากฐานข้อมูลมาเพื่อดูว่า user นั้น ๆ มีสิทธิ์การเข้างานเมนูไหนและทำอะไรได้บ้าง
        /// </summary>
        /// 
        void GET_MENU_AND_PRIVIRATE(string emp_username)
        {
            // หาว่า emp_user คือ id อะไร
            DataTable tbemp = employee.SelectChar(emp_username);
            string user_id = "";
            foreach (DataRow rw in tbemp.Rows)
            {
                user_id = rw["id"].ToString();
            }

            // นำ user_id ไปหาว่าสิทธิ์มีอะพไรบ้าง
            privilageModels privilageModels = new privilageModels
            {
                user_id = user_id
            };

            if (privilage.Select(privilageModels))
            {

                if (privilage.tb.Rows.Count > 0)
                {
                    // ทำการจำแนก สิทธิ์การใช้งาน เมนูนั้น ๆ 
                    foreach (DataRow rw in privilage.tb.Rows)
                    {
                        string pr_menu = rw["menus"].ToString();
                        string pr_add = rw["pr_add"].ToString();
                        string pr_del = rw["pr_del"].ToString();
                        string pr_edit = rw["pr_edit"].ToString();

                        // ลูปหาชื่อเมนูในโปรแกรม 
                        foreach (Guna.UI2.WinForms.Guna2CustomCheckBox cbb in panel1.Controls.OfType<Guna.UI2.WinForms.Guna2CustomCheckBox>())
                        {
                            // สั่งเปิด cbb ให้หมด
                            cbb.Enabled = true;
                            if (pr_menu == cbb.Text)
                            {
                                // หากลูปหาเชื่อเมนูที่ตรงกันให้ ทำการ checked = true                        
                                cbb.Checked = true;
                                //  ลูปหาสิทธิ์ว่า เพิ่ม ลบ แก้ไข ได้หรือไม่
                                foreach (Panel pn in panel1.Controls.OfType<Panel>())
                                {
                                    // ตรวจสอบว่า cbb กับ pn ใช้ตัวเดียวกันหรือให่ โดยเช็คจาก tag
                                    if (pr_menu == pn.Tag.ToString())
                                    {
                                        pn.Enabled = true;
                                        // ลูปหา togleswitch
                                        foreach (Guna.UI2.WinForms.Guna2ToggleSwitch tgs in pn.Controls.OfType<Guna.UI2.WinForms.Guna2ToggleSwitch>())
                                        {
                                            // เช็คว่า tgs คือ add , del,edit
                                            if (tgs.Tag.ToString() == "add")
                                            {
                                                if (pr_add == "TRUE")
                                                {
                                                    tgs.Checked = true;
                                                }
                                                else
                                                {
                                                    tgs.Checked = false;
                                                }
                                            }
                                            if (tgs.Tag.ToString() == "del")
                                            {
                                                if (pr_del == "TRUE")
                                                {
                                                    tgs.Checked = true;
                                                }
                                                else
                                                {
                                                    tgs.Checked = false;
                                                }
                                            }
                                            if (tgs.Tag.ToString() == "edit")
                                            {
                                                if (pr_edit == "TRUE")
                                                {
                                                    tgs.Checked = true;
                                                }
                                                else
                                                {
                                                    tgs.Checked = false;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (privilage.tb.Rows.Count == 0)
                {
                    foreach (Guna.UI2.WinForms.Guna2CustomCheckBox cbb in panel1.Controls.OfType<Guna.UI2.WinForms.Guna2CustomCheckBox>())
                    {
                        // สั่งเปิด cbb ให้หมด
                        cbb.Enabled = true;
                    }
                }

            }
        }

        void CLEAR_MENU_AND_PRIVIRAGE()
        {
            // ลูป panel เพื่อหา togleswitch
            foreach (Panel pn in panel1.Controls.OfType<Panel>())
            {
                // ลูป disible togleswitch
                foreach (Guna.UI2.WinForms.Guna2ToggleSwitch tgs in pn.Controls.OfType<Guna.UI2.WinForms.Guna2ToggleSwitch>())
                {
                    tgs.Checked = false;
                }
                pn.Enabled = false;
            }

            // ลูป disible ชื่อเมนู
            foreach (Guna.UI2.WinForms.Guna2CustomCheckBox checkBox in panel1.Controls.OfType<Guna.UI2.WinForms.Guna2CustomCheckBox>())
            {
                checkBox.Checked = false;
                checkBox.Enabled = false;
            }
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            // กำหนดค่า cbbEmployee เป็นค่าเริ่มต้น
            cbbEmployee.Items.Clear();
            cbbEmployee.Items.Add("--เลือกชื่อผู้ใช้งาน--");
            cbbEmployee.SelectedIndex = 0;
            // เครีย์ฟอร์มให้พร้อมทำงาน
            CLEAR_MENU_AND_PRIVIRAGE();
        }

        private void cbbEmployee_DropDownClosed(object sender, EventArgs e)
        {
            if (cbbEmployee.Text == "")
            {
                CLEAR_MENU_AND_PRIVIRAGE();
                cbbEmployee.Items.Clear();
                cbbEmployee.Items.Add("--เลือกชื่อผู้ใช้งาน--");
                cbbEmployee.SelectedIndex = 0;
            }
        }

        private void cbbEmployee_DropDown(object sender, EventArgs e)
        {
            cbbEmployee.Items.Clear();
            // ดึงข้อมูลรายชื่อ พนักงานมาแสดง
            if (employee.Select())
            {
                foreach (DataRow rw in employee.tb.Rows)
                {
                    string _user = rw["emp_username"].ToString();
                    string _name = rw["emp_names"].ToString();

                    // เพิ่มข้อมูลไปที่ cbbEmployee
                    cbbEmployee.Items.Add($"{_user} | {_name}");
                }
            }
        }

        private void cbbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbEmployee.Text != "--เลือกชื่อผู้ใช้งาน--")
            {
                string[] select = cbbEmployee.Text.Split('|');
                // ตรวจสอบก่อนว่าผู้ใช้ได้เลือก sa หรือไม่ เพราะเนื่องจาก sa จะไม่สามารถแก้ไขได้ 
                if (select[0].Trim() == "sa")
                {
                    msg.Show(this, "ไม่สามารถแก้ไชสิทธิ์การใช้งานสิทธิ์ sa ได้", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                    //หากเลือก sa ให้เครียค่ากลับเหมือนเดิม
                    cbbEmployee.Items.Clear();
                    cbbEmployee.Items.Add("--เลือกชื่อผู้ใช้งาน--");
                    cbbEmployee.SelectedIndex = 0;

                    // สั่งเครีย์ค่าทั้งหดม
                    CLEAR_MENU_AND_PRIVIRAGE();
                }
                // แต่ถ้านอกเนื่อจากนี้ให้ทำการดึงช้อมูลสิทธื์การใช้งานแต่ละ user มาแสดงและ โชวร์ที่โปรแกรม
                else
                {
                    GET_MENU_AND_PRIVIRATE(select[0].Trim());
                }

                // Check funstion
                if (registy.function.RFIDState == "FALSE")
                    cbRFID.Enabled = false;

                if (registy.function.LPRState == "FALSE")
                    cbLPR.Enabled = false;

                if (registy.function.CAMERAState == "FALSE")
                    cbCCTV.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // ทำการเช็คก่อนว่ามีค่าว่างหรือไม่
                if (cbbEmployee.Text != "--เลือกชื่อผู้ใช้งาน--")
                {
                    string[] select = cbbEmployee.Text.Split('|');
                    #region ค้นหา user_id
                    DataTable tbemp = employee.SelectChar(select[0].Trim());
                    string user_id = "";
                    foreach (DataRow rw in tbemp.Rows)
                    {
                        user_id = rw["id"].ToString();
                        break;
                    }

                    // นำ user_id ไปลบสิทธิ์ทั้งหมดก่อน
                    privilageModels privilageModels = new privilageModels
                    {
                        user_id = user_id
                    };
                    if (!privilage.Delete(privilageModels))
                    {
                        return;
                    }
                    #endregion

                    #region อ่านค่าจาก object บันทึกข้อมู
                    // ทำการลูปบันทึกข้อมูล
                    foreach (Guna.UI2.WinForms.Guna2CustomCheckBox cbb in panel1.Controls.OfType<Guna.UI2.WinForms.Guna2CustomCheckBox>())
                    {
                        // สร้างตัวแปรสำหรับการเก็บค่า pr_add,pr_del,_pr_edit
                        string pr_add = "FALSE";
                        string pr_del = "FALSE";
                        string pr_edit = "FALSE";
                        // หากมีการเลือกเมนูให้ทำการบันทัก
                        if (cbb.Checked)
                        {
                            // ทำการลูปเช็คว่า ในเมนูนั้นมีสิทธิ์อะไรบ้าง
                            foreach (Panel pn in panel1.Controls.OfType<Panel>())
                            {
                                if (cbb.Text == pn.Tag.ToString())
                                {
                                    foreach (Guna.UI2.WinForms.Guna2ToggleSwitch tgs in pn.Controls.OfType<Guna.UI2.WinForms.Guna2ToggleSwitch>())
                                    {
                                        // ตรวจสอบว่ามีสิทธิ์อะไรเปิดบ้าง
                                        if (tgs.Checked == true)
                                        {
                                            switch (tgs.Tag)
                                            {
                                                case "add":
                                                    pr_add = "TRUE";
                                                    break;
                                                case "del":
                                                    pr_del = "TRUE";
                                                    break;
                                                case "edit":
                                                    pr_edit = "TRUE";
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                            // กำหนดค่าก่อนบันทึก
                            privilageModels privilages = new privilageModels
                            {
                                user_id = user_id,
                                menu_id = cbb.Tag.ToString(),
                                add = pr_add,
                                del = pr_del,
                                edit = pr_del
                            };

                            if (!privilage.Insert(privilages))
                            {
                                msg.Show(this, "เกิดข้อผิดผลา " + privilage.ERR, BunifuSnackbar.MessageTypes.Error, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                                return;
                            }
                        }

                    }
                    msg.Show(this, "บันทึกข้อมูลสำเร็จ", BunifuSnackbar.MessageTypes.Success, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                    // เครีย์ข้อมูล
                    CLEAR_MENU_AND_PRIVIRAGE();
                    // คืนค่าให้กับ cbbEmployee
                    cbbEmployee.Items.Clear();
                    cbbEmployee.Items.Add("--เลือกชื่อผู้ใช้งาน--");
                    cbbEmployee.SelectedIndex = 0;
                    #endregion              
                }
                else
                {
                    // กรณีไม่ได้เลือกชื่อผู้ใช้
                    bunifuSnackbar1.Show(this,
                        "กรุณาเลือกผู้ใช้ที่ต้องการให้สิทธิ์ใช้งานโปรแกรม",
                        Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning,
                        3000,
                        "OK",
                        Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                }
            }
            catch (Exception ex)
            {
                bunifuSnackbar1.Show(this, "เกิดข้อผิดผลาด " + ex.Message, BunifuSnackbar.MessageTypes.Error, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
            }

        }

        private void guna2CustomCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2CustomCheckBox cbb = sender as Guna.UI2.WinForms.Guna2CustomCheckBox;

            if (cbb.Checked == false)
            {
                foreach (Panel panel in panel1.Controls.OfType<Panel>())
                {
                    if (cbb.Text == panel.Tag.ToString())
                    {
                        //foreach (Guna.UI2.WinForms.Guna2ToggleSwitch tgsPri in panel.Controls.OfType<Guna.UI2.WinForms.Guna2ToggleSwitch>())
                        //{
                        //    tgsPri.Checked = false;
                        //}
                        panel.Enabled = false;
                    }
                }
            }
            else if (cbb.Checked == true)
            {
                foreach (Panel panel in panel1.Controls.OfType<Panel>())
                {
                    if (cbb.Text == panel.Tag.ToString())
                    {
                        panel.Enabled = true;
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
