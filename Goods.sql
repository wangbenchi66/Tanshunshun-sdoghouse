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
SELECT   GoodsName as Name ,COUNT(GoodsName) as Value
                FROM      dbo.Goods INNER JOIN
                dbo.GoodsType ON dbo.Goods.GoodsTypeId = dbo.GoodsType.GoodsTypeId INNER JOIN
                dbo.sell ON dbo.Goods.GoodsId = dbo.sell.GoodsId group by GoodsName

SELECT   GoodsName as Name ,COUNT(GoodsName) as Value
                FROM      dbo.Goods INNER JOIN
                dbo.GoodsType ON dbo.Goods.GoodsTypeId = dbo.GoodsType.GoodsTypeId INNER JOIN
                dbo.sell ON dbo.Goods.GoodsId = dbo.sell.GoodsId group by GoodsName

SELECT * FROM sell

--ȫ����Ʒ����
SELECT   dbo.Goods.GoodsName AS NAME, dbo.sell.SellCount AS VALUE
FROM      dbo.sell INNER JOIN
                dbo.Goods ON dbo.sell.GoodsId = dbo.Goods.GoodsId group by Goods.GoodsName,sell.SellCount

--����ǰ5��Ʒ����
SELECT top 5  dbo.Goods.GoodsName AS NAME, dbo.sell.SellCount AS VALUE
FROM      dbo.sell INNER JOIN
                dbo.Goods ON dbo.sell.GoodsId = dbo.Goods.GoodsId group by Goods.GoodsName,sell.SellCount order by Value desc

--����������Ʋ�ѯ
	SELECT   *
                    FROM      dbo.Goods INNER JOIN
                dbo.GoodsType ON dbo.Goods.GoodsTypeId = dbo.GoodsType.GoodsTypeId  where GoodsTypeName='��ʳ'

--��ѯ�������  ������ѯ
SELECT   *
FROM      dbo.Goods INNER JOIN
                dbo.sell ON dbo.Goods.GoodsId = dbo.sell.GoodsId where GoodsName='���'

