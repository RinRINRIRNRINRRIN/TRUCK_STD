namespace TRUCK_STD.Function
{
    class Func_Privilage
    {
        // Class สำหรับ กำหนดสิทธิ์การใช้งาน โดยมีค่าเริ่มต้นเป็น FALSE
        public static string emp_usernmae = "";     // ใช้สำหรับเก็บค่าเมื่อมีการ Login เข้ามา
        public static string emp_password = "";
        public static string emp_name = "";         // ใช้สำหรับเก็บผู้ช้ชื่ออะไร
        public static class pr_customer
        {
            public static string pr_systemAdd = "FALSE";
            public static string pr_systemDel = "FALSE";
            public static string pr_systemEdit = "FALSE";
        }

        public static class pr_employee
        {
            public static string pr_systemAdd = "FALSE";
            public static string pr_systemDel = "FALSE";
            public static string pr_systemEdit = "FALSE";
        }

        public static class pr_product
        {
            public static string pr_systemAdd = "FALSE";
            public static string pr_systemDel = "FALSE";
            public static string pr_systemEdit = "FALSE";
        }

        public static class pr_weight
        {
            public static string pr_systemAdd = "FALSE";
            public static string pr_systemDel = "FALSE";
            public static string pr_systemEdit = "FALSE";
        }

        public static class pr_history
        {
            public static string pr_systemAdd = "FALSE";
            public static string pr_systemDel = "FALSE";
            public static string pr_systemEdit = "FALSE";
        }
    }
}
