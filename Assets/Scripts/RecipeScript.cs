using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeScript : MonoBehaviour
{
    public int ingredientsNum = 0;

    //List Of Recipes
    public string[] recipes = { "Allergy", "Death", "Hallucination", "Hypertension", "Hypotension", "Insight", "Love", "Memory", "Resurrection", "Somnia", "Vision", "Vomiting" };

    public string currentRecipe = "";

    Queue<string> recipeList = new Queue<string>(12);

    //Ingredients For Recipe
    private string ingredient1;
    private string ingredient2;

    private void Awake()
    {
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
        if (recipeList.Count > 0)
        {
            currentRecipe = recipeList.Dequeue();
            Debug.Log("Current Recipe: " + currentRecipe);
        }
        else
        {
            QueueRecipes();
            SetCurrentRecipe();
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
                return recipes[1];
            }
            else if (ingredient2 == "Yellow")
            {
                return recipes[5];
            }
            else if (ingredient2 == "Green")
            {
                return recipes[9];
            }
        }
        else if (ingredient1 == "Red")
        {
            if (ingredient2 == "Blue")
            {
                return recipes[8];
            }
            else if (ingredient2 == "Yellow")
            {
                return recipes[2];
            }
            else if (ingredient2 == "Green")
            {
                return recipes[11];
            }
        }
        else if (ingredient1 == "Yellow")
        {
            if (ingredient2 == "Blue")
            {
                return recipes[6];
            }
            else if (ingredient2 == "Red")
            {
                return recipes[0];
            }
            else if (ingredient2 == "Green")
            {
                return recipes[10];
            }
        }
        else if (ingredient1 == "Green")
        {
            if(ingredient2 == "Blue")
            {
                return recipes[4];
            }
            else if (ingredient2 == "Red")
            {
                return recipes[7];
            }
            if (ingredient2 == "Yellow")
            {
                return recipes[3];
            }
        }
        return null;
    }
}
