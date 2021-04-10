USE [master]
GO
/****** Object:  Database [BlueBank]    Script Date: 10/04/2021 4:13:39 p. m. ******/
CREATE DATABASE [BlueBank]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BlueBank', FILENAME = N'C:\Users\Alexander\BlueBank.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BlueBank_log', FILENAME = N'C:\Users\Alexander\BlueBank_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BlueBank] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BlueBank].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BlueBank] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BlueBank] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BlueBank] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BlueBank] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BlueBank] SET ARITHABORT OFF 
GO
ALTER DATABASE [BlueBank] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BlueBank] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BlueBank] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BlueBank] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BlueBank] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BlueBank] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BlueBank] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BlueBank] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BlueBank] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BlueBank] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BlueBank] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BlueBank] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BlueBank] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BlueBank] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BlueBank] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BlueBank] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BlueBank] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BlueBank] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BlueBank] SET  MULTI_USER 
GO
ALTER DATABASE [BlueBank] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BlueBank] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BlueBank] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BlueBank] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BlueBank] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BlueBank] SET QUERY_STORE = OFF
GO
USE [BlueBank]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [BlueBank]
GO
/****** Object:  Table [dbo].[CuentaAhorros]    Script Date: 10/04/2021 4:13:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CuentaAhorros](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdentificacionPersona] [nvarchar](10) NULL,
	[NumeroCuenta] [nvarchar](10) NOT NULL,
	[Monto] [float] NULL,
	[FechaCreacion] [datetime] NULL,
 CONSTRAINT [PK_CuentaAhorros_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 10/04/2021 4:13:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[Identificacion] [nvarchar](10) NOT NULL,
	[Nombre] [nvarchar](60) NULL,
	[Apellido] [nvarchar](60) NULL,
	[IdTipoIdentificacion] [int] NULL,
	[FechaNacimeinto] [datetime] NULL,
	[Movil] [nvarchar](10) NULL,
	[FechaIngreso] [datetime] NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[Identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoIdentificacion]    Script Date: 10/04/2021 4:13:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoIdentificacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NULL,
 CONSTRAINT [PK_TipoPersonas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoTransacion]    Script Date: 10/04/2021 4:13:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoTransacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NULL,
 CONSTRAINT [PK_TipoTransacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transacciones]    Script Date: 10/04/2021 4:13:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transacciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumeroCuenta] [nvarchar](10) NULL,
	[Monto] [float] NULL,
	[IdTipoTransaccion] [int] NULL,
	[FechaTransaccion] [datetime] NULL,
 CONSTRAINT [PK_Transaciones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Personas] ADD  CONSTRAINT [DF_Personas_FechaIngreso]  DEFAULT (getdate()) FOR [FechaIngreso]
GO
ALTER TABLE [dbo].[Transacciones] ADD  CONSTRAINT [DF_Transaciones_FechaTransacion]  DEFAULT (getdate()) FOR [FechaTransaccion]
GO
USE [master]
GO
ALTER DATABASE [BlueBank] SET  READ_WRITE 
GO
