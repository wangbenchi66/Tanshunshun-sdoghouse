use SuperMarket
go

--��ѯ���
create proc GoodsTypeSelect
as
	select * from GoodsType
go
--	exec GoodsTypeSelect

--�޸���Ʒ��Ϣ
create proc GoodsUpdate(@GoodsName nvarchar(200),@GoodsTypeId int,@SellPrice money,@EnterPrice money,@GoodsImg varchar(200),@GoodsState int,@GoodsId int)
as
	update Goods set GoodsName=@GoodsName,GoodsTypeId=@GoodsTypeId,SellPrice=@SellPrice,EnterPrice=@EnterPrice,GoodsImg=@GoodsImg,GoodsState=@GoodsState where GoodsId=@GoodsId
go
--	exec GoodsUpdate 'С�׾���д���Ա�10֧װ',1006,9.99,9,'/images/Food/bi1.jpg',1,2001
