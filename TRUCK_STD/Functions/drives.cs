using System.IO;

namespace TRUCK_STD.Functions
{
    internal class drives
    {


        public static DriveInfo[] Get()
        {
            // ดึงข้อมูลเกี่ยวกับไดรฟ์ทั้งหมดในคอมพิวเตอร์
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            return allDrives;
        }

    }
}
