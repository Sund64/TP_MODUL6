using System;

public class SayaMusicTrack
{
    private int id;
    private int playCount;
    private string title;

    public SayaMusicTrack(string title)
    {
        if (title == null)
            throw new ArgumentException("Precondition gagal: Judul tidak boleh null.");
        if (title.Length > 100)
            throw new ArgumentException("Precondition gagal: Judul maksimal 100 karakter.");

        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {

        if (count > 10_000_000)
            throw new ArgumentException("Precondition gagal: Input penambahan play count maksimal 10.000.000.");

        try
        {
            playCount = checked(playCount + count);
            Console.WriteLine($"Play count berhasil ditambah. Total sekarang: {playCount}");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Exception: Overflow! Play count melebihi batas maksimum integer.");
        }
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
        Console.WriteLine("== Uji Normal ==");
        SayaMusicTrack track = new SayaMusicTrack("Bohemian Rhapsody");
        track.PrintTrackDetails();
        track.IncreasePlayCount(150);
        track.IncreasePlayCount(75);
        Console.WriteLine("\nSetelah menambah play count:");
        track.PrintTrackDetails();

        Console.WriteLine("\n== Uji Precondition (count > 10.000.000) ==");
        try
        {
            SayaMusicTrack track2 = new SayaMusicTrack("Shape of You");
            track2.IncreasePlayCount(10_000_001);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Precondition Exception tertangkap: {ex.Message}");
        }

        Console.WriteLine("\n== Uji Overflow dengan for loop ==");
        SayaMusicTrack track3 = new SayaMusicTrack("Blinding Lights");
        for (int i = 0; i < 300; i++)
        {
            track3.IncreasePlayCount(10_000_000);
        }
        track3.PrintTrackDetails();

        Console.WriteLine("\nTekan Enter untuk keluar...");
        Console.ReadLine();
    }
}