USE ISCS

--USERS ROLES BEGIN

IF NOT EXISTS (
	SELECT Id
	FROM AspNetRoles
	WHERE [Name]='Administrator')
BEGIN
	INSERT INTO AspNetRoles(Id, ConcurrencyStamp, [Name], NormalizedName)
	VALUES('7DB6FB85-0749-45BD-B6CB-4C74C22F2F3B', 'DB48E330-2117-436C-A98F-E469018C2FC8', 'Administrator', 'ADMINISTRATOR')
END

IF NOT EXISTS (
	SELECT Id
	FROM AspNetRoles
	WHERE [Name]='Chief Engineer')
BEGIN
	INSERT INTO AspNetRoles(Id, ConcurrencyStamp, [Name], NormalizedName)
	VALUES('2B350646-FE3E-4AC2-8A2B-DFA3C710C25A', '5B26FC63-4F7B-4A94-B5C1-4C4EB1C6F5AF', 'Chief Engineer', 'CHIEF ENGINEER')
END

IF NOT EXISTS (
	SELECT Id
	FROM AspNetRoles
	WHERE [Name]='RA Department')
BEGIN
	INSERT INTO AspNetRoles(Id, ConcurrencyStamp, [Name], NormalizedName)
	VALUES('8AC2FD18-2000-4E04-B6FC-6BC001DF2FD1', '4382CFE4-5F99-4DFD-ACB8-ABC3E59A0CAC', 'RA Department', 'RA DEPARTMENT')
END

--USERS ROLES END

--HAZARDS BEGIN
IF NOT EXISTS (
	SELECT [Id]
	FROM [Hazards]
	WHERE [Name] = 'Cat A Performing Authority presence')
BEGIN
	INSERT INTO [Hazards]([Name], [HazardLevel])
	VALUES ('Cat A Performing Authority presence', 0);
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [Hazards]
	WHERE [Name] = 'Cat B Performing Authority presence')
BEGIN
	INSERT INTO [Hazards]([Name], [HazardLevel])
	VALUES ('Cat B Performing Authority presence',0);
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [Hazards]
	WHERE [Name] = 'Cat C Performing Authority presence')
BEGIN
	INSERT INTO [Hazards]([Name], [HazardLevel])
	VALUES ('Cat C Performing Authority presence',1);
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [Hazards]
	WHERE [Name] = 'Hazard-1')
BEGIN
	INSERT INTO [Hazards]([Name], [HazardLevel])
	VALUES ('Hazard-1',2);
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [Hazards]
	WHERE [Name] = 'Leg Entry')
BEGIN
	INSERT INTO [Hazards]([Name], [HazardLevel])
	VALUES ('Leg Entry',0);
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [Hazards]
	WHERE [Name] = 'Life threatening atmosphere (Confined Space)')
BEGIN
	INSERT INTO [Hazards]([Name], [HazardLevel])
	VALUES ('Life threatening atmosphere (Confined Space)',2);
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [Hazards]
	WHERE [Name] = 'Entry into fin Fan exhaust plenum')
BEGIN
	INSERT INTO [Hazards]([Name], [HazardLevel])
	VALUES ('Entry into fin Fan exhaust plenum',2);
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [Hazards]
	WHERE [Name] = 'Electromagnetic Radiation (Radhaz)')
BEGIN
	INSERT INTO [Hazards]([Name], [HazardLevel])
	VALUES ('Electromagnetic Radiation (Radhaz)',0);
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [Hazards]
	WHERE [Name] = 'Extra Low Voltage (ELV)')
BEGIN
	INSERT INTO [Hazards]([Name], [HazardLevel])
	VALUES ('Extra Low Voltage (ELV)',1);
END
	
IF NOT EXISTS (
	SELECT [Id]
	FROM [Hazards]
	WHERE [Name] = 'High voltage (HV)')
BEGIN
	INSERT INTO [Hazards]([Name], [HazardLevel])
	VALUES ('High voltage (HV)',0);
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [Hazards]
	WHERE [Name] = 'Low voltage (LV)')
BEGIN
	INSERT INTO [Hazards]([Name], [HazardLevel])
	VALUES ('Low voltage (LV)',2);
END


IF NOT EXISTS (
	SELECT [Id]
	FROM [Hazards]
	WHERE [Name] = 'Stored electrical charge')
BEGIN
	INSERT INTO [Hazards]([Name], [HazardLevel])
	VALUES ('Stored electrical charge',1);
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [Hazards]
	WHERE [Name] = 'Failure of small bore pipework')
BEGIN
	INSERT INTO [Hazards]([Name], [HazardLevel])
	VALUES ('Failure of small bore pipework',1);
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [Hazards]
	WHERE [Name] = 'Lifting Equipment Failure')
BEGIN
	INSERT INTO [Hazards]([Name], [HazardLevel])
	VALUES ('Lifting Equipment Failure',1);
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [Hazards]
	WHERE [Name] = 'Low Power Lasers')
BEGIN
	INSERT INTO [Hazards]([Name], [HazardLevel])
	VALUES ('Low Power Lasers',0);
END
	
IF NOT EXISTS (
	SELECT [Id]
	FROM [Hazards]
	WHERE [Name] = 'Movement of HGVs within assets fences')
BEGIN
	INSERT INTO [Hazards]([Name], [HazardLevel])
	VALUES ('Movement of HGVs within assets fences',2);
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [Hazards]
	WHERE [Name] = 'Pressure testing')
BEGIN
	INSERT INTO [Hazards]([Name], [HazardLevel])
	VALUES ('Pressure testing',0);
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [Hazards]
	WHERE [Name] = 'Pressurised gas cylinder failure')
BEGIN
	INSERT INTO [Hazards]([Name], [HazardLevel])
	VALUES ('Pressurised gas cylinder failure',1);
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [Hazards]
	WHERE [Name] = 'Pressurised hose failure')
BEGIN
	INSERT INTO [Hazards]([Name], [HazardLevel])
	VALUES ('Pressurised hose failure',2);
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [Hazards]
	WHERE [Name] = 'Pressurised vessel or system failure')
BEGIN
	INSERT INTO [Hazards]([Name], [HazardLevel])
	VALUES ('Pressurised vessel or system failure',2);
END
--HAZARDS END

--HAZARD CONTROLS BEGIN

-- Begin controls for 'Cat A Performing Authority presence'
IF NOT EXISTS (
	SELECT [Id]
	FROM [HazardControls] 
	WHERE [Name] = 'Continuous attendance of a Performing authority. Work to stop when no PA present.')
BEGIN
	INSERT INTO [HazardControls]([Name], [HazardId])
	VALUES ('Continuous attendance of a Performing authority. Work to stop when no PA present.',
	(SELECT [Id] FROM [Hazards] WHERE [Name]='Cat A Performing Authority presence'));
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [HazardControls] 
	WHERE [Name] = 'Red barriers and signs are to be erected. Barriers to be removed as soon as possible to do so.')
BEGIN
	INSERT INTO [HazardControls]([Name], [HazardId])
	VALUES ('Red barriers and signs are to be erected. Barriers to be removed as soon as possible to do so.',
	(SELECT [Id] FROM [Hazards] WHERE [Name]='Cat A Performing Authority presence'));
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [HazardControls] 
	WHERE [Name] = 'Yellow barriers and signs are to be erected. Barriers to be removed as soon as possible to do so.')
BEGIN
	INSERT INTO [HazardControls]([Name], [HazardId])
	VALUES ('Yellow barriers and signs are to be erected. Barriers to be removed as soon as possible to do so.',
	(SELECT [Id] FROM [Hazards] WHERE [Name]='Cat A Performing Authority presence'));
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [HazardControls] 
	WHERE [Name] = 'Hearing protection is provided. Earpluggs and earmuffs (disposable and custom moulded) are used. First action level 80 dB(A), second action level 85dB')
BEGIN
	INSERT INTO [HazardControls]([Name], [HazardId])
	VALUES ('Hearing protection is provided. Earpluggs and earmuffs (disposable and custom moulded) are used. First action level 80 dB(A), second action level 85dB',
	(SELECT [Id] FROM [Hazards] WHERE [Name]='Cat A Performing Authority presence'));
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [HazardControls] 
	WHERE [Name] = 'Area delegate must sign paper copy of permit before work starts or countersign its electronically.')
BEGIN
	INSERT INTO [HazardControls]([Name], [HazardId])
	VALUES ('Area delegate must sign paper copy of permit before work starts or countersign its electronically.',
	(SELECT [Id] FROM [Hazards] WHERE [Name]='Cat A Performing Authority presence'));
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [HazardControls] 
	WHERE [Name] = 'GAS TEST REQUIRED BEFORE WORK COMMENCES')
BEGIN
	INSERT INTO [HazardControls]([Name], [HazardId])
	VALUES ('GAS TEST REQUIRED BEFORE WORK COMMENCES',
	(SELECT [Id] FROM [Hazards] WHERE [Name]='Cat A Performing Authority presence'));
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [HazardControls] 
	WHERE [Name] = 'CONSTANT GAS MONITORING WITH PORTABLE DETECTOR')
BEGIN
	INSERT INTO [HazardControls]([Name], [HazardId])
	VALUES ('CONSTANT GAS MONITORING WITH PORTABLE DETECTOR',
	(SELECT [Id] FROM [Hazards] WHERE [Name]='Cat A Performing Authority presence'));
END
-- End controls for 'Cat A Performing Authority presence'

-- Begin controls for 'Cat B Performing Authority presence'
IF NOT EXISTS (
	SELECT [Id]
	FROM [HazardControls] 
	WHERE [Name] = 'PA cannot be responsible for more than one CAT B unless the other tasks are in close proximity to the first one and PA can safely supervise all')
BEGIN
	INSERT INTO [HazardControls]([Name], [HazardId])
	VALUES ('PA cannot be responsible for more than one CAT B unless the other tasks are in close proximity to the first one and PA can safely supervise all',
	(SELECT [Id] FROM [Hazards] WHERE [Name]='Cat B Performing Authority presence'));
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [HazardControls] 
	WHERE [Name] = 'Work may continue during short absences of the PA. PA cannot be responsible for more than 1 CAT B task.')
BEGIN
	INSERT INTO [HazardControls]([Name], [HazardId])
	VALUES ('Work may continue during short absences of the PA. PA cannot be responsible for more than 1 CAT B task.',
	(SELECT [Id] FROM [Hazards] WHERE [Name]='Cat B Performing Authority presence'));
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [HazardControls] 
	WHERE [Name] = 'PA to ensure that the No. of Cat C permits accepted, in close proximity to CAT B, (if also responsible for Cat B permit), does not compromise safety.')
BEGIN
	INSERT INTO [HazardControls]([Name], [HazardId])
	VALUES ('PA to ensure that the No. of Cat C permits accepted, in close proximity to CAT B, (if also responsible for Cat B permit), does not compromise safety.',
	(SELECT [Id] FROM [Hazards] WHERE [Name]='Cat B Performing Authority presence'));
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [HazardControls] 
	WHERE [Name] = '')
BEGIN
	INSERT INTO [HazardControls]([Name], [HazardId])
	VALUES ('',
	(SELECT [Id] FROM [Hazards] WHERE [Name]='Cat B Performing Authority presence'));
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [HazardControls] 
	WHERE [Name] = 'Red barriers and signs are to be erected. Barriers to be removed as soon as possible to do so.')
BEGIN
	INSERT INTO [HazardControls]([Name], [HazardId])
	VALUES ('Red barriers and signs are to be erected. Barriers to be removed as soon as possible to do so.',
	(SELECT [Id] FROM [Hazards] WHERE [Name]='Cat B Performing Authority presence'));
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [HazardControls] 
	WHERE [Name] = 'Yellow barriers and signs are to be erected. Barriers to be removed as soon as possible to do so.')
BEGIN
	INSERT INTO [HazardControls]([Name], [HazardId])
	VALUES ('Yellow barriers and signs are to be erected. Barriers to be removed as soon as possible to do so.',
	(SELECT [Id] FROM [Hazards] WHERE [Name]='Cat B Performing Authority presence'));
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [HazardControls] 
	WHERE [Name] = 'Hearing protection is provided. Earpluggs and earmuffs (disposable and custom moulded) are used. First action level 80 dB(A), second action level 85dB')
BEGIN
	INSERT INTO [HazardControls]([Name], [HazardId])
	VALUES ('Hearing protection is provided. Earpluggs and earmuffs (disposable and custom moulded) are used. First action level 80 dB(A), second action level 85dB',
	(SELECT [Id] FROM [Hazards] WHERE [Name]='Cat B Performing Authority presence'));
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [HazardControls] 
	WHERE [Name] = 'Area delegate must sign paper copy of permit before work starts or countersign its electronically.')
BEGIN
	INSERT INTO [HazardControls]([Name], [HazardId])
	VALUES ('Area delegate must sign paper copy of permit before work starts or countersign its electronically.',
	(SELECT [Id] FROM [Hazards] WHERE [Name]='Cat B Performing Authority presence'));
END

IF NOT EXISTS (
	SELECT [Id]
	FROM [HazardControls] 
	WHERE [Name] = 'GAS TEST REQUIRED BEFORE WORK COMMENCES')
BEGIN
	INSERT INTO [HazardControls]([Name], [HazardId])
	VALUES ('GAS TEST REQUIRED BEFORE WORK COMMENCES',
	(SELECT [Id] FROM [Hazards] WHERE [Name]='Cat B Performing Authority presence'));
END
-- End controls for 'Cat B Performing Authority presence'

--HAZARD CONTROLS END 

--AREAS BEGIN
IF NOT EXISTS(
	SELECT [Id]
	FROM [Areas]
	WHERE [Name]='Area - 1')
BEGIN
	INSERT INTO Areas([Name], Coords) 
	VALUES('Area - 1', '105,214,65,237,40,220,334,49,409,94,118,266,103,256,139,233')
END

IF NOT EXISTS(
	SELECT [Id]
	FROM [Areas]
	WHERE [Name]='Area - 2')
BEGIN
	INSERT INTO Areas([Name], Coords)
	VALUES('Area - 2', '411,94,335,48,404,8,482,54')
END

IF NOT EXISTS(
	SELECT [Id]
	FROM [Areas]
	WHERE [Name]='Area - 3')
BEGIN
	INSERT INTO Areas([Name], Coords)
	VALUES('Area - 3', '419,186,562,100,484,55,337,138')
END

IF NOT EXISTS(
	SELECT [Id]
	FROM [Areas]
	WHERE [Name]='Area - 4')
BEGIN
	INSERT INTO Areas([Name], Coords)
	VALUES('Area - 4', '383,204,197,313,301,372,381,394,472,382,572,343,559,295,532,266,485,225,467,213,431,233')
END
--AREAS END


insert into Equipments([Name], [Description], AreaId) values('1 Equipment', 'desc 1', 1)
insert into Equipments([Name], [Description], AreaId) values('2 Equipment', 'desc 2', 1)
insert into Equipments([Name], [Description], AreaId) values('3 Equipment', 'desc 3', 1)
insert into Equipments([Name], [Description], AreaId) values('4 Equipment', 'desc 4', 2)
insert into Equipments([Name], [Description], AreaId) values('5 Equipment', 'desc 5', 2)
insert into Equipments([Name], [Description], AreaId) values('6 Equipment', 'desc 6', 2)
insert into Equipments([Name], [Description], AreaId) values('7 Equipment', 'desc 7', 3)
insert into Equipments([Name], [Description], AreaId) values('8 Equipment', 'desc 8', 3)
insert into Equipments([Name], [Description], AreaId) values('9 Equipment', 'desc 9', 4)
insert into Equipments([Name], [Description], AreaId) values('10 Equipment', 'desc 10', 4)
insert into Equipments([Name], [Description], AreaId) values('11 Equipment', 'desc 11', 4)
insert into Equipments([Name], [Description], AreaId) values('12 Equipment', 'desc 12', 4)

INSERT INTO Works([Description], [Name]) VALUES('Description-1', 'Work - 1')
INSERT INTO Works([Description], [Name]) VALUES('Description-2', 'Work - 2')
INSERT INTO Works([Description], [Name]) VALUES('Description-3', 'Work - 3')
INSERT INTO Works([Description], [Name]) VALUES('Description-4', 'Work - 4')
INSERT INTO Works([Description], [Name]) VALUES('Description-5', 'Work - 5')

insert into Operations values('Description')
insert into Operations values('Description-1')
insert into Operations values('Description-2')
insert into Operations values('Description-3')
insert into Operations values('Description-4')
insert into Operations values('Description-5')
insert into Operations values('Description-6')
insert into Operations values('Description-7')
insert into Operations values('Description-8')
insert into Operations values('Description-9')
insert into Operations values('Description-10')
insert into Operations values('Description-11')
insert into Operations values('Description-12')
insert into Operations values('Description-13')
insert into Operations values('Description-14')
insert into Operations values('Description-15')

insert into EquipmentOperations values(1,1)
insert into EquipmentOperations values(1,2)
insert into EquipmentOperations values(1,3)
insert into EquipmentOperations values(2,4)
insert into EquipmentOperations values(2,5)
insert into EquipmentOperations values(3,1)
insert into EquipmentOperations values(3,2)
insert into EquipmentOperations values(4,5)
insert into EquipmentOperations values(5,6)
insert into EquipmentOperations values(5,7)
insert into EquipmentOperations values(5,8)
insert into EquipmentOperations values(6,9)
insert into EquipmentOperations values(6,10)
insert into EquipmentOperations values(6,11)
insert into EquipmentOperations values(7,9)
insert into EquipmentOperations values(7,10)
insert into EquipmentOperations values(8,15)
insert into EquipmentOperations values(8,16)
insert into EquipmentOperations values(9,16)
insert into EquipmentOperations values(10,17)