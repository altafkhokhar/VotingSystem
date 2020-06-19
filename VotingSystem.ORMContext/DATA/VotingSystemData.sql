USE [VotingSystem]
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [UserName], [Password], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (1, N'Aakib Shaikh', N'10201020', 0, N'Aakib Shaikh', CAST(N'2020-06-18T19:23:18.890' AS DateTime), N'Aakib Shaikh', CAST(N'2020-06-18T19:23:18.890' AS DateTime))
INSERT [dbo].[User] ([UserId], [UserName], [Password], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (2, N'BOB HANSIE', N'11122233', 0, N'BOB HANSIE', CAST(N'2020-06-18T19:23:43.850' AS DateTime), N'Zakir Shaikh', CAST(N'2020-06-18T19:23:43.850' AS DateTime))
INSERT [dbo].[User] ([UserId], [UserName], [Password], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (3, N'Javed Shaikh', N'22200011', 0, N'Javed Shaikh', CAST(N'2020-06-18T19:24:00.690' AS DateTime), N'Javed Shaikh', CAST(N'2020-06-18T19:24:00.690' AS DateTime))
INSERT [dbo].[User] ([UserId], [UserName], [Password], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (4, N'Aarif Shaikh', N'52010201', 0, N'Aarif Shaikh', CAST(N'2020-06-18T19:25:01.703' AS DateTime), N'Aarif Shaikh', CAST(N'2020-06-18T19:23:13.177' AS DateTime))
SET IDENTITY_INSERT [dbo].[User] OFF
--------

SET IDENTITY_INSERT [dbo].[People] ON 

INSERT [dbo].[People] ([PeopleId], [FirstName], [LastName], [UserId], [Age], [Address], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (5, N'Aakib', N'Shaikh', 1, 25, N'Ahmedabad', 0, N'Aakib Shaikh', CAST(N'2020-06-18T19:31:56.183' AS DateTime), N'Aakib Shaikh', CAST(N'2020-06-18T19:31:56.183' AS DateTime))
INSERT [dbo].[People] ([PeopleId], [FirstName], [LastName], [UserId], [Age], [Address], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (6, N'Zakir', N'Shaikh', 2, 26, N'Ahmedabad', 0, N'Zakir Shaikh', CAST(N'2020-06-18T19:23:43.850' AS DateTime), N'Zakir Shaikh', CAST(N'2020-06-18T19:23:43.850' AS DateTime))
INSERT [dbo].[People] ([PeopleId], [FirstName], [LastName], [UserId], [Age], [Address], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (7, N'Javed', N'Shaikh', 3, 27, N'Ahmedabad', 0, N'Javed Shaikh', CAST(N'2020-06-18T19:34:04.203' AS DateTime), N'Javed Shaikh', CAST(N'2020-06-18T19:34:04.203' AS DateTime))
INSERT [dbo].[People] ([PeopleId], [FirstName], [LastName], [UserId], [Age], [Address], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (9, N'Aarif', N'Shaikh', 4, 28, N'Ahmedabad', 0, N'Aarif Shaikh', CAST(N'2020-06-18T19:52:46.437' AS DateTime), N'Aarif Shaikh', CAST(N'2020-06-18T19:52:46.437' AS DateTime))
--------

SET IDENTITY_INSERT [dbo].[People] OFF
INSERT [dbo].[Voter] ([VoterId], [PeopleId], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (1, 5, 0, N'Aakib Shaikh', CAST(N'2020-06-18T19:31:56.183' AS DateTime), N'Aakib Shaikh', CAST(N'2020-06-18T19:31:56.183' AS DateTime))
INSERT [dbo].[Voter] ([VoterId], [PeopleId], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (2, 6, 0, N'Aakib Shaikh', CAST(N'2020-06-18T19:31:56.183' AS DateTime), N'Aakib Shaikh', CAST(N'2020-06-18T19:31:56.183' AS DateTime))
INSERT [dbo].[Voter] ([VoterId], [PeopleId], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (3, 7, 0, N'Aakib Shaikh', CAST(N'2020-06-18T19:31:56.183' AS DateTime), N'Aakib Shaikh', CAST(N'2020-06-18T19:31:56.183' AS DateTime))
INSERT [dbo].[Voter] ([VoterId], [PeopleId], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (4, 9, 0, N'Aakib Shaikh', CAST(N'2020-06-18T19:31:56.183' AS DateTime), N'Aakib Shaikh', CAST(N'2020-06-18T19:31:56.183' AS DateTime))
SET IDENTITY_INSERT [dbo].[Category] ON 

--------

INSERT [dbo].[Category] ([CategoryId], [CategoryName], [IsDeleted], [CreatedBy], [CreatedDate], [UpdateBy], [UpdatedDate]) VALUES (2, N'President', 0, N'Aakib Shaikh', CAST(N'2020-06-18T19:23:18.890' AS DateTime), N'Aakib Shaikh', CAST(N'2020-06-18T19:23:18.890' AS DateTime))
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [IsDeleted], [CreatedBy], [CreatedDate], [UpdateBy], [UpdatedDate]) VALUES (4, N'Vice President', 0, N'Zakir Shaikh', CAST(N'2020-06-18T19:55:43.637' AS DateTime), N'Zakir Shaikh', CAST(N'2020-06-18T19:55:43.637' AS DateTime))
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [IsDeleted], [CreatedBy], [CreatedDate], [UpdateBy], [UpdatedDate]) VALUES (5, N'Secretary', 0, N'Javed Shaikh', CAST(N'2020-06-18T19:56:09.230' AS DateTime), N'Javed Shaikh', CAST(N'2020-06-18T19:56:09.230' AS DateTime))
SET IDENTITY_INSERT [dbo].[Category] OFF

--------

SET IDENTITY_INSERT [dbo].[Candidate] ON 

INSERT [dbo].[Candidate] ([CandidateId], [PeopleId], [CategoryId], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (2, 5, 2, 0, N'Aakib Shaikh', CAST(N'2020-06-18T19:58:15.263' AS DateTime), N'Aakib Shaikh', CAST(N'2020-06-18T19:58:15.263' AS DateTime))
INSERT [dbo].[Candidate] ([CandidateId], [PeopleId], [CategoryId], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (7, 9, 4, 0, N'Aakib Shaikh', CAST(N'2020-06-18T20:00:31.453' AS DateTime), N'Aakib Shaikh', CAST(N'2020-06-18T20:00:31.453' AS DateTime))
SET IDENTITY_INSERT [dbo].[Candidate] OFF

--------

SET IDENTITY_INSERT [dbo].[Vote] ON 

INSERT [dbo].[Vote] ([VoteId], [VoterId], [CandidateId], [CategoryId], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (1, 1, 2, 2, 0, N'Aakib Shaikh', CAST(N'2020-06-18T19:58:15.263' AS DateTime), N'Aakib Shaikh', CAST(N'2020-06-18T19:58:15.263' AS DateTime))
INSERT [dbo].[Vote] ([VoteId], [VoterId], [CandidateId], [CategoryId], [IsDeleted], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (2, 2, 7, 2, 0, N'Aakib Shaikh', CAST(N'2020-06-18T20:03:54.640' AS DateTime), N'Aakib Shaikh', CAST(N'2020-06-18T20:03:54.640' AS DateTime))

SET IDENTITY_INSERT [dbo].[Vote] OFF


--------