USE [WebsiteBanHang]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 17/01/2025 6:08:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Avatar] [nvarchar](100) NULL,
	[Slug] [varchar](100) NULL,
	[ShowOnHomePage] [bit] NULL,
	[DisplayOrder] [int] NULL,
	[CreatedOnUtc] [datetime] NULL,
	[UpdatedOnUtc] [datetime] NULL,
	[Deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 17/01/2025 6:08:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Avatar] [nchar](100) NULL,
	[Slug] [varchar](100) NULL,
	[ShowOnHomePage] [bit] NULL,
	[DisplayOrder] [int] NULL,
	[Deleted] [bit] NULL,
	[CreatedOnUtc] [datetime] NULL,
	[UpdatedOnUtc] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 17/01/2025 6:08:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[UserId] [int] NULL,
	[Status] [int] NULL,
	[CreatedOnUtc] [datetime] NULL,
 CONSTRAINT [PK__Order__3214EC07C6A3790A] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 17/01/2025 6:08:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[ProductId] [int] NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 17/01/2025 6:08:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Avatar] [nchar](100) NULL,
	[CategoryId] [int] NULL,
	[ShortDes] [nvarchar](100) NULL,
	[FullDescription] [nvarchar](500) NULL,
	[Price] [float] NULL,
	[PriceDiscount] [int] NULL,
	[TypeId] [int] NULL,
	[Slug] [varchar](50) NULL,
	[BrandId] [int] NULL,
	[Deleted] [bit] NULL,
	[ShowOnHomePage] [bit] NULL,
	[DisplayOrder] [int] NULL,
	[CreatedOnUtc] [datetime] NULL,
	[UpdatedOnUtc] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 17/01/2025 6:08:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[IsAdmin] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brand] ON 

INSERT [dbo].[Brand] ([Id], [Name], [Avatar], [Slug], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc], [Deleted]) VALUES (1, N'Apple', N'2023_9_20_638307989548007937_iphone-15-promax-xanh-9_20250110100054.jpg', N'apple', 1, 1, NULL, NULL, 0)
INSERT [dbo].[Brand] ([Id], [Name], [Avatar], [Slug], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc], [Deleted]) VALUES (2, N'Samsung', N'samsung_galaxy_z_flip6_blue_e30111f18f_20250110100122.png', N'samsung', 1, 2, NULL, NULL, 0)
INSERT [dbo].[Brand] ([Id], [Name], [Avatar], [Slug], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc], [Deleted]) VALUES (3, N'Xiaomi', N'2022_12_1_638054842391741479_20250113114357.jpg', N'xiaomi', 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Brand] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [Avatar], [Slug], [ShowOnHomePage], [DisplayOrder], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (1, N'Điện Thoại', N'dien_thoai_thumb_2_e6be721634_20250113112950.png                                                    ', N'dien-thoai', NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[Category] ([Id], [Name], [Avatar], [Slug], [ShowOnHomePage], [DisplayOrder], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (2, N'Máy Tính', N'00909839_dell_vostro_3420_gray_88f0e892df_20250113113154.jpg                                        ', N'may-tinh', NULL, 2, NULL, NULL, NULL)
INSERT [dbo].[Category] ([Id], [Name], [Avatar], [Slug], [ShowOnHomePage], [DisplayOrder], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (3, N'Máy Tính Bảng', N'lenovo_tab_m11_dd_3b32fa284d_20250113113125.jpg                                                     ', N'may-tinh-bang', 1, 3, NULL, NULL, NULL)
INSERT [dbo].[Category] ([Id], [Name], [Avatar], [Slug], [ShowOnHomePage], [DisplayOrder], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (4, N'Phụ Kiện', N'may-choi-game-sony-playstation-5-slim-ps5-slim-1_20250113115816.jpg                                 ', N'phu-kien', NULL, 4, NULL, NULL, NULL)
INSERT [dbo].[Category] ([Id], [Name], [Avatar], [Slug], [ShowOnHomePage], [DisplayOrder], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (5, N'Đồng hồ thông minh', N'donghothongminh.jpg                                                                                 ', N'dong-ho-thong-minh', 1, 5, NULL, NULL, NULL)
INSERT [dbo].[Category] ([Id], [Name], [Avatar], [Slug], [ShowOnHomePage], [DisplayOrder], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (6, N'Đồng hồ thời trang', N'7_20250110101006.jpg                                                                                ', N'dong-ho-thoi-trang', 1, 6, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [Name], [UserId], [Status], [CreatedOnUtc]) VALUES (12, N'DonHang20250104133144', 1, 1, CAST(N'2025-01-04T13:31:44.647' AS DateTime))
INSERT [dbo].[Order] ([Id], [Name], [UserId], [Status], [CreatedOnUtc]) VALUES (13, N'DonHang20250104133157', 1, 1, CAST(N'2025-01-04T13:31:57.050' AS DateTime))
INSERT [dbo].[Order] ([Id], [Name], [UserId], [Status], [CreatedOnUtc]) VALUES (15, N'DonHang20250105004038', 6, 1, CAST(N'2025-01-05T00:40:38.073' AS DateTime))
INSERT [dbo].[Order] ([Id], [Name], [UserId], [Status], [CreatedOnUtc]) VALUES (16, N'DonHang20250108190417', 6, 1, CAST(N'2025-01-08T19:04:17.760' AS DateTime))
INSERT [dbo].[Order] ([Id], [Name], [UserId], [Status], [CreatedOnUtc]) VALUES (17, N'DonHang20250111002358', 6, 1, CAST(N'2025-01-11T00:23:58.070' AS DateTime))
INSERT [dbo].[Order] ([Id], [Name], [UserId], [Status], [CreatedOnUtc]) VALUES (18, N'DonHang20250114192520', 1, 1, CAST(N'2025-01-14T19:25:20.680' AS DateTime))
INSERT [dbo].[Order] ([Id], [Name], [UserId], [Status], [CreatedOnUtc]) VALUES (20, N'DonHang20250114195122', 1, 1, CAST(N'2025-01-14T19:51:22.257' AS DateTime))
INSERT [dbo].[Order] ([Id], [Name], [UserId], [Status], [CreatedOnUtc]) VALUES (21, N'DonHang20250114195209', 1, 1, CAST(N'2025-01-14T19:52:09.263' AS DateTime))
INSERT [dbo].[Order] ([Id], [Name], [UserId], [Status], [CreatedOnUtc]) VALUES (22, N'DonHang20250114195221', 1, 1, CAST(N'2025-01-14T19:52:21.550' AS DateTime))
INSERT [dbo].[Order] ([Id], [Name], [UserId], [Status], [CreatedOnUtc]) VALUES (23, N'DonHang20250114195612', 1, 1, CAST(N'2025-01-14T19:56:12.733' AS DateTime))
INSERT [dbo].[Order] ([Id], [Name], [UserId], [Status], [CreatedOnUtc]) VALUES (24, N'DonHang20250114202012', 1, 1, CAST(N'2025-01-14T20:20:12.953' AS DateTime))
INSERT [dbo].[Order] ([Id], [Name], [UserId], [Status], [CreatedOnUtc]) VALUES (25, N'DonHang20250114202058', 1, 1, CAST(N'2025-01-14T20:20:58.907' AS DateTime))
INSERT [dbo].[Order] ([Id], [Name], [UserId], [Status], [CreatedOnUtc]) VALUES (26, N'DonHang20250114202133', 1, 1, CAST(N'2025-01-14T20:21:33.107' AS DateTime))
INSERT [dbo].[Order] ([Id], [Name], [UserId], [Status], [CreatedOnUtc]) VALUES (27, N'DonHang20250117142600', 1, 1, CAST(N'2025-01-17T14:26:00.033' AS DateTime))
INSERT [dbo].[Order] ([Id], [Name], [UserId], [Status], [CreatedOnUtc]) VALUES (29, N'DonHang20250117180215', 15, 1, CAST(N'2025-01-17T18:02:15.607' AS DateTime))
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (1, 12, 5, 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (2, 13, 6, 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (5, 15, 9, 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (6, 16, 2, 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (7, 17, 6, 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (8, 18, 16, 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (10, 23, 16, 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (11, 24, 13, 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (12, 25, 13, 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (13, 26, 5, 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (14, 27, 4, 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (16, 29, 1, 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (17, 29, 9, 1)
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [Avatar], [CategoryId], [ShortDes], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (1, N'iPhone 15', N'2021_9_15_637673230232103636_iphone-13-mini-do-1_20250113102857.jpg                                 ', 1, N'Điện thoại Apple cao cấp', N'Điện thoại thông minh với chip A17 và camera sắc nét.', 23999760, 10, 1, N'iphone-15', 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Avatar], [CategoryId], [ShortDes], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (2, N'MacBook Pro', N'2022_6_7_637902001346753987_macbook-air-m2-2022-bac-1_20250113104813.jpg                            ', 2, N'Laptop Apple hiệu năng cao', N'Laptop với chip M3 và màn hình Retina.', 47999760, 15, 2, N'macbook-pro', 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Avatar], [CategoryId], [ShortDes], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (3, N'iPad Pro 12.9', N'ipad-pro-11-inch-m4-2024-den_20250113110325.jpg                                                     ', 3, N'Máy tính bảng Apple lớn nhất', N'iPad Pro với chip M2 và màn hình Liquid Retina XDR.', 31199760, 10, 2, N'ipad-pro-129', 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Avatar], [CategoryId], [ShortDes], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (4, N'Apple Watch Series 9', N'apple_watch_series_10_20250113105740.png                                                            ', 5, N'Đồng hồ thông minh Apple', N'Đồng hồ với nhiều tính năng sức khỏe và GPS.', 9599760, 5, 1, N'apple-watch-9', 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Avatar], [CategoryId], [ShortDes], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (5, N'Galaxy S23', N'samsung_galaxy_z_fold6_pink_bec1eeef80_20250113102940.png                                           ', 1, N'Điện thoại Samsung flagship', N'Điện thoại với màn hình AMOLED và camera 108MP.', 21599760, 5, 1, N'galaxy-s23', 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Avatar], [CategoryId], [ShortDes], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (6, N'Galaxy Z Fold 5', N'2023_8_9_638271957052937345_samsung-galaxy-z-flip5-xanh-2_20250113103018.jpg                        ', 1, N'Điện thoại gập Samsung', N'Điện thoại với thiết kế gập và màn hình lớn.', 43199760, 10, 1, N'galaxy-z-fold-5', 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Avatar], [CategoryId], [ShortDes], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (7, N'Galaxy Tab S10', N'samsung_galaxy_tab_s10_plus_xam_1_dcb2180fb0_20250113111148.png                                     ', 3, N'Máy tính bảng Samsung cao cấp', N'Máy tính bảng với màn hình AMOLED và bút S Pen.', 19199760, 10, 2, N'galaxy-tab-s9', 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Avatar], [CategoryId], [ShortDes], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (8, N'Galaxy Watch 6', N'samsung-galaxy-watch6-xam-1_20250113112553.jpg                                                      ', 5, N'Đồng hồ thông minh Samsung', N'Đồng hồ với màn hình Super AMOLED và tính năng theo dõi sức khỏe.', 8399760, 15, 1, N'galaxy-watch-6', 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Avatar], [CategoryId], [ShortDes], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (9, N'Redmi Note 14', N'xiaomi_redmi_note_14_den_4_2f995df92e_20250113104419.png                                            ', 1, N'Điện thoại Xiaomi giá rẻ', N'Điện thoại thông minh với pin 5000mAh và camera 50MP.', 7199760, 5, 1, N'redmi-note-14', 3, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Avatar], [CategoryId], [ShortDes], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (11, N'Mi Pad 6', N'2022_12_1_638054842391741479_20250113110436.jpg                                                     ', 3, N'Máy tính bảng Xiaomi mạnh mẽ', N'Máy tính bảng với chip Snapdragon 870 và màn hình 120Hz.', 11999760, 10, 2, N'mi-pad-6', 3, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Avatar], [CategoryId], [ShortDes], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (12, N'Xiaomi Watch S2', N'2024_3_11_638457734717596034_20250113110201.jpg                                                     ', 5, N'Đồng hồ thông minh Xiaomi', N'Đồng hồ với màn hình AMOLED và theo dõi sức khỏe 24/7.', 4799760, 20, 1, N'xiaomi-watch-s2', 3, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Avatar], [CategoryId], [ShortDes], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (13, N'AirPods Pro', N'2023_9_18_638306555231622845_tai-nghe-airpods-pro-2023-usb-c-trang-3_20250113112020.jpg             ', 4, N'Tai nghe không dây Apple', N'Tai nghe chống ồn chủ động với âm thanh chất lượng cao.', 5999760, 20, 1, N'airpods-pro', 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Avatar], [CategoryId], [ShortDes], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (14, N'Galaxy Buds 2', N'samsung_galaxy_buds_3_silver_51b7138bfa_20250113112126.png                                          ', 4, N'Tai nghe không dây Samsung', N'Tai nghe nhỏ gọn với âm thanh chuẩn studio.', 3599760, 15, 1, N'galaxy-buds-2', 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Avatar], [CategoryId], [ShortDes], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (15, N'Xiaomi Buds 4', N'tai_nghe_bluetooth_20250113112327.jpg                                                               ', 4, N'Tai nghe không dây Xiaomi', N'Tai nghe với thiết kế nhỏ gọn và âm thanh chất lượng.', 2399760, 10, 1, N'xiaomi-buds-4', 3, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Avatar], [CategoryId], [ShortDes], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (16, N'Apple Watch Hermès', N'day-deo-apple-watch-45mm_20250113105842.jpg                                                         ', 6, N'Đồng hồ thời trang cao cấp', N'Phiên bản đặc biệt của Apple Watch kết hợp Hermès.', 31199760, 5, 1, N'apple-watch-hermes', 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Avatar], [CategoryId], [ShortDes], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (17, N'Samsung Watch Elite', N'samsung_galaxy_watch7_20250113110028.png                                                            ', 6, N'Đồng hồ thời trang Samsung', N'Đồng hồ thông minh với thiết kế sang trọng.', 14399760, 10, 1, N'samsung-watch-elite', 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Avatar], [CategoryId], [ShortDes], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (37, N'Iphone 16', N'iphone_16_pro_desert_titan_de8448c1fe.png_20250113103541.png                                        ', 1, N'Vẻ đẹp sang trọng của khung vỏ Titan', N'Gây ấn tượng bởi kiểu dáng thanh lịch, iPhone 16 Pro Max có cấu trúc khung vỏ được chế tác kỳ công từ chất liệu Titan Cấp 5 siêu bền và siêu nhẹ. Ngoài ra, Apple cũng cải tiến cấu trúc tản nhiệt bên trong thân máy để duy trì hiệu suất tốt hơn 20% so với thế hệ cũ, đem đến cho người dùng một thiết bị vừa sang trọng, vừa mạnh mẽ.', 23000000, 2000, 2, N'Iphone-16', 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Avatar], [CategoryId], [ShortDes], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (38, N'Samsung Galaxy S24 ', N'2024_1_15_638409395342231798_samsung-galaxy-s24-ultra-xam-1.png_20250113103936.png                  ', 1, N'Kết nối không giới hạn cùng Galaxy AI', N'Samsung Galaxy S24 Ultra là chiếc điện thoại Galaxy thông minh nhất từ trước đến nay với quyền năng kết nối, quyền năng sáng tạo và quyền năng giải trí đều được hỗ trợ bởi trí tuệ nhân tạo Galaxy AI. Thiết kế hoàn toàn mới từ bộ khung Titan đẳng cấp, siêu camera độ phân giải lên tới 200MP và bộ vi xử lý Snapdragon 8 Gen 3 for Galaxy sẽ mang đến trải nghiệm thú vị chưa từng có dành cho bạn.', 25000000, 100, 1, N'Samsung-Galaxy-S24 ', 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Avatar], [CategoryId], [ShortDes], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (39, N'Samsung Galaxy A06', N'samsung_galaxy_a06_blue_black_1_46d3694f11.png_20250113104650.png                                   ', 1, N'Trải nghiệm màn hình siêu lớn 6.7 inch', N'Galaxy A06 ấn tượng bởi màn hình siêu lớn U-Cut đến 6.7 inch, tấm nền THT và tần số quét 60Hz. Đây là màn hình lớn nhất từ trước đến nay của dòng Galaxy A. Nhờ màn hình này, người dùng có thể tận hưởng không gian giải trí tuyệt đỉnh, từ lướt mạng xã hội FaceBook, TikTok, Threads đến xem phim toàn cảnh, chơi game “cực đã” với không gian rộng rãi, thao tác dễ dàng. Đồng thời, màn hình này cũng phù hợp để học tập với màn hình lớn, tìm kiếm thông tin, học online rõ nét.

', 2890000, 100, 1, N'Samsung-Galaxy-A06', 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Avatar], [CategoryId], [ShortDes], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (40, N'Samsung Galaxy Tab S9', N'samsung-galaxy-tab-s9-xam-ai.jpg_20250113111435.jpg                                                 ', 3, N'Mãn nhãn trong màn hình Dynamic AMOLED 2X sắc nét và chân thực', N'Từng chi tiết được tái hiện một cách rõ ràng và chân thực đáng kinh ngạc trên Galaxy Tab S9 Wifi khi thiết bị được tích hợp tấm nền Dynamic AMOLED 2X hàng đầu. Đây là nâng cấp rất vượt trội khi các thế hệ tiêu chuẩn cũ chỉ dừng lại màn hình LCD. Kết hợp với màn hình rộng 11 inch, cho bạn không gian hiển thị rộng và thao tác thoải mái cho mọi tác vụ từ học tập, làm việc đến giải trí. Chưa dừng lại, sự mượt mà còn được chú trọng với tần số quét 120Hz.', 17490000, 100, 1, N'Samsung-Galaxy-Tab-S9', 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Avatar], [CategoryId], [ShortDes], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (41, N'Samsung Galaxy Tab A9', N'galaxy_tab_a9_wifi_thumb_xam_0d92b21c80.png_20250113111717.png                                      ', 3, N'Màn hình TFT LCD 8.7 inch', N'Đối với mọi thiết bị di động, màn hình là nơi mà người dùng tương tác nhiều nhất. Hiểu được điều đó, Samsung đã trang bị một màn hình TFT LCD 8.7 inch cho Galaxy Tab A9 WiFi. Màn hình này không chỉ lớn về kích thước mà còn sắc nét về chất lượng.', 25000000, 200, 1, N'Samsung-Galaxy-Tab-A9', 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Avatar], [CategoryId], [ShortDes], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (46, N'san pham1', N'2023_8_9_638271957052778853_samsung-galaxy-z-flip5-xanh-4_20250117060242.jpg                        ', 1, N'Vẻ đẹp sang trọng của khung vỏ Titan', N'ẻwewewe', 23000000, 12222, 1, N'san-pham-1', 1, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Password], [IsAdmin]) VALUES (1, N'bui', N'kiem', N'buiduckiem9a4@gmail.com', N'81dc9bdb52d04dc20036dbd8313ed055', NULL)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Password], [IsAdmin]) VALUES (6, N'Bùi', N'Ki?m', N'buiduckiem@gmail.com', N'81dc9bdb52d04dc20036dbd8313ed055', NULL)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Password], [IsAdmin]) VALUES (15, N'duc', N'kiem', N'buiduckiem0467@gmail.com', N'81dc9bdb52d04dc20036dbd8313ed055', NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Product] FOREIGN KEY([UserId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Product]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Brand]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1:Giảm giá sốc, 2: Đề xuất' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'Id'
GO
