--===========================================================================================
-- Author			: Stefano
-- Create Date		: Feb 22, 2024
-- Description		: Update a trip based on the TripId
-- Name				: usp_UpdateTrip
-- Params			: 
--===========================================================================================
-- REVISION
-- Author			: 
-- Revision Date	: 
-- Comments			: 
--===========================================================================================

CREATE OR ALTER PROCEDURE usp_UpdateTrip
    @TripId INT,
    @Destination NVARCHAR(50), 
    @Description NVARCHAR(MAX),
    @StartDate DATETIME, 
    @EndDate DATETIME
AS 
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
            UPDATE Trip
            SET 
                Destination = @Destination, 
                [Description] = @Description,
                StartDate = @StartDate,
                EndDate = @EndDate
            WHERE 
                TripId = @TripId;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF(@@TRANCOUNT > 0) 
            ROLLBACK TRANSACTION;
    END CATCH;
END;
