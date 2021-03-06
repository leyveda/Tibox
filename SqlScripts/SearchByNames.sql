USE [Northwind_Lite]
GO
/****** Object:  StoredProcedure [dbo].[SearchByNames]    Script Date: 05/03/2017 09:55:42 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SearchByNames] @firstName NVARCHAR(40)
	,@lastName NVARCHAR(40)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id]
		,[FirstName]
		,[LastName]
		,[City]
		,[Country]
		,[Phone]
	FROM dbo.Customer
	WHERE FirstName = @firstName
		AND LastName = @lastName
END
