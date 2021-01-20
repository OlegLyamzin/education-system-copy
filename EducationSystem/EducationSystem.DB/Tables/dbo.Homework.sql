﻿CREATE TABLE [dbo].[Homework](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[DeadlineDate] [datetime2](7) NOT NULL,
	[GroupID] [int] NOT NULL,
	[IsOptional] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_HOMEWORK] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (
PAD_INDEX = OFF,
STATISTICS_NORECOMPUTE = OFF,
IGNORE_DUP_KEY = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
--,
--OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF
) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Homework]  WITH NOCHECK ADD  CONSTRAINT [Homework_fk0] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Group] ([Id])
ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[Homework] CHECK CONSTRAINT [Homework_fk0]