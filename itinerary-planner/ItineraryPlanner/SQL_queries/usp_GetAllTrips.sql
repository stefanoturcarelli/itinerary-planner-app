--===========================================================================================
-- Author			: Stefano
-- Create Date		: Feb 21, 2024
-- Description		: Getting the data about trips
-- Name				: usp_GetAllTrips
-- Params			: 
--===========================================================================================
-- REVISION
-- Author			: 
-- Revision Date	: 
-- Comments			: 
--===========================================================================================
CREATE OR ALTER PROCEDURE usp_GetAllTrips
AS
BEGIN
	SELECT * FROM [dbo].[Trip]
END