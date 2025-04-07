CREATE DATABASE [TestEdisonInterRapidisimo];
GO
USE [TestEdisonInterRapidisimo]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 4/7/2025 11:01:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[IdRole] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[IdRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 4/7/2025 11:01:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nchar](30) NOT NULL,
	[Code] [nchar](10) NOT NULL,
	[Credits] [int] NOT NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/7/2025 11:01:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[IdUser] [uniqueidentifier] NOT NULL,
	[Name] [nchar](50) NOT NULL,
	[Email] [nchar](50) NOT NULL,
	[EnrollmentDate] [datetime2](7) NOT NULL,
	[IdRole] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSubjects]    Script Date: 4/7/2025 11:01:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSubjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUser] [uniqueidentifier] NOT NULL,
	[IdSubject] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_UserSubjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([IdRole], [Name]) VALUES (1, N'Student')
GO
INSERT [dbo].[Roles] ([IdRole], [Name]) VALUES (2, N'Teacher')
GO
INSERT [dbo].[Roles] ([IdRole], [Name]) VALUES (3, N'Admin')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
INSERT [dbo].[Subjects] ([Id], [Name], [Code], [Credits]) VALUES (N'239e9062-5102-4de2-bb65-221430d21b6d', N'Computer Science', N'CS101', 3)
GO
INSERT [dbo].[Subjects] ([Id], [Name], [Code], [Credits]) VALUES (N'348aee36-af32-4824-a66e-371d7193d10e', N'Biology', N'BIO101', 3)
GO
INSERT [dbo].[Subjects] ([Id], [Name], [Code], [Credits]) VALUES (N'53e01eb3-5b81-4216-aca0-630c87f5e348', N'Art', N'ART101', 3)
GO
INSERT [dbo].[Subjects] ([Id], [Name], [Code], [Credits]) VALUES (N'e424c795-5974-45f4-8c7f-69b635633465', N'Chemistry', N'CHEM101', 3)
GO
INSERT [dbo].[Subjects] ([Id], [Name], [Code], [Credits]) VALUES (N'63160108-af28-4bde-b14f-7c1a71e81970', N'History', N'HIST101', 3)
GO
INSERT [dbo].[Subjects] ([Id], [Name], [Code], [Credits]) VALUES (N'205934e3-1231-43f6-b1ce-abdc33dbeead', N'Physics', N'PHYS101', 3)
GO
INSERT [dbo].[Subjects] ([Id], [Name], [Code], [Credits]) VALUES (N'1fc07a70-ac8a-4a07-bede-b5439fba8f11', N'English', N'ENG101', 3)
GO
INSERT [dbo].[Subjects] ([Id], [Name], [Code], [Credits]) VALUES (N'2f93414a-4bc5-4d52-8802-d39b10248f78', N'Geography', N'GEO101', 3)
GO
INSERT [dbo].[Subjects] ([Id], [Name], [Code], [Credits]) VALUES (N'da7ba262-6bb8-4441-b92d-dcf3d7cbcc93', N'Spanish', N'SPA101', 3)
GO
INSERT [dbo].[Subjects] ([Id], [Name], [Code], [Credits]) VALUES (N'efedafab-2680-4993-bcd8-f985d2651db1', N'Mathematics', N'MATH101', 3)
GO
INSERT [dbo].[Users] ([IdUser], [Name], [Email], [EnrollmentDate], [IdRole]) VALUES (N'315afcc2-564e-4c9a-9f26-32c4dea258f1', N'Teacher 1', N'teacher1@gmail.com', CAST(N'2025-04-07T09:50:59.1411363' AS DateTime2), 2)
GO
INSERT [dbo].[Users] ([IdUser], [Name], [Email], [EnrollmentDate], [IdRole]) VALUES (N'b32a5788-f846-4d54-8784-3d2c937c65da', N'Teacher 2', N'teacher2@gmail.com', CAST(N'2025-04-07T09:50:59.1419513' AS DateTime2), 2)
GO
INSERT [dbo].[Users] ([IdUser], [Name], [Email], [EnrollmentDate], [IdRole]) VALUES (N'96b2d65a-233d-43c1-96ff-4ad52a2a26e0', N'Teacher 5', N'teacher5@gmail.com', CAST(N'2025-04-07T09:50:59.1419535' AS DateTime2), 2)
GO
INSERT [dbo].[Users] ([IdUser], [Name], [Email], [EnrollmentDate], [IdRole]) VALUES (N'645122d9-67ac-4df8-b401-8859f3bb6706', N'Teacher 3', N'teacher3@gmail.com', CAST(N'2025-04-07T09:50:59.1419524' AS DateTime2), 2)
GO
INSERT [dbo].[Users] ([IdUser], [Name], [Email], [EnrollmentDate], [IdRole]) VALUES (N'9bdd9f32-378f-4df2-b098-b83d13f82655', N'Teacher 4', N'teacher4@gmail.com', CAST(N'2025-04-07T09:50:59.1419530' AS DateTime2), 2)
GO
SET IDENTITY_INSERT [dbo].[UserSubjects] ON 
GO
INSERT [dbo].[UserSubjects] ([Id], [IdUser], [IdSubject]) VALUES (1, N'315afcc2-564e-4c9a-9f26-32c4dea258f1', N'239e9062-5102-4de2-bb65-221430d21b6d')
GO
INSERT [dbo].[UserSubjects] ([Id], [IdUser], [IdSubject]) VALUES (2, N'315afcc2-564e-4c9a-9f26-32c4dea258f1', N'348aee36-af32-4824-a66e-371d7193d10e')
GO
INSERT [dbo].[UserSubjects] ([Id], [IdUser], [IdSubject]) VALUES (3, N'b32a5788-f846-4d54-8784-3d2c937c65da', N'53e01eb3-5b81-4216-aca0-630c87f5e348')
GO
INSERT [dbo].[UserSubjects] ([Id], [IdUser], [IdSubject]) VALUES (4, N'b32a5788-f846-4d54-8784-3d2c937c65da', N'e424c795-5974-45f4-8c7f-69b635633465')
GO
INSERT [dbo].[UserSubjects] ([Id], [IdUser], [IdSubject]) VALUES (5, N'96b2d65a-233d-43c1-96ff-4ad52a2a26e0', N'63160108-af28-4bde-b14f-7c1a71e81970')
GO
INSERT [dbo].[UserSubjects] ([Id], [IdUser], [IdSubject]) VALUES (6, N'96b2d65a-233d-43c1-96ff-4ad52a2a26e0', N'205934e3-1231-43f6-b1ce-abdc33dbeead')
GO
INSERT [dbo].[UserSubjects] ([Id], [IdUser], [IdSubject]) VALUES (7, N'645122d9-67ac-4df8-b401-8859f3bb6706', N'1fc07a70-ac8a-4a07-bede-b5439fba8f11')
GO
INSERT [dbo].[UserSubjects] ([Id], [IdUser], [IdSubject]) VALUES (8, N'645122d9-67ac-4df8-b401-8859f3bb6706', N'2f93414a-4bc5-4d52-8802-d39b10248f78')
GO
INSERT [dbo].[UserSubjects] ([Id], [IdUser], [IdSubject]) VALUES (9, N'9bdd9f32-378f-4df2-b098-b83d13f82655', N'da7ba262-6bb8-4441-b92d-dcf3d7cbcc93')
GO
INSERT [dbo].[UserSubjects] ([Id], [IdUser], [IdSubject]) VALUES (10, N'9bdd9f32-378f-4df2-b098-b83d13f82655', N'efedafab-2680-4993-bcd8-f985d2651db1')
GO
SET IDENTITY_INSERT [dbo].[UserSubjects] OFF
GO
ALTER TABLE [dbo].[Subjects] ADD  DEFAULT ((0)) FOR [Credits]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [IdRole]
GO
ALTER TABLE [dbo].[UserSubjects]  WITH CHECK ADD  CONSTRAINT [FK_UserSubjects_Subjects] FOREIGN KEY([IdSubject])
REFERENCES [dbo].[Subjects] ([Id])
GO
ALTER TABLE [dbo].[UserSubjects] CHECK CONSTRAINT [FK_UserSubjects_Subjects]
GO
ALTER TABLE [dbo].[UserSubjects]  WITH CHECK ADD  CONSTRAINT [FK_UserSubjects_Users] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Users] ([IdUser])
GO
ALTER TABLE [dbo].[UserSubjects] CHECK CONSTRAINT [FK_UserSubjects_Users]
GO
