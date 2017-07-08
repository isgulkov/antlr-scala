java -jar antlr-4.7-complete.jar Scala.g4 -o src
xbuild src/ScalaTranslator.sln
mkdir -p ./res
cp src/bin/Debug/* ./res
