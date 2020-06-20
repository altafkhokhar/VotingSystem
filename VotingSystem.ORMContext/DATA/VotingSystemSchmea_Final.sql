USE [VotingSystem]
GO

/****** Object:  Table [dbo].[User]    Script Date: 6/20/2020 6:08:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--------TABLE SCRIPT-----------


CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_Users_IsDeleted]  DEFAULT ((0)),
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF__Users__CreatedDate]  DEFAULT (getdate()),
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



CREATE TABLE [dbo].[People](
	[PeopleId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[UserId] [int] NULL,
	[Age] [int] NOT NULL,
	[Address] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_People_IsDeleted]  DEFAULT ((0)),
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF__People__CreatedDate]  DEFAULT (getdate()),
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[PeopleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[People]  WITH CHECK ADD  CONSTRAINT [FK_People_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[People] CHECK CONSTRAINT [FK_People_Users]
GO



CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NULL CONSTRAINT [DF_Category_IsDeleted]  DEFAULT ((0)),
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF__Category__CreatedDate]  DEFAULT (getdate()),
	[UpdateBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO





CREATE TABLE [dbo].[Candidate](
	[CandidateId] [int] IDENTITY(1,1) NOT NULL,
	[PeopleId] [int] NULL,
	[CategoryId] [int] NULL,
	[IsDeleted] [bit] NULL CONSTRAINT [DF_Candidates_IsDeleted]  DEFAULT ((0)),
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF__Candidate__CreatedDate]  DEFAULT (getdate()),
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Candidates] PRIMARY KEY CLUSTERED 
(
	[CandidateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Candidate]  WITH CHECK ADD  CONSTRAINT [FK_Candidate_People] FOREIGN KEY([PeopleId])
REFERENCES [dbo].[People] ([PeopleId])
GO

ALTER TABLE [dbo].[Candidate] CHECK CONSTRAINT [FK_Candidate_People]
GO

ALTER TABLE [dbo].[Candidate]  WITH CHECK ADD  CONSTRAINT [FK_Candidates_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO

ALTER TABLE [dbo].[Candidate] CHECK CONSTRAINT [FK_Candidates_Category]
GO

ALTER TABLE [dbo].[Candidate] ADD  CONSTRAINT [UQ_Candidate] UNIQUE NONCLUSTERED 
(
	[CandidateId] ASC
)
GO

CREATE TABLE [dbo].[Voter](
	[VoterId] [int] IDENTITY(1,1) NOT NULL,
	[PeopleId] [int] NULL,
	[IsDeleted] [int] NULL CONSTRAINT [DF_Voter_IsDeleted]  DEFAULT ((0)),
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_Voter_CreatedDate]  DEFAULT (getdate()),
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Voter] PRIMARY KEY CLUSTERED 
(
	[VoterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Voter]  WITH CHECK ADD  CONSTRAINT [FK_Voter_People] FOREIGN KEY([PeopleId])
REFERENCES [dbo].[People] ([PeopleId])
GO

ALTER TABLE [dbo].[Voter] CHECK CONSTRAINT [FK_Voter_People]
GO




CREATE TABLE [dbo].[Vote](
	[VoteId] [int] IDENTITY(1,1) NOT NULL,
	[VoterId] [int] NOT NULL,
	[CandidateId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[IsDeleted] [bit] NULL CONSTRAINT [DF_Votes_IsDeleted]  DEFAULT ((0)),
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF__Votes__CreatedDate]  DEFAULT (getdate()),
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Votes] PRIMARY KEY CLUSTERED 
(
	[VoteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uq_Votes] UNIQUE NONCLUSTERED 
(
	[VoterId] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Vote]  WITH CHECK ADD  CONSTRAINT [FK_Votes_Candidates] FOREIGN KEY([CandidateId])
REFERENCES [dbo].[Candidate] ([CandidateId])
GO

ALTER TABLE [dbo].[Vote] CHECK CONSTRAINT [FK_Votes_Candidates]
GO

ALTER TABLE [dbo].[Vote]  WITH CHECK ADD  CONSTRAINT [FK_Votes_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO

ALTER TABLE [dbo].[Vote] CHECK CONSTRAINT [FK_Votes_Category]
GO


-------table script end

--------proc script----



 CREATE PROCEDURE [dbo].[USP_CandidateVoteCount]

  /*
  EXEC CandidateVotesCount @CandidateId = 2
  */
(
	@CandidateId int = NULL
)

	AS
BEGIN

select  V.CategoryId, cat.CategoryName,  COUNT(VoterId) as VoteCount from Vote AS V
	INNER JOIN Category AS cat ON cat.CategoryId = v.CategoryId 
  WHERE v.CandidateId =@CandidateId
  GROUP BY V.CategoryId, cat.CategoryName

 END

 
GO

