using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeScript : MonoBehaviour
{
    public int ingredientsNum = 0;

    //List Of Recipes
    private string[] recipes = { "Recipe1", "Recipe2", "Recipe3", "Recipe4", "Recipe5", "Recipe6"};

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
                Debug.Log("Recipe 1");
                return recipes[0];
            }
            else if (ingredient2 == "Yellow")
            {
                Debug.Log("Recipe 2");
                return recipes[1];
            }
            else if (ingredient2 == "Green")
            {
                Debug.Log("Recipe 3");
                return recipes[2];
            }
        }
        else if (ingredient1 == "Red")
        {
            if (ingredient2 == "Blue")
            {
                Debug.Log("Recipe 1");
                return recipes[0];
            }
            else if (ingredient2 == "Yellow")
            {
                Debug.Log("Recipe 4");
                return recipes[3];
            }
            else if (ingredient2 == "Green")
            {
                Debug.Log("Recipe 5");
                return recipes[4];
            }
        }
        else if (ingredient1 == "Yellow")
        {
            if (ingredient2 == "Blue")
            {
                Debug.Log("Recipe 2");
                return recipes[1];
            }
            else if (ingredient2 == "Red")
            {
                Debug.Log("Recipe 4");
                return recipes[3];
            }
            else if (ingredient2 == "Green")
            {
                Debug.Log("Recipe 6");
                return recipes[5];
            }
        }
        else if (ingredient1 == "Green")
        {
            if(ingredient2 == "Blue")
            {
                Debug.Log("Recipe 3");
                return recipes[2];
            }
            else if (ingredient2 == "Red")
            {
                Debug.Log("Recipe 5");
                return recipes[4];
            }
            if (ingredient2 == "Yellow")
            {
                Debug.Log("Recipe 6");
                return recipes[5];
            }
        }
        return null;
    }
}
