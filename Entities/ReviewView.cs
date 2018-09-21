using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    /*
drop view ReviewView
create view ReviewView as
select  count(*) as RecordCount, x.Total, round(count(*)*100/convert(float, x.Total),2,1) as Percentage, rt.BusinessID, rt.Message, rdi2.DisplayValue as Category, rdi3.DisplayValue as SubCategory
from ReviewItem ri
inner join ReviewType rt on rt.ReviewTypeID = ri.ReviewTypeID
inner join ApplicationVersion av on av.ApplicationVersionId = ri.ApplicationVersionID and IsLatest = 1
inner join Application a on a.ApplicationId = av.ApplicationId
inner join ReferenceDataItem rdi on rdi.ReferenceDataItemID = av.ApplicationVersionStatusID
inner join ReferenceDataItem rdi2 on rdi2.ReferenceDataItemID = rt.ReviewCategoryID
inner join ReferenceDataItem rdi3 on rdi3.ReferenceDataItemID = rt.ReviewTypeReferenceID
cross apply (
	select count(*) as Total
	from ReviewItem ri2
	inner join ReviewType rt2 on rt2.ReviewTypeID = ri2.ReviewTypeID
	inner join ApplicationVersion av2 on av2.ApplicationVersionId = ri2.ApplicationVersionID and av2.IsLatest = 1
	inner join Application a2 on a2.ApplicationId = av2.ApplicationId
	inner join ReferenceDataItem rdi11 on rdi11.ReferenceDataItemID = av2.ApplicationVersionStatusID
	inner join ReferenceDataItem rdi22 on rdi22.ReferenceDataItemID = rt2.ReviewCategoryID
	inner join ReferenceDataItem rdi33 on rdi33.ReferenceDataItemID = rt2.ReviewTypeReferenceID
	where a2.FundingYear = 2017
) as x
where a.FundingYear = 2017
group by x.Total, rt.BusinessID, rt.Message,  rdi2.DisplayValue, rdi3.DisplayValue
order by count(*) desc


CREATE PROCEDURE [dbo].[GetApplicationsByReview] (
    @ReviewBusinessId [varchar](100)
)
AS
BEGIN
    SELECT a.ApplicationDisplay, rdi.DisplayValue as ApplicationStatus, lv.SIN, lv.FirstName, lv.LastName
    FROM Application a
	INNER JOIN ApplicationVersion av on av.ApplicationID = a.ApplicationID
	INNER JOIN Learner.LearnerVersion lv on lv.LearnerVersionID = av.LearnerVersionID
	INNER JOIN ReferenceDataItem rdi on rdi.ReferenceDataItemID = av.ApplicationVersionStatusID
	WHERE Exists (
		SELECT 1 
		FROM ReviewItem ri
		INNER JOIN ReviewType rt on rt.ReviewTypeID = ri.ReviewTypeID
		WHERE ri.ApplicationVersionID = av.ApplicationVersionID
		AND rt.BusinessID = @ReviewBusinessId
	)
	
END


     */
    public class ReviewView
    {
        public int RecordCount { get; set; }
        public int Total { get; set;  }

        public double Percentage { get; set; }

        public string BusinessId { get; set; }

        public string Message { get; set; }

        public string Category { get; set; }

        public string SubCategory { get; set; }
    }
}
