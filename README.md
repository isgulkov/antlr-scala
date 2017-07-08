Название: Подмножество языка Scala

Операторы: +, -, *, /, var, >>, <<, ==, print, println, <, >

Сложные операторы(фичи): while, for

Типы: int long string

Пример кода:

```
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
```

Ожидаемый вывод:

```
1 2 4 8 16 32 64 128 256 512
```

Справка: http://www.tutorialspoint.com/scala/
