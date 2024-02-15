namespace DistributeurBoisson;

public class Recipe
{
    public string Name { get; set; }
    public Dictionary<string, int> DosesPerIngredient { get; set; } = new();

    public double GetCost(Dictionary<string, double> costPerIngredient)
    {
        var result = 0d;
        foreach (var (ingredient, nbDoses) in DosesPerIngredient)
        {
            result += costPerIngredient[ingredient] * nbDoses;
        }

        return result*1.3;
    }
    
}