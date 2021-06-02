
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/03/2021 00:04:23
-- Generated from EDMX file: C:\Users\Nikola\Documents\Military\Military\Database\Military.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Military];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_SoldierRank]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_Soldier] DROP CONSTRAINT [FK_SoldierRank];
GO
IF OBJECT_ID(N'[dbo].[FK_MedicSpecialty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_Medic] DROP CONSTRAINT [FK_MedicSpecialty];
GO
IF OBJECT_ID(N'[dbo].[FK_EquipmentCamp]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Equipments] DROP CONSTRAINT [FK_EquipmentCamp];
GO
IF OBJECT_ID(N'[dbo].[FK_MilitaryPersonCamp]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_MilitaryPerson] DROP CONSTRAINT [FK_MilitaryPersonCamp];
GO
IF OBJECT_ID(N'[dbo].[FK_SoldierExamination]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Examinations] DROP CONSTRAINT [FK_SoldierExamination];
GO
IF OBJECT_ID(N'[dbo].[FK_ExaminationMedic]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Examinations] DROP CONSTRAINT [FK_ExaminationMedic];
GO
IF OBJECT_ID(N'[dbo].[FK_ExaminationCamp]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Examinations] DROP CONSTRAINT [FK_ExaminationCamp];
GO
IF OBJECT_ID(N'[dbo].[FK_MilitaryPerson_inherits_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_MilitaryPerson] DROP CONSTRAINT [FK_MilitaryPerson_inherits_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_Soldier_inherits_MilitaryPerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_Soldier] DROP CONSTRAINT [FK_Soldier_inherits_MilitaryPerson];
GO
IF OBJECT_ID(N'[dbo].[FK_Medic_inherits_MilitaryPerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_Medic] DROP CONSTRAINT [FK_Medic_inherits_MilitaryPerson];
GO
IF OBJECT_ID(N'[dbo].[FK_SupportPerson_inherits_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_SupportPerson] DROP CONSTRAINT [FK_SupportPerson_inherits_Employee];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[Specialties]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Specialties];
GO
IF OBJECT_ID(N'[dbo].[Camps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Camps];
GO
IF OBJECT_ID(N'[dbo].[Units]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Units];
GO
IF OBJECT_ID(N'[dbo].[Examinations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Examinations];
GO
IF OBJECT_ID(N'[dbo].[Ranks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ranks];
GO
IF OBJECT_ID(N'[dbo].[Equipments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Equipments];
GO
IF OBJECT_ID(N'[dbo].[Employees_MilitaryPerson]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees_MilitaryPerson];
GO
IF OBJECT_ID(N'[dbo].[Employees_Soldier]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees_Soldier];
GO
IF OBJECT_ID(N'[dbo].[Employees_Medic]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees_Medic];
GO
IF OBJECT_ID(N'[dbo].[Employees_SupportPerson]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees_SupportPerson];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [JMBG] nchar(450)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [EmployeeType] int  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'Specialties'
CREATE TABLE [dbo].[Specialties] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Camps'
CREATE TABLE [dbo].[Camps] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'Units'
CREATE TABLE [dbo].[Units] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Examinations'
CREATE TABLE [dbo].[Examinations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateOfExam] datetime  NOT NULL,
    [Soldier_JMBG] nchar(450)  NOT NULL,
    [Medic_JMBG] nchar(450)  NOT NULL,
    [Camp_Id] int  NOT NULL
);
GO

-- Creating table 'Ranks'
CREATE TABLE [dbo].[Ranks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Equipments'
CREATE TABLE [dbo].[Equipments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [CampId] int  NOT NULL
);
GO

-- Creating table 'Employees_MilitaryPerson'
CREATE TABLE [dbo].[Employees_MilitaryPerson] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CampId] int  NOT NULL,
    [Type] int  NOT NULL,
    [JMBG] nchar(450)  NOT NULL
);
GO

-- Creating table 'Employees_Soldier'
CREATE TABLE [dbo].[Employees_Soldier] (
    [RankId] int  NOT NULL,
    [JMBG] nchar(450)  NOT NULL
);
GO

-- Creating table 'Employees_Medic'
CREATE TABLE [dbo].[Employees_Medic] (
    [LicenseNo] nvarchar(max)  NOT NULL,
    [JMBG] nchar(450)  NOT NULL,
    [Specialty_Id] int  NULL
);
GO

-- Creating table 'Employees_SupportPerson'
CREATE TABLE [dbo].[Employees_SupportPerson] (
    [JMBG] nchar(450)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [JMBG] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [Id] in table 'Specialties'
ALTER TABLE [dbo].[Specialties]
ADD CONSTRAINT [PK_Specialties]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Camps'
ALTER TABLE [dbo].[Camps]
ADD CONSTRAINT [PK_Camps]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Units'
ALTER TABLE [dbo].[Units]
ADD CONSTRAINT [PK_Units]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Examinations'
ALTER TABLE [dbo].[Examinations]
ADD CONSTRAINT [PK_Examinations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Ranks'
ALTER TABLE [dbo].[Ranks]
ADD CONSTRAINT [PK_Ranks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Equipments'
ALTER TABLE [dbo].[Equipments]
ADD CONSTRAINT [PK_Equipments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [JMBG] in table 'Employees_MilitaryPerson'
ALTER TABLE [dbo].[Employees_MilitaryPerson]
ADD CONSTRAINT [PK_Employees_MilitaryPerson]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [JMBG] in table 'Employees_Soldier'
ALTER TABLE [dbo].[Employees_Soldier]
ADD CONSTRAINT [PK_Employees_Soldier]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [JMBG] in table 'Employees_Medic'
ALTER TABLE [dbo].[Employees_Medic]
ADD CONSTRAINT [PK_Employees_Medic]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [JMBG] in table 'Employees_SupportPerson'
ALTER TABLE [dbo].[Employees_SupportPerson]
ADD CONSTRAINT [PK_Employees_SupportPerson]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RankId] in table 'Employees_Soldier'
ALTER TABLE [dbo].[Employees_Soldier]
ADD CONSTRAINT [FK_SoldierRank]
    FOREIGN KEY ([RankId])
    REFERENCES [dbo].[Ranks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SoldierRank'
CREATE INDEX [IX_FK_SoldierRank]
ON [dbo].[Employees_Soldier]
    ([RankId]);
GO

-- Creating foreign key on [Specialty_Id] in table 'Employees_Medic'
ALTER TABLE [dbo].[Employees_Medic]
ADD CONSTRAINT [FK_MedicSpecialty]
    FOREIGN KEY ([Specialty_Id])
    REFERENCES [dbo].[Specialties]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MedicSpecialty'
CREATE INDEX [IX_FK_MedicSpecialty]
ON [dbo].[Employees_Medic]
    ([Specialty_Id]);
GO

-- Creating foreign key on [CampId] in table 'Equipments'
ALTER TABLE [dbo].[Equipments]
ADD CONSTRAINT [FK_EquipmentCamp]
    FOREIGN KEY ([CampId])
    REFERENCES [dbo].[Camps]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EquipmentCamp'
CREATE INDEX [IX_FK_EquipmentCamp]
ON [dbo].[Equipments]
    ([CampId]);
GO

-- Creating foreign key on [CampId] in table 'Employees_MilitaryPerson'
ALTER TABLE [dbo].[Employees_MilitaryPerson]
ADD CONSTRAINT [FK_MilitaryPersonCamp]
    FOREIGN KEY ([CampId])
    REFERENCES [dbo].[Camps]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MilitaryPersonCamp'
CREATE INDEX [IX_FK_MilitaryPersonCamp]
ON [dbo].[Employees_MilitaryPerson]
    ([CampId]);
GO

-- Creating foreign key on [Soldier_JMBG] in table 'Examinations'
ALTER TABLE [dbo].[Examinations]
ADD CONSTRAINT [FK_SoldierExamination]
    FOREIGN KEY ([Soldier_JMBG])
    REFERENCES [dbo].[Employees_Soldier]
        ([JMBG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SoldierExamination'
CREATE INDEX [IX_FK_SoldierExamination]
ON [dbo].[Examinations]
    ([Soldier_JMBG]);
GO

-- Creating foreign key on [Medic_JMBG] in table 'Examinations'
ALTER TABLE [dbo].[Examinations]
ADD CONSTRAINT [FK_ExaminationMedic]
    FOREIGN KEY ([Medic_JMBG])
    REFERENCES [dbo].[Employees_Medic]
        ([JMBG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExaminationMedic'
CREATE INDEX [IX_FK_ExaminationMedic]
ON [dbo].[Examinations]
    ([Medic_JMBG]);
GO

-- Creating foreign key on [Camp_Id] in table 'Examinations'
ALTER TABLE [dbo].[Examinations]
ADD CONSTRAINT [FK_ExaminationCamp]
    FOREIGN KEY ([Camp_Id])
    REFERENCES [dbo].[Camps]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExaminationCamp'
CREATE INDEX [IX_FK_ExaminationCamp]
ON [dbo].[Examinations]
    ([Camp_Id]);
GO

-- Creating foreign key on [JMBG] in table 'Employees_MilitaryPerson'
ALTER TABLE [dbo].[Employees_MilitaryPerson]
ADD CONSTRAINT [FK_MilitaryPerson_inherits_Employee]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Employees]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JMBG] in table 'Employees_Soldier'
ALTER TABLE [dbo].[Employees_Soldier]
ADD CONSTRAINT [FK_Soldier_inherits_MilitaryPerson]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Employees_MilitaryPerson]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JMBG] in table 'Employees_Medic'
ALTER TABLE [dbo].[Employees_Medic]
ADD CONSTRAINT [FK_Medic_inherits_MilitaryPerson]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Employees_MilitaryPerson]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JMBG] in table 'Employees_SupportPerson'
ALTER TABLE [dbo].[Employees_SupportPerson]
ADD CONSTRAINT [FK_SupportPerson_inherits_Employee]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Employees]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------