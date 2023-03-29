public class Draw
{
public List<Group> Groups { get; set; }
public List<Team> Winners {get; set; }
    public Draw()
    {
        Groups = new List<Group>();
        Winners = new List<Team>();
    }
    public void PerformDraw(List<Team> teams)
    {
        Random random = new Random();
        List<Team> shuffledTeams = teams.OrderBy(x => random.Next()).ToList();
        for (int i = 0; i < 8; i++)
        {
            string groupName = $"Group {((char)('A' + i))}";
            List<Team> groupTeams = shuffledTeams.GetRange(i * 4, 4);
            Group groups = new Group(groupName, groupTeams);
            Groups.Add(groups);
        }
    }
    public KnockOut PerformDrawWinners()
    {
        List<Team> temp = new List<Team>();
        List<Match> matches = new List<Match>();
        foreach (Group group in Groups)
        {
            temp = group.Points.OrderByDescending(pair => pair.Value).Take(2).Select(pair => pair.Key).ToList();
            Winners.Add(temp[0]);
            Winners.Add(temp[1]);
        }
        Random random = new Random();
        List<Team> shuffledTeams = Winners.OrderBy(x => random.Next()).ToList();
       
        for(int i = 0; i < Winners.Count; i+=2)
        {
            Match m = new Match(Winners[i], Winners[i+1]);
            matches.Add(m);

        }
        return new KnockOut(matches);
    }
}
