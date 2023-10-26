using static System.Console;

Queue queue = new Queue(); // стек
string cmd = null; // пользовательская команда
int pushNum; // добавляемое число

WriteLine("Commands: 'pop', 'front', 'size', 'clear', 'print', 'exit', 'push'");
do
{
    Write("cmd: ");
    cmd = ReadLine();

    switch (cmd)
    {
        case "pop":
            WriteLine(queue.Pop());
            break;
        case "front":
            WriteLine(queue.Peek());
            break;
        case "size":
            WriteLine(queue.Size());
            break;
        case "clear":
            WriteLine(queue.Clear());
            break;
        case "exit":
            WriteLine("Thank you, goodbye ;)");
            break;
        case "print":
            queue.Print();
            break;
        default:
            if (cmd != null && cmd.Length > 5 && cmd.Substring(0, 5) == "push "
                                    && int.TryParse(cmd.Substring(5), out pushNum))
            {
                WriteLine(queue.Push(pushNum));
            }
            else
            {
                WriteLine("This command unsupported! Try again...");
            }

            break;
    }
} while (cmd != "exit");

struct Queue
{
    private int[] queue;
    private int length;

    // конструктор
    public Queue()
    {
        queue = new int[10];
        length = 0;
    }

    // изменить размер очереди
    private void Resize()
    {
        if (queue != null) Array.Resize(ref queue, queue.Length * 2);
    }

    // добавить элемент в очередь
    public string Push(int value)
    {
        if (queue.Length == length) Resize();

        queue[length++] = value;
        return "Your value was pushed!";
    }

    // удалить крайний элемент из очереди
    public string Pop()
    {

        if (length == 0) return "Queue is empty!";


        int retVal = queue[0];

        for (int i = 0; i < length - 1; i++)
        {
            queue[i] = queue[i + 1];
        }

        length--;

        return retVal.ToString();
    }

    // посмотреть крайний элемент очереди
    public string Peek()
    {
        if (length == 0) return "Queue is empty!";

        return queue[0].ToString();
    }

    // получить размер очереди
    public string Size()
    {
        return length.ToString();
    }

    // очистить очередь
    public string Clear()
    {
        queue = new int[10];
        length = 0;

        return "Stack was cleared!";
    }

    // вывод очереди на экран
    public void Print()
    {
        Write("[");
        for(int i = 0; i < length; i++){
            if(i == length - 1){
                Write(queue[i]);
                break;
            }
            Write(queue[i] + " -> ");
        }
        WriteLine("]");
    }
}
