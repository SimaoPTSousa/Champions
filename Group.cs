public class Group
{
    public string GroupName { get; set; }
    public List<Team> Teams { get; set; }
    public List<Match> Matches { get; set; }
    public Dictionary<Team, int> Points { get; set; }
    public Group(string groupName, List<Team> teams)
    {
        GroupName = groupName;
        Teams = teams;
        Matches = new List<Match>();
        GenerateMatches();
        Points = new Dictionary<Team, int>();
    }
    public void GenerateMatches()
    {
        Matches = new List<Match>();
        int numTeams = Teams.Count;
        for (int i = 0; i < numTeams - 1; i++)
        {
            for (int j = i + 1; j < numTeams; j++)
            {
                Match Home = new Match(Teams[i], Teams[j]);
                Match Away = new Match(Teams[j], Teams[i]);
                Matches.Add(Home);
                Matches.Add(Away);

            }
        }
    }
    public void PlayAllMatches()
    {
        foreach (Match match in Matches)
        {
            Team winner = match.Play();
            if (!Points.ContainsKey(match.HomeTeam))
            {
                Points[match.HomeTeam] = 0;
            }
            if (!Points.ContainsKey(match.AwayTeam))
            {
                Points[match.AwayTeam] = 0;
            }
            if(winner == null){
                Points[match.AwayTeam] += 1;
                Points[match.HomeTeam] += 1;
                continue;
            }
            if (winner.TeamName == match.HomeTeam.TeamName)
            {
                Points[match.HomeTeam] += 3;
                Console.WriteLine($"{match.HomeTeam.TeamName} ganhou o jogo.");
            }
            else
            {
                Points[match.AwayTeam] += 3;
                Console.WriteLine($"{match.AwayTeam.TeamName} ganhou o jogo.");
            }
        }
    }
    public List<Team> GetStandings() 
    {
        foreach(Team Points in Teams)
        {  
        }
        return Teams;
    }
}