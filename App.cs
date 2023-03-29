using System;
using System.Collections.Generic;
public class App
{ 
    public static void Main(string[] args)
    {  
        List<Team> Teams = new List<Team>
        {
            new Team ("Sporting", 150, 150),
            new Team ("Benfica", 150, 145),
            new Team ("Porto", 145, 145),
            new Team ("Farense", 130, 130),
            new Team ("Braga", 130, 130),
            new Team ("Manchester City", 105, 90),
            new Team ("Real Madrid", 105, 90),
            new Team ("Bayern Munich", 100, 95),
            new Team ("Arsenal", 100, 95),
            new Team ("Barcelona", 90, 85),
            new Team ("Liverpool", 85, 85),
            new Team ("PSG", 100, 80),
            new Team ("Napoli", 90, 90),
            new Team ("ManchesterUnited", 95, 70),
            new Team ("Milan", 90, 85),
            new Team ("Chelsea", 90, 80), 
            new Team ("Juventus", 85, 80),
            new Team ("Tottenham", 90, 75),
            new Team ("Inter", 85, 85),
            new Team ("Borussia", 75, 85),
            new Team ("Atletico", 75, 70),
            new Team ("Leipzig", 75, 70),
            new Team ("Marselha", 70, 70),
            new Team ("Ajax", 70, 70),
            new Team ("Sevilha", 70, 70),
            new Team ("Roma", 70, 70),
            new Team ("Fulham", 50, 60),
            new Team ("ClubeBrugge", 50, 60),
            new Team ("Monaco", 50, 60),
            new Team ("Newcastle", 50, 60),
            new Team ("RealSociadade", 50, 50 ),
            new Team ("CasaPia", 25, 25),  
        };
       
        ChampionsLeague CL = new ChampionsLeague(Teams);
        foreach (Group group in CL.Groups)
        {
            Console.WriteLine("Grupo " + group.GroupName);
            foreach (Team team in group.Teams)
            {
                Console.WriteLine(team.TeamName);
            }
            Console.WriteLine();
            group.PlayAllMatches();
            Console.WriteLine();
        }
        Console.WriteLine("Equipas que passaram com mais pontos:");
        KnockOut k = CL.Draw.PerformDrawWinners();
        foreach(Team t in CL.Draw.Winners)
            Console.WriteLine(t.TeamName);
        List<Team> qualified = CL.Draw.Winners;

        //8avos
        Console.WriteLine("OITAVOS");
        qualified = k.PlayAllMatches();
        Console.WriteLine();

        //4os
        Console.WriteLine("QUARTOS");

        List<Match> matches = new List<Match>();

        for (int i = 0; i < qualified.Count; i+=2){
            Match m = new Match(qualified[i], qualified[i+1]);
            matches.Add(m);
        }
        Console.WriteLine();
        k = new KnockOut(matches);
        qualified = k.PlayAllMatches();
        Console.WriteLine();
        //2as
                Console.WriteLine("MEIAS");

        matches.Clear();
        for (int i = 0; i < qualified.Count; i+=2){
            Match m = new Match(qualified[i], qualified[i+1]);
            matches.Add(m);
        }
        Console.WriteLine();
        k = new KnockOut(matches);
        qualified = k.PlayAllMatches();
        Console.WriteLine();
        //Final
                        Console.WriteLine("FINAL");

        matches.Clear();
        for (int i = 0; i < qualified.Count; i+=2){
            Match m = new Match(qualified[i], qualified[i+1]);
            matches.Add(m);
        }
        Console.WriteLine();
        k = new KnockOut(matches);
        qualified = k.PlayAllMatches();


        

        
        
    }
}