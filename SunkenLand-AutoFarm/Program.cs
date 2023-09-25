using SunkenlandAutoFarm;
using System;
using System.Runtime.InteropServices;
using System.Threading;

class Logos
{
    public static string Main()
    {
        string logo = @"███████╗██╗   ██╗███╗   ██╗██╗  ██╗███████╗███╗   ██╗██╗      █████╗ ███╗   ██╗██████╗ 
██╔════╝██║   ██║████╗  ██║██║ ██╔╝██╔════╝████╗  ██║██║     ██╔══██╗████╗  ██║██╔══██╗
███████╗██║   ██║██╔██╗ ██║█████╔╝ █████╗  ██╔██╗ ██║██║     ███████║██╔██╗ ██║██║  ██║
╚════██║██║   ██║██║╚██╗██║██╔═██╗ ██╔══╝  ██║╚██╗██║██║     ██╔══██║██║╚██╗██║██║  ██║
███████║╚██████╔╝██║ ╚████║██║  ██╗███████╗██║ ╚████║███████╗██║  ██║██║ ╚████║██████╔╝
╚══════╝ ╚═════╝ ╚═╝  ╚═══╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═══╝╚══════╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═════╝ 
                                                                                       ";
        return logo;
    }

    public static string Steel()
    {
        string logo = @"███████╗██╗                   ███████╗████████╗███████╗███████╗██╗     
██╔════╝██║                   ██╔════╝╚══██╔══╝██╔════╝██╔════╝██║     
███████╗██║         █████╗    ███████╗   ██║   █████╗  █████╗  ██║     
╚════██║██║         ╚════╝    ╚════██║   ██║   ██╔══╝  ██╔══╝  ██║     
███████║███████╗              ███████║   ██║   ███████╗███████╗███████╗
╚══════╝╚══════╝              ╚══════╝   ╚═╝   ╚══════╝╚══════╝╚══════╝
                                                                       ";
        return logo;
    }
    public static string Copper_Iron()
    {
        string logo = @"███████╗██╗                   ██╗██████╗  ██████╗ ███╗   ██╗        ██╗     ██████╗ ██████╗ ██████╗ ██████╗ ███████╗██████╗ 
██╔════╝██║                   ██║██╔══██╗██╔═══██╗████╗  ██║       ██╔╝    ██╔════╝██╔═══██╗██╔══██╗██╔══██╗██╔════╝██╔══██╗
███████╗██║         █████╗    ██║██████╔╝██║   ██║██╔██╗ ██║      ██╔╝     ██║     ██║   ██║██████╔╝██████╔╝█████╗  ██████╔╝
╚════██║██║         ╚════╝    ██║██╔══██╗██║   ██║██║╚██╗██║     ██╔╝      ██║     ██║   ██║██╔═══╝ ██╔═══╝ ██╔══╝  ██╔══██╗
███████║███████╗              ██║██║  ██║╚██████╔╝██║ ╚████║    ██╔╝       ╚██████╗╚██████╔╝██║     ██║     ███████╗██║  ██║
╚══════╝╚══════╝              ╚═╝╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═══╝    ╚═╝         ╚═════╝ ╚═════╝ ╚═╝     ╚═╝     ╚══════╝╚═╝  ╚═╝
                                                                                                                            ";
        return logo;
    }

    public static string Sawmill()
    {
        string logo = @"███████╗██╗                   ███████╗ █████╗ ██╗    ██╗███╗   ███╗██╗██╗     ██╗     
██╔════╝██║                   ██╔════╝██╔══██╗██║    ██║████╗ ████║██║██║     ██║     
███████╗██║         █████╗    ███████╗███████║██║ █╗ ██║██╔████╔██║██║██║     ██║     
╚════██║██║         ╚════╝    ╚════██║██╔══██║██║███╗██║██║╚██╔╝██║██║██║     ██║     
███████║███████╗              ███████║██║  ██║╚███╔███╔╝██║ ╚═╝ ██║██║███████╗███████╗
╚══════╝╚══════╝              ╚══════╝╚═╝  ╚═╝ ╚══╝╚══╝ ╚═╝     ╚═╝╚═╝╚══════╝╚══════╝
                                                                                      ";
        return logo;
    }
}

class Farms
{
    private static bool steelFuranceRunning = false;
    private static bool ironCopperFuranceRunning = false;
    private static bool sawmillRunning = false;


    [DllImport("user32.dll")]
    public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

    private const byte VK_F = 0x46;  // F
    private const byte VK_C = 0x43;  // C
    private const int KEYEVENTF_KEYDOWN = 0x0;
    private const int KEYEVENTF_KEYUP = 0x2;

    public static void SteelFurance()
    {
        steelFuranceRunning = true;

        Console.Clear();
        Console.WindowWidth = 125;
        Console.WriteLine(Logos.Steel());
        Console.WriteLine("10 Steel = ~15 Minutes" + Environment.NewLine);

        int cfKeyPressCount = 0;
        int produced = 0; // See how much you produced
        int timeout = 91; // The seconds to wait before clicking again
        int timeout_bkp = timeout; // backup | to make the code more soft

        while (steelFuranceRunning)
        {
            if (cfKeyPressCount < 6)
            {
                // Pressing Buttons
                PressKey(VK_F); 
                PressKey(VK_C);
                PressKey(VK_C);
                // Increasing Counter
                cfKeyPressCount++;
                // Just useless printing
                Console.Write($"\r{cfKeyPressCount} times clicked".PadRight(50) + "| Status: Clicking...");
            }
            else
            {
                produced++;

                // Showing live timeout
                while (timeout > 0) {
                    if (!steelFuranceRunning)
                    {
                        break;
                    }

                    Console.Write($"\r{produced} Steel Produced".PadRight(50) + $"| Status: Waiting... | Clicking in {timeout}s" + "".PadRight(5)); // The \r is for Updating / Rewrite the full line
                    Thread.Sleep(1000);
                    timeout--;
                }

                timeout = timeout_bkp;
                cfKeyPressCount = 0; // Reset Counter
            }
        }
    }

    public static void Iron_CopperFurance()
    {
        ironCopperFuranceRunning = true;

        Console.Clear();
        Console.WindowWidth = 125;
        Console.WriteLine(Logos.Copper_Iron());
        Console.WriteLine("10 Iron/Copper = ~5 Minutes" + Environment.NewLine);

        int produced = 0; // See how much you produced
        int timeout = 31; // The seconds to wait before clicking again
        int timeout_bkp = timeout; // backup | to make the code more soft

        while (ironCopperFuranceRunning)
        {
            PressKey(VK_F);
            PressKey(VK_F);
            PressKey(VK_C);
            PressKey(VK_C);
            
            produced++;

            // Showing live timeout
            while (timeout > 0)
            {
                if (!ironCopperFuranceRunning)
                {
                    break;
                }

                Console.Write($"\r{produced} Bars Produced".PadRight(50) + $"| Status: Waiting... | Clicking in {timeout}s" + "".PadRight(5)); // The \r is for Updating / Rewrite the full line
                Thread.Sleep(1000);
                timeout--;
            }

            timeout = timeout_bkp;
        }
    }

    public static void Sawmill()
    {
        sawmillRunning = true;

        Console.Clear();
        Console.WindowWidth = 125;
        Console.WriteLine(Logos.Sawmill());
        Console.WriteLine("10 Fine Woodplanks = ~5 Minutes" + Environment.NewLine);

        int fKeyPressCount = 0;
        int produced = 0; // See how much you produced
        int timeout = 31; // The seconds to wait before clicking again
        int timeout_bkp = timeout; // backup | to make the code more soft

        while (sawmillRunning)
        {
            if (fKeyPressCount < 6)
            {
                PressKey(VK_F);
                fKeyPressCount++;
                Console.Write($"\r{fKeyPressCount} times clicked".PadRight(50) + "| Status: Clicking...");
            }
            else
            {
                produced++;

                // Showing live timeout
                while (timeout > 0)
                {
                    if (!sawmillRunning)
                    {
                        break;
                    }

                    Console.Write($"\r{produced} Steel Produced".PadRight(50) + $"| Status: Waiting... | Clicking in {timeout}s" + "".PadRight(5)); // The \r is for Updating / Rewrite the full line
                    Thread.Sleep(1000);
                    timeout--;
                }

                timeout = timeout_bkp;
                fKeyPressCount = 0; // Reset Counter
            }
        }
    }

    internal static void PressKey(byte keyCode, int lenght = 35)
    {
        keybd_event(keyCode, 0, KEYEVENTF_KEYDOWN, 0);
        Thread.Sleep(lenght);
        keybd_event(keyCode, 0, KEYEVENTF_KEYUP, 0);
    }

    public static void StopAllFarms()
    {
        steelFuranceRunning = false;
        ironCopperFuranceRunning = false;
        sawmillRunning = false;
    }
}

class Handles
{
    public static void HandleCtrlC(object sender, ConsoleCancelEventArgs e)
    {
        Farms.StopAllFarms();
        Environment.Exit(0);
    }
}

namespace SunkenlandAutoFarm
{
    internal class Program
    {
        internal static void Main()
        {
            Console.Clear();
            Console.WriteLine(Logos.Main());
            Console.WindowWidth = 87;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("IF YOU'RE DONE FARMING PRESS CTRL + C" + Environment.NewLine);
            Console.ResetColor();
            Console.WriteLine("[1] Steel Furance    [2] Iron/Coppper Furance    [3] Sawmill");
            ConsoleKeyInfo key = Console.ReadKey();
            int timer = 5;
            int timer_bkp = timer;

            while (timer > 0)
            {
                Console.Write($"\rStarting in {timer} seconds...");
                Thread.Sleep(1000);
                timer--;
            }

            Console.CancelKeyPress += Handles.HandleCtrlC;

            timer = timer_bkp;
            
            if (key.Key == ConsoleKey.D1)
            {
                Farms.SteelFurance();
            }
            else if (key.Key == ConsoleKey.D2) 
            { 
                Farms.Iron_CopperFurance();
            }
            else if (key.Key == ConsoleKey.D3)
            {
                Farms.Sawmill();
            }
            else { Console.WriteLine("Invalid Key"); }
        }
        
    }
}