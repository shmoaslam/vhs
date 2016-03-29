USE [VHSLatest]
GO
ALTER TABLE [dbo].[UserTravelPrefMapping] DROP CONSTRAINT [FK__UserTrave__Trave__3F466844]
GO
ALTER TABLE [dbo].[UserTravelPrefMapping] DROP CONSTRAINT [FK__UserTrave__Login__403A8C7D]
GO
ALTER TABLE [dbo].[UserProfile] DROP CONSTRAINT [FK_dbo.UserProfile_dbo.UserLogin_LoginId]
GO
ALTER TABLE [dbo].[UserLogin] DROP CONSTRAINT [FK_dbo.UserLogin_dbo.UserType_TypeId]
GO
ALTER TABLE [dbo].[PropertyTravelBeatsMap] DROP CONSTRAINT [FK__PropertyT__TraBe__531856C7]
GO
ALTER TABLE [dbo].[PropertyTravelBeatsMap] DROP CONSTRAINT [FK__PropertyT__Prope__5224328E]
GO
ALTER TABLE [dbo].[PropertyTravelAmbassadorMap] DROP CONSTRAINT [FK__PropertyT__TraAm__4C6B5938]
GO
ALTER TABLE [dbo].[PropertyTravelAmbassadorMap] DROP CONSTRAINT [FK__PropertyT__Prope__4B7734FF]
GO
ALTER TABLE [dbo].[PropertySleepingMap] DROP CONSTRAINT [FK__PropertyS__Sleep__793DFFAF]
GO
ALTER TABLE [dbo].[PropertySleepingMap] DROP CONSTRAINT [FK__PropertyS__Prope__7849DB76]
GO
ALTER TABLE [dbo].[PropertyRMMapping] DROP CONSTRAINT [FK__PropertyR__Prope__46E78A0C]
GO
ALTER TABLE [dbo].[PropertyRMMapping] DROP CONSTRAINT [FK__PropertyR__Login__47DBAE45]
GO
ALTER TABLE [dbo].[PropertyPrice] DROP CONSTRAINT [FK__PropertyP__Prope__3864608B]
GO
ALTER TABLE [dbo].[PropertyParkingMap] DROP CONSTRAINT [FK__PropertyP__Prope__5D95E53A]
GO
ALTER TABLE [dbo].[PropertyParkingMap] DROP CONSTRAINT [FK__PropertyP__Parki__5E8A0973]
GO
ALTER TABLE [dbo].[PropertyOutdoorMap] DROP CONSTRAINT [FK__PropertyO__Prope__32767D0B]
GO
ALTER TABLE [dbo].[PropertyOutdoorMap] DROP CONSTRAINT [FK__PropertyO__OutFa__336AA144]
GO
ALTER TABLE [dbo].[PropertyKitchenMap] DROP CONSTRAINT [FK__PropertyK__Prope__0F2D40CE]
GO
ALTER TABLE [dbo].[PropertyKitchenMap] DROP CONSTRAINT [FK__PropertyK__Kitch__10216507]
GO
ALTER TABLE [dbo].[PropertyImageMapping] DROP CONSTRAINT [FK__PropertyI__Prope__33D4B598]
GO
ALTER TABLE [dbo].[PropertyImageMapping] DROP CONSTRAINT [FK__PropertyI__Image__34C8D9D1]
GO
ALTER TABLE [dbo].[PropertyGeneralMap] DROP CONSTRAINT [FK__PropertyG__Prope__1A9EF37A]
GO
ALTER TABLE [dbo].[PropertyGeneralMap] DROP CONSTRAINT [FK__PropertyG__Gener__1B9317B3]
GO
ALTER TABLE [dbo].[PropertyGallaryMap] DROP CONSTRAINT [FK__PropertyG__Prope__44CA3770]
GO
ALTER TABLE [dbo].[PropertyGallaryMap] DROP CONSTRAINT [FK__PropertyG__Image__45BE5BA9]
GO
ALTER TABLE [dbo].[PropertyEnterElecMap] DROP CONSTRAINT [FK__PropertyE__Prope__2610A626]
GO
ALTER TABLE [dbo].[PropertyEnterElecMap] DROP CONSTRAINT [FK__PropertyE__Enter__2704CA5F]
GO
ALTER TABLE [dbo].[PropertyCoverPhotoMap] DROP CONSTRAINT [FK__PropertyC__Prope__3E1D39E1]
GO
ALTER TABLE [dbo].[PropertyCoverPhotoMap] DROP CONSTRAINT [FK__PropertyC__Image__3F115E1A]
GO
ALTER TABLE [dbo].[PropertyBathRoomsMap] DROP CONSTRAINT [FK__PropertyB__Prope__03BB8E22]
GO
ALTER TABLE [dbo].[PropertyBathRoomsMap] DROP CONSTRAINT [FK__PropertyB__BathR__04AFB25B]
GO
ALTER TABLE [dbo].[PropertyAmenitiesMap] DROP CONSTRAINT [FK__PropertyA__Prope__6CD828CA]
GO
ALTER TABLE [dbo].[PropertyAmenitiesMap] DROP CONSTRAINT [FK__PropertyA__Ameni__6DCC4D03]
GO
ALTER TABLE [dbo].[PropertyAddress] DROP CONSTRAINT [FK__PropertAd__Prope__30F848ED]
GO
ALTER TABLE [dbo].[PropertyAdditionalInfo] DROP CONSTRAINT [FK__PropertyA__Prope__2FCF1A8A]
GO
ALTER TABLE [dbo].[Property] DROP CONSTRAINT [ListedId]
GO
ALTER TABLE [dbo].[Property] DROP CONSTRAINT [FK__Property__IsActi__29572725]
GO
ALTER TABLE [dbo].[Property] DROP CONSTRAINT [CategoryId]
GO
ALTER TABLE [dbo].[Documents] DROP CONSTRAINT [FK_dbo.Documents_dbo.UserLogin_LoginId]
GO
ALTER TABLE [dbo].[UserTravelPrefMapping] DROP CONSTRAINT [DF__UserTrave__Updat__151B244E]
GO
ALTER TABLE [dbo].[UserTravelPrefMapping] DROP CONSTRAINT [DF__UserTrave__Creat__14270015]
GO
ALTER TABLE [dbo].[TravelPreferences] DROP CONSTRAINT [DF__TravelPre__Updae__1DB06A4F]
GO
ALTER TABLE [dbo].[TravelPreferences] DROP CONSTRAINT [DF__TravelPre__Creat__1CBC4616]
GO
ALTER TABLE [dbo].[TravelPreferences] DROP CONSTRAINT [DF__TravelPre__IsAct__17F790F9]
GO
ALTER TABLE [dbo].[SleepingArrangement] DROP CONSTRAINT [DF__SleepingA__IsAct__756D6ECB]
GO
ALTER TABLE [dbo].[SleepingArrangement] DROP CONSTRAINT [DF__SleepingA__Updat__74794A92]
GO
ALTER TABLE [dbo].[SleepingArrangement] DROP CONSTRAINT [DF__SleepingA__Creat__73852659]
GO
ALTER TABLE [dbo].[PropertyTravelBeatsMap] DROP CONSTRAINT [DF__PropertyT__IsAct__55F4C372]
GO
ALTER TABLE [dbo].[PropertyTravelBeatsMap] DROP CONSTRAINT [DF__PropertyT__Updat__55009F39]
GO
ALTER TABLE [dbo].[PropertyTravelBeatsMap] DROP CONSTRAINT [DF__PropertyT__Creat__540C7B00]
GO
ALTER TABLE [dbo].[PropertyTravelAmbassadorMap] DROP CONSTRAINT [DF__PropertyT__IsAct__4F47C5E3]
GO
ALTER TABLE [dbo].[PropertyTravelAmbassadorMap] DROP CONSTRAINT [DF__PropertyT__Updat__4E53A1AA]
GO
ALTER TABLE [dbo].[PropertyTravelAmbassadorMap] DROP CONSTRAINT [DF__PropertyT__Creat__4D5F7D71]
GO
ALTER TABLE [dbo].[PropertySleepingMap] DROP CONSTRAINT [DF__PropertyS__IsAct__7C1A6C5A]
GO
ALTER TABLE [dbo].[PropertySleepingMap] DROP CONSTRAINT [DF__PropertyS__Updat__7B264821]
GO
ALTER TABLE [dbo].[PropertySleepingMap] DROP CONSTRAINT [DF__PropertyS__Creat__7A3223E8]
GO
ALTER TABLE [dbo].[PropertyRMMapping] DROP CONSTRAINT [DF__PropertyR__Updat__70DDC3D8]
GO
ALTER TABLE [dbo].[PropertyRMMapping] DROP CONSTRAINT [DF__PropertyR__Creat__6FE99F9F]
GO
ALTER TABLE [dbo].[PropertyPrice] DROP CONSTRAINT [DF__PropertyP__IsAct__3B40CD36]
GO
ALTER TABLE [dbo].[PropertyPrice] DROP CONSTRAINT [DF__PropertyP__Updat__3A4CA8FD]
GO
ALTER TABLE [dbo].[PropertyPrice] DROP CONSTRAINT [DF__PropertyP__Creat__395884C4]
GO
ALTER TABLE [dbo].[PropertyPrice] DROP CONSTRAINT [DF__PropertyP__Price__37703C52]
GO
ALTER TABLE [dbo].[PropertyPrice] DROP CONSTRAINT [DF__PropertyP__EndDa__367C1819]
GO
ALTER TABLE [dbo].[PropertyPrice] DROP CONSTRAINT [DF__PropertyP__Start__3587F3E0]
GO
ALTER TABLE [dbo].[PropertyParkingMap] DROP CONSTRAINT [DF__PropertyP__IsAct__6166761E]
GO
ALTER TABLE [dbo].[PropertyParkingMap] DROP CONSTRAINT [DF__PropertyP__Updat__607251E5]
GO
ALTER TABLE [dbo].[PropertyParkingMap] DROP CONSTRAINT [DF__PropertyP__Creat__5F7E2DAC]
GO
ALTER TABLE [dbo].[PropertyOutdoorMap] DROP CONSTRAINT [DF__PropertyO__IsAct__36470DEF]
GO
ALTER TABLE [dbo].[PropertyOutdoorMap] DROP CONSTRAINT [DF__PropertyO__Updat__3552E9B6]
GO
ALTER TABLE [dbo].[PropertyOutdoorMap] DROP CONSTRAINT [DF__PropertyO__Creat__345EC57D]
GO
ALTER TABLE [dbo].[PropertyKitchenMap] DROP CONSTRAINT [DF__PropertyK__IsAct__12FDD1B2]
GO
ALTER TABLE [dbo].[PropertyKitchenMap] DROP CONSTRAINT [DF__PropertyK__Updat__1209AD79]
GO
ALTER TABLE [dbo].[PropertyKitchenMap] DROP CONSTRAINT [DF__PropertyK__Creat__11158940]
GO
ALTER TABLE [dbo].[PropertyGeneralMap] DROP CONSTRAINT [DF__PropertyG__IsAct__1E6F845E]
GO
ALTER TABLE [dbo].[PropertyGeneralMap] DROP CONSTRAINT [DF__PropertyG__Updat__1D7B6025]
GO
ALTER TABLE [dbo].[PropertyGeneralMap] DROP CONSTRAINT [DF__PropertyG__Creat__1C873BEC]
GO
ALTER TABLE [dbo].[PropertyGallaryMap] DROP CONSTRAINT [DF__PropertyG__IsAct__489AC854]
GO
ALTER TABLE [dbo].[PropertyGallaryMap] DROP CONSTRAINT [DF__PropertyG__Updat__47A6A41B]
GO
ALTER TABLE [dbo].[PropertyGallaryMap] DROP CONSTRAINT [DF__PropertyG__Creat__46B27FE2]
GO
ALTER TABLE [dbo].[PropertyEnterElecMap] DROP CONSTRAINT [DF__PropertyE__IsAct__29E1370A]
GO
ALTER TABLE [dbo].[PropertyEnterElecMap] DROP CONSTRAINT [DF__PropertyE__Updat__28ED12D1]
GO
ALTER TABLE [dbo].[PropertyEnterElecMap] DROP CONSTRAINT [DF__PropertyE__Creat__27F8EE98]
GO
ALTER TABLE [dbo].[PropertyCoverPhotoMap] DROP CONSTRAINT [DF__PropertyC__IsAct__41EDCAC5]
GO
ALTER TABLE [dbo].[PropertyCoverPhotoMap] DROP CONSTRAINT [DF__PropertyC__Updat__40F9A68C]
GO
ALTER TABLE [dbo].[PropertyCoverPhotoMap] DROP CONSTRAINT [DF__PropertyC__Creat__40058253]
GO
ALTER TABLE [dbo].[PropertyBathRoomsMap] DROP CONSTRAINT [DF__PropertyB__IsAct__078C1F06]
GO
ALTER TABLE [dbo].[PropertyBathRoomsMap] DROP CONSTRAINT [DF__PropertyB__Updat__0697FACD]
GO
ALTER TABLE [dbo].[PropertyBathRoomsMap] DROP CONSTRAINT [DF__PropertyB__Creat__05A3D694]
GO
ALTER TABLE [dbo].[PropertyAmenitiesMap] DROP CONSTRAINT [DF__PropertyA__IsAct__70A8B9AE]
GO
ALTER TABLE [dbo].[PropertyAmenitiesMap] DROP CONSTRAINT [DF__PropertyA__Updat__6FB49575]
GO
ALTER TABLE [dbo].[PropertyAmenitiesMap] DROP CONSTRAINT [DF__PropertyA__Creat__6EC0713C]
GO
ALTER TABLE [dbo].[PropertyAddress] DROP CONSTRAINT [DF__PropertAd__IsAct__300424B4]
GO
ALTER TABLE [dbo].[PropertyAddress] DROP CONSTRAINT [DF__PropertAd__Updat__2F10007B]
GO
ALTER TABLE [dbo].[PropertyAddress] DROP CONSTRAINT [DF__PropertAd__Creat__2E1BDC42]
GO
ALTER TABLE [dbo].[PropertyAddress] DROP CONSTRAINT [DF__PropertAd__Updat__2D27B809]
GO
ALTER TABLE [dbo].[PropertyAddress] DROP CONSTRAINT [DF__PropertAd__Creat__2C3393D0]
GO
ALTER TABLE [dbo].[PropertyAdditionalInfo] DROP CONSTRAINT [DF__PropertyA__IsAct__32AB8735]
GO
ALTER TABLE [dbo].[PropertyAdditionalInfo] DROP CONSTRAINT [DF__PropertyA__Updat__31B762FC]
GO
ALTER TABLE [dbo].[PropertyAdditionalInfo] DROP CONSTRAINT [DF__PropertyA__Creat__30C33EC3]
GO
ALTER TABLE [dbo].[PropertyAdditionalInfo] DROP CONSTRAINT [DF__PropertyA__IsWhe__2EDAF651]
GO
ALTER TABLE [dbo].[PropertyAdditionalInfo] DROP CONSTRAINT [DF__PropertyA__IsFam__2DE6D218]
GO
ALTER TABLE [dbo].[PropertyAdditionalInfo] DROP CONSTRAINT [DF__PropertyA__IsSmo__2CF2ADDF]
GO
ALTER TABLE [dbo].[PropertyAdditionalInfo] DROP CONSTRAINT [DF__PropertyA__IsDri__2BFE89A6]
GO
ALTER TABLE [dbo].[PropertyAdditionalInfo] DROP CONSTRAINT [DF__PropertyA__IsPet__2B0A656D]
GO
ALTER TABLE [dbo].[Property] DROP CONSTRAINT [DF__Property__PriceP__282DF8C2]
GO
ALTER TABLE [dbo].[Property] DROP CONSTRAINT [DF__Property__PriceP__2739D489]
GO
ALTER TABLE [dbo].[Parking] DROP CONSTRAINT [DF__Parking__IsActiv__5AB9788F]
GO
ALTER TABLE [dbo].[Parking] DROP CONSTRAINT [DF__Parking__Updated__59C55456]
GO
ALTER TABLE [dbo].[Parking] DROP CONSTRAINT [DF__Parking__Created__58D1301D]
GO
ALTER TABLE [dbo].[OutdoorFacilities] DROP CONSTRAINT [DF__OutdoorFa__IsAct__2EA5EC27]
GO
ALTER TABLE [dbo].[OutdoorFacilities] DROP CONSTRAINT [DF__OutdoorFa__Updat__2DB1C7EE]
GO
ALTER TABLE [dbo].[OutdoorFacilities] DROP CONSTRAINT [DF__OutdoorFa__Creat__2CBDA3B5]
GO
ALTER TABLE [dbo].[MailLink] DROP CONSTRAINT [DF__MailLink__Update__04E4BC85]
GO
ALTER TABLE [dbo].[MailLink] DROP CONSTRAINT [DF__MailLink__Create__03F0984C]
GO
ALTER TABLE [dbo].[MailLink] DROP CONSTRAINT [DF__MailLink__Expiry__02FC7413]
GO
ALTER TABLE [dbo].[Kitchen] DROP CONSTRAINT [DF__Kitchen__IsActiv__0C50D423]
GO
ALTER TABLE [dbo].[Kitchen] DROP CONSTRAINT [DF__Kitchen__Updated__0B5CAFEA]
GO
ALTER TABLE [dbo].[Kitchen] DROP CONSTRAINT [DF__Kitchen__Created__0A688BB1]
GO
ALTER TABLE [dbo].[General] DROP CONSTRAINT [DF__General__IsActiv__17C286CF]
GO
ALTER TABLE [dbo].[General] DROP CONSTRAINT [DF__General__Updated__16CE6296]
GO
ALTER TABLE [dbo].[General] DROP CONSTRAINT [DF__General__Created__15DA3E5D]
GO
ALTER TABLE [dbo].[EntertainmentElectronics] DROP CONSTRAINT [DF__Entertain__IsAct__2334397B]
GO
ALTER TABLE [dbo].[EntertainmentElectronics] DROP CONSTRAINT [DF__Entertain__Updat__22401542]
GO
ALTER TABLE [dbo].[EntertainmentElectronics] DROP CONSTRAINT [DF__Entertain__Creat__214BF109]
GO
ALTER TABLE [dbo].[Contact] DROP CONSTRAINT [DF__Contact__IsActvi__24927208]
GO
ALTER TABLE [dbo].[Contact] DROP CONSTRAINT [DF__Contact__Created__239E4DCF]
GO
ALTER TABLE [dbo].[BathRooms] DROP CONSTRAINT [DF__BathRooms__IsAct__00DF2177]
GO
ALTER TABLE [dbo].[BathRooms] DROP CONSTRAINT [DF__BathRooms__Updat__7FEAFD3E]
GO
ALTER TABLE [dbo].[BathRooms] DROP CONSTRAINT [DF__BathRooms__Creat__7EF6D905]
GO
ALTER TABLE [dbo].[Amenities] DROP CONSTRAINT [DF__Amenities__IsAct__69FBBC1F]
GO
ALTER TABLE [dbo].[Amenities] DROP CONSTRAINT [DF__Amenities__Updat__690797E6]
GO
ALTER TABLE [dbo].[Amenities] DROP CONSTRAINT [DF__Amenities__Creat__681373AD]
GO
/****** Object:  Index [IX_LoginId]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP INDEX [IX_LoginId] ON [dbo].[UserProfile]
GO
/****** Object:  Index [IX_TypeId]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP INDEX [IX_TypeId] ON [dbo].[UserLogin]
GO
/****** Object:  Index [IX_LoginId]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP INDEX [IX_LoginId] ON [dbo].[Documents]
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[UserType]
GO
/****** Object:  Table [dbo].[UserTravelPrefMapping]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[UserTravelPrefMapping]
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[UserProfile]
GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[UserLogin]
GO
/****** Object:  Table [dbo].[TravelPreferences]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[TravelPreferences]
GO
/****** Object:  Table [dbo].[SleepingArrangement]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[SleepingArrangement]
GO
/****** Object:  Table [dbo].[PropertyTravelBeatsMap]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[PropertyTravelBeatsMap]
GO
/****** Object:  Table [dbo].[PropertyTravelAmbassadorMap]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[PropertyTravelAmbassadorMap]
GO
/****** Object:  Table [dbo].[PropertySleepingMap]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[PropertySleepingMap]
GO
/****** Object:  Table [dbo].[PropertyRMMapping]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[PropertyRMMapping]
GO
/****** Object:  Table [dbo].[PropertyPrice]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[PropertyPrice]
GO
/****** Object:  Table [dbo].[PropertyParkingMap]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[PropertyParkingMap]
GO
/****** Object:  Table [dbo].[PropertyOutdoorMap]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[PropertyOutdoorMap]
GO
/****** Object:  Table [dbo].[PropertyListedBy]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[PropertyListedBy]
GO
/****** Object:  Table [dbo].[PropertyKitchenMap]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[PropertyKitchenMap]
GO
/****** Object:  Table [dbo].[PropertyImageMapping]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[PropertyImageMapping]
GO
/****** Object:  Table [dbo].[PropertyGeneralMap]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[PropertyGeneralMap]
GO
/****** Object:  Table [dbo].[PropertyGallaryMap]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[PropertyGallaryMap]
GO
/****** Object:  Table [dbo].[PropertyEnterElecMap]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[PropertyEnterElecMap]
GO
/****** Object:  Table [dbo].[PropertyCoverPhotoMap]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[PropertyCoverPhotoMap]
GO
/****** Object:  Table [dbo].[PropertyCategory]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[PropertyCategory]
GO
/****** Object:  Table [dbo].[PropertyBathRoomsMap]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[PropertyBathRoomsMap]
GO
/****** Object:  Table [dbo].[PropertyAmenitiesMap]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[PropertyAmenitiesMap]
GO
/****** Object:  Table [dbo].[PropertyAddress]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[PropertyAddress]
GO
/****** Object:  Table [dbo].[PropertyAdditionalInfo]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[PropertyAdditionalInfo]
GO
/****** Object:  Table [dbo].[Property]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[Property]
GO
/****** Object:  Table [dbo].[Parking]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[Parking]
GO
/****** Object:  Table [dbo].[OutdoorFacilities]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[OutdoorFacilities]
GO
/****** Object:  Table [dbo].[MailLink]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[MailLink]
GO
/****** Object:  Table [dbo].[Kitchen]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[Kitchen]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[Image]
GO
/****** Object:  Table [dbo].[General]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[General]
GO
/****** Object:  Table [dbo].[EntertainmentElectronics]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[EntertainmentElectronics]
GO
/****** Object:  Table [dbo].[Documents]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[Documents]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[Contact]
GO
/****** Object:  Table [dbo].[BathRooms]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[BathRooms]
GO
/****** Object:  Table [dbo].[Amenities]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[Amenities]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP TABLE [dbo].[__MigrationHistory]
GO
USE [master]
GO
/****** Object:  Database [VHSLatest]    Script Date: 3/28/2016 11:23:21 AM ******/
DROP DATABASE [VHSLatest]
GO
/****** Object:  Database [VHSLatest]    Script Date: 3/28/2016 11:23:21 AM ******/
CREATE DATABASE [VHSLatest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VHSLatest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\VHSLatest.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'VHSLatest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\VHSLatest_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [VHSLatest] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VHSLatest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VHSLatest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VHSLatest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VHSLatest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VHSLatest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VHSLatest] SET ARITHABORT OFF 
GO
ALTER DATABASE [VHSLatest] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [VHSLatest] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [VHSLatest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VHSLatest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VHSLatest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VHSLatest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VHSLatest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VHSLatest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VHSLatest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VHSLatest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VHSLatest] SET  ENABLE_BROKER 
GO
ALTER DATABASE [VHSLatest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VHSLatest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VHSLatest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VHSLatest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VHSLatest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VHSLatest] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [VHSLatest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VHSLatest] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [VHSLatest] SET  MULTI_USER 
GO
ALTER DATABASE [VHSLatest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VHSLatest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VHSLatest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VHSLatest] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [VHSLatest]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Amenities]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Amenities](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](512) NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BathRooms]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BathRooms](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](512) NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contact]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contact](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](1024) NULL,
	[EmailId] [varchar](50) NULL,
	[Comment] [varchar](max) NULL,
	[CreatedOn] [date] NULL,
	[IsActvie] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Documents]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documents](
	[DocId] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](max) NULL,
	[LoginId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Documents] PRIMARY KEY CLUSTERED 
(
	[DocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EntertainmentElectronics]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntertainmentElectronics](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](512) NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[General]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[General](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](512) NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Image]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Image](
	[ImageId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](1024) NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Kitchen]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kitchen](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](512) NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MailLink]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MailLink](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](512) NULL,
	[ExpiryDate] [date] NULL,
	[Email] [varchar](512) NULL,
	[Token] [varchar](100) NULL,
	[LinkUsed] [bit] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OutdoorFacilities]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OutdoorFacilities](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](512) NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Parking]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parking](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](512) NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Property]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Property](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ListedId] [int] NOT NULL,
	[NumberOfGuest] [int] NOT NULL,
	[NumberOfRooms] [int] NOT NULL,
	[NumberOfBathRoom] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[LoginId] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[PricePerNight] [float] NULL,
	[PricePerWeek] [float] NULL,
	[LocalOrder] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyAdditionalInfo]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PropertyAdditionalInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PropDescription] [nvarchar](max) NULL,
	[CheckInTime] [time](7) NULL,
	[CheckOutTime] [time](7) NULL,
	[PropertySize] [varchar](100) NULL,
	[PersonPerRoom] [int] NULL,
	[IsPetsAllowed] [bit] NULL,
	[IsDrinikingAllowed] [bit] NULL,
	[IsSmokingAllowed] [bit] NULL,
	[IsFamKidFriendAllowed] [bit] NULL,
	[IsWheelChairAccess] [bit] NULL,
	[MapLatitude] [nvarchar](100) NULL,
	[MapLongitude] [nvarchar](100) NULL,
	[PropertyId] [int] NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PropertyAddress]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PropertyAddress](
	[PropAddressId] [int] IDENTITY(1,1) NOT NULL,
	[Address] [varchar](max) NULL,
	[City] [varchar](512) NULL,
	[Country] [varchar](512) NULL,
	[ZipCode] [varchar](512) NULL,
	[CreatedDate] [date] NULL,
	[UpdatedDate] [date] NULL,
	[CreatedBy] [date] NULL,
	[UpdatedBy] [date] NULL,
	[IsActvie] [bit] NULL,
	[PropertyId] [int] NULL,
	[Email] [nvarchar](100) NULL,
	[ContactNo] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[PropAddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PropertyAmenitiesMap]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyAmenitiesMap](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NULL,
	[AmenitiesId] [int] NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyBathRoomsMap]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyBathRoomsMap](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NULL,
	[BathRoomId] [int] NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyCategory]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PropertyCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](512) NULL,
	[CreatedDate] [date] NULL,
	[UpdatedDate] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PropertyCoverPhotoMap]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyCoverPhotoMap](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NULL,
	[ImageId] [int] NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyEnterElecMap]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyEnterElecMap](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NULL,
	[EnterElecId] [int] NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyGallaryMap]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyGallaryMap](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NULL,
	[ImageId] [int] NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyGeneralMap]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyGeneralMap](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NULL,
	[GeneralId] [int] NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyImageMapping]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyImageMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NULL,
	[ImageId] [int] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
	[UpdatedOn] [date] NULL,
	[CreatedOn] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyKitchenMap]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyKitchenMap](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NULL,
	[KitchenId] [int] NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyListedBy]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PropertyListedBy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](512) NULL,
	[CreatedDate] [date] NULL,
	[UpdatedDate] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PropertyOutdoorMap]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyOutdoorMap](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NULL,
	[OutFaciId] [int] NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyParkingMap]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyParkingMap](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NULL,
	[ParkingId] [int] NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyPrice]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyPrice](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[Price] [float] NULL,
	[PropertyId] [int] NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyRMMapping]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyRMMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoginId] [int] NULL,
	[PropertyId] [int] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertySleepingMap]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertySleepingMap](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NULL,
	[SleepArrengId] [int] NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyTravelAmbassadorMap]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyTravelAmbassadorMap](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NULL,
	[TraAmbassId] [int] NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PropertyTravelBeatsMap]    Script Date: 3/28/2016 11:23:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyTravelBeatsMap](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NULL,
	[TraBeatsId] [int] NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SleepingArrangement]    Script Date: 3/28/2016 11:23:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SleepingArrangement](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](512) NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TravelPreferences]    Script Date: 3/28/2016 11:23:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TravelPreferences](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](512) NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 3/28/2016 11:23:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogin](
	[LoginId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[IsEmailVerified] [bit] NOT NULL,
	[TypeId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.UserLogin] PRIMARY KEY CLUSTERED 
(
	[LoginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 3/28/2016 11:23:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserProfile](
	[LoginId] [int] NOT NULL,
	[Address] [nvarchar](max) NULL,
	[Telephone] [nvarchar](max) NULL,
	[Mobile] [nvarchar](max) NULL,
	[BirthDay] [datetime] NULL,
	[Anniversary] [datetime] NULL,
	[TravelPreferences] [nvarchar](max) NULL,
	[WorkTelephone] [nvarchar](max) NULL,
	[HomeTelephone] [nvarchar](max) NULL,
	[PrefMethodContact] [nvarchar](max) NULL,
	[PrefCallTime] [nvarchar](max) NULL,
	[IsVerified] [bit] NOT NULL,
	[City] [varchar](100) NULL,
	[ZipCode] [varchar](100) NULL,
 CONSTRAINT [PK_dbo.UserProfile] PRIMARY KEY CLUSTERED 
(
	[LoginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserTravelPrefMapping]    Script Date: 3/28/2016 11:23:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTravelPrefMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoginId] [int] NULL,
	[TravelPefid] [int] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserType]    Script Date: 3/28/2016 11:23:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[TypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.UserType] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201603071645544_InitialCreate', N'VHS.Data.VHSDbContext', 0x1F8B0800000000000400ED5C5B6FE336167E2FB0FF41D0D3B6C8C449E66537B05B649C496B743209E2CCB4E8CB80966887A844A924958DB1E82FEBC3FEA4FD0B2575E545174AB29D4C3BC84BC2CBC7C3730ECFE1E553FEFFC7FFA6DF3D8581F3080945119EB9A7C727AE03B117F9086F666EC2D6AFFEE57EF7ED3FBE9ABEF5C327E763D1EEB568C77B623A731F188BCF2713EA3DC010D0E3107924A2D19A1D7B5138017E34393B39F9F7E4F474023984CBB11C677A9760864298FEC1FF9C47D883314B40701DF930A07939AF59A6A8CE7B10421A030FCEDC8F3F2C8F2F0103AE731120C0C75FC260ED3A00E38801C6A53BFF40E19291086F96312F00C1FD3686BCDD1A0414E6529F57CD6D277072262630A93A16505E425914F6043C7D9D6B64A2771FA457B7D418D7D95BAE5BB615B34EF536732F232F092166AEA30F763E0F886898A9751E11785C343E728AA2A3D2EEDC3DC4CF91334F02961038C33061040447CE6DB20A90F723DCDE47BF423CC34910C83271A9789D52C08B6E491443C2B677705D49BAF05D67A2769DE87DCB9E6AB76C260BCC5E9FB9CE7B2E025805B034BC34EB25E3D3FA1E62480083FE2D600C126EB7850F53D5190268C35DA1008ADF8A11B9B7F1E5E23AD7E0E91DC41BF63073F9AFAE73859EA05F94E4527CC088AF2EDE899104760DF42EDA20DC3D330DE43D78449B74A21A1C5F182485749D3B18A42DE8038AB325541AFE93D4EC8A44E15D14483E54D57E5A4609F18412A2C626F7806C2053259C4E2A076D755B490E0BBF2D5B3F8BE39696EAEBBA9626DE9DF31EC4716F01A5FF8988BFF781DE8600057B1F6541D371B837A13582E5ACDE44DCEF01EE5E911A9CE8DD7B556B18730285F9DF6CC7C17C88FD5DC0E4D2DCE002866768788F84A70D136807480B7AE131F4087B5BAB317E56797417E1B3888D2DE1B388B07D023C2F5AF3FC542B6385ACB4ACC4AC6D6004FAFA5675B1BE4B5861190B49B3664D628ADA0E19D326A39351A930CB7494B7FF4B26A4F6B577E1FB0452BAF7C07C0F03183F4478FF19ED3A5AA5A6DFF3306F10610F97606B46BF0E85638CC4290E90DE5DEF097884C12D816B48F8D10F1EC06A5CAA5F24A3D94AFA53447E3D9CC57F884278B8D184FEAF217B887C7E1866C0630719710E8220D3FCDE775083374F038F3303739D9E95DB33E2E054926534CB3C228A9E2589141BD5BE39C46E83FB999D692E21F5088AB33B9A3D8FF565777FF8DD7D9F7062B1216D0F24CA9ED5268A5C501A7928954A97570970EA64DF62DFB1DAD967EEAC4C94BB350F2B28E68184CB33734F0D5576A1972A50D1CB58DC857F976D49C41D2E4F8A948736849919B510F6500C029B896A9DFBEC9C8569CAB1F49A4B18432C82958D3E460A518EA505E52E6D4D27920FF571ADD4D9ED2CAF1EC52C9CEA1B6BA75217950A9D2D47DD9D74CDDDE04BBE9D63D0119143DCD3CF01F5806F8608BE04FD9D7BA22CBF8D07D4E7DE115E28DB669C0007F0C09ADB94263769BB99AEDCA4BABBB177C0B64B1BAB80F9DC1ED83C814305C266E3BCB42898A5DDF4F085F83E3497806FBA2F57A2103ED53D9FF159E55B769A6FEC745F12A04BC834B7E667EC2ACD1B1E6A38A40A52AAB20E45F2460B983C3335019599DA022A5542034E169F3510C90E3573534F6D52DBD6E39DEE26B6FB9F7242AA760DB7B3DDF16878959AF575AE2AA1B78232C57669C74CE0B6297CAC5E94A4AD81E50E335A237517EFA646BA128A6D4A9126212DE61685B424112BEDB668A4382B9441ABE24D4C32E24441B09834302CA6D7208EF91156625CE425CE32A35BCC5F2DFB3312C20C63E2D11A6242296D39123FFC830DD46AF9D05CD22B442813748F151067B9B91F1ACD9410DD10A78AA1F4286C9AAD885E450FF17B990A52E24915A8CD1496F7BAE2F3112DD2A9C11A9731BBA65C171000524F6D98474112E21692441B46C5579061AA527BA43221CB408D595A389EA611238F1B1A373642AA09AD0C2CADA641166E8C1116266EE9BB2BAD36E19836EE6BDFEADD5E46A94AED91F2877919262FB2C7309EDD6534A3D21EB738D9C8704DA79D6614E98E4E06928AEDB1A48B3A194B2AEE2D97B863AB91EBC6D8185AC8A56349C57DAC59DCD8A9662C4A5F54F428776C83E347C396D4328234F6DE770C295F6E659CB2B0C71AAB5ECE94655615DB63156FAF325051668F523DADCA3855690F1DC98FAD8A9EE48A1EBA325F60159D99D53DB0CBB75605B22CB547D25E5F6538ADCA1E537B639531B5AA1E39CC7C4955929959DD0FBB7A33D561AB9A3E51B129BDB565B6678C8CD9B16D7058AC3B8B5AC6C4FAAEFB4DF2E3B754CAB3A1B28D972BBE6C3BFE26DB0EE3CCAE3729472FCFEEDA197D9A9F97BB3F95300ED05913D7E12A7A44BE383C2FB794C1305B9ECBDF827980D21BC8A2C135C0680D29CB6804EED9C9E999F6DDC5CBF9066242A91FD4DC37D47D08A1DAEB609F2620A1DB4EAE43CF9770FD6B04FC0888F700C83F43F0F4B58C36E08B0354FBD1C802FBF069E6FE37ED73EE2C7EFE94773B726E08F79A73E7C4F9BD631E03BE021860B45DB120F762B89D194D67DB8F025318F5A3901A58F32BC44632E66DBD32EBD5C329CD810D224E3AF6581ACE101083842330D94E4838839174124EB76907F1AD9F7BE1EF25009A436BA4E9516BCF20AE8E4253C9CFA3A07482739DEFD9E0D4109E87423512A0C7594023390F95AE96F43C4AB25A62F3B804D4445E1E8DAA13944726A4FEB9A83FAB7740B4DA0DCFF6656F526AE8B3A3F0BE64E6C364E69D114F77C3322D292176A4D293E3E35DF34A0F4A226D7E45F8CC39A31973E5D03CCEC16E69D204073B51C30DE87E19A07F29C667EF90B2170FAAF87A8368A69F49106A21BBBC44BEA6C9196A78D8D06F04DBF898D9B529CFC6AB881B3BCBA08DE4AF66BA663B5BB36E904164CE2E2E67D3407DC99EAD5CCFA6415E1213B49E80D7C96ED4D46C3CD9BF588EA76C34F551CD8AD069A7AE9741E01C63633D24A8C4BDBDB033CD171D1E18A57F91C5A332459B0A42FCC32C0C3D2524966D16781D15A15993A868A25FEF4006F849035C1086D6FCF4CEAB3D4869FA69E347102450DC0AAFA0BFC037098B13C6A70CC355A03C0F8A08DF367E4A4155659EDEA4A741BA8B29703191382CDDE037090AFC52EEAB9A834E0384481DF9C159D8928903F4665B22BD3768084D40B9FACA8C770FC338E060F4062F813892F5978D7BEE3BB801DEB678986B06E93684AAF6E925021B02429A6354FDF99FDC87FDF0E9DB3F014F9DC0D9294E0000, N'6.1.3-40302')
GO
SET IDENTITY_INSERT [dbo].[Amenities] ON 

GO
INSERT [dbo].[Amenities] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (1, N'On Premises', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Amenities] OFF
GO
SET IDENTITY_INSERT [dbo].[BathRooms] ON 

GO
INSERT [dbo].[BathRooms] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (1, N'Hot Tub', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[BathRooms] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (2, N'Water Supply', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[BathRooms] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (3, N'Hot Water Supply', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[BathRooms] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (4, N'Bathtub', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[BathRooms] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (5, N'Hair Dryer', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[BathRooms] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (6, N'Shower', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[BathRooms] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (7, N'Towels', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[BathRooms] OFF
GO
SET IDENTITY_INSERT [dbo].[EntertainmentElectronics] ON 

GO
INSERT [dbo].[EntertainmentElectronics] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (1, N'Internet', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[EntertainmentElectronics] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (2, N'WiFi', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[EntertainmentElectronics] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (3, N'TV', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[EntertainmentElectronics] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (4, N'Music System', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[EntertainmentElectronics] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (5, N'Scanner/Printer', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[EntertainmentElectronics] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (6, N'Phone(Booth/Lines)', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[EntertainmentElectronics] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (7, N'Projector', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[EntertainmentElectronics] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (8, N'Fax', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[EntertainmentElectronics] OFF
GO
SET IDENTITY_INSERT [dbo].[General] ON 

GO
INSERT [dbo].[General] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (1, N'Elevator In Building', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[General] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (2, N'Indoor Fireplace', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[General] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (3, N'AC', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[General] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (4, N'Heating', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[General] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (5, N'Furniture', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[General] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (6, N'Dryer', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[General] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (7, N'Washing Machine', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[General] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (8, N'Security', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[General] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (9, N'Butler', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[General] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (10, N'Cook', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[General] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (11, N'Doorman', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[General] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (12, N'House Help', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[General] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (13, N'First Aid Kit', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[General] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (14, N'Dental Kit', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[General] OFF
GO
SET IDENTITY_INSERT [dbo].[Image] ON 

GO
INSERT [dbo].[Image] ([ImageId], [Name], [CreatedBy], [UpdatedBy], [IsActive], [CreatedOn], [UpdatedOn]) VALUES (17, N'33.jpg', 0, 0, 1, CAST(0x2A3B0B00 AS Date), CAST(0x2A3B0B00 AS Date))
GO
INSERT [dbo].[Image] ([ImageId], [Name], [CreatedBy], [UpdatedBy], [IsActive], [CreatedOn], [UpdatedOn]) VALUES (18, N'2_20160320185330.jpg', 0, 0, 1, CAST(0x2A3B0B00 AS Date), CAST(0x2A3B0B00 AS Date))
GO
INSERT [dbo].[Image] ([ImageId], [Name], [CreatedBy], [UpdatedBy], [IsActive], [CreatedOn], [UpdatedOn]) VALUES (19, N'33_20160328091507.jpg', NULL, NULL, 1, CAST(0x323B0B00 AS Date), CAST(0x323B0B00 AS Date))
GO
INSERT [dbo].[Image] ([ImageId], [Name], [CreatedBy], [UpdatedBy], [IsActive], [CreatedOn], [UpdatedOn]) VALUES (20, N'33_20160328092141.jpg', NULL, NULL, 1, CAST(0x323B0B00 AS Date), CAST(0x323B0B00 AS Date))
GO
SET IDENTITY_INSERT [dbo].[Image] OFF
GO
SET IDENTITY_INSERT [dbo].[Kitchen] ON 

GO
INSERT [dbo].[Kitchen] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (1, N'Gas', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[Kitchen] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (2, N'Crockery And Cutlery', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[Kitchen] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (3, N'Coffee Maker', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[Kitchen] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (4, N'Dish Washer', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[Kitchen] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (5, N'Fridge', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Kitchen] OFF
GO
SET IDENTITY_INSERT [dbo].[MailLink] ON 

GO
INSERT [dbo].[MailLink] ([Id], [Name], [ExpiryDate], [Email], [Token], [LinkUsed], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn], [IsActive]) VALUES (1, N'RM Password creation', CAST(0x2D3B0B00 AS Date), N'dharam3579@gmail.com', NULL, 0, 0, 0, CAST(0x2D3B0B00 AS Date), CAST(0x2D3B0B00 AS Date), 1)
GO
INSERT [dbo].[MailLink] ([Id], [Name], [ExpiryDate], [Email], [Token], [LinkUsed], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn], [IsActive]) VALUES (2, N'RM Password creation', CAST(0x2D3B0B00 AS Date), N'dharam3579@gmail.com', NULL, 1, 0, 0, CAST(0x2D3B0B00 AS Date), CAST(0x2D3B0B00 AS Date), 1)
GO
SET IDENTITY_INSERT [dbo].[MailLink] OFF
GO
SET IDENTITY_INSERT [dbo].[OutdoorFacilities] ON 

GO
INSERT [dbo].[OutdoorFacilities] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (1, N'Bar/Restaurant', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[OutdoorFacilities] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (2, N'Gym', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[OutdoorFacilities] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (3, N'Swimming Pool', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[OutdoorFacilities] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (4, N'Barbeque', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[OutdoorFacilities] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (5, N'Balcony', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[OutdoorFacilities] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (6, N'Garden', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[OutdoorFacilities] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (7, N'Terrace', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[OutdoorFacilities] OFF
GO
SET IDENTITY_INSERT [dbo].[Parking] ON 

GO
INSERT [dbo].[Parking] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (1, N'On Premises', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[Parking] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (2, N'Open Parking', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[Parking] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (3, N'Paid Parking', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[Parking] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (4, N'Covered Parking', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[Parking] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (5, N'Valet', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Parking] OFF
GO
SET IDENTITY_INSERT [dbo].[Property] ON 

GO
INSERT [dbo].[Property] ([Id], [Title], [CategoryId], [ListedId], [NumberOfGuest], [NumberOfRooms], [NumberOfBathRoom], [Price], [IsApproved], [CreatedBy], [UpdatedBy], [LoginId], [IsActive], [CreatedOn], [UpdatedOn], [PricePerNight], [PricePerWeek], [LocalOrder]) VALUES (14, N'Park Villa Hot ', 5, 1, 12, 1, 2, 20, 0, 0, 0, 24, 1, CAST(0x2A3B0B00 AS Date), CAST(0x2A3B0B00 AS Date), 50, 100, 1)
GO
INSERT [dbo].[Property] ([Id], [Title], [CategoryId], [ListedId], [NumberOfGuest], [NumberOfRooms], [NumberOfBathRoom], [Price], [IsApproved], [CreatedBy], [UpdatedBy], [LoginId], [IsActive], [CreatedOn], [UpdatedOn], [PricePerNight], [PricePerWeek], [LocalOrder]) VALUES (15, N'Sanity ', 2, 1, 12, 21, 2, 3400, 0, 0, 0, 23, 1, CAST(0x2A3B0B00 AS Date), CAST(0x2A3B0B00 AS Date), 10, 20, 2)
GO
SET IDENTITY_INSERT [dbo].[Property] OFF
GO
SET IDENTITY_INSERT [dbo].[PropertyAddress] ON 

GO
INSERT [dbo].[PropertyAddress] ([PropAddressId], [Address], [City], [Country], [ZipCode], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy], [IsActvie], [PropertyId], [Email], [ContactNo]) VALUES (9, N'Borivali', N'Mumbai', N'India', N'400065', CAST(0x2A3B0B00 AS Date), CAST(0x2A3B0B00 AS Date), CAST(0x2A3B0B00 AS Date), CAST(0x2A3B0B00 AS Date), 1, 14, N'dharam@gmail.com', N'9594460613')
GO
INSERT [dbo].[PropertyAddress] ([PropAddressId], [Address], [City], [Country], [ZipCode], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy], [IsActvie], [PropertyId], [Email], [ContactNo]) VALUES (10, N'Badalapur', N'Allahabad', N'South Africa', N'430089', CAST(0x2A3B0B00 AS Date), CAST(0x2A3B0B00 AS Date), CAST(0x2A3B0B00 AS Date), CAST(0x2A3B0B00 AS Date), 1, 15, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[PropertyAddress] OFF
GO
SET IDENTITY_INSERT [dbo].[PropertyCategory] ON 

GO
INSERT [dbo].[PropertyCategory] ([Id], [CategoryName], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (1, N'Apartment', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[PropertyCategory] ([Id], [CategoryName], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (2, N'Beach House', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[PropertyCategory] ([Id], [CategoryName], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (3, N'Boat House', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[PropertyCategory] ([Id], [CategoryName], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (4, N'Farmhouse', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[PropertyCategory] ([Id], [CategoryName], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (5, N'Private Room', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[PropertyCategory] ([Id], [CategoryName], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (6, N'Villa', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[PropertyCategory] ([Id], [CategoryName], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (7, N'Other', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[PropertyCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[PropertyImageMapping] ON 

GO
INSERT [dbo].[PropertyImageMapping] ([Id], [PropertyId], [ImageId], [CreatedBy], [UpdatedBy], [IsActive], [UpdatedOn], [CreatedOn]) VALUES (16, 14, 20, 0, 0, 1, CAST(0x2A3B0B00 AS Date), CAST(0x2A3B0B00 AS Date))
GO
INSERT [dbo].[PropertyImageMapping] ([Id], [PropertyId], [ImageId], [CreatedBy], [UpdatedBy], [IsActive], [UpdatedOn], [CreatedOn]) VALUES (17, 15, 18, 0, 0, 1, CAST(0x2A3B0B00 AS Date), CAST(0x2A3B0B00 AS Date))
GO
SET IDENTITY_INSERT [dbo].[PropertyImageMapping] OFF
GO
SET IDENTITY_INSERT [dbo].[PropertyListedBy] ON 

GO
INSERT [dbo].[PropertyListedBy] ([Id], [Name], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (1, N'Owner', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[PropertyListedBy] ([Id], [Name], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (2, N'Representative', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[PropertyListedBy] OFF
GO
SET IDENTITY_INSERT [dbo].[PropertyRMMapping] ON 

GO
INSERT [dbo].[PropertyRMMapping] ([Id], [LoginId], [PropertyId], [CreatedBy], [UpdatedBy], [IsActive], [CreatedOn], [UpdatedOn]) VALUES (3, 34, 14, 1, 1, 1, NULL, NULL)
GO
INSERT [dbo].[PropertyRMMapping] ([Id], [LoginId], [PropertyId], [CreatedBy], [UpdatedBy], [IsActive], [CreatedOn], [UpdatedOn]) VALUES (7, 28, 15, 1, 1, 1, CAST(0x2F3B0B00 AS Date), CAST(0x2F3B0B00 AS Date))
GO
SET IDENTITY_INSERT [dbo].[PropertyRMMapping] OFF
GO
SET IDENTITY_INSERT [dbo].[SleepingArrangement] ON 

GO
INSERT [dbo].[SleepingArrangement] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (1, N'Beds & Mattresses', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[SleepingArrangement] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (2, N'Cupboard', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
INSERT [dbo].[SleepingArrangement] ([id], [Name], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsActive]) VALUES (3, N'Personal Safe', CAST(0x6E390B00 AS Date), CAST(0x6E390B00 AS Date), 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[SleepingArrangement] OFF
GO
SET IDENTITY_INSERT [dbo].[TravelPreferences] ON 

GO
INSERT [dbo].[TravelPreferences] ([Id], [Name], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (1, N'Business', 1, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[TravelPreferences] ([Id], [Name], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (2, N'Business cum Leisure', 1, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[TravelPreferences] ([Id], [Name], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (3, N'Honeymoon', 1, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[TravelPreferences] ([Id], [Name], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (4, N'Birthday Celebration', 1, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[TravelPreferences] ([Id], [Name], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (5, N'Road trip', 1, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[TravelPreferences] ([Id], [Name], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (6, N'Wedding', 1, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[TravelPreferences] ([Id], [Name], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (7, N'Budget', 1, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[TravelPreferences] ([Id], [Name], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (8, N'Hiking', 1, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[TravelPreferences] ([Id], [Name], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (9, N'Corporate Retreat', 1, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[TravelPreferences] ([Id], [Name], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (10, N'Luxury', 1, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[TravelPreferences] ([Id], [Name], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (11, N'Leisure', 1, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[TravelPreferences] ([Id], [Name], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (12, N'Family Holiday', 1, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[TravelPreferences] ([Id], [Name], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (13, N'Anniversary', 1, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[TravelPreferences] ([Id], [Name], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (14, N'Adventure', 1, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[TravelPreferences] ([Id], [Name], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (15, N'Educational trip', 1, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[TravelPreferences] ([Id], [Name], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (16, N'Backpacking', 1, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[TravelPreferences] ([Id], [Name], [IsActive], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (17, N'Luxury Train', 1, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[TravelPreferences] OFF
GO
SET IDENTITY_INSERT [dbo].[UserLogin] ON 

GO
INSERT [dbo].[UserLogin] ([LoginId], [Name], [Password], [Email], [IsEmailVerified], [TypeId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn], [IsActive]) VALUES (23, N'Admin', N'123456', N'admin@gmail.com', 1, 1, 0, 0, CAST(0x0000A41300000000 AS DateTime), CAST(0x0000A41300000000 AS DateTime), 1)
GO
INSERT [dbo].[UserLogin] ([LoginId], [Name], [Password], [Email], [IsEmailVerified], [TypeId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn], [IsActive]) VALUES (24, N'Dharmendra Yadav', N'123456', N'd@gmail.com', 0, 3, 0, 0, CAST(0x0000A5CF01028943 AS DateTime), CAST(0x0000A5CF01028943 AS DateTime), 1)
GO
INSERT [dbo].[UserLogin] ([LoginId], [Name], [Password], [Email], [IsEmailVerified], [TypeId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn], [IsActive]) VALUES (25, N'Ajeet Yadav', N'123456', N'ajeet@gmail.com', 0, 3, 0, 0, CAST(0x0000A5CF01098143 AS DateTime), CAST(0x0000A5CF01098143 AS DateTime), 1)
GO
INSERT [dbo].[UserLogin] ([LoginId], [Name], [Password], [Email], [IsEmailVerified], [TypeId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn], [IsActive]) VALUES (26, N'Suneel Yadav', NULL, N'suneel@gmail.com', 0, 3, 0, 0, CAST(0x0000A5CF0109910E AS DateTime), CAST(0x0000A5CF0109910E AS DateTime), 1)
GO
INSERT [dbo].[UserLogin] ([LoginId], [Name], [Password], [Email], [IsEmailVerified], [TypeId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn], [IsActive]) VALUES (28, N'Gaurav', NULL, N'dharam3570@gmail.com', 0, 2, 0, 0, CAST(0x0000A5D2010ADA37 AS DateTime), CAST(0x0000A5D2010ADA37 AS DateTime), 1)
GO
INSERT [dbo].[UserLogin] ([LoginId], [Name], [Password], [Email], [IsEmailVerified], [TypeId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn], [IsActive]) VALUES (29, N'Dev', NULL, N'dharam379@gmail.com', 0, 3, 0, 0, CAST(0x0000A5D2010B5663 AS DateTime), CAST(0x0000A5D2010B5663 AS DateTime), 1)
GO
INSERT [dbo].[UserLogin] ([LoginId], [Name], [Password], [Email], [IsEmailVerified], [TypeId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn], [IsActive]) VALUES (30, N'Dev', NULL, N'dharam39@gmail.com', 0, 3, 0, 0, CAST(0x0000A5D2010BE9E7 AS DateTime), CAST(0x0000A5D2010BE9E7 AS DateTime), 1)
GO
INSERT [dbo].[UserLogin] ([LoginId], [Name], [Password], [Email], [IsEmailVerified], [TypeId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn], [IsActive]) VALUES (31, N'Dev', NULL, N'dharam359@gmail.com', 0, 3, 0, 0, CAST(0x0000A5D2010C868A AS DateTime), CAST(0x0000A5D2010C868A AS DateTime), 1)
GO
INSERT [dbo].[UserLogin] ([LoginId], [Name], [Password], [Email], [IsEmailVerified], [TypeId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn], [IsActive]) VALUES (32, N'raj', NULL, N'dharam356579@gmail.com', 0, 3, 0, 0, CAST(0x0000A5D2010DCA53 AS DateTime), CAST(0x0000A5D2010DCA53 AS DateTime), 1)
GO
INSERT [dbo].[UserLogin] ([LoginId], [Name], [Password], [Email], [IsEmailVerified], [TypeId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn], [IsActive]) VALUES (33, N'Devwe', NULL, N'dharam379@gmail.com', 0, 3, 0, 0, CAST(0x0000A5D20124F23A AS DateTime), CAST(0x0000A5D20124F23A AS DateTime), 1)
GO
INSERT [dbo].[UserLogin] ([LoginId], [Name], [Password], [Email], [IsEmailVerified], [TypeId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn], [IsActive]) VALUES (34, N'Raj dev', N'123456', N'dharam3579@gmail.com', 1, 2, 0, 0, CAST(0x0000A5D2012FE781 AS DateTime), CAST(0x0000A5D2012FE781 AS DateTime), 1)
GO
INSERT [dbo].[UserLogin] ([LoginId], [Name], [Password], [Email], [IsEmailVerified], [TypeId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn], [IsActive]) VALUES (35, N'', N'123456', N'v@gmail.com', 0, 3, 0, 0, CAST(0x0000A5D6016513B0 AS DateTime), CAST(0x0000A5D6016513B0 AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[UserLogin] OFF
GO
INSERT [dbo].[UserProfile] ([LoginId], [Address], [Telephone], [Mobile], [BirthDay], [Anniversary], [TravelPreferences], [WorkTelephone], [HomeTelephone], [PrefMethodContact], [PrefCallTime], [IsVerified], [City], [ZipCode]) VALUES (24, N'Aarey Milk Colony', N'022229276580', N'9594460614', NULL, CAST(0x00007DEF00000000 AS DateTime), N'', N'02229276580', NULL, N'2', N'1', 0, N'Mumbai', N'400065')
GO
INSERT [dbo].[UserProfile] ([LoginId], [Address], [Telephone], [Mobile], [BirthDay], [Anniversary], [TravelPreferences], [WorkTelephone], [HomeTelephone], [PrefMethodContact], [PrefCallTime], [IsVerified], [City], [ZipCode]) VALUES (25, NULL, NULL, N'9587878879', NULL, NULL, N'', N'', N'', N'', N'', 0, NULL, NULL)
GO
INSERT [dbo].[UserProfile] ([LoginId], [Address], [Telephone], [Mobile], [BirthDay], [Anniversary], [TravelPreferences], [WorkTelephone], [HomeTelephone], [PrefMethodContact], [PrefCallTime], [IsVerified], [City], [ZipCode]) VALUES (26, NULL, NULL, N'8887878879', NULL, NULL, N'', N'', N'', N'', N'', 0, NULL, NULL)
GO
INSERT [dbo].[UserProfile] ([LoginId], [Address], [Telephone], [Mobile], [BirthDay], [Anniversary], [TravelPreferences], [WorkTelephone], [HomeTelephone], [PrefMethodContact], [PrefCallTime], [IsVerified], [City], [ZipCode]) VALUES (28, NULL, NULL, N'123456', NULL, NULL, N'', N'', N'', N'', N'', 0, NULL, NULL)
GO
INSERT [dbo].[UserProfile] ([LoginId], [Address], [Telephone], [Mobile], [BirthDay], [Anniversary], [TravelPreferences], [WorkTelephone], [HomeTelephone], [PrefMethodContact], [PrefCallTime], [IsVerified], [City], [ZipCode]) VALUES (29, NULL, NULL, N'8787878787', NULL, NULL, N'', N'', N'', N'', N'', 0, NULL, NULL)
GO
INSERT [dbo].[UserProfile] ([LoginId], [Address], [Telephone], [Mobile], [BirthDay], [Anniversary], [TravelPreferences], [WorkTelephone], [HomeTelephone], [PrefMethodContact], [PrefCallTime], [IsVerified], [City], [ZipCode]) VALUES (30, NULL, NULL, N'767676767', NULL, NULL, N'', N'', N'', N'', N'', 0, NULL, NULL)
GO
INSERT [dbo].[UserProfile] ([LoginId], [Address], [Telephone], [Mobile], [BirthDay], [Anniversary], [TravelPreferences], [WorkTelephone], [HomeTelephone], [PrefMethodContact], [PrefCallTime], [IsVerified], [City], [ZipCode]) VALUES (31, NULL, NULL, N'767676767', NULL, NULL, N'', N'', N'', N'', N'', 0, NULL, NULL)
GO
INSERT [dbo].[UserProfile] ([LoginId], [Address], [Telephone], [Mobile], [BirthDay], [Anniversary], [TravelPreferences], [WorkTelephone], [HomeTelephone], [PrefMethodContact], [PrefCallTime], [IsVerified], [City], [ZipCode]) VALUES (32, NULL, NULL, N'9898989898', NULL, NULL, N'', N'', N'', N'', N'', 0, NULL, NULL)
GO
INSERT [dbo].[UserProfile] ([LoginId], [Address], [Telephone], [Mobile], [BirthDay], [Anniversary], [TravelPreferences], [WorkTelephone], [HomeTelephone], [PrefMethodContact], [PrefCallTime], [IsVerified], [City], [ZipCode]) VALUES (33, NULL, NULL, N'9898989898', NULL, NULL, N'', N'', N'', N'', N'', 0, NULL, NULL)
GO
INSERT [dbo].[UserProfile] ([LoginId], [Address], [Telephone], [Mobile], [BirthDay], [Anniversary], [TravelPreferences], [WorkTelephone], [HomeTelephone], [PrefMethodContact], [PrefCallTime], [IsVerified], [City], [ZipCode]) VALUES (34, NULL, NULL, N'123456', NULL, NULL, N'', N'', N'', N'', N'', 0, NULL, NULL)
GO
INSERT [dbo].[UserProfile] ([LoginId], [Address], [Telephone], [Mobile], [BirthDay], [Anniversary], [TravelPreferences], [WorkTelephone], [HomeTelephone], [PrefMethodContact], [PrefCallTime], [IsVerified], [City], [ZipCode]) VALUES (35, NULL, NULL, N'', NULL, NULL, N'', N'', N'', N'', N'', 0, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[UserTravelPrefMapping] ON 

GO
INSERT [dbo].[UserTravelPrefMapping] ([Id], [LoginId], [TravelPefid], [CreatedBy], [UpdatedBy], [IsActive], [CreatedOn], [UpdatedOn]) VALUES (6, 24, 1, NULL, NULL, 1, CAST(0x2F3B0B00 AS Date), CAST(0x2F3B0B00 AS Date))
GO
INSERT [dbo].[UserTravelPrefMapping] ([Id], [LoginId], [TravelPefid], [CreatedBy], [UpdatedBy], [IsActive], [CreatedOn], [UpdatedOn]) VALUES (7, 24, 3, NULL, NULL, 1, CAST(0x2F3B0B00 AS Date), CAST(0x2F3B0B00 AS Date))
GO
INSERT [dbo].[UserTravelPrefMapping] ([Id], [LoginId], [TravelPefid], [CreatedBy], [UpdatedBy], [IsActive], [CreatedOn], [UpdatedOn]) VALUES (8, 24, 5, NULL, NULL, 1, CAST(0x2F3B0B00 AS Date), CAST(0x2F3B0B00 AS Date))
GO
INSERT [dbo].[UserTravelPrefMapping] ([Id], [LoginId], [TravelPefid], [CreatedBy], [UpdatedBy], [IsActive], [CreatedOn], [UpdatedOn]) VALUES (9, 24, 7, NULL, NULL, 1, CAST(0x2F3B0B00 AS Date), CAST(0x2F3B0B00 AS Date))
GO
INSERT [dbo].[UserTravelPrefMapping] ([Id], [LoginId], [TravelPefid], [CreatedBy], [UpdatedBy], [IsActive], [CreatedOn], [UpdatedOn]) VALUES (10, 24, 9, NULL, NULL, 1, CAST(0x2F3B0B00 AS Date), CAST(0x2F3B0B00 AS Date))
GO
INSERT [dbo].[UserTravelPrefMapping] ([Id], [LoginId], [TravelPefid], [CreatedBy], [UpdatedBy], [IsActive], [CreatedOn], [UpdatedOn]) VALUES (11, 24, 11, NULL, NULL, 1, CAST(0x2F3B0B00 AS Date), CAST(0x2F3B0B00 AS Date))
GO
SET IDENTITY_INSERT [dbo].[UserTravelPrefMapping] OFF
GO
SET IDENTITY_INSERT [dbo].[UserType] ON 

GO
INSERT [dbo].[UserType] ([TypeId], [Name], [Description], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn], [IsActive]) VALUES (1, N'Admin', N'Admin User', 1, 1, CAST(0x0001247B00000000 AS DateTime), CAST(0x0001247B00000000 AS DateTime), 1)
GO
INSERT [dbo].[UserType] ([TypeId], [Name], [Description], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn], [IsActive]) VALUES (2, N'RM', N'RM User', 1, 1, CAST(0x0001247B00000000 AS DateTime), CAST(0x0001247B00000000 AS DateTime), 1)
GO
INSERT [dbo].[UserType] ([TypeId], [Name], [Description], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn], [IsActive]) VALUES (3, N'User', N'Normal user', 1, 1, CAST(0x0001247B00000000 AS DateTime), CAST(0x0001247B00000000 AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[UserType] OFF
GO
/****** Object:  Index [IX_LoginId]    Script Date: 3/28/2016 11:23:22 AM ******/
CREATE NONCLUSTERED INDEX [IX_LoginId] ON [dbo].[Documents]
(
	[LoginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TypeId]    Script Date: 3/28/2016 11:23:22 AM ******/
CREATE NONCLUSTERED INDEX [IX_TypeId] ON [dbo].[UserLogin]
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LoginId]    Script Date: 3/28/2016 11:23:22 AM ******/
CREATE NONCLUSTERED INDEX [IX_LoginId] ON [dbo].[UserProfile]
(
	[LoginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Amenities] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Amenities] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[Amenities] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[BathRooms] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[BathRooms] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[BathRooms] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Contact] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Contact] ADD  DEFAULT ('true') FOR [IsActvie]
GO
ALTER TABLE [dbo].[EntertainmentElectronics] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[EntertainmentElectronics] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[EntertainmentElectronics] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[General] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[General] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[General] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Kitchen] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Kitchen] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[Kitchen] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[MailLink] ADD  DEFAULT (getdate()) FOR [ExpiryDate]
GO
ALTER TABLE [dbo].[MailLink] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[MailLink] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[OutdoorFacilities] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[OutdoorFacilities] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[OutdoorFacilities] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Parking] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Parking] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[Parking] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Property] ADD  DEFAULT ((0.0)) FOR [PricePerNight]
GO
ALTER TABLE [dbo].[Property] ADD  DEFAULT ((0.0)) FOR [PricePerWeek]
GO
ALTER TABLE [dbo].[PropertyAdditionalInfo] ADD  DEFAULT ((0)) FOR [IsPetsAllowed]
GO
ALTER TABLE [dbo].[PropertyAdditionalInfo] ADD  DEFAULT ((0)) FOR [IsDrinikingAllowed]
GO
ALTER TABLE [dbo].[PropertyAdditionalInfo] ADD  DEFAULT ((0)) FOR [IsSmokingAllowed]
GO
ALTER TABLE [dbo].[PropertyAdditionalInfo] ADD  DEFAULT ((0)) FOR [IsFamKidFriendAllowed]
GO
ALTER TABLE [dbo].[PropertyAdditionalInfo] ADD  DEFAULT ((0)) FOR [IsWheelChairAccess]
GO
ALTER TABLE [dbo].[PropertyAdditionalInfo] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[PropertyAdditionalInfo] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[PropertyAdditionalInfo] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[PropertyAddress] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[PropertyAddress] ADD  DEFAULT (getdate()) FOR [UpdatedDate]
GO
ALTER TABLE [dbo].[PropertyAddress] ADD  DEFAULT (getdate()) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[PropertyAddress] ADD  DEFAULT (getdate()) FOR [UpdatedBy]
GO
ALTER TABLE [dbo].[PropertyAddress] ADD  DEFAULT ('true') FOR [IsActvie]
GO
ALTER TABLE [dbo].[PropertyAmenitiesMap] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[PropertyAmenitiesMap] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[PropertyAmenitiesMap] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[PropertyBathRoomsMap] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[PropertyBathRoomsMap] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[PropertyBathRoomsMap] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[PropertyCoverPhotoMap] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[PropertyCoverPhotoMap] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[PropertyCoverPhotoMap] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[PropertyEnterElecMap] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[PropertyEnterElecMap] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[PropertyEnterElecMap] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[PropertyGallaryMap] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[PropertyGallaryMap] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[PropertyGallaryMap] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[PropertyGeneralMap] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[PropertyGeneralMap] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[PropertyGeneralMap] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[PropertyKitchenMap] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[PropertyKitchenMap] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[PropertyKitchenMap] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[PropertyOutdoorMap] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[PropertyOutdoorMap] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[PropertyOutdoorMap] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[PropertyParkingMap] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[PropertyParkingMap] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[PropertyParkingMap] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[PropertyPrice] ADD  DEFAULT (getdate()) FOR [StartDate]
GO
ALTER TABLE [dbo].[PropertyPrice] ADD  DEFAULT (getdate()) FOR [EndDate]
GO
ALTER TABLE [dbo].[PropertyPrice] ADD  DEFAULT ((0.0)) FOR [Price]
GO
ALTER TABLE [dbo].[PropertyPrice] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[PropertyPrice] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[PropertyPrice] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[PropertyRMMapping] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[PropertyRMMapping] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[PropertySleepingMap] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[PropertySleepingMap] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[PropertySleepingMap] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[PropertyTravelAmbassadorMap] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[PropertyTravelAmbassadorMap] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[PropertyTravelAmbassadorMap] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[PropertyTravelBeatsMap] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[PropertyTravelBeatsMap] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[PropertyTravelBeatsMap] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[SleepingArrangement] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[SleepingArrangement] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[SleepingArrangement] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[TravelPreferences] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[TravelPreferences] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[TravelPreferences] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[UserTravelPrefMapping] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[UserTravelPrefMapping] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[Documents]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Documents_dbo.UserLogin_LoginId] FOREIGN KEY([LoginId])
REFERENCES [dbo].[UserLogin] ([LoginId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Documents] CHECK CONSTRAINT [FK_dbo.Documents_dbo.UserLogin_LoginId]
GO
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[PropertyCategory] ([Id])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [CategoryId]
GO
ALTER TABLE [dbo].[Property]  WITH CHECK ADD FOREIGN KEY([LoginId])
REFERENCES [dbo].[UserLogin] ([LoginId])
GO
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [ListedId] FOREIGN KEY([ListedId])
REFERENCES [dbo].[PropertyListedBy] ([Id])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [ListedId]
GO
ALTER TABLE [dbo].[PropertyAdditionalInfo]  WITH CHECK ADD FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[PropertyAddress]  WITH CHECK ADD FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[PropertyAmenitiesMap]  WITH CHECK ADD FOREIGN KEY([AmenitiesId])
REFERENCES [dbo].[Amenities] ([id])
GO
ALTER TABLE [dbo].[PropertyAmenitiesMap]  WITH CHECK ADD FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[PropertyBathRoomsMap]  WITH CHECK ADD FOREIGN KEY([BathRoomId])
REFERENCES [dbo].[BathRooms] ([id])
GO
ALTER TABLE [dbo].[PropertyBathRoomsMap]  WITH CHECK ADD FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[PropertyCoverPhotoMap]  WITH CHECK ADD FOREIGN KEY([ImageId])
REFERENCES [dbo].[Image] ([ImageId])
GO
ALTER TABLE [dbo].[PropertyCoverPhotoMap]  WITH CHECK ADD FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[PropertyEnterElecMap]  WITH CHECK ADD FOREIGN KEY([EnterElecId])
REFERENCES [dbo].[EntertainmentElectronics] ([id])
GO
ALTER TABLE [dbo].[PropertyEnterElecMap]  WITH CHECK ADD FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[PropertyGallaryMap]  WITH CHECK ADD FOREIGN KEY([ImageId])
REFERENCES [dbo].[Image] ([ImageId])
GO
ALTER TABLE [dbo].[PropertyGallaryMap]  WITH CHECK ADD FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[PropertyGeneralMap]  WITH CHECK ADD FOREIGN KEY([GeneralId])
REFERENCES [dbo].[General] ([id])
GO
ALTER TABLE [dbo].[PropertyGeneralMap]  WITH CHECK ADD FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[PropertyImageMapping]  WITH CHECK ADD FOREIGN KEY([ImageId])
REFERENCES [dbo].[Image] ([ImageId])
GO
ALTER TABLE [dbo].[PropertyImageMapping]  WITH CHECK ADD FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[PropertyKitchenMap]  WITH CHECK ADD FOREIGN KEY([KitchenId])
REFERENCES [dbo].[Kitchen] ([id])
GO
ALTER TABLE [dbo].[PropertyKitchenMap]  WITH CHECK ADD FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[PropertyOutdoorMap]  WITH CHECK ADD FOREIGN KEY([OutFaciId])
REFERENCES [dbo].[OutdoorFacilities] ([id])
GO
ALTER TABLE [dbo].[PropertyOutdoorMap]  WITH CHECK ADD FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[PropertyParkingMap]  WITH CHECK ADD FOREIGN KEY([ParkingId])
REFERENCES [dbo].[Parking] ([id])
GO
ALTER TABLE [dbo].[PropertyParkingMap]  WITH CHECK ADD FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[PropertyPrice]  WITH CHECK ADD FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[PropertyRMMapping]  WITH CHECK ADD FOREIGN KEY([LoginId])
REFERENCES [dbo].[UserLogin] ([LoginId])
GO
ALTER TABLE [dbo].[PropertyRMMapping]  WITH CHECK ADD FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[PropertySleepingMap]  WITH CHECK ADD FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[PropertySleepingMap]  WITH CHECK ADD FOREIGN KEY([SleepArrengId])
REFERENCES [dbo].[SleepingArrangement] ([id])
GO
ALTER TABLE [dbo].[PropertyTravelAmbassadorMap]  WITH CHECK ADD FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[PropertyTravelAmbassadorMap]  WITH CHECK ADD FOREIGN KEY([TraAmbassId])
REFERENCES [dbo].[UserLogin] ([LoginId])
GO
ALTER TABLE [dbo].[PropertyTravelBeatsMap]  WITH CHECK ADD FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[PropertyTravelBeatsMap]  WITH CHECK ADD FOREIGN KEY([TraBeatsId])
REFERENCES [dbo].[UserLogin] ([LoginId])
GO
ALTER TABLE [dbo].[UserLogin]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserLogin_dbo.UserType_TypeId] FOREIGN KEY([TypeId])
REFERENCES [dbo].[UserType] ([TypeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLogin] CHECK CONSTRAINT [FK_dbo.UserLogin_dbo.UserType_TypeId]
GO
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserProfile_dbo.UserLogin_LoginId] FOREIGN KEY([LoginId])
REFERENCES [dbo].[UserLogin] ([LoginId])
GO
ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [FK_dbo.UserProfile_dbo.UserLogin_LoginId]
GO
ALTER TABLE [dbo].[UserTravelPrefMapping]  WITH CHECK ADD FOREIGN KEY([LoginId])
REFERENCES [dbo].[UserLogin] ([LoginId])
GO
ALTER TABLE [dbo].[UserTravelPrefMapping]  WITH CHECK ADD FOREIGN KEY([TravelPefid])
REFERENCES [dbo].[TravelPreferences] ([Id])
GO
USE [master]
GO
ALTER DATABASE [VHSLatest] SET  READ_WRITE 
GO
