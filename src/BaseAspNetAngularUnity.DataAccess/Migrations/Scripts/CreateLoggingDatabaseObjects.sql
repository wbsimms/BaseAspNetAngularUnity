--IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Category]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
--BEGIN
--CREATE TABLE [dbo].[Category](
--	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
--	[CategoryName] [nvarchar](64) NOT NULL,
-- CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
--(
--	[CategoryID] ASC
--)

--)
--END

--IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CategoryLog]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
--BEGIN
--CREATE TABLE [dbo].[CategoryLog](
--	[CategoryLogID] [int] IDENTITY(1,1) NOT NULL,
--	[CategoryID] [int] NOT NULL,
--	[LogID] [int] NOT NULL,
-- CONSTRAINT [PK_CategoryLog] PRIMARY KEY CLUSTERED 
--(
--	[CategoryLogID] ASC
--)
 
--) 
--END

--IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Log]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
--BEGIN
--CREATE TABLE [dbo].[Log](
--	[LogID] [int] IDENTITY(1,1) NOT NULL,
--	[EventID] [int] NULL,
--	[Priority] [int] NOT NULL,
--	[Severity] [nvarchar](32) NOT NULL,
--	[Title] [nvarchar](256) NOT NULL,
--	[Timestamp] [datetime2] NOT NULL,
--	[MachineName] [nvarchar](32) NOT NULL,
--	[AppDomainName] [nvarchar](512) NOT NULL,
--	[ProcessID] [nvarchar](256) NOT NULL,
--	[ProcessName] [nvarchar](512) NOT NULL,
--	[ThreadName] [nvarchar](512) NULL,
--	[Win32ThreadId] [nvarchar](128) NULL,
--	[Message] [nvarchar](1500) NULL,
--	[FormattedMessage] [ntext] NULL,
-- CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
--(
--	[LogID] ASC
--) 
 
--) 
--END

IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[InsertCategoryLog]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE InsertCategoryLog
	@CategoryID INT,
	@LogID INT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @CatLogID INT
	SELECT @CatLogID FROM CategoryLogs WHERE CategoryID=@CategoryID and LogID = @LogID
	IF @CatLogID IS NULL
	BEGIN
		INSERT INTO CategoryLogs (CategoryID, LogID) VALUES(@CategoryID, @LogID)
		RETURN @@IDENTITY
	END
	ELSE RETURN @CatLogID
END
' 
END

IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[AddCategory]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[AddCategory]
	-- Add the parameters for the function here
	@CategoryName nvarchar(64),
	@LogID int
AS
BEGIN
	SET NOCOUNT ON;
    DECLARE @CatID INT
	SELECT @CatID = CategoryID FROM Categories WHERE CategoryName = @CategoryName
	IF @CatID IS NULL
	BEGIN
		INSERT INTO Categories (CategoryName) VALUES(@CategoryName)
		SELECT @CatID = @@IDENTITY
	END

	EXEC InsertCategoryLog @CatID, @LogID 

	RETURN @CatID
END

' 
END

IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[ClearLogs]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE ClearLogs
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM CategoryLogs
	DELETE FROM [Logs]
    DELETE FROM Categories
END
' 
END

IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[WriteLog]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



/****** Object:  Stored Procedure dbo.WriteLog    Script Date: 10/1/2004 3:16:36 PM ******/

CREATE PROCEDURE [dbo].[WriteLog]
(
	@EventID int, 
	@Priority int, 
	@Severity nvarchar(32), 
	@Title nvarchar(256), 
	@Timestamp datetime2,
	@MachineName nvarchar(32), 
	@AppDomainName nvarchar(512),
	@ProcessID nvarchar(256),
	@ProcessName nvarchar(512),
	@ThreadName nvarchar(512),
	@Win32ThreadId nvarchar(128),
	@Message nvarchar(1500),
	@FormattedMessage ntext,
	@LogId int OUTPUT
)
AS 

	INSERT INTO [Logs] (
		EventID,
		Priority,
		Severity,
		Title,
		[Timestamp],
		MachineName,
		AppDomainName,
		ProcessID,
		ProcessName,
		ThreadName,
		Win32ThreadId,
		Message,
		FormattedMessage
	)
	VALUES (
		@EventID, 
		@Priority, 
		@Severity, 
		@Title, 
		@Timestamp,
		@MachineName, 
		@AppDomainName,
		@ProcessID,
		@ProcessName,
		@ThreadName,
		@Win32ThreadId,
		@Message,
		@FormattedMessage)

	SET @LogID = @@IDENTITY
	RETURN @LogID



' 
END

--IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'FK_CategoryLog_Category') AND parent_obj = OBJECT_ID(N'[dbo].[CategoryLog]'))
--ALTER TABLE [dbo].[CategoryLog]  WITH CHECK ADD  CONSTRAINT [FK_CategoryLog_Category] FOREIGN KEY(	[CategoryID])
--REFERENCES [dbo].[Category] (	[CategoryID])

--IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'FK_CategoryLog_Log') AND parent_obj = OBJECT_ID(N'[dbo].[CategoryLog]'))
--ALTER TABLE [dbo].[CategoryLog]  WITH CHECK ADD  CONSTRAINT [FK_CategoryLog_Log] FOREIGN KEY(	[LogID])
--REFERENCES [dbo].[Log] (	[LogID])



CREATE NONCLUSTERED INDEX [ixCategoryLog] ON [dbo].[CategoryLogs] ([LogID] ASC, [CategoryID] ASC )



