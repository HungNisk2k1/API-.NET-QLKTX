--Create database QuanLyKTX
USE [QuanLyKTX]
GO
/****** Object:  Table [dbo].[Phong]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phong](
	[id_Phong] [int] IDENTITY(1,1) NOT NULL,
	[Phong] [nchar](20) NULL,
	[GiaPhong] [nchar](20) NULL,
	[TrangThai] [nchar](10) NULL,
 CONSTRAINT [PK_Phong] PRIMARY KEY CLUSTERED 
(
	[id_Phong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON  ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QLCP]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QLCP](
	[id_QLCP] [int] IDENTITY(1,1) NOT NULL,
	[MaSV] [int] NOT NULL,
	[NgayDK] [nchar](10) NULL,
	[NgayNop] [nchar](10) NULL,
	[TrangThai] [nchar](10) NULL,
 CONSTRAINT [PK_QLCP] PRIMARY KEY CLUSTERED 
(
	[id_QLCP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON  ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QLGX]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QLGX](
	[id_GX] [int] IDENTITY(1,1) NOT NULL,
	[MaSV] [int] NOT NULL,
	[LoaiXe] [nchar](20) NULL,
	[Bien] [nchar](10) NULL,
 CONSTRAINT [PK_QLGX] PRIMARY KEY CLUSTERED 
(
	[id_GX] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SV]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SV](
	[id_SV] [int] IDENTITY(1,1) NOT NULL,
	[MaSV] [int] NOT NULL,
	[HoTenSV] [nchar](50) NULL,
	[NgaySinh] [nchar](10) NULL,
	[DiaChi] [nchar](100) NULL,
	[id_Phong] [int] NOT NULL,
	[SDT] [nchar](12) NULL,
 CONSTRAINT [PK_SV] PRIMARY KEY CLUSTERED 
(
	[MaSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON  ) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Phong] ON 
GO
INSERT [dbo].[Phong] ([id_Phong], [Phong], [GiaPhong], [TrangThai]) VALUES (1, N'Phòng 1             ', N'1.700.000           ', N'4/8       ')
GO
INSERT [dbo].[Phong] ([id_Phong], [Phong], [GiaPhong], [TrangThai]) VALUES (2, N'Phòng 2             ', N'1.000.000           ', N'4/9       ')
GO
SET IDENTITY_INSERT [dbo].[Phong] OFF
GO
SET IDENTITY_INSERT [dbo].[QLCP] ON 
GO
INSERT [dbo].[QLCP] ([id_QLCP], [MaSV], [NgayDK], [NgayNop], [TrangThai]) VALUES (1, 2000170, N'20/3/2023 ', N'20/3      ', N'Nợ        ')
GO
INSERT [dbo].[QLCP] ([id_QLCP], [MaSV], [NgayDK], [NgayNop], [TrangThai]) VALUES (2, 2000171, N'20/3/2023 ', N'20/3      ', N'Nợ        ')
GO
SET IDENTITY_INSERT [dbo].[QLCP] OFF
GO
SET IDENTITY_INSERT [dbo].[QLGX] ON 
GO
INSERT [dbo].[QLGX] ([id_GX], [MaSV], [LoaiXe], [Bien]) VALUES (5, 2000171, N'string              ', N'string    ')
GO
SET IDENTITY_INSERT [dbo].[QLGX] OFF
GO
SET IDENTITY_INSERT [dbo].[SV] ON 
GO
INSERT [dbo].[SV] ([id_SV], [MaSV], [HoTenSV], [NgaySinh], [DiaChi], [id_Phong], [SDT]) VALUES (1, 2000170, N'Đặng Thị Trà My                                   ', N'27/05/2002', N'Lạng Sơn                                                                                            ', 2, N'0378850383  ')
GO
INSERT [dbo].[SV] ([id_SV], [MaSV], [HoTenSV], [NgaySinh], [DiaChi], [id_Phong], [SDT]) VALUES (3, 2000171, N'a                                                 ', N'a         ', N'a                                                                                                   ', 1, N'0123456789  ')
GO
INSERT [dbo].[SV] ([id_SV], [MaSV], [HoTenSV], [NgaySinh], [DiaChi], [id_Phong], [SDT]) VALUES (4, 2000172, N'b                                                 ', N'b         ', N'b                                                                                                   ', 1, N'0234567891  ')
GO
SET IDENTITY_INSERT [dbo].[SV] OFF
GO
ALTER TABLE [dbo].[QLCP]  WITH CHECK ADD  CONSTRAINT [FK_QLCP_SV] FOREIGN KEY([MaSV])
REFERENCES [dbo].[SV] ([MaSV])
GO
ALTER TABLE [dbo].[QLCP] CHECK CONSTRAINT [FK_QLCP_SV]
GO
ALTER TABLE [dbo].[QLGX]  WITH CHECK ADD  CONSTRAINT [FK_QLGX_SV1] FOREIGN KEY([MaSV])
REFERENCES [dbo].[SV] ([MaSV])
GO
ALTER TABLE [dbo].[QLGX] CHECK CONSTRAINT [FK_QLGX_SV1]
GO
ALTER TABLE [dbo].[SV]  WITH CHECK ADD  CONSTRAINT [FK_SV_Phong] FOREIGN KEY([id_Phong])
REFERENCES [dbo].[Phong] ([id_Phong])
GO
ALTER TABLE [dbo].[SV] CHECK CONSTRAINT [FK_SV_Phong]
GO
/****** Object:  StoredProcedure [dbo].[DM_ChiTietGuiXe]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[DM_ChiTietGuiXe]
	@MaSV int
AS
BEGIN
	--select * from  dbo.QLGX where MaSV=@MaSV
		SELECT a.id_GX,a.MaSV,a.LoaiXe,a.Bien FROM QLGX as a
		INNER JOIN SV as b ON b.MaSV=a.MaSV WHERE a.MaSV = @MaSV order by LoaiXe asc
	
END
GO
/****** Object:  StoredProcedure [dbo].[DM_ChiTietPhong]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[DM_ChiTietPhong]
	@id_Phong int
AS
BEGIN
	select * from dbo.Phong where id_Phong=@id_Phong
		
END

GO
/****** Object:  StoredProcedure [dbo].[DM_ChiTietQLChiPhi]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[DM_ChiTietQLChiPhi]
	@MaSV int
AS
BEGIN
	--select * from  dbo.QLCP where MaSV=@MaSV
		SELECT *from QLCP WHERE MaSV = @MaSV 
END
GO
/****** Object:  StoredProcedure [dbo].[DM_ChiTietSinhVien]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DM_ChiTietSinhVien]
	@MaSV int
	--@id_SV int
AS
BEGIN
	SELECT a.id_SV,a.MaSV,a.HoTenSV,a.NgaySinh,a.DiaChi,b.Phong,a.SDT FROM SV as a
	--INNER JOIN Phong as b ON b.id_Phong=a.id_Phong WHERE id_SV = @id_SV order by HoTenSV asc
	INNER JOIN Phong as b ON b.id_Phong=a.id_Phong WHERE MaSV = @MaSV order by HoTenSV asc
		
END




GO
/****** Object:  StoredProcedure [dbo].[DM_DeleteGuiXe]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DM_DeleteGuiXe]
	@MaSV int

AS
BEGIN
	
	delete  dbo.QLGX WHERE MaSV=@MaSV
		
END

GO
/****** Object:  StoredProcedure [dbo].[DM_DeletePhong]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DM_DeletePhong]
	@id_Phong int
AS
BEGIN
	delete  dbo.Phong WHERE id_Phong=@id_Phong
		
END

GO
/****** Object:  StoredProcedure [dbo].[DM_DeleteQLChiPhi]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DM_DeleteQLChiPhi]
	@MaSV int

AS
BEGIN
	
	delete  dbo.QLCP WHERE MaSV=@MaSV
		
END

GO
/****** Object:  StoredProcedure [dbo].[DM_DeleteSinhVien]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DM_DeleteSinhVien]
	--@id_SV int
	@MaSV int

AS
BEGIN
	--delete  dbo.SV WHERE id_SV=@id_SV
	delete  dbo.SV WHERE MaSV=@MaSV
		
END




GO
/****** Object:  StoredProcedure [dbo].[DM_EditGuiXe]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DM_EditGuiXe]
	@id_GX int,
	@MaSV int,
	@LoaiXe nvarchar(200),
	@Bien nvarchar(10)
AS
BEGIN
	UPDATE   dbo.QLGX
		set MaSV=@MaSV,
			LoaiXe=@LoaiXe,
			Bien=@Bien
		WHERE MaSV=@MaSV;
		
END

GO
/****** Object:  StoredProcedure [dbo].[DM_EditPhong]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DM_EditPhong]
	@id_Phong int,
	@Phong varchar(50),
	@GiaPhong nvarchar(200),
	@TrangThai varchar(50)
AS
BEGIN
	UPDATE  dbo.Phong
		set Phong=@Phong,
			GiaPhong=@GiaPhong,
			TrangThai=@TrangThai
		WHERE id_Phong=@id_Phong;
		
END

GO
/****** Object:  StoredProcedure [dbo].[DM_EditQLChiPhi]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DM_EditQLChiPhi]
	@id_QLCP int,
	@MaSV int,
	@NgayDK nvarchar(10),
	@NgayNop nvarchar(10),
	@TrangThai nvarchar(10)
AS
BEGIN
	UPDATE   dbo.QLCP
		set MaSV=@MaSV,
			NgayDK=@NgayDK,
			NgayNop=@NgayNop,
			TrangThai=@TrangThai
		WHERE MaSV=@MaSV;
		
END

GO
/****** Object:  StoredProcedure [dbo].[DM_EditSinhVien]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DM_EditSinhVien]
	@id_SV int,
	@MaSV int,
	@HoTenSV nvarchar(200),
	@NgaySinh nvarchar(200),
	@DiaChi nvarchar(200),
	@id_Phong int,
	@SDT nvarchar(200)
AS
BEGIN
	UPDATE  dbo.SV
		set MaSV=@MaSV,
			HoTenSV=@HoTenSV,
			NgaySinh=@NgaySinh,
			DiaChi=@DiaChi,
			id_Phong=@id_Phong,
			SDT=@SDT
		--WHERE id_SV=@id_SV;
		WHERE MaSV=@MaSV;
		
END




GO
/****** Object:  StoredProcedure [dbo].[DM_KTGuiXe]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DM_KTGuiXe]
	@Keyword nvarchar(20),
	@Type int,
	@MaSV int
AS
BEGIN
	if(@Type = 1)
	begin
	SElect COUNT(*) as TonTai from QLGX where MaSV = @Keyword 
	AND (@MaSV is null or MaSV = @MaSV)
	END
	ELSE IF(@Type = 2)
	BEGIN 
	SElect COUNT(*) as TonTai from QLGX where Bien = @Keyword 
	and (@MaSV is null or MaSV = @MaSV)
	end
	else if(@type=3)
	begin
		select COUNT(*) as TonTai from QLGX
			where MaSV = @MaSV	
	end

END


GO
/****** Object:  StoredProcedure [dbo].[DM_KTPhong]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DM_KTPhong]
	@id_Phong int,
	@Phong varchar(200)
AS
BEGIN
if(@id_Phong is null) --Kiểm tra sửa
begin
	select COUNT(*) as SoLuong from dbo.Phong where Phong=@Phong and id_Phong != @id_Phong group by Phong
		
END
else --kiểm tra thêm mới
begin
select COUNT(*) as SoLuong from dbodbo.Phong where Phong=@Phong group by Phong
end
end

GO
/****** Object:  StoredProcedure [dbo].[DM_KTQLChiPhi]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DM_KTQLChiPhi]
	@Keyword nvarchar(20),
	@Type int,
	@MaSV int
AS
BEGIN
	if(@Type = 1)
	begin
	SElect COUNT(*) as TonTai from QLCP where MaSV = @Keyword 
	AND (@MaSV is null or MaSV = @MaSV)
	END
	else if(@type=2)
	begin
		select COUNT(*) as TonTai from QLCP
			where MaSV = @MaSV	
	end

END


GO
/****** Object:  StoredProcedure [dbo].[DM_KTSinhVien]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DM_KTSinhVien]
	@Keyword nvarchar(20),
	@Type int,
	@MaSV int
AS
BEGIN
	if(@Type = 1)
	begin
	SElect COUNT(*) as TonTai from SV where MaSV = @Keyword 
	AND (@MaSV is null or MaSV = @MaSV)
	END
	ELSE IF(@Type = 2)
	BEGIN 
	SElect COUNT(*) as TonTai from SV where HoTenSV = @Keyword 
	and (@MaSV is null or MaSV = @MaSV)
	end
	else if(@type=3)
	begin
		select COUNT(*) as TonTai from SV 
			where MaSV = @MaSV	
	end

END


GO
/****** Object:  StoredProcedure [dbo].[DM_ListGuiXe]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DM_ListGuiXe]
		@Keyword NVARCHAR(200),
		@TotalRow INT    output
		as
	
BEGIN	
		

	SELECT a.id_GX,a.MaSV,a.LoaiXe,a.Bien,b.SDT FROM QLGX as a
	INNER JOIN SV as b ON b.MaSV=a.MaSV WHERE LoaiXe LIKE CONCAT('%',@Keyword,'%') 

	SET @TotalRow =  (SELECT COUNT(1) FROM QLGX);
END;
GO
/****** Object:  StoredProcedure [dbo].[DM_ListPhong]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DM_ListPhong]
		@Keyword NVARCHAR(200)
		as
	
BEGIN	
		SELECT 
			* 
			 from dbo.Phong a
			WHERE 
			a.Phong like CONCAT('%',@Keyword,'%')
END;


GO
/****** Object:  StoredProcedure [dbo].[DM_ListQLChiPhi]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DM_ListQLChiPhi]
		@Keyword NVARCHAR(200),
		@TotalRow INT    output
		as
	
BEGIN	
		

	SELECT a.id_QLCP,a.MaSV,a.NgayDK,a.NgayNop,a.TrangThai FROM QLCP as a
	INNER JOIN SV as b ON b.MaSV=a.MaSV WHERE TrangThai LIKE CONCAT('%',@Keyword,'%') 

	SET @TotalRow =  (SELECT COUNT(1) FROM QLCP);
END;
GO
/****** Object:  StoredProcedure [dbo].[DM_ListSinhVien]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DM_ListSinhVien]
			@Keyword nvarchar (200),
	@TotalRow INT    output
AS
BEGIN
	SELECT a.id_SV,a.MaSV,a.HoTenSV,a.NgaySinh,a.DiaChi,b.Phong,a.SDT FROM SV as a
	INNER JOIN Phong as b ON b.id_Phong=a.id_Phong WHERE HoTenSV LIKE CONCAT('%',@Keyword,'%') 

	SET @TotalRow =  (SELECT COUNT(1) FROM SV);
END;

select * from SV
select * from Phong

GO
/****** Object:  StoredProcedure [dbo].[DM_NewGuiXe]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DM_NewGuiXe]
	@MaSV int,
	@LoaiXe nvarchar(200),
	@Bien nvarchar(10)
AS
BEGIN
	insert into QuanLyKTX.dbo.QLGX(
		MaSV,
		LoaiXe,
		Bien
		)
		VALUES(
			@MaSV,
			@LoaiXe,
			@Bien
		);
		select SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[DM_NewPhong]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DM_NewPhong]
	@Phong varchar(200),
	@GiaPhong nvarchar(200),
	@TrangThai varchar(10)
AS
BEGIN
	insert into QuanLyKTX.dbo.Phong(
		Phong,
		GiaPhong,
		TrangThai
		)
		VALUES(
			@Phong,
			@GiaPhong,
			@TrangThai
		);
		select SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[DM_NewQLChiPhi]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DM_NewQLChiPhi]
	@MaSV int,
	@NgayDK nvarchar(10),
	@NgayNop nvarchar(10),
	@TrangThai nvarchar(10)
AS
BEGIN
	insert into QuanLyKTX.dbo.QLCP(
		MaSV,
		NgayDK,
		NgayNop,
		TrangThai
		)
		VALUES(
			@MaSV,
			@NgayDK,
			@NgayNop,
			@TrangThai
			);
		select SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[DM_NewSinhVien]    Script Date: 3/22/2023 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DM_NewSinhVien]
	@MaSV int,
	@HoTenSV nvarchar(200),
	@NgaySinh nvarchar(200),
	@DiaChi nvarchar(200),
	@id_Phong int,
	@SDT nvarchar(200)
AS
BEGIN
	insert into QuanLyKTX.dbo.SV(
		MaSV,
		HoTenSV,
		NgaySinh,
		DiaChi,
		id_Phong,
		SDT
		)
		VALUES(
			@MaSV,
			@HoTenSV,
			@NgaySinh,
			@DiaChi,
			@id_Phong,
			@SDT
		);
		select SCOPE_IDENTITY()
END




GO
