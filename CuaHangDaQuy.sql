﻿create database CuaHangDaQuy
go

use CuaHangDaQuy
go

--drop database CuaHangDaQuy
--go

set dateformat DMY
go

create table InfoStaff  -- Nhân viên
(
	ID varchar(50) primary key,
	FullName nvarchar(100) not null,
	DoB smalldatetime not null,
	Sex nvarchar(10) not null,
	Addr nvarchar(100),
	Phone varchar(100),
	Email nvarchar(100),
	Avatar image,
	IDPersonal int not null unique, --cmnd/cccd
	stt int default 1 --1: đang làm||0: nghỉ việc
)
go

create table Account  -- Tài khoản
(
	UserName varchar(100) primary key,
	Pass nvarchar(1000) not null default 1,
	ID varchar(50) not null ,
	AccType int not null default 0, --1: admin, 0: staff
	constraint FK_Account_ID foreign key (ID) references dbo.InfoStaff(ID)
)
go

create table FormCategory --hình thức: dây chuyền, vòng tay, nhẫn...
(
	ID varchar(50) primary key,
	NameForm varchar(100) not null default N'No name'
)
go

create table MaterialCategory --chất liệu: vàng, bạc, đá quý, ngọc trai
(
	ID varchar(50) primary key,
	NameMaterial varchar(100) not null default N'No name'
)
go

--Nhà cung cấp
create table ProviderInfo
(
	ID varchar(50) primary key,
	NameProd nvarchar(100) not null,
	Addr nvarchar(100) not null,
	Phone varchar(100) not null,
)
go

--Đơn vị tính: ounce, gram, carat
create table Unit
(
	ID varchar(50) primary key,
	NameUnit nvarchar(100) not null,
)
go

--Hàng nhập
create table ImportedItems
(
	ID varchar(50) primary key,
	NameItem nvarchar(1000) not null default N'No name', --tên sản phẩm
	Size int not null,
	IDProd varchar(50) not null,
	IDUnit varchar(50) not null,
	IDMaterial varchar(50) not null,
	Quantity int, --số lượng mỗi sản phẩm
	PurchasePrice float not null default 0, --đơn giá mua vào từng sản phẩm
	Total float, --thành tiền từng sản phẩm
	DatePurchase smalldatetime not null default getdate(), --ngày nhập hàng
	Descript nvarchar(1000), 
	Picture image,
	constraint FK_ImportedItems_ProviderInfo foreign key (IDProd) references ProviderInfo(ID),
	constraint FK_ImportedItems_Unit foreign key (IDUnit) references Unit(ID),
	constraint FK_ImportedItems_MaterialCategory foreign key (IDMaterial) references MaterialCategory(ID)
)
go

--Size
create table ItemSize
(
	ID varchar(50) primary key,
	IDItem varchar(50) not null,
	SizeName varchar(50) not null,
	constraint FK_ItemSize_ImportedItems foreign key (IDItem) references ImportedItems(ID),
)

--Hàng bán
create table Items
(
	ID varchar(50) primary key,
	IDItem varchar(50),
	IDForm varchar(50) not null,
	IDMaterial varchar(50) not null,
	Profit float default 0.01,
	Price float, --đơn giá bán ra = PurchasePrice+(PurchasePrice*Profit)
	Total float not null, --thành tiền từng sản phẩm
	Quantity int, --số lượng
	DateSell smalldatetime not null default getdate(), --ngày bán
	constraint FK_Item_FormCategory foreign key (IDForm) references FormCategory(ID),
	constraint FK_Item_MaterialCategory foreign key (IDMaterial) references MaterialCategory(ID),
	constraint FK_Item_ImportedItems foreign key (IDItem) references ImportedItems(ID)
)
go

create table ServiceCategory --loại dịch vụ
(
	ID varchar(50) primary key,
	NameService nvarchar(1000) not null default N'No name',
)
go

--Phiếu dịch vụ
create table CusService
(
	ID varchar(50) primary key,
	NameCus nvarchar(100) not null,
	Phone varchar(100),
	Quantity int, --số lượng mỗi dịch vụ 
	Total float, --thành tiền từng dịch vụ: Total=Quantity*Price
	Costs float default 0, --chi phí phát sinh
	Prepay float not null, --trả trước từng dịch vụ: Prepay>=Total*0.5
	Remain float not null, --tiền còn lại từng dịch vụ
	DateBooking smalldatetime not null default getdate(), --ngày lập phiếu
	DateReturn smalldatetime not null, --ngày giao
	Price float not null default 0, --đơn giá dịch vụ
	PriceDiscounted float, --đơn giá được tính=Price+Costs
	Stt varchar not null --tình trạng (xong hoặc chưa)
	constraint FK_CusService_ServiceCategory foreign key (ID) references ServiceCategory(ID)
)
go

create table InfoCustomer  -- Khách hàng
(
	ID varchar(50) primary key,
	IDItem varchar(50),
	IDService varchar(50),
	FullName nvarchar(100) not null,
	DoB smalldatetime not null,
	Phone varchar(100),
	Email nvarchar(100),
	IDPersonal bigint not null unique, --cmnd/cccd
	Points int -- điểm tích lũy (nếu kịp)
	constraint FK_InfoCustomer_Items foreign key (IDItem) references Items(ID),
	constraint FK_InfoCustomer_CusService foreign key (IDService) references CusService(ID)

)
go

--Giỏ hàng
create table WishList
(
	ID varchar(50) primary key,
	IDItem varchar(50) not null,
	Quantity int, --số lượng
	Total float, --thành tiền
	constraint FK_WishList_ImportedItems foreign key (IDItem) references ImportedItems(ID)
)
go

-------------------------FUNCTION/PROCEDURE-----------------------
--thành tiền từng sản phẩm mua vào
create proc USP_UpdateImportedItems
@id varchar(50)
as
begin
	declare @purchaseprice float
	declare @quantity int

	select @quantity = II.Quantity, @purchaseprice = II.PurchasePrice 
	from dbo.ImportedItems II
	where ID=@id
	
	update dbo.ImportedItems set Total=@purchaseprice*@quantity where ID=@id
end
go

--đơn giá bán ra, thành tiền từng sản phẩm bán ra
create proc USP_UpdateItems
@id varchar(50)
as
begin
	declare @purchaseprice float
	declare @profit float
	declare @quantity int

	select @purchaseprice = PurchasePrice
	from dbo.ImportedItems
	where ID=@id

	select @profit = Profit, @quantity = Quantity
	from dbo.Items
	where IDItem=@id
	
	update dbo.Items set Price=@purchaseprice+(@purchaseprice*@profit) where IDItem=@id
	update dbo.Items set Total=Price*@quantity where IDItem=@id
end
go

--đơn giá được tính và thành tiền dịch vụ
create proc USP_UpdateCusService
@id varchar(50)
as
begin
	declare @price float
	declare @costs float
	declare @quantity int

	select @price = Price, @costs = Costs, @quantity = Quantity
	from dbo.CusService
	where ID=@id
	
	update dbo.CusService set PriceDiscounted=@price+@costs where ID=@id
	update dbo.CusService set Total=PriceDiscounted*@quantity where ID=@id
end
go

------------------------INSERT--------------------------
insert dbo.FormCategory values('F01','Necklace')
insert dbo.FormCategory values('F02','Bracelet')
insert dbo.FormCategory values('F03','Ring')
insert dbo.FormCategory values('F04','Watch')
insert dbo.FormCategory values('F05','Earrings')
insert dbo.FormCategory values('F06','Pendant')
insert dbo.FormCategory values('F07','Gemstone')
insert dbo.FormCategory values('F08','Charm')
go

insert dbo.Unit values('U01','ounce')
insert dbo.Unit values('U02','gram')
insert dbo.Unit values('U03','carat')
go

insert dbo.MaterialCategory values('M01','Gold')
insert dbo.MaterialCategory values('M02','Silver')
insert dbo.MaterialCategory values('M03','Pearl')
insert dbo.MaterialCategory values('M04','Sapphire')
insert dbo.MaterialCategory values('M05','Ruby')
insert dbo.MaterialCategory values('M06','Emerald ')
insert dbo.MaterialCategory values('M07','Spinel ')
insert dbo.MaterialCategory values('M08','Platinum ')
insert dbo.MaterialCategory values('M09','Diamond ')
go

insert dbo.ProviderInfo values('P01','PNJ','Bến Tre','0359086355')
insert dbo.ProviderInfo values('P02','DOJI','Kiên Giang','0359086356')
insert dbo.ProviderInfo values('P03','SJC','Đồng Nai','0359086357')
insert dbo.ProviderInfo values('P04','SBJ','Kontum','0359086358')
insert dbo.ProviderInfo values('P05','PNJ','Hồ Chí Minh','0359086359')
insert dbo.ProviderInfo values('P06','MINH CHÂU','Tiền Giang','0359086360')
insert dbo.ProviderInfo values('P07','JEWELRY','Sóc Trăng','0359086361')
insert dbo.ProviderInfo values('P08','SKYMOND LUXURY','Quảng Nam','0359086362')
insert dbo.ProviderInfo values('P09','PANDORA','Hà Nội','0359086363')
go

insert dbo.ImportedItems values('I01','Dây chuyền','1','P01','U01','M01','10','1000000','','28/03/2022','dây chuyền hột soàn lấp la lấp lánh','')
insert dbo.ImportedItems values('I02','Nhẫn','2','P02','U02','M02','10','900000','','28/03/2022','nhẫn uyên ương','')
insert dbo.ImportedItems values('I03','Vòng tay','3','P03','U03','M03','10','850000','','28/03/2022','vòng tay hoa lá','')
insert dbo.ImportedItems values('I04','Bông tai','2','P04','U02','M04','10','700000','','28/03/2022','bông tai hột soàn','')
insert dbo.ImportedItems values('I05','Đồng hồ','1','P05','U01','M05','10','1000000','','28/03/2022','đồng hồ thời trang','')
insert dbo.ImportedItems values('I06','Lắc tay','1','P06','U01','M06','10','500000','','28/03/2022','lắc tay nhỏ','')
insert dbo.ImportedItems values('I07','Kiềng','2','P07','U02','M07','10','700000','','28/03/2022','kiềng cưới','')
go
select * from dbo.ImportedItems;

exec USP_UpdateImportedItems 'I01'
exec USP_UpdateImportedItems 'I02'
exec USP_UpdateImportedItems 'I03'
exec USP_UpdateImportedItems 'I04'
exec USP_UpdateImportedItems 'I05'
exec USP_UpdateImportedItems 'I06'
exec USP_UpdateImportedItems 'I07'