USE [DATABASE]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

ALTER PROCEDURE [dbo].[NewsItems_GetPagedNewsItems]
(
	@PageIndex int,
	@PageSize int,
	@SectionId int
)
AS
SET NOCOUNT ON

SET @PageIndex = @PageIndex - 1;

SELECT NI.Id, NI.RowNum, NI.SectionId, NI.ItemState, NI.UrlLink, NI.Title, NI.SubTitle, NI.SubTitle AS TextBody, NI.ImageUrl, NI.Author, NI.Created FROM
(
	SELECT Id, SectionId, ItemState, UrlLink, Title, SubTitle, SubTitle AS TextBody, ImageUrl, Author, Created, ROW_NUMBER() OVER (ORDER BY Id DESC) AS RowNum
	FROM NewsItems WHERE (SectionId = @SectionId OR @SectionId = 0)
) AS NI	WHERE NI.RowNum BETWEEN (@PageIndex * @PageSize + 1) AND ((@PageIndex + 1) * @PageSize);