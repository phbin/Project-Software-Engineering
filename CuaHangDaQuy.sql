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
	AccType varchar(100) not null, 
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
	Points int, -- điểm tích lũy (nếu kịp)
	stt int
)
go


--Nhà cung cấp
create table INFOPROVIDER
(
	ID varchar(50) primary key,
	NameProd nvarchar(100) not null,
	Addr nvarchar(100) not null,
	Phone varchar(100) not null,
	stt int 
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

create table ORIGINALITEM -- sản phẩm đã nhập không trùng lặp
(
	ID varchar(50) primary key,
	NameItem nvarchar(1000) not null default N'No name', --tên sản phẩm
	IDForm varchar(50) not null,
	IDMaterial varchar(50) not null,
	Quantity int, --tổng số lượng mỗi sản phẩm
	SellQty int, --số lượng đã bán
	Price float, --đơn giá bán ra = PurchasePrice+(PurchasePrice*Profit)
	Descript nvarchar(1000), 
	Picture image,
	constraint FK_ORIGINALITEM_FormCategory foreign key (IDForm) references FormCategory(ID),
	constraint FK_ORIGINALITEM_MaterialCategory foreign key (IDMaterial) references MaterialCategory(ID)
)
go

--Sản phẩm (nhập)
create table IMPORTEDITEMS
(
	ID varchar(50) primary key,
	--NameItem nvarchar(1000) not null default N'No name', --tên sản phẩm
	IDProd varchar(50) not null,
	IDOrgItem varchar(50) not null,
	--IDForm varchar(50) not null,
	--IDMaterial varchar(50) not null,
	--SellQty int,
	Quantity int, --số lượng mỗi sản phẩm nhập
	PurchasePrice float not null default 0, --đơn giá mua vào từng sản phẩm
	--Price float, --đơn giá bán ra = PurchasePrice+(PurchasePrice*Profit)
	Total float, --thành tiền từng sản phẩm=đơn giá mua vào*số lượng
	DatePurchase smalldatetime not null default getdate(), --ngày nhập hàng
	--Descript nvarchar(1000),	
	--Picture image,
	--constraint FK_ImportedItems_FormCategory foreign key (IDForm) references FormCategory(ID),
	constraint FK_ImportedItems_ProviderInfo foreign key (IDProd) references InfoProvider(ID),
	constraint FK_ImportedItems_ORIGINALITEM foreign key (IDOrgItem) references ORIGINALITEM(ID),
	--constraint FK_ImportedItems_MaterialCategory foreign key (IDMaterial) references MaterialCategory(ID)
)
go

select * from ORIGINALITEM
select * from IMPORTEDITEMS


--Phiếu mua hàng
create table ITEMBILLFORM
(
	ID varchar(50) primary key,
	IDProd varchar(50) not null,
	DateBooking smalldatetime not null default getdate(), --ngày lập phiếu
	constraint FK_ItemBillForm_InfoCustomer foreign key (IDProd) references InfoProvider(ID)
)
go

--Danh sách sản phẩm mua vào
create table ITEMBILL
(
	ID varchar(50) primary key,
	IDItemBillForm varchar(50) not null,
	IDItem varchar(50) not null, 
	--Quantity int,
	constraint FK_IDItemBill_ItemBillForm foreign key (IDItemBillForm) references ItemBillForm(ID),
	constraint FK_IDItemBill_IMPORTEDITEMS foreign key (IDItem) references IMPORTEDITEMS(ID)
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
	ID varchar(50) primary key,
	IDItemForm varchar(50) not null,
	IDOrgItem varchar(50) not null, 
	Total float not null, --thành tiền từng sản phẩm = Đơn giá*Số lượng
	Quantity int, --số lượng mỗi sản phẩm
	DateSell smalldatetime not null default getdate(), --ngày bán
	constraint FK_Items_ItemForm foreign key (IDItemForm) references ItemForm(ID),
	constraint FK_Items_ORIGINALITEM foreign key (IDOrgItem) references ORIGINALITEM(ID)
)
go

create table SERVICECATEGORY --loại dịch vụ
(
	ID varchar(50) primary key,
	NameService nvarchar(1000) not null default N'No name',
	Price float not null default 0, --đơn giá dịch vụ
	Stt  int -- 1: hoạt động ; 0:không hoạt động
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
	ID varchar(50) primary key,
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
	--constraint Check_ServiceList check (Prepay >= Total*0.5)
)
go


--Giỏ hàng
create table CARTS
(
	ID varchar(50) primary key,
	IDOrgItem varchar(50) not null,
	Quantity int, --số lượng
	Total float, --thành tiền
	constraint FK_WishList_ORIGINALITEM foreign key (IDOrgItem) references ORIGINALITEM(ID)
)
go


-------------------------FUNCTION/PROCEDURE-----------------------
--thành tiền từng sản phẩm mua vào, đơn giá bán ra
create proc USP_UpdateImportedItems
@id varchar(50)
as
begin
	declare @idOrg varchar(50)	
	declare @purchaseprice float
	declare @profit float
	declare @quantity int
	declare @idmaterial varchar(50)
	select @idOrg = IDOrgItem
	from dbo.IMPORTEDITEMS
	where ID=@id

	select @idmaterial = IDMaterial
	from dbo.ORIGINALITEM
	where ID=@idOrg

	select @purchaseprice = PurchasePrice, @quantity = Quantity
	from dbo.IMPORTEDITEMS
	where ID=@id

	select @profit = Profit
	from dbo.MaterialCategory
	where ID=@idmaterial

	update dbo.ImportedItems set Total=@purchaseprice*@quantity where ID=@id
	update dbo.ORIGINALITEM set Price=@purchaseprice+(@purchaseprice*@profit) where ID=@idOrg
	
end
go

--thành tiền từng sản phẩm bán ra
create proc USP_UpdateItems
@iditemform varchar(50),
@idorg varchar(50)
as
begin
	declare @price float
	declare @quantity int

	select @quantity = Quantity
	from dbo.Items 
	where IDOrgItem=@idorg
	
	select @price = Price
	from dbo.ORIGINALITEM 
	where ID=@idorg

	update dbo.Items set Total=@price*@quantity where IDOrgItem=@idorg  and IDItemForm=@iditemform
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
@idorg varchar(50)
as
begin
	declare @price float

	select @price = Price
	from dbo.ORIGINALITEM
	where ID=@idorg

	update dbo.CARTS set Total=Quantity*@price where IDOrgItem=@idorg
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

select id from MATERIALCATEGORY where NameMaterial='silver'
insert dbo.MaterialCategory values('M01','U01','Gold','0.05')
insert dbo.MaterialCategory values('M02','U02','Silver','0.04')
insert dbo.MaterialCategory values('M03','U02','Pearl','0.08')
insert dbo.MaterialCategory values('M04','U02','Sapphire','0.05')
insert dbo.MaterialCategory values('M05','U01','Platinum ','0.07')
insert dbo.MaterialCategory values('M06','U02','Emerald ','0.05')
insert dbo.MaterialCategory values('M07','U02','Spinel ','0.04')
insert dbo.MaterialCategory values('M08','U03','Diamond','0.1')
go

SELECT *FROM ACCOUNT
insert into InfoStaff values('NV01', N'Huỳnh Thế Vĩ', '23/03/2002', 'Nam', N'Kiên Giang', '0848867679', '20520857@gm.uit.edu.vn', '','1234231', '1')
insert into InfoStaff values('NV02', N'Uyên', '23/03/2002', N'Nữ', N'Đồng Nai', '0848867679', '20520853@gm.uit.edu.vn', '','123123123', '1')
insert into InfoStaff values('NV03', N'Thịnh', '23/03/2002', 'Nam', N'Kiên Giang', '0848867679', '20520857@gm.uit.edu.vn', '','14123123', '1')
insert into InfoStaff values('NV04', N'Bình', '23/03/2002', 'Nam', N'Kiên Giang', '0848867679', '20520857@gm.uit.edu.vn', '','51244131', '1')
insert into InfoStaff values('NV05', N'Tuấn', '23/03/2002', 'Nam', N'Kiên Giang', '0848867679', '20520857@gm.uit.edu.vn', '','125412', '1')

insert into Account values('huynhthevi', 'e10adc3949ba59abbe56e057f20f883e', 'NV01', 'admin')
insert into Account values('neyu', 'e10adc3949ba59abbe56e057f20f883e', 'NV02', 'staff')
insert into Account values('thinh', 'e10adc3949ba59abbe56e057f20f883e', 'NV03', 'staff')

insert into InfoCustomer values('KH01', N'Khách hàng 1', '23/03/2002', '0123912312', 'kh@gm.com', '123123123', '10',1)
insert into InfoCustomer values('KH02', N'Khách hàng 2', '23/03/2002', '0123912312', 'kh@gm.com', '123123133', '0',1)
insert into InfoCustomer values('KH03', N'Khách hàng 3', '23/03/2002', '0123912312', 'kh@gm.com', '123341243', '0',1)

insert into INFOPROVIDER values('NCC1', N'Nhà cung cấp 1', 'SG', '012312312',1)
insert into INFOPROVIDER values('NCC2', N'Nhà cung cấp 2', 'SG', '012312312',1)
insert into INFOPROVIDER values('NCC3', N'Nhà cung cấp 3', 'SG', '012312312',1)
--originalitem
select * from ORIGINALITEM
insert into ORIGINALITEM values('OI1',N'Necklace','F03','M01', 100, 100, '','abc', '')
insert into ORIGINALITEM values('OI2',N'Ring','F03','M01', 100, 100, '','abc', '')
insert into ORIGINALITEM values('OI3',N'Bracelet','F03','M01', 100, 100, '','abc', '')
insert into ORIGINALITEM values('OI4',N'Earrings','F03','M01', 100, 100, '','abc', '')

update ORIGINALITEM set SellQty=45 where ID='OI2'
update ORIGINALITEM set SellQty=50 where ID='OI3'
update ORIGINALITEM set SellQty=10 where ID='OI4'
update ORIGINALITEM set SellQty=1 where ID='OI1'

update CUSSERVICE set DateBooking=GETDATE()-30

select * from ImportedItems
insert into ImportedItems values('SP1', 'NCC1', 'OI1', 100, 200000, '',GETDATE()-20)
insert into ImportedItems values('SP2', 'NCC1', 'OI2', 100,200000, '',GETDATE()-20)
insert into ImportedItems values('SP3', 'NCC2', 'OI3', 100, 200000, '',GETDATE()-20)
insert into ImportedItems values('SP4', 'NCC1', 'OI4', 100, 200000, '',GETDATE()-20)
insert into ImportedItems values('SP5', 'NCC1', 'OI1', 100, 200000, '',GETDATE()-20)
insert into ImportedItems values('SP6', 'NCC1', 'OI2', 100,200000, '', GETDATE()-20)
exec USP_UpdateImportedItems 'SP1'
exec USP_UpdateImportedItems 'SP2'
exec USP_UpdateImportedItems 'SP3'
exec USP_UpdateImportedItems 'SP4'
exec USP_UpdateImportedItems 'SP5'
exec USP_UpdateImportedItems 'SP6'
update ORIGINALITEM set Picture = (select * from openrowset(bulk N'C:\Users\Bin\Desktop\Project-Software-Engineering\QuanLyCuaHangDaQuy\Resources\Image\necklace.png', single_blob) as img) where ID = 'OI1'
update ORIGINALITEM set Picture = (select * from openrowset(bulk N'C:\Users\Bin\Desktop\Project-Software-Engineering\QuanLyCuaHangDaQuy\Resources\Image\ring.png', single_blob) as img) where ID = 'OI2'
update ORIGINALITEM set Picture = (select * from openrowset(bulk N'C:\Users\Bin\Desktop\Project-Software-Engineering\QuanLyCuaHangDaQuy\Resources\Image\bracelet.png', single_blob) as img) where ID = 'OI3'
update ORIGINALITEM set Picture = (select * from openrowset(bulk N'C:\Users\Bin\Desktop\Project-Software-Engineering\QuanLyCuaHangDaQuy\Resources\Image\earrings.png', single_blob) as img) where ID = 'OI4'

update INFOSTAFF set Avatar = (select * from openrowset(bulk N'C:\Users\Bin\Desktop\Project-Software-Engineering\QuanLyCuaHangDaQuy\Resources\Image\avatar.png', single_blob) as img)



select * from ITEMBILLFORM
insert into ITEMBILLFORM values('B01', 'NCC1', '')
insert into ITEMBILLFORM values('B02', 'NCC1', GETDATE()-11)
delete from ITEMBILL where id='IB9'
select * from ITEMBILL
insert into ITEMBILL values('IB1','B01', 'SP1')
insert into ITEMBILL values('IB2','B01', 'SP2')
insert into ITEMBILL values('IB3','B01', 'SP3')
insert into ITEMBILL values('IB4','B01', 'SP4')
insert into ITEMBILL values('IB5','B02', 'SP1')
insert into ITEMBILL values('IB6','B02', 'SP2')
insert into ITEMBILL values('IB7','B02', 'SP3')
insert into ITEMBILL values('IB8','B02', 'SP4')
update ITEMBILLFORM set DateBooking=GETDATE() 

select * from ITEMFORM
insert into ITEMFORM values('B01', 'KH01', 'NV01', '')
insert into ITEMFORM values('B02', 'KH01', 'NV01', '')
insert into ITEMFORM values('B03', 'KH01', 'NV01', '')

select * from Items
insert into Items values('I01','B01', 'OI1', '', 1, '')
insert into Items values('I02','B02', 'OI2', '', 1, '')
insert into Items values('I03', 'B01','OI3', '', 1, '')
insert into Items values('I04','B02', 'OI4', '', 3, '')
update  Items set DateSell=GETDATE()-3
exec USP_UpdateItems 'B01','OI1'
exec USP_UpdateItems 'B02','OI2'
exec USP_UpdateItems 'B01','OI3'
exec USP_UpdateItems 'B02','OI4'

select * from ServiceCategory
insert into ServiceCategory values('SV1', N'Renew', 100000, 1)
insert into ServiceCategory values('SV2', N'Fix', 100000, 1)
insert into ServiceCategory values('SV3', N'Cut', 100000, 0)

select * from CusService
insert into CusService values('CS1', 'KH01', '', 'unfinished')
insert into CusService values('CS2', 'KH02', '', 'unfinished')
insert into CusService values('CS3', 'KH02', '', 'unfinished')

select * from SERVICELIST
insert into SERVICELIST values('S01','CS1', 'SV1', 1, '', 0, '', 50000, '', '', 'unfinish')
insert into SERVICELIST values('S02','CS2', 'SV3', 1, '', 0, '', 50000, '', '', 'unfinish')
insert into SERVICELIST values('S03','CS3', 'SV2', 1, '', 0, '', 50000, '', '', 'unfinish')
insert into SERVICELIST values('S04','CS3', 'SV1', 1, '', 0, '', 50000, '', '', 'unfinish')

exec USP_UpdateServiceList 'CS1','SV1'
exec USP_UpdateServiceList 'CS2','SV3'
exec USP_UpdateServiceList 'CS3','SV2'
exec USP_UpdateServiceList 'CS3','SV1'

select * from CARTS
insert into CARTS values('1','OI1', 1, '')
insert into CARTS values('2','OI2', 2, '')
insert into CARTS values('3','OI3', 5, '')
insert into CARTS values('4','OI4', 1, '')
exec USP_Carts 'OI1'
exec USP_Carts 'OI2'
exec USP_Carts 'OI3'
exec USP_Carts 'OI4'