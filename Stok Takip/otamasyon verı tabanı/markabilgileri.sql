USE [Stok_Takıp]
GO

/****** Object:  Table [dbo].[markabilgileri]    Script Date: 11.06.2024 22:40:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[markabilgileri](
	[kategori] [nvarchar](50) NOT NULL,
	[marka] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO

