
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/28/2015 00:57:05
-- Generated from EDMX file: D:\TEAMPROJECT\Solution_trilbone2014\MyTrees\dbMyTrees.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyTrees];
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

-- Creating table 'edmNodeObjectSet'
CREATE TABLE [dbo].[edmNodeObjectSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ParentNodeID] int  NOT NULL,
    [VirtualFullPath] nvarchar(max)  NULL,
    [ComplexDescription_DescriptionEN] nvarchar(max)  NOT NULL,
    [ComplexDescription_DescriptionRUS] nvarchar(max)  NOT NULL,
    [ComplexDescription_Info] nvarchar(max)  NOT NULL,
    [ComplexDescription_NameEN] nvarchar(max)  NOT NULL,
    [ComplexDescription_NameRUS] nvarchar(max)  NOT NULL,
    [edmVirtualTree_Id] int  NULL,
    [edmOwnUser_Id] int  NULL,
    [edmLinkedNode_Id] int  NULL
);
GO

-- Creating table 'edmLinkSet'
CREATE TABLE [dbo].[edmLinkSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [fromNodeID] int  NOT NULL,
    [toNodeID] int  NOT NULL,
    [edmOwnUser_Id] int  NULL
);
GO

-- Creating table 'edmVirtualTreeSet'
CREATE TABLE [dbo].[edmVirtualTreeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NameEN] nvarchar(100)  NOT NULL,
    [NameRUS] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'edmFileSet'
CREATE TABLE [dbo].[edmFileSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [edmUserID] int  NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'edmNodeImageSet'
CREATE TABLE [dbo].[edmNodeImageSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StorageImageName] nvarchar(100)  NOT NULL,
    [StorageBlockName] nvarchar(100)  NOT NULL,
    [URI] nvarchar(max)  NOT NULL,
    [Caption] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'edmPrivateTreeSet'
CREATE TABLE [dbo].[edmPrivateTreeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [edmFileID] int  NOT NULL,
    [edmVirtualTree_Id] int  NULL
);
GO

-- Creating table 'edmUserSet'
CREATE TABLE [dbo].[edmUserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'edmTagSet'
CREATE TABLE [dbo].[edmTagSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'edmLinkedNodeSet'
CREATE TABLE [dbo].[edmLinkedNodeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PathID] nvarchar(max)  NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'edmNodeImageedmNodeObject'
CREATE TABLE [dbo].[edmNodeImageedmNodeObject] (
    [edmNodeImageList_Id] int  NOT NULL,
    [edmNodeObjectList_Id] int  NOT NULL
);
GO

-- Creating table 'edmVolumeedmNodeObject'
CREATE TABLE [dbo].[edmVolumeedmNodeObject] (
    [edmPrivateTreeList_Id] int  NOT NULL,
    [edmHeadNodeObjectList_Id] int  NOT NULL
);
GO

-- Creating table 'edmUseredmNodeObject'
CREATE TABLE [dbo].[edmUseredmNodeObject] (
    [edmUserList_Id] int  NOT NULL,
    [edmNodeObjectList_Id] int  NOT NULL
);
GO

-- Creating table 'edmNodeObjectedmTag'
CREATE TABLE [dbo].[edmNodeObjectedmTag] (
    [edmNodeObject_Id] int  NOT NULL,
    [edmTag_Id] int  NOT NULL
);
GO

-- Creating table 'edmUseredmLink1'
CREATE TABLE [dbo].[edmUseredmLink1] (
    [edmUserList_Id] int  NOT NULL,
    [edmLinkList_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'edmNodeObjectSet'
ALTER TABLE [dbo].[edmNodeObjectSet]
ADD CONSTRAINT [PK_edmNodeObjectSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'edmLinkSet'
ALTER TABLE [dbo].[edmLinkSet]
ADD CONSTRAINT [PK_edmLinkSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'edmVirtualTreeSet'
ALTER TABLE [dbo].[edmVirtualTreeSet]
ADD CONSTRAINT [PK_edmVirtualTreeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'edmFileSet'
ALTER TABLE [dbo].[edmFileSet]
ADD CONSTRAINT [PK_edmFileSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'edmNodeImageSet'
ALTER TABLE [dbo].[edmNodeImageSet]
ADD CONSTRAINT [PK_edmNodeImageSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'edmPrivateTreeSet'
ALTER TABLE [dbo].[edmPrivateTreeSet]
ADD CONSTRAINT [PK_edmPrivateTreeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'edmUserSet'
ALTER TABLE [dbo].[edmUserSet]
ADD CONSTRAINT [PK_edmUserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'edmTagSet'
ALTER TABLE [dbo].[edmTagSet]
ADD CONSTRAINT [PK_edmTagSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'edmLinkedNodeSet'
ALTER TABLE [dbo].[edmLinkedNodeSet]
ADD CONSTRAINT [PK_edmLinkedNodeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [edmNodeImageList_Id], [edmNodeObjectList_Id] in table 'edmNodeImageedmNodeObject'
ALTER TABLE [dbo].[edmNodeImageedmNodeObject]
ADD CONSTRAINT [PK_edmNodeImageedmNodeObject]
    PRIMARY KEY CLUSTERED ([edmNodeImageList_Id], [edmNodeObjectList_Id] ASC);
GO

-- Creating primary key on [edmPrivateTreeList_Id], [edmHeadNodeObjectList_Id] in table 'edmVolumeedmNodeObject'
ALTER TABLE [dbo].[edmVolumeedmNodeObject]
ADD CONSTRAINT [PK_edmVolumeedmNodeObject]
    PRIMARY KEY CLUSTERED ([edmPrivateTreeList_Id], [edmHeadNodeObjectList_Id] ASC);
GO

-- Creating primary key on [edmUserList_Id], [edmNodeObjectList_Id] in table 'edmUseredmNodeObject'
ALTER TABLE [dbo].[edmUseredmNodeObject]
ADD CONSTRAINT [PK_edmUseredmNodeObject]
    PRIMARY KEY CLUSTERED ([edmUserList_Id], [edmNodeObjectList_Id] ASC);
GO

-- Creating primary key on [edmNodeObject_Id], [edmTag_Id] in table 'edmNodeObjectedmTag'
ALTER TABLE [dbo].[edmNodeObjectedmTag]
ADD CONSTRAINT [PK_edmNodeObjectedmTag]
    PRIMARY KEY CLUSTERED ([edmNodeObject_Id], [edmTag_Id] ASC);
GO

-- Creating primary key on [edmUserList_Id], [edmLinkList_Id] in table 'edmUseredmLink1'
ALTER TABLE [dbo].[edmUseredmLink1]
ADD CONSTRAINT [PK_edmUseredmLink1]
    PRIMARY KEY CLUSTERED ([edmUserList_Id], [edmLinkList_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [edmVirtualTree_Id] in table 'edmNodeObjectSet'
ALTER TABLE [dbo].[edmNodeObjectSet]
ADD CONSTRAINT [FK_edmNodeObjectedmVirtualTrees]
    FOREIGN KEY ([edmVirtualTree_Id])
    REFERENCES [dbo].[edmVirtualTreeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_edmNodeObjectedmVirtualTrees'
CREATE INDEX [IX_FK_edmNodeObjectedmVirtualTrees]
ON [dbo].[edmNodeObjectSet]
    ([edmVirtualTree_Id]);
GO

-- Creating foreign key on [fromNodeID] in table 'edmLinkSet'
ALTER TABLE [dbo].[edmLinkSet]
ADD CONSTRAINT [FK_edmLinkedmNodeObject]
    FOREIGN KEY ([fromNodeID])
    REFERENCES [dbo].[edmNodeObjectSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_edmLinkedmNodeObject'
CREATE INDEX [IX_FK_edmLinkedmNodeObject]
ON [dbo].[edmLinkSet]
    ([fromNodeID]);
GO

-- Creating foreign key on [toNodeID] in table 'edmLinkSet'
ALTER TABLE [dbo].[edmLinkSet]
ADD CONSTRAINT [FK_edmNodeObjectedmLink]
    FOREIGN KEY ([toNodeID])
    REFERENCES [dbo].[edmNodeObjectSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_edmNodeObjectedmLink'
CREATE INDEX [IX_FK_edmNodeObjectedmLink]
ON [dbo].[edmLinkSet]
    ([toNodeID]);
GO

-- Creating foreign key on [edmNodeImageList_Id] in table 'edmNodeImageedmNodeObject'
ALTER TABLE [dbo].[edmNodeImageedmNodeObject]
ADD CONSTRAINT [FK_edmNodeImageedmNodeObject_edmNodeImage]
    FOREIGN KEY ([edmNodeImageList_Id])
    REFERENCES [dbo].[edmNodeImageSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [edmNodeObjectList_Id] in table 'edmNodeImageedmNodeObject'
ALTER TABLE [dbo].[edmNodeImageedmNodeObject]
ADD CONSTRAINT [FK_edmNodeImageedmNodeObject_edmNodeObject]
    FOREIGN KEY ([edmNodeObjectList_Id])
    REFERENCES [dbo].[edmNodeObjectSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_edmNodeImageedmNodeObject_edmNodeObject'
CREATE INDEX [IX_FK_edmNodeImageedmNodeObject_edmNodeObject]
ON [dbo].[edmNodeImageedmNodeObject]
    ([edmNodeObjectList_Id]);
GO

-- Creating foreign key on [edmFileID] in table 'edmPrivateTreeSet'
ALTER TABLE [dbo].[edmPrivateTreeSet]
ADD CONSTRAINT [FK_edmBlockTreeedmVolume]
    FOREIGN KEY ([edmFileID])
    REFERENCES [dbo].[edmFileSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_edmBlockTreeedmVolume'
CREATE INDEX [IX_FK_edmBlockTreeedmVolume]
ON [dbo].[edmPrivateTreeSet]
    ([edmFileID]);
GO

-- Creating foreign key on [edmPrivateTreeList_Id] in table 'edmVolumeedmNodeObject'
ALTER TABLE [dbo].[edmVolumeedmNodeObject]
ADD CONSTRAINT [FK_edmVolumeedmNodeObject_edmVolume]
    FOREIGN KEY ([edmPrivateTreeList_Id])
    REFERENCES [dbo].[edmPrivateTreeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [edmHeadNodeObjectList_Id] in table 'edmVolumeedmNodeObject'
ALTER TABLE [dbo].[edmVolumeedmNodeObject]
ADD CONSTRAINT [FK_edmVolumeedmNodeObject_edmNodeObject]
    FOREIGN KEY ([edmHeadNodeObjectList_Id])
    REFERENCES [dbo].[edmNodeObjectSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_edmVolumeedmNodeObject_edmNodeObject'
CREATE INDEX [IX_FK_edmVolumeedmNodeObject_edmNodeObject]
ON [dbo].[edmVolumeedmNodeObject]
    ([edmHeadNodeObjectList_Id]);
GO

-- Creating foreign key on [edmUserID] in table 'edmFileSet'
ALTER TABLE [dbo].[edmFileSet]
ADD CONSTRAINT [FK_edmUseredmBlockTree]
    FOREIGN KEY ([edmUserID])
    REFERENCES [dbo].[edmUserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_edmUseredmBlockTree'
CREATE INDEX [IX_FK_edmUseredmBlockTree]
ON [dbo].[edmFileSet]
    ([edmUserID]);
GO

-- Creating foreign key on [edmUserList_Id] in table 'edmUseredmNodeObject'
ALTER TABLE [dbo].[edmUseredmNodeObject]
ADD CONSTRAINT [FK_edmUseredmNodeObject_edmUser]
    FOREIGN KEY ([edmUserList_Id])
    REFERENCES [dbo].[edmUserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [edmNodeObjectList_Id] in table 'edmUseredmNodeObject'
ALTER TABLE [dbo].[edmUseredmNodeObject]
ADD CONSTRAINT [FK_edmUseredmNodeObject_edmNodeObject]
    FOREIGN KEY ([edmNodeObjectList_Id])
    REFERENCES [dbo].[edmNodeObjectSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_edmUseredmNodeObject_edmNodeObject'
CREATE INDEX [IX_FK_edmUseredmNodeObject_edmNodeObject]
ON [dbo].[edmUseredmNodeObject]
    ([edmNodeObjectList_Id]);
GO

-- Creating foreign key on [edmNodeObject_Id] in table 'edmNodeObjectedmTag'
ALTER TABLE [dbo].[edmNodeObjectedmTag]
ADD CONSTRAINT [FK_edmNodeObjectedmTag_edmNodeObject]
    FOREIGN KEY ([edmNodeObject_Id])
    REFERENCES [dbo].[edmNodeObjectSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [edmTag_Id] in table 'edmNodeObjectedmTag'
ALTER TABLE [dbo].[edmNodeObjectedmTag]
ADD CONSTRAINT [FK_edmNodeObjectedmTag_edmTag]
    FOREIGN KEY ([edmTag_Id])
    REFERENCES [dbo].[edmTagSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_edmNodeObjectedmTag_edmTag'
CREATE INDEX [IX_FK_edmNodeObjectedmTag_edmTag]
ON [dbo].[edmNodeObjectedmTag]
    ([edmTag_Id]);
GO

-- Creating foreign key on [edmOwnUser_Id] in table 'edmLinkSet'
ALTER TABLE [dbo].[edmLinkSet]
ADD CONSTRAINT [FK_edmUseredmLink]
    FOREIGN KEY ([edmOwnUser_Id])
    REFERENCES [dbo].[edmUserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_edmUseredmLink'
CREATE INDEX [IX_FK_edmUseredmLink]
ON [dbo].[edmLinkSet]
    ([edmOwnUser_Id]);
GO

-- Creating foreign key on [edmVirtualTree_Id] in table 'edmPrivateTreeSet'
ALTER TABLE [dbo].[edmPrivateTreeSet]
ADD CONSTRAINT [FK_edmVirtualTreeedmPrivateTree]
    FOREIGN KEY ([edmVirtualTree_Id])
    REFERENCES [dbo].[edmVirtualTreeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_edmVirtualTreeedmPrivateTree'
CREATE INDEX [IX_FK_edmVirtualTreeedmPrivateTree]
ON [dbo].[edmPrivateTreeSet]
    ([edmVirtualTree_Id]);
GO

-- Creating foreign key on [edmOwnUser_Id] in table 'edmNodeObjectSet'
ALTER TABLE [dbo].[edmNodeObjectSet]
ADD CONSTRAINT [FK_edmOwnerNode]
    FOREIGN KEY ([edmOwnUser_Id])
    REFERENCES [dbo].[edmUserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_edmOwnerNode'
CREATE INDEX [IX_FK_edmOwnerNode]
ON [dbo].[edmNodeObjectSet]
    ([edmOwnUser_Id]);
GO

-- Creating foreign key on [edmUserList_Id] in table 'edmUseredmLink1'
ALTER TABLE [dbo].[edmUseredmLink1]
ADD CONSTRAINT [FK_edmUseredmLink1_edmUser]
    FOREIGN KEY ([edmUserList_Id])
    REFERENCES [dbo].[edmUserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [edmLinkList_Id] in table 'edmUseredmLink1'
ALTER TABLE [dbo].[edmUseredmLink1]
ADD CONSTRAINT [FK_edmUseredmLink1_edmLink]
    FOREIGN KEY ([edmLinkList_Id])
    REFERENCES [dbo].[edmLinkSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_edmUseredmLink1_edmLink'
CREATE INDEX [IX_FK_edmUseredmLink1_edmLink]
ON [dbo].[edmUseredmLink1]
    ([edmLinkList_Id]);
GO

-- Creating foreign key on [edmLinkedNode_Id] in table 'edmNodeObjectSet'
ALTER TABLE [dbo].[edmNodeObjectSet]
ADD CONSTRAINT [FK_edmNodeObjectedmLinkedNode]
    FOREIGN KEY ([edmLinkedNode_Id])
    REFERENCES [dbo].[edmLinkedNodeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_edmNodeObjectedmLinkedNode'
CREATE INDEX [IX_FK_edmNodeObjectedmLinkedNode]
ON [dbo].[edmNodeObjectSet]
    ([edmLinkedNode_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------