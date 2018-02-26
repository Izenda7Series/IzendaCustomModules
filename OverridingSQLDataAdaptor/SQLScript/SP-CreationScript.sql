-- CREATE USER-DEFINED TABLE TYPE TO PASS LIST OF IDS AS PARAM
CREATE TYPE [dbo].[FieldIds] AS TABLE(
	[Id] [nvarchar](200) NULL
)

GO

-- CREATE STORED PROC
CREATE PROCEDURE [dbo].[sp_getFieldUniqueNamesByIds] 
	@fieldIds FieldIds READONLY
AS
SELECT  
	'[' + c.Name + '].[' + qsc.Name + '].[' + qs.Name + '].[' + qsf.Name + ']' 
FROM IzendaConnection c,
		IzendaQuerySourceCategory qsc,
		IzendaQuerySource qs,
		IzendaQuerySourceField qsf, 
		@fieldIds fields 
WHERE 
	c.Id = qsc.ConnectionId AND qsc.Id = qs.CategoryId AND qs.Id = qsf.QuerySourceId AND qsf.Id = fields.Id

GO