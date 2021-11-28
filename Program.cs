using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRZ
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 3)
            {
                QRZ qrz = new QRZ(args[0], args[1], null);
                if (qrz.isOnline == false)
                {
                    Console.WriteLine("Unable to connect to QRZ...check name/passwd");
                    return 1;
                }
                if (qrz.GetCallsign(args[2], out bool cached))
                {
                    string value = $"Found {args[2]} Cached: {cached}";
                    Console.WriteLine(value: value);
                    return 0;
                }
                else
                {
                    Console.WriteLine(value: $"{args[2]} bad");
                    return 1;
                }
                
            }
            else
            {
                Console.WriteLine(value: "QRZ Version 1.0 by W9MDB");
                Console.WriteLine(value: "Expected 3 arguments: login passwd callsign");
                Console.Write(value: "Received " + args.Length + " arguments:");
                for (int i = 0; i < args.Length; ++i) Console.Write(" " + args[i]);
                Console.WriteLine("");
            }
            return 1;
        }
    }
}
