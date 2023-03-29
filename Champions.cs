using System;
using System.Collections.Generic;

public class ChampionsLeague
{
    public List<Team> Teams { get; set; }
    public List<Group> Groups { get; set; }
    public KnockOut KnockOutStage { get; set; }
    public List<Team> Winners {get; set; }
    public Draw Draw { get; set; }
    public ChampionsLeague(List<Team> teams)
    {
        Teams = teams;
        Draw = new Draw(); 
        Draw.PerformDraw(teams);
        Groups = Draw.Groups;
        Winners = Draw.Winners;
    }
    public void PlayGroupStage()
    {
        foreach(Group g in Groups)
        {
            g.PlayAllMatches();
        }
    }
    public void PlayKnockOutStage()
    {
        foreach(Team team in Winners)
        {

        }
        
    }
}