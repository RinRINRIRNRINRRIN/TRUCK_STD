const express = require('express');
const cors = require('cors');
const multer = require('multer');
const upload = multer(); // 
const app = express();

app.use(express.json({ limit: '50mb' }));
app.use(cors());

// Middleware เพื่อจัดการกับข้อมูลที่ถูกส่งมาในรูปแบบ x-www-form-urlencoded
app.use(express.urlencoded({ extended: true, limit: '50mb' }));

let ipArray = [];
let ip1 = "";
let ip2 = "";


app.get('/testApi/',(req,res)=>{
  res.status(200).json({
    message : "success"
  });
});

// For cam add data
app.post('/camera/', async (req, res) => {
  console.log('========================================================= Camera access');
  const data = await req.body;
  const ip = data["cam_ip"];

  switch (ip) {
    case "192.168.1.205":
      ip1 = data;
      console.log(ip1['plate_num']);
      console.log(ip1["cam_ip"]);
      break;
    case "192.168.1.206":
      ip2 = data;
      console.log(ip2['plate_num']);
      console.log(ip2['cam_ip']);
      break;
  }
});

app.get('/get-licensePlate/', (req, res) => {
  const ip = req.query.ipcam;
  switch (ip) {
    case "192.168.1.205":
      res.status(200).json(ip1); // ส่งข้อมูล JSON ที่พบ
      break;
    case "192.168.1.206":
      res.status(200).json(ip2); // ส่งข้อมูล JSON ที่พบ
      break;
    default:
      res.status(404).json({ message: "ip not found" });
      break;
  }
});

app.post('/reset/', (req, res) => {
  const ip = req.query.ipcam;
  switch (ip) {
    case "192.168.1.205":
      ip1 = null;
      res.status(200).json({ message: "success" }); // ส่งข้อมูล JSON ที่พบ
      break;
    case "192.168.1.206":
      ip2 = null;
      res.status(200).json({ message: "success" }); // ส่งข้อมูล JSON ที่พบ
      break;
    default:
      res.status(404).json({ message: "ip not found" });
      break;
  }
});

app.listen(1234, () => {
  console.log('App is running');
});