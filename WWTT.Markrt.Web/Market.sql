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
   inventory int null, --库存数量
);

create table sell --商品销售
(
   SellId int primary key identity(2091211,1),--订单编号
   GoodsId int references Goods(GoodsId)  not null, --商品id
   --GoodsName varchar references Goods(GoodsName) null, --商品名称
   GoodsPrice money null, --商品价格
   SellCount  int null,--销售数量
   GoodsValue money null, --商品总价
   CreateData datetime default(GETDATE()),--销售时间
);

create table provider --供应商
(
   ProviderId int primary key identity(190901,1), --供应商编号
   ProviderName nvarchar(200) null,--供应商名称
   Phone  nvarchar(200) null,--供应商电话
   GoodsId int references Goods(GoodsId),--商品id
   --GoodsName varchar null,--商品名称
   ProviderPrice money null,--供货价格
);

insert into role values('销售员')
insert into role values('供应商')
insert into role values('店铺管理员')
select * from role

insert into employee values('王奔驰','123456',102)
insert into employee values('王洋','123456',103)
insert into employee values('谭顺顺','123456',101)
insert into employee values('田松茂','123456',101)
select * from employee

insert into GoodsType values('饮料')
insert into GoodsType values('零食')
insert into GoodsType values('日用')
select * from GoodsType

insert into Goods values('百事可乐',1001,3,2.5,458)
insert into Goods values('康师傅冰红茶',1001,3,2,333)
insert into Goods values('统一阿萨姆奶茶',1001,4,3,108)
insert into Goods values('阿尔卑斯棒棒糖',1002,1,0.5,516)
insert into Goods values('白色恋人饼干',1002,300,219,61)
insert into Goods values('丹夫华夫饼',1002,120,100,86)
insert into Goods values('云南白药创可贴',1003,26,25,102)
insert into Goods values('马克笔',1003,24,20,321)
insert into Goods values('保温杯',1003,30,21,40)
select * from Goods

insert into sell values(2001,3,2,6,default)
insert into sell values(2002,3,3,9,default)
insert into sell values(2003,4,1,4,default)
insert into sell values(2006,120,2,240,default)
insert into sell values(2008,24,3,72,default)
select * from sell

insert into provider values('深圳百事可乐饮料有限公司',07525810749,2001,2.5)
insert into provider values('圣元饮品（山东）有限公司',13011354044,2002,2)
insert into provider values('青岛优源优饮贸易有限公司',13210230808,2003,3)
insert into provider values('嘉兴健博贸易有限公司',057384018610,2004,0.5)
select * from provider

select * from role
select * from employee
select * from GoodsType
select * from Goods
select * from sell
select * from provider