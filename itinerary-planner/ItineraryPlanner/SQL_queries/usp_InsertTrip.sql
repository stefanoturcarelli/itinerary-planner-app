--===========================================================================================
-- Author			: Stefano
-- Create Date		: Feb 21, 2024
-- Description		: Insert trip to table
-- Name				: usp_InsertTrips
-- Params			: 
--===========================================================================================
-- REVISION
-- Author			: 
-- Revision Date	: 
-- Comments			: 
--===========================================================================================
CREATE OR ALTER PROCEDURE usp_InsertTrip
@Destination NVARCHAR(50), 
@Description NVARCHAR(MAX),
@StartDate DATETIME, 
@EndDate DATETIME
AS
BEGIN

BEGIN TRY

BEGIN TRANSACTION
	INSERT INTO Trip(Destination, [Description], StartDate, EndDate)
	VALUES(@Destination, @Description, @StartDate, @EndDate)
COMMIT TRANSACTION

END TRY

BEGIN CATCH
	IF @@TRANCOUNT > 0 
		ROLLBACK TRANSACTION
END CATCH

END