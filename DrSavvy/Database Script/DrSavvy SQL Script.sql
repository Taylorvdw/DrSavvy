USE [master]
GO
/****** Object:  Database [DrSavvy]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE DATABASE [DrSavvy]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DrSavvy', FILENAME = N'D:\Visual Studio\SQL\MSSQL15.MSSQLSERVER\MSSQL\DATA\DrSavvy.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DrSavvy_log', FILENAME = N'D:\Visual Studio\SQL\MSSQL15.MSSQLSERVER\MSSQL\DATA\DrSavvy_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DrSavvy] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DrSavvy].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DrSavvy] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DrSavvy] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DrSavvy] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DrSavvy] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DrSavvy] SET ARITHABORT OFF 
GO
ALTER DATABASE [DrSavvy] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DrSavvy] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DrSavvy] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DrSavvy] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DrSavvy] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DrSavvy] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DrSavvy] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DrSavvy] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DrSavvy] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DrSavvy] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DrSavvy] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DrSavvy] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DrSavvy] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DrSavvy] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DrSavvy] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DrSavvy] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DrSavvy] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DrSavvy] SET RECOVERY FULL 
GO
ALTER DATABASE [DrSavvy] SET  MULTI_USER 
GO
ALTER DATABASE [DrSavvy] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DrSavvy] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DrSavvy] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DrSavvy] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DrSavvy] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DrSavvy] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DrSavvy', N'ON'
GO
ALTER DATABASE [DrSavvy] SET QUERY_STORE = OFF
GO
USE [DrSavvy]
GO
/****** Object:  Table [dbo].[Access_Control]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Access_Control](
	[AccessID] [int] IDENTITY(1,1) NOT NULL,
	[AC_Name] [varchar](50) NOT NULL,
	[AC_Description] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Access_Control] PRIMARY KEY CLUSTERED 
(
	[AccessID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ailments]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ailments](
	[Ailment_ID] [int] IDENTITY(1,1) NOT NULL,
	[ICD10] [varchar](50) NOT NULL,
	[Ailment_Name] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Ailments] PRIMARY KEY CLUSTERED 
(
	[Ailment_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Allergies]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Allergies](
	[Allergy_ID] [int] IDENTITY(1,1) NOT NULL,
	[Allergy_Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Allergies] PRIMARY KEY CLUSTERED 
(
	[Allergy_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[Appointment_ID] [int] IDENTITY(1,1) NOT NULL,
	[AppointmentDate] [datetime] NOT NULL,
	[Patient_ID] [int] NOT NULL,
	[Timeslot_ID] [int] NOT NULL,
	[AppointmentDescription] [varchar](max) NULL,
	[ThemeColor] [varchar](50) NULL,
	[IsFullDay] [bit] NULL,
	[AppointmentStatus] [varchar](50) NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[Appointment_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[AspNetRoles_Id] [nvarchar](128) NOT NULL,
	[AspNetUsers_Id] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[AspNetRoles_Id] ASC,
	[AspNetUsers_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Backlogs]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Backlogs](
	[BacklogID] [int] IDENTITY(1,1) NOT NULL,
	[Backlog_Description] [varchar](30) NOT NULL,
	[OrderID] [int] NOT NULL,
	[OrderLineID] [int] NULL,
	[BacklogQty] [decimal](10, 2) NULL,
 CONSTRAINT [PK_Backlogs] PRIMARY KEY CLUSTERED 
(
	[BacklogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[C__MigrationHistory]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[C__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_C__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Consultation_Ailment]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consultation_Ailment](
	[Consultation_ID] [int] NOT NULL,
	[Ailment_ID] [int] NOT NULL,
	[Notes] [varchar](50) NULL,
 CONSTRAINT [PK_Consultation_Ailment] PRIMARY KEY CLUSTERED 
(
	[Consultation_ID] ASC,
	[Ailment_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Consultation_Procedure]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consultation_Procedure](
	[Consultation_ProcedureID] [int] IDENTITY(1,1) NOT NULL,
	[Consultation_ID] [int] NOT NULL,
	[Procedure_ID] [int] NOT NULL,
	[ProcedureNotes] [varchar](max) NULL,
	[Appointment_ID] [int] NULL,
 CONSTRAINT [PK_Consultation_Procedure] PRIMARY KEY CLUSTERED 
(
	[Consultation_ProcedureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Consultations]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consultations](
	[Consultation_ID] [int] IDENTITY(1,1) NOT NULL,
	[Comments] [varchar](255) NOT NULL,
	[Patient_ID] [int] NULL,
	[Appointment_ID] [int] NULL,
 CONSTRAINT [PK_Consultations] PRIMARY KEY CLUSTERED 
(
	[Consultation_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[database_firewall_rules]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[database_firewall_rules](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](128) NOT NULL,
	[start_ip_address] [varchar](45) NOT NULL,
	[end_ip_address] [varchar](45) NOT NULL,
	[create_date] [datetime] NOT NULL,
	[modify_date] [datetime] NOT NULL,
 CONSTRAINT [PK_database_firewall_rules] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[name] ASC,
	[start_ip_address] ASC,
	[end_ip_address] ASC,
	[create_date] ASC,
	[modify_date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee_Role]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee_Role](
	[EMP_Role_ID] [int] IDENTITY(1,1) NOT NULL,
	[Emp_Role_Description] [varchar](255) NOT NULL,
	[AccessID] [int] NULL,
 CONSTRAINT [PK_Employee_Role] PRIMARY KEY CLUSTERED 
(
	[EMP_Role_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EMP_ID] [int] IDENTITY(1,1) NOT NULL,
	[EMPName] [varchar](50) NOT NULL,
	[EMPSurname] [varchar](50) NOT NULL,
	[EMP_CellphoneNum] [varchar](15) NOT NULL,
	[EMP_Email] [varchar](50) NOT NULL,
	[Emp_IDNum] [varchar](13) NOT NULL,
	[EMP_Role_ID] [int] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EMP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Institute_Type]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Institute_Type](
	[Institute_Type_ID] [int] IDENTITY(1,1) NOT NULL,
	[Institute_Type_Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Institute_Type] PRIMARY KEY CLUSTERED 
(
	[Institute_Type_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Institutes]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Institutes](
	[Institute_ID] [int] IDENTITY(1,1) NOT NULL,
	[Institute_Name] [varchar](50) NOT NULL,
	[Institute_Type_ID] [int] NOT NULL,
	[Institute_ContactPerson] [varchar](50) NULL,
	[Instsitute_ContactNumber] [varchar](50) NULL,
 CONSTRAINT [PK_Institutes] PRIMARY KEY CLUSTERED 
(
	[Institute_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medical_Aid_Claim]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medical_Aid_Claim](
	[Medical_Aid_Claim_ID] [int] IDENTITY(1,1) NOT NULL,
	[Claim_Amount] [decimal](10, 2) NOT NULL,
	[Claim_Date] [datetime] NOT NULL,
	[Claim_Description] [varchar](255) NOT NULL,
	[Payment_ID] [int] NULL,
	[Consultation_ID] [int] NOT NULL,
	[ClaimStatus] [varchar](20) NULL,
 CONSTRAINT [PK_Medical_Aid_Claim] PRIMARY KEY CLUSTERED 
(
	[Medical_Aid_Claim_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medical_Aid_Company]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medical_Aid_Company](
	[Company_ID] [int] IDENTITY(1,1) NOT NULL,
	[Company_Name] [varchar](50) NOT NULL,
	[ContactPerson] [varchar](50) NOT NULL,
	[Contact_Number] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Medical_Aid_Company] PRIMARY KEY CLUSTERED 
(
	[Company_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medical_Aid_Scheme]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medical_Aid_Scheme](
	[Scheme_ID] [int] IDENTITY(1,1) NOT NULL,
	[Scheme_Name] [varchar](50) NOT NULL,
	[Company_ID] [int] NOT NULL,
 CONSTRAINT [PK_Medical_Aid_Scheme] PRIMARY KEY CLUSTERED 
(
	[Scheme_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medications]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medications](
	[Medication_ID] [int] IDENTITY(1,1) NOT NULL,
	[Mediction_Description] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Medications] PRIMARY KEY CLUSTERED 
(
	[Medication_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MobileApps]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MobileApps](
	[MobileAppID] [int] IDENTITY(1,1) NOT NULL,
	[AppointmentID] [int] NOT NULL,
	[AppDate] [varchar](max) NULL,
	[StartTime] [varchar](max) NULL,
	[EndTime] [varchar](max) NULL,
	[PatientName] [varchar](max) NULL,
	[PatientSurname] [varchar](max) NULL,
	[AppDescr] [varchar](max) NULL,
	[StartDateTime] [varchar](max) NULL,
	[EndDateTime] [varchar](max) NULL,
	[FullName] [varchar](max) NULL,
 CONSTRAINT [PK_MobileApps] PRIMARY KEY CLUSTERED 
(
	[MobileAppID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Line]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Line](
	[OrderLineID] [int] IDENTITY(1,1) NOT NULL,
	[Prod_Qty] [decimal](10, 2) NOT NULL,
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[ReceivedQty] [decimal](10, 0) NULL,
 CONSTRAINT [PK_Order_Line] PRIMARY KEY CLUSTERED 
(
	[OrderLineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Payment]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Payment](
	[Order_Payment_ID] [int] IDENTITY(1,1) NOT NULL,
	[Order_Payment_Date] [datetime] NOT NULL,
	[Order_Payment_Amount] [decimal](10, 2) NOT NULL,
	[OrderID] [int] NOT NULL,
	[Payment_Type_ID] [int] NOT NULL,
	[ReceiptNumber] [varchar](20) NULL,
	[TransactionNumber] [varchar](20) NULL,
 CONSTRAINT [PK_Order_Payment] PRIMARY KEY CLUSTERED 
(
	[Order_Payment_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Status]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Status](
	[OS_ID] [int] IDENTITY(1,1) NOT NULL,
	[OS_Description] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Order_Status] PRIMARY KEY CLUSTERED 
(
	[OS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[Order_Cost] [decimal](10, 2) NOT NULL,
	[OS_ID] [int] NOT NULL,
	[Supplier_ID] [int] NOT NULL,
	[Order_Date] [datetime] NULL,
	[PaidStatus] [bit] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient_Allergy_List]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient_Allergy_List](
	[PatientAllergyID] [int] IDENTITY(1,1) NOT NULL,
	[Patient_ID] [int] NOT NULL,
	[Allergy_ID] [int] NOT NULL,
 CONSTRAINT [PK_Patient_Allergy_List] PRIMARY KEY CLUSTERED 
(
	[PatientAllergyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[Patient_ID] [int] IDENTITY(1,1) NOT NULL,
	[PatientName] [varchar](50) NOT NULL,
	[PatientSurname] [varchar](50) NOT NULL,
	[PatientCell] [varchar](15) NULL,
	[PatientWorkNum] [varchar](15) NULL,
	[PatientTelNum] [varchar](15) NULL,
	[PatientEmail] [varchar](50) NULL,
	[PatientPoBox] [varchar](255) NULL,
	[PatientHomeAddress] [varchar](255) NULL,
	[PatientIDNum] [varchar](13) NULL,
	[PatientPassportNum] [varchar](9) NULL,
	[MedicalAidNo] [varchar](30) NULL,
	[DependentNo] [int] NULL,
	[Scheme_ID] [int] NULL,
	[Title_ID] [int] NULL,
	[DOB] [datetime] NULL,
	[Gender] [varchar](15) NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[Patient_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment_Type]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment_Type](
	[Payment_Type_ID] [int] IDENTITY(1,1) NOT NULL,
	[Payment_Type_Description] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Payment_Type] PRIMARY KEY CLUSTERED 
(
	[Payment_Type_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Payment_ID] [int] IDENTITY(1,1) NOT NULL,
	[Payment_Amount] [decimal](10, 2) NOT NULL,
	[Consultation_ID] [int] NOT NULL,
	[Payment_Type_ID] [int] NOT NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[Payment_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prescription_Line]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prescription_Line](
	[PrescriptionLineID] [int] IDENTITY(1,1) NOT NULL,
	[Perscription_Date] [datetime] NULL,
	[Intake] [varchar](50) NULL,
	[ValidUntil] [datetime] NULL,
	[Consultation_ID] [int] NOT NULL,
	[Medication_ID] [int] NULL,
	[Patient_ID] [int] NULL,
 CONSTRAINT [PK_Prescription_Line] PRIMARY KEY CLUSTERED 
(
	[PrescriptionLineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prices]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prices](
	[PriceID] [int] IDENTITY(1,1) NOT NULL,
	[Price_Figure] [decimal](10, 2) NOT NULL,
	[Date_Initiated] [datetime] NOT NULL,
	[ProductID] [int] NOT NULL,
 CONSTRAINT [PK_Prices] PRIMARY KEY CLUSTERED 
(
	[PriceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Procedures]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Procedures](
	[Procedure_ID] [int] NOT NULL,
	[Procedure_Description] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Procedures] PRIMARY KEY CLUSTERED 
(
	[Procedure_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Procedure]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Procedure](
	[ProductProcedureID] [int] IDENTITY(1,1) NOT NULL,
	[Procedure_ID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
 CONSTRAINT [PK_Product_Procedure] PRIMARY KEY CLUSTERED 
(
	[ProductProcedureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Type]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Type](
	[Product_Type_ID] [int] IDENTITY(1,1) NOT NULL,
	[Product_Type_Description] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Product_Type] PRIMARY KEY CLUSTERED 
(
	[Product_Type_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](100) NOT NULL,
	[Product_Qty] [decimal](10, 2) NOT NULL,
	[Product_Type_ID] [int] NOT NULL,
	[Product_Disable] [bit] NOT NULL,
	[Supplier_ID] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reconcilliations]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reconcilliations](
	[ReconID] [int] IDENTITY(1,1) NOT NULL,
	[RealisedQty] [decimal](10, 2) NOT NULL,
	[ReasonDescription] [varchar](255) NOT NULL,
	[ProductID] [int] NOT NULL,
 CONSTRAINT [PK_Reconcilliations] PRIMARY KEY CLUSTERED 
(
	[ReconID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Referral_Test]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Referral_Test](
	[ReferralTestID] [int] IDENTITY(1,1) NOT NULL,
	[Ref_ID] [int] NOT NULL,
	[TestRemarks] [varchar](255) NOT NULL,
	[TestID] [int] NOT NULL,
	[Institute_ID] [int] NULL,
 CONSTRAINT [PK_Referral_Test] PRIMARY KEY CLUSTERED 
(
	[ReferralTestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Referrals]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Referrals](
	[Ref_ID] [int] IDENTITY(1,1) NOT NULL,
	[Comment] [varchar](255) NOT NULL,
	[Consultation_ID] [int] NOT NULL,
 CONSTRAINT [PK_Referrals] PRIMARY KEY CLUSTERED 
(
	[Ref_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sick_Note]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sick_Note](
	[SN__ID] [int] IDENTITY(1,1) NOT NULL,
	[SN__Description] [varchar](255) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[DateGenerated] [datetime] NOT NULL,
	[Consultation_ID] [int] NULL,
 CONSTRAINT [PK_Sick_Note] PRIMARY KEY CLUSTERED 
(
	[SN__ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock_Take]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock_Take](
	[StockTake_ID] [int] IDENTITY(1,1) NOT NULL,
	[ST_Date] [datetime] NOT NULL,
	[ST_Quantity] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Stock_Take] PRIMARY KEY CLUSTERED 
(
	[StockTake_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock_take_Line]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock_take_Line](
	[Stock_Take_Line_ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[StockTake_ID] [int] NOT NULL,
 CONSTRAINT [PK_Stock_take_Line] PRIMARY KEY CLUSTERED 
(
	[Stock_Take_Line_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[Supplier_ID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierName] [varchar](50) NOT NULL,
	[SupplierEmail] [varchar](50) NOT NULL,
	[SupplierAddress] [varchar](255) NOT NULL,
	[SupplierContactPerson] [varchar](100) NOT NULL,
	[SupplierCellNumber] [varchar](15) NOT NULL,
	[SupplierWorkNumber] [varchar](15) NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[Supplier_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test_Type]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test_Type](
	[Test_Type_ID] [int] IDENTITY(1,1) NOT NULL,
	[Test_Type_Name] [varchar](50) NOT NULL,
	[Test_Type_Description] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Test_Type] PRIMARY KEY CLUSTERED 
(
	[Test_Type_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tests]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tests](
	[TestID] [int] IDENTITY(1,1) NOT NULL,
	[TestName] [varchar](100) NOT NULL,
	[TestDescription] [varchar](255) NOT NULL,
	[Test_Type_ID] [int] NOT NULL,
	[test_Disable] [binary](1) NOT NULL,
 CONSTRAINT [PK_Tests] PRIMARY KEY CLUSTERED 
(
	[TestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Timeslots]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Timeslots](
	[Timeslot_ID] [int] IDENTITY(1,1) NOT NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
 CONSTRAINT [PK_Timeslots] PRIMARY KEY CLUSTERED 
(
	[Timeslot_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Titles]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Titles](
	[Title_ID] [int] IDENTITY(1,1) NOT NULL,
	[Title_Description] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Titles] PRIMARY KEY CLUSTERED 
(
	[Title_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[User_ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[EMP_ID] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Xrays]    Script Date: 2021/02/22 9:52:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Xrays](
	[XrayID] [int] IDENTITY(1,1) NOT NULL,
	[Patient_ID] [int] NULL,
	[Consultation_ID] [int] NULL,
	[Title] [varchar](250) NULL,
	[ImagePath] [varchar](max) NULL,
 CONSTRAINT [PK_Xrays] PRIMARY KEY CLUSTERED 
(
	[XrayID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Appointme__Times__2DE6D218]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Appointme__Times__2DE6D218] ON [dbo].[Appointments]
(
	[Timeslot_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Appointment_Patient]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK_Appointment_Patient] ON [dbo].[Appointments]
(
	[Patient_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_FK_AspNetUserRoles_AspNetUser]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK_AspNetUserRoles_AspNetUser] ON [dbo].[AspNetUserRoles]
(
	[AspNetUsers_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Backlog__OrderID__339FAB6E]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Backlog__OrderID__339FAB6E] ON [dbo].[Backlogs]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Backlog_Order_Line]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK_Backlog_Order_Line] ON [dbo].[Backlogs]
(
	[OrderLineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Consultat__Ailme__3864608B]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Consultat__Ailme__3864608B] ON [dbo].[Consultation_Ailment]
(
	[Ailment_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Consultat__Appoi__395884C4]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Consultat__Appoi__395884C4] ON [dbo].[Consultation_Procedure]
(
	[Appointment_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Consultat__Consu__3A4CA8FD]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Consultat__Consu__3A4CA8FD] ON [dbo].[Consultation_Procedure]
(
	[Consultation_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Consultat__Proce__3B40CD36]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Consultat__Proce__3B40CD36] ON [dbo].[Consultation_Procedure]
(
	[Procedure_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Consultat__Appoi__3587F3E0]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Consultat__Appoi__3587F3E0] ON [dbo].[Consultations]
(
	[Appointment_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Consultation_Patient]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK_Consultation_Patient] ON [dbo].[Consultations]
(
	[Patient_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Employee___Acces__3D2915A8]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Employee___Acces__3D2915A8] ON [dbo].[Employee_Role]
(
	[AccessID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Employee__EMP_Ro__3C34F16F]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Employee__EMP_Ro__3C34F16F] ON [dbo].[Employees]
(
	[EMP_Role_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Institute__Insti__3E1D39E1]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Institute__Insti__3E1D39E1] ON [dbo].[Institutes]
(
	[Institute_Type_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Medical_A__Consu__40058253]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Medical_A__Consu__40058253] ON [dbo].[Medical_Aid_Claim]
(
	[Consultation_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Medical_A__Payme__3F115E1A]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Medical_A__Payme__3F115E1A] ON [dbo].[Medical_Aid_Claim]
(
	[Payment_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Medical_A__Compa__40F9A68C]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Medical_A__Compa__40F9A68C] ON [dbo].[Medical_Aid_Scheme]
(
	[Company_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Order_Lin__Order__43D61337]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Order_Lin__Order__43D61337] ON [dbo].[Order_Line]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Order_Line_Product]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK_Order_Line_Product] ON [dbo].[Order_Line]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Order_Pay__Order__45BE5BA9]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Order_Pay__Order__45BE5BA9] ON [dbo].[Order_Payment]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Order_Pay__Payme__31B762FC]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Order_Pay__Payme__31B762FC] ON [dbo].[Order_Payment]
(
	[Payment_Type_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Order__OS_ID__41EDCAC5]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Order__OS_ID__41EDCAC5] ON [dbo].[Orders]
(
	[OS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Order__Supplier___42E1EEFE]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Order__Supplier___42E1EEFE] ON [dbo].[Orders]
(
	[Supplier_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Patient_A__Aller__4B7734FF]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Patient_A__Aller__4B7734FF] ON [dbo].[Patient_Allergy_List]
(
	[Allergy_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Patient_Allergy_List_Patient]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK_Patient_Allergy_List_Patient] ON [dbo].[Patient_Allergy_List]
(
	[Patient_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Patient__Depende__47A6A41B]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Patient__Depende__47A6A41B] ON [dbo].[Patients]
(
	[DependentNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Patient__Scheme___489AC854]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Patient__Scheme___489AC854] ON [dbo].[Patients]
(
	[Scheme_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Patient__Title_I__498EEC8D]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Patient__Title_I__498EEC8D] ON [dbo].[Patients]
(
	[Title_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Payment__Consult__4E53A1AA]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Payment__Consult__4E53A1AA] ON [dbo].[Payments]
(
	[Consultation_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Payment__Payment__4D5F7D71]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Payment__Payment__4D5F7D71] ON [dbo].[Payments]
(
	[Payment_Type_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Prescript__Consu__503BEA1C]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Prescript__Consu__503BEA1C] ON [dbo].[Prescription_Line]
(
	[Consultation_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Prescript__Medic__4F47C5E3]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Prescript__Medic__4F47C5E3] ON [dbo].[Prescription_Line]
(
	[Medication_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Prescription_Line_Patient]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK_Prescription_Line_Patient] ON [dbo].[Prescription_Line]
(
	[Patient_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Price_Product]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK_Price_Product] ON [dbo].[Prices]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Product_P__Proce__55009F39]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Product_P__Proce__55009F39] ON [dbo].[Product_Procedure]
(
	[Procedure_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Product_Procedure_Product]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK_Product_Procedure_Product] ON [dbo].[Product_Procedure]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Product__Product__531856C7]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Product__Product__531856C7] ON [dbo].[Products]
(
	[Product_Type_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Product_Supplier]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK_Product_Supplier] ON [dbo].[Products]
(
	[Supplier_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Reconcilliation_Product]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK_Reconcilliation_Product] ON [dbo].[Reconcilliations]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Referral___Ref_I__59C55456]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Referral___Ref_I__59C55456] ON [dbo].[Referral_Test]
(
	[Ref_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Referral___TestI__58D1301D]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Referral___TestI__58D1301D] ON [dbo].[Referral_Test]
(
	[TestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Referral_Test_Institute]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK_Referral_Test_Institute] ON [dbo].[Referral_Test]
(
	[Institute_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Referral__Consul__57DD0BE4]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Referral__Consul__57DD0BE4] ON [dbo].[Referrals]
(
	[Consultation_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Sick_Note__Consu__5BAD9CC8]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Sick_Note__Consu__5BAD9CC8] ON [dbo].[Sick_Note]
(
	[Consultation_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Stock_tak__Produ__5CA1C101]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Stock_tak__Produ__5CA1C101] ON [dbo].[Stock_take_Line]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Stock_tak__Stock__5D95E53A]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Stock_tak__Stock__5D95E53A] ON [dbo].[Stock_take_Line]
(
	[StockTake_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Test__Test_Type___5E8A0973]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Test__Test_Type___5E8A0973] ON [dbo].[Tests]
(
	[Test_Type_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__User__EMP_ID__5F7E2DAC]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__User__EMP_ID__5F7E2DAC] ON [dbo].[Users]
(
	[EMP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__Xrays__Consultat__607251E5]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__Xrays__Consultat__607251E5] ON [dbo].[Xrays]
(
	[Consultation_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Xrays_Patient]    Script Date: 2021/02/22 9:52:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK_Xrays_Patient] ON [dbo].[Xrays]
(
	[Patient_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK__Appointme__Times__2DE6D218] FOREIGN KEY([Timeslot_ID])
REFERENCES [dbo].[Timeslots] ([Timeslot_ID])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK__Appointme__Times__2DE6D218]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Patient] FOREIGN KEY([Patient_ID])
REFERENCES [dbo].[Patients] ([Patient_ID])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointment_Patient]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRole] FOREIGN KEY([AspNetRoles_Id])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRole]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUser] FOREIGN KEY([AspNetUsers_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUser]
GO
ALTER TABLE [dbo].[Backlogs]  WITH CHECK ADD  CONSTRAINT [FK__Backlog__OrderID__339FAB6E] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[Backlogs] CHECK CONSTRAINT [FK__Backlog__OrderID__339FAB6E]
GO
ALTER TABLE [dbo].[Backlogs]  WITH CHECK ADD  CONSTRAINT [FK_Backlog_Order_Line] FOREIGN KEY([OrderLineID])
REFERENCES [dbo].[Order_Line] ([OrderLineID])
GO
ALTER TABLE [dbo].[Backlogs] CHECK CONSTRAINT [FK_Backlog_Order_Line]
GO
ALTER TABLE [dbo].[Consultation_Ailment]  WITH CHECK ADD  CONSTRAINT [FK__Consultat__Ailme__3864608B] FOREIGN KEY([Ailment_ID])
REFERENCES [dbo].[Ailments] ([Ailment_ID])
GO
ALTER TABLE [dbo].[Consultation_Ailment] CHECK CONSTRAINT [FK__Consultat__Ailme__3864608B]
GO
ALTER TABLE [dbo].[Consultation_Ailment]  WITH CHECK ADD  CONSTRAINT [FK__Consultat__Consu__37703C52] FOREIGN KEY([Consultation_ID])
REFERENCES [dbo].[Consultations] ([Consultation_ID])
GO
ALTER TABLE [dbo].[Consultation_Ailment] CHECK CONSTRAINT [FK__Consultat__Consu__37703C52]
GO
ALTER TABLE [dbo].[Consultation_Procedure]  WITH CHECK ADD  CONSTRAINT [FK__Consultat__Appoi__395884C4] FOREIGN KEY([Appointment_ID])
REFERENCES [dbo].[Appointments] ([Appointment_ID])
GO
ALTER TABLE [dbo].[Consultation_Procedure] CHECK CONSTRAINT [FK__Consultat__Appoi__395884C4]
GO
ALTER TABLE [dbo].[Consultation_Procedure]  WITH CHECK ADD  CONSTRAINT [FK__Consultat__Consu__3A4CA8FD] FOREIGN KEY([Consultation_ID])
REFERENCES [dbo].[Consultations] ([Consultation_ID])
GO
ALTER TABLE [dbo].[Consultation_Procedure] CHECK CONSTRAINT [FK__Consultat__Consu__3A4CA8FD]
GO
ALTER TABLE [dbo].[Consultation_Procedure]  WITH CHECK ADD  CONSTRAINT [FK__Consultat__Proce__3B40CD36] FOREIGN KEY([Procedure_ID])
REFERENCES [dbo].[Procedures] ([Procedure_ID])
GO
ALTER TABLE [dbo].[Consultation_Procedure] CHECK CONSTRAINT [FK__Consultat__Proce__3B40CD36]
GO
ALTER TABLE [dbo].[Consultations]  WITH CHECK ADD  CONSTRAINT [FK__Consultat__Appoi__3587F3E0] FOREIGN KEY([Appointment_ID])
REFERENCES [dbo].[Appointments] ([Appointment_ID])
GO
ALTER TABLE [dbo].[Consultations] CHECK CONSTRAINT [FK__Consultat__Appoi__3587F3E0]
GO
ALTER TABLE [dbo].[Consultations]  WITH CHECK ADD  CONSTRAINT [FK_Consultation_Patient] FOREIGN KEY([Patient_ID])
REFERENCES [dbo].[Patients] ([Patient_ID])
GO
ALTER TABLE [dbo].[Consultations] CHECK CONSTRAINT [FK_Consultation_Patient]
GO
ALTER TABLE [dbo].[Employee_Role]  WITH CHECK ADD  CONSTRAINT [FK__Employee___Acces__3D2915A8] FOREIGN KEY([AccessID])
REFERENCES [dbo].[Access_Control] ([AccessID])
GO
ALTER TABLE [dbo].[Employee_Role] CHECK CONSTRAINT [FK__Employee___Acces__3D2915A8]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK__Employee__EMP_Ro__3C34F16F] FOREIGN KEY([EMP_Role_ID])
REFERENCES [dbo].[Employee_Role] ([EMP_Role_ID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK__Employee__EMP_Ro__3C34F16F]
GO
ALTER TABLE [dbo].[Institutes]  WITH CHECK ADD  CONSTRAINT [FK__Institute__Insti__3E1D39E1] FOREIGN KEY([Institute_Type_ID])
REFERENCES [dbo].[Institute_Type] ([Institute_Type_ID])
GO
ALTER TABLE [dbo].[Institutes] CHECK CONSTRAINT [FK__Institute__Insti__3E1D39E1]
GO
ALTER TABLE [dbo].[Medical_Aid_Claim]  WITH CHECK ADD  CONSTRAINT [FK__Medical_A__Consu__40058253] FOREIGN KEY([Consultation_ID])
REFERENCES [dbo].[Consultations] ([Consultation_ID])
GO
ALTER TABLE [dbo].[Medical_Aid_Claim] CHECK CONSTRAINT [FK__Medical_A__Consu__40058253]
GO
ALTER TABLE [dbo].[Medical_Aid_Claim]  WITH CHECK ADD  CONSTRAINT [FK__Medical_A__Payme__3F115E1A] FOREIGN KEY([Payment_ID])
REFERENCES [dbo].[Payments] ([Payment_ID])
GO
ALTER TABLE [dbo].[Medical_Aid_Claim] CHECK CONSTRAINT [FK__Medical_A__Payme__3F115E1A]
GO
ALTER TABLE [dbo].[Medical_Aid_Scheme]  WITH CHECK ADD  CONSTRAINT [FK__Medical_A__Compa__40F9A68C] FOREIGN KEY([Company_ID])
REFERENCES [dbo].[Medical_Aid_Company] ([Company_ID])
GO
ALTER TABLE [dbo].[Medical_Aid_Scheme] CHECK CONSTRAINT [FK__Medical_A__Compa__40F9A68C]
GO
ALTER TABLE [dbo].[Order_Line]  WITH CHECK ADD  CONSTRAINT [FK__Order_Lin__Order__43D61337] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[Order_Line] CHECK CONSTRAINT [FK__Order_Lin__Order__43D61337]
GO
ALTER TABLE [dbo].[Order_Line]  WITH CHECK ADD  CONSTRAINT [FK_Order_Line_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Order_Line] CHECK CONSTRAINT [FK_Order_Line_Product]
GO
ALTER TABLE [dbo].[Order_Payment]  WITH CHECK ADD  CONSTRAINT [FK__Order_Pay__Order__45BE5BA9] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[Order_Payment] CHECK CONSTRAINT [FK__Order_Pay__Order__45BE5BA9]
GO
ALTER TABLE [dbo].[Order_Payment]  WITH CHECK ADD  CONSTRAINT [FK__Order_Pay__Payme__31B762FC] FOREIGN KEY([Payment_Type_ID])
REFERENCES [dbo].[Payment_Type] ([Payment_Type_ID])
GO
ALTER TABLE [dbo].[Order_Payment] CHECK CONSTRAINT [FK__Order_Pay__Payme__31B762FC]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK__Order__OS_ID__41EDCAC5] FOREIGN KEY([OS_ID])
REFERENCES [dbo].[Order_Status] ([OS_ID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK__Order__OS_ID__41EDCAC5]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK__Order__Supplier___42E1EEFE] FOREIGN KEY([Supplier_ID])
REFERENCES [dbo].[Suppliers] ([Supplier_ID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK__Order__Supplier___42E1EEFE]
GO
ALTER TABLE [dbo].[Patient_Allergy_List]  WITH CHECK ADD  CONSTRAINT [FK__Patient_A__Aller__4B7734FF] FOREIGN KEY([Allergy_ID])
REFERENCES [dbo].[Allergies] ([Allergy_ID])
GO
ALTER TABLE [dbo].[Patient_Allergy_List] CHECK CONSTRAINT [FK__Patient_A__Aller__4B7734FF]
GO
ALTER TABLE [dbo].[Patient_Allergy_List]  WITH CHECK ADD  CONSTRAINT [FK_Patient_Allergy_List_Patient] FOREIGN KEY([Patient_ID])
REFERENCES [dbo].[Patients] ([Patient_ID])
GO
ALTER TABLE [dbo].[Patient_Allergy_List] CHECK CONSTRAINT [FK_Patient_Allergy_List_Patient]
GO
ALTER TABLE [dbo].[Patients]  WITH CHECK ADD  CONSTRAINT [FK__Patient__Depende__47A6A41B] FOREIGN KEY([DependentNo])
REFERENCES [dbo].[Patients] ([Patient_ID])
GO
ALTER TABLE [dbo].[Patients] CHECK CONSTRAINT [FK__Patient__Depende__47A6A41B]
GO
ALTER TABLE [dbo].[Patients]  WITH CHECK ADD  CONSTRAINT [FK__Patient__Scheme___489AC854] FOREIGN KEY([Scheme_ID])
REFERENCES [dbo].[Medical_Aid_Scheme] ([Scheme_ID])
GO
ALTER TABLE [dbo].[Patients] CHECK CONSTRAINT [FK__Patient__Scheme___489AC854]
GO
ALTER TABLE [dbo].[Patients]  WITH CHECK ADD  CONSTRAINT [FK__Patient__Title_I__498EEC8D] FOREIGN KEY([Title_ID])
REFERENCES [dbo].[Titles] ([Title_ID])
GO
ALTER TABLE [dbo].[Patients] CHECK CONSTRAINT [FK__Patient__Title_I__498EEC8D]
GO
ALTER TABLE [dbo].[Patients]  WITH CHECK ADD  CONSTRAINT [FK_Patient_Patient] FOREIGN KEY([Patient_ID])
REFERENCES [dbo].[Patients] ([Patient_ID])
GO
ALTER TABLE [dbo].[Patients] CHECK CONSTRAINT [FK_Patient_Patient]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK__Payment__Consult__4E53A1AA] FOREIGN KEY([Consultation_ID])
REFERENCES [dbo].[Consultations] ([Consultation_ID])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK__Payment__Consult__4E53A1AA]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK__Payment__Payment__4D5F7D71] FOREIGN KEY([Payment_Type_ID])
REFERENCES [dbo].[Payment_Type] ([Payment_Type_ID])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK__Payment__Payment__4D5F7D71]
GO
ALTER TABLE [dbo].[Prescription_Line]  WITH CHECK ADD  CONSTRAINT [FK__Prescript__Consu__503BEA1C] FOREIGN KEY([Consultation_ID])
REFERENCES [dbo].[Consultations] ([Consultation_ID])
GO
ALTER TABLE [dbo].[Prescription_Line] CHECK CONSTRAINT [FK__Prescript__Consu__503BEA1C]
GO
ALTER TABLE [dbo].[Prescription_Line]  WITH CHECK ADD  CONSTRAINT [FK__Prescript__Medic__4F47C5E3] FOREIGN KEY([Medication_ID])
REFERENCES [dbo].[Medications] ([Medication_ID])
GO
ALTER TABLE [dbo].[Prescription_Line] CHECK CONSTRAINT [FK__Prescript__Medic__4F47C5E3]
GO
ALTER TABLE [dbo].[Prescription_Line]  WITH CHECK ADD  CONSTRAINT [FK_Prescription_Line_Patient] FOREIGN KEY([Patient_ID])
REFERENCES [dbo].[Patients] ([Patient_ID])
GO
ALTER TABLE [dbo].[Prescription_Line] CHECK CONSTRAINT [FK_Prescription_Line_Patient]
GO
ALTER TABLE [dbo].[Prices]  WITH CHECK ADD  CONSTRAINT [FK_Price_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Prices] CHECK CONSTRAINT [FK_Price_Product]
GO
ALTER TABLE [dbo].[Product_Procedure]  WITH CHECK ADD  CONSTRAINT [FK__Product_P__Proce__55009F39] FOREIGN KEY([Procedure_ID])
REFERENCES [dbo].[Procedures] ([Procedure_ID])
GO
ALTER TABLE [dbo].[Product_Procedure] CHECK CONSTRAINT [FK__Product_P__Proce__55009F39]
GO
ALTER TABLE [dbo].[Product_Procedure]  WITH CHECK ADD  CONSTRAINT [FK_Product_Procedure_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Product_Procedure] CHECK CONSTRAINT [FK_Product_Procedure_Product]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK__Product__Product__531856C7] FOREIGN KEY([Product_Type_ID])
REFERENCES [dbo].[Product_Type] ([Product_Type_ID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK__Product__Product__531856C7]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Product_Supplier] FOREIGN KEY([Supplier_ID])
REFERENCES [dbo].[Suppliers] ([Supplier_ID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Product_Supplier]
GO
ALTER TABLE [dbo].[Reconcilliations]  WITH CHECK ADD  CONSTRAINT [FK_Reconcilliation_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Reconcilliations] CHECK CONSTRAINT [FK_Reconcilliation_Product]
GO
ALTER TABLE [dbo].[Referral_Test]  WITH CHECK ADD  CONSTRAINT [FK__Referral___Ref_I__59C55456] FOREIGN KEY([Ref_ID])
REFERENCES [dbo].[Referrals] ([Ref_ID])
GO
ALTER TABLE [dbo].[Referral_Test] CHECK CONSTRAINT [FK__Referral___Ref_I__59C55456]
GO
ALTER TABLE [dbo].[Referral_Test]  WITH CHECK ADD  CONSTRAINT [FK__Referral___TestI__58D1301D] FOREIGN KEY([TestID])
REFERENCES [dbo].[Tests] ([TestID])
GO
ALTER TABLE [dbo].[Referral_Test] CHECK CONSTRAINT [FK__Referral___TestI__58D1301D]
GO
ALTER TABLE [dbo].[Referral_Test]  WITH CHECK ADD  CONSTRAINT [FK_Referral_Test_Institute] FOREIGN KEY([Institute_ID])
REFERENCES [dbo].[Institutes] ([Institute_ID])
GO
ALTER TABLE [dbo].[Referral_Test] CHECK CONSTRAINT [FK_Referral_Test_Institute]
GO
ALTER TABLE [dbo].[Referrals]  WITH CHECK ADD  CONSTRAINT [FK__Referral__Consul__57DD0BE4] FOREIGN KEY([Consultation_ID])
REFERENCES [dbo].[Consultations] ([Consultation_ID])
GO
ALTER TABLE [dbo].[Referrals] CHECK CONSTRAINT [FK__Referral__Consul__57DD0BE4]
GO
ALTER TABLE [dbo].[Sick_Note]  WITH CHECK ADD  CONSTRAINT [FK__Sick_Note__Consu__5BAD9CC8] FOREIGN KEY([Consultation_ID])
REFERENCES [dbo].[Consultations] ([Consultation_ID])
GO
ALTER TABLE [dbo].[Sick_Note] CHECK CONSTRAINT [FK__Sick_Note__Consu__5BAD9CC8]
GO
ALTER TABLE [dbo].[Stock_take_Line]  WITH CHECK ADD  CONSTRAINT [FK__Stock_tak__Produ__5CA1C101] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Stock_take_Line] CHECK CONSTRAINT [FK__Stock_tak__Produ__5CA1C101]
GO
ALTER TABLE [dbo].[Stock_take_Line]  WITH CHECK ADD  CONSTRAINT [FK__Stock_tak__Stock__5D95E53A] FOREIGN KEY([StockTake_ID])
REFERENCES [dbo].[Stock_Take] ([StockTake_ID])
GO
ALTER TABLE [dbo].[Stock_take_Line] CHECK CONSTRAINT [FK__Stock_tak__Stock__5D95E53A]
GO
ALTER TABLE [dbo].[Tests]  WITH CHECK ADD  CONSTRAINT [FK__Test__Test_Type___5E8A0973] FOREIGN KEY([Test_Type_ID])
REFERENCES [dbo].[Test_Type] ([Test_Type_ID])
GO
ALTER TABLE [dbo].[Tests] CHECK CONSTRAINT [FK__Test__Test_Type___5E8A0973]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK__User__EMP_ID__5F7E2DAC] FOREIGN KEY([EMP_ID])
REFERENCES [dbo].[Employees] ([EMP_ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK__User__EMP_ID__5F7E2DAC]
GO
ALTER TABLE [dbo].[Xrays]  WITH CHECK ADD  CONSTRAINT [FK__Xrays__Consultat__607251E5] FOREIGN KEY([Consultation_ID])
REFERENCES [dbo].[Consultations] ([Consultation_ID])
GO
ALTER TABLE [dbo].[Xrays] CHECK CONSTRAINT [FK__Xrays__Consultat__607251E5]
GO
ALTER TABLE [dbo].[Xrays]  WITH CHECK ADD  CONSTRAINT [FK_Xrays_Patient] FOREIGN KEY([Patient_ID])
REFERENCES [dbo].[Patients] ([Patient_ID])
GO
ALTER TABLE [dbo].[Xrays] CHECK CONSTRAINT [FK_Xrays_Patient]
GO
USE [master]
GO
ALTER DATABASE [DrSavvy] SET  READ_WRITE 
GO
