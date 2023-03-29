public class Match
{
    public Team HomeTeam { get; set; }
    public Team AwayTeam { get; set; }
    public Match (Team a, Team b)
    {
        HomeTeam = a;
        AwayTeam = b;
    }
    public Team Play()
    {
        double homeAttackStrength = HomeTeam.AttkRating / AwayTeam.DefenseRating;
        double awayAttackStrength = AwayTeam.AttkRating / HomeTeam.DefenseRating;
        double homeWinProbability = homeAttackStrength / (homeAttackStrength + awayAttackStrength);
        double awayWinProbability = awayAttackStrength / (homeAttackStrength + awayAttackStrength);
        Random random = new Random();
        double result = random.NextDouble();
        if (result < homeWinProbability)
        {
            return HomeTeam;
        }
        else if (result < homeWinProbability + awayWinProbability)
        {
            return AwayTeam;
        }
        else
        {
            return null;
        }
    }
}