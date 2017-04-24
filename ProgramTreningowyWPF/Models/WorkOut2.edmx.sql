
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/15/2017 17:02:38
-- Generated from EDMX file: E:\ProgramTreningowyMVVM\ProgramTreningowyWPF\ProgramTreningowyWPF\Models\WorkOut2.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WorkOut2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PersonSetPersonNoTreningDaySet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonNoTreningDaySetSet] DROP CONSTRAINT [FK_PersonSetPersonNoTreningDaySet];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[PersonSetSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonSetSet];
GO
IF OBJECT_ID(N'[dbo].[PersonTreningDaySetSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonTreningDaySetSet];
GO
IF OBJECT_ID(N'[dbo].[PersonPhotoSetSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonPhotoSetSet];
GO
IF OBJECT_ID(N'[dbo].[PersonNoTreningDaySetSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonNoTreningDaySetSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PersonSetSet'
CREATE TABLE [dbo].[PersonSetSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PersonTreningDaySetSet'
CREATE TABLE [dbo].[PersonTreningDaySetSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NULL,
    [Weight] float  NULL,
    [Exercises] nvarchar(max)  NULL,
    [Diet] nvarchar(max)  NULL,
    [Supplementation] nvarchar(max)  NULL,
    [PersonSetId] int  NOT NULL
);
GO

-- Creating table 'PersonPhotoSetSet'
CREATE TABLE [dbo].[PersonPhotoSetSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Photo] varbinary(max)  NULL,
    [PersonTreningDaySetId] int  NOT NULL
);
GO

-- Creating table 'PersonNoTreningDaySetSet'
CREATE TABLE [dbo].[PersonNoTreningDaySetSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NULL,
    [Weight] float  NULL,
    [Diet] nvarchar(max)  NULL,
    [PersonSetId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'PersonSetSet'
ALTER TABLE [dbo].[PersonSetSet]
ADD CONSTRAINT [PK_PersonSetSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonTreningDaySetSet'
ALTER TABLE [dbo].[PersonTreningDaySetSet]
ADD CONSTRAINT [PK_PersonTreningDaySetSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonPhotoSetSet'
ALTER TABLE [dbo].[PersonPhotoSetSet]
ADD CONSTRAINT [PK_PersonPhotoSetSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonNoTreningDaySetSet'
ALTER TABLE [dbo].[PersonNoTreningDaySetSet]
ADD CONSTRAINT [PK_PersonNoTreningDaySetSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PersonSetId] in table 'PersonNoTreningDaySetSet'
ALTER TABLE [dbo].[PersonNoTreningDaySetSet]
ADD CONSTRAINT [FK_PersonSetPersonNoTreningDaySet]
    FOREIGN KEY ([PersonSetId])
    REFERENCES [dbo].[PersonSetSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonSetPersonNoTreningDaySet'
CREATE INDEX [IX_FK_PersonSetPersonNoTreningDaySet]
ON [dbo].[PersonNoTreningDaySetSet]
    ([PersonSetId]);
GO

-- Creating foreign key on [PersonSetId] in table 'PersonTreningDaySetSet'
ALTER TABLE [dbo].[PersonTreningDaySetSet]
ADD CONSTRAINT [FK_PersonSetPersonTreningDaySet]
    FOREIGN KEY ([PersonSetId])
    REFERENCES [dbo].[PersonSetSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonSetPersonTreningDaySet'
CREATE INDEX [IX_FK_PersonSetPersonTreningDaySet]
ON [dbo].[PersonTreningDaySetSet]
    ([PersonSetId]);
GO

-- Creating foreign key on [PersonTreningDaySetId] in table 'PersonPhotoSetSet'
ALTER TABLE [dbo].[PersonPhotoSetSet]
ADD CONSTRAINT [FK_PersonTreningDaySetPersonPhotoSet]
    FOREIGN KEY ([PersonTreningDaySetId])
    REFERENCES [dbo].[PersonTreningDaySetSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonTreningDaySetPersonPhotoSet'
CREATE INDEX [IX_FK_PersonTreningDaySetPersonPhotoSet]
ON [dbo].[PersonPhotoSetSet]
    ([PersonTreningDaySetId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------