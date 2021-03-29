﻿CREATE TABLE [dbo].[Attachment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](1000),
	[Path] [nvarchar](250) NOT NULL,
	[AttachmentTypeId] [int] NOT NULL,
 CONSTRAINT [PK_ATTACHMENT] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Attachment]  WITH CHECK ADD  CONSTRAINT [Attachment_fk0] FOREIGN KEY([AttachmentTypeId])
REFERENCES [dbo].[AttachmentType] ([Id])
ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[Attachment] CHECK CONSTRAINT [Attachment_fk0]
GO
