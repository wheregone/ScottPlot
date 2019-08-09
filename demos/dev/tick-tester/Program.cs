﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tick_tester
{
    class Program
    {
        static void Main(string[] args)
        //all comments to be stripped out when done
        //right click on output window and uncheck "Exception messages" to clean output
        {

            double bigNumber = Math.Pow(23.456, 9);
            double smallNumber = Math.Pow(23.456, -9);

            DisplayTicksForRange(-bigNumber, bigNumber);
            DisplayTicksForRange(9876 * bigNumber, 9877 * bigNumber);
            DisplayTicksForRange(-smallNumber, smallNumber);
            DisplayTicksForRange(9876 * smallNumber, 9877 * smallNumber);

            /*
            DisplayTicksForRange(-10, 10);
            DisplayTicksForRange(-50, 50);
            DisplayTicksForRange(-77, 123);
            DisplayTicksForRange(-12345678, -12345678 + 1);
            DisplayTicksForRange(-1234567812345678, -1234567812345678 + 1);
            DisplayTicksForRange(.00000010, .00000011);
            DisplayTicksForRange(.0000001000001, .0000001000002); //does not render correctly
            DisplayTicksForRange(100000001, 200000001);

            DisplayTicksForTime(new DateTime(1492, 10, 12), new DateTime(1776, 10, 3)); //years
            DisplayTicksForTime(new DateTime(1915, 1, 1), new DateTime(1918, 1, 1));  //months
            DisplayTicksForTime(new DateTime(2019, 6, 1, 6, 0, 0), new DateTime(2019, 6, 1, 11, 12, 15)); //hours
            DisplayTicksForTime(new DateTime(2019, 6, 1, 6, 0, 0), new DateTime(2019, 6, 1, 6, 12, 15)); //minutes
            DisplayTicksForTime(new DateTime(2019, 6, 1, 6, 12, 0), new DateTime(2019, 6, 1, 6, 12, 15)); //seconds
            DisplayTicksForTime(DateTime.Now, DateTime.Now);
            */

            Console.WriteLine();

        }

        static void DisplayTicksForRange(double low, double high)
        {
            double[] tickPositions;

            tickPositions = ScottPlot.TicksExperimental.GetTicks(low, high);
            ScottPlot.TicksExperimental.GetMantissasExponentOffset(tickPositions, out double[] tickPositionsMantissas, out int tickPositionsExponent, out double offset);
            string multiplierString = ScottPlot.TicksExperimental.GetMultiplierString(offset, tickPositionsExponent);

            Console.WriteLine($"\nValue range: [{low}, {high}]");
            Console.Write("  tick labels: ");
            foreach (double tickPositionsMantissa in tickPositionsMantissas)
                Console.Write(tickPositionsMantissa + "  ");
            Console.WriteLine($"\n  modifier: {multiplierString}");

        }
        static void DisplayTicksForTime(DateTime low, DateTime high)
        {

            double[] tickPositions = ScottPlot.TicksExperimental.GetTicksForTime(low, high);

            Console.WriteLine($"\nTime range: [{low}, {high}]");
            Console.Write("  tick labels: ");
            foreach (double tickPosition in tickPositions)
                Console.Write(tickPosition + "  ");
            Console.WriteLine();
        }

    }
}