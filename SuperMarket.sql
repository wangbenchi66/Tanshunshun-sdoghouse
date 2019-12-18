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
insert into GoodsType values('烟酒')
insert into GoodsType values('调料')
insert into GoodsType values('办公')
select * from GoodsType

insert into Goods values('百事可乐',1001,3,2,'~/images/Food/kele.jpg')
insert into Goods values('胃动力',1001,6,5,'~/images/Food/weidongli.jpg')
insert into Goods values('统一阿萨姆奶茶',1001,4,3,'~/images/Food/asamu.jpg')
insert into Goods values('脉动',1001,5,4,'~/images/Food/maidong.jpg')
insert into Goods values('红牛',1001,6,5,'~/images/Food/redbull.jpg')

insert into Goods values('阿尔卑斯棒棒糖',1002,1,0.5,'~/images/Food/aerbeisi.jpg')
insert into Goods values('德芙（盒装）',1002,300,219,'~/images/Food/defu3.jpg')
insert into Goods values('德芙（袋装）',1002,120,100,'~/images/Food/defu1.jpg')
insert into Goods values('乐吧',1002,2,1,'~/images/Food/leba2.jpg')
insert into Goods values('面包',1002,8,6,'~/images/Food/mianbao1.jpg')
insert into Goods values('土司',1002,25,18,'~/images/Food/miaobao2.jpg')
insert into Goods values('奥利奥',1002,10,7,'~/images/Food/aoliao.jpg')

insert into Goods values('电动牙刷',1003,199,150,'~/images/Food/yashua.jpg')
insert into Goods values('洗手机',1003,300,235,'~/images/Food/xishouji.jpg')
insert into Goods values('牙膏',1003,30,21,'~/images/Food/yagao.jpg')
insert into Goods values('剃须刀',1003,199,170,'~/images/Food/guhudao.jpg')

insert into Goods values('利群',1004,14,13,'~/images/Food/liqun.jpg')
insert into Goods values('中华',1004,60,58,'~/images/Food/zhonghua.jpg')
insert into Goods values('万宝路',1004,20,18,'~/images/Food/wanbaolu.jpg')
insert into Goods values('天之蓝',1004,248,200,'~/images/Food/tian.jpg')
insert into Goods values('海之蓝',1004,258,200,'~/images/Food/hai.jpg')
insert into Goods values('梦之蓝',1004,480,300,'~/images/Food/meng.jpg')

insert into Goods values('盐',1005,2,1,'~/images/Food/yan.jpg')
insert into Goods values('十三香',1005,2,1,'~/images/Food/shisanxiang.jpg')
insert into Goods values('醋',1005,10,5,'~/images/Food/cu.jpg')
insert into Goods values('味精',1005,2,1,'~/images/Food/weijing.jpg')
insert into Goods values('香油',1005,12,10,'~/images/Food/xiangyou.jpg')
insert into Goods values('芝麻酱',1005,6,5,'~/images/Food/zhimajiang.jpg')

insert into Goods values('小米巨能写中性笔10支装',1006,9.99,9,'~/images/Food/bi1.jpg')
insert into Goods values('小米中性笔 10支装 ',1006,24.9,20,'~/images/Food/bi2.jpg')
insert into Goods values('米家金属签字笔 ',1006,24.9,20,'~/images/Food/bi3.jpg')
insert into Goods values('小米记事本',1006,9.9,9,'~/images/Food/ben1.jpg')
insert into Goods values('小米米家液晶小黑板',1006,99,90,'~/images/Food/ben2.jpg')
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