md \test\compiled

res\ScalaTranslator.exe test\01_assisty.sc test\compiled\01_assisty.cs
"C:\Program Files\MSBuild\14.0\Bin\csc.exe" test\compiled\01_assisty.cs /out:test\compiled\01_assisty.exe
test\compiled\01_assisty.exe

res\ScalaTranslator.exe test\02_for_loop.sc test\compiled\02_for_loop.cs
"C:\Program Files\MSBuild\14.0\Bin\csc.exe" test\compiled\02_for_loop.cs /out:test\compiled\02_for_loop.exe
test\compiled\02_for_loop.exe

res\ScalaTranslator.exe test\03_declarations.sc test\compiled\03_declarations.cs
"C:\Program Files\MSBuild\14.0\Bin\csc.exe" test\compiled\03_declarations.cs /out:test\compiled\03_declarations.exe
test\compiled\03_declarations.exe

res\ScalaTranslator.exe test\04_precedence.sc test\compiled\04_precedence.cs
"C:\Program Files\MSBuild\14.0\Bin\csc.exe" test\compiled\04_precedence.cs /out:test\compiled\04_precedence.exe
test\compiled\04_precedence.exe

res\ScalaTranslator.exe test\05_nested_loops.sc test\compiled\05_nested_loops.cs
"C:\Program Files\MSBuild\14.0\Bin\csc.exe" test\compiled\05_nested_loops.cs /out:test\compiled\05_nested_loops.exe
test\compiled\05_nested_loops.exe

res\ScalaTranslator.exe test\06_comparison_ops.sc test\compiled\06_comparison_ops.cs
"C:\Program Files\MSBuild\14.0\Bin\csc.exe" test\compiled\06_comparison_ops.cs /out:test\compiled\06_comparison_ops.exe
test\compiled\06_comparison_ops.exe

res\ScalaTranslator.exe test\07_literals.sc test\compiled\07_literals.cs
"C:\Program Files\MSBuild\14.0\Bin\csc.exe" test\compiled\07_literals.cs /out:test\compiled\07_literals.exe
test\compiled\07_literals.exe

