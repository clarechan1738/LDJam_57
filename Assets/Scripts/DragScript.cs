using System.Collections;
using System.Collections.Generic;
using System.Net.Cache;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragScript : MonoBehaviour
{
    //Check If Currently Dragging
    private bool dragActive = false;
    
    private Vector3 offset;

    //Recipe Script Reference
    private RecipeScript recipeScript;

    private TooltipUI tooltipUIScript;

    private short correctPotions = 0;
    private short mistakes = 0;

    private short ending = 0;

    private void Awake()
    {
        recipeScript = FindAnyObjectByType<RecipeScript>();
        tooltipUIScript = FindAnyObjectByType<TooltipUI>();
    }

    void Update()
    {
        if (dragActive)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
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
                if (recipeScript.CombineIngredients() == recipeScript.currentRecipe)
                {
                    //Complete Current Task & Select New One
                    correctPotions++;

                    //Check For End Of List?

                    recipeScript.SetCurrentRecipe();
                    recipeScript.ingredientsNum = 0;
                }
                else
                {
                    mistakes++;
                    recipeScript.ingredientsNum = 0;
                }
            }

            //Ending Stuff
            if (correctPotions >= 12 && mistakes <= 3)
            {
                //Best Ending
                ending = 0;
            }
            else if (correctPotions >= 5 && correctPotions <= 11 && mistakes < 7 && mistakes >= 3)
            {
                //Mid Ending
                ending = 1;
            }
            else if (correctPotions <= 4 && correctPotions >= 0 && mistakes >= 7)
            {
                //Bad Ending
                ending = 2;
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
