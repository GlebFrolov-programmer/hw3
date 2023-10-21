using static System.Console;

Stack stack = new Stack(); // стек
string cmd = null; // пользовательская команда
int pushNum; // добавляемое число

WriteLine("Commands: 'pop', 'back', 'size', 'clear', 'print', 'exit', 'push'");
do
{
    Write("cmd: ");
    cmd = ReadLine();

    switch (cmd)
    {
        case "pop":
            WriteLine(stack.Pop());
            break;
        case "back":
            WriteLine(stack.Peek());
            break;
        case "size":
            WriteLine(stack.Size());
            break;
        case "clear":
            WriteLine(stack.Clear());
            break;
        case "print":
            stack.Print();
            break;
        case "exit":
            WriteLine("Thank you, goodbye ;)");
            break;
        default:
            if (cmd != null && cmd.Length > 5
                && cmd.Substring(0, 5) == "push "
                && int.TryParse(cmd.Substring(5), out pushNum))
            {
                WriteLine(stack.Push(pushNum));
            }
            else
            {
                WriteLine("This command unsupported! Try again...");
            }
            break;
    }
} while (cmd != "exit");


struct Stack
{
    private int[]? stack;
    private int length;

    // конструктор
    public Stack()
    {
        stack = new int[10];
        length = 0;
    }

    // изменить размер стека
    private void Resize()
    {
        if (stack != null) Array.Resize(ref stack, stack.Length * 2);
    }

    // добавить элемент в стек
    public string Push(int value)
    {
        if (length == 100) return "Stack overflow!";

        if (stack.Length == length) Resize();

        stack[length++] = value;
        return "Your value was pushed!";
    }

    // удалить крайний элемент из стека
    public string Pop()
    {
        if (length == 0) return "Stack is empty!";

        return stack[(length--) - 1].ToString();
    }

    // посмотреть крайний элемент стека
    public string Peek()
    {
        if (length == 0) return "Stack is empty!";

        return stack[length - 1].ToString();
    }

    // посмотреть размер стека
    public string Size()
    {
        return length.ToString();
    }

    // очистить стек
    public string Clear()
    {
        stack = new int[10];
        length = 0;

        return "Stack was cleared!";
    }

    // вывод очереди на экран
    public void Print()
    {
        Write("[");
        for(int i = 0; i < length; i++){
            if(i == length - 1){
               Write(stack[i]);
               break;
            }
            Write(stack[i] + ",");
        }
        WriteLine("]");
    }
}