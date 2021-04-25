SET IDENTITY_INSERT [dbo].[Customers] ON
INSERT INTO [dbo].[Customers] ([Id], [Name], [BirthDate], [IsSubcribedToNewsLetter], [MembershipTypeId]) VALUES (1, N'Omar EL-Sherif', N'1960-01-07 00:00:00', 1, 2)
INSERT INTO [dbo].[Customers] ([Id], [Name], [BirthDate], [IsSubcribedToNewsLetter], [MembershipTypeId]) VALUES (2, N'will Smith', N'1970-04-09 00:00:00', 0, 1)
INSERT INTO [dbo].[Customers] ([Id], [Name], [BirthDate], [IsSubcribedToNewsLetter], [MembershipTypeId]) VALUES (3, N'Harry', N'1990-05-05 00:00:00', 1, 4)
SET IDENTITY_INSERT [dbo].[Customers] OFF
