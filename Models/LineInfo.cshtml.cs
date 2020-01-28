using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace program.Pages  
{  
    public class LineInfoModel : PageModel  
    {  
				public List<Models.Line> StationList { get; set; }
				public string Input { get; set; }
				public Exception EX { get; set; }
  
        public void OnGet(string input)  
        {  
				  StationList = new List<Models.Line>();
					
					// make input available to web page:
					Input = input;
					
					// clear exception:
					EX = null;
					
					try
					{
						//
						// Do we have an input argument?  If not, there's nothing to do:
						//
						if (input == null)
						{
							//
							// there's no page argument, perhaps user surfed to the page directly?  
							// In this case, nothing to do.
							//
						}
						else  
						{
							// 
							// Lookup movie(s) based on input, which could be id or a partial name:
							// 
							string sql;

						  // lookup station(s) by partial name match:
							input = input.Replace("'", "''");

						
    sql = string.Format(@"
    SELECT Position, Stations.StationID, Stations.Name, COUNT(DISTINCT StopID) AS numStops, Color
    FROM Stations
	LEFT JOIN Riderships ON Stations.StationID = Riderships.StationID
    LEFT JOIN Stops ON Stations.StationID = Stops.StationID
    LEFT JOIN StationOrder ON Stations.StationID = StationOrder.StationID
    LEFT JOIN Lines ON Lines.LineID = StationOrder.LineID
    WHERE Color LIKE '%{0}%'
	GROUP BY Stations.StationID, Stations.Name, [Position], Color
	ORDER BY [Position]
    ", input);
    


							DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

							foreach (DataRow row in ds.Tables[0].Rows)
							{
								Models.Line s = new Models.Line();

								s.StationID = Convert.ToInt32(row["StationID"]);
								s.StationName = Convert.ToString(row["Name"]);

						
                                s.NumStops = Convert.ToInt32(row["numStops"]);
                                
                               
								StationList.Add(s);
							}
						}//else
                        
                        
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

