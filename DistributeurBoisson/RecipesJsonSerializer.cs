using System.Text.Json;

namespace DistributeurBoisson;

public class RecipesJsonSerializer
{
    // todo faire une meilleure gestion des erreurs
    public Dictionary<string, Recipe> GetRecipes(string recipesFile) =>
        JsonSerializer.Deserialize<Dictionary<string, Recipe>>(File.ReadAllText(recipesFile)) ?? throw new InvalidOperationException($"Could not read recipes from file {recipesFile}");

    public void RecipesToFile(Dictionary<string, Recipe> recipes, string recipesFile) =>
        File.WriteAllText(recipesFile, JsonSerializer.Serialize(recipes));
}