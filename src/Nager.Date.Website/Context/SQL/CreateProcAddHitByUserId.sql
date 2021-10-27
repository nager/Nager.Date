CREATE PROCEDURE AddHitByUserId
(
	@UserId int,
	@IP varbinary(16)
)
AS BEGIN
	DECLARE @today DATE
	DECLARE @hitId INT
	SET @today = GETDATE()
	BEGIN TRANSACTION SERIALIZABLE
	SET @hitId = (SELECT ch.Id FROM [ConsumerHits] ch
				  WHERE ch.[HitDate] = @today AND ch.[IPAddress] = @IP AND ch.UserId = @UserId) 
	IF @hitId IS NULL BEGIN
		INSERT INTO [ConsumerHits] ([UserId], [HitDate], [IPAddress], [HitCount])
		VALUES (@UserId, @today, @IP, 1)
	END ELSE BEGIN
		UPDATE [ConsumerHits] SET [HitCount] = [HitCount] + 1
		WHERE [Id] = @hitId
	END
	COMMIT
END
