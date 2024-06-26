USE [master]
GO
/****** Object:  Database [BaddyMatchMaker]    Script Date: 31-Oct-21 12:06:31 AM ******/
CREATE DATABASE [BaddyMatchMaker]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BaddyMatchMaker', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BaddyMatchMaker.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BaddyMatchMaker_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BaddyMatchMaker_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BaddyMatchMaker] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BaddyMatchMaker].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BaddyMatchMaker] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BaddyMatchMaker] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BaddyMatchMaker] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BaddyMatchMaker] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BaddyMatchMaker] SET ARITHABORT OFF 
GO
ALTER DATABASE [BaddyMatchMaker] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BaddyMatchMaker] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BaddyMatchMaker] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BaddyMatchMaker] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BaddyMatchMaker] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BaddyMatchMaker] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BaddyMatchMaker] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BaddyMatchMaker] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BaddyMatchMaker] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BaddyMatchMaker] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BaddyMatchMaker] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BaddyMatchMaker] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BaddyMatchMaker] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BaddyMatchMaker] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BaddyMatchMaker] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BaddyMatchMaker] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BaddyMatchMaker] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BaddyMatchMaker] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BaddyMatchMaker] SET  MULTI_USER 
GO
ALTER DATABASE [BaddyMatchMaker] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BaddyMatchMaker] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BaddyMatchMaker] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BaddyMatchMaker] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BaddyMatchMaker] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BaddyMatchMaker] SET QUERY_STORE = OFF
GO
USE [BaddyMatchMaker]
GO
/****** Object:  User [admin]    Script Date: 31-Oct-21 12:06:31 AM ******/
CREATE USER [admin] FOR LOGIN [admin] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [admin]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [admin]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [admin]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [admin]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [admin]
GO
ALTER ROLE [db_datareader] ADD MEMBER [admin]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [admin]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [admin]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [admin]
GO
/****** Object:  Table [dbo].[Club]    Script Date: 31-Oct-21 12:06:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Club](
	[clubId] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](max) NULL,
 CONSTRAINT [PK_Club] PRIMARY KEY CLUSTERED 
(
	[clubId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Match]    Script Date: 31-Oct-21 12:06:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Match](
	[matchId] [int] IDENTITY(1,1) NOT NULL,
	[courtNumber] [int] NOT NULL,
	[roundId] [int] NOT NULL,
 CONSTRAINT [PK_Match] PRIMARY KEY CLUSTERED 
(
	[matchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Player]    Script Date: 31-Oct-21 12:06:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[playerId] [int] IDENTITY(1,1) NOT NULL,
	[clubId] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[sex] [char](1) NOT NULL,
	[grade] [int] NOT NULL,
	[phone] [varchar](50) NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED 
(
	[playerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlayerMatch]    Script Date: 31-Oct-21 12:06:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayerMatch](
	[playerMatchId] [int] IDENTITY(1,1) NOT NULL,
	[matchId] [int] NOT NULL,
	[playerId] [int] NOT NULL,
 CONSTRAINT [PK_PlayerMatch] PRIMARY KEY CLUSTERED 
(
	[playerMatchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Round]    Script Date: 31-Oct-21 12:06:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Round](
	[roundId] [int] IDENTITY(1,1) NOT NULL,
	[sessionId] [int] NOT NULL,
	[roundNumber] [int] NOT NULL,
	[startTime] [datetime] NULL,
	[endTime] [datetime] NULL,
	[courtsAvailable] [int] NOT NULL,
 CONSTRAINT [PK_Round] PRIMARY KEY CLUSTERED 
(
	[roundId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Session]    Script Date: 31-Oct-21 12:06:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Session](
	[sessionId] [int] IDENTITY(1,1) NOT NULL,
	[clubId] [int] NOT NULL,
	[venueId] [int] NOT NULL,
	[startTime] [datetime] NULL,
	[endTime] [datetime] NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED 
(
	[sessionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SessionPlayer]    Script Date: 31-Oct-21 12:06:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SessionPlayer](
	[sessionPlayerId] [int] IDENTITY(1,1) NOT NULL,
	[sessionId] [int] NOT NULL,
	[playerId] [int] NOT NULL,
	[signInTime] [datetime] NOT NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_SessionPlayer] PRIMARY KEY CLUSTERED 
(
	[sessionPlayerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Setting]    Script Date: 31-Oct-21 12:06:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Setting](
	[clubId] [int] NOT NULL,
	[matchDuration] [int] NOT NULL,
	[ignoreSex] [bit] NOT NULL,
	[singlesMode] [bit] NOT NULL,
	[prioritizeMixed] [bit] NOT NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[clubId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venue]    Script Date: 31-Oct-21 12:06:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venue](
	[venueId] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[address] [varchar](max) NULL,
	[numberOfCourts] [int] NOT NULL,
 CONSTRAINT [PK_Venue] PRIMARY KEY CLUSTERED 
(
	[venueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_PlayerMatch]    Script Date: 31-Oct-21 12:06:31 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_PlayerMatch] ON [dbo].[PlayerMatch]
(
	[matchId] ASC,
	[playerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SessionPlayer]    Script Date: 31-Oct-21 12:06:31 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_SessionPlayer] ON [dbo].[SessionPlayer]
(
	[sessionId] ASC,
	[playerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_Round] FOREIGN KEY([roundId])
REFERENCES [dbo].[Round] ([roundId])
GO
ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_Match_Round]
GO
ALTER TABLE [dbo].[Player]  WITH CHECK ADD  CONSTRAINT [FK_Player_Club] FOREIGN KEY([clubId])
REFERENCES [dbo].[Club] ([clubId])
GO
ALTER TABLE [dbo].[Player] CHECK CONSTRAINT [FK_Player_Club]
GO
ALTER TABLE [dbo].[PlayerMatch]  WITH CHECK ADD  CONSTRAINT [FK_PlayerMatch_Match] FOREIGN KEY([matchId])
REFERENCES [dbo].[Match] ([matchId])
GO
ALTER TABLE [dbo].[PlayerMatch] CHECK CONSTRAINT [FK_PlayerMatch_Match]
GO
ALTER TABLE [dbo].[PlayerMatch]  WITH CHECK ADD  CONSTRAINT [FK_PlayerMatch_Player] FOREIGN KEY([playerId])
REFERENCES [dbo].[Player] ([playerId])
GO
ALTER TABLE [dbo].[PlayerMatch] CHECK CONSTRAINT [FK_PlayerMatch_Player]
GO
ALTER TABLE [dbo].[Round]  WITH CHECK ADD  CONSTRAINT [FK_Round_Session] FOREIGN KEY([sessionId])
REFERENCES [dbo].[Session] ([sessionId])
GO
ALTER TABLE [dbo].[Round] CHECK CONSTRAINT [FK_Round_Session]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK_Session_Club] FOREIGN KEY([clubId])
REFERENCES [dbo].[Club] ([clubId])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK_Session_Club]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK_Session_Venue] FOREIGN KEY([venueId])
REFERENCES [dbo].[Venue] ([venueId])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK_Session_Venue]
GO
ALTER TABLE [dbo].[SessionPlayer]  WITH CHECK ADD  CONSTRAINT [FK_SessionPlayer_Player] FOREIGN KEY([playerId])
REFERENCES [dbo].[Player] ([playerId])
GO
ALTER TABLE [dbo].[SessionPlayer] CHECK CONSTRAINT [FK_SessionPlayer_Player]
GO
ALTER TABLE [dbo].[SessionPlayer]  WITH CHECK ADD  CONSTRAINT [FK_SessionPlayer_Session] FOREIGN KEY([sessionId])
REFERENCES [dbo].[Session] ([sessionId])
GO
ALTER TABLE [dbo].[SessionPlayer] CHECK CONSTRAINT [FK_SessionPlayer_Session]
GO
ALTER TABLE [dbo].[Setting]  WITH CHECK ADD  CONSTRAINT [FK_Settings_Club] FOREIGN KEY([clubId])
REFERENCES [dbo].[Club] ([clubId])
GO
ALTER TABLE [dbo].[Setting] CHECK CONSTRAINT [FK_Settings_Club]
GO
ALTER TABLE [dbo].[Venue]  WITH CHECK ADD  CONSTRAINT [FK_Venue_Venue] FOREIGN KEY([venueId])
REFERENCES [dbo].[Venue] ([venueId])
GO
ALTER TABLE [dbo].[Venue] CHECK CONSTRAINT [FK_Venue_Venue]
GO
USE [master]
GO
ALTER DATABASE [BaddyMatchMaker] SET  READ_WRITE 
GO
