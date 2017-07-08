using System;
using System.IO;

namespace ScalaTranslator
{
	public class ScalaNormListener : ScalaBaseListener
	{
		readonly string OutputFilename;
		StreamWriter OutputWriter;

		public ScalaNormListener(string outputFilename)
		{
			OutputFilename = outputFilename;

			OutputWriter = new StreamWriter(File.Open(OutputFilename, FileMode.Create));
			OutputWriter.AutoFlush = true;
		}

		void Out(string s)
		{
			OutputWriter.Write(s);
		}

		void OutLine(string s)
		{
			OutputWriter.WriteLine(s);
		}

		void PrintErrorAndExit(int error_code, string message)
		{
			Console.WriteLine($"Error {error_code}: {message}");

			OutputWriter.Close();
			File.Delete(OutputFilename);

			Environment.Exit(1);
		}

		public override void EnterFile(ScalaParser.FileContext context)
		{
            OutLine("using System;");
			OutLine("using System.Linq;");
            OutLine("using System.Collections.Generic;");
			OutLine("");
			OutLine("class Program {");
            OutLine("static IEnumerable<int> Range(int start, int end)");
			OutLine("{");
			OutLine("return Enumerable.Range(start, end - start + 1);");
			OutLine("}");
			OutLine("");
            OutLine("public static void Main() {");
		}

		public override void ExitFile(ScalaParser.FileContext context)
		{
			OutLine("}");
            OutLine("}");
		}

		public override void EnterDeclarationStmt(ScalaParser.DeclarationStmtContext context)
		{
			if(context.expression() == null) {
				OutLine($"object {context.ID().GetText()};");
			}
			else {
				OutLine($"var {context.ID().GetText()} = {context.expression().GetText()};");
			}
		}

		public override void EnterWhileStmt(ScalaParser.WhileStmtContext context)
		{
			OutLine($"while({context.expression().GetText()}) {{");
		}

		public override void ExitWhileStmt(ScalaParser.WhileStmtContext context)
		{
			OutLine("}");
		}

		public override void EnterForStmt(ScalaParser.ForStmtContext context)
		{
			Out($"foreach(var {context.ID().GetText()} in ");

			Out($"Enumerable.Range({context.expression()[0]}, {context.expression()[0]})");

			OutLine(") {");
		}

		public override void ExitForStmt(ScalaParser.ForStmtContext context)
		{
			OutLine("}");
		}

		public override void EnterPrintStmt(ScalaParser.PrintStmtContext context)
		{
			if(context.expression() != null) {
				OutLine($"Console.Write({context.expression().GetText()});");
			}
		}

		public override void EnterPrintlnStmt(ScalaParser.PrintlnStmtContext context)
		{
			if(context.expression() != null) {
				OutLine($"Console.WriteLine({context.expression().GetText()});");
			}
			else {
                OutLine("Console.WriteLine();");
			}
		}
	}
}
