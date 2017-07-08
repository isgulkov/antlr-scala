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

		static string PrintExpression(ScalaParser.ExpressionContext context)
		{
			if(context.expression() != null) {
				return $"{PrintExpression(context.comparativeExpr())} = {PrintExpression(context.expression())}";
			}
			else {
				return PrintExpression(context.comparativeExpr());
			}
		}

		static string PrintExpression(ScalaParser.ComparativeExprContext context)
		{
			if(context.comparativeExpr() != null) {
				return $"{PrintExpression(context.comparativeExpr())}" +
					$" {context.children[1].GetText()} {PrintExpression(context.multiplicativeExpr())}";
			}
			else {
				return PrintExpression(context.multiplicativeExpr());
			}
		}

		static string PrintExpression(ScalaParser.MultiplicativeExprContext context)
		{
			if(context.multiplicativeExpr() != null) {
				return $"{PrintExpression(context.multiplicativeExpr())}" +
					$" {context.children[1].GetText()} {PrintExpression(context.bitshiftExpr())}";
			}
			else {
				return PrintExpression(context.bitshiftExpr());
			}
		}

		static string PrintExpression(ScalaParser.BitshiftExprContext context)
		{
			if(context.bitshiftExpr() != null) {
				return $"({PrintExpression(context.bitshiftExpr())}" +
					$" {context.children[1].GetText()} {PrintExpression(context.primaryExpr())})";
			}
			else {
				return PrintExpression(context.primaryExpr());
			}
		}

		static string PrintExpression(ScalaParser.PrimaryExprContext context)
		{
			if(context.expression() != null) {
				return $"({PrintExpression(context.expression())})";
			}
			else {
				return context.GetText();
			}
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
				OutLine($"dynamic {context.ID().GetText()};");
			}
			else {
				OutLine($"dynamic {context.ID().GetText()} = {PrintExpression(context.expression())};");
			}
		}

		public override void EnterWhileStmt(ScalaParser.WhileStmtContext context)
		{
            OutLine($"while({PrintExpression(context.expression())}) {{");
		}

		public override void ExitWhileStmt(ScalaParser.WhileStmtContext context)
		{
			OutLine("}");
		}

		public override void EnterForStmt(ScalaParser.ForStmtContext context)
		{
			Out($"foreach(var {context.ID().GetText()} in ");

            Out($"Range({PrintExpression(context.expression()[0])}, {PrintExpression(context.expression()[1])})");

			OutLine(") {");
		}

		public override void ExitForStmt(ScalaParser.ForStmtContext context)
		{
			OutLine("}");
		}

		public override void EnterPrintStmt(ScalaParser.PrintStmtContext context)
		{
			if(context.expression() != null) {
                OutLine($"Console.Write({PrintExpression(context.expression())});");
			}
		}

		public override void EnterPrintlnStmt(ScalaParser.PrintlnStmtContext context)
		{
			if(context.expression() != null) {
                OutLine($"Console.WriteLine({PrintExpression(context.expression())});");
			}
			else {
                OutLine("Console.WriteLine();");
			}
		}

		public override void EnterStatement(ScalaParser.StatementContext context)
		{
			if(context.expression() != null) {
				OutLine($"{PrintExpression(context.expression())};");
			}
		}
	}
}
