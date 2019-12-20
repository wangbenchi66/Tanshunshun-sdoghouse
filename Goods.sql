use SuperMarket
go

--查询类别
create proc GoodsTypeSelect
as
	select * from GoodsType
go
--	exec GoodsTypeSelect

--修改商品信息
create proc GoodsUpdate(@GoodsName nvarchar(200),@GoodsTypeId int,@SellPrice money,@EnterPrice money,@GoodsImg varchar(200),@GoodsState int,@GoodsId int)
as
	update Goods set GoodsName=@GoodsName,GoodsTypeId=@GoodsTypeId,SellPrice=@SellPrice,EnterPrice=@EnterPrice,GoodsImg=@GoodsImg,GoodsState=@GoodsState where GoodsId=@GoodsId
go
--	exec GoodsUpdate '小米巨能写中性笔10支装',1006,9.99,9,'/images/Food/bi1.jpg',1,2001
