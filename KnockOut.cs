public class KnockOut
{

    public List<Match> Matches { get; set; }
    public Dictionary<Team, int> Vectory { get; set; }
    public List<Team> Winners {get; set; }
    public KnockOut(List<Match> matches)
    {

        Matches = matches;
        Vectory = new Dictionary<Team, int>();
    }
    public void GenerateMatches()
    {
        Matches = new List<Match>();
        int numTeams = Winners.Count;
        for (int i = 0; i < numTeams - 1; i++)
        {
            for (int j = i + 1; j < numTeams; j++)
            {
                Match Home = new Match(Winners[i], Winners[j]);
                Match Away = new Match(Winners[j], Winners[i]);
                Matches.Add(Home);
                Matches.Add(Away);
            }
        }
    }
    public List<Team> PlayAllMatches()
    {
        List<Team> result = new List<Team>();
        foreach (Match match in Matches)
        {
            Team winner = match.Play();
            if (!Vectory.ContainsKey(match.HomeTeam))
            {
                Vectory[match.HomeTeam] = 0;
            }
            if (!Vectory.ContainsKey(match.AwayTeam))
            {
                Vectory[match.AwayTeam] = 0;
            }
            if(winner == null){
                Vectory[match.AwayTeam] += 0;
                Vectory[match.HomeTeam] += 0;
                result.Add(match.HomeTeam);
                continue;
            }
            if (winner.TeamName == match.HomeTeam.TeamName)
            {
                Vectory[match.HomeTeam] += 1;
                Console.WriteLine($"{match.HomeTeam.TeamName} ganhou o jogo.");
                result.Add(match.HomeTeam);

            }
            else
            {
                Vectory[match.AwayTeam] += 1;
                Console.WriteLine($"{match.AwayTeam.TeamName} ganhou o jogo.");
                result.Add(match.AwayTeam);
            }
        }
        return result;
    }
}
