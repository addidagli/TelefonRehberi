USE [master]
GO
/****** Object:  Database [Telefon]    Script Date: 3/27/2019 6:13:25 PM ******/
CREATE DATABASE [Telefon]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Telefon', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Telefon.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Telefon_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Telefon_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Telefon] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Telefon].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Telefon] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Telefon] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Telefon] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Telefon] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Telefon] SET ARITHABORT OFF 
GO
ALTER DATABASE [Telefon] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Telefon] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Telefon] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Telefon] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Telefon] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Telefon] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Telefon] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Telefon] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Telefon] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Telefon] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Telefon] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Telefon] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Telefon] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Telefon] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Telefon] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Telefon] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Telefon] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Telefon] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Telefon] SET  MULTI_USER 
GO
ALTER DATABASE [Telefon] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Telefon] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Telefon] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Telefon] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Telefon] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Telefon] SET QUERY_STORE = OFF
GO
USE [Telefon]
GO
/****** Object:  Table [dbo].[Tbl_Admin]    Script Date: 3/27/2019 6:13:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Admin](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[kullaniciad] [varchar](20) NULL,
	[sifre] [varchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Bilgi]    Script Date: 3/27/2019 6:13:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Bilgi](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ad] [varchar](15) NULL,
	[soyad] [varchar](15) NULL,
	[telefon] [varchar](50) NULL,
	[departman] [varchar](30) NULL,
	[yoneticibilgi] [varchar](30) NULL,
	[TC] [char](11) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Departmanlar]    Script Date: 3/27/2019 6:13:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Departmanlar](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[departmanad] [varchar](30) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Yonetim]    Script Date: 3/27/2019 6:13:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Yonetim](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[yonetim] [varchar](30) NULL,
	[puan] [smallint] NULL,
	[departman] [varchar](20) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Admin] ON 

INSERT [dbo].[Tbl_Admin] ([id], [kullaniciad], [sifre]) VALUES (1, N'admin', N'123')
SET IDENTITY_INSERT [dbo].[Tbl_Admin] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Bilgi] ON 

INSERT [dbo].[Tbl_Bilgi] ([id], [ad], [soyad], [telefon], [departman], [yoneticibilgi], [TC]) VALUES (48, N'Selçuk', N'Cerit', N'(981) 556-6151', N'Finans', N'Muhasebe', N'56505605662')
INSERT [dbo].[Tbl_Bilgi] ([id], [ad], [soyad], [telefon], [departman], [yoneticibilgi], [TC]) VALUES (50, N'Bülent', N'Ortaçgil', N'(146) 785-7578', N'Satis', N'Satin Alma Müdürü', N'82951613651')
INSERT [dbo].[Tbl_Bilgi] ([id], [ad], [soyad], [telefon], [departman], [yoneticibilgi], [TC]) VALUES (47, N'Ali Emre', N'Yayvan', N'(256) 251-6516', N'Üretim ve AR-GE', N'Tekniker', N'16515615616')
INSERT [dbo].[Tbl_Bilgi] ([id], [ad], [soyad], [telefon], [departman], [yoneticibilgi], [TC]) VALUES (49, N'Birsen ', N'Tezer', N'(151) 651-5191', N'Insan Kaynaklari', N'Personel Müdürü', N'29849498826')
INSERT [dbo].[Tbl_Bilgi] ([id], [ad], [soyad], [telefon], [departman], [yoneticibilgi], [TC]) VALUES (51, N'Hüsnü', N'Arkan', N'(529) 828-9198', N'Hukuk', N'Avukat', N'19815623032')
INSERT [dbo].[Tbl_Bilgi] ([id], [ad], [soyad], [telefon], [departman], [yoneticibilgi], [TC]) VALUES (53, N'Alaattin', N'Dagli', N'(451) 541-4154', N'', N'Genel Müdür', N'11981915616')
SET IDENTITY_INSERT [dbo].[Tbl_Bilgi] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Departmanlar] ON 

INSERT [dbo].[Tbl_Departmanlar] ([id], [departmanad]) VALUES (1, N'Finans')
INSERT [dbo].[Tbl_Departmanlar] ([id], [departmanad]) VALUES (2, N'Hukuk')
INSERT [dbo].[Tbl_Departmanlar] ([id], [departmanad]) VALUES (3, N'Insan Kaynaklari')
INSERT [dbo].[Tbl_Departmanlar] ([id], [departmanad]) VALUES (4, N'Pazarlama')
INSERT [dbo].[Tbl_Departmanlar] ([id], [departmanad]) VALUES (5, N'Satis')
INSERT [dbo].[Tbl_Departmanlar] ([id], [departmanad]) VALUES (6, N'Üretim ve AR-GE')
SET IDENTITY_INSERT [dbo].[Tbl_Departmanlar] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Yonetim] ON 

INSERT [dbo].[Tbl_Yonetim] ([id], [yonetim], [puan], [departman]) VALUES (1, N'Genel Müdür', 5, N'')
INSERT [dbo].[Tbl_Yonetim] ([id], [yonetim], [puan], [departman]) VALUES (2, N'Pazarlama Müdürü', 3, N'Pazarlama')
INSERT [dbo].[Tbl_Yonetim] ([id], [yonetim], [puan], [departman]) VALUES (3, N'Personel Müdürü', 3, N'Insan Kaynaklari')
INSERT [dbo].[Tbl_Yonetim] ([id], [yonetim], [puan], [departman]) VALUES (4, N'Satin Alma Müdürü', 3, N'Satis')
INSERT [dbo].[Tbl_Yonetim] ([id], [yonetim], [puan], [departman]) VALUES (5, N'Avukat', 2, N'Hukuk')
INSERT [dbo].[Tbl_Yonetim] ([id], [yonetim], [puan], [departman]) VALUES (6, N'Mühendis', 2, N'Üretim ve AR-GE')
INSERT [dbo].[Tbl_Yonetim] ([id], [yonetim], [puan], [departman]) VALUES (7, N'Tekniker', 2, N'Üretim ve AR-GE')
INSERT [dbo].[Tbl_Yonetim] ([id], [yonetim], [puan], [departman]) VALUES (8, N'Muhasebe', 1, N'Finans')
INSERT [dbo].[Tbl_Yonetim] ([id], [yonetim], [puan], [departman]) VALUES (9, N'Reklam', 1, N'Pazarlama')
INSERT [dbo].[Tbl_Yonetim] ([id], [yonetim], [puan], [departman]) VALUES (10, N'Yatirim Planlama', 1, N'Finans')
INSERT [dbo].[Tbl_Yonetim] ([id], [yonetim], [puan], [departman]) VALUES (11, N'Malzeme Tedarik', 1, N'Pazarlama')
INSERT [dbo].[Tbl_Yonetim] ([id], [yonetim], [puan], [departman]) VALUES (12, NULL, NULL, N'')
SET IDENTITY_INSERT [dbo].[Tbl_Yonetim] OFF
USE [master]
GO
ALTER DATABASE [Telefon] SET  READ_WRITE 
GO
