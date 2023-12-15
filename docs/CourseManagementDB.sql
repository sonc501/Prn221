USE [master]
GO
/****** Object:  Database [CourseManagerDB]    Script Date: 8/12/2023 1:25:36 PM ******/
CREATE DATABASE [CourseManagerDB]
GO
ALTER DATABASE [CourseManagerDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CourseManagerDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CourseManagerDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CourseManagerDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CourseManagerDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CourseManagerDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CourseManagerDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CourseManagerDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CourseManagerDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CourseManagerDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CourseManagerDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CourseManagerDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CourseManagerDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CourseManagerDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CourseManagerDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CourseManagerDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CourseManagerDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CourseManagerDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CourseManagerDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CourseManagerDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CourseManagerDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CourseManagerDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CourseManagerDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CourseManagerDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CourseManagerDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CourseManagerDB] SET  MULTI_USER 
GO
ALTER DATABASE [CourseManagerDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CourseManagerDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CourseManagerDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CourseManagerDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CourseManagerDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CourseManagerDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CourseManagerDB] SET QUERY_STORE = OFF
GO
USE [CourseManagerDB]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 8/12/2023 1:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[ID] [int] NOT NULL,
	[StudentInCourseID] [int] NOT NULL,
	[SessionID] [int] NOT NULL,
	[Description] [varchar](255) NULL,
	[AttendanceDate] [datetime] NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 8/12/2023 1:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[ID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](255) NULL,
	[SessionCount] [int] NOT NULL,
	[SemesterID] [int] NOT NULL,
	[SubjectID] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Major]    Script Date: 8/12/2023 1:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Major](
	[ID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Desciption] [varchar](255) NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 8/12/2023 1:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 8/12/2023 1:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[ID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](255) NULL,
	[Capacity] [int] NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Semester]    Script Date: 8/12/2023 1:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semester](
	[ID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Session]    Script Date: 8/12/2023 1:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Session](
	[ID] [int] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[CourseID] [int] NOT NULL,
	[RoomID] [int] NOT NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 8/12/2023 1:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[ID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Address] [varchar](255) NOT NULL,
	[EnrollDate] [date] NOT NULL,
	[MajorID] [int] NOT NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentInCourse]    Script Date: 8/12/2023 1:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentInCourse](
	[ID] [int] NOT NULL,
	[CourseID] [int] NOT NULL,
	[StudentID] [int] NOT NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 8/12/2023 1:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[ID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](255) NULL,
	[MajorID] [int] NOT NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 8/12/2023 1:25:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[RoleID] [int] NOT NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Attendance] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Room] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Semester] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Session] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Student] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[StudentInCourse] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FKAttendance212911] FOREIGN KEY([StudentInCourseID])
REFERENCES [dbo].[StudentInCourse] ([ID])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FKAttendance212911]
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FKAttendance330821] FOREIGN KEY([SessionID])
REFERENCES [dbo].[Session] ([ID])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FKAttendance330821]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FKCourse376970] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subject] ([ID])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FKCourse376970]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FKCourse520946] FOREIGN KEY([SemesterID])
REFERENCES [dbo].[Semester] ([ID])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FKCourse520946]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FKSession226261] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([ID])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FKSession226261]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FKSession746100] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Room] ([ID])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FKSession746100]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FKStudent707023] FOREIGN KEY([MajorID])
REFERENCES [dbo].[Major] ([ID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FKStudent707023]
GO
ALTER TABLE [dbo].[StudentInCourse]  WITH CHECK ADD  CONSTRAINT [FKStudentInC83153] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[StudentInCourse] CHECK CONSTRAINT [FKStudentInC83153]
GO
ALTER TABLE [dbo].[StudentInCourse]  WITH CHECK ADD  CONSTRAINT [FKStudentInC845509] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([ID])
GO
ALTER TABLE [dbo].[StudentInCourse] CHECK CONSTRAINT [FKStudentInC845509]
GO
ALTER TABLE [dbo].[Subject]  WITH CHECK ADD  CONSTRAINT [FKSubject446355] FOREIGN KEY([MajorID])
REFERENCES [dbo].[Major] ([ID])
GO
ALTER TABLE [dbo].[Subject] CHECK CONSTRAINT [FKSubject446355]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FKUser349791] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FKUser349791]
GO
USE [master]
GO
ALTER DATABASE [CourseManagerDB] SET  READ_WRITE 
GO
/*insert new data*/
USE [master]
GO
USE [CourseManagerDB]
GO
INSERT INTO [dbo].[Semester]
  (ID, 
  Name, 
  StartDate, 
  EndDate, 
  Status)
VALUES 
  (0, 
  N'SPRING2022', 
  CAST(N'2022-05-18' AS date), 
  CAST(N'2022-05-18' AS date),
  1),
  (1, 
  N'SPRING2023', 
  CAST(N'2023-05-18' AS date), 
  CAST(N'2023-05-18' AS date),
  1);
  Go
INSERT INTO [dbo].[Major]
  ([ID], 
  [Name], 
  [Desciption], 
  [Status]) 
VALUES 
  (0, 
  N'SE', 
  N'Software Engineer', 
  1),
  (1, 
  N'SS', 
  N'Software Engineer', 
  1); 
  GO
INSERT INTO [dbo].[Subject]
  ([ID], 
  [Name], 
  [Description], 
  [MajorID], 
  [Status]) 
VALUES 
  (0, 
  N'PRN211', 
  NULL, 
  0, 
  1),
  (1, 
  N'PRN221', 
  NULL, 
  0, 
  1); 
  GO
INSERT INTO [dbo].[Course]
  ([ID], 
  [Name], 
  [Description], 
  [SessionCount], 
  [SemesterID], 
  [SubjectID], 
  [StartDate], 
  [EndDate], 
  [Status]) 
VALUES 
  (0, 
  'PRN221_3W', 
  NULL, 
  1, 
  0, 
  0, 
  CAST(N'2022-05-18' AS date), 
  CAST(N'2022-05-18' AS date), 
  1); 
  GO

INSERT INTO [dbo].[Role]
  ([ID], 
  [Name], 
  [Status]) 
VALUES 
  (0, 
  N'Admin', 
  1),
  (1, 
  N'Lecturer', 
  1)
  ; 
  GO

INSERT INTO [dbo].[Room]
  ([ID], 
  [Name], 
  [Description], 
  [Capacity], 
  [Status]) 
VALUES 
  (0, 
  N'001', 
  N'Phong 001', 
  10, 
  1), 
  (1, 
  N'002', 
  N'Phong 002', 
  10, 
  1); 
  GO

INSERT INTO [dbo].[Session]
  ([ID], 
  [StartTime], 
  [EndTime], 
  [CourseID], 
  [RoomID], 
  [Status]) 
VALUES 
  (0, 
  CAST(N'2022-05-18' AS date), 
  CAST(N'2022-05-18' AS date), 
  0, 
  0, 
  1); 
  GO
  

INSERT INTO [dbo].[Student]
  ([ID], 
  [Name], 
  [Code], 
  [Email], 
  [Address], 
  [EnrollDate], 
  [MajorID], 
  [Status]) 
VALUES 
  (0, 
  N'Sa', 
  N'SE123456', 
  N'student@gmail.com', 
  N'HCM', 
  CAST(N'2022-05-18' AS date),  
  1, 
  1); 
  GO

INSERT INTO [dbo].[StudentInCourse]
  ([ID], 
  [CourseID], 
  [StudentID], 
  [Status]) 
VALUES 
  (0, 
  0, 
  0, 
  1); 
  GO
INSERT INTO [dbo].[Attendance]
  ([ID], 
  [StudentInCourseID], 
  [SessionID], 
  [Description], 
  [AttendanceDate], 
  [Status]) 
VALUES 
  (0, 
  0, 
  0, 
  NULL, 
  CAST(N'2022-05-18' AS date), 
  1); 
  GO


INSERT INTO [dbo].[User]
  ([ID], 
  [Username], 
  [Password], 
  [Email], 
  [RoleID], 
  [Status]) 
VALUES 
  (0, 
  N'admin', 
  N'admin', 
  N'admin@gmail.com', 
  0, 
  1),
  (1, 
  N'lecturer', 
  N'123', 
  N'lecturer@gmail.com', 
  1, 
  1); 
  GO
