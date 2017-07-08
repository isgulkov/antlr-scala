object Main
{
	def main(args: Array[String])
	{
	    for(i <- 8 to 10) {
            for(j <- 8 to 10) {
                var k = 8;
                
                while(k < 11) {
                    print(i);
                    print(" ");
                    print(j);
                    print(" ");
                    print(k);
                    println();                    
                }            
            }	    
	    }
	    
	    println("(expected all triples of 8, 9, 10)");
	}
}
