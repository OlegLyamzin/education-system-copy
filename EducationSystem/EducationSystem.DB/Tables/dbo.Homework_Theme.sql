﻿CREATE TABLE [dbo].[Homework_Theme](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HomeworkId] [int] NOT NULL,
	[ThemeId] [int] NOT NULL,
 CONSTRAINT [PK_HOMEWORK_THEME] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON
--, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF
) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Homework_Theme]  WITH CHECK ADD  CONSTRAINT [Homework_Theme_fk0] FOREIGN KEY([HomeworkId])
REFERENCES [dbo].[Homework] ([Id])
ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[Homework_Theme] CHECK CONSTRAINT [Homework_Theme_fk0]
GO

ALTER TABLE [dbo].[Homework_Theme]  WITH CHECK ADD  CONSTRAINT [Homework_Theme_fk1] FOREIGN KEY([ThemeId])
REFERENCES [dbo].[Theme] ([Id])
ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[Homework_Theme] CHECK CONSTRAINT [Homework_Theme_fk1]
GO