using System;

public class SayaMusicTrack
{
    private int id;
    private int playCount;
    private string title;

    public SayaMusicTrack(string title)
    {
        Random random = new Random();
        this.id = random.Next(10000, 99999); // 5 digit random
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        playCount += count;
    }

    public void PrintTrackDetails()
    {
        Console.WriteLine("=== Track Details ===");
        Console.WriteLine($"ID        : {id}");
        Console.WriteLine($"Title     : {title}");
        Console.WriteLine($"Play Count: {playCount}");
        Console.WriteLine("=====================");
    }
}
    
class Program
{
    static void Main(string[] args)
    {
        SayaMusicTrack track = new SayaMusicTrack("Bohemian Rhapsody");

        track.PrintTrackDetails();

        track.IncreasePlayCount(150);
        track.IncreasePlayCount(75);

        Console.WriteLine("\nSetelah menambah play count:");
        track.PrintTrackDetails();
    }
}