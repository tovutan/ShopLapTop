create database laptopnew
go
use  laptopnew
go

create table taikhoan
(
	username varchar(60) primary key,
	password varchar(60) not null,
	status bit not null
)
go
create table Nhanhieu
(
	Mahieu int primary key,
	Tenhieu nvarchar(60),
	hinh varchar(50) null
)
go

create table Loai
(
	Maloai int primary key,
	Tenloai nvarchar(60)
)
go

create table Sanpham
(
	MaSP INT  primary key,
	TenSP nvarchar(150),	
	cpu varchar(200) null,
	vga varchar(200) null,
	ram varchar(100) null,
	hdd varchar(100) null,
	ssd varchar(70) null,
	manhinh varchar(200) null,
	cd_dvd varchar(100) null,
	ketnoi nvarchar(150) null,
	tichhop nvarchar(300) null,
	trongluong nvarchar(30) null,
	pin nvarchar(30) null,
	hdh nvarchar(90) null,
	Giaban decimal(18,0) null,
	Giakhuyenmai decimal(18,0) default 0,
	BaoHanh int null,
	Mota ntext null,
	Ngayban date null,
	Hinh varchar(70) null,
	trangthai bit,
	Maloai int references Loai(Maloai),
	Mahieu  int references Nhanhieu(Mahieu)
)
go



create table Khachhang
(
	Email varchar(50) primary key,
	Password varchar(50) not null,
	Hoten nvarchar(60) null,
	Gioitinh nvarchar(6) null,
	Diachi nvarchar(90) null,
	Dienthoai varchar(11) not null,
)
go

delete from hoadon

select *from hoadon

create table Hoadon
(
	MaHD int primary key identity,
	Ngaymua date default getdate(),
	Email varchar(50) references Khachhang(Email),
	Ngaygiaohang date null,
	TrigiaHD decimal(18,0) null
)
go
insert into hoadon values(GETDATE(),'tovutan20111995@gmail.com',GETDATE(),0);

CREATE table CT_HoaDon
(
	MaHD INT references Hoadon(MaHD),
	MaSP INT references Sanpham(MaSP),
	Soluong int default 0,
	Dongia decimal(18,0),
	primary key(MaHD,MaSP)
)
go





insert into taikhoan(username,password,status) values(N'tan','123',1)
go

-- them khach hang
insert into khachhang(Email,password,Hoten,Gioitinh,diachi,Dienthoai) 
values
('bi@yahoo.com','123',N'Trần Văn Tèo',N'Nam',N'quận 1 TP.HCM','0909123456'),
('bo@yahoo.com','234',N'Trần Văn Tý',N'Nam',N'quận 5 TP.HCM','0919123456'),
('tan@gmail.com','123',N'Tân',N'Nam',N'quận 1 TP.HCM','098909898');
go
-- them hoadon
insert into hoadon(Ngaymua,Email,Ngaygiaohang,TrigiaHD) values
('12/22/2017','bo@yahoo.com','12/25/2017',0);
go
-- Thêm loai
insert into loai(Maloai,Tenloai) values(1,N'Gaming')
insert into loai(Maloai,Tenloai) values(2,N'Design')
insert into loai(Maloai,Tenloai) values(3,N'Workstation')
insert into loai(Maloai,Tenloai) values(4,N'Student')
go
-- them nhanhieu
insert into nhanhieu(mahieu,Tenhieu,hinh) values(1,N'ASUS','logo asus.png')
insert into nhanhieu(mahieu,Tenhieu,hinh) values(2,N'HP','1024px-HP_logo_2012.svg.png')
insert into nhanhieu(mahieu,Tenhieu,hinh) values(3,N'DELL','dell-log.jpg')
insert into nhanhieu(mahieu,Tenhieu,hinh) values(4,N'MSI','27x32_logoMSI.png')
insert into nhanhieu(mahieu,Tenhieu,hinh) values(5,N'ACER','Logo Acer.png')
INSERT INTO nhanhieu(mahieu,tenhieu,hinh) values(6,'LENOVO','logo1_lenovo.png')
go


select distinct(TenSP) from sanpham 
where tensp like N'Asus %' and giaban>10000000 and Giaban<=15000000
 

select distinct(TenSP) from sanpham 
where tensp like N'Asus %' and giaban<10000000

select distinct(TenSP) from sanpham 
where tensp like N'dell %' and giaban>15000000 and Giaban<=20000000

select distinct(TenSP) from sanpham 
where tensp like N'dell %' and giaban>20000000 and Giaban<=25000000

select distinct(TenSP) from sanpham 
where tensp like N'lenovo %' and giaban>25000000 

-- them sản phẩm 
-- gaming
---- asus
insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(1,N'Asus ROG Zephyrus GX501VI-GZ029T',N'Intel® Core™ i7-7700HQ (2.8GHz upto 3.8GHz, 4Cores, 8Threads, 6MB cache, FSB 8GT/s)',
N'NVIDIA GeForce® GTX 1080M 8GB GDDR5 + Intel® HD Graphics 630',N'24GB DDR4 2400MHz (1x16GB + 1x8GB)',NULL,
N'1TB SSD M2 PCIe3x4',N'15.6 FHD IPS (1920x1080) with 120Hz, Công nghệ Anti Glare',N'None',N'Integrated 802.11 ac | Wireless 802.11AC | BT 4.0 |',
N'1 x Microphone-in jack1 x Headphone-out jack 2 x USB 3.1 TYPE C port(s)3 x USB 3.0 port(s) 1 x RJ45 LAN Jack for LAN insert 1 x HDMI 1 x mini Display Port1 x Thunderbolt port 1 x SD card reader1X AC adapter plug',
N'2.2 Kg (kích thước 16.9mm)',N'4 Cells 50 Whrs',N'Windows 10 bản quyền',79900000,79900000,24,N'LAPTOPGAMING',null,N'220x200-Asus-GX501VI.png',1,1,1)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)    
values(2,N'Asus FX553VD-DM304S',N'Intel® Core™ i5-7300HQ (2.5GHz upto 3.5GHz, 4Cores, 4Threads, 6MB cache, FSB 8GT/s)',
N'NVIDIA GeForce® GTX 1050 4GB GDDR5 + Intel® HD Graphics 630',N'8GB DDR4 2400MHz (1x8GB) + 1 slot Ram.',N' 1TB HDD 7200rpm',
N'128GB SSD M2 Sata3 (upgrade)',N'15.6 FHD IPS (1920x1080)',N'DVD±R/RW supperMulti DL',N'1000Mbps | Wifi 802.11 ac,b,g,n | Bluetooth 4.1',N'Reader SD | Camera HD | HDMI | USB 3.0 | USB C+ | Thunderbolt',
N'2.4 Kg',N'4 Cell 48 Whrs Pin',N'FreeDOS',19500000,19500000,24,N'LAPTOPGAMING',null,N'220x200-asus-fx553vd1.png',1,1,1)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(3,N'Acer VX5-591G-52YZR',N'Intel® Core™ i5-7300HQ (2.5GHz upto 3.5GHz, 4Cores, 4Threads, 6MB cache, FSB 8GT/s)',
N'NVIDIA GeForce® GTX 1050 4GB GDDR5 + Intel® HD Graphics 630',N'16GB DDR4 2400MHz (1x8GB) + (1x8GB) upgrade, 2 slot Ram, Max 32GB',N'1TB HDD 5400rpm',
N'128GB SSD M2 SATA3',N'15.6 FHD (1920x1080)',N'None',N'1000Mbps | 802.11ac | Bluetooth 4.1',N'Reader SD | Camera HD | HDMI | USB 3.0 | USB C+ | Thunderbolt | Backlit',
N'2.4 Kg',N'4 CELL - 64WHrs - gần 3.5giờ',N'FreeDOS',19400000,19400000,12,N'LAPTOPGAMING',null,N'220x200-Acer-Aspire-VX5-591G-31.png',1,1,5)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)   
values(4,N'MSI GP72M 7REX-873XVN Leopard Pro',N'Intel® Core™ i7-7700HQ (2.8GHz upto 3.8GHz, 4Cores, 8Threads, 6MB cache, FSB 8GT/s)',
N'NVIDIA GeForce® GTX 1050Ti 4GB GDDR5 + Intel® HD Graphics 630',N'8GB DDR4 2400MHz (1x8GB) + 1 slot Ram',N'1TB HDD 7200rpm + 1 slot SSD M2 PCIe3x4',
null,N'17.3 FHD (1920*1080), 120Hz wideview 94%NTSC color Anti-Glare',N'None',N'Killer Gb LAN + Intel 3168 Sandy Peak 1 (1x1 802.11 ac) + BT4.2',
N'USB-C, USB3.0, USB2.0, RJ45, SD, HDMI, Mini-DisplayPort',
N'2.7 Kg',N'6 Cell 41 Whr',N'FreeDos',35000000,35000000,24,N'LAPTOPGAMING',null,N'220x200-msi-GP72M-7REX.png',1,1,4)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(20,N'Acer Predator Helios 300 G3-572-70J1',N'Intel® Core™ i7-7700HQ 2.8GHz up to 3.8GHz 6MB',
N'NVIDIA GeForce® GTX 1050Ti 4GB + Intel HD Graphics 620',N'8GB DDR4 2400MHz','HDD 1TB 5400rpm, x1 slot SSD M.2',
N'128GB SSD',N'15.6" FHD (1920 x 1080) IPS, Anti-Glare',N'None',N'802.11a/b/g/n | 10/100/1000 Mbps | BT 4.0 |',
N'2 x USB 2.0, 1 x USB 3.0, 1 x USB 3.1 Type C, 1 x HDMI',
N'2.7 kg',N'4 Cell 48 WHrs',N'Free Dos',29990000,29990000,12,N'LAPTOPGAMING',null,N'220x200-acer predator helios 300 g3 572 70j1_lager.png',1,1,5)
--design
insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(5,N'Dell Inspiron N7566-N7566A',N'Intel® Core™ i7-6700HQ (2.6GHz upto 3.5GHz, 4Cores, 8Threads, 6MB cache, FSB 8GT/s)',
N'NVIDIA GeForce® GTX 960M 4GB GDDR5 + intel Graphic HD 530',N'8GB DDR4 2133MHz (1x8GB) + 1 slot RAM',N'500GB HDD 5400rpm',
N'128GB SSD',N'15.6 FHD (1920x1080)',N'None',N'1000Mbps | Wifi 802.11b,g,n | Bluetooth 4.1',
N'Reader SD | Camera HD | HDMI | USB 3.0 | MaxxAudio | Backlit | 3 Fan tải nhiệtLaptop có hỗ trợ SLOT nâng cấp SSD M2 SATA3',
N'2.5 Kg',N'gần 3giờ sử dụng',N'Windows 10 bản quyền',
24700000,24700000,12,N'LAPTOPDESIGN',null,N'220x200-Dell Inspiron 7566-N7566A.png',1,2,3)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(6,N'Dell Inspiron 7567-N7567A',N'Intel® Core™ i7-7700HQ (2.8GHz upto 3.8GHz, 4Cores, 8Threads, 6MB cache, FSB 8GT/s)',
N'NVIDIA GeForce® GTX 1050Ti 4GB GDDR5 + Intel® HD Graphics 630',N'8GB DDR4 Bus 2400Mhz (2 Slot, 8GB x 01)',N'500GB HDD  5400rpm',
N'128GB SSD M2 SATA3',N'15.6 FHD (1920x1080)',N'None',N'802.11ac + Bluetooth 4.0, 2.4 GHz',
N'Webcam, Card Reader, USB 3.0, USB 3.1 Type C, HDMI, Backlit Keyboard, Dual Fans',
N'2.5 Kg',N'6 Cells 74 Whrs',N'Windows 10 bản quyền',26500000,26500000,12,N'LAPTOPDESIGN',null,N'220x200-Dell Inspiron 7567-N7567A.png',1,2,3)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(7,N'Dell Inspiron 7559-N7559A',N'Intel® Core™ i7-6700HQ (2.6GHz upto 3.5GHz, 4Cores, 8Threads, 6MB cache, FSB 8GT/s)',
N'NVIDIA Geforce® GTX 960M 4GB GDDR5 + Intel® HD Graphics 530',N'8GB DDR3L Bus 1600MHz',N'1TB HDD 5400rpm +1 slot SSD M2 SATA3',
null,N'15.6 FHD (1920 x 1080 pixels)-Backlit + Anti-Glare',N'None',N'1000Mbps / WLan 802.11b,g,n / Bluetooth 4.0',
N'Reader SD | Camera HD | DVI | USB 3.0 | Backlit',N'2.57 kg',N'6 Cells 74 Whrs',N'Windows 10 bản quyền',23200000,23200000,12,
N'LAPTOPDESIGN',null,N'220x200-dell-inspiron-7559.png',1,2,3)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(15,N'Asus VivoBook S15 S510UQ-BQ483T',N'Intel® Core™ i7-8550U (1.8GHz Upto 4.0GHz, 4Cores, 8Threads, 8MB cache, FSB 4GT/s)',
N'NVIDIA Geforce® 940MX 2GB GDDR5 + Intel® UHD Graphics 620',N'8GB DDR4 Buss 2400MHz, 2 Slots RAM',N'1TB HDD 5400rpm + 1 Slot SSD M2 SATA3',
null,N'15.6 (16:9) backlit FHD (1920x1080) 60Hz Anti-Glare Panel with 45% ',N'None',N'Integrated 802.11 AC (2x2) + Built-in Bluetooth V4.1',
N'Microphone-in/Headphone-out jack, Type C USB3.0 (USB3.1 GEN1), USB 3.0 port(s), USB 2.0 port(s), HDMI, Finger',
N'1.7 Kg',N'3 Cells 42 Whrs Battery',N'Windows 10 bản quyền',
21490000,20800000,24,N'LAPTOPSTUDENTS',null,N'220x200-Asus-Vivobook-S15-S5105.png',1,2,1)


-- Workstation
insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(8,N'MSI WS60 7RJ1',N'Intel® Xeon® E3-1505M V6 (3.0GHz Up to 4.0Ghz, 4Cores, 8Threads, 8MB Cache)',
N'NVIDIA GeForce® Quadro M2200 4GB GDDR5 + Intel® HD Graphics 630',N'32GB DDR4 Buss 2133Mhz (ECC), 2 Slots, Max 32GB',N'1TB HDD 7200rpm',
N'256GB SSD M2 PCIe3x4 (Super Raid 4)',N'15.6 FHD, Anti-Glare (1920*1080) eDP IPS-Level',N'None',
N'Intel 8265 Windstorm Peak (2x2)+BT4.1 M.2 type',
N'Speaker, Audio Jack, Type-C (USB3.1 Gen2 / DP / Thunderbolt™3), Type-A USB3.0, RJ45, Card Reader (XC/HC), HDMI (4K @ 30Hz), Mini-DisplayPort',
N'1.9 Kg',N'6-Cell 47 Whr',N'Windows 10 Pro bản quyền',68990000,68990000,24,N'LAPTOPWORKSTATION',null,N'220x200-msi-ws60-7rj.png',1,3,4)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)   
values(9,N'MSI WS62 7RJ',N'Intel® Core™ i7-7700HQ (2.8GHz upto 3.8GHz, 4Cores, 8Threads, 6MB cache, FSB 8GT/s)',
N'NVIDIA GeForce® Quadro M2200 4GB GDDR5 ',N'16GB DDR4 Buss 2400Mhz, 2 Slots, Max 32GB',N'1TB HDD 7200rpm',
N'128GB SSD M2 PCIe3x4',N'15.6 FHD, Anti-Glare (1920*1080) eDP IPS-Level',N'DVD±R/RW supperMulti DL',N'Intel 8265 Windstorm Peak (2x2)+BT4.1 M.2 type',
N'Speaker, Audio Jack, Type-C (USB3.1 Gen2 / DP / Thunderbolt™3), Type-A USB3.0, RJ45, Card Reader (XC/HC), HDMI (4K @ 30Hz), Mini-DisplayPort',
N'2.4 Kg',N'6-Cell Li-ion 51 Whr',N'Windows 10 Pro bản quyền',53990000,53990000,24,N'LAPTOPWORKSTATION',null,N'220x200-MSI-WE62-7RJ.png',1,3,4)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(10,N'MSI WE72 7RJ',N'Intel® Core™ i7-7700HQ (2.8GHz upto 3.8GHz, 4Cores, 8Threads, 6MB cache, FSB 8GT/s)',
N'NVIDIA GeForce® Quadro M2200 4GB GDDR5 + Intel® HD Graphics 630',N'16GB DDR4 Buss 2400Mhz, 2 Slots, Max 32GB',N'1TB HDD 7200rpm',
N'128GB SSD M2 PCIe3x4',N'17.3 FHD, Anti-Glare (1920*1080) eDP IPS-Level',N'DVD±R/RW supperMulti DL',
N'Intel 3168 Sandy Peak 1 (1x1 802.11 ac)+BT4.2',
N'Speaker, Audio Jack, Type-C USB3.1 Gen2, Type-A USB3.0, Type-A USB2.0, RJ45, Card Reader (XC/HC), HDMI (4K @ 30Hz), Mini-DisplayPort',
N'2.7 Kg',N'6-Cell Li-ion 51 Whr',N'Windows 10 Pro bản quyền',54990000,54990000,12,N'LAPTOPWORKSTATION',null,N'220x200-MSI-WE72-7RJ.png',1,3,4)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)   
values(11,N'MSI WT73VR 7RM2',N'Intel® Core™ i7-7820HK (2.9GHz upto 3.9GHz, 4Cores, 8Thread, 8M cache, FSB 8GT/s)',
N'NVIDIA GeForce® Quadro P5000 16GB GDDR5 ',N'32GB DDR4 Bus 2400MHz (2x16GB), 4 Slots, Max 64GB',N'1TB HDD 7200rpm',
N'256GB SSD M2 PCIe3x4 (Super Raid 4)',N'17.3 FHD, Anti-Glare (1920*1080) eDP IPS-Level',N'None',
N'Intel 8265 Windstorm Peak (2x2)+BT4.1 M.2 type',N'Speaker, Woofer, Audio Jack, Type-C (USB3.1 Gen2/DP/ Thunderbolt™3), Type-A USB 3.0, RJ45, Card Reader, HDMI, Mini-DisplayPort',
N'4.14 Kg',N'9 Cell Li-ion 75 Whr',N'Windows 10 Pro bản quyền',129900000,129900000,24,N'LAPTOPWORKSTATION',null,N'220x200-msi-wt73vr-7rm2.png',1,3,4)
--STUDENT

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)    
values(12,N'Asus A540UP-GO097T',N'Intel® Core™ i5-7200U (2.50GHz Upto 3.10GHz, 2Cores, 4Threads, 3MB Cache, FSB 4GT/s)',
N'AMD Radeon R5 M420 2GB + Intel® HD Graphics 620',N'4GB DDR4 2133MHz (1x4GB) + 1 slot RAM.',N'500GB HDD 5400rpm',
null,N'15.6 Backlit (1366x768)',N'None',N'Intel 802.11b/g/n (1x1) + Bluetooth® 4.0',N'HDMI, LAN (RJ45), USB 2.0, USB Type-C, USB 3.0, VGA (D-Sub)',
N'1.9 Kg',N'3 Cells 41Whr',N'Windows 10 bản quyền',12250000,12250000,24,N'LAPTOPSTUDENTS',null,N'220x200-Asus A540UP-GO097T-org.png',1,4,1)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)   
values(13,N'Asus K555LD-XX803D',N'Intel® Core™ i7-5500U (2.40GHz Upto 3.00GHz, 2Cores, 4Threads, 4MB cache, FSB 5GT/s)',
N'NVIDIA GeForce® 820M 2GB GDDR3 + Intel® HD Graphics 5500',N'4GB DDR3L Bus 1600MHz',N'500GB HDD 5400rpm',
null,N'15.6inch HD (1366x768)',N'None',N'Intel 802.11b/g/n + Bluetooth V4.0',N'USB 2.0 port(s), HDMI, RJ45 LAN Jack for LAN insert, SD card reader, COMBO audio jack',
N'2.3 Kg',N'2 Cell 37 Whrs',N'Free Dos',12500000,12250000,12,N'LAPTOPSTUDENTS',null,N'220x200-Asus_K555LD-XX361D1.png',1,4,1)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)   
values(14,N'Asus VivoBook S15 S510UQ-BQ216',N'Intel® Core™ i7-7500U (2.70GHz upto 3.50GHz, 2Cores, 4Threads, 4MB Cache, FSB 4GT/s)',
N'NVIDIA GeForce® GT 940MX 2GB GDDR5 + Intel® HD Graphics 620',N'8GB DDR4 Buss 2133 MHz, 2 Slots',N'1TB HDD 5400rpm + 1 Slot SSD M2 SATA3',
null,N'15.6 (16:9) backlit FHD (1920x1080) 60Hz Anti-Glare Panel with 45% NTSC with 178˚ wide-viewing angle display',
N'None',N'Integrated 802.11 AC (2x2) + Built-in Bluetooth V4.1',N'Microphone-in/Headphone-out jack, Type C USB3.0 (USB3.1 GEN1), USB 3.0 port(s), USB 2.0 port(s), HDMI, Finger',
N'1.7 Kg',N'3 Cells 42 Whrs Battery',N'FreeDos',
17500000,17500000,12,N'LAPTOPSTUDENTS',null,N'220x200-Asus-Vivobook-S15-S5105.png',1,4,1)


insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(16,N'Asus VivoBook S15 S510UQ-BQ483T',N'Intel® Core™ i7-8550U (1.8GHz Upto 4.0GHz, 4Cores, 8Threads, 8MB cache, FSB 4GT/s)',
N'NVIDIA Geforce® 940MX 2GB GDDR5 + Intel® UHD Graphics 620',N'8GB DDR4 Buss 2400MHz, 2 Slots RAM',N'1TB HDD 5400rpm + 1 Slot SSD M2 SATA3',
null,N'15.6 (16:9) backlit FHD (1920x1080) 60Hz Anti-Glare Panel with 45% NTSC with 178˚ wide-viewing angle display',
 N'None',N'Integrated 802.11 AC (2x2) + Built-in Bluetooth V4.1',N'Microphone-in/Headphone-out jack, Type C USB3.0 (USB3.1 GEN1), USB 3.0 port(s), USB 2.0 port(s), HDMI, Finger',
 N'1.7 Kg',N'3 Cells 42 Whrs Battery',N'Windows 10 bản quyền',20800000,20800000,24,N'LAPTOPSTUDENTS',null,N'220x200-Asus-Vivobook-S15-S5108.png',1,4,1)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(17,N'Asus GL553VE-FY096',N'Intel® Core™ i7-7700HQ (2.8GHz upto 3.8GHz, 4Cores, 8Threads, 6MB cache, FSB 8GT/s)',
N'NVIDIA GeForce® GTX 1050Ti 4GB GDDR5 + Intel® HD Graphics 630',N'16GB DDR4 2400MHz (2x8GB), 2 Slot RAM, Max 32GB',N'1TB HDD 7200rpm + 1 slot SSD M2 PCIe3x4',
null,N'15.6 FHD IPS (1920x1080)',N'DVD±R/RW supperMulti DL',N'1000Mbps | 802.11ac | Bluetooth 4.1',N'Reader SD | Camera HD | HDMI | USB 3.0 | USB C+ | Thunderbolt | Backlit',
N'2.4 Kg',N'gần 3.5giờ sử dụng',N'FreeDOS',
27490000,24900000,24,N'LAPTOPGAMING',null,N'220x200-Asus-GX501VI.png',1,1,1)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(18,N'Asus ROG Zephyrus GX501VI-GZ029T',N'Intel® Core™ i7-7700HQ (2.8GHz upto 3.8GHz, 4Cores, 8Threads, 6MB cache, FSB 8GT/s)',
N'NVIDIA GeForce® GTX 1080M 8GB GDDR5 + Intel® HD Graphics 630',N'24GB DDR4 2400MHz (1x16GB + 1x8GB)',NULL,
N'1TB SSD M2 PCIe3x4',N'15.6 FHD IPS (1920x1080) with 120Hz, Công nghệ Anti Glare',N'None',N'Integrated 802.11 ac | Wireless 802.11AC | BT 4.0 |',
N'1 x Microphone-in jack1 x Headphone-out jack 2 x USB 3.1 TYPE C port(s)3 x USB 3.0 port(s) 1 x RJ45 LAN Jack for LAN insert 1 x HDMI 1 x mini Display Port1 x Thunderbolt port 1 x SD card reader1X AC adapter plug',
N'2.2 Kg (kích thước 16.9mm)',N'4 Cells 50 Whrs',N'Windows 10 bản quyền',79900000,79900000,24,N'LAPTOPGAMING',null,N'220x200-Asus-GX501VI.png',1,1,1)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(19,N'Acer AS A515-51-39GT',N'Intel® Core™ i3-7100U 2.4GHz 3MB',
N'Intel Graphics HD 620',N'4GB DDR4 2400MHz','500GB HDD 5400rpm, x1 slot SSD M.2',
null,N'15.6 inch FHD (1920 x 1080)',N'None',N'802.11a/b/g/n | 10/100/1000 Mbps | BT 4.0 |',
N'USB 2.0 USB 3.0 HDMI LAN',
N'2.0 kg',N'4 Cell 48WHrs',N'Free Dos',10490000,10490000,12,N'LAPTOPSTUDENTS',null,N'220x200-acer as a515 51 39gt_lager.png',1,4,5)


insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(21,N'Acer Swift SF315-51-530V',N'Intel® Core™ i5-8250U 4*1.6GHz up 3.4GHz 6MB',
N'Intel UHD Graphics 620',N'4GB DDR4 2400MHz','1TB HDD 5400rpm',
NULL,N'15.6 inch FHD (1920 x 1080 pixels) IPS, Anti-Glare',N'None',N'802.11AC',
N'2x USB 3.0, 1x USB 2.0, 1 x USB Type-C, 1x HDMI',
N'2.1 kg',N'4 Cell 3320 mAh (Up to 10h)',N'Windows 10',16990000,16990000,12,N'STUDENTS',null,N'220x200-acer swift sf315 51 530v_lager.png',1,4,5)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(22,N'Acer AS E5-575G-37WF',N'Intel® Core™ i3-7100U 2.4GHz 3MB',
N'NVIDIA GeForce® 940MX 2GB GDDR5 + Intel Graphics HD 620',N'4GB DDR4 2400MHz','500GB HDD 5400rpm, x1 slot SSD M.2 SATA',
NULL,N'15.6 inch FHD (1920 x 1080) Anti-Glare',N'DVD+/-RW',N'802.11a/b/g/n | 10/100/1000 Mbps | Bluetooth 4.0',
N'USB 2.0, USB 3.0, HDMI',
N'2.23 kg',N'4 Cell',N'Windows 10 Home',11590000,10590000,12,N'STUDENTS',null,N'220x200-acer-as-e5-575g-37wf-3613_lager.png',1,4,5)


insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(23,N'Acer AS VX5-591G-70XM',N'Intel® Core™ i7-7700HQ 2.8GHz up to 3.8GHz 6MB',
N'NVIDIA GeForce® GTX 1050 4GB GDDR5 + Intel HD Graphics 620',N'8GB DDR4 2400MHz','1TB HDD 5400rpm, x1 slot SSD M.2 SATA',
N'128GB SSD M.2 SATA',N'15.6" FHD (1920 x 1080) Anti-Glare with 94% NTSC',N'None',N'802.11ac with MU-MIMO | 10/100/1000/Gigabits Base T | Bluetooth 4.0',
N'USB 2.0 USB 3.0 HDMI LAN USB Type C 3.1',
N'2.5 kg',N'Li-ion 52 WHrs 4465mAh',N'Free DOS',23990000 ,22990000,12,N'LAPTOPGAMING',null,N'220x200-acer-aspire-vx5-591g-70xm-1970_lager.png',1,1,5)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(24,N'Acer Predator 21X - GX21-71-77KU',N'Intel® Core™ i7-7820HK 2.9GHz up to 3.9GHz 8MB',
N'NVIDIA GeForce® GTX 1080 SLI with 16GB GDDR5X',N'64GB DDR4 2400MHz','1TB HDD 7200rpm',
N'1TB SSD NVMe PCI-e',N'21" WFHD (2560x1080) IPS, G-Sync, 2000R',N'None',
N'802.11ac with MU-MIMO (Killer WLAN 1535) + Killer DoubleShot™ Pro | 10/100/1000 Gigabit LAN (Killer LAN E2500) | Bluetooth 4.0',
N'4x USB 3.0, 1x DisplayPort, 1x HDMI',
N'8.8 kg',N'8 Cells 6000 mAh',N'Windows 10 Home',229900000 ,229900000,12,N'LAPTOPGAMING',null,N'220x200-acer-predator-21x--gx21-71-77ku-4073_lager.png',1,1,5)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(25,N'Dell Inspiron 7577 (N7577C)',N'Intel® Core™ i7-7700HQ 2.8GHz up to 3.8GHz 6MB',
N'NVIDIA GeForce® GTX 1060 6GB GDDR5 Max-Q + Intel® HD Graphics 630',N'16GB DDR4 2400MHz','1TB HDD 5400rpm',
N'128GB SSD M.2',N'15.6 inch UHD (3840 x 2160) IPS, LED-Backlit + Anti-Glare',N'None',N'WLAN Intel 3165AC | 10/100/1000 Base T | Bluetooth 4.0',
N'USB 3.0, HDMI, LAN',
N'2.57 kg',N'6 Cells 74 Whrs',N'Windows 10 Home + Office 365',39990000 ,39990000,12,N'LAPTOPGAMING',null,N'220x200-dell inspiron 7577 n7577c_lager.png',1,1,3)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(26,N'HP 14-am121TX (Z4R01PA)',N'Intel® Core™ i7-7500U 2.7GHz up to 3.5GHz 4MB',
N'VGA AMD R7 M170 2GB + Intel® HD Graphics 620',N'8GB DDR4 2133MHz','1TB HDD 5400rpm',
null,N'14 inch HD (1366 x 768 pixels)',N'DVD+/-RW',N'802.11b/g/n | Bluetooth 4.0',
N'USB 3.0, HDMI, LAN',
N'1.94 kg, Màu: Trắng Bạc',N'4 Cells',N'Free DOS',15990000 ,15990000,12,N'LAPTOPDESIGN',null,N'220x200-hp 14 am121tx z4r01pa_lager.png',1,2,2)


insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(27,N'HP Envy 13-ad075TU (2LR93PA)',N'Intel® Core™ i5-7200U 2.5GHz up to 3.1GHz 3MB',
N'Intel® HD Graphics 620',N'4GB LPDDR3 Onboard',NULL,
N'256GB SSD PCIe® NVMe™',N'13.3 inch FHD (1920 x 1080) diagonal IPS BrightView micro-edge WLED-backlit',N'None',N'802.11ac | Built-in Bluetooth™ V4.0',
N'2x USB 3.1, 2x USB 3.1 Type-C',
N'1.36 kg',N'6 Cell 53.6 WHrs Li-ion',N'Windows 10 64bit bản quyền',
20990000 ,19990000,12,N'LAPTOPDESIGN',null,N'220x200-hp envy 13 ad075tu 2lr93pa_lager.png',1,2,2)


insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(28,N'HP Pavilion 14-bf017TU (2GE49PA)',N'Intel® Core™ i5-7200U 2.5GHz up to 3.1GHz 3MB',
N'Intel® HD Graphics 620',N'4GB DDR4 2400MHz',N'1TB HDD 5400rpm, 1x slot SSD M.2',
NULL,N'14" FHD (1920 x 1080) Diagonal IPS BrightView WLED-backlit',N'None',N'802.11AC | Integrated 10/100/1000 GbE LAN',
N'2x USB 3.1, 1x USB 3.1 Type-C, 1x HDMI',
N'1.63 kg, Màu: Bạc',N'3 Cell 41WHrs',N'Free DOS',14290000 ,13990000,12,N'LAPTOPDESIGN',null,N'220x200-hp pavilion 14 bf017tu 2ge49pa_lager.png',1,2,2)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(29,N'HP Pavilion Power 15-cb503TX (2LR98PA)',N'Intel® Core™ i7-7700HQ 2.8GHz up to 3.8GHz 6MB',
N'NVIDIA GeForce® GTX 1050 4GB GDDR5 + Intel® Graphics 630',N'16GB DDR4 2400MHz SDRAM (2 x 8 GB)',N'1TB HDD 7200rpm',
N'256GB SSD PCIe NVMe',N'15.6" FHD (1920 x 1080) IPS, Anti-Glare',N'None',N'Intel® 802.11a/b/g/n/ac (2x2) Wi-Fi | Integrated 10/100/1000 GbE LAN | Bluetooth® 4.2',
N'3x USB 3.1, 1x USB 3.1 Type-C, 1x HDMI',
N'2.21 kg',N'4 Cell 70 WHrs',N'Windows 10',29990000 ,28990000,12,N'LAPTOPGAMING',null,N'220x200-hp pavilion power 15 cb503tx 2lr98pa_lager.png',1,1,2)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(30,N'HP Envy 13-ab011TU (Z4Q37PA)',N'Intel® Core™ i5-7200U 2.5GHz up to 3.1GHz 3Mb',
N'Intel® HD Graphics 620',N'4GB LPDDR3 Onboard',null,
N'256GB SSD M.2',N'13.3 inch QHD (3200 x 1800)',N'None',N'802.11ac | Built-in Bluetooth™ V4.0',
N'USB 3.0 HDMI,HP TrueVision HD Webcam,HP SimplePass Fingerprint Reader',
N'1.36 kg',N'3 Cells 45 Whrs (3 giờ)',N'Windows 10 64bit bản quyền',20990000 ,19990000,12,N'LAPTOPDESIGN',null,
N'220x200-hp-envy-13-ab011tu-z4q37pa-8836_lager.png',1,2,2)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(31,N'HP Pavilion 15-au120TX (Y4G53PA)',N'Intel® Core™ i5-7200U 2.5GHz up to 3.1GHz 3MB',
N'NVIDIA GeForce® GT 940MX 2GB DDR3 + Intel® HD Graphics 620',N'4GB DDR4 2133MHz',N' 500GB HDD 5400rpm',
NULL,N'15.6 inch HD (1366 x 768 pixels)',N'SuperMulti DVD',N'802.11b/g/n | 10/100 Base T | Bluetooth 4.0',
N'USB 2.0 USB 3.0 HDMI LAN,Webcam HD',
N'2.3 kg',N'2 Cells 41Whrs Li-ion',N'Windows 10 Home SL',14990000 ,14990000,12,N'LAPTOPDESIGN',null,
N'220x200-hp-pavilion-15-au120tx-y4g53pa-1836_lager.png',1,2,2)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(32,N'MSI GE62 7RE-676XVN',N'Intel® Core™ i7-7700HQ 2.8GHz up to 3.8GHz 6MB',
N'NVIDIA GeForce® GTX 1050Ti 4GB GDDR5 + Intel® HD Graphics 630',N'8GB DDR4 2400MHz',N'1TB 7200rpm HDD, x1 slot SSD (M.2/ PCIe)',
NULL,N'15.6 inch FHD (1920 x 1080 pixels) IPS, Anti-Glare eDP Vivid Color 94%',N'Super-Multi DVD (9.5mm)',N'802.11AC (Intel 3165 StonePeak) | 10/100/1000 Base T',
N'USB 2.0 USB 3.0 HDMI LAN, HD Web Camera',
N'2.3 kg',N'6 Cell',N'Free Dos',32990000 ,27900000,12,N'LAPTOPGAMING',null,
N'220x200-msi-ge62-7re-camo-squad-11.png',1,1,4)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(33,N'Lenovo IdeaPad 110-15ISK (80UD00JEVN)',N'Intel® Core™ i3-6100U 2.30GHz 3MB',
N'AMD Radeon R5 M430 2GB + Intel® HD Graphics 520',N'4GB DDR4 2133MHz',N'1TB HDD 5400rpm',
NULL,N'15.6 inch HD (1366 x 768 pixels)',N'DVD+/-RW',N'802.11 b/g/n | 10/100/1000 Base T',
N'USB 2.0, USB 3.0, HDMI, HD Webcam',
N'2.25 kg',N'4Cells, 32WHr',N'Free Dos',9290000 ,9290000,12,N'LAPTOPSTUDENTS',null,
N'220x200-lenovo ideapad 110 15isk 80ud00jevn_lager.png',1,4,6)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(34,N'Lenovo IdeaPad 310-15IKB (80TV02E7VN)',N'Intel® Core™ i5-7200U 2.5GHz up to 3.1GHz 3MB',
N'Intel® HD Graphics 620',N'4GB DDR4 2133MHz',N'1TB HDD 5400rpm',
NULL,N'15.6" FHD (1920 x 1080) Anti-Glare',N'None',N'802.11 b/g/n | 10/100/1000 Base T',
N'USB 2.0, USB 3.0, HDMI, LAN, HD Webcam',
N'2.25 kg',N'2Cells, 39WHr',N'Windows 10 SL 64bit bản quyền',12490000 ,11990000,12,N'LAPTOPSTUDENTS',null,
N'220x200-lenovo ideapad 310 15ikb 80tv02e7vn_lager.png',1,4,6)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(35,N'Lenovo IdeaPad 510-15IKB (80SV00QSVN)',N'Intel® Core™ i7-7500U 2.7GHz up to 3.5GHz 4MB',
N'NVIDIA GeForce® GT 940MX 4GB DDR3 + Intel HD Graphics 620',N'12GB DDR4 2133MHz',N'1TB HDD 5400rpm',
NULL,N'15.6" FHD (1920 x 1080) IPS, Anti-Glare',N'None',N'802.11 AC | 10/100/1000M Gigabit Ethernet | Bluetooth® 4.0',
N'2 x USB 3.0, 1 x USB 2.0, 1 x VGA, 1 x HDMI, LAN, HD Webcam, 2 x Harman Audio Certified Speakers',
N'2.2 kg, Màu: Bạc',N'2Cells, 39WHr',N'Free Dos',17990000 ,17990000,12,N'LAPTOPDESIGN',null,
N'220x200-lenovo ideapad 510 15ikb 80sv00qsvn_lager.png',1,2,6)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(36,N'Lenovo IdeaPad Yoga 910-13IKB (80VF00C2VN)',N'Intel® Core™ i7-7500U 2.7GHz up to 3.5GHz 4MB',
N'Intel® HD Graphics 620',N'8GB DDR4 2133MHz',NULL,
N'512GB SSD M.2 PCIe',N'13.9" UHD (3840 x 2160) IPS, Multi-Touch',N'None',N'802.11 AC (2x2) | Bluetooth® 4.1',
N'2 x USB 3.0, 1 x USB 2.0, 1 x VGA, 1 x HDMI, LAN, HD Webcam, 2 x Harman Audio Certified Speakers',
N'1.38 kg, Màu: Gold',N'4 Cells',N'Windows 10 Home',41990000 ,41990000,12,N'LAPTOPDESIGN',null,
N'220x200-lenovo ideapad yoga 910 13ikb 80vf00c2vn_lager.png',1,2,6)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(37,N'Lenovo Yoga 720-13IKB (80X60084VN)',N'Intel® Core™ i5-7200U 2.5GHz up to 3.1GHz 3MB',
N'Intel® HD Graphics 620',N'8GB DDR4 2133MHz',NULL,
N'256GB SSD M.2 PCIe',N'13.3" FHD (1920 x 1080) IPS + TouchScreen',N'None',N'802.11AC',
N'USB 3.0, USB 3.1, USB Type-C (Thunderbolt), Display Port, 2 x JBL Speakers, Dolby® Audio Premium, Webcam HD 720p, 4-in-1 card reader',
N'1.3 kg, Màu: Đồng',N'4 Cells',N'Windows 10 Home',24990000 ,24990000,12,N'LAPTOPDESIGN',null,
N'220x200-lenovo yoga 720 13ikb 80x60084vn_lager.png',1,2,6)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(38,N'Lenovo Legion Y520-15IKBN (80WK00GCVN)',N'Intel® Core™ i5-7300HQ 2.5GHz up to 3.5GHz 6MB',
N'NVIDIA GeForce® GTX 1050 4GB GDDR5 + Intel Graphics 630',N'8GB DDR4 2400MHz',N'1TB HDD 5400rpm',
N'128GB SSD PCIe Samsung PM961',N'15.6" FHD (1920 x 1080) IPS, Anti-Glare',N'None',N'802.11AC (2x2) | 10/100/1000M Gigabit Ethernet',
N'USB 2.0 USB 3.0 HDMI LAN, HD Webcam, 2 x 2W Harman™ Certified Speakers with Dolby Audio™ Premium',
N'2.4 kg',N'3 Cell',N'Free DOS',20990000 ,19990000,12,N'LAPTOPGAMING',null,
N'220x200-lenovo-legion-y520-15ikbn-80wk00gcvn-8277_lager.png',1,1,6)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(39,N'Lenovo Legion Y520-15IKBN (80WK00GLVN)',N'Intel® Core™ i7-7700HQ 2.8GHz up to 3.8GHz 6MB',
N'NVIDIA GeForce® GTX 1050Ti 4GB GDDR5 + Intel HD Graphics 630',N'8GB DDR4 2400MHz',N'1TB HDD 5400rpm',
N'128GB SSD PCIe PM961',N'15.6" FHD (1920 x 1080) IPS, Anti-Glare',N'None',N'802.11 AC (2x2) | 10/100/1000M Gigabit Ethernet',
N'USB 2.0 USB 3.0 HDMI LAN, HD Webcam, 2 x 2W Harman™ Certified Speakers with Dolby Audio™ Premium',
N'2.4 kg',N'3 Cell',N'Free DOS',26490000 ,26490000,12,N'LAPTOPGAMING',null,
N'220x200-lenovo-legion-y520-15ikbn-80wk00glvn-1914_lager.png',1,1,6)

insert into sanpham(masp,tensp,cpu,vga,ram, hdd, ssd ,manhinh,cd_dvd,ketnoi,tichhop,trongluong,pin,hdh,Giaban,Giakhuyenmai,
BaoHanh,Mota ,Ngayban ,Hinh ,trangthai,Maloai,Mahieu)  
values(40,N'Asus ROG Strix SCAR GL703VD-EE057T',N'Intel® Core™ i7-7700HQ (2.8GHz upto 3.8GHz, 4Cores, 8Threads, 6MB cache, FSB 8GT/s)',
N'NVIDIA GeForce® GTX 1050 4GB GDDR5 + Intel® HD Graphics 630',N'8GB DDR4 2400MHz (1x8GB), 2 slot Ram, Max 32GB',
N'1TB HDD 5400rpm (SSHD 8GB) + 1 slot SSD M2 PCIe3x4',
NULL,N'17.3-inch Full HD (1920x1080) TN panel, 120Hz/5ms, 94% NTSC, 300nits LED',N'None',N'Wi-Fi 802.11 AC (2x2) | Bluetooth V4.1',
N'USB 3.1 Gen1 (Type-C), USB 3.1 Gen1, USB 2.0, mDP 1.2, HDMI 1.4, RJ-45 Jack, 
2-in-1 card reader, 3.5mm headphone and microphone combo jack, Kensington lock',
N'2.9 kg',N'4 Cells 64 Whrs',N'Windows 10 bản quyền',27990000 ,27990000,24,N'LAPTOPGAMING',null,
N'220x200-asus-rog-strix-scar-gl503.png',1,1,1)
go

