--���Ȥ@
--�򥻬d��
--�b�i���u�j��ƪ���X�Ҧ��b1993�~(�t)�H���¾����ơC
select * from Employees 
where HireDate >= '1993-1-1'

--�b�i�q��j��ƪ��X�e�f�l���ϸ���44087�P05022��82520����ơC
select * from Orders
where ShipPostalCode in ('44087', '05022', '82520')

--�b�i���~�j��ƪ���X�w�s�q�̦h���e6�W��ưO���C
select top 6 with ties *
from Products
order by  UnitsInStock desc

--�b�i�q��j��ƪ���X�|�����e�f������O����ơC
select * from Orders
where ShippedDate is null

--�b�i�q����ӡj��ƪ���X�q�ʪ����~�ƶq����20~40�󪺸�ưO���C
select * from OrderDetails
where Quantity between 20 and 40

--�έp�d��
--�p��i���~�j��ƪ����O����2�����~��ƥ�������C
select avg (UnitPrice) as �������
from Products
where CategoryID=2

--�b�i���~�j��ƪ���X�w�s�q�p��w���s�q�A�B�|���i����ʪ����~��ưO���C
select * from Products
where UnitsInStock < ReorderLevel and UnitsOnOrder=0

--�b�i�q����ӡj��ƪ��X�q�椤�]�t�W�L5�ز��~����ưO���C
select OrderID, count(*) as ProductID 
from OrderDetails
group by OrderID 
having count(*)>5

--�b�i�q����ӡj��ƪ���ܥX�q�渹�X10263�Ҧ����~������p�p�C
select * ,UnitPrice*Quantity*(1-Discount) as �p�p
from OrderDetails
where OrderID=10263

--�Q�Ρi���~�j��ƪ��ơA�έp�X�C�@�Ө����ӦU���ѤF�X�˲��~�C
select SupplierID, count(*) as �������ӫ~
from Products
group by SupplierID

--�Q�Ρi�q����ӡj��ƪ��ơA�έp�X�U���ӫ~����������P�����P��ƶq�A
--�æC�X�����P��ƶq�j��10����ơA�B�N��ƨ̲��~�s���Ѥp��j�ƧǡC
select ProductID,avg(UnitPrice) as �������,avg(Quantity) as �����P��ƶq
from OrderDetails
group by ProductID
having avg(Quantity) > 10
order by ProductID

-----------------------------------------------------------------------------
--���ȤG
--�иռg�@�X�֬d�ߡA�d�ߥX�q�ʤ�����b1996�~7��ë��w�e�f���q���uUnited Package�v�����q�椧�q�f���Ӹ�ơA
--�æC�X�q�渹�X�B���~���O�W�١B���~�W�١B���~�q�ʳ���B���~�q�ʼƶq�B���~�����p�p�B�Ȥ�s���B�Ȥ�W�١B���f�H�W�r�B�q�ʤ���B�B�z�q����u���m�W�B�f�B���q�B�����ӦW�ٵ���ƶ��ءA
--�䤤���~�����p�p�ХH�|�ˤ��J�p��ܾ�Ʀ�C

select o.OrderID �q�渹�X,c.CategoryID ���~���O,p.ProductName ���~,od.UnitPrice �q�ʳ�� ,od.Quantity �q�ʼƶq ,round(od.UnitPrice*(1-od.Discount)*od.Quantity,0) �p�p,
cu.CustomerID �Ȥ�s��,cu.CompanyName �Ȥ�W��,o.ShipName ���f�H,o.OrderDate �q�ʤ��,e.FirstName+' '+e.LastName as �B�z�q����u,s.CompanyName �f�B���q,su.CompanyName ������
from Shippers as s 
inner join (Categories as c 
inner join (Employees as e 
inner join(Suppliers as su 
inner join (Customers as cu 
inner join (Products as p 
inner join (OrderDetails as od 
inner join Orders as o 
on od.OrderID=o.OrderID) 
on p.ProductID=od.ProductID) 
on cu.CustomerID=o.CustomerID)
on su.SupplierID=p.SupplierID)
on e.EmployeeID=o.EmployeeID)
on c.CategoryID=p.CategoryID)
on s.ShipperID=o.ShipVia
where o.OrderDate between '1996-7-1' and '1996-7-31' and s.CompanyName='United Package'

--�ЧQ��exists�B��l�t�X�l�d�ߦ��A��X���ǫȤ�q���U�L�q��A�æC�X�Ȥ᪺�Ҧ����C
--(���i�Ψ�in�B��A�礣�i�ΦX�֬d�ߦ�) 

select * from Customers as cu 
where not exists 
(select * from Orders as o where cu.CustomerID=o.CustomerID)

--�ЧQ��in�B��l�t�X�l�d�ߦ��A�d�߭��ǭ��u���B�z�L�q��A�æC�X���u�����u�s���B�m�W�B¾�١B�����������X�B�������C
--(���i�Ψ�exists�B��A�礣�i�ΦX�֬d�ߦ�) 

select EmployeeID,FirstName+' '+LastName as EmployeeName,Title,Extension,Notes
from Employees
where EmployeeID in(select distinct EmployeeID from OrderDetails)

--�ЦX�֬d�߻P�l�d�ߨ�ؼg�k�A�C�X1998�~�שҦ��Q�q�ʹL�����~��ơA�æC�X���~���Ҧ����A�B�̲��~�s���Ѥp��j�ƧǡC
--(�g�X�֬d�߮ɤ��o�Υ���l�d�ߦ��A�g�l�d�߮ɤ��o�Υ���X�֬d�ߦ�)

--�X�֬d��(inner join)
select distinct p.*
from Products as p 
inner join OrderDetails	as od on p.ProductID=od.ProductID
inner join Orders as o on od.OrderID=o.OrderID
where o.OrderDate between '1998-01-01'and '1998-12-31'
order by p.ProductID

--�l�d��(in)
select * from Products	
where ProductID in (select ProductID from OrderDetails
where OrderID in (select OrderID from Orders
where OrderDate between '1998-01-01'and '1998-12-31'))

-----------------------------------------------------------------------------
--���ȤT
--�إߤ@�ӦW���iMySchool�j��Ʈw��SQL DDL Script
create database MySchool
go

--�g�X�۹�����SQL DDL Script�A�Ϩ�i��iMySchool�j��Ʈw���إ߳o�Ǹ�ƪ�C
create table[Student](
StuID nchar(10) not null primary key,
StuName nvarchar(20) not null,
Tel nvarchar(20) not null ,
[Address] nvarchar(100),
Birthday datetime not null,
DeptID nchar(1) not null, 
foreign key(DeptID) references [Department](DeptID))--2

create table[Course](
CourseID nchar(5) not null primary key,
CourseName nvarchar(30) not null,
Credit int not null default(0),
[Hour] int not null default(2),
DeptID nchar(1) not null, 
foreign key(DeptID) references [Department](DeptID))--3

create table[SelectionDetail](
StuID nchar(10) not null ,
CourseID nchar(5) not null ,
[Year] int not null default (Year(Getdate())),
Term tinyint  not null,
Score int not null default(0),
primary key (StuID,CourseID),
foreign key(StuID) references [Student](StuID),
foreign key(CourseID) references [Course](CourseID))--4

create table [Department](
DeptID nchar(1) not null primary key,
DeptName nvarchar(30) not null unique)--1

-----------------------------------------------------------------------------
--���ȥ|
create proc InsertDeptmentData

	@DeptID nchar(1),@DeptName nvarchar(30)
as
begin

	declare @d nchar(1)
	declare @dn nvarchar(30)

	select @d=DeptID from [Department]  where DeptID=@DeptID
	select @dn=DeptName from [Department]  where DeptName=@DeptName


	if @d is not null
	begin
		print '��t�N�X[' + @DeptID + '] �w�s�b�A�L�k�s�W�I' 
		return
	end

	if @dn is not null
	begin
		print '��t�W��[' + @DeptName + '] �w�s�b�A�L�k�s�W�I' 
		return
	end

	insert into [Department] (DeptID, DeptName)  
    values  (@DeptID, @DeptName)
    
    print '���\�s�W��t�G�N�X=' + @DeptID + ', �W��=' + @DeptName

end


-----------------------------------------------------------------------------
--���Ȥ�

create function getCourseID(@DeptID nchar(1))
	returns nchar(5)
as
begin

	declare @lastID nchar(5), @newID nchar(5)

	select top 1 @lastID=CourseID
		from [Course]
		where DeptID = @DeptID
		order by CourseID desc

	if @lastID is null
		set @newID=N'C'+ @DeptID + N'001'
	else
	begin

		declare @num nchar(3)=right(N'000'+cast( cast( substring(@lastID, 3,3 ) as int )+1 as nvarchar),3)

		set @newID=N'C'+@DeptID+@num
	end
	return @newID 
end

--����
--insert into [Course] values(dbo.getCourseID('A'),'test9647',2,3,'A')

--����ۦ�ɥR��ȤW�̱`�Ϊ����k --max�Ƨ�
create function getCourseID(@DeptID nchar(1))
returns nchar(5)
as
begin
declare @maxNum int, @newID nchar(5) 
select @maxNum  = max(cast(substring(CourseID,3,3)as int))
from [Course]
where DeptID=@DeptID
	and CourseID like N'C'+@DeptID+N'%'  ---- �p�G @DeptID = 'A'�A�|���GCA001, CA002, CABC, CA999999 ���Ҧ��H 'CA' �}�Y���r��(�ҽk�d��)
	and len(CourseID) =5 --len�p��r����ס]���]�t���ݪŮ�^�A�T�O CourseID ���n�O5�Ӧr��
	and isnumeric(substring(CourseID,3,3))=1 --isnumeric()�ˬd�r��O�_�����ļƦr�A

	if @maxNum is null 
	set @newID=N'C'+@DeptID+N'001'
	else
	set @newID=N'C'+@DeptID+format(@maxNum+1,'D3')

	return @newID
end














