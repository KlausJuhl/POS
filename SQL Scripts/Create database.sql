USE [master]
GO
/****** Object:  Database [SelfServicePOS]    Script Date: 23-05-2023 16:08:34 ******/
CREATE DATABASE [SelfServicePOS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SelfServicePOS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SelfServicePOS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SelfServicePOS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SelfServicePOS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SelfServicePOS] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SelfServicePOS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SelfServicePOS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SelfServicePOS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SelfServicePOS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SelfServicePOS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SelfServicePOS] SET ARITHABORT OFF 
GO
ALTER DATABASE [SelfServicePOS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SelfServicePOS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SelfServicePOS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SelfServicePOS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SelfServicePOS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SelfServicePOS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SelfServicePOS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SelfServicePOS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SelfServicePOS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SelfServicePOS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SelfServicePOS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SelfServicePOS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SelfServicePOS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SelfServicePOS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SelfServicePOS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SelfServicePOS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SelfServicePOS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SelfServicePOS] SET RECOVERY FULL 
GO
ALTER DATABASE [SelfServicePOS] SET  MULTI_USER 
GO
ALTER DATABASE [SelfServicePOS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SelfServicePOS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SelfServicePOS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SelfServicePOS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SelfServicePOS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SelfServicePOS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SelfServicePOS', N'ON'
GO
ALTER DATABASE [SelfServicePOS] SET QUERY_STORE = OFF
GO
USE [SelfServicePOS]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 23-05-2023 16:08:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerNumber] [bigint] NOT NULL,
	[CustomerName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EcoPOS]    Script Date: 23-05-2023 16:08:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EcoPOS](
	[EcoPosId] [int] IDENTITY(1,1) NOT NULL,
	[EcoPosTimestamp] [datetime] NOT NULL,
	[CustomerNumber] [bigint] NOT NULL,
	[ProductNumber] [varchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Total] [float] NOT NULL,
	[EcoBooked] [datetime] NULL,
	[EcoErrorCode] [int] NULL,
	[EcoErrorText] [varchar](500) NULL,
 CONSTRAINT [PK_EcoPOS] PRIMARY KEY CLUSTERED 
(
	[EcoPosId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[POSTransaction]    Script Date: 23-05-2023 16:08:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[POSTransaction](
	[POSTransId] [int] IDENTITY(1,1) NOT NULL,
	[POSTimestamp] [datetime] NULL,
	[InvoiceNumber] [int] NULL,
	[CustomerNumber] [bigint] NULL,
	[ProductNumber] [bigint] NULL,
	[Quantity] [int] NULL,
	[UnitNetPrice] [float] NULL,
 CONSTRAINT [PK_POSTransaction] PRIMARY KEY CLUSTERED 
(
	[POSTransId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 23-05-2023 16:08:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductNumber] [bigint] NOT NULL,
	[ProductName] [nvarchar](20) NOT NULL,
	[Price] [money] NULL,
	[ImageFileName] [nvarchar](20) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [SelfServicePOS] SET  READ_WRITE 
GO
