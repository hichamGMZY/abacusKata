using System.Reflection;

namespace DistributeurBoisson.Tester;

public class DistributeurBoissonTests
{
    private Dictionary<string, double> _expectedCosts = new();
    private Dictionary<string, double> _ingredientCosts = new();
    private Dictionary<string, Recipe> _recipes = new();

    [SetUp]
    public void Setup()
    {
        var testData =
            Path.Combine(Path.GetDirectoryName(Assembly.GetAssembly(typeof(DistributeurBoissonTests))!.Location)!,
                "TestData");
        _expectedCosts = new IngredientPricesCsvReader().GetPrices(Path.Combine(testData, "expectedCosts.csv"));
        _ingredientCosts =
            new IngredientPricesCsvReader().GetPrices(Path.Combine(testData, "ingredientCosts.csv"));
        _recipes = new RecipesJsonSerializer().GetRecipes(Path.Combine(testData, "recipes.json"));
    }
    
    [TestCase("Expresso")]
    [TestCase("Allonge")]
    [TestCase("Capuccino")]
    [TestCase("Chocolat")]
    [TestCase("The")]
    public void TestComputeCost(string recipeName)
    {
        var recipe = _recipes[recipeName];

        var cost = recipe.GetCost(_ingredientCosts);
        var expectedCost = _expectedCosts[recipeName];
        
        Assert.That(Math.Round(cost, 2), Is.EqualTo(Math.Round(expectedCost, 2)));
    }
    
}