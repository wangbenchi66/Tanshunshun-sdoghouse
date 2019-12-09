if exists(select * from sys.databases where name='Test')
drop database Test
go
create database Test
go
use Test
go

--BookTypeInfo (�鼮������Ϣ��)
if exists(select * from sys.tables where name='BookTypeInfo')
drop table BookTypeInfo
go
create table BookTypeInfo
(
	BookTypeID int primary key identity(1,1),--���ͱ��	����,�Զ�������
	BookTypeName varchar(30) not null,--�������� ����
)
go

--BookInfo(ͼ����Ϣ��)
if exists(select * from sys.tables where name='BookInfo')
drop table BookInfo
go
create table BookInfo
(
	BookID int primary key identity(1,1),--	�鼮���	����,�Զ�������
	BookName varchar(30) not null,--�鼮���� ������Ϊ��
	BookType Int not null references BookTypeInfo(BookTypeID),--�鼮���� ������Ϊ��
	BookPrice float not null,--�鼮�۸� ������Ϊ��
	AuthorName varchar(20) not null, --�鼮���߲�����Ϊ��
	IsLoan bit default(0) not null,--�Ƿ��� ������Ϊ��
	Addtime datetime default( getdate())   not null,--����ʱ��	������Ϊ��
	Remark varchar(100),--��ע
)
go

--��������
insert BookTypeInfo values('С˵')
insert BookTypeInfo values('��ѧ')
insert BookTypeInfo values('��ʷ')

insert BookInfo values('��������',1,99,'�޹���',0,'2017-1-1','')
insert BookInfo values('ƽ��������',2,88,'·ң',0,'2017-2-2','')
insert BookInfo values('����ʮ����',3,77,'����',1,'2017-3-3','')

--�洢����

--��ѯ
if exists(select * from sys.procedures where name='BookInfo_select')
drop proc BookInfo_select
go
create proc BookInfo_select
as
	select * from BookInfo,BookTypeInfo where BookInfo.BookID=BookTypeInfo.BookTypeID
go
--	exec BookInfo_select

--��ѯ���
if exists(select * from sys.procedures where name='BookTypeInfo_select')
drop proc BookTypeInfo_select
go
create proc BookTypeInfo_select
as
	select * from BookTypeInfo
go
--	exec BookTypeInfo_select

--�޸�
if exists(select * from sys.procedures where name='BookInfo_update')
drop proc BookInfo_update
go
create proc BookInfo_update(@BookName varchar(30),@BookType Int,@BookPrice float,@IsLoan bit,@Remark varchar(100),@BookID int)
as
	update BookInfo set BookName=@BookName,BookType=@BookType,BookPrice=@BookPrice,IsLoan=@IsLoan,Remark=@Remark where BookID=@BookID
go

--	exec BookInfo_update '��������',1,99,0,'',1