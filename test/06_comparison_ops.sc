object Main
{
	def main(args: Array[String])
	{
	    var x = "priv";
	    
	    while(x == "priv") {
            print("priv ");
            x = "ne priv";
	    }
	    
	    var y = 100L;
	    
	    while(y > 99L) {
	        print("priv ");
	        y = 99L;
	    }
	    
	    var z = 100;
	    
	    while(z < 100) {
            print("priv ");
            z = 200;	    
	    }
	    
	    var w = 10000;
	    
	    while(w == 1000 * 1000 / 10 / 10) {
	        print("priv ");
	        w = 1337;
	    }
	    
	    println();
	    println("(three privs expected)");
	}
}
