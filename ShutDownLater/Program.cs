using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        PrintBanner();
        var minutes = GetShutdownTimeFromUser();
        var shutDownTime = DateTime.Now.AddMinutes(minutes);
        CountDownUntil(shutDownTime);
        ShutdownSystem();
    }

    static void PrintBanner()
    {
        var banner = new[]
        {
            "╔╔══════════════════════╗╗ ShutDownLater",
            "║║▐█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█▌║║    by Adri B",
            "║║▐▌░░▒▒░░▒▒░░▒▒░░▒▒░░▐▌║║",
            "║║▐▌▒▒░░▒▒░░▒▒░░▒▒░░▒▒▐▌║║",
            "║║▐▌▒▒░░▒▒░░▒▒░░▒▒░░▒▒▐▌║║",
            "║║▐▌░░▒▒░░▒▒░░▒▒░░▒▒░░▐▌║║",
            "║║▐▌▒▒░░▒▒░░▒▒░░▒▒░░▒▒▐▌║║",
            "║║▐▌░░▒▒░░▒▒░░▒▒░░▒▒░░▐▌║║",
            "║║▐█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█▌║║",
            "╚╚══════════════════════╝╝",
             "██▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄██",
             "██▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄██",
             "██▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄▀▄██",
             "██▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██",
             "▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀"
        };

        foreach (var line in banner)
        {
            Console.WriteLine(line);
            Thread.Sleep(10);
        }
    }

    static short GetShutdownTimeFromUser()
    {
        Console.Write(" Write shut down time in minutes: ");
        short minutes;
        while (!short.TryParse(Console.ReadLine(), out minutes) || minutes < 0)
        {
            Console.Write("Invalid input. Please enter a positive number: ");
        }
        return minutes;
    }

    static void CountDownUntil(DateTime shutDownTime)
    {
        TimeSpan remainingTime;
        while ((remainingTime = shutDownTime - DateTime.Now) > TimeSpan.Zero)
        {
            Console.Clear();
            Console.WriteLine("Remaining time: {0} hours {1} minutes {2} seconds ", remainingTime.Hours, remainingTime.Minutes, remainingTime.Seconds);
            Thread.Sleep(500);
        }
    }

    static void ShutdownSystem()
    {
        Process.Start("shutdown", "/s /t 0");
    }
}
