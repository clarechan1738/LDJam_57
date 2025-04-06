using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DragScript : MonoBehaviour
{
    //Check If Currently Dragging
    private bool dragActive = false;
    
    private Vector3 offset;

    //Recipe Script Reference
    private RecipeScript recipeScript;

    private TooltipUI tooltipUIScript;

    private DialogueManager diaMgr;

    private GameManager gameManager;

    public bool gameOver = false;

    private void Awake()
    {
        recipeScript = FindAnyObjectByType<RecipeScript>();
        tooltipUIScript = FindAnyObjectByType<TooltipUI>();
        diaMgr = FindAnyObjectByType<DialogueManager>();
        gameManager = FindAnyObjectByType<GameManager>();
    }

    void Update()
    {
        if (dragActive && !diaMgr.dialogueActive && !gameManager.gamePaused)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }

        if((recipeScript.recipeList.Count() - 1) == 0)
        {
            gameOver = true;
        }

        
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragActive = true;
    }

    private void OnMouseUp()
    {
        dragActive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Pot"))
        {

            Destroy(this.gameObject);
            recipeScript.ingredientsNum++;

            //Check Which Index Current Ingredient Is At Then Combine
            if (recipeScript.ingredientsNum == 1)
            {
                recipeScript.GetCurrentIngredient(this.gameObject.name, recipeScript.ingredientsNum);
            }
            else if(recipeScript.ingredientsNum == 2)
            {
                recipeScript.GetCurrentIngredient(this.gameObject.name, recipeScript.ingredientsNum);
                Debug.Log("Result: " + recipeScript.CombineIngredients());
                if (recipeScript.CombineIngredients() == recipeScript.currentRecipe)
                {
                    recipeScript.correctPotions++;
                    Debug.Log("Correct Potions Made: " + recipeScript.correctPotions);
                    //Complete Current Task & Select New One
                    recipeScript.SetCurrentRecipe();
                    recipeScript.ingredientsNum = 0;
                }
                else
                {
                    recipeScript.mistakes++;
                    Debug.Log("Mistakes Made: " + recipeScript.mistakes);
                    recipeScript.SetCurrentRecipe();
                    recipeScript.ingredientsNum = 0;
                }
            }

        }
    }

    //Tooltip Text For Hovering Objects
    private void OnMouseOver()
    {
        if (gameObject.name == "Blue")
        {
            TooltipUI.Instance.ShowTooltip_Static("Bat Wings");
        }
        else if (gameObject.name == "Red")
        {
            TooltipUI.Instance.ShowTooltip_Static("Red Mushroom");
        }
        else if (gameObject.name == "Yellow")
        {
            TooltipUI.Instance.ShowTooltip_Static("Golden Carrot");
        }
        else if (gameObject.name == "Green")
        {
            TooltipUI.Instance.ShowTooltip_Static("Snake Venom");
        }
    }

    private void OnMouseExit()
    {
        TooltipUI.Instance.HideTooltip_Static();
    }

}
