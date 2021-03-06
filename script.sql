USE [master]
GO
/****** Object:  Database [FinalDbHts]    Script Date: 02/09/2021 10:03:06 AM ******/
CREATE DATABASE [FinalDbHts]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FinalDbHts', FILENAME = N'/var/opt/mssql/data/FinalDbHts.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FinalDbHts_log', FILENAME = N'/var/opt/mssql/data/FinalDbHts_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [FinalDbHts] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FinalDbHts].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FinalDbHts] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FinalDbHts] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FinalDbHts] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FinalDbHts] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FinalDbHts] SET ARITHABORT OFF 
GO
ALTER DATABASE [FinalDbHts] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FinalDbHts] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FinalDbHts] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FinalDbHts] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FinalDbHts] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FinalDbHts] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FinalDbHts] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FinalDbHts] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FinalDbHts] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FinalDbHts] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FinalDbHts] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FinalDbHts] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FinalDbHts] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FinalDbHts] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FinalDbHts] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FinalDbHts] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FinalDbHts] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FinalDbHts] SET RECOVERY FULL 
GO
ALTER DATABASE [FinalDbHts] SET  MULTI_USER 
GO
ALTER DATABASE [FinalDbHts] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FinalDbHts] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FinalDbHts] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FinalDbHts] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FinalDbHts] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FinalDbHts] SET QUERY_STORE = OFF
GO
USE [FinalDbHts]
GO
/****** Object:  Table [dbo].[tblDoktor]    Script Date: 02/09/2021 10:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDoktor](
	[DoktorID] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](30) NOT NULL,
	[Soyad] [nvarchar](30) NOT NULL,
	[Sicil] [nvarchar](30) NOT NULL,
	[DiplomaNo] [nvarchar](30) NOT NULL,
	[KullaniciAdi] [nvarchar](50) NOT NULL,
	[Sifre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tblDoktor] PRIMARY KEY CLUSTERED 
(
	[DoktorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblHasta]    Script Date: 02/09/2021 10:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHasta](
	[HastaID] [int] IDENTITY(1,1) NOT NULL,
	[DoktorID] [int] NULL,
	[Ad] [nvarchar](30) NOT NULL,
	[Soyad] [nvarchar](30) NOT NULL,
	[TC] [nvarchar](11) NOT NULL,
	[DogumTarihi] [datetime] NOT NULL,
	[KayitTarihi] [datetime] NOT NULL,
	[Cinsiyet] [nchar](10) NULL,
	[Adres] [nvarchar](400) NULL,
	[Telefon] [nvarchar](20) NULL,
 CONSTRAINT [PK_tblHasta] PRIMARY KEY CLUSTERED 
(
	[HastaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblMuayene]    Script Date: 02/09/2021 10:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMuayene](
	[MuayeneID] [int] IDENTITY(1,1) NOT NULL,
	[HastaID] [int] NOT NULL,
	[DoktorID] [int] NOT NULL,
	[Tarih] [datetime] NULL,
 CONSTRAINT [PK_tblMuayene] PRIMARY KEY CLUSTERED 
(
	[MuayeneID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblMuayeneIlac]    Script Date: 02/09/2021 10:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMuayeneIlac](
	[MuayeneIlacID] [int] IDENTITY(1,1) NOT NULL,
	[MuayeneID] [int] NOT NULL,
	[Ilac] [nvarchar](100) NOT NULL,
	[Dozaj] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblMuayeneIlac] PRIMARY KEY CLUSTERED 
(
	[MuayeneIlacID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblMuayeneTani]    Script Date: 02/09/2021 10:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMuayeneTani](
	[MuayeneID] [int] NOT NULL,
	[TaniID] [int] NOT NULL,
 CONSTRAINT [PK_tblMuayeneTani] PRIMARY KEY CLUSTERED 
(
	[MuayeneID] ASC,
	[TaniID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTaniKatalog]    Script Date: 02/09/2021 10:03:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTaniKatalog](
	[TaniID] [int] IDENTITY(1,1) NOT NULL,
	[Tani] [nvarchar](1000) NOT NULL,
	[ICDKodu] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_tblTaniKatalog] PRIMARY KEY CLUSTERED 
(
	[TaniID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblHasta] ADD  CONSTRAINT [DF_tblHasta_KayitTarihi]  DEFAULT (getdate()) FOR [KayitTarihi]
GO
ALTER TABLE [dbo].[tblHasta]  WITH CHECK ADD  CONSTRAINT [FK_tblHasta_tblDoktor] FOREIGN KEY([DoktorID])
REFERENCES [dbo].[tblDoktor] ([DoktorID])
GO
ALTER TABLE [dbo].[tblHasta] CHECK CONSTRAINT [FK_tblHasta_tblDoktor]
GO
ALTER TABLE [dbo].[tblMuayene]  WITH CHECK ADD  CONSTRAINT [FK_tblMuayene_tblDoktor] FOREIGN KEY([DoktorID])
REFERENCES [dbo].[tblDoktor] ([DoktorID])
GO
ALTER TABLE [dbo].[tblMuayene] CHECK CONSTRAINT [FK_tblMuayene_tblDoktor]
GO
ALTER TABLE [dbo].[tblMuayene]  WITH CHECK ADD  CONSTRAINT [FK_tblMuayene_tblHasta] FOREIGN KEY([HastaID])
REFERENCES [dbo].[tblHasta] ([HastaID])
GO
ALTER TABLE [dbo].[tblMuayene] CHECK CONSTRAINT [FK_tblMuayene_tblHasta]
GO
ALTER TABLE [dbo].[tblMuayeneIlac]  WITH CHECK ADD  CONSTRAINT [FK_tblMuayeneIlac_tblMuayene] FOREIGN KEY([MuayeneID])
REFERENCES [dbo].[tblMuayene] ([MuayeneID])
GO
ALTER TABLE [dbo].[tblMuayeneIlac] CHECK CONSTRAINT [FK_tblMuayeneIlac_tblMuayene]
GO
ALTER TABLE [dbo].[tblMuayeneTani]  WITH CHECK ADD  CONSTRAINT [FK_tblMuayeneTani_tblMuayene] FOREIGN KEY([MuayeneID])
REFERENCES [dbo].[tblMuayene] ([MuayeneID])
GO
ALTER TABLE [dbo].[tblMuayeneTani] CHECK CONSTRAINT [FK_tblMuayeneTani_tblMuayene]
GO
ALTER TABLE [dbo].[tblMuayeneTani]  WITH CHECK ADD  CONSTRAINT [FK_tblMuayeneTani_tblTaniKatalog] FOREIGN KEY([TaniID])
REFERENCES [dbo].[tblTaniKatalog] ([TaniID])
GO
ALTER TABLE [dbo].[tblMuayeneTani] CHECK CONSTRAINT [FK_tblMuayeneTani_tblTaniKatalog]
GO
USE [master]
GO
ALTER DATABASE [FinalDbHts] SET  READ_WRITE 
GO
