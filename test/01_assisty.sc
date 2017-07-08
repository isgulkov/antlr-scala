object Main
{
	def main(args: Array[String])
	{
		var a = 1;
		while(a < 1024) {
			println(a);
			a = a<<1;
		}
	}
}
