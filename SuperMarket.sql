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
insert into GoodsType values('�̾�')
insert into GoodsType values('����')
insert into GoodsType values('�칫')
select * from GoodsType

insert into Goods values('���¿���',1001,3,2,'~/images/Food/kele.jpg')
insert into Goods values('θ����',1001,6,5,'~/images/Food/weidongli.jpg')
insert into Goods values('ͳһ����ķ�̲�',1001,4,3,'~/images/Food/asamu.jpg')
insert into Goods values('����',1001,5,4,'~/images/Food/maidong.jpg')
insert into Goods values('��ţ',1001,6,5,'~/images/Food/redbull.jpg')

insert into Goods values('������˹������',1002,1,0.5,'~/images/Food/aerbeisi.jpg')
insert into Goods values('��ܽ����װ��',1002,300,219,'~/images/Food/defu3.jpg')
insert into Goods values('��ܽ����װ��',1002,120,100,'~/images/Food/defu1.jpg')
insert into Goods values('�ְ�',1002,2,1,'~/images/Food/leba2.jpg')
insert into Goods values('���',1002,8,6,'~/images/Food/mianbao1.jpg')
insert into Goods values('��˾',1002,25,18,'~/images/Food/miaobao2.jpg')
insert into Goods values('������',1002,10,7,'~/images/Food/aoliao.jpg')

insert into Goods values('�綯��ˢ',1003,199,150,'~/images/Food/yashua.jpg')
insert into Goods values('ϴ�ֻ�',1003,300,235,'~/images/Food/xishouji.jpg')
insert into Goods values('����',1003,30,21,'~/images/Food/yagao.jpg')
insert into Goods values('���뵶',1003,199,170,'~/images/Food/guhudao.jpg')

insert into Goods values('��Ⱥ',1004,14,13,'~/images/Food/liqun.jpg')
insert into Goods values('�л�',1004,60,58,'~/images/Food/zhonghua.jpg')
insert into Goods values('��·',1004,20,18,'~/images/Food/wanbaolu.jpg')
insert into Goods values('��֮��',1004,248,200,'~/images/Food/tian.jpg')
insert into Goods values('��֮��',1004,258,200,'~/images/Food/hai.jpg')
insert into Goods values('��֮��',1004,480,300,'~/images/Food/meng.jpg')

insert into Goods values('��',1005,2,1,'~/images/Food/yan.jpg')
insert into Goods values('ʮ����',1005,2,1,'~/images/Food/shisanxiang.jpg')
insert into Goods values('��',1005,10,5,'~/images/Food/cu.jpg')
insert into Goods values('ζ��',1005,2,1,'~/images/Food/weijing.jpg')
insert into Goods values('����',1005,12,10,'~/images/Food/xiangyou.jpg')
insert into Goods values('֥�齴',1005,6,5,'~/images/Food/zhimajiang.jpg')

insert into Goods values('С�׾���д���Ա�10֧װ',1006,9.99,9,'~/images/Food/bi1.jpg')
insert into Goods values('С�����Ա� 10֧װ ',1006,24.9,20,'~/images/Food/bi2.jpg')
insert into Goods values('�׼ҽ���ǩ�ֱ� ',1006,24.9,20,'~/images/Food/bi3.jpg')
insert into Goods values('С�׼��±�',1006,9.9,9,'~/images/Food/ben1.jpg')
insert into Goods values('С���׼�Һ��С�ڰ�',1006,99,90,'~/images/Food/ben2.jpg')
select * from Goods

insert into sell values(2001,3,default)
insert into sell values(2002,3,default)
insert into sell values(2003,4,default)
insert into sell values(2004,120,default)
insert into sell values(2005,24,default)

insert into sell values(2006,5,default)
insert into sell values(2007,88,default)
insert into sell values(2008,99,default)
insert into sell values(2009,5,default)
insert into sell values(2010,457,default)
insert into sell values(2011,45,default)
insert into sell values(2012,5,default)
insert into sell values(2013,4,default)
insert into sell values(2014,2,default)
insert into sell values(2015,85,default)
insert into sell values(2016,54,default)
insert into sell values(2017,50,default)
insert into sell values(2018,5,default)
select * from sell



select * from role
select * from employee
select * from GoodsType
select * from Goods
select * from sell