USE [Initiatives]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ChallengeMultipleChoice](
	[Id] [uniqueidentifier] NOT NULL,
	[ExpectedAnswer] [char](1) NULL,
 CONSTRAINT [PK_ChallengeMultipleChoice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ChallengeMultipleChoiceItems]    Script Date: 2017-09-21 11:52:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ChallengeMultipleChoiceItems](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Value] [char](1) NOT NULL,
	[ChallengeMultipleChoiceId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ChallengeMultipleChoiceItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Challenges]    Script Date: 2017-09-21 11:52:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Challenges](
	[Id] [uniqueidentifier] NOT NULL,
	[InitiativeId] [uniqueidentifier] NOT NULL,
	[ChallengeTypeId] [uniqueidentifier] NOT NULL,
	[Question] [nvarchar](50) NOT NULL,
	[ChallengeYesNoId] [uniqueidentifier] NULL,
	[ChallengeMultipleChoiceId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Challenges] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChallengeTypes]    Script Date: 2017-09-21 11:52:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChallengeTypes](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[CorrelationId] [int] NOT NULL,
 CONSTRAINT [PK_ChallengeTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChallengeYesNo]    Script Date: 2017-09-21 11:52:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChallengeYesNo](
	[Id] [uniqueidentifier] NOT NULL,
	[ExpectedAnswer] [int] NOT NULL,
 CONSTRAINT [PK_ChallengeYesNo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Initiatives]    Script Date: 2017-09-21 11:52:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Initiatives](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
	[PassRate] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Initiatives] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RegistrationAttemptAnswers]    Script Date: 2017-09-21 11:52:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RegistrationAttemptAnswers](
	[Id] [uniqueidentifier] NOT NULL,
	[ChallengeId] [uniqueidentifier] NOT NULL,
	[RegistrationAttemptId] [uniqueidentifier] NOT NULL,
	[AnswerYesNo] [int] NULL,
	[AnswerMultipleChoice] [char](1) NULL,
 CONSTRAINT [PK_RegistrationAttemptQuestions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RegistrationAttempts]    Script Date: 2017-09-21 11:52:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistrationAttempts](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[EmailAddress] [nvarchar](100) NOT NULL,
	[HasSucceeded] [bit] NOT NULL,
	[InitiativeId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_RegistrationAttempts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[ChallengeTypes] ([Id], [Description], [CorrelationId]) VALUES (N'b29b6aca-0edc-4f95-86c7-0b452ae11723', N'MultipleChoice', 2)
GO
INSERT [dbo].[ChallengeTypes] ([Id], [Description], [CorrelationId]) VALUES (N'e6c23906-60ba-4bc1-8062-56413bfe15dd', N'Unknown', 0)
GO
INSERT [dbo].[ChallengeTypes] ([Id], [Description], [CorrelationId]) VALUES (N'ada66d2d-e1a0-48a7-95a5-c29765afafb4', N'YesNo', 1)
GO
ALTER TABLE [dbo].[ChallengeMultipleChoiceItems]  WITH CHECK ADD  CONSTRAINT [FK_ChallengeMultipleChoiceItems_ChallengeMultipleChoice] FOREIGN KEY([ChallengeMultipleChoiceId])
REFERENCES [dbo].[ChallengeMultipleChoice] ([Id])
GO
ALTER TABLE [dbo].[ChallengeMultipleChoiceItems] CHECK CONSTRAINT [FK_ChallengeMultipleChoiceItems_ChallengeMultipleChoice]
GO
ALTER TABLE [dbo].[Challenges]  WITH CHECK ADD  CONSTRAINT [FK_Challenges_ChallengeMultipleChoice] FOREIGN KEY([ChallengeMultipleChoiceId])
REFERENCES [dbo].[ChallengeMultipleChoice] ([Id])
GO
ALTER TABLE [dbo].[Challenges] CHECK CONSTRAINT [FK_Challenges_ChallengeMultipleChoice]
GO
ALTER TABLE [dbo].[Challenges]  WITH CHECK ADD  CONSTRAINT [FK_Challenges_ChallengeTypes] FOREIGN KEY([ChallengeTypeId])
REFERENCES [dbo].[ChallengeTypes] ([Id])
GO
ALTER TABLE [dbo].[Challenges] CHECK CONSTRAINT [FK_Challenges_ChallengeTypes]
GO
ALTER TABLE [dbo].[Challenges]  WITH CHECK ADD  CONSTRAINT [FK_Challenges_ChallengeYesNo] FOREIGN KEY([ChallengeYesNoId])
REFERENCES [dbo].[ChallengeYesNo] ([Id])
GO
ALTER TABLE [dbo].[Challenges] CHECK CONSTRAINT [FK_Challenges_ChallengeYesNo]
GO
ALTER TABLE [dbo].[Challenges]  WITH CHECK ADD  CONSTRAINT [FK_Challenges_Initiatives] FOREIGN KEY([InitiativeId])
REFERENCES [dbo].[Initiatives] ([Id])
GO
ALTER TABLE [dbo].[Challenges] CHECK CONSTRAINT [FK_Challenges_Initiatives]
GO
ALTER TABLE [dbo].[RegistrationAttemptAnswers]  WITH CHECK ADD  CONSTRAINT [FK_RegistrationAttemptQuestions_Challenges] FOREIGN KEY([ChallengeId])
REFERENCES [dbo].[Challenges] ([Id])
GO
ALTER TABLE [dbo].[RegistrationAttemptAnswers] CHECK CONSTRAINT [FK_RegistrationAttemptQuestions_Challenges]
GO
ALTER TABLE [dbo].[RegistrationAttemptAnswers]  WITH CHECK ADD  CONSTRAINT [FK_RegistrationAttemptQuestions_RegistrationAttempts] FOREIGN KEY([RegistrationAttemptId])
REFERENCES [dbo].[RegistrationAttempts] ([Id])
GO
ALTER TABLE [dbo].[RegistrationAttemptAnswers] CHECK CONSTRAINT [FK_RegistrationAttemptQuestions_RegistrationAttempts]
GO
ALTER TABLE [dbo].[RegistrationAttempts]  WITH CHECK ADD  CONSTRAINT [FK_RegistrationAttempts_Initiatives] FOREIGN KEY([InitiativeId])
REFERENCES [dbo].[Initiatives] ([Id])
GO
ALTER TABLE [dbo].[RegistrationAttempts] CHECK CONSTRAINT [FK_RegistrationAttempts_Initiatives]
GO
