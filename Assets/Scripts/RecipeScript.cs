using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeScript : MonoBehaviour
{
    public int ingredientsNum = 0;

    //List Of Recipes
    private string[] recipes = { "Allergy", "Death", "Hallucination", "Hypertension", "Hypotension", "Insight", "Love", "Memory", "Resurrection", "Somnia", "Vision", "Vomiting" };

    //Ingredients For Recipe
    private string ingredient1;
    private string ingredient2;

    //Gets Current Passed In Ingredient
    public void GetCurrentIngredient(string currIn, int index)
    {
        if(index == 0)
        {
            ingredient1 = currIn;
        }
        else if(index == 1)
        {
            ingredient2 = currIn;
        }
    }

    //Combines The Two Passed In Ingredients
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
                Debug.Log("Recipe 5");
                return recipes[7];
            }
            if (ingredient2 == "Yellow")
            {
                Debug.Log("Recipe 6");
                return recipes[3];
            }
        }
        return null;
    }
}
