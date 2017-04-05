
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/20/2013 21:25:40
-- Generated from EDMX file: H:\TEAMPROGECTS\Solution_trilbone_base\SampleList\ModelSampleList.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [LISTS];
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

-- Creating table 'SampleListCollection'
CREATE TABLE [dbo].[SampleListCollection] (
    [IDList] int IDENTITY(1,1) NOT NULL,
    [ListName] nvarchar(40)  NOT NULL,
    [IDListLine] int  NULL,
    [IDListType] int  NULL,
    [IsActiveFlag] bit  NOT NULL,
    [OpenDate] datetime  NOT NULL,
    [CloseDate] datetime  NULL
);
GO

-- Creating table 'ListLineCollection'
CREATE TABLE [dbo].[ListLineCollection] (
    [IDListLine] int IDENTITY(1,1) NOT NULL,
    [ListLineName] nvarchar(max)  NOT NULL,
    [IsActiveFlag] bit  NOT NULL
);
GO

-- Creating table 'ListTypeCollection'
CREATE TABLE [dbo].[ListTypeCollection] (
    [IDListType] int IDENTITY(1,1) NOT NULL,
    [ListTypeName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SampleInListCollection'
CREATE TABLE [dbo].[SampleInListCollection] (
    [IDSample] int IDENTITY(1,1) NOT NULL,
    [SampleNumber] nvarchar(max)  NULL,
    [IsLockedFlag] bit  NOT NULL
);
GO

-- Creating table 'SampleParameterCollection'
CREATE TABLE [dbo].[SampleParameterCollection] (
    [IDSParameter] int IDENTITY(1,1) NOT NULL,
    [ParameterName] nvarchar(max)  NOT NULL,
    [ParameterValue] nvarchar(max)  NOT NULL,
    [ParameterType] nvarchar(max)  NULL,
    [ParameterNETtype] nvarchar(max)  NOT NULL,
    [IDSample] int  NOT NULL
);
GO

-- Creating table 'SampleListParameterCollection'
CREATE TABLE [dbo].[SampleListParameterCollection] (
    [IDLParameter] int IDENTITY(1,1) NOT NULL,
    [ParameterName] nvarchar(max)  NOT NULL,
    [ParameterValue] nvarchar(max)  NOT NULL,
    [ParameterType] nvarchar(max)  NULL,
    [ParameterNETtype] nvarchar(max)  NOT NULL,
    [IDList] int  NOT NULL
);
GO

-- Creating table 'SampleAndListCollection'
CREATE TABLE [dbo].[SampleAndListCollection] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IDSample] int  NOT NULL,
    [IDList] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IDList] in table 'SampleListCollection'
ALTER TABLE [dbo].[SampleListCollection]
ADD CONSTRAINT [PK_SampleListCollection]
    PRIMARY KEY CLUSTERED ([IDList] ASC);
GO

-- Creating primary key on [IDListLine] in table 'ListLineCollection'
ALTER TABLE [dbo].[ListLineCollection]
ADD CONSTRAINT [PK_ListLineCollection]
    PRIMARY KEY CLUSTERED ([IDListLine] ASC);
GO

-- Creating primary key on [IDListType] in table 'ListTypeCollection'
ALTER TABLE [dbo].[ListTypeCollection]
ADD CONSTRAINT [PK_ListTypeCollection]
    PRIMARY KEY CLUSTERED ([IDListType] ASC);
GO

-- Creating primary key on [IDSample] in table 'SampleInListCollection'
ALTER TABLE [dbo].[SampleInListCollection]
ADD CONSTRAINT [PK_SampleInListCollection]
    PRIMARY KEY CLUSTERED ([IDSample] ASC);
GO

-- Creating primary key on [IDSParameter] in table 'SampleParameterCollection'
ALTER TABLE [dbo].[SampleParameterCollection]
ADD CONSTRAINT [PK_SampleParameterCollection]
    PRIMARY KEY CLUSTERED ([IDSParameter] ASC);
GO

-- Creating primary key on [IDLParameter] in table 'SampleListParameterCollection'
ALTER TABLE [dbo].[SampleListParameterCollection]
ADD CONSTRAINT [PK_SampleListParameterCollection]
    PRIMARY KEY CLUSTERED ([IDLParameter] ASC);
GO

-- Creating primary key on [ID] in table 'SampleAndListCollection'
ALTER TABLE [dbo].[SampleAndListCollection]
ADD CONSTRAINT [PK_SampleAndListCollection]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IDListLine] in table 'SampleListCollection'
ALTER TABLE [dbo].[SampleListCollection]
ADD CONSTRAINT [FK_ListLineSampleList]
    FOREIGN KEY ([IDListLine])
    REFERENCES [dbo].[ListLineCollection]
        ([IDListLine])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ListLineSampleList'
CREATE INDEX [IX_FK_ListLineSampleList]
ON [dbo].[SampleListCollection]
    ([IDListLine]);
GO

-- Creating foreign key on [IDListType] in table 'SampleListCollection'
ALTER TABLE [dbo].[SampleListCollection]
ADD CONSTRAINT [FK_ListTypeSampleList]
    FOREIGN KEY ([IDListType])
    REFERENCES [dbo].[ListTypeCollection]
        ([IDListType])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ListTypeSampleList'
CREATE INDEX [IX_FK_ListTypeSampleList]
ON [dbo].[SampleListCollection]
    ([IDListType]);
GO

-- Creating foreign key on [IDSample] in table 'SampleParameterCollection'
ALTER TABLE [dbo].[SampleParameterCollection]
ADD CONSTRAINT [FK_SampleInListSampleParameter]
    FOREIGN KEY ([IDSample])
    REFERENCES [dbo].[SampleInListCollection]
        ([IDSample])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SampleInListSampleParameter'
CREATE INDEX [IX_FK_SampleInListSampleParameter]
ON [dbo].[SampleParameterCollection]
    ([IDSample]);
GO

-- Creating foreign key on [IDList] in table 'SampleListParameterCollection'
ALTER TABLE [dbo].[SampleListParameterCollection]
ADD CONSTRAINT [FK_SampleListSampleListParameter]
    FOREIGN KEY ([IDList])
    REFERENCES [dbo].[SampleListCollection]
        ([IDList])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SampleListSampleListParameter'
CREATE INDEX [IX_FK_SampleListSampleListParameter]
ON [dbo].[SampleListParameterCollection]
    ([IDList]);
GO

-- Creating foreign key on [IDSample] in table 'SampleAndListCollection'
ALTER TABLE [dbo].[SampleAndListCollection]
ADD CONSTRAINT [FK_SampleInListSampleAndList]
    FOREIGN KEY ([IDSample])
    REFERENCES [dbo].[SampleInListCollection]
        ([IDSample])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SampleInListSampleAndList'
CREATE INDEX [IX_FK_SampleInListSampleAndList]
ON [dbo].[SampleAndListCollection]
    ([IDSample]);
GO

-- Creating foreign key on [IDList] in table 'SampleAndListCollection'
ALTER TABLE [dbo].[SampleAndListCollection]
ADD CONSTRAINT [FK_SampleListSampleAndList]
    FOREIGN KEY ([IDList])
    REFERENCES [dbo].[SampleListCollection]
        ([IDList])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SampleListSampleAndList'
CREATE INDEX [IX_FK_SampleListSampleAndList]
ON [dbo].[SampleAndListCollection]
    ([IDList]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------