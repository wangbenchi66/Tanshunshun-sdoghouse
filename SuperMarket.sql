if exists(select * from sys.databases where name='SuperMarket')
drop database SuperMarket
go
create database SuperMarket
go
use SuperMarket
go

if exists(select * from sys.tables where name='sell')
drop table sell
go

if exists(select * from sys.tables where name='Goods')
drop table Goods
go

if exists(select * from sys.tables where name='GoodsType')
drop table GoodsType
go

if exists(select * from sys.tables where name='employee')
drop table employee
go

if exists(select * from sys.tables where name='role')
drop table role
go

create table role --��ɫ��
(
	RoleId int primary key identity(101,1),
	RoleName nvarchar(200) not null
);

create table employee --Ա����Ϣ
(
   EmpId int primary key identity(201,1), --Ա��id
   EmpName nvarchar(200) not null,--Ա������
   EmpPwd nvarchar(200)  not null,    --Ա������
   RoleId int references role(RoleId) --��ɫ
);

create table GoodsType --��Ʒ���
(
	GoodsTypeId int  primary key identity(1001,1),--�����
	GoodsTypeName nvarchar(200) null,--�������
);

create table Goods --��Ʒ��Ϣ
(
   GoodsId int primary key identity(2001,1), --��Ʒid
   GoodsName nvarchar(200) null,--��Ʒ����
   GoodsTypeId int references GoodsType(GoodsTypeId)  not null,    
   SellPrice money null, --���ۼ۸�
   EnterPrice money null,--�����۸�
   GoodsImg varchar(200) not null,--��ƷͼƬ
);

create table sell --��Ʒ����
(
   SellId int primary key identity(2091211,1),--�������
   GoodsId int references Goods(GoodsId)  not null, --��Ʒid
   SellCount  int null,--��������
   CreateData datetime default(GETDATE()),--����ʱ��
);


insert into role values('�ϰ�')
insert into role values('Ա��')
select * from role


insert into employee values('̷˳˳','123456',102)
insert into employee values('����ï','123456',101)
select * from employee

insert into GoodsType values('����')
insert into GoodsType values('��ʳ')
insert into GoodsType values('����')
select * from GoodsType

insert into Goods values('���¿���',1001,3,2.5)
insert into Goods values('��ʦ�������',1001,3,2)
insert into Goods values('ͳһ����ķ�̲�',1001,4,3)
insert into Goods values('������˹������',1002,1,0.5)
insert into Goods values('��ɫ���˱���',1002,300,219)
insert into Goods values('���򻪷��',1002,120,100)
insert into Goods values('���ϰ�ҩ������',1003,26,25)
insert into Goods values('��˱�',1003,24,20)
insert into Goods values('���±�',1003,30,21)
select * from Goods

insert into sell values(2001,3,default)
insert into sell values(2002,3,default)
insert into sell values(2003,4,default)
insert into sell values(2004,120,default)
insert into sell values(2005,24,default)
select * from sell



select * from role
select * from employee
select * from GoodsType
select * from Goods
select * from sell