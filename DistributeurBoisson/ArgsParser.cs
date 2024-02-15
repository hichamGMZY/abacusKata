namespace DistributeurBoisson;

public class ArgsParser
{
    public static Dictionary<string, string> ReadArguments(string[] args)
    {
        var result = new Dictionary<string, string>();
        foreach (var arg in args)
        {
            var equalIndex = arg.IndexOf("=", StringComparison.Ordinal);
            if (equalIndex == -1)
                Console.WriteLine($"ERROR : Failed reading argument {arg}");
            var beforeEqual = arg.Substring(0, equalIndex);
            var afterEqual = arg.Substring(equalIndex + 1, arg.Length - equalIndex - 1);
            result[beforeEqual] = afterEqual;
        }

        return result;
    }
}