
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/13/2018 21:38:04
-- Generated from EDMX file: D:\Programming\level_3_lesson_1\MailSender.git\SpamTools\MailSenderGUI\data\database.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SpamDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Recipients'
CREATE TABLE [dbo].[Recipients] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'MailingLists'
CREATE TABLE [dbo].[MailingLists] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'Emails'
CREATE TABLE [dbo].[Emails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Body] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'SchedulerTasks'
CREATE TABLE [dbo].[SchedulerTasks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Time] datetime  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [MailingList_Id] int  NULL,
    [Sender_Id] int  NOT NULL,
    [Server_Id] int  NOT NULL
);
GO

-- Creating table 'Senders'
CREATE TABLE [dbo].[Senders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Servers'
CREATE TABLE [dbo].[Servers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Port] nvarchar(max)  NOT NULL,
    [UseSSL] bit  NOT NULL
);
GO

-- Creating table 'RecipientMailingList'
CREATE TABLE [dbo].[RecipientMailingList] (
    [Recipient_Id] int  NOT NULL,
    [MailingLists_Id] int  NOT NULL
);
GO

-- Creating table 'SchedulerTaskEmail'
CREATE TABLE [dbo].[SchedulerTaskEmail] (
    [SchedulerTask_Id] int  NOT NULL,
    [Emails_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Recipients'
ALTER TABLE [dbo].[Recipients]
ADD CONSTRAINT [PK_Recipients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MailingLists'
ALTER TABLE [dbo].[MailingLists]
ADD CONSTRAINT [PK_MailingLists]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Emails'
ALTER TABLE [dbo].[Emails]
ADD CONSTRAINT [PK_Emails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SchedulerTasks'
ALTER TABLE [dbo].[SchedulerTasks]
ADD CONSTRAINT [PK_SchedulerTasks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Senders'
ALTER TABLE [dbo].[Senders]
ADD CONSTRAINT [PK_Senders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Servers'
ALTER TABLE [dbo].[Servers]
ADD CONSTRAINT [PK_Servers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Recipient_Id], [MailingLists_Id] in table 'RecipientMailingList'
ALTER TABLE [dbo].[RecipientMailingList]
ADD CONSTRAINT [PK_RecipientMailingList]
    PRIMARY KEY CLUSTERED ([Recipient_Id], [MailingLists_Id] ASC);
GO

-- Creating primary key on [SchedulerTask_Id], [Emails_Id] in table 'SchedulerTaskEmail'
ALTER TABLE [dbo].[SchedulerTaskEmail]
ADD CONSTRAINT [PK_SchedulerTaskEmail]
    PRIMARY KEY CLUSTERED ([SchedulerTask_Id], [Emails_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Recipient_Id] in table 'RecipientMailingList'
ALTER TABLE [dbo].[RecipientMailingList]
ADD CONSTRAINT [FK_RecipientMailingList_Recipient]
    FOREIGN KEY ([Recipient_Id])
    REFERENCES [dbo].[Recipients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MailingLists_Id] in table 'RecipientMailingList'
ALTER TABLE [dbo].[RecipientMailingList]
ADD CONSTRAINT [FK_RecipientMailingList_MailingList]
    FOREIGN KEY ([MailingLists_Id])
    REFERENCES [dbo].[MailingLists]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RecipientMailingList_MailingList'
CREATE INDEX [IX_FK_RecipientMailingList_MailingList]
ON [dbo].[RecipientMailingList]
    ([MailingLists_Id]);
GO

-- Creating foreign key on [MailingList_Id] in table 'SchedulerTasks'
ALTER TABLE [dbo].[SchedulerTasks]
ADD CONSTRAINT [FK_MailingListSchedulerTask]
    FOREIGN KEY ([MailingList_Id])
    REFERENCES [dbo].[MailingLists]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MailingListSchedulerTask'
CREATE INDEX [IX_FK_MailingListSchedulerTask]
ON [dbo].[SchedulerTasks]
    ([MailingList_Id]);
GO

-- Creating foreign key on [SchedulerTask_Id] in table 'SchedulerTaskEmail'
ALTER TABLE [dbo].[SchedulerTaskEmail]
ADD CONSTRAINT [FK_SchedulerTaskEmail_SchedulerTask]
    FOREIGN KEY ([SchedulerTask_Id])
    REFERENCES [dbo].[SchedulerTasks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Emails_Id] in table 'SchedulerTaskEmail'
ALTER TABLE [dbo].[SchedulerTaskEmail]
ADD CONSTRAINT [FK_SchedulerTaskEmail_Email]
    FOREIGN KEY ([Emails_Id])
    REFERENCES [dbo].[Emails]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SchedulerTaskEmail_Email'
CREATE INDEX [IX_FK_SchedulerTaskEmail_Email]
ON [dbo].[SchedulerTaskEmail]
    ([Emails_Id]);
GO

-- Creating foreign key on [Sender_Id] in table 'SchedulerTasks'
ALTER TABLE [dbo].[SchedulerTasks]
ADD CONSTRAINT [FK_SenderSchedulerTask]
    FOREIGN KEY ([Sender_Id])
    REFERENCES [dbo].[Senders]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SenderSchedulerTask'
CREATE INDEX [IX_FK_SenderSchedulerTask]
ON [dbo].[SchedulerTasks]
    ([Sender_Id]);
GO

-- Creating foreign key on [Server_Id] in table 'SchedulerTasks'
ALTER TABLE [dbo].[SchedulerTasks]
ADD CONSTRAINT [FK_ServerSchedulerTask]
    FOREIGN KEY ([Server_Id])
    REFERENCES [dbo].[Servers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServerSchedulerTask'
CREATE INDEX [IX_FK_ServerSchedulerTask]
ON [dbo].[SchedulerTasks]
    ([Server_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------