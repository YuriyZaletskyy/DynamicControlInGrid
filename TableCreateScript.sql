USE [MichaelSDemo2031]
GO

/****** Object:  Table [dbo].[DynamicallyDac]    Script Date: 7/5/2021 10:49:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DynamicallyDac](
	[Value] [nvarchar](60) NULL,
	[Index] [int] NOT NULL,
	[Type] [nvarchar](50) NULL,
 CONSTRAINT [PK_DynamicallyDac] PRIMARY KEY CLUSTERED 
(
	[Index] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


