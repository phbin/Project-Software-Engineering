--create database CuaHangDaQuy
--go

use CuaHangDaQuy
go

--drop database CuaHangDaQuy
--go

set dateformat DMY
go

create table INFOSTAFF  -- Nhân viên
(
	ID varchar(50) primary key,
	FullName nvarchar(100) not null,
	DoB smalldatetime not null,
	Sex nvarchar(10) not null,
	Addr nvarchar(100),
	Phone varchar(100) not null,
	Email nvarchar(100) not null,
	Avatar image,
	IDPersonal bigint not null unique, --cmnd/cccd
	stt int default 1 --1: đang làm||0: nghỉ việc
)
go

create table ACCOUNT  -- Tài khoản
(
	UserName varchar(100) primary key,
	Pass nvarchar(1000) not null default 1,
	ID varchar(50) not null ,
	AccType int not null default 0, --1: admin, 0: staff
	constraint FK_Account_ID foreign key (ID) references dbo.INFOSTAFF(ID)
)
go

create table INFOCUSTOMER  -- Khách hàng
(
	ID varchar(50) primary key,
	FullName nvarchar(100) not null,
	DoB smalldatetime not null,
	Phone varchar(100),
	Email nvarchar(100),
	IDPersonal bigint not null unique, --cmnd/cccd
	Points int -- điểm tích lũy (nếu kịp)
)
go

--Nhà cung cấp
create table INFOPROVIDER
(
	ID varchar(50) primary key,
	NameProd nvarchar(100) not null,
	Addr nvarchar(100) not null,
	Phone varchar(100) not null,
)
go

--Đơn vị tính: ounce, gram, carat
create table UNIT
(
	ID varchar(50) primary key,
	NameUnit nvarchar(100) not null,
)
go

create table FORMCATEGORY --hình thức: dây chuyền, vòng tay, nhẫn...
(
	ID varchar(50) primary key,
	NameForm varchar(100) not null default N'No name'
)
go

create table MATERIALCATEGORY --chất liệu (loại sản phẩm): vàng, bạc, đá quý, ngọc trai
(
	ID varchar(50) primary key,
	IDUnit varchar(50) not null,
	NameMaterial varchar(100) not null default N'No name',
	Profit float default 0.01, --lợi nhuận
	constraint FK_MaterialCategory_Unit foreign key (IDUnit) references Unit(ID)
)
go

--Sản phẩm (nhập)
create table IMPORTEDITEMS
(
	ID varchar(50) primary key,
	NameItem nvarchar(1000) not null default N'No name', --tên sản phẩm
	Size int not null,
	IDProd varchar(50) not null,
	IDForm varchar(50) not null,
	IDMaterial varchar(50) not null,
	Quantity int, --số lượng mỗi sản phẩm
	PurchasePrice float not null default 0, --đơn giá mua vào từng sản phẩm
	Price float, --đơn giá bán ra = PurchasePrice+(PurchasePrice*Profit)
	Total float, --thành tiền từng sản phẩm=đơn giá mua vào*số lượng
	DatePurchase smalldatetime not null default getdate(), --ngày nhập hàng
	Descript nvarchar(1000), 
	Picture image,
	constraint FK_ImportedItems_FormCategory foreign key (IDForm) references FormCategory(ID),
	constraint FK_ImportedItems_ProviderInfo foreign key (IDProd) references InfoProvider(ID),
	constraint FK_ImportedItems_MaterialCategory foreign key (IDMaterial) references MaterialCategory(ID)
)
go

--Phiếu mua hàng
create table ITEMBILLFORM
(
	ID varchar(50) primary key,
	IDProd varchar(50) not null,
	DateBooking smalldatetime not null default getdate(), --ngày lập phiếu
	constraint FK_ItemBillForm_InfoCustomer foreign key (IDProd) references InfoProvider(ID),
)
go

--Danh sách sản phẩm mua vào
create table ITEMBILL
(
	IDItemBillForm varchar(50) not null,
	IDItem varchar(50) not null, 
	Total float not null, --thành tiền từng sản phẩm = Đơn giá*Số lượng
	Quantity int, --số lượng mỗi sản phẩm
	DateBought smalldatetime not null default getdate(), --ngày mua
	constraint FK_IDItemBillForm_ItemBillForm foreign key (IDItemBillForm) references ItemBillForm(ID),
	constraint FK_IDItemBillForm_ImportedItems foreign key (IDItem) references ImportedItems(ID),
	constraint PK_IDItemBillForm primary key(IDItemBillForm,IDItem)
)
go

--Size
create table ITEMSIZE
(
	IDItem varchar(50) not null,
	SizeName varchar(50) not null,
	constraint FK_ItemSize_ImportedItems foreign key (IDItem) references ImportedItems(ID),
)

--Phiếu bán hàng
create table ITEMFORM
(
	ID varchar(50) primary key,
	IDCustomer varchar(50) not null,
	IDStaff varchar(50) not null,
	DateBooking smalldatetime not null default getdate(), --ngày lập phiếu
	constraint FK_ITEMFORM_InfoCustomer foreign key (IDCustomer) references InfoCustomer(ID),
	constraint FK_ITEMFORM_InfoStaff foreign key (IDStaff) references InfoStaff(ID)
)
go

--Danh sách sản phẩm mỗi khách hàng mua
create table ITEMS
(
	IDItemForm varchar(50) not null,
	IDItem varchar(50) not null, 
	Total float not null, --thành tiền từng sản phẩm = Đơn giá*Số lượng
	Quantity int, --số lượng mỗi sản phẩm
	DateSell smalldatetime not null default getdate(), --ngày bán
	constraint FK_Items_ItemForm foreign key (IDItemForm) references ItemForm(ID),
	constraint FK_Items_ImportedItems foreign key (IDItem) references ImportedItems(ID),
	constraint PK_Items primary key(IDItemForm,IDItem)
)
go

create table SERVICECATEGORY --loại dịch vụ
(
	ID varchar(50) primary key,
	NameService nvarchar(1000) not null default N'No name',
	Price float not null default 0, --đơn giá dịch vụ
)
go

--Phiếu dịch vụ
create table CUSSERVICE
(
	ID varchar(50) primary key,
	IDCustomer varchar(50) not null,
	DateBooking smalldatetime not null default getdate(), --ngày lập phiếu
	Stt varchar(50) not null --tình trạng (hoàn thành hoặc chưa hoàn thành)
	constraint FK_CusService_InfoCustomer foreign key (IDCustomer) references InfoCustomer(ID)
)
go

create table SERVICELIST --danh sách dịch vụ của mỗi khách hàng
(
	IDCusService varchar(50) not null, --ID phiếu dịch vụ
	IDService varchar(50) not null, --ID loại dịch vụ
	Quantity int, --số lượng mỗi dịch vụ được chọn ở trên
	Costs float default 0, --chi phí phát sinh
	PriceDiscounted float, --đơn giá được tính=Price+Costs
	Total float, --thành tiền từng dịch vụ: Total=Quantity*Price
	Prepay float, --trả trước từng dịch vụ: Prepay>=Total*0.5
	Remain float, --tiền còn lại từng dịch vụ
	DateReturn smalldatetime not null, --ngày giao
	Stt nvarchar(50) not null --tình trạng (đã giao hoặc chưa giao)
	constraint FK_ServiceList_ServiceCategory foreign key (IDService) references ServiceCategory(ID),
	constraint FK_ServiceList_CusService foreign key (IDCusService) references CusService(ID),
	constraint PK_ServiceList primary key(IDCusService,IDService),
	--constraint Check_ServiceList check (Prepay >= Total*0.5)
)
go

--Giỏ hàng
create table CARTS
(
	ID varchar(50) primary key,
	IDItem varchar(50) not null,
	Quantity int, --số lượng
	Total float, --thành tiền
	constraint FK_WishList_ImportedItems foreign key (IDItem) references ImportedItems(ID)
)
go

-------------------------FUNCTION/PROCEDURE-----------------------
--thành tiền từng sản phẩm mua vào, đơn giá bán ra
create proc USP_UpdateImportedItems
@id varchar(50)
as
begin
	declare @purchaseprice float
	declare @profit float
	declare @quantity int
	declare @idmaterial varchar(50)

	select @idmaterial = IDMaterial, @purchaseprice = PurchasePrice, @quantity = Quantity
	from dbo.ImportedItems
	where ID=@id

	select @profit = Profit
	from dbo.MaterialCategory
	where ID=@idmaterial

	update dbo.ImportedItems set Total=@purchaseprice*@quantity where ID=@id
	update dbo.ImportedItems set Price=@purchaseprice+(@purchaseprice*@profit) where ID=@id
end
go

--thành tiền từng sản phẩm bán ra
create proc USP_UpdateItems
@id varchar(50)
as
begin
	declare @price float
	declare @quantity int

	select @quantity = Quantity
	from dbo.Items 
	where IDItem=@id
	
	select @price = Price
	from dbo.ImportedItems 
	where ID=@id

	update dbo.Items set Total=@price*@quantity where IDItem=@id
end
go

--đơn giá được tính và thành tiền dịch vụ
create proc USP_UpdateServiceList
@idcusservice varchar(50), @idservice varchar(50)
as
begin
	declare @price float
	declare @costs float
	declare @quantity int


	select @price = Price
	from dbo.ServiceCategory
	where ID=@idservice

	select @costs = Costs, @quantity = Quantity
	from dbo.ServiceList
	where IDCusService=@idcusservice and IDService=@idservice

	
	update dbo.ServiceList set PriceDiscounted=@price+@costs where IDCusService=@idcusservice and IDService=@idservice
	update dbo.ServiceList set Total=PriceDiscounted*@quantity where IDCusService=@idcusservice and IDService=@idservice
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

insert dbo.MaterialCategory values('M01','U01','Gold','0.05')
insert dbo.MaterialCategory values('M02','U02','Silver','0.04')
insert dbo.MaterialCategory values('M03','U02','Pearl','0.08')
insert dbo.MaterialCategory values('M04','U02','Sapphire','0.05')
insert dbo.MaterialCategory values('M05','U01','Platinum ','0.07')
insert dbo.MaterialCategory values('M06','U02','Emerald ','0.05')
insert dbo.MaterialCategory values('M07','U02','Spinel ','0.04')
insert dbo.MaterialCategory values('M08','U03','Diamond','0.1')
go

/*
insert dbo.INFOCUSTOMER values('P01','PNJ','Bến Tre','0359086355')
insert dbo.INFOCUSTOMER values('P02','DOJI','Kiên Giang','0359086356')
insert dbo.INFOCUSTOMER values('P03','SJC','Đồng Nai','0359086357')
insert dbo.INFOCUSTOMER values('P04','SBJ','Kontum','0359086358')
insert dbo.INFOCUSTOMER values('P05','PNJ','Hồ Chí Minh','0359086359')
insert dbo.INFOCUSTOMER values('P06','MINH CHÂU','Tiền Giang','0359086360')
insert dbo.INFOCUSTOMER values('P07','JEWELRY','Sóc Trăng','0359086361')
insert dbo.INFOCUSTOMER values('P08','SKYMOND LUXURY','Quảng Nam','0359086362')
insert dbo.INFOCUSTOMER values('P09','PANDORA','Hà Nội','0359086363')
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
exec USP_UpdateImportedItems 'I07'*/