namespace EviusChess;

public static class Utils
{
    private static readonly string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static int ToInt(string input)
    {
        if (input.Length != 1)
        {
            throw new Exception("Input was more than 1 character.");
        }

        return _alphabet.IndexOf(input, StringComparison.CurrentCultureIgnoreCase) + 1;
    }

    public static int ToInt(char input)
    {
        input = char.ToUpper(input);
        return _alphabet.IndexOf(input) + 1;
    }

    public static string ToString(int input)
    {
        return _alphabet[input - 1].ToString();
    }

    public static char ToChar(int input)
    {
        return _alphabet[input - 1];
    }

    public static (int x, int y) SplitNotation(string value)
    {
        var x = ToInt(value[0]);
        var y = int.Parse(value[1..]);
        return new(x, y);
    }
}