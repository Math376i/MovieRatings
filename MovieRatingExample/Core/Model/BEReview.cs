namespace MovieRatingExample.Core.Model;

public class BEReview
{
    
    // Klassen bliver brugt til at sætte de vaiabler der skal bruges igennem projektet
    public int Reviewer { get; set; }
    public int Movie { get; set; }
    public int Grade { get; set; }
    public DateTime ReviewDate { get; set; }
}