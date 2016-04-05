CREATE TABLE [dbo].[Menu] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [menu] TEXT          NULL,
    [name] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


SET IDENTITY_INSERT [dbo].[Menu] ON
INSERT INTO [dbo].[Menu] ([Id], [menu], [name]) VALUES (1, N'[{"name":"Hospitals","link":""},[{"name":"Princess Margaret Cancer Center","link":"test2"},{"name":"Toronto General Hospital","link":"test"},{"name":"Toronto Weston Hospital","link":""},{"name":"Toronto Rehabilitation Institute","link":""},[{"name":"Toronto Rehab - Bickle","link":""},{"name":"Toronto Rehab - Lakeside","link":""},{"name":"Toronto Rehab - Lyndhurst","link":""},{"name":"Toronto Rehab - Rumsey","link":""},{"name":"Toronto Rehab - University","link":""}]],{"name":"Patients&families","link":""},[{"name":"Emergency Departments","link":""},{"name":"Find a Doctor","link":""},{"name":"Health Information","link":""},{"name":"My Visit to UHN","link":""},{"name":"Visiting Patients","link":""},{"name":"Online Booking","link":""},{"name":"Patients & Family Services","link":""}],{"name":"Reaserch","link":""},[{"name":"Our Research Institute","link":""},{"name":"Research Ethics Board","link":""},{"name":"Research Commercialization","link":""},{"name":"Research Trainees","link":""},{"name":"Clinical Research Quality","link":""}],{"name":"Education","link":""},[{"name":"The Michener Institute","link":""},{"name":"Event Services","link":""},{"name":"Observerships","link":""},{"name":"Students","link":""},{"name":"Libraries","link":""},{"name":"International Centre for Education","link":""}],{"name":"About UHN","link":""},[{"name":"Our History","link":""},{"name":"Achieving Our Vision","link":""},{"name":"Quality and Patient Safety","link":""},{"name":"Events Calendar","link":""},{"name":"Fiscal Accountability","link":""},{"name":"General Services","link":""},{"name":"Accessibility at UHN","link":""},{"name":"FAQ","link":""}],{"name":"Contact","link":""}]', N'Main')
SET IDENTITY_INSERT [dbo].[Menu] OFF
