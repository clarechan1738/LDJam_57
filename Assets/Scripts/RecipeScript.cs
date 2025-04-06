using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecipeScript : MonoBehaviour
{
    public int ingredientsNum = 0;

    private DragScript dragScript;

    //List Of Recipes
    public string[] recipes = { "Allergy", "Death", "Hallucination", "Hypertension", "Hypotension", "Insight", "Love", "Memory", "Resurrection", "Somnia", "Vision", "Vomiting" };

    public string currentRecipe = "";

    public Queue<string> recipeList = new Queue<string>(12);

    public List<DialogueStorage> dialogueList = new List<DialogueStorage>(12);

    //Ingredients For Recipe
    private string ingredient1;
    private string ingredient2;

    //Potion Stuff
    public short correctPotions = 0;
    public short mistakes = 0;

    private void Awake()
    {
        dragScript = FindAnyObjectByType<DragScript>();
        QueueRecipes();
        SetCurrentRecipe();
    }

    public void QueueRecipes()
    {

        string swapRecipe;

        for(int i = 0; i < recipes.Length; i++)
        {
            int swapNum = Random.Range(0, recipes.Length);
            swapRecipe = recipes[i];
            recipes[i] = recipes[swapNum];
            recipes[swapNum] = swapRecipe;
        }

        foreach (string recipe in recipes)
        {
            recipeList.Enqueue(recipe);
        }

    }
    public void SetCurrentRecipe()
    {
        Debug.Log("Recipe Count: " + recipeList.Count);

        if (recipeList.Count > 0)
        {
            currentRecipe = recipeList.Dequeue();
            Debug.Log("Current Recipe: " + currentRecipe);
        }
        else
        {
            if(dragScript.gameOver)
            {
                if (correctPotions == 12)
                {
                    SceneManager.LoadScene("GoodEnding");
                }
                else if (mistakes == 12)
                {
                    SceneManager.LoadScene("BadEnding");
                }
                else
                {
                    SceneManager.LoadScene("MehEnding");
                }
            }
            
            
        }
    }

    //Gets Current Passed In Ingredient
    public void GetCurrentIngredient(string currIn, int index)
    {
        if(index == 1)
        {
            ingredient1 = currIn;
            Debug.Log(ingredient1);
        }
        else if(index == 2)
        {
            ingredient2 = currIn;
            Debug.Log(ingredient2);
        }
    }

    //Combines The Two Ingredients
    public string CombineIngredients()
    {
        if(ingredient1 == "Blue")
        {
            if(ingredient2 == "Red")
            {
                return "Death";
            }
            else if (ingredient2 == "Yellow")
            {
                return "Insight";
            }
            else if (ingredient2 == "Green")
            {
                return "Somnia";
            }
        }
        else if (ingredient1 == "Red")
        {
            if (ingredient2 == "Blue")
            {
                return "Resurrection";
            }
            else if (ingredient2 == "Yellow")
            {
                return "Hallucination";
            }
            else if (ingredient2 == "Green")
            {
                return "Vomiting";
            }
        }
        else if (ingredient1 == "Yellow")
        {
            if (ingredient2 == "Blue")
            {
                return "Love";
            }
            else if (ingredient2 == "Red")
            {
                return "Allergy";
            }
            else if (ingredient2 == "Green")
            {
                return "Vision";
            }
        }
        else if (ingredient1 == "Green")
        {
            if(ingredient2 == "Blue")
            {
                return "Hypotension";
            }
            else if (ingredient2 == "Red")
            {
                return "Memory";
            }
            if (ingredient2 == "Yellow")
            {
                return "Hypertension";
            }
        }
        return null;
    }
}
