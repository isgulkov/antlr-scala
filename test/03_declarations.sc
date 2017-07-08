object Main
{
	def main(args: Array[String])
	{
		var x = 1000;

		print("x declared in outer scope equals ");
		println(x);

		x = 2500;

		print("x got reassigned to ");
		println(x);

		for(p <- 1 to 1) {
            var y = 1500;
            
            print("y declared in a block equals ");
		    println(y);
		}

		var z;
		z = 2000;

		print("z assigned after declaration equals ");
		println(z);
	}
}
