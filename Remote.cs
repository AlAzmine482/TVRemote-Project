using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Threading.Channels;


namespace TvRemoteExample
{

    public class TVRemote

    {

        public string RemoteID = "TM-1240A";
        // private unsupportedtv faketv;
        private readonly Tvmodel1 _screen;
        private readonly string[] supportedModels = {
            "UN75TU7000", "UN70TU7000", "UN65TU7000",
            "UN58TU7000", "UN55TU7000", "UN50TU7000",
            "UN43TU7000"
        };

        public TVRemote(Tvmodel1 screen)
        {
            _screen = screen;


        }


        public void CheckSupportedModels(TvDevice tvScreen)
        {
            if (supportedModels.Contains(tvScreen.ModelName))
            {
                Console.WriteLine("TVModel is Supported");
                Console.WriteLine($"TVModel: {tvScreen.ModelName}");
                Console.WriteLine($"TVRemote: {RemoteID}");
                Console.WriteLine("Welcome to the TV Remote! Ready to control your TV.");
                DisplayMenu(tvScreen);
            }
            else
            {
                Console.WriteLine("TVModel is not Supported");
                Console.WriteLine($"TVModel: {tvScreen.ModelName}");
                Console.WriteLine($"TVRemote: {RemoteID} is not supported for this TVModel:{tvScreen.ModelName}");

            }



        }


        public void PowerButton(TvDevice tvScreen)
        {
            if (tvScreen.IsOn == true)
            {
                tvScreen.TurnOff();
                Console.WriteLine("Tv Now off!");
            }
            else
            {
                tvScreen.TurnOn();
                Console.WriteLine("Tv Now on!");
            }

        }
        public void DisplayMenu(TvDevice tvScreen)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n--- TV Remote Menu ---");
                Console.WriteLine("1) Turn On/Off TV");
                Console.WriteLine("2) Change Channel");
                Console.WriteLine("3) Display Smart Menu");
                Console.WriteLine("4) Volume up or Volume Down");
                Console.WriteLine("5) Mute");
                Console.WriteLine("6) Change Channel");
                Console.WriteLine("7) Settings");
                Console.WriteLine("8) Help");
                Console.WriteLine("9) Exit");
                Console.Write("Choose an option: ");

                string? input = Console.ReadLine();


                switch (input)
                {
                    case "1":
                        PowerButton(tvScreen);

                        break;
                    case "2":
                        ChannelButton(tvScreen);
                        break;
                    case "3":
                        SmartMenu(tvScreen);
                        break;
                    case "4":
                        Volumebutton(tvScreen);
                        break;
                    case "5":
                        Mute(tvScreen);
                        break;
                    case "6":
                        ChangeChannel(tvScreen);
                        break;
                    case "7":
                        Settings(tvScreen);
                        break;
                    case "8":
                        Help();
                        break;
                    case "9":
                        Console.WriteLine("Exiting the remote control.");
                        //Environment.Exit(0);
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please choose again.");
                        break;
                }
            }

        }

        private void ChannelButton(TvDevice tvScreen)
        {
            Console.WriteLine("Press  up arrow to increase or press down arrow to decrease");
            var keyInput = Console.ReadKey();
            switch (keyInput.Key)
            {
                case ConsoleKey.UpArrow:
                    tvScreen.channelUp();
                    Console.WriteLine("Volume up button pressed");
                    break;
                case ConsoleKey.DownArrow:
                    tvScreen.channelDown();
                    Console.WriteLine("Volume Down button pressed");
                    break;


            }


        }

        public void Volumebutton(TvDevice tvScreen)
        {
            Console.WriteLine("Press  up arrow to increase or press down arrow to decrease");
            var keyInput = Console.ReadKey(intercept: true);
            switch (keyInput.Key)
            {
                case ConsoleKey.UpArrow:
                    tvScreen.volumeUp();
                    Console.WriteLine("Volume up button pressed");
                    break;
                case ConsoleKey.DownArrow:
                    tvScreen.volumeDown();
                    Console.WriteLine("Volume Down button pressed");
                    break;
            }

        }




        public void Mute(TvDevice tvScreen)
        {
            tvScreen.mute();
        }



        public void SmartMenu(TvDevice tvScreen)
        {
            //Web browsing, Sports content, Music Streaming, Videos, Apps and games, settings, content categories, program search
            Console.WriteLine("\n--- Smart Menu ---");
            Console.WriteLine("1) Apps and Services");
            //Console.WriteLine("2) Return");
            Console.WriteLine("3) Samsung Apps Store");
            Console.WriteLine("4) Settings");
            Console.WriteLine("5) Help and Support");
            string? input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("1) Apps and Services Include: Amazon Prime Video, Netflix, Hulu, Disney+");
                    break;
                case "2":
                    //  DisplayMenu();
                    break;
                case "3":
                    Console.WriteLine("Samsung App Store");
                    break;
                case "4":
                    Settings(tvScreen);
                    break;
                case "5":
                    Help();
                    break;
                case "6":
                    Console.WriteLine("Exiting the remote control.");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option, please choose again.");
                    break;
            }
        }


        public void ChangeChannel(TvDevice tvScreen)
        {
            Console.WriteLine("Enter the channel number ");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int channel))
            {

                tvScreen.ChannelNumber(channel);
            }
            else
            {
                Console.WriteLine("Invalid Input! Please enter Integers");
            }
        }

        public void Settings(TvDevice tvScreen)
        {
            //Picture Settings, Sound Settings, Channel Settings, Network Settings, System Information, General Settings, Advance Settings Smart Features?

            Console.WriteLine("\n--- Settings Menu ---");
            Console.WriteLine("1) Picture Settings");
            Console.WriteLine("2) Sound Settings");
            Console.WriteLine("3) Samsung Apps Store");
            Console.WriteLine("4) System Information");
            Console.WriteLine("5) Return");
            string? input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    pictureSettings(tvScreen);
                    break;
                case "2":
                    Volumebutton(tvScreen);
                    break;
                case "3":
                    SamsungAppStore();
                    break;
                case "4":
                    SystemInformation(tvScreen);
                    break;
                case "5":
                    Console.WriteLine("Returning to Main Menu.");
                    //DisplayMenu();
                    break;
                default:
                    Console.WriteLine("Invalid option, please choose again.");
                    break;
            }

        }
        public void Help()
        {

            Console.WriteLine("\n--- Help Menu ---");
            Console.WriteLine("1) **Turn On/Off TV**: This option allows you to turn the TV on or off.");
            Console.WriteLine("2) **Change Channel**: Enter a channel number to switch to a specific channel.");
            Console.WriteLine("3) **Display Smart Menu**: Can access apps, streaming services, and settings specific to smart features.");
            Console.WriteLine("4) **Volume Up or Volume Down**: Adjust the TV’s volume.");
            Console.WriteLine("5) **Mute**: Instantly mute the sound of your TV.");
            Console.WriteLine("6) **Change Channel**: Enter numbers to change Channel.");
            Console.WriteLine("7) **Settings**: Access the TV’s settings menu .");
            Console.WriteLine("8) **Help**: Explain the functions of each option.");
            Console.WriteLine("9) **Exit**: Exit the TV Remote menu and return to the main program.");
        }

        public void pictureSettings(TvDevice tvScreen)
        {
            Console.WriteLine("\n--- Picture Settings Menu ---");
            Console.WriteLine("1) Brightness");
            Console.WriteLine("2) Contrast");
            Console.WriteLine("3) Sharpness");


            string? input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    brightnesschange(tvScreen);
                    break;
                case "2":
                    contrastChange(tvScreen);
                    break;
                case "3":
                    sharpness(tvScreen);
                    break;
                case "4":
                    Console.WriteLine("Returning to Main Menu.");
                    //DisplayMenu();
                    break;
                default:
                    Console.WriteLine("Invalid option, please choose again.");
                    break;
            }
        }



        public void SystemInformation(TvDevice tvScreen)
        {
            tvScreen.Model();
            tvScreen.countryofOrgin();
            tvScreen.Screensize();
            tvScreen.UPCCODe();
        }

        public void brightnesschange(TvDevice tvScreen)
        {
            Console.WriteLine("Press  up arrow to increase or press down arrow to decrease");
            var keyInput = Console.ReadKey(intercept: true);
            switch (keyInput.Key)
            {
                case ConsoleKey.UpArrow:
                    tvScreen.BrightnessUp();

                    break;
                case ConsoleKey.DownArrow:
                    tvScreen.BrightnessDown();

                    break;
            }

        }

        public void contrastChange(TvDevice tvScreen)
        {
            Console.WriteLine("Press  up arrow to increase or press down arrow to decrease");
            var keyInput = Console.ReadKey(intercept: true);
            switch (keyInput.Key)
            {
                case ConsoleKey.UpArrow:
                    tvScreen.ContrastUp();
                    Console.WriteLine("Up button pressed");
                    break;
                case ConsoleKey.DownArrow:
                    tvScreen.ContrastDown();

                    break;
            }
        }

        public void sharpness(TvDevice tvScreen)
        {
            Console.WriteLine("Press  up arrow to increase or press down arrow to decrease");
            var keyInput = Console.ReadKey(intercept: true);
            switch (keyInput.Key)
            {
                case ConsoleKey.UpArrow:
                    tvScreen.SharpnessUp();

                    break;
                case ConsoleKey.DownArrow:
                    tvScreen.SharpnessDown();

                    break;
            }

        }
        public void SamsungAppStore()
        {

            Console.WriteLine("\n--- Picture Settings Menu ---");
            Console.WriteLine("1) Apple TV");
            Console.WriteLine("2) Samsung TV Plus");
            Console.WriteLine("3) Netflix");
            string? input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Now in Apple TV");
                    break;
                case "2":
                    Console.WriteLine("Now in Samsung TV Plus");
                    break;
                case "3":
                    Console.WriteLine("Netflix");
                    break;

            }






        }
    }
}