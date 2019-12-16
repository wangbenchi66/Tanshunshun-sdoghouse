if exists(select * from sys.databases where name='Market')
drop database Market
go
create database Market
go
use Market
go

if exists(select * from sys.tables where name='provider')
drop table provider
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
   inventory int null, --�������
);

create table sell --��Ʒ����
(
   SellId int primary key identity(2091211,1),--�������
   GoodsId int references Goods(GoodsId)  not null, --��Ʒid
   --GoodsName varchar references Goods(GoodsName) null, --��Ʒ����
   GoodsPrice money null, --��Ʒ�۸�
   SellCount  int null,--��������
   GoodsValue money null, --��Ʒ�ܼ�
   CreateData datetime default(GETDATE()),--����ʱ��
);

create table provider --��Ӧ��
(
   ProviderId int primary key identity(190901,1), --��Ӧ�̱��
   ProviderName nvarchar(200) null,--��Ӧ������
   Phone  nvarchar(200) null,--��Ӧ�̵绰
   GoodsId int references Goods(GoodsId),--��Ʒid
   --GoodsName varchar null,--��Ʒ����
   ProviderPrice money null,--�����۸�
);

insert into role values('����Ա')
insert into role values('��Ӧ��')
insert into role values('���̹���Ա')
select * from role

insert into employee values('������','123456',102)
insert into employee values('����','123456',103)
insert into employee values('̷˳˳','123456',101)
insert into employee values('����ï','123456',101)
select * from employee

insert into GoodsType values('����')
insert into GoodsType values('��ʳ')
insert into GoodsType values('����')
select * from GoodsType

insert into Goods values('���¿���',1001,3,2.5,458)
insert into Goods values('��ʦ�������',1001,3,2,333)
insert into Goods values('ͳһ����ķ�̲�',1001,4,3,108)
insert into Goods values('������˹������',1002,1,0.5,516)
insert into Goods values('��ɫ���˱���',1002,300,219,61)
insert into Goods values('���򻪷��',1002,120,100,86)
insert into Goods values('���ϰ�ҩ������',1003,26,25,102)
insert into Goods values('��˱�',1003,24,20,321)
insert into Goods values('���±�',1003,30,21,40)
select * from Goods

insert into sell values(2001,3,2,6,default)
insert into sell values(2002,3,3,9,default)
insert into sell values(2003,4,1,4,default)
insert into sell values(2006,120,2,240,default)
insert into sell values(2008,24,3,72,default)
select * from sell

insert into provider values('���ڰ��¿����������޹�˾',07525810749,2001,2.5)
insert into provider values('ʥԪ��Ʒ��ɽ�������޹�˾',13011354044,2002,2)
insert into provider values('�ൺ��Դ����ó�����޹�˾',13210230808,2003,3)
insert into provider values('���˽���ó�����޹�˾',057384018610,2004,0.5)
select * from provider

select * from role
select * from employee
select * from GoodsType
select * from Goods
select * from sell
select * from provider