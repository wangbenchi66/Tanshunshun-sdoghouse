if exists(select * from sys.databases where name='Test')
drop database Test
go
create database Test
go
use Test
go

--BookTypeInfo (书籍分类信息表)
if exists(select * from sys.tables where name='BookTypeInfo')
drop table BookTypeInfo
go
create table BookTypeInfo
(
	BookTypeID int primary key identity(1,1),--类型编号	主键,自动增长列
	BookTypeName varchar(30) not null,--类型名称 不允
)
go

--BookInfo(图书信息表)
if exists(select * from sys.tables where name='BookInfo')
drop table BookInfo
go
create table BookInfo
(
	BookID int primary key identity(1,1),--	书籍编号	主键,自动增长列
	BookName varchar(30) not null,--书籍名称 不允许为空
	BookType Int not null references BookTypeInfo(BookTypeID),--书籍类型 不允许为空
	BookPrice float not null,--书籍价格 不允许为空
	AuthorName varchar(20) not null, --书籍作者不允许为空
	IsLoan bit default(0) not null,--是否借出 不允许为空
	Addtime datetime default( getdate())   not null,--购买时间	不允许为空
	Remark varchar(100),--备注
)
go

--插入数据
insert BookTypeInfo values('小说')
insert BookTypeInfo values('文学')
insert BookTypeInfo values('历史')

insert BookInfo values('三国演义',1,99,'罗贯中',0,'2017-1-1','')
insert BookInfo values('平凡的世界',2,88,'路遥',0,'2017-2-2','')
insert BookInfo values('万历十五年',3,77,'李斌辉',1,'2017-3-3','')

--存储过程

--查询
if exists(select * from sys.procedures where name='BookInfo_select')
drop proc BookInfo_select
go
create proc BookInfo_select
as
	select * from BookInfo,BookTypeInfo where BookInfo.BookID=BookTypeInfo.BookTypeID
go
--	exec BookInfo_select

--查询类别
if exists(select * from sys.procedures where name='BookTypeInfo_select')
drop proc BookTypeInfo_select
go
create proc BookTypeInfo_select
as
	select * from BookTypeInfo
go
--	exec BookTypeInfo_select

--修改
if exists(select * from sys.procedures where name='BookInfo_update')
drop proc BookInfo_update
go
create proc BookInfo_update(@BookName varchar(30),@BookType Int,@BookPrice float,@IsLoan bit,@Remark varchar(100),@BookID int)
as
	update BookInfo set BookName=@BookName,BookType=@BookType,BookPrice=@BookPrice,IsLoan=@IsLoan,Remark=@Remark where BookID=@BookID
go

--	exec BookInfo_update '三国演义',1,99,0,'',1