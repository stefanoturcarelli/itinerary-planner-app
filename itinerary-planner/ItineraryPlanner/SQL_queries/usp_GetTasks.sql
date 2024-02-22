--===========================================================================================
-- Author			: Stefano
-- Create Date		: Feb 21, 2024
-- Description		: Get Trip Tasks based on a given TripId
-- Name				: usp_GetTasks
-- Params			: 
--===========================================================================================
-- REVISION
-- Author			: 
-- Revision Date	: 
-- Comments			: 
--===========================================================================================
CREATE OR ALTER PROCEDURE usp_GetTasks
@TripId INT
AS 
BEGIN
	SELECT * 
	FROM TripTask
	WHERE TripId = @TripId
END