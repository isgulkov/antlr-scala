java -jar antlr-4.7-complete.jar Scala.g4 -o src
"C:\Program Files\MSBuild\14.0\Bin\MSBuild.exe" src\ScalaTranslator.sln
md \res
xcopy src\bin\Debug\* res /y
