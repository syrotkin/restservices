USE [osytest]
GO

/****** Object:  Table [dbo].[Movies]    Script Date: 01.05.2016 15:16:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Movies](
	[ID] [int] NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[ReleaseDate] [datetime] NOT NULL,
	[Genre] [nvarchar](255) NOT NULL,
	[Price] [decimal](19, 5) NOT NULL,
	[Rating] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
