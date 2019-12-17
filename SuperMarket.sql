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

create table role --角色表
(
	RoleId int primary key identity(101,1),
	RoleName nvarchar(200) not null
);

create table employee --员工信息
(
   EmpId int primary key identity(201,1), --员工id
   EmpName nvarchar(200) not null,--员工姓名
   EmpPwd nvarchar(200)  not null,    --员工密码
   RoleId int references role(RoleId) --角色
);

create table GoodsType --商品类别
(
	GoodsTypeId int  primary key identity(1001,1),--类别编号
	GoodsTypeName nvarchar(200) null,--类别名称
);

create table Goods --商品信息
(
   GoodsId int primary key identity(2001,1), --商品id
   GoodsName nvarchar(200) null,--商品名称
   GoodsTypeId int references GoodsType(GoodsTypeId)  not null,    
   SellPrice money null, --销售价格
   EnterPrice money null,--进货价格
   GoodsImg varchar(200) not null,--商品图片
);

create table sell --商品销售
(
   SellId int primary key identity(2091211,1),--订单编号
   GoodsId int references Goods(GoodsId)  not null, --商品id
   SellCount  int null,--销售数量
   CreateData datetime default(GETDATE()),--销售时间
);


insert into role values('老板')
insert into role values('员工')
select * from role


insert into employee values('谭顺顺','123456',102)
insert into employee values('田松茂','123456',101)
select * from employee

insert into GoodsType values('饮料')
insert into GoodsType values('零食')
insert into GoodsType values('日用')
select * from GoodsType

insert into Goods values('百事可乐',1001,3,2.5)
insert into Goods values('康师傅冰红茶',1001,3,2)
insert into Goods values('统一阿萨姆奶茶',1001,4,3)
insert into Goods values('阿尔卑斯棒棒糖',1002,1,0.5)
insert into Goods values('白色恋人饼干',1002,300,219)
insert into Goods values('丹夫华夫饼',1002,120,100)
insert into Goods values('云南白药创可贴',1003,26,25)
insert into Goods values('马克笔',1003,24,20)
insert into Goods values('保温杯',1003,30,21)
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