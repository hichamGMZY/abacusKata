namespace DistributeurBoisson;

public static class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            ConsoleKey key;
            try
            {
                var arguments = ArgsParser.ReadArguments(args);
                var ingredientPrices = new IngredientPricesCsvReader().GetPrices(arguments["ingredientCostFile"]);
                var recipes = new RecipesJsonSerializer().GetRecipes(arguments["recipeFile"]);

                var recipesNamesArray = recipes.Keys.ToArray();
                do
                {
                    Console.WriteLine("Quelle boisson chaude voulez vous ?");

                    for (int i = 0; i < recipesNamesArray.Length; i++)
                    {
                        Console.WriteLine($"{i} - {recipesNamesArray[i]}");
                    }

                    Console.WriteLine("Entrez le numero de la boisson voulue");
                    var number = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Failed to read recipe number"));

                    var recipe = recipes[recipesNamesArray[number]];
                    var cost = recipe.GetCost(ingredientPrices);
                    Console.WriteLine($"Prix de la boisson {recipe.Name} : {cost:0.00}€");
                    Console.WriteLine(
                        "Appuyer sur R pour obtenir le prix d'une nouvelle boisson, ou sur une autre touche pour quitter le programme");
                    key = Console.ReadKey().Key;
                    Console.WriteLine();
                } while (key == ConsoleKey.R);

                Console.WriteLine("Bonne degustation !");
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Une erreur est survenue lors de l'execution du programme");
                Console.WriteLine(e);
                Console.Write(
                    "Pour recommencer, appuyez sur R, sinon, appuyez sur une autre touche pour quitter le programme");
                key = Console.ReadKey().Key;
                Console.WriteLine();
                if (key != ConsoleKey.R)
                    return;
            }
        }
    }
    
}