USE [master]
GO
/****** Object:  Database [UventaArenda]    Script Date: 21.05.2023 10:15:35 ******/
CREATE DATABASE [UventaArenda]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UventaArenda', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\UventaArenda.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UventaArenda_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\UventaArenda_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [UventaArenda] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UventaArenda].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UventaArenda] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UventaArenda] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UventaArenda] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UventaArenda] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UventaArenda] SET ARITHABORT OFF 
GO
ALTER DATABASE [UventaArenda] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UventaArenda] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UventaArenda] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UventaArenda] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UventaArenda] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UventaArenda] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UventaArenda] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UventaArenda] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UventaArenda] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UventaArenda] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UventaArenda] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UventaArenda] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UventaArenda] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UventaArenda] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UventaArenda] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UventaArenda] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UventaArenda] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UventaArenda] SET RECOVERY FULL 
GO
ALTER DATABASE [UventaArenda] SET  MULTI_USER 
GO
ALTER DATABASE [UventaArenda] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UventaArenda] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UventaArenda] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UventaArenda] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UventaArenda] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UventaArenda] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [UventaArenda] SET QUERY_STORE = OFF
GO
USE [UventaArenda]
GO
/****** Object:  Table [dbo].[Building]    Script Date: 21.05.2023 10:15:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Building](
	[BuildingId] [int] NOT NULL,
	[BuildingName] [nvarchar](300) NOT NULL,
	[Address] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK__Building__5463CDC4B227ABD7] PRIMARY KEY CLUSTERED 
(
	[BuildingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rent]    Script Date: 21.05.2023 10:15:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rent](
	[RentId] [int] IDENTITY(1,1) NOT NULL,
	[RentalObjectId] [int] NOT NULL,
	[TenantId] [int] NOT NULL,
	[ContractCreationDate] [date] NOT NULL,
	[ContractStartDate] [date] NOT NULL,
	[ContractEndDate] [date] NOT NULL,
 CONSTRAINT [PK__Rent__783D47F55D08CAAB] PRIMARY KEY CLUSTERED 
(
	[RentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentalObject]    Script Date: 21.05.2023 10:15:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentalObject](
	[RentalObjectId] [int] IDENTITY(0,1) NOT NULL,
	[BuildingId] [int] NOT NULL,
	[ObjectNumber] [int] NOT NULL,
	[Area] [float] NOT NULL,
	[RentalPrice] [money] NOT NULL,
 CONSTRAINT [PK_RentalObject] PRIMARY KEY CLUSTERED 
(
	[RentalObjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentalType]    Script Date: 21.05.2023 10:15:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentalType](
	[RentalTypeId] [int] NOT NULL,
	[RentalTypeName] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK__RentalTy__DECD55EE4CFAEFA1] PRIMARY KEY CLUSTERED 
(
	[RentalTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 21.05.2023 10:15:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] NOT NULL,
	[RoleName] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK__Role__8AFACE1A06030752] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tenant]    Script Date: 21.05.2023 10:15:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tenant](
	[TenantId] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](300) NOT NULL,
	[FirstName] [nvarchar](300) NOT NULL,
	[RentalTypeId] [int] NOT NULL,
	[RegistrationAddress] [nvarchar](300) NOT NULL,
	[PhoneNumber] [nvarchar](300) NOT NULL,
	[Email] [nvarchar](300) NOT NULL,
	[PassportSeries] [nvarchar](300) NOT NULL,
	[PassportNumber] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK__Tenant__2E9B47E120FDAA01] PRIMARY KEY CLUSTERED 
(
	[TenantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 21.05.2023 10:15:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[FullName] [nvarchar](300) NOT NULL,
	[Login] [nvarchar](300) NOT NULL,
	[Password] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK__User__1788CC4CAAAB3322] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Building] ([BuildingId], [BuildingName], [Address]) VALUES (1, N'Здание', N'Кунгур')
INSERT [dbo].[Building] ([BuildingId], [BuildingName], [Address]) VALUES (2, N'Parrot', N'aaa')
GO
INSERT [dbo].[RentalType] ([RentalTypeId], [RentalTypeName]) VALUES (0, N'Физическое лицо')
INSERT [dbo].[RentalType] ([RentalTypeId], [RentalTypeName]) VALUES (1, N'Юридическое лицо')
GO
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (0, N'Админестратор')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (1, N'Менеджер')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (2, N'Директор')
GO
SET IDENTITY_INSERT [dbo].[Tenant] ON 

INSERT [dbo].[Tenant] ([TenantId], [LastName], [FirstName], [RentalTypeId], [RegistrationAddress], [PhoneNumber], [Email], [PassportSeries], [PassportNumber]) VALUES (1, N'Иванов', N'Максим', 0, N'г.Кунгур, ул. Свободы 19', N'8943234', N'maxivanov@gmail.com', N'3213', N'34235')
INSERT [dbo].[Tenant] ([TenantId], [LastName], [FirstName], [RentalTypeId], [RegistrationAddress], [PhoneNumber], [Email], [PassportSeries], [PassportNumber]) VALUES (1004, N'Маврий', N'Никос', 1, N'Кунгур', N'8994234', N'nixm@gmail.com', N'12412', N'123213')
SET IDENTITY_INSERT [dbo].[Tenant] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [RoleId], [FullName], [Login], [Password]) VALUES (2, 0, N'Иванов Иван Иванович', N'admin', N'1234')
INSERT [dbo].[User] ([UserId], [RoleId], [FullName], [Login], [Password]) VALUES (3, 1, N'Петров Петр Петрович', N'manager', N'1234')
INSERT [dbo].[User] ([UserId], [RoleId], [FullName], [Login], [Password]) VALUES (4, 1, N'Сидоров Сидор Сидорович', N'manager2', N'oP9iJk2HnM')
INSERT [dbo].[User] ([UserId], [RoleId], [FullName], [Login], [Password]) VALUES (5, 1, N'Козлова Екатерина Александровна', N'manager3', N'KjHn8LmO7p')
INSERT [dbo].[User] ([UserId], [RoleId], [FullName], [Login], [Password]) VALUES (6, 2, N'Николаев Николай Николаевич', N'director', N'1234')
INSERT [dbo].[User] ([UserId], [RoleId], [FullName], [Login], [Password]) VALUES (7, 2, N'Антонова Мария Владимировна', N'director2', N'Mk9iLn7Op1')
INSERT [dbo].[User] ([UserId], [RoleId], [FullName], [Login], [Password]) VALUES (8, 2, N'Захаров Владимир Алексеевич', N'director3', N'jH8kIn6LmN')
INSERT [dbo].[User] ([UserId], [RoleId], [FullName], [Login], [Password]) VALUES (9, 1, N'Иванова Ольга Васильевна', N'manager4', N'pO9iJk3HnM')
INSERT [dbo].[User] ([UserId], [RoleId], [FullName], [Login], [Password]) VALUES (10, 0, N'Сидорова Анна Сергеевна', N'admin2', N'hU1kIn8LmN')
INSERT [dbo].[User] ([UserId], [RoleId], [FullName], [Login], [Password]) VALUES (11, 1, N'Петрова Елена Николаевна', N'manager5', N'jH0kLm9InP')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Rent]  WITH CHECK ADD  CONSTRAINT [FK_Rent_RentalObject] FOREIGN KEY([RentalObjectId])
REFERENCES [dbo].[RentalObject] ([RentalObjectId])
GO
ALTER TABLE [dbo].[Rent] CHECK CONSTRAINT [FK_Rent_RentalObject]
GO
ALTER TABLE [dbo].[Rent]  WITH CHECK ADD  CONSTRAINT [FK_Rent_Tenant] FOREIGN KEY([TenantId])
REFERENCES [dbo].[Tenant] ([TenantId])
GO
ALTER TABLE [dbo].[Rent] CHECK CONSTRAINT [FK_Rent_Tenant]
GO
ALTER TABLE [dbo].[RentalObject]  WITH CHECK ADD  CONSTRAINT [FK_RentalObject_Building] FOREIGN KEY([BuildingId])
REFERENCES [dbo].[Building] ([BuildingId])
GO
ALTER TABLE [dbo].[RentalObject] CHECK CONSTRAINT [FK_RentalObject_Building]
GO
ALTER TABLE [dbo].[Tenant]  WITH CHECK ADD  CONSTRAINT [FK_Tenant_RentalType] FOREIGN KEY([RentalTypeId])
REFERENCES [dbo].[RentalType] ([RentalTypeId])
GO
ALTER TABLE [dbo].[Tenant] CHECK CONSTRAINT [FK_Tenant_RentalType]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [UventaArenda] SET  READ_WRITE 
GO
