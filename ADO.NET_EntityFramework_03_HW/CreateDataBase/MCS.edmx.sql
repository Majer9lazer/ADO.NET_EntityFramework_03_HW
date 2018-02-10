
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/10/2018 13:50:49
-- Generated from EDMX file: C:\Users\user\Documents\Visual Studio 2017\Projects\ADO.NET_EntityFramework_03_HW\ADO.NET_EntityFramework_03_HW\CreateDataBase\MCS.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MCS_forEntity_03];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ManufacturerEquipment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EquipmentSet] DROP CONSTRAINT [FK_ManufacturerEquipment];
GO
IF OBJECT_ID(N'[dbo].[FK_ModelEquipment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EquipmentSet] DROP CONSTRAINT [FK_ModelEquipment];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ModelSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ModelSet];
GO
IF OBJECT_ID(N'[dbo].[EquipmentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EquipmentSet];
GO
IF OBJECT_ID(N'[dbo].[ManufacturerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ManufacturerSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ModelSet'
CREATE TABLE [dbo].[ModelSet] (
    [ModelId] int IDENTITY(1,1) NOT NULL,
    [strName] nvarchar(10)  NOT NULL,
    [intManufacturerID] int  NULL
);
GO

-- Creating table 'EquipmentSet'
CREATE TABLE [dbo].[EquipmentSet] (
    [intEquipmentId] int IDENTITY(1,1) NOT NULL,
    [intGarageRoom] nvarchar(50)  NULL,
    [strManufYear] nvarchar(50)  NULL,
    [intSNPrefixId] int  NULL,
    [Manufacturer_intManufacturerID] int  NOT NULL,
    [ModelModelId] int  NOT NULL
);
GO

-- Creating table 'ManufacturerSet'
CREATE TABLE [dbo].[ManufacturerSet] (
    [intManufacturerID] int IDENTITY(1,1) NOT NULL,
    [ManufacturerDescription] nvarchar(50)  NULL,
    [strName] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ModelId] in table 'ModelSet'
ALTER TABLE [dbo].[ModelSet]
ADD CONSTRAINT [PK_ModelSet]
    PRIMARY KEY CLUSTERED ([ModelId] ASC);
GO

-- Creating primary key on [intEquipmentId] in table 'EquipmentSet'
ALTER TABLE [dbo].[EquipmentSet]
ADD CONSTRAINT [PK_EquipmentSet]
    PRIMARY KEY CLUSTERED ([intEquipmentId] ASC);
GO

-- Creating primary key on [intManufacturerID] in table 'ManufacturerSet'
ALTER TABLE [dbo].[ManufacturerSet]
ADD CONSTRAINT [PK_ManufacturerSet]
    PRIMARY KEY CLUSTERED ([intManufacturerID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Manufacturer_intManufacturerID] in table 'EquipmentSet'
ALTER TABLE [dbo].[EquipmentSet]
ADD CONSTRAINT [FK_ManufacturerEquipment]
    FOREIGN KEY ([Manufacturer_intManufacturerID])
    REFERENCES [dbo].[ManufacturerSet]
        ([intManufacturerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ManufacturerEquipment'
CREATE INDEX [IX_FK_ManufacturerEquipment]
ON [dbo].[EquipmentSet]
    ([Manufacturer_intManufacturerID]);
GO

-- Creating foreign key on [ModelModelId] in table 'EquipmentSet'
ALTER TABLE [dbo].[EquipmentSet]
ADD CONSTRAINT [FK_ModelEquipment]
    FOREIGN KEY ([ModelModelId])
    REFERENCES [dbo].[ModelSet]
        ([ModelId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ModelEquipment'
CREATE INDEX [IX_FK_ModelEquipment]
ON [dbo].[EquipmentSet]
    ([ModelModelId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------