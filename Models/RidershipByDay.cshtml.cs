using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
  
namespace program.Pages  
{  
    public class RidershipByDayModel : PageModel  
    {  
        public List<string> Days { get; set; }
        public List<int> NumRiders { get; set; }
        public Exception EX { get; set; }
  
        public void OnGet()  
        {
          Days = new List<string>();
          NumRiders = new List<int>();         
          EX = null;
          
          Days.Add("Sunday");
          Days.Add("Monday");
          Days.Add("Tuesday");
          Days.Add("Wednesday");
          Days.Add("Thursday");
          Days.Add("Friday");
          Days.Add("Saturday");
          
          
          try
          {
            string sql = string.Format(@"
SELECT DATENAME(WEEKDAY, TheDate) AS TheDay, Sum(DailyTotal) AS NumRiders,
  case DATENAME(WEEKDAY, TheDate)
  when 'sunday' then 0
  when 'monday' then 1
  when 'tuesday' then 2
  when 'wednesday' then 3
  when 'thursday' then 4
  when 'friday' then 5
  when 'saturday' then 6
end as dayNum
FROM Riderships
GROUP BY DATENAME(WEEKDAY, TheDate)
ORDER BY dayNum
");
          
            DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
              int numriders = Convert.ToInt32(row["NumRiders"]);

              NumRiders.Add(numriders);
            }
		      }
		      catch(Exception ex)
		      {
            EX = ex;
		      }
		      finally
		      { 
            // nothing at the moment
          } 
        }  
        
    }//class
}//namespace