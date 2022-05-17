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
	constraint FK_IDItemBill_ItemBillForm foreign key (IDItemBillForm) references ItemBillForm(ID),
	constraint FK_IDItemBill_ImportedItems foreign key (IDItem) references ImportedItems(ID),
	constraint PK_IDItemBill primary key(IDItemBillForm,IDItem)
)
go

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
@iditemform varchar(50),
@iditem varchar(50)
as
begin
	declare @price float
	declare @quantity int

	select @quantity = Quantity
	from dbo.Items 
	where IDItem=@iditem
	
	select @price = Price
	from dbo.ImportedItems 
	where ID=@iditem

	update dbo.Items set Total=@price*@quantity where IDItem=@iditem  and IDItemForm=@iditemform
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
	update dbo.ServiceList set Remain=Total-Prepay where IDCusService=@idcusservice and IDService=@idservice

end
go
--tổng tiền sản phẩm trong giỏ hàng
create proc USP_Carts
@iditem varchar(50)
as
begin
	declare @price float

	select @price = Price
	from dbo.IMPORTEDITEMS
	where ID=@iditem

	update dbo.CARTS set Total=Quantity*@price where IDItem=@iditem
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

insert into InfoStaff values('NV01', 'Huỳnh Thế Vĩ', '23/03/2002', 'Nam', 'Kiên Giang', '0848867679', '20520857@gm.uit.edu.vn', '','1234231', '1')
insert into InfoStaff values('NV02', 'Uyên', '23/03/2002', 'Nữ', 'Kiên Giang', '0848867679', '20520857@gm.uit.edu.vn', '','123123123', '1')
insert into InfoStaff values('NV03', 'Thịnh', '23/03/2002', 'Nam', 'Kiên Giang', '0848867679', '20520857@gm.uit.edu.vn', '','14123123', '1')
insert into InfoStaff values('NV04', 'Bình', '23/03/2002', 'Nam', 'Kiên Giang', '0848867679', '20520857@gm.uit.edu.vn', '','51244131', '1')
insert into InfoStaff values('NV05', 'Tuấn', '23/03/2002', 'Nam', 'Kiên Giang', '0848867679', '20520857@gm.uit.edu.vn', '','125412', '1')

insert into Account values('huynhthevi', '123456', 'NV01', '1')
insert into Account values('neyu', '123456', 'NV02', '0')
insert into Account values('thinh', '123456', 'NV03', '0')

insert into InfoCustomer values('KH01', 'Khách hàng 1', '23/03/2002', '0123912312', 'kh@gm.com', '123123123', '10')
insert into InfoCustomer values('KH02', 'Khách hàng 2', '23/03/2002', '0123912312', 'kh@gm.com', '123123133', '0')
insert into InfoCustomer values('KH03', 'Khách hàng 3', '23/03/2002', '0123912312', 'kh@gm.com', '123341243', '0')

insert into INFOPROVIDER values('NCC1', 'Nhà cung cấp 1', 'SG', '012312312')
insert into INFOPROVIDER values('NCC2', 'Nhà cung cấp 2', 'SG', '012312312')
insert into INFOPROVIDER values('NCC3', 'Nhà cung cấp 3', 'SG', '012312312')

select * from ImportedItems
insert into ImportedItems values('SP1', N'Necklace', 'NCC1', 'F01', 'M01', 100, 200000, '', '', '', 'abc', '')
insert into ImportedItems values('SP2', N'Ring', 'NCC1', 'F01', 'M01', 100, 200000, '', '', '', 'abc', '')
insert into ImportedItems values('SP3', N'Bracelet', 'NCC2', 'F01', 'M01', 100, 200000, '', '', '', 'abc', '')
insert into ImportedItems values('SP4', N'Earrings', 'NCC1', 'F01', 'M01', 100, 200000, '', '', '', 'abc', '')
exec USP_UpdateImportedItems 'SP1'
exec USP_UpdateImportedItems 'SP2'
exec USP_UpdateImportedItems 'SP3'
exec USP_UpdateImportedItems 'SP4'

select * from ITEMBILLFORM
insert into ITEMBILLFORM values('B01', 'NCC1', '')

select * from ITEMBILL
insert into ITEMBILL values('B01', 'SP1')
insert into ITEMBILL values('B01', 'SP2')
insert into ITEMBILL values('B01', 'SP3')
insert into ITEMBILL values('B01', 'SP4')


select * from ITEMFORM
insert into ITEMFORM values('B01', 'KH01', 'NV01', '')
insert into ITEMFORM values('B02', 'KH01', 'NV01', '')
insert into ITEMFORM values('B03', 'KH01', 'NV01', '')

select * from Items
insert into Items values('B01', 'SP1', '', 1, '')
insert into Items values('B01', 'SP2', '', 1, '')
insert into Items values('B01', 'SP3', '', 1, '')
insert into Items values('B02', 'SP1', '', 3, '')

exec USP_UpdateItems 'B01','SP1'
exec USP_UpdateItems 'B01','SP2'
exec USP_UpdateItems 'B01','SP3'
exec USP_UpdateItems 'B02','SP1'

select * from ServiceCategory
insert into ServiceCategory values('SV1', 'Đanh bong', 100000)
insert into ServiceCategory values('SV2', 'Sua', 100000)
insert into ServiceCategory values('SV3', 'Cat', 100000)

select * from CusService
insert into CusService values('CS1', 'KH01', '', 'unfinish')
insert into CusService values('CS2', 'KH02', '', 'unfinish')
insert into CusService values('CS3', 'KH02', '', 'unfinish')

select * from SERVICELIST
insert into SERVICELIST values('CS1', 'SV1', 1, '', 0, '', 50000, '', '', 'unfinish')
insert into SERVICELIST values('CS2', 'SV3', 1, '', 0, '', 50000, '', '', 'unfinish')
insert into SERVICELIST values('CS3', 'SV2', 1, '', 0, '', 50000, '', '', 'unfinish')
insert into SERVICELIST values('CS3', 'SV1', 1, '', 0, '', 50000, '', '', 'unfinish')

exec USP_UpdateServiceList 'CS1','SV1'
exec USP_UpdateServiceList 'CS2','SV3'
exec USP_UpdateServiceList 'CS3','SV2'
exec USP_UpdateServiceList 'CS3','SV1'

select * from CARTS
insert into CARTS values('SP1', 1, '')
insert into CARTS values('SP2', 2, '')
insert into CARTS values('SP3', 5, '')
insert into CARTS values('SP4', 1, '')
exec USP_Carts 'SP1'
exec USP_Carts 'SP2'
exec USP_Carts 'SP3'
exec USP_Carts 'SP4'