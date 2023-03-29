public class Team
{
    public string TeamName { get; set; }
    public int AttkRating { get; set; }
    public int DefenseRating { get; set; }
    public Team(string TeamName, int AttkRating, int DefenseRating)
    {
        this.TeamName = TeamName;
        this.AttkRating = AttkRating;
        this.DefenseRating = DefenseRating;
    }
}