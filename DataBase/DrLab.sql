USE [DRLAB_LITE]
GO
/****** Object:  Table [dbo].[E00T_Customer]    Script Date: 5/8/2020 5:12:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E00T_Customer](
	[customerCode] [nvarchar](50) NOT NULL,
	[companyName] [nvarchar](500) NULL,
	[contactName] [nvarchar](500) NULL,
	[contactEmail] [nvarchar](500) NULL,
	[companyAddress] [nvarchar](500) NULL,
	[city] [nvarchar](500) NULL,
	[note] [nvarchar](500) NULL,
 CONSTRAINT [PK_E00T_Customer] PRIMARY KEY CLUSTERED 
(
	[customerCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[E00T_Customer_Item]    Script Date: 5/8/2020 5:12:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E00T_Customer_Item](
	[contactID] [bigint] IDENTITY(1,1) NOT NULL,
	[customerCode] [nvarchar](50) NULL,
	[contactName] [nvarchar](500) NULL,
	[email] [nvarchar](50) NULL,
	[address] [nvarchar](500) NULL,
	[note] [nvarchar](200) NULL,
 CONSTRAINT [PK_E00T_Customer_Item] PRIMARY KEY CLUSTERED 
(
	[contactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[E00T_SampleMatrix]    Script Date: 5/8/2020 5:12:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E00T_SampleMatrix](
	[matrixID] [bigint] IDENTITY(1,1) NOT NULL,
	[sampleMatrix] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_E00T_SampleMatrix] PRIMARY KEY CLUSTERED 
(
	[matrixID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[E00T_Specification]    Script Date: 5/8/2020 5:12:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E00T_Specification](
	[specID] [bigint] IDENTITY(1,1) NOT NULL,
	[specification] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_E00T_Specification] PRIMARY KEY CLUSTERED 
(
	[specID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[E08T_AnalysisRequest_Data]    Script Date: 5/8/2020 5:12:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E08T_AnalysisRequest_Data](
	[requestNo] [nvarchar](50) NOT NULL,
	[LVNCode] [nvarchar](50) NOT NULL,
	[analysisCode] [nvarchar](50) NOT NULL,
	[sampleMatrix] [nvarchar](50) NOT NULL,
	[specification] [nvarchar](250) NOT NULL,
	[method] [nvarchar](250) NULL,
	[min] [float] NULL,
	[max] [float] NULL,
	[precision] [float] NULL,
	[unit] [nvarchar](50) NULL,
	[LOD] [nvarchar](50) NULL,
	[urgentRate] [int] NULL,
	[price] [float] NULL,
	[turnAroundDay] [float] NULL,
	[specMark] [varchar](20) NULL,
 CONSTRAINT [PK_E08T_AnalysisRequest_Data] PRIMARY KEY CLUSTERED 
(
	[requestNo] ASC,
	[LVNCode] ASC,
	[analysisCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[E08T_AnalysisRequest_Info]    Script Date: 5/8/2020 5:12:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E08T_AnalysisRequest_Info](
	[requestNo] [nvarchar](50) NOT NULL,
	[customerID] [nvarchar](50) NULL,
	[receivceDate] [datetime] NULL,
	[dateOfSendingResult] [datetime] NULL,
	[status] [int] NULL,
	[orderConfim] [bit] NULL,
	[contactID] [bigint] NULL,
	[testReportContactID] [nvarchar](50) NULL,
	[numberSample] [int] NULL,
	[printVAT] [int] NULL,
	[priceID] [nvarchar](50) NULL,
	[note] [nvarchar](200) NULL,
 CONSTRAINT [PK_E08T_AnalysisRequest_Info] PRIMARY KEY CLUSTERED 
(
	[requestNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[E08T_AnalysisRequest_Item]    Script Date: 5/8/2020 5:12:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E08T_AnalysisRequest_Item](
	[requestNo] [nvarchar](50) NOT NULL,
	[LVNCode] [nvarchar](50) NOT NULL,
	[sampleCode] [nvarchar](100) NULL,
	[sampleName] [nvarchar](1000) NULL,
	[sampleDescription] [nvarchar](400) NULL,
	[weight] [nvarchar](100) NULL,
	[remarkToLab] [nvarchar](400) NULL,
	[detected] [bit] NULL,
 CONSTRAINT [PK_E08T_AnalysisRequest_Item] PRIMARY KEY CLUSTERED 
(
	[requestNo] ASC,
	[LVNCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[E08T_Testing_Data]    Script Date: 5/8/2020 5:12:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E08T_Testing_Data](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[matrixID] [bigint] NOT NULL,
	[specID] [bigint] NOT NULL,
	[min] [float] NULL,
	[max] [float] NULL,
	[precision] [float] NULL,
	[LOD] [nvarchar](50) NULL,
 CONSTRAINT [PK_E08T_Testing_Item] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[E08T_Testing_Info]    Script Date: 5/8/2020 5:12:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E08T_Testing_Info](
	[analysisCode] [nvarchar](50) NOT NULL,
	[specID] [bigint] NOT NULL,
	[specification] [nvarchar](250) NULL,
	[method] [nvarchar](250) NULL,
	[unit] [nvarchar](50) NULL,
	[turnAroundTime] [float] NULL,
	[reformTestResult] [bit] NULL,
	[note] [nvarchar](200) NULL,
 CONSTRAINT [PK_E08T_Testing_Info] PRIMARY KEY CLUSTERED 
(
	[analysisCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[E00T_Customer] ADD  DEFAULT ('Note') FOR [note]
GO
ALTER TABLE [dbo].[E00T_Customer_Item] ADD  DEFAULT ('Note') FOR [note]
GO
ALTER TABLE [dbo].[E08T_AnalysisRequest_Data] ADD  DEFAULT ((0)) FOR [urgentRate]
GO
ALTER TABLE [dbo].[E08T_AnalysisRequest_Data] ADD  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[E08T_AnalysisRequest_Data] ADD  DEFAULT ((0)) FOR [turnAroundDay]
GO
ALTER TABLE [dbo].[E08T_AnalysisRequest_Data] ADD  DEFAULT ('') FOR [specMark]
GO
ALTER TABLE [dbo].[E08T_AnalysisRequest_Info] ADD  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[E08T_AnalysisRequest_Info] ADD  DEFAULT ((0)) FOR [orderConfim]
GO
ALTER TABLE [dbo].[E08T_AnalysisRequest_Info] ADD  CONSTRAINT [DF_E08T_AnalysisRequest_Info_NumberSample]  DEFAULT ((0)) FOR [numberSample]
GO
ALTER TABLE [dbo].[E08T_AnalysisRequest_Info] ADD  DEFAULT ((0)) FOR [printVAT]
GO
ALTER TABLE [dbo].[E08T_AnalysisRequest_Item] ADD  DEFAULT ((0)) FOR [detected]
GO
ALTER TABLE [dbo].[E08T_Testing_Data] ADD  DEFAULT ((0)) FOR [min]
GO
ALTER TABLE [dbo].[E08T_Testing_Data] ADD  DEFAULT ((0)) FOR [max]
GO
ALTER TABLE [dbo].[E08T_Testing_Data] ADD  DEFAULT ((0)) FOR [precision]
GO
ALTER TABLE [dbo].[E08T_Testing_Data] ADD  DEFAULT ('0') FOR [LOD]
GO
ALTER TABLE [dbo].[E08T_Testing_Info] ADD  DEFAULT ((0)) FOR [turnAroundTime]
GO
ALTER TABLE [dbo].[E08T_Testing_Info] ADD  DEFAULT ((0)) FOR [reformTestResult]
GO
ALTER TABLE [dbo].[E08T_Testing_Info] ADD  DEFAULT ('Note') FOR [note]
GO
ALTER TABLE [dbo].[E00T_Customer_Item]  WITH CHECK ADD  CONSTRAINT [FK_E00T_Customer_Item_E00T_Customer] FOREIGN KEY([customerCode])
REFERENCES [dbo].[E00T_Customer] ([customerCode])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[E00T_Customer_Item] CHECK CONSTRAINT [FK_E00T_Customer_Item_E00T_Customer]
GO
ALTER TABLE [dbo].[E08T_AnalysisRequest_Data]  WITH NOCHECK ADD  CONSTRAINT [FK_E08T_AnalysisRequest_Data_E08T_AnalysisRequest_Item] FOREIGN KEY([requestNo], [LVNCode])
REFERENCES [dbo].[E08T_AnalysisRequest_Item] ([requestNo], [LVNCode])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[E08T_AnalysisRequest_Data] NOCHECK CONSTRAINT [FK_E08T_AnalysisRequest_Data_E08T_AnalysisRequest_Item]
GO
ALTER TABLE [dbo].[E08T_AnalysisRequest_Info]  WITH NOCHECK ADD  CONSTRAINT [FK_E08T_AnalysisRequest_Info_E00T_Customer] FOREIGN KEY([customerID])
REFERENCES [dbo].[E00T_Customer] ([customerCode])
GO
ALTER TABLE [dbo].[E08T_AnalysisRequest_Info] NOCHECK CONSTRAINT [FK_E08T_AnalysisRequest_Info_E00T_Customer]
GO
ALTER TABLE [dbo].[E08T_AnalysisRequest_Item]  WITH NOCHECK ADD  CONSTRAINT [FK_E08T_AnalysisRequest_Item_E08T_AnalysisRequest_Info] FOREIGN KEY([requestNo])
REFERENCES [dbo].[E08T_AnalysisRequest_Info] ([requestNo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[E08T_AnalysisRequest_Item] NOCHECK CONSTRAINT [FK_E08T_AnalysisRequest_Item_E08T_AnalysisRequest_Info]
GO
ALTER TABLE [dbo].[E08T_Testing_Data]  WITH CHECK ADD  CONSTRAINT [FK_E08T_Testing_Data_E00T_SampleMatrix] FOREIGN KEY([matrixID])
REFERENCES [dbo].[E00T_SampleMatrix] ([matrixID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[E08T_Testing_Data] CHECK CONSTRAINT [FK_E08T_Testing_Data_E00T_SampleMatrix]
GO
ALTER TABLE [dbo].[E08T_Testing_Data]  WITH CHECK ADD  CONSTRAINT [FK_E08T_Testing_Data_E00T_Specification] FOREIGN KEY([specID])
REFERENCES [dbo].[E00T_Specification] ([specID])
GO
ALTER TABLE [dbo].[E08T_Testing_Data] CHECK CONSTRAINT [FK_E08T_Testing_Data_E00T_Specification]
GO
ALTER TABLE [dbo].[E08T_Testing_Info]  WITH CHECK ADD  CONSTRAINT [FK_E08T_Testing_Info_E00T_Specification] FOREIGN KEY([specID])
REFERENCES [dbo].[E00T_Specification] ([specID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[E08T_Testing_Info] CHECK CONSTRAINT [FK_E08T_Testing_Info_E00T_Specification]
GO
