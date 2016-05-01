-- Call:
-- EXEX sp_getMovie 'The', NULL

USE [osytest]
GO
/****** Object:  StoredProcedure [dbo].[sp_getMovie]    Script Date: 01.05.2016 14:17:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--CREATE PROCEDURE <Procedure_Name, sysname, ProcedureName> 
ALTER PROCEDURE [dbo].[sp_getMovie] 
	-- Add the parameters for the stored procedure here
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	--<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
	@Title varchar(20),
	@Genre varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--SELECT <@Param1, sysname, @p1>, <@Param2, sysname, @p2>
	Select [ID]
      ,[Title]
      ,[ReleaseDate]
      ,[Genre]
      ,[Price]
      ,[Rating]
	From dbo.Movies
	where (Title LIKE @Title + '%' Or @Title is NULL) AND (Genre LIKE @Genre + '%'  OR @Genre is NULL)

END
