USE [FileMover]
GO

/****** Object:  Table [dbo].[MoverStatusLog]    Script Date: 3/7/2021 6:51:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MoverStatusLog]') AND type in (N'U')) 
	BEGIN
		PRINT 'CREATING TABLE MoverStatusLog...'
		CREATE TABLE [dbo].[MoverStatusLog](
			[id] [varchar](64) NOT NULL,
			[insert_date] [date] NOT NULL,
			[status] [bit] NOT NULL,
			[file_name] [varchar](60) NOT NULL,
			[file_type] [CHAR](10) NOT NULL,
		 CONSTRAINT [PK_MoverStatusLog] PRIMARY KEY CLUSTERED 
		(
			[id] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]	

		PRINT 'TABLE MoverStatusLog CREATED.'
	END
ELSE
	BEGIN
		PRINT 'TABLE ALREADY EXISTS'
	END
GO



