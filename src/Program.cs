﻿using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace ScalaTranslator
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			if(args.Length != 2) {
				Console.WriteLine("usage: ScalaTranslator.exe [input file] [output file]");
				Environment.Exit(1);
			}

			string input = File.ReadAllText(args[0]);

			var ms = new MemoryStream(Encoding.UTF8.GetBytes(input));
			var lexer = new ScalaLexer(new AntlrInputStream(ms));

			var tokens = new CommonTokenStream(lexer);

			var parser = new ScalaParser(tokens);

			var tree = parser.file();

			var pastwk = new ParseTreeWalker();

			pastwk.Walk(new ScalaNormListener(args[1]), tree);
		}
	}
}
