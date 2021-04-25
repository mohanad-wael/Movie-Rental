SET IDENTITY_INSERT [dbo].[MembershipTypes] ON
INSERT INTO [dbo].[MembershipTypes] ([Id], [Name], [SingUpFee], [DurationMonths], [DiscountRate]) VALUES (1, N'Pay As You Go', 0, 0, 0)
INSERT INTO [dbo].[MembershipTypes] ([Id], [Name], [SingUpFee], [DurationMonths], [DiscountRate]) VALUES (2, N'Monthly', 30, 1, 10)
INSERT INTO [dbo].[MembershipTypes] ([Id], [Name], [SingUpFee], [DurationMonths], [DiscountRate]) VALUES (3, N'Three Monthes', 90, 3, 15)
INSERT INTO [dbo].[MembershipTypes] ([Id], [Name], [SingUpFee], [DurationMonths], [DiscountRate]) VALUES (4, N'Annualy', 300, 12, 20)
SET IDENTITY_INSERT [dbo].[MembershipTypes] OFF
