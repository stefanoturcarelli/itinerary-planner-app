--===========================================================================================
-- Author			: Stefano
-- Create Date		: Feb 21, 2024
-- Description		: Insert trip to table
-- Name				: usp_InsertTripTask
-- Params			: 
--===========================================================================================
-- REVISION
-- Author			: 
-- Revision Date	: 
-- Comments			: 
--===========================================================================================
CREATE OR ALTER PROCEDURE usp_InsertTripTask
@TripTaskId INT, 
@TripId INT,
@TaskName NVARCHAR(50), 
@TaskDescription NVARCHAR(MAX),
@TaskDueDate DATETIME
AS
BEGIN

BEGIN TRY

BEGIN TRANSACTION
	UPDATE TripTask
	SET TripId = @TripId
	WHERE TripTaskId = @TripTaskId
	INSERT INTO 
		TripTask(TaskName, TripId, TaskDescription, TaskDueDate)
	VALUES 
		(@TaskName, @TripId, @TaskDescription, @TaskDueDate)
COMMIT TRANSACTION

END TRY

BEGIN CATCH
	IF @@TRANCOUNT > 0 
		ROLLBACK TRANSACTION
END CATCH

END