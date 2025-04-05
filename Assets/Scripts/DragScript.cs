using System.Collections;
using System.Collections.Generic;
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

            //If Ingredient Being Added Is 0 Or 1, Send It To Recipe Script. Otherwise, Reset Ingredients To 0 After Combining
            if (recipeScript.ingredientsNum == 1 || recipeScript.ingredientsNum == 2)
            {
                recipeScript.GetCurrentIngredient(this.gameObject.name, recipeScript.ingredientsNum);
            }
            else if (recipeScript.ingredientsNum == 3)
            {
                recipeScript.CombineIngredients();
                Debug.Log(recipeScript.CombineIngredients());
                recipeScript.ingredientsNum = 0;
            }

        }
    }

    //Tooltip Text For Hovering Objects
    private void OnMouseOver()
    {
        if (gameObject.name == "Blue")
        {
           TooltipUI.Instance.ShowTooltip_Static("Bat Wings\nUseful For Making Potions Of Somnia, Death, And Insight.");
        }
        else if (gameObject.name == "Red")
        {
            TooltipUI.Instance.ShowTooltip_Static("Red Mushroom\nUseful For Making Potions Of Hallucination, Vomiting, And Ressurection");
        }
        else if (gameObject.name == "Yellow")
        {
            TooltipUI.Instance.ShowTooltip_Static("Golden Carrot\nUseful For Making Potions Of Vision, Love, And Allergy");
        }
        else if (gameObject.name == "Green")
        {
            TooltipUI.Instance.ShowTooltip_Static("Snake Venom\nUseful For Making Potions Of Hypotension, Hypertension, And Memory");
        }
    }

    private void OnMouseExit()
    {
        TooltipUI.Instance.HideTooltip_Static();
    }

}
