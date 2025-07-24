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

--���ȤG
--�иռg�@�X�֬d�ߡA�d�ߥX�q�ʤ�����b1996�~7��ë��w�e�f���q���uUnited Package�v�����q�椧�q�f���Ӹ�ơA
--�æC�X�q�渹�X�B���~���O�W�١B���~�W�١B���~�q�ʳ���B���~�q�ʼƶq�B���~�����p�p�B�Ȥ�s���B�Ȥ�W�١B���f�H�W�r�B�q�ʤ���B�B�z�q����u���m�W�B�f�B���q�B�����ӦW�ٵ���ƶ��ءA
--�䤤���~�����p�p�ХH�|�ˤ��J�p��ܾ�Ʀ�C


select od.OrderID,c.CategoryName,p.ProductName,od.UnitPrice as ���,
od.Quantity as �ƶq, od.
p.��� as �q��,p.���-od.��� as ���t,od.�ƶq as ��X�ƶq,(p.���-od.���)*od.�ƶq as �`�馩���B,s.������,s.�s���H,s.�s���H¾��
,o.���f�H,o.�q����,cu.���q�W��,e.�m�W,t.�f�B���q�W��

from OrderDetails as od 
inner join Products as p on p.ProductID=od.ProductID
inner join Categories as c on c.CategoryID=p.CategoryID
inner join Suppliers as s on s.SupplierID=p.SupplierID
inner join OrderDetails as o on o.OrderID=od.OrderID
inner join Customers as cu on cu.CustomerID=o.CustomerID
inner join Employees as e on e.EmployeeID=o.EmployeeID
inner join Shippers as t on t.ShipperID=o.ShipVia
where o.OrderDate between '1996-7-1' and '1996-7-31'

select * 
from  Categories as c, Customers as cu,  Employees as e, Orders as o, 
OrderDetails as od, Products as p, Shippers as s,Suppliers as su
where od.OrderID=o.OrderID
and p.ProductID=od.ProductID
and cu.CustomerID=o.CustomerID
and su.SupplierID=p.SupplierID
and e.EmployeeID=o.EmployeeID
and c.CategoryID=p.CategoryID





