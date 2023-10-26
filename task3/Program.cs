using static System.Console;
string text;
int res = 0;

do
{
    WriteLine("Input text for check string: ");
    text = ReadLine();
    res = CheckText(text);

    switch (res)
    {
        case -2:
            WriteLine("Input is not correct!");
            break;
        case -1:
            WriteLine("Input is correct!");
            break;
        default:
            WriteLine(res);
            break;
    }

} while (text != null);


int CheckText(string text)
{
    // если передан указатель на null или пустая строка
    if (text.Length == 0)
    {
        return -2;
    }

    int leftParentheseIndex; // индекс открывающей скобки
    int rightParentheseIndex; // индекс закрывающей скобки
    int trimmedSymb = 0; // число отброшенных символов

    // выполнять цикл пока в тексте есть непроверенные скобки
    do
    {
        leftParentheseIndex = text.IndexOf('(');
        rightParentheseIndex = text.IndexOf(')');

        // если отсутствует открывающая скобка, но присутствует закрываюшая
        if (leftParentheseIndex == -1 && rightParentheseIndex != -1)
        {
            // вернуть индекс закрывающей скобки
            return rightParentheseIndex + trimmedSymb;
        }
        // если присутствует открывающая скобка но отсутствует закрывающая
        else if (leftParentheseIndex != -1 && rightParentheseIndex == -1)
        {
            // вернуть число открывающих скобок, начиная с позиции первой лишней открывающей скобки
            text = text.Substring(leftParentheseIndex);
            return text.Length - text.Replace("(", "").Length;
        }
        // если индекс открывающей скобки меньше индекса закрывающей
        else if (leftParentheseIndex < rightParentheseIndex)
        {
            // если из строки возможно выделить подстроку
            if (text.Length > rightParentheseIndex + 1)
            {
                trimmedSymb += rightParentheseIndex + 1;
                text = text.Substring(rightParentheseIndex + 1);
                continue;
            }

            // если закрывающая скобка была последним символом строки
            break;
        }
        // если индекс открывающей скобки больше индекса закрывающей
        else if (leftParentheseIndex > rightParentheseIndex)
        {
            // вернуть индекс закрывающей скобки
            return rightParentheseIndex + trimmedSymb;
        }
    } while (leftParentheseIndex != -1 && rightParentheseIndex != -1);

    return -1;
}