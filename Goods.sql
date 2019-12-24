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
SELECT   GoodsName as Name ,COUNT(GoodsName) as Value
                FROM      dbo.Goods INNER JOIN
                dbo.GoodsType ON dbo.Goods.GoodsTypeId = dbo.GoodsType.GoodsTypeId INNER JOIN
                dbo.sell ON dbo.Goods.GoodsId = dbo.sell.GoodsId group by GoodsName

SELECT   GoodsName as Name ,COUNT(GoodsName) as Value
                FROM      dbo.Goods INNER JOIN
                dbo.GoodsType ON dbo.Goods.GoodsTypeId = dbo.GoodsType.GoodsTypeId INNER JOIN
                dbo.sell ON dbo.Goods.GoodsId = dbo.sell.GoodsId group by GoodsName

SELECT * FROM sell

--全部商品分析
SELECT   dbo.Goods.GoodsName AS NAME, dbo.sell.SellCount AS VALUE
FROM      dbo.sell INNER JOIN
                dbo.Goods ON dbo.sell.GoodsId = dbo.Goods.GoodsId group by Goods.GoodsName,sell.SellCount

--销量前5商品分析
SELECT top 5  dbo.Goods.GoodsName AS NAME, dbo.sell.SellCount AS VALUE
FROM      dbo.sell INNER JOIN
                dbo.Goods ON dbo.sell.GoodsId = dbo.Goods.GoodsId group by Goods.GoodsName,sell.SellCount order by Value desc

--根据类别名称查询
	SELECT   *
                    FROM      dbo.Goods INNER JOIN
                dbo.GoodsType ON dbo.Goods.GoodsTypeId = dbo.GoodsType.GoodsTypeId  where GoodsTypeName='零食'

--查询销售情况  条件查询
SELECT   *
FROM      dbo.Goods INNER JOIN
                dbo.sell ON dbo.Goods.GoodsId = dbo.sell.GoodsId where GoodsName='面包'

