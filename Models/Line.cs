//
// One CTA Station
//

namespace program.Models
{

  public class Line
	{
	
		// data members with auto-generated getters and setters:
        public int StationID { get; set; }
		public string StationName { get; set; }
        public int NumStops { get; set; }
   
      
		// default constructor:
		public Line()
		{ }
		
		// constructor:
		public Line(int id, string name, int numStops)
		{
			StationID = id;
			StationName = name;
            NumStops = numStops;
		}
		
	}//class

}//namespace