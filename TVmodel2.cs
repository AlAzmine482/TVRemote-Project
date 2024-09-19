using System;
using System.Diagnostics.Contracts;
using System.Numerics;
using TvRemoteExample;

public class TvModel2: TvDevice
{
	
        
   
    public int Volume { get; private set; }
    public string ScreenSize { get; private set; }
    public string UPCCode { get; private set; }
    public string CountryOfOrigin { get; private set; }
    public int Channel { get; private set; }
    public int Brightness { get; set; }
    public int Contrast { get; set; }
    public int Sharpness { get; set; }

    public TvModel2()
    {
        IsOn = false;
        Volume = 10; // Initial volume
        ModelName = "UN70TU7000";
        CountryOfOrigin = "Mexico";
        Channel = 1;
        ScreenSize = "70";
        UPCCode = "887276400075";
        Brightness = 50;
        Contrast = 50;
        Sharpness = 50;





    }



    public override void countryofOrgin()
    {
        Console.WriteLine(CountryOfOrigin);
    }

    public override void Model()
    {
        Console.WriteLine(ModelName);
    }

    public override void Screensize()
    {
        throw new NotImplementedException();
    }

    public override void TurnOff()
    {

        IsOn = false;
        Console.WriteLine("Turning Off TV.....");
    }

    public override void TurnOn()
    {
        IsOn = true;
        Console.WriteLine("Turning On Tv.....");
    }

    public override void UPCCODe()
    {
        throw new NotImplementedException();
    }

    public override void volumeDown()
    {
        Volume = Volume - 1;
        Console.WriteLine("Volume Down button pressed");
        Console.WriteLine("Volume:", Volume);
    }

    public override void volumeUp()
    {
        Volume = Volume + 1;
        Console.WriteLine("Volume up button pressed");
        Console.WriteLine("Volume:", Volume);
    }

    internal void DisplaySmartMenu()
    {
        throw new NotImplementedException();
    }

    public override void channelUp()
    {
        Channel = Channel + 1;
        Console.WriteLine($"Channel {Channel}");
    }

    public override void channelDown()
    {
        Channel = Channel - 1;
        Console.WriteLine($"Channel {Channel}");
    }

    public override void ChannelNumber(int channel)
    {
        Channel = channel;
        Console.WriteLine($"Channel {Channel}");
    }

    public override void mute()
    {
        Volume = 0;
        Console.WriteLine("Mute");
    }

    public void DisplayInternalFunctions()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n--- TV Remote Menu ---");
            Console.WriteLine("1) Turn On/Off TV");
            Console.WriteLine("2) Change Channel");
            Console.WriteLine("3) Exit");



            string? input = Console.ReadLine();


            switch (input)
            {
                case "1":
                    powerbutton();
                    break;
                case "2":
                    channelupdown();
                    break;
                case "3":
                    exit = true;
                    break;
            }


        }
    }

    public void powerbutton() {
        if (IsOn == false)
        {
            TurnOn();
        }
        else
        {
            TurnOff();

        }
    }
    public void channelupdown() {
        Console.WriteLine("Press  up arrow to increase or press down arrow to decrease");
        var keyInput = Console.ReadKey();
        switch (keyInput.Key)
        {
            case ConsoleKey.UpArrow:
                channelUp();
                Console.WriteLine("Volume up button pressed");
                break;
            case ConsoleKey.DownArrow:
                channelDown();
                Console.WriteLine("Volume Down button pressed");
                break;


        }
    }
    public override void BrightnessDown()
    {
        Brightness = Brightness - 1;
        Console.WriteLine("Brightness Down button pressed");
        Console.WriteLine($"Brightness: {Brightness}");
    }

    public override void BrightnessUp()
    {
        Brightness = Brightness + 1;
        Console.WriteLine("Brightness Up button pressed");
        Console.WriteLine($"Brightness: {Brightness}");
    }

    public override void ContrastDown()
    {
        Contrast = Contrast - 1;
        Console.WriteLine("Contrast Down button pressed");
        Console.WriteLine($"Contrast: {Contrast}");
    }

    public override void ContrastUp()
    {
        Contrast = Contrast + 1;
        Console.WriteLine("Contrast Up button pressed");
        Console.WriteLine($"Contrast: {Contrast}");
    }

    public override void SharpnessDown()
    {
        Sharpness = Sharpness - 1;
        Console.WriteLine("Sharpness Down button pressed");
        Console.WriteLine($"Sharpness: {Sharpness}");
    }

    public override void SharpnessUp()
    {
        Sharpness = Sharpness + 1;
        Console.WriteLine("Sharpness Up button pressed");
        Console.WriteLine($"Sharpness: {Sharpness}");
    }
}
