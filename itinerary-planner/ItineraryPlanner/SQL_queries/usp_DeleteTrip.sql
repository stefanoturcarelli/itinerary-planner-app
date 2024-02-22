--===========================================================================================
-- Author			: Stefano
-- Create Date		: Feb 22, 2024
-- Description		: Delete a trip record
-- Name				: usp_DeleteTrip
-- Params			: 
--===========================================================================================
-- REVISION
-- Author			: 
-- Revision Date	: 
-- Comments			: 
--===========================================================================================
CREATE OR ALTER PROCEDURE usp_DeleteTrip
@TripId INT
AS
BEGIN

BEGIN TRY

BEGIN TRANSACTION
	DELETE FROM Trip
	WHERE TripId = @TripId
COMMIT TRANSACTION

END TRY

BEGIN CATCH
	IF @@TRANCOUNT > 0 
		ROLLBACK TRANSACTION
END CATCH

END