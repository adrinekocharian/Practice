using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NugetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(RunOptions)
                .WithNotParsed(HandleParseError);

            //foreach (var item in args)
            //{
            //    Console.WriteLine(item);
            //}

            if(args.Contains("--create-account"))
            {
                //
            }
            if(args.Contains(""))
            {
                //
            }
            Console.WriteLine("Hello World!");

            Console.ReadLine();
        }

        static void RunOptions(Options opts)
        {
            if (opts.stdin)
            {
                Console.WriteLine("print on console");
            }
            if (opts.InputFiles != null && opts.InputFiles.Any())
            {
                foreach (var item in opts.InputFiles)
                {
                    Console.WriteLine(item);
                }
            }
            //handle options
        }
        static void HandleParseError(IEnumerable<Error> errs)
        {
            //handle errors
        }
    }
}
