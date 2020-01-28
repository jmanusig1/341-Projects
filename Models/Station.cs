//
// One CTA Station
//

namespace program.Models
{

  public class Station
	{
	
		// data members with auto-generated getters and setters:
	  public int StationID { get; set; }
		public string StationName { get; set; }
		public int AvgDailyRidership { get; set; }
        public int NumStops { get; set; }
        public string Handicap {get; set; }
      
		// default constructor:
		public Station()
		{ }
		
		// constructor:
		public Station(int id, string name, int avgDailyRidership, int numStops, string handicap)
		{
			StationID = id;
			StationName = name;
			AvgDailyRidership = avgDailyRidership;
            NumStops = numStops;
            Handicap = handicap;
		}
		
	}//class

}//namespace