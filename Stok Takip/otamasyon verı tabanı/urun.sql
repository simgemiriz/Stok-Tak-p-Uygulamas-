USE [Stok_Takıp]
GO

/****** Object:  Table [dbo].[urun]    Script Date: 11.06.2024 22:41:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[urun](
	[barkodno] [nvarchar](50) NOT NULL,
	[kategori] [nvarchar](50) NOT NULL,
	[marka] [nvarchar](50) NOT NULL,
	[urunadi] [nvarchar](50) NOT NULL,
	[miktar] [int] NOT NULL,
	[alisfiyatı] [decimal](18, 2) NOT NULL,
	[satisfiyatı] [decimal](18, 2) NOT NULL,
	[tarih] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO

