using System;
using System.IO;
using System.Linq;
using System.Threading;
using hb.Business;
using hb.Business.Types;
using hb.Helper.Extensions;

namespace hb
{
    class Program
    {
        static void Main(string[] args)
        {
            Intro();
            Start();
        }

        private static void Start()
        {
            Console.WriteLine();
            Console.WriteLine("How do you want to drive? (K/F)");
            Console.WriteLine("      K: Drive by Keyboard Input.");
            Console.WriteLine("      F: Drive by *.txt File Input.");
            Console.WriteLine("      E: Exit.");
            Field field = null;
            var input = Console.ReadLine();

            if (input != null)
                switch (input.ToLower())
                {
                    case "k":
                        field = DriveByKeyboard();
                        break;

                    case "f":
                        field = DriveByFile();
                        break;

                    case "e":
                        return;

                    default:
                        Console.WriteLine("Please enter a valid choice...");
                        Start();
                        break;
                }
            else
            {
                Console.WriteLine("Please enter a valid choice...");
                Start();
            }

            if (field != null)
            {
                field.HandleMoves();
                if (field.IsValid())
                {
                    Console.WriteLine("Mission Completed!");
                    foreach (var vehicle in field.Vehicles)
                    {
                        Console.WriteLine(vehicle);
                    }

                    Console.WriteLine("Press any key to exit.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("One or more Rover gone out of the field boundaries.");
                }
            }
        }

        private static Field DriveByFile()
        {
            var filesPath = Path.Combine(Environment.CurrentDirectory, "InputFiles");
            var fileList = Directory.EnumerateFiles(filesPath, "*.txt").ToList();
            Console.WriteLine();
            if (fileList.Count == 0)
            {
                Console.WriteLine($"*.txt File Not Found at {filesPath} folder.");
                return null;
            }
            var i = 1;
            Console.WriteLine("Please Select File");

            foreach (var file in fileList)
            {

                Console.WriteLine($"      {i}: {Path.GetFileName(file)}");
                i++;
            }

            var selectedFile = Console.ReadLine();
            var selectedFileIndex = int.Parse(selectedFile ?? throw new InvalidOperationException());
            if (selectedFileIndex > fileList.Count)
            {
                Console.WriteLine("Invalid Input!");
                return null;
            }
            var fileText = File.ReadAllText(@fileList[selectedFileIndex - 1]);

            Console.WriteLine();
            Console.WriteLine("Input:");
            Console.WriteLine(fileText);
            Console.WriteLine("");
            var splittedText = fileText.Split(new[] { "\n" }, StringSplitOptions.None);
            var boundry = ParseBoundry(splittedText[0].Replace("\r", string.Empty));
            var rover1Position = ParsePosition(splittedText[1].Replace("\r", string.Empty));
            var rover1MoveSet = ParseMoveSet(splittedText[2].Replace("\r", string.Empty));
            var rover2Position = ParsePosition(splittedText[3].Replace("\r", string.Empty));
            var rover2MoveSet = ParseMoveSet(splittedText[4].Replace("\r", string.Empty));

            var field = new Field(boundry);
            field.Vehicles.Add(new Vehicle(rover1Position, rover1MoveSet));
            field.Vehicles.Add(new Vehicle(rover2Position, rover2MoveSet));
            return field;
        }

        private static Field DriveByKeyboard()
        {
            var boundry = GetBoundries();
            var rover1Position = GetPosition(1);
            var rover1MoveSet = GetMoveSet(1);
            var rover2Position = GetPosition(2);
            var rover2MoveSet = GetMoveSet(2);

            var field = new Field(boundry);
            field.Vehicles.Add(new Vehicle(rover1Position, rover1MoveSet));
            field.Vehicles.Add(new Vehicle(rover2Position, rover2MoveSet));
            return field;
        }

        private static Boundry GetBoundries()
        {
            Console.WriteLine("Please Enter Field Boundaries like 55");
            var boundariesInput = Console.ReadLine();
            if (boundariesInput != null)
            {
                var boundry = ParseBoundry(boundariesInput);
                if (boundry != null)
                    return boundry;
            }
            return GetBoundries();
        }

        private static Boundry ParseBoundry(string boundariesInput)
        {
            var boundaries = boundariesInput.ToUpper().ToCharArray();
            if (boundaries.Length != 2)
            {
                Console.WriteLine("Invalid Input!");
            }
            else
            {
                try
                {
                    return new Boundry(int.Parse(boundaries[0].ToString()), int.Parse(boundaries[1].ToString()));
                }
                catch
                {
                    Console.WriteLine("Invalid Input!");
                    throw;
                }
            }

            return null;
        }

        private static Position GetPosition(int i)
        {
            Console.WriteLine($"Please Enter {i.AddOrdinal()} Rover's Position like 12N");
            var positionInput = Console.ReadLine();
            if (positionInput != null)
            {
                var position = ParsePosition(positionInput);
                if (position != null)
                {
                    return position;
                }
            }
            return GetPosition(i);
        }

        private static Position ParsePosition(string positionInput)
        {
            var positionParams = positionInput.ToUpper().ToCharArray();
            if (positionParams.Length != 3)
            {
                Console.WriteLine("Invalid Input!");
            }
            else
            {
                try
                {
                    return new Position(int.Parse(positionParams[0].ToString()), int.Parse(positionParams[1].ToString()), Enum.Parse<Enums.Direction>(positionParams[2].ToString()));
                }
                catch
                {
                    Console.WriteLine("Invalid Input!");
                    throw;
                }

            }

            return null;
        }

        private static MoveSet GetMoveSet(int i)
        {
            Console.WriteLine($"Please Enter {i.AddOrdinal()} Rover's Move Set like LMRMLMMM by using L,R,M");
            var movesInput = Console.ReadLine();
            if (movesInput != null)
            {
                var moveset = ParseMoveSet(movesInput);
                if (moveset != null)
                {
                    return moveset;
                }

            }
            return GetMoveSet(i);
        }

        private static MoveSet ParseMoveSet(string movesInput)
        {
            var moveSet = new MoveSet(movesInput.ToUpper());
            if (moveSet.IsValid())
            {
                return moveSet;
            }
            else
            {
                Console.WriteLine("Invalid Input!");
            }

            return null;
        }

        #region Intro

        private static void Intro()
        {
            Console.Clear();


            Console.WriteLine();

            var margin = "".PadLeft(15);

            Console.WriteLine("  +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+");

            Console.WriteLine(margin + "##    ##       ###        ######        ###");
            Console.WriteLine(margin + "###   ##      ## ##      ##    ##      ## ##");
            Console.WriteLine(margin + "####  ##     ##   ##     ##           ##   ##");
            Console.WriteLine(margin + "## ## ##    ##     ##     ######     ##     ##");
            Console.WriteLine(margin + "##  ####    #########          ##    #########");
            Console.WriteLine(margin + "##   ###    ##     ##    ##    ##    ##     ##");
            Console.WriteLine(margin + "##    ##    ##     ##     ######     ##     ##");
            Console.WriteLine("  +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+");



            Console.WriteLine();
            Console.WriteLine("Welcome to NASA Rover Driver APP!");
        }

        #endregion Intro
    }
}
