namespace DistributeurBoisson;

public class IngredientPricesCsvReader
{
    public Dictionary<string, double> GetPrices(string pricesFile, char separator = ';')
    {
        var result = new Dictionary<string, double>();
        foreach (var line in File.ReadAllLines(pricesFile).Skip(1))
        {
            var splitLine = line.Split(separator);
            result[splitLine[0]] = double.Parse(splitLine[1]); //todo error management
        }

        return result;
    }
}