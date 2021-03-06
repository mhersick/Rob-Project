USE [SiteDB]
GO
ALTER TABLE [dbo].[SubProjects] DROP CONSTRAINT [FK_Projects_SubProjects]
GO
ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [FK_Projects_Company]
GO
ALTER TABLE [dbo].[Payments] DROP CONSTRAINT [FK_Payments_Orders]
GO
ALTER TABLE [dbo].[PaymentMethods] DROP CONSTRAINT [FK_PaymentMethods_Company]
GO
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Company]
GO
ALTER TABLE [dbo].[OrderLine] DROP CONSTRAINT [FK_OrderLine_Orders]
GO
ALTER TABLE [dbo].[Messages] DROP CONSTRAINT [FK_Messages_Employees]
GO
ALTER TABLE [dbo].[Items] DROP CONSTRAINT [FK_Items_ItemCategories]
GO
ALTER TABLE [dbo].[Items] DROP CONSTRAINT [FK_Items_ItemBoxes]
GO
ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_Employees_Company]
GO
ALTER TABLE [dbo].[Documents] DROP CONSTRAINT [FK_Documents_SubProjects]
GO
ALTER TABLE [dbo].[Documents] DROP CONSTRAINT [FK_Documents_Company]
GO
ALTER TABLE [dbo].[BlogPosts] DROP CONSTRAINT [FK_BlogPosts_BlogCategories]
GO
ALTER TABLE [dbo].[BlogComments] DROP CONSTRAINT [FK_BlogComments_BlogPosts]
GO
ALTER TABLE [dbo].[Bids] DROP CONSTRAINT [FK_Bids_SubProjects]
GO
ALTER TABLE [dbo].[Bids] DROP CONSTRAINT [FK_Bids_Company]
GO
ALTER TABLE [dbo].[AltAddress] DROP CONSTRAINT [FK_AltAddress_Company]
GO
ALTER TABLE [dbo].[SubProjects] DROP CONSTRAINT [DF_SubProjects_IsSubProject]
GO
ALTER TABLE [dbo].[SubProjects] DROP CONSTRAINT [DF_SubProjects_Complete]
GO
ALTER TABLE [dbo].[SubProjects] DROP CONSTRAINT [DF_SubProjects_Active]
GO
ALTER TABLE [dbo].[SubProjects] DROP CONSTRAINT [DF_SubProjects_Deleted]
GO
ALTER TABLE [dbo].[SubProjects] DROP CONSTRAINT [DF_SubProjects_ProjectCategory]
GO
ALTER TABLE [dbo].[Reviews] DROP CONSTRAINT [DF_Reviews_Featured]
GO
ALTER TABLE [dbo].[Reviews] DROP CONSTRAINT [DF_Reviews_Active]
GO
ALTER TABLE [dbo].[Reviews] DROP CONSTRAINT [DF_Reviews_Deleted]
GO
ALTER TABLE [dbo].[ProjectStatus] DROP CONSTRAINT [DF_ProjectStatus_Deleted]
GO
ALTER TABLE [dbo].[ProjectStatus] DROP CONSTRAINT [DF_ProjectStatus_Active]
GO
ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [DF_Projects_IsSubProject]
GO
ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [DF_Projects_Complete]
GO
ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [DF_Projects_Active]
GO
ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [DF_Projects_Deleted]
GO
ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [DF_Projects_ProjectCategory]
GO
ALTER TABLE [dbo].[ProjectCategories] DROP CONSTRAINT [DF_ProjectCategories_Deleted]
GO
ALTER TABLE [dbo].[ProjectCategories] DROP CONSTRAINT [DF_ProjectCategories_Active]
GO
ALTER TABLE [dbo].[Payments] DROP CONSTRAINT [DF_Payments_Deleted]
GO
ALTER TABLE [dbo].[Payments] DROP CONSTRAINT [DF_Payments_Active]
GO
ALTER TABLE [dbo].[PaymentMethods] DROP CONSTRAINT [DF_PaymentMethods_Deleted]
GO
ALTER TABLE [dbo].[PaymentMethods] DROP CONSTRAINT [DF_PaymentMethods_Active]
GO
ALTER TABLE [dbo].[OrderStatus] DROP CONSTRAINT [DF_OrderStatus_Deleted]
GO
ALTER TABLE [dbo].[OrderStatus] DROP CONSTRAINT [DF_OrderStatus_Active]
GO
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [DF_Orders_Active]
GO
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [DF_Orders_Deleted]
GO
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [DF_Orders_Fulfilled]
GO
ALTER TABLE [dbo].[OrderLine] DROP CONSTRAINT [DF_OrderLine_Active]
GO
ALTER TABLE [dbo].[OrderLine] DROP CONSTRAINT [DF_OrderLine_Deleted]
GO
ALTER TABLE [dbo].[OrderLine] DROP CONSTRAINT [DF_OrderLine_Fullfilled]
GO
ALTER TABLE [dbo].[Messages] DROP CONSTRAINT [DF_Messages_Deleted]
GO
ALTER TABLE [dbo].[Messages] DROP CONSTRAINT [DF_Messages_DBPImail]
GO
ALTER TABLE [dbo].[Items] DROP CONSTRAINT [DF_Items_Outlet]
GO
ALTER TABLE [dbo].[Items] DROP CONSTRAINT [DF_Items_Featured]
GO
ALTER TABLE [dbo].[Items] DROP CONSTRAINT [DF_Items_Active]
GO
ALTER TABLE [dbo].[ItemCategories] DROP CONSTRAINT [DF_ItemCategories_IsSubCat]
GO
ALTER TABLE [dbo].[ItemCategories] DROP CONSTRAINT [DF_ItemCategories_ShowOnRelated]
GO
ALTER TABLE [dbo].[ItemCategories] DROP CONSTRAINT [DF_ItemCategories_Featured]
GO
ALTER TABLE [dbo].[ItemCategories] DROP CONSTRAINT [DF_ItemCategories_Active]
GO
ALTER TABLE [dbo].[ItemBoxes] DROP CONSTRAINT [DF_ItemBoxes_Deleted]
GO
ALTER TABLE [dbo].[ItemBoxes] DROP CONSTRAINT [DF_ItemBoxes_Active]
GO
ALTER TABLE [dbo].[ItemBoxes] DROP CONSTRAINT [DF_ItemBoxes_InternationalZone]
GO
ALTER TABLE [dbo].[ItemBoxes] DROP CONSTRAINT [DF_ItemBoxes_RuralZone]
GO
ALTER TABLE [dbo].[ItemBoxes] DROP CONSTRAINT [DF_ItemBoxes_InnerOuter]
GO
ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [DF_Employees_CompanyCreator]
GO
ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [DF_Employees_Active]
GO
ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [DF_Employees_Deleted]
GO
ALTER TABLE [dbo].[Documents] DROP CONSTRAINT [DF_Documents_Deleted]
GO
ALTER TABLE [dbo].[Documents] DROP CONSTRAINT [DF_Documents_Active]
GO
ALTER TABLE [dbo].[Contacts] DROP CONSTRAINT [DF_Contacts_Deleted]
GO
ALTER TABLE [dbo].[Contacts] DROP CONSTRAINT [DF_Contacts_Active]
GO
ALTER TABLE [dbo].[Company] DROP CONSTRAINT [DF_Company_Deleted]
GO
ALTER TABLE [dbo].[Company] DROP CONSTRAINT [DF_Company_Active]
GO
ALTER TABLE [dbo].[Company] DROP CONSTRAINT [DF_Company_ServiceLevel]
GO
ALTER TABLE [dbo].[BlogPosts] DROP CONSTRAINT [DF_BlogPosts_Post_CommentsReview]
GO
ALTER TABLE [dbo].[BlogPosts] DROP CONSTRAINT [DF_BlogPosts_Post_CommentsAllowed]
GO
ALTER TABLE [dbo].[BlogPosts] DROP CONSTRAINT [DF_BlogPosts_Post_Featured]
GO
ALTER TABLE [dbo].[BlogPosts] DROP CONSTRAINT [DF_BlogPosts_Post_Active]
GO
ALTER TABLE [dbo].[BlogPosts] DROP CONSTRAINT [DF_BlogPosts_Post_Deleted]
GO
ALTER TABLE [dbo].[BlogComments] DROP CONSTRAINT [DF_BlogComments_Active]
GO
ALTER TABLE [dbo].[BlogComments] DROP CONSTRAINT [DF_BlogComments_Deleted]
GO
ALTER TABLE [dbo].[BlogCategories] DROP CONSTRAINT [DF_BlogCategories_Post_Active]
GO
ALTER TABLE [dbo].[BidStatus] DROP CONSTRAINT [DF_BidStatus_Deleted]
GO
ALTER TABLE [dbo].[BidStatus] DROP CONSTRAINT [DF_BidStatus_Active]
GO
ALTER TABLE [dbo].[Bids] DROP CONSTRAINT [DF_Bids_Active]
GO
ALTER TABLE [dbo].[Bids] DROP CONSTRAINT [DF_Bids_Deleted]
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP TABLE [dbo].[Teams]
GO
/****** Object:  Table [dbo].[SubProjects]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP TABLE [dbo].[SubProjects]
GO
/****** Object:  Table [dbo].[ServicePlans]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP TABLE [dbo].[ServicePlans]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP TABLE [dbo].[Reviews]
GO
/****** Object:  Table [dbo].[ProjectStatus]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP TABLE [dbo].[ProjectStatus]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP TABLE [dbo].[Projects]
GO
/****** Object:  Table [dbo].[ProjectCategories]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP TABLE [dbo].[ProjectCategories]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP TABLE [dbo].[Payments]
GO
/****** Object:  Table [dbo].[PaymentMethods]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP TABLE [dbo].[PaymentMethods]
GO
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP TABLE [dbo].[OrderStatus]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP TABLE [dbo].[Orders]
GO
/****** Object:  Table [dbo].[OrderLine]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP TABLE [dbo].[OrderLine]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP TABLE [dbo].[Messages]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP TABLE [dbo].[Items]
GO
/****** Object:  Table [dbo].[ItemCategories]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP TABLE [dbo].[ItemCategories]
GO
/****** Object:  Table [dbo].[ItemBoxes]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP TABLE [dbo].[ItemBoxes]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP TABLE [dbo].[Employees]
GO
/****** Object:  Table [dbo].[Documents]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP TABLE [dbo].[Documents]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP TABLE [dbo].[Contacts]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP TABLE [dbo].[Company]
GO
/****** Object:  Table [dbo].[BlogPosts]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP TABLE [dbo].[BlogPosts]
GO
/****** Object:  Table [dbo].[BlogComments]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP TABLE [dbo].[BlogComments]
GO
/****** Object:  Table [dbo].[BlogCategories]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP TABLE [dbo].[BlogCategories]
GO
/****** Object:  Table [dbo].[BidStatus]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP TABLE [dbo].[BidStatus]
GO
/****** Object:  Table [dbo].[Bids]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP TABLE [dbo].[Bids]
GO
/****** Object:  Table [dbo].[AltAddress]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP TABLE [dbo].[AltAddress]
GO
/****** Object:  User [NT AUTHORITY\NETWORK SERVICE]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP USER [NT AUTHORITY\NETWORK SERVICE]
GO
USE [master]
GO
/****** Object:  Database [SiteDB]    Script Date: 10/31/2018 9:04:55 AM ******/
DROP DATABASE [SiteDB]
GO
/****** Object:  Database [SiteDB]    Script Date: 10/31/2018 9:04:55 AM ******/
CREATE DATABASE [SiteDB] ON  PRIMARY 
( NAME = N'SiteDB', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\SiteDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SiteDB_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\SiteDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SiteDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SiteDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SiteDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SiteDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SiteDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SiteDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SiteDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SiteDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SiteDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SiteDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SiteDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SiteDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SiteDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SiteDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SiteDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SiteDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SiteDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SiteDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SiteDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SiteDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SiteDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SiteDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SiteDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SiteDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SiteDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SiteDB] SET  MULTI_USER 
GO
ALTER DATABASE [SiteDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SiteDB] SET DB_CHAINING OFF 
GO
USE [SiteDB]
GO
/****** Object:  User [NT AUTHORITY\NETWORK SERVICE]    Script Date: 10/31/2018 9:04:55 AM ******/
CREATE USER [NT AUTHORITY\NETWORK SERVICE] FOR LOGIN [NT AUTHORITY\NETWORK SERVICE] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[AltAddress]    Script Date: 10/31/2018 9:04:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AltAddress](
	[AddressID] [int] IDENTITY(500,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[NickName] [nvarchar](50) NOT NULL,
	[Address1] [nvarchar](100) NULL,
	[Address2] [nvarchar](100) NOT NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[Zip] [nchar](10) NULL,
	[Country] [nvarchar](50) NULL,
	[ShipPhone] [nvarchar](50) NOT NULL,
	[ShipEmail] [nvarchar](50) NOT NULL,
	[Notes] [nvarchar](1000) NULL,
 CONSTRAINT [PK_AltAddress] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bids]    Script Date: 10/31/2018 9:04:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bids](
	[BidID] [int] IDENTITY(500,1) NOT NULL,
	[SubProjectID] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[BidDate] [datetime] NOT NULL,
	[BidText] [nvarchar](max) NOT NULL,
	[BidLimitations] [nvarchar](max) NULL,
	[BidAmt] [decimal](18, 2) NOT NULL,
	[BidStatus] [nvarchar](50) NULL,
	[Deleted] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[ActionDate] [datetime] NULL,
	[Notes] [nvarchar](max) NULL,
	[LastViewDate] [datetime] NULL,
 CONSTRAINT [PK_Bids] PRIMARY KEY CLUSTERED 
(
	[BidID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BidStatus]    Script Date: 10/31/2018 9:04:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BidStatus](
	[BidStatusID] [int] IDENTITY(100,1) NOT NULL,
	[BidStatusName] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Sequence] [int] NULL,
 CONSTRAINT [PK_BidStatus] PRIMARY KEY CLUSTERED 
(
	[BidStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BlogCategories]    Script Date: 10/31/2018 9:04:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogCategories](
	[Post_CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Post_CategoryName] [nvarchar](50) NOT NULL,
	[Post_CategoryText] [nvarchar](max) NULL,
	[Post_CategoryImage] [nvarchar](50) NULL,
	[Sequence] [int] NULL,
	[Post_Active] [bit] NOT NULL,
 CONSTRAINT [PK_BlogCategories] PRIMARY KEY CLUSTERED 
(
	[Post_CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BlogComments]    Script Date: 10/31/2018 9:04:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogComments](
	[PostCommentID] [int] IDENTITY(1,1) NOT NULL,
	[PostID] [int] NOT NULL,
	[PostCommentAuthor] [nvarchar](50) NULL,
	[PostCommentDate] [datetime] NULL,
	[PostCommentContent] [nvarchar](max) NULL,
	[Deleted] [bit] NULL,
	[Active] [bit] NULL,
	[PostCommentCompanyID] [int] NULL,
 CONSTRAINT [PK_BlogComments] PRIMARY KEY CLUSTERED 
(
	[PostCommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BlogPosts]    Script Date: 10/31/2018 9:04:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogPosts](
	[PostID] [int] IDENTITY(500,1) NOT NULL,
	[Post_CategoryID] [int] NOT NULL,
	[Post_author] [nvarchar](50) NOT NULL,
	[Post_Date] [datetime] NOT NULL,
	[Post_Tite] [nvarchar](100) NOT NULL,
	[Post_Content] [nvarchar](max) NOT NULL,
	[Post_Status] [nvarchar](50) NULL,
	[Post_Deleted] [bit] NOT NULL,
	[Post_Active] [bit] NOT NULL,
	[Post_Featured] [bit] NOT NULL,
	[Post_Views] [int] NULL,
	[Post_CommentsAllowed] [bit] NOT NULL,
	[Post_Image1] [nvarchar](50) NULL,
	[Post_Image2] [nvarchar](50) NULL,
	[Post_Image3] [nvarchar](50) NULL,
	[Post_Banner1] [nvarchar](50) NULL,
	[Post_Article] [nvarchar](300) NULL,
	[Post_ArticleContent] [nvarchar](max) NULL,
	[Post_URL1] [nvarchar](50) NULL,
	[Post_URL2] [nvarchar](50) NULL,
	[Post_CommentsReview] [bit] NOT NULL,
 CONSTRAINT [PK_BlogPosts] PRIMARY KEY CLUSTERED 
(
	[PostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Company]    Script Date: 10/31/2018 9:04:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyID] [int] IDENTITY(500,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[UserName] [nvarchar](256) NULL,
	[UserID] [uniqueidentifier] NULL,
	[CompanyName] [nvarchar](100) NOT NULL,
	[Address1] [nvarchar](100) NULL,
	[Address2] [nvarchar](100) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nchar](10) NULL,
	[Zip] [nchar](10) NULL,
	[Country] [nvarchar](50) NULL,
	[Phone1] [nchar](50) NULL,
	[Phone2] [nchar](50) NULL,
	[Email1] [nvarchar](50) NULL,
	[Email2] [nvarchar](50) NULL,
	[WebSite] [nvarchar](100) NULL,
	[CompanyPrimaryImg] [nvarchar](50) NULL,
	[CompanySecondaryImg] [nvarchar](50) NULL,
	[CompanyDescription] [nvarchar](300) NULL,
	[CompanyText] [nvarchar](max) NULL,
	[ArticleDescription] [nvarchar](300) NULL,
	[ArticleText] [nvarchar](max) NULL,
	[ServiceLevel] [nvarchar](50) NULL,
	[BillingCycle] [int] NULL,
	[ResaleCertificate] [nvarchar](50) NULL,
	[ContractorLicense] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 10/31/2018 9:04:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[ContactID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[CompanyName] [nvarchar](100) NULL,
	[Phone] [nvarchar](50) NULL,
	[Interest] [nvarchar](100) NULL,
	[MessageText] [nvarchar](max) NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[ContactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Documents]    Script Date: 10/31/2018 9:04:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documents](
	[DocumentID] [int] IDENTITY(500,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[SubProjectID] [int] NOT NULL,
	[DocumentTitle] [nvarchar](100) NOT NULL,
	[DocumentText] [nvarchar](500) NULL,
	[Location] [nvarchar](50) NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED 
(
	[DocumentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees]    Script Date: 10/31/2018 9:04:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(500,1) NOT NULL,
	[UserID] [uniqueidentifier] NULL,
	[UserName] [nvarchar](256) NULL,
	[CompanyID] [int] NOT NULL,
	[Company_EmployeeID] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Address1] [nvarchar](50) NULL,
	[Address2] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[Zip] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Phone1] [nvarchar](50) NULL,
	[Phone2] [nvarchar](50) NULL,
	[Email1] [nvarchar](50) NOT NULL,
	[Email2] [nvarchar](50) NULL,
	[Notes] [nvarchar](max) NULL,
	[Deleted] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[CompanyCreator] [bit] NOT NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ItemBoxes]    Script Date: 10/31/2018 9:04:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemBoxes](
	[BoxID] [int] IDENTITY(500,1) NOT NULL,
	[BoxDescription] [nvarchar](50) NULL,
	[BoxWidth] [decimal](10, 2) NULL,
	[BoxLength] [decimal](10, 2) NULL,
	[BoxHeight] [decimal](10, 2) NULL,
	[BoxNW] [decimal](10, 2) NULL,
	[BoxCF] [decimal](10, 2) NULL,
	[InnerOuter] [bit] NULL,
	[InnerBoxFor] [int] NULL,
	[Image] [nvarchar](50) NULL,
	[Zone01] [decimal](10, 2) NULL,
	[Zone02] [decimal](10, 2) NULL,
	[Zone03] [decimal](10, 2) NULL,
	[Zone04] [decimal](10, 2) NULL,
	[Zone05] [decimal](10, 2) NULL,
	[Zone06] [decimal](10, 2) NULL,
	[Zone07] [decimal](10, 2) NULL,
	[Zone08] [decimal](10, 2) NULL,
	[Zone09] [decimal](10, 2) NULL,
	[Zone10] [decimal](10, 2) NULL,
	[Zone11] [decimal](10, 2) NULL,
	[Zone12] [decimal](10, 2) NULL,
	[Zone13] [decimal](10, 2) NULL,
	[Zone14] [decimal](10, 2) NULL,
	[Zone15] [decimal](10, 2) NULL,
	[RuralZone] [bit] NOT NULL,
	[InternationalZone] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_ItemBoxes] PRIMARY KEY CLUSTERED 
(
	[BoxID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ItemCategories]    Script Date: 10/31/2018 9:04:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemCategories](
	[CategoryID] [int] IDENTITY(500,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	[CategoryDescription] [nvarchar](500) NULL,
	[CategoryHeader] [nvarchar](100) NULL,
	[Image1] [nvarchar](50) NULL,
	[Image2] [nvarchar](50) NULL,
	[Image3] [nvarchar](50) NULL,
	[WebLink1] [nvarchar](50) NULL,
	[Weblink2] [nvarchar](50) NULL,
	[Active] [bit] NOT NULL,
	[Featured] [bit] NOT NULL,
	[ShowOnRelated] [bit] NOT NULL,
	[IsSubCat] [bit] NOT NULL,
	[SubCatOf] [nvarchar](50) NULL,
	[CategoryLongText] [nvarchar](max) NULL,
	[Notes] [nvarchar](max) NULL,
	[Sequence] [int] NULL,
 CONSTRAINT [PK_ItemCategories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Items]    Script Date: 10/31/2018 9:04:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[VendorID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
	[SKU] [int] NULL,
	[ItemName] [nvarchar](100) NULL,
	[ItemDescription] [nvarchar](1000) NULL,
	[VendorItemID] [int] NULL,
	[Price1] [decimal](18, 2) NULL,
	[Price2] [decimal](18, 2) NULL,
	[Price3] [decimal](18, 2) NULL,
	[Price4] [decimal](18, 2) NULL,
	[Price5] [decimal](18, 2) NULL,
	[Size] [int] NULL,
	[Color] [int] NULL,
	[InStock] [int] NULL,
	[Active] [bit] NULL,
	[Featured] [bit] NULL,
	[ItemNW] [decimal](18, 2) NULL,
	[Limage] [nvarchar](50) NULL,
	[Simage] [nvarchar](50) NULL,
	[Timage] [nvarchar](50) NULL,
	[Pic01] [nvarchar](50) NULL,
	[Pic02] [nvarchar](50) NULL,
	[Pic03] [nvarchar](50) NULL,
	[WebLink] [nvarchar](50) NULL,
	[Outlet] [bit] NOT NULL,
	[OrderMin] [int] NULL,
	[OrderInc] [int] NULL,
	[BoxID] [int] NULL,
	[Views] [int] NULL,
	[Ranking] [int] NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Messages]    Script Date: 10/31/2018 9:04:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[MessageID] [int] IDENTITY(5000,1) NOT NULL,
	[FromID] [int] NOT NULL,
	[FromEmail] [nvarchar](100) NULL,
	[FromFName] [nvarchar](50) NULL,
	[FromLName] [nvarchar](50) NULL,
	[FromCompany] [int] NOT NULL,
	[ToID] [int] NULL,
	[ToEmail] [nvarchar](100) NULL,
	[ToFName] [nvarchar](50) NULL,
	[ToLName] [nvarchar](50) NULL,
	[ToCompany] [int] NULL,
	[MessageSubject] [nvarchar](100) NOT NULL,
	[MessageText] [nvarchar](max) NULL,
	[MessageDate] [datetime] NULL,
	[ResponseDate] [datetime] NULL,
	[DBPImail] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DeleteDate] [datetime] NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderLine]    Script Date: 10/31/2018 9:04:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderLine](
	[OrderLineID] [int] IDENTITY(500,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[ItemID] [int] NOT NULL,
	[ItemName] [nvarchar](50) NULL,
	[ItemDescription] [nvarchar](5) NULL,
	[ItemPrice] [decimal](18, 2) NULL,
	[ItemQty] [int] NULL,
	[Discount] [decimal](18, 2) NULL,
	[LineTotal] [decimal](18, 2) NULL,
	[OrderLineStatus] [nvarchar](50) NULL,
	[ThumbImage] [nvarchar](10) NULL,
	[BoxID] [int] NULL,
	[Fullfilled] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[Notes] [nvarchar](1000) NULL,
	[Size] [int] NULL,
	[Color] [int] NULL,
 CONSTRAINT [PK_OrderLine] PRIMARY KEY CLUSTERED 
(
	[OrderLineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 10/31/2018 9:04:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[CustOrderNumber] [nvarchar](50) NULL,
	[OrderStatus] [nvarchar](50) NULL,
	[OrderDate] [datetime] NOT NULL,
	[ShipDate] [datetime] NULL,
	[PaymentStatus] [nvarchar](50) NULL,
	[PaymentID] [int] NULL,
	[PaymentDate] [datetime] NULL,
	[ShipToAddressID] [int] NULL,
	[ShipperID] [int] NULL,
	[ShipperTracking] [nvarchar](1000) NULL,
	[ProductTotal] [decimal](18, 2) NULL,
	[WebShipping] [decimal](18, 2) NULL,
	[ActualShipping] [decimal](18, 2) NULL,
	[SalesTax] [decimal](18, 2) NULL,
	[Discounts] [decimal](18, 2) NULL,
	[Fulfilled] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 10/31/2018 9:04:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatus](
	[OrderStatusID] [int] IDENTITY(1,1) NOT NULL,
	[OrderStatus] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Sequence] [int] NULL,
 CONSTRAINT [PK_OrderStatus] PRIMARY KEY CLUSTERED 
(
	[OrderStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PaymentMethods]    Script Date: 10/31/2018 9:04:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentMethods](
	[PaymentMethodID] [int] IDENTITY(500,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[PaymentType] [int] NOT NULL,
	[PaymentMethodName] [nvarchar](50) NOT NULL,
	[AccountNumber] [nvarchar](50) NOT NULL,
	[RoutingNumber] [nvarchar](50) NULL,
	[BankName] [nvarchar](50) NULL,
	[ExpirationMonth] [int] NULL,
	[ExpirationYear] [int] NULL,
	[PayeeName] [nvarchar](50) NULL,
	[PayeeAddress] [nchar](10) NULL,
	[PayeeCity] [nvarchar](50) NULL,
	[PayeeState] [nvarchar](50) NULL,
	[PayeeZip] [nvarchar](50) NULL,
	[PayeeCountry] [nvarchar](50) NULL,
	[OtherInfo] [nvarchar](200) NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastActivityDate] [datetime] NOT NULL,
	[SetAsDefault] [bit] NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_PaymentMethods] PRIMARY KEY CLUSTERED 
(
	[PaymentMethodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payments]    Script Date: 10/31/2018 9:04:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[PaymentAmt] [decimal](18, 2) NOT NULL,
	[PaymentDate] [datetime] NOT NULL,
	[PaymentType] [nvarchar](50) NOT NULL,
	[PayerID] [nvarchar](50) NULL,
	[TransID] [nvarchar](50) NULL,
	[TransStatus] [nvarchar](50) NULL,
	[Notes] [nvarchar](1000) NULL,
	[Active] [bit] NULL,
	[Deleted] [bit] NULL,
	[BankAccount] [nvarchar](50) NULL,
	[BankRouting] [nvarchar](50) NULL,
	[CardType] [nvarchar](50) NULL,
	[CardNumber] [nchar](20) NULL,
	[CardExMo] [nchar](2) NULL,
	[CardExYr] [nchar](2) NULL,
	[CardCVCC] [nchar](10) NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProjectCategories]    Script Date: 10/31/2018 9:04:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectCategories](
	[ProjectCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
	[CategoryDescription] [nvarchar](500) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Sequence] [int] NULL,
 CONSTRAINT [PK_ProjectCategories] PRIMARY KEY CLUSTERED 
(
	[ProjectCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Projects]    Script Date: 10/31/2018 9:04:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectID] [int] IDENTITY(500,1) NOT NULL,
	[ProjectName] [nvarchar](100) NOT NULL,
	[ProjectDescription] [nvarchar](max) NOT NULL,
	[ProjectStatus] [int] NOT NULL,
	[ProjectCategory] [int] NOT NULL,
	[OpenDate] [datetime] NULL,
	[BidOpenDate] [datetime] NULL,
	[BidCloseDate] [datetime] NULL,
	[CompanyID] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[Complete] [bit] NOT NULL,
	[CompletionDate] [datetime] NULL,
	[RequiredDate] [datetime] NULL,
	[BidStatus] [int] NULL,
	[AcceptedBid] [int] NULL,
	[AcceptedCompany] [int] NULL,
	[ActionDate] [datetime] NULL,
	[SiteAddress1] [nvarchar](100) NULL,
	[SiteAddress2] [nvarchar](100) NULL,
	[SiteAddressCity] [nvarchar](50) NULL,
	[SiteAddressState] [nvarchar](50) NULL,
	[SiteAddressZip] [nvarchar](50) NULL,
	[SiteAddressCountry] [nvarchar](50) NULL,
	[Dependencies] [int] NULL,
	[IsSubProject] [bit] NOT NULL,
	[SubProjectOf] [int] NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProjectStatus]    Script Date: 10/31/2018 9:04:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectStatus](
	[ProjectStatusID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectStatusName] [nvarchar](50) NULL,
	[Description] [nvarchar](300) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Sequence] [int] NULL,
 CONSTRAINT [PK_ProjectStatus] PRIMARY KEY CLUSTERED 
(
	[ProjectStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 10/31/2018 9:04:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[ReviewID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NULL,
	[EmployeeID] [int] NULL,
	[ReviewDate] [datetime] NOT NULL,
	[StarRate] [int] NULL,
	[ReviewText] [nvarchar](max) NOT NULL,
	[Deleted] [bit] NULL,
	[Active] [bit] NULL,
	[Featured] [bit] NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[ReviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ServicePlans]    Script Date: 10/31/2018 9:04:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServicePlans](
	[ServicePlanID] [int] IDENTITY(100,1) NOT NULL,
	[ServicePlanName] [nvarchar](50) NOT NULL,
	[ShortDescription] [nvarchar](500) NULL,
	[LongDescription] [nvarchar](max) NULL,
	[Seats] [nvarchar](50) NULL,
	[Storage] [nvarchar](50) NULL,
	[FeatureA] [nvarchar](50) NULL,
	[FeatureB] [nvarchar](50) NULL,
	[FeatureC] [nvarchar](50) NULL,
	[FeatureD] [nvarchar](50) NULL,
	[FeatureE] [nvarchar](50) NULL,
	[AddSeatCost] [decimal](18, 0) NULL,
	[MontlhyCost] [decimal](18, 0) NULL,
	[AnnualCost] [decimal](18, 0) NULL,
	[DiscountPercent] [decimal](18, 0) NULL,
	[Sequence] [int] NULL,
 CONSTRAINT [PK_ServicePlans] PRIMARY KEY CLUSTERED 
(
	[ServicePlanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubProjects]    Script Date: 10/31/2018 9:04:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubProjects](
	[SubProjectID] [int] IDENTITY(500,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[SubProjectName] [nvarchar](10) NOT NULL,
	[SubProjectDescription] [nvarchar](max) NOT NULL,
	[SubProjectStatus] [int] NOT NULL,
	[ProjectCategory] [int] NOT NULL,
	[OpenDate] [datetime] NULL,
	[BiDOpenDate] [datetime] NULL,
	[BidCloseDate] [datetime] NULL,
	[RequiredDate] [datetime] NULL,
	[BidStatus] [int] NULL,
	[AcceptedBid] [int] NULL,
	[AcceptedCompany] [int] NULL,
	[ActionDate] [datetime] NULL,
	[Deleted] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[Complete] [bit] NOT NULL,
	[CompletionDate] [datetime] NULL,
	[Dependencies] [int] NULL,
	[IsSubProject] [bit] NOT NULL,
	[SubProjectOf] [int] NULL,
 CONSTRAINT [PK_SubProjects] PRIMARY KEY CLUSTERED 
(
	[SubProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teams]    Script Date: 10/31/2018 9:04:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[TeamRecordID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[EmployeeID] [int] NULL,
	[CompanyID] [int] NULL,
	[Title] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED 
(
	[TeamRecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[BidStatus] ON 

INSERT [dbo].[BidStatus] ([BidStatusID], [BidStatusName], [Description], [Active], [Deleted], [Sequence]) VALUES (100, N'Open for Bids', N'Project Task is open for Bidding', 1, 0, 1)
INSERT [dbo].[BidStatus] ([BidStatusID], [BidStatusName], [Description], [Active], [Deleted], [Sequence]) VALUES (101, N'Closed to Bids', N'Project Task is closed to Bidding', 1, 0, 2)
INSERT [dbo].[BidStatus] ([BidStatusID], [BidStatusName], [Description], [Active], [Deleted], [Sequence]) VALUES (102, N'Project Awarded', N'The Project contract has been awarded to a Bidder', 1, 0, 3)
INSERT [dbo].[BidStatus] ([BidStatusID], [BidStatusName], [Description], [Active], [Deleted], [Sequence]) VALUES (103, N'Closed to Bids - On Hold', N'The Project is On Hold and is not accepting bids right now', 1, 0, 4)
INSERT [dbo].[BidStatus] ([BidStatusID], [BidStatusName], [Description], [Active], [Deleted], [Sequence]) VALUES (104, N'In negotiation with a bidder', N'In negotiation with a bidder', 1, 0, 5)
SET IDENTITY_INSERT [dbo].[BidStatus] OFF
SET IDENTITY_INSERT [dbo].[BlogCategories] ON 

INSERT [dbo].[BlogCategories] ([Post_CategoryID], [Post_CategoryName], [Post_CategoryText], [Post_CategoryImage], [Sequence], [Post_Active]) VALUES (1, N'EAC Industry News', N'EAC Industry News', NULL, 1, 1)
INSERT [dbo].[BlogCategories] ([Post_CategoryID], [Post_CategoryName], [Post_CategoryText], [Post_CategoryImage], [Sequence], [Post_Active]) VALUES (2, N'DBPI News', N'DBPI News', NULL, 2, 1)
INSERT [dbo].[BlogCategories] ([Post_CategoryID], [Post_CategoryName], [Post_CategoryText], [Post_CategoryImage], [Sequence], [Post_Active]) VALUES (3, N'New Features', N'New Features', NULL, 3, 1)
SET IDENTITY_INSERT [dbo].[BlogCategories] OFF
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([CompanyID], [EmployeeID], [UserName], [UserID], [CompanyName], [Address1], [Address2], [City], [State], [Zip], [Country], [Phone1], [Phone2], [Email1], [Email2], [WebSite], [CompanyPrimaryImg], [CompanySecondaryImg], [CompanyDescription], [CompanyText], [ArticleDescription], [ArticleText], [ServiceLevel], [BillingCycle], [ResaleCertificate], [ContractorLicense], [CreateDate], [Active], [Deleted]) VALUES (502, 502, N'jmoore963', NULL, N'Bell Blueprint', NULL, NULL, NULL, NULL, NULL, NULL, N'858 254-8066', NULL, N'jim@bellblue.com', NULL, N'bellblue.com', NULL, NULL, NULL, NULL, NULL, NULL, N'Ultimate', 24, NULL, NULL, CAST(N'2018-07-24T05:26:54.633' AS DateTime), 1, 0)

INSERT [dbo].[Company] ([CompanyID], [EmployeeID], [UserName], [UserID], [CompanyName], [Address1], [Address2], [City], [State], [Zip], [Country], [Phone1], [Phone2], [Email1], [Email2], [WebSite], [CompanyPrimaryImg], [CompanySecondaryImg], [CompanyDescription], [CompanyText], [ArticleDescription], [ArticleText], [ServiceLevel], [BillingCycle], [ResaleCertificate], [ContractorLicense], [CreateDate], [Active], [Deleted]) VALUES (501, 501, N'bowonderobDBPI', NULL, N'E3 Image Group', N'17865 Von Karman Ave', N'Suite 150', N'Irvine', N'CA', N'92614', N'US', N'7143090115', N'9494294488', N'rob@e3imagegroup.com', NULL, N'e3imagegroup.com', NULL, NULL, NULL, NULL, NULL, NULL, N'Professional', 24, NULL, NULL, CAST(N'2018-07-24T05:32:00.123' AS DateTime), 1, 0)

INSERT [dbo].[Company] ([CompanyID], [EmployeeID], [UserName], [UserID], [CompanyName], [Address1], [Address2], [City], [State], [Zip], [Country], [Phone1], [Phone2], [Email1], [Email2], [WebSite], [CompanyPrimaryImg], [CompanySecondaryImg], [CompanyDescription], [CompanyText], [ArticleDescription], [ArticleText], [ServiceLevel], [BillingCycle], [ResaleCertificate], [ContractorLicense], [CreateDate], [Active], [Deleted]) VALUES (500, 500, N'rorygod', NULL, N'RawrData Technology, LLC', N'10 BurningInHell Dr.', NULL, N'Aliso Viejo', N'CA', N'92656', N'US', N'(949) 949 1234', NULL, N'rorybre@gmail.com', NULL, N'rawrdata.com', NULL, NULL, NULL, NULL, NULL, NULL, N'Standard', 24, NULL, NULL, CAST(N'2018-07-24T22:26:21.000' AS DateTime), 1, 0)

INSERT [dbo].[Company] ([CompanyID], [EmployeeID], [UserName], [UserID], [CompanyName], [Address1], [Address2], [City], [State], [Zip], [Country], [Phone1], [Phone2], [Email1], [Email2], [WebSite], [CompanyPrimaryImg], [CompanySecondaryImg], [CompanyDescription], [CompanyText], [ArticleDescription], [ArticleText], [ServiceLevel], [BillingCycle], [ResaleCertificate], [ContractorLicense], [CreateDate], [Active], [Deleted]) VALUES (503, 503, N'mark', NULL, N'Mark Kennedy, Inc.', NULL, NULL, NULL, NULL, NULL, NULL, N'(949) 656-9352', NULL, N'mkennedy@aingealbear.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'UltimatePro', 248, NULL, NULL, CAST(N'2018-07-28T22:26:21.363' AS DateTime), 1, 0)

INSERT [dbo].[Company] ([CompanyID], [EmployeeID], [UserName], [UserID], [CompanyName], [Address1], [Address2], [City], [State], [Zip], [Country], [Phone1], [Phone2], [Email1], [Email2], [WebSite], [CompanyPrimaryImg], [CompanySecondaryImg], [CompanyDescription], [CompanyText], [ArticleDescription], [ArticleText], [ServiceLevel], [BillingCycle], [ResaleCertificate], [ContractorLicense], [CreateDate], [Active], [Deleted]) VALUES (506, 507, N'JasonT', NULL, N'E3 Image Group', NULL, NULL, NULL, NULL, NULL, NULL, N'7605325063', NULL, N'jason@designandcre8.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Standard', 4, NULL, NULL, CAST(N'2018-10-04T18:44:42.000' AS DateTime), 1, 0)

INSERT [dbo].[Company] ([CompanyID], [EmployeeID], [UserName], [UserID], [CompanyName], [Address1], [Address2], [City], [State], [Zip], [Country], [Phone1], [Phone2], [Email1], [Email2], [WebSite], [CompanyPrimaryImg], [CompanySecondaryImg], [CompanyDescription], [CompanyText], [ArticleDescription], [ArticleText], [ServiceLevel], [BillingCycle], [ResaleCertificate], [ContractorLicense], [CreateDate], [Active], [Deleted]) VALUES (507, 508, N'testadmin10', NULL, N'RawrData Technology, LLC', N'10 Meadowpoint', NULL, N'Aliso Viejo', N'CA', N'92656', N'US', N'(949) 949 1234', NULL, N'service@bestblogsever.com', NULL, N'rawrdata.com', NULL, NULL, NULL, NULL, NULL, NULL, N'Standard', 24, NULL, NULL, CAST(N'2018-07-24T22:26:21.000' AS DateTime), 1, 0)

SET IDENTITY_INSERT [dbo].[Company] OFF
SET IDENTITY_INSERT [dbo].[Contacts] ON 

INSERT [dbo].[Contacts] ([ContactID], [Email], [FirstName], [LastName], [CompanyName], [Phone], [Interest], [MessageText], [DateTime], [Active], [Deleted]) VALUES (1, N'rorybre@gmail.com', N'Rory', N'Bresnan', N'RawrData Technology, LLC', N'9497420173', NULL, N'test db w date', CAST(N'2018-07-12T15:51:38.610' AS DateTime), 1, 0)
INSERT [dbo].[Contacts] ([ContactID], [Email], [FirstName], [LastName], [CompanyName], [Phone], [Interest], [MessageText], [DateTime], [Active], [Deleted]) VALUES (4, N'rorybre@gmail.com', N'Rory', N'Bresnan', N'RawrData Technology, LLC', N'9497420173', NULL, N'test', CAST(N'2018-07-13T00:46:29.333' AS DateTime), 0, 0)
INSERT [dbo].[Contacts] ([ContactID], [Email], [FirstName], [LastName], [CompanyName], [Phone], [Interest], [MessageText], [DateTime], [Active], [Deleted]) VALUES (5, N'rorybre@gmail.com', N'Rory', N'Bresnan', N'RawrData Technology, LLC', N'9497420173', NULL, N'test email template function after move to messages controller', CAST(N'2018-07-14T09:35:05.840' AS DateTime), 0, 0)
SET IDENTITY_INSERT [dbo].[Contacts] OFF
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([EmployeeID], [UserID], [UserName], [CompanyID], [Company_EmployeeID], [FirstName], [LastName], [Address1], [Address2], [City], [State], [Zip], [Country], [Phone1], [Phone2], [Email1], [Email2], [Notes], [Deleted], [Active], [CompanyCreator], [CreateDate]) VALUES (500, NULL, N'rorygod', 500, NULL, N'Rory', N'Bresnan', N'10 Meadowpoint', NULL, N'Aliso Viejo', N'CA', N'92656', N'US', N'9497420173', NULL, N'rorybre@gmail.com', NULL, NULL, 0, 1, 1, CAST(N'2018-07-24T05:26:54.883' AS DateTime))

INSERT [dbo].[Employees] ([EmployeeID], [UserID], [UserName], [CompanyID], [Company_EmployeeID], [FirstName], [LastName], [Address1], [Address2], [City], [State], [Zip], [Country], [Phone1], [Phone2], [Email1], [Email2], [Notes], [Deleted], [Active], [CompanyCreator], [CreateDate]) VALUES (501, NULL, N'bowonderobDBPI', 501, NULL, N'Rob', N'Evans', N'33 Solitare Lane', NULL, N'Aliso Viejo', N'CA', N'92656', N'US', N'9497420173', N'9494294488', N'rob@e3imagegroup.com', NULL, NULL, 0, 1, 1, CAST(N'2018-07-24T05:32:00.370' AS DateTime))

INSERT [dbo].[Employees] ([EmployeeID], [UserID], [UserName], [CompanyID], [Company_EmployeeID], [FirstName], [LastName], [Address1], [Address2], [City], [State], [Zip], [Country], [Phone1], [Phone2], [Email1], [Email2], [Notes], [Deleted], [Active], [CompanyCreator], [CreateDate]) VALUES (502, NULL, N'jmoore963', 502, NULL, N'Jim', N'Moore', NULL, NULL, NULL, NULL, NULL, NULL, N'858 254-8066', NULL, N'jim@bellblue.com', NULL, NULL, 0, 1, 1, CAST(N'2018-07-24T22:26:21.000' AS DateTime))

INSERT [dbo].[Employees] ([EmployeeID], [UserID], [UserName], [CompanyID], [Company_EmployeeID], [FirstName], [LastName], [Address1], [Address2], [City], [State], [Zip], [Country], [Phone1], [Phone2], [Email1], [Email2], [Notes], [Deleted], [Active], [CompanyCreator], [CreateDate]) VALUES (503, NULL, N'mark', 503, NULL, N'Mark', N'Kennedy', NULL, NULL, N'Aliso Viejo', N'CA', N'92656', N'US', N'(949) 656-9352', NULL, N'mkennedy@aingealbear.com', NULL, NULL, 0, 1, 1, CAST(N'2018-07-24T22:24:21.757' AS DateTime))

INSERT [dbo].[Employees] ([EmployeeID], [UserID], [UserName], [CompanyID], [Company_EmployeeID], [FirstName], [LastName], [Address1], [Address2], [City], [State], [Zip], [Country], [Phone1], [Phone2], [Email1], [Email2], [Notes], [Deleted], [Active], [CompanyCreator], [CreateDate]) VALUES (507, NULL, N'jasonT', 506, NULL, N'Jason', N'T', NULL, NULL, NULL, NULL, NULL, NULL, N'7605325063', NULL, N'jason@designandcre8.com', NULL, NULL, 0, 1, 1, CAST(N'2018-10-04T16:42:08.000' AS DateTime))

INSERT [dbo].[Employees] ([EmployeeID], [UserID], [UserName], [CompanyID], [Company_EmployeeID], [FirstName], [LastName], [Address1], [Address2], [City], [State], [Zip], [Country], [Phone1], [Phone2], [Email1], [Email2], [Notes], [Deleted], [Active], [CompanyCreator], [CreateDate]) VALUES (508, NULL, N'testadmin10', 500, NULL, N'Rory', N'Bresnan', N'10 Meadowpoint', NULL, N'Aliso Viejo', N'CA', N'92656', N'US', N'9497420173', NULL, N'service@bestblogsever.com', NULL, NULL, 0, 1, 1, CAST(N'2018-07-24T05:26:54.883' AS DateTime))
SET IDENTITY_INSERT [dbo].[Employees] OFF
SET IDENTITY_INSERT [dbo].[ItemCategories] ON 

INSERT [dbo].[ItemCategories] ([CategoryID], [CategoryName], [CategoryDescription], [CategoryHeader], [Image1], [Image2], [Image3], [WebLink1], [Weblink2], [Active], [Featured], [ShowOnRelated], [IsSubCat], [SubCatOf], [CategoryLongText], [Notes], [Sequence]) VALUES (500, N'Printed Material', N'General category for Print Jobs', N'General category for Print Jobs', NULL, NULL, NULL, NULL, NULL, 1, 0, 0, 0, NULL, NULL, NULL, 1)
INSERT [dbo].[ItemCategories] ([CategoryID], [CategoryName], [CategoryDescription], [CategoryHeader], [Image1], [Image2], [Image3], [WebLink1], [Weblink2], [Active], [Featured], [ShowOnRelated], [IsSubCat], [SubCatOf], [CategoryLongText], [Notes], [Sequence]) VALUES (501, N'Office Supplies', N'Office and Print Supplies ', N'Office Supplies', NULL, NULL, NULL, NULL, NULL, 1, 0, 0, 0, NULL, NULL, NULL, 2)
INSERT [dbo].[ItemCategories] ([CategoryID], [CategoryName], [CategoryDescription], [CategoryHeader], [Image1], [Image2], [Image3], [WebLink1], [Weblink2], [Active], [Featured], [ShowOnRelated], [IsSubCat], [SubCatOf], [CategoryLongText], [Notes], [Sequence]) VALUES (502, N'Reproduction/Graphic Services', N'Reproduction/Graphic Services', N'Reproduction/Graphic Services', NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, NULL, NULL, NULL, 3)
SET IDENTITY_INSERT [dbo].[ItemCategories] OFF
SET IDENTITY_INSERT [dbo].[Messages] ON 

INSERT [dbo].[Messages] ([MessageID], [FromID], [FromEmail], [FromFName], [FromLName], [FromCompany], [ToID], [ToEmail], [ToFName], [ToLName], [ToCompany], [MessageSubject], [MessageText], [MessageDate], [ResponseDate], [DBPImail], [Deleted], [DeleteDate]) VALUES (1, 561, N'rorygod@caca.com', N'Rory', N'Bresnan', 565, 603, N'rorybre@gmail.com', N'Rory', N'Bresnan', 605, N'test', N'test test test test test test', CAST(N'2018-07-07T14:40:06.803' AS DateTime), NULL, 1, 0, NULL)
INSERT [dbo].[Messages] ([MessageID], [FromID], [FromEmail], [FromFName], [FromLName], [FromCompany], [ToID], [ToEmail], [ToFName], [ToLName], [ToCompany], [MessageSubject], [MessageText], [MessageDate], [ResponseDate], [DBPImail], [Deleted], [DeleteDate]) VALUES (2, 561, N'rorygod@caca.com', N'Rory', N'Bresnan', 565, 603, N'rorybre@gmail.com', N'Rory', N'Bresnan', 605, N'test', N'test test test test test test', CAST(N'2018-07-07T14:54:36.227' AS DateTime), NULL, 1, 0, NULL)
INSERT [dbo].[Messages] ([MessageID], [FromID], [FromEmail], [FromFName], [FromLName], [FromCompany], [ToID], [ToEmail], [ToFName], [ToLName], [ToCompany], [MessageSubject], [MessageText], [MessageDate], [ResponseDate], [DBPImail], [Deleted], [DeleteDate]) VALUES (3, 561, N'rorygod@caca.com', N'Rory', N'Bresnan', 565, 603, N'rorybre@gmail.com', N'Rory', N'Bresnan', 605, N'test', N'test test test test test test', CAST(N'2018-07-07T19:28:53.573' AS DateTime), NULL, 1, 0, NULL)
SET IDENTITY_INSERT [dbo].[Messages] OFF
SET IDENTITY_INSERT [dbo].[OrderStatus] ON 

INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatus], [Description], [Active], [Deleted], [Sequence]) VALUES (1, N'Order Opened', N'Your order has been placed but not processed yet', 1, 0, 1)
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatus], [Description], [Active], [Deleted], [Sequence]) VALUES (2, N'Pending Payment', N'Your order has been placed, but processing is pending your payment', 1, 0, 2)
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatus], [Description], [Active], [Deleted], [Sequence]) VALUES (3, N'In Production', N'Your Order is in production', 1, 0, 3)
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatus], [Description], [Active], [Deleted], [Sequence]) VALUES (4, N'Shipped', N'Your order has been shipped', 1, 0, 4)
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatus], [Description], [Active], [Deleted], [Sequence]) VALUES (5, N'Fulfilled', N'Your order has been processed, payment received, shipped to your location and received', 1, 0, 5)
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatus], [Description], [Active], [Deleted], [Sequence]) VALUES (6, N'Deleted', N'Your order was deleted by the customer before being placed', 1, 0, 6)
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatus], [Description], [Active], [Deleted], [Sequence]) VALUES (7, N'Canceled', N'This order was canceled after it was placed', 1, 0, 7)
SET IDENTITY_INSERT [dbo].[OrderStatus] OFF
SET IDENTITY_INSERT [dbo].[ProjectCategories] ON 

INSERT [dbo].[ProjectCategories] ([ProjectCategoryID], [CategoryName], [CategoryDescription], [Active], [Deleted], [Sequence]) VALUES (1, N'Rough-in Electrical', N'Rough-in Electrical', 0, 0, NULL)
INSERT [dbo].[ProjectCategories] ([ProjectCategoryID], [CategoryName], [CategoryDescription], [Active], [Deleted], [Sequence]) VALUES (2, N'Finish Electrical', N'Finish Electrical', 0, 0, NULL)
INSERT [dbo].[ProjectCategories] ([ProjectCategoryID], [CategoryName], [CategoryDescription], [Active], [Deleted], [Sequence]) VALUES (3, N'Rough-in Plumbing', N'Rough-in Plumbing', 0, 0, NULL)
SET IDENTITY_INSERT [dbo].[ProjectCategories] OFF
SET IDENTITY_INSERT [dbo].[Projects] ON 

INSERT [dbo].[Projects] ([ProjectID], [ProjectName], [ProjectDescription], [ProjectStatus], [ProjectCategory], [OpenDate], [BidOpenDate], [BidCloseDate], [CompanyID], [Deleted], [Active], [Notes], [Complete], [CompletionDate], [RequiredDate], [BidStatus], [AcceptedBid], [AcceptedCompany], [ActionDate], [SiteAddress1], [SiteAddress2], [SiteAddressCity], [SiteAddressState], [SiteAddressZip], [SiteAddressCountry], [Dependencies], [IsSubProject], [SubProjectOf]) VALUES (508, N'Test Project 1', N'Test Project 1Test Project 1Test Project 1Test Project 1Test Project 1', 0, 0, CAST(N'2018-10-30T00:00:00.000' AS DateTime), CAST(N'2018-10-30T00:00:00.000' AS DateTime), CAST(N'2018-11-15T00:00:00.000' AS DateTime), 565, 0, 1, N'Test Project 1Test Project 1Test Project 1Test Project 1Test Project 1Test Project 1Test Project 1', 0, NULL, CAST(N'2018-11-30T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[Projects] ([ProjectID], [ProjectName], [ProjectDescription], [ProjectStatus], [ProjectCategory], [OpenDate], [BidOpenDate], [BidCloseDate], [CompanyID], [Deleted], [Active], [Notes], [Complete], [CompletionDate], [RequiredDate], [BidStatus], [AcceptedBid], [AcceptedCompany], [ActionDate], [SiteAddress1], [SiteAddress2], [SiteAddressCity], [SiteAddressState], [SiteAddressZip], [SiteAddressCountry], [Dependencies], [IsSubProject], [SubProjectOf]) VALUES (511, N'Test Project 2', N'Test Project 2Test Project 2Test Project 2Test Project 2Test Project 2Test Project 2Test Project 2Test Project 2Test Project 2Test Project 2', 0, 0, CAST(N'2018-10-30T00:00:00.000' AS DateTime), CAST(N'2018-10-30T00:00:00.000' AS DateTime), CAST(N'2018-11-15T00:00:00.000' AS DateTime), 565, 0, 0, N'Test Project 2Test Project 2Test Project 2Test Project 2Test Project 2', 0, NULL, CAST(N'2018-11-15T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
SET IDENTITY_INSERT [dbo].[Projects] OFF
SET IDENTITY_INSERT [dbo].[ProjectStatus] ON 

INSERT [dbo].[ProjectStatus] ([ProjectStatusID], [ProjectStatusName], [Description], [Active], [Deleted], [Sequence]) VALUES (1, N'Staging', N'The Project is open for defining the Sub-Projects and tasks, but is not in production at this time', 1, 0, 1)
INSERT [dbo].[ProjectStatus] ([ProjectStatusID], [ProjectStatusName], [Description], [Active], [Deleted], [Sequence]) VALUES (2, N'Open for Bid', N'Open for Bid', 1, 0, 2)
INSERT [dbo].[ProjectStatus] ([ProjectStatusID], [ProjectStatusName], [Description], [Active], [Deleted], [Sequence]) VALUES (3, N'Awarded', N'The Project contract has been awarded to a Bidder', 1, 0, 3)
INSERT [dbo].[ProjectStatus] ([ProjectStatusID], [ProjectStatusName], [Description], [Active], [Deleted], [Sequence]) VALUES (4, N'On Hold', N'The Project is On Hold and is not accepting bids right now', 1, 0, 4)
INSERT [dbo].[ProjectStatus] ([ProjectStatusID], [ProjectStatusName], [Description], [Active], [Deleted], [Sequence]) VALUES (5, N'Closed to Bids', N'This Project is closed to bids', 1, 0, 5)
SET IDENTITY_INSERT [dbo].[ProjectStatus] OFF
SET IDENTITY_INSERT [dbo].[ServicePlans] ON 

INSERT [dbo].[ServicePlans] ([ServicePlanID], [ServicePlanName], [ShortDescription], [LongDescription], [Seats], [Storage], [FeatureA], [FeatureB], [FeatureC], [FeatureD], [FeatureE], [AddSeatCost], [MontlhyCost], [AnnualCost], [DiscountPercent], [Sequence]) VALUES (100, N'Standard', N'Free 2-Seat Account', N'This is an excellent starting point if you aren''t sure of where to begin.  ', N'2', N'100MB', NULL, NULL, NULL, NULL, NULL, CAST(50 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), 1)
INSERT [dbo].[ServicePlans] ([ServicePlanID], [ServicePlanName], [ShortDescription], [LongDescription], [Seats], [Storage], [FeatureA], [FeatureB], [FeatureC], [FeatureD], [FeatureE], [AddSeatCost], [MontlhyCost], [AnnualCost], [DiscountPercent], [Sequence]) VALUES (101, N'Premium', N'Full Service account for teams up to 5 People', N'Full Service account for teams up to 5 People', N'5', N'2GB', NULL, NULL, NULL, NULL, NULL, CAST(50 AS Decimal(18, 0)), CAST(399 AS Decimal(18, 0)), CAST(4548 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), 2)
INSERT [dbo].[ServicePlans] ([ServicePlanID], [ServicePlanName], [ShortDescription], [LongDescription], [Seats], [Storage], [FeatureA], [FeatureB], [FeatureC], [FeatureD], [FeatureE], [AddSeatCost], [MontlhyCost], [AnnualCost], [DiscountPercent], [Sequence]) VALUES (102, N'Professional', N'Full Service account for teams up to 10 People', N'Full Service account for teams up to 10 People', N'10', N'5GB', NULL, NULL, NULL, NULL, NULL, CAST(50 AS Decimal(18, 0)), CAST(799 AS Decimal(18, 0)), CAST(8916 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), 3)
INSERT [dbo].[ServicePlans] ([ServicePlanID], [ServicePlanName], [ShortDescription], [LongDescription], [Seats], [Storage], [FeatureA], [FeatureB], [FeatureC], [FeatureD], [FeatureE], [AddSeatCost], [MontlhyCost], [AnnualCost], [DiscountPercent], [Sequence]) VALUES (103, N'Ultimate', N'Full Service account for teams up to 25 People', N'Full Service account for teams up to 25 People', N'25', N'10GB', NULL, NULL, NULL, NULL, NULL, CAST(50 AS Decimal(18, 0)), CAST(1299 AS Decimal(18, 0)), CAST(12029 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), 4)
INSERT [dbo].[ServicePlans] ([ServicePlanID], [ServicePlanName], [ShortDescription], [LongDescription], [Seats], [Storage], [FeatureA], [FeatureB], [FeatureC], [FeatureD], [FeatureE], [AddSeatCost], [MontlhyCost], [AnnualCost], [DiscountPercent], [Sequence]) VALUES (104, N'UltimatePro', N'Full Service, Unlimited Seats', N'Full Service, Unlimited Seats', N'Unlimited', N'50GB', NULL, NULL, NULL, NULL, NULL, CAST(50 AS Decimal(18, 0)), CAST(1999 AS Decimal(18, 0)), CAST(20390 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), 5)
SET IDENTITY_INSERT [dbo].[ServicePlans] OFF
ALTER TABLE [dbo].[Bids] ADD  CONSTRAINT [DF_Bids_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Bids] ADD  CONSTRAINT [DF_Bids_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[BidStatus] ADD  CONSTRAINT [DF_BidStatus_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[BidStatus] ADD  CONSTRAINT [DF_BidStatus_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[BlogCategories] ADD  CONSTRAINT [DF_BlogCategories_Post_Active]  DEFAULT ((1)) FOR [Post_Active]
GO
ALTER TABLE [dbo].[BlogComments] ADD  CONSTRAINT [DF_BlogComments_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[BlogComments] ADD  CONSTRAINT [DF_BlogComments_Active]  DEFAULT ((0)) FOR [Active]
GO
ALTER TABLE [dbo].[BlogPosts] ADD  CONSTRAINT [DF_BlogPosts_Post_Deleted]  DEFAULT ((0)) FOR [Post_Deleted]
GO
ALTER TABLE [dbo].[BlogPosts] ADD  CONSTRAINT [DF_BlogPosts_Post_Active]  DEFAULT ((0)) FOR [Post_Active]
GO
ALTER TABLE [dbo].[BlogPosts] ADD  CONSTRAINT [DF_BlogPosts_Post_Featured]  DEFAULT ((0)) FOR [Post_Featured]
GO
ALTER TABLE [dbo].[BlogPosts] ADD  CONSTRAINT [DF_BlogPosts_Post_CommentsAllowed]  DEFAULT ((0)) FOR [Post_CommentsAllowed]
GO
ALTER TABLE [dbo].[BlogPosts] ADD  CONSTRAINT [DF_BlogPosts_Post_CommentsReview]  DEFAULT ((1)) FOR [Post_CommentsReview]
GO
ALTER TABLE [dbo].[Company] ADD  CONSTRAINT [DF_Company_ServiceLevel]  DEFAULT (N'Standard') FOR [ServiceLevel]
GO
ALTER TABLE [dbo].[Company] ADD  CONSTRAINT [DF_Company_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Company] ADD  CONSTRAINT [DF_Company_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Contacts] ADD  CONSTRAINT [DF_Contacts_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Contacts] ADD  CONSTRAINT [DF_Contacts_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Documents] ADD  CONSTRAINT [DF_Documents_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Documents] ADD  CONSTRAINT [DF_Documents_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_CompanyCreator]  DEFAULT ((0)) FOR [CompanyCreator]
GO
ALTER TABLE [dbo].[ItemBoxes] ADD  CONSTRAINT [DF_ItemBoxes_InnerOuter]  DEFAULT ((0)) FOR [InnerOuter]
GO
ALTER TABLE [dbo].[ItemBoxes] ADD  CONSTRAINT [DF_ItemBoxes_RuralZone]  DEFAULT ((0)) FOR [RuralZone]
GO
ALTER TABLE [dbo].[ItemBoxes] ADD  CONSTRAINT [DF_ItemBoxes_InternationalZone]  DEFAULT ((0)) FOR [InternationalZone]
GO
ALTER TABLE [dbo].[ItemBoxes] ADD  CONSTRAINT [DF_ItemBoxes_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[ItemBoxes] ADD  CONSTRAINT [DF_ItemBoxes_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[ItemCategories] ADD  CONSTRAINT [DF_ItemCategories_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[ItemCategories] ADD  CONSTRAINT [DF_ItemCategories_Featured]  DEFAULT ((0)) FOR [Featured]
GO
ALTER TABLE [dbo].[ItemCategories] ADD  CONSTRAINT [DF_ItemCategories_ShowOnRelated]  DEFAULT ((0)) FOR [ShowOnRelated]
GO
ALTER TABLE [dbo].[ItemCategories] ADD  CONSTRAINT [DF_ItemCategories_IsSubCat]  DEFAULT ((0)) FOR [IsSubCat]
GO
ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [DF_Items_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [DF_Items_Featured]  DEFAULT ((0)) FOR [Featured]
GO
ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [DF_Items_Outlet]  DEFAULT ((0)) FOR [Outlet]
GO
ALTER TABLE [dbo].[Messages] ADD  CONSTRAINT [DF_Messages_DBPImail]  DEFAULT ((1)) FOR [DBPImail]
GO
ALTER TABLE [dbo].[Messages] ADD  CONSTRAINT [DF_Messages_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[OrderLine] ADD  CONSTRAINT [DF_OrderLine_Fullfilled]  DEFAULT ((0)) FOR [Fullfilled]
GO
ALTER TABLE [dbo].[OrderLine] ADD  CONSTRAINT [DF_OrderLine_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[OrderLine] ADD  CONSTRAINT [DF_OrderLine_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_Fulfilled]  DEFAULT ((0)) FOR [Fulfilled]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[OrderStatus] ADD  CONSTRAINT [DF_OrderStatus_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[OrderStatus] ADD  CONSTRAINT [DF_OrderStatus_Deleted]  DEFAULT ((1)) FOR [Deleted]
GO
ALTER TABLE [dbo].[PaymentMethods] ADD  CONSTRAINT [DF_PaymentMethods_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[PaymentMethods] ADD  CONSTRAINT [DF_PaymentMethods_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Payments] ADD  CONSTRAINT [DF_Payments_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Payments] ADD  CONSTRAINT [DF_Payments_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[ProjectCategories] ADD  CONSTRAINT [DF_ProjectCategories_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[ProjectCategories] ADD  CONSTRAINT [DF_ProjectCategories_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_ProjectCategory]  DEFAULT ((0)) FOR [ProjectCategory]
GO
ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_Complete]  DEFAULT ((0)) FOR [Complete]
GO
ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_IsSubProject]  DEFAULT ((0)) FOR [IsSubProject]
GO
ALTER TABLE [dbo].[ProjectStatus] ADD  CONSTRAINT [DF_ProjectStatus_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[ProjectStatus] ADD  CONSTRAINT [DF_ProjectStatus_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Reviews] ADD  CONSTRAINT [DF_Reviews_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Reviews] ADD  CONSTRAINT [DF_Reviews_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Reviews] ADD  CONSTRAINT [DF_Reviews_Featured]  DEFAULT ((0)) FOR [Featured]
GO
ALTER TABLE [dbo].[SubProjects] ADD  CONSTRAINT [DF_SubProjects_ProjectCategory]  DEFAULT ((0)) FOR [ProjectCategory]
GO
ALTER TABLE [dbo].[SubProjects] ADD  CONSTRAINT [DF_SubProjects_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[SubProjects] ADD  CONSTRAINT [DF_SubProjects_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[SubProjects] ADD  CONSTRAINT [DF_SubProjects_Complete]  DEFAULT ((0)) FOR [Complete]
GO
ALTER TABLE [dbo].[SubProjects] ADD  CONSTRAINT [DF_SubProjects_IsSubProject]  DEFAULT ((0)) FOR [IsSubProject]
GO
ALTER TABLE [dbo].[AltAddress]  WITH CHECK ADD  CONSTRAINT [FK_AltAddress_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[AltAddress] CHECK CONSTRAINT [FK_AltAddress_Company]
GO
ALTER TABLE [dbo].[Bids]  WITH CHECK ADD  CONSTRAINT [FK_Bids_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[Bids] CHECK CONSTRAINT [FK_Bids_Company]
GO
ALTER TABLE [dbo].[Bids]  WITH CHECK ADD  CONSTRAINT [FK_Bids_SubProjects] FOREIGN KEY([SubProjectID])
REFERENCES [dbo].[SubProjects] ([SubProjectID])
GO
ALTER TABLE [dbo].[Bids] CHECK CONSTRAINT [FK_Bids_SubProjects]
GO
ALTER TABLE [dbo].[BlogComments]  WITH CHECK ADD  CONSTRAINT [FK_BlogComments_BlogPosts] FOREIGN KEY([PostID])
REFERENCES [dbo].[BlogPosts] ([PostID])
GO
ALTER TABLE [dbo].[BlogComments] CHECK CONSTRAINT [FK_BlogComments_BlogPosts]
GO
ALTER TABLE [dbo].[BlogPosts]  WITH CHECK ADD  CONSTRAINT [FK_BlogPosts_BlogCategories] FOREIGN KEY([Post_CategoryID])
REFERENCES [dbo].[BlogCategories] ([Post_CategoryID])
GO
ALTER TABLE [dbo].[BlogPosts] CHECK CONSTRAINT [FK_BlogPosts_BlogCategories]
GO
ALTER TABLE [dbo].[Documents]  WITH CHECK ADD  CONSTRAINT [FK_Documents_Company] FOREIGN KEY([DocumentID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[Documents] CHECK CONSTRAINT [FK_Documents_Company]
GO
ALTER TABLE [dbo].[Documents]  WITH CHECK ADD  CONSTRAINT [FK_Documents_SubProjects] FOREIGN KEY([SubProjectID])
REFERENCES [dbo].[SubProjects] ([SubProjectID])
GO
ALTER TABLE [dbo].[Documents] CHECK CONSTRAINT [FK_Documents_SubProjects]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Company]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_ItemBoxes] FOREIGN KEY([BoxID])
REFERENCES [dbo].[ItemBoxes] ([BoxID])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_ItemBoxes]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_ItemCategories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[ItemCategories] ([CategoryID])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_ItemCategories]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Employees] FOREIGN KEY([FromID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Employees]
GO
ALTER TABLE [dbo].[OrderLine]  WITH CHECK ADD  CONSTRAINT [FK_OrderLine_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[OrderLine] CHECK CONSTRAINT [FK_OrderLine_Orders]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Company]
GO
ALTER TABLE [dbo].[PaymentMethods]  WITH CHECK ADD  CONSTRAINT [FK_PaymentMethods_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[PaymentMethods] CHECK CONSTRAINT [FK_PaymentMethods_Company]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Orders]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_Company]
GO
ALTER TABLE [dbo].[SubProjects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_SubProjects] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Projects] ([ProjectID])
GO
ALTER TABLE [dbo].[SubProjects] CHECK CONSTRAINT [FK_Projects_SubProjects]
GO
USE [master]
GO
ALTER DATABASE [SiteDB] SET  READ_WRITE 
GO
