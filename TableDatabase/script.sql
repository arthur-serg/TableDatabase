USE [pointsdb]
GO
/****** Object:  Table [dbo].[pointstable]    Script Date: 07.03.2023 14:07:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pointstable](
	[id] [int] IDENTITY(0,1) NOT NULL,
	[x] [real] NULL,
	[y] [real] NULL,
 CONSTRAINT [PK_pointstable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteRowById]    Script Date: 07.03.2023 14:07:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_DeleteRowById]
	@id int
AS
BEGIN
	DELETE FROM [dbo].[pointstable] where id = @id

    SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteRows]    Script Date: 07.03.2023 14:07:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_DeleteRows]
AS
	TRUNCATE TABLE pointstable
    SELECT SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertPoint]    Script Date: 07.03.2023 14:07:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertPoint]
    @x real = null,
    @y real = null
AS
BEGIN
    INSERT INTO pointstable (x, y)
    VALUES (COALESCE(@x, null), COALESCE(@y, null))

    SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Select]    Script Date: 07.03.2023 14:07:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Select]
AS
	select * from pointstable
  
    SELECT SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateTable]    Script Date: 07.03.2023 14:07:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateTable]
	@id int,
    @x real = null,
    @y real = null
AS
BEGIN
    UPDATE pointstable SET x=COALESCE(@x, null), y=COALESCE(@y, null) where id=@id

    SELECT SCOPE_IDENTITY()
END
GO
