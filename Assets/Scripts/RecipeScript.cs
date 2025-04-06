using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
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

    public DialogueStorage[] dialogueList = new DialogueStorage[12];

    private DialogueManager diaMgr;

    //Ingredients For Recipe
    private string ingredient1;
    private string ingredient2;

    //Potion Stuff
    public short correctPotions = 0;
    public short mistakes = 0;

    [SerializeField]
    private TextMeshProUGUI potionTxt;


    private void Awake()
    {
        potionTxt.text = default;
        dragScript = FindAnyObjectByType<DragScript>();
        diaMgr = FindAnyObjectByType<DialogueManager>();
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

        if (recipeList.Count > 0 && !dragScript.gameOver)
        {

            currentRecipe = recipeList.Dequeue();
            Debug.Log("Current Recipe: " + currentRecipe);

            //Display Potion Currently Trying To Attain
            potionTxt.text = "Potion Of " + currentRecipe;

            DisplayCurrentDialogue();
        }
        else
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

    public void DisplayCurrentDialogue()
    {
        //Display Dialogue Depending On Current Recipe
        switch (currentRecipe)
        {
            case "Allergy":
                diaMgr.StartDialogue(dialogueList[0]);
                break;
            case "Death":
                diaMgr.StartDialogue(dialogueList[1]);
                break;
            case "Hallucination":
                diaMgr.StartDialogue(dialogueList[2]);
                break;
            case "Hypertension":
                diaMgr.StartDialogue(dialogueList[3]);
                break;
            case "Hypotension":
                diaMgr.StartDialogue(dialogueList[4]);
                break;
            case "Insight":
                diaMgr.StartDialogue(dialogueList[5]);
                break;
            case "Love":
                diaMgr.StartDialogue(dialogueList[6]);
                break;
            case "Memory":
                diaMgr.StartDialogue(dialogueList[7]);
                break;
            case "Resurrection":
                diaMgr.StartDialogue(dialogueList[8]);
                break;
            case "Somnia":
                diaMgr.StartDialogue(dialogueList[9]);
                break;
            case "Vision":
                diaMgr.StartDialogue(dialogueList[10]);
                break;
            case "Vomiting":
                diaMgr.StartDialogue(dialogueList[11]);
                break;
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
