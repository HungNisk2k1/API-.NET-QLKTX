USE [QuanLyKTX]
GO
/****** Object:  StoredProcedure [dbo].[DM_ChiTietGuiXe]    Script Date: 3/22/2023 2:57:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
ALTER PROCEDURE [dbo].[DM_ChiTietGuiXe]
	@MaSV int
AS
BEGIN
	--select * from  dbo.QLGX where MaSV=@MaSV
		SELECT a.id_GX,a.MaSV,a.LoaiXe,a.Bien,b.SDT FROM QLGX as a
		INNER JOIN SV as b ON b.MaSV=a.MaSV WHERE a.MaSV = @MaSV order by LoaiXe asc
	
END

GO
/****** Object:  StoredProcedure [dbo].[DM_DeleteGuiXe]    Script Date: 3/22/2023 2:57:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[DM_DeleteGuiXe]
	@MaSV int

AS
BEGIN
	
	delete  dbo.QLGX WHERE MaSV=@MaSV
		
END

GO
/****** Object:  StoredProcedure [dbo].[DM_EditGuiXe]    Script Date: 3/22/2023 2:57:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[DM_EditGuiXe]
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
/****** Object:  StoredProcedure [dbo].[DM_KTGuiXe]    Script Date: 3/22/2023 2:57:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[DM_KTGuiXe]
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
/****** Object:  StoredProcedure [dbo].[DM_ListGuiXe]    Script Date: 3/22/2023 2:57:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[DM_ListGuiXe]
		@Keyword NVARCHAR(200),
		@TotalRow INT    output
		as
	
BEGIN	
		

	SELECT a.id_GX,a.MaSV,a.LoaiXe,a.Bien,b.SDT FROM QLGX as a
	INNER JOIN SV as b ON b.MaSV=a.MaSV WHERE LoaiXe LIKE CONCAT('%',@Keyword,'%') 

	SET @TotalRow =  (SELECT COUNT(1) FROM QLGX);
END;
GO
/****** Object:  StoredProcedure [dbo].[DM_NewGuiXe]    Script Date: 3/22/2023 2:57:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[DM_NewGuiXe]
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
