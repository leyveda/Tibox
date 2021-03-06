USE [Northwind_Lite]
GO
/****** Object:  StoredProcedure [dbo].[CustomerSearchByNames]    Script Date: 05/03/2017 09:56:35 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[CustomerSearchByNames] 
	@firstName NVARCHAR(40)
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

	SET NOCOUNT OFF;
END
