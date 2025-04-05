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

    private void Awake()
    {
        recipeScript = FindAnyObjectByType<RecipeScript>();
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
            recipeScript.ingredientsNum++;
            Destroy(this.gameObject);

            //If Ingredient Being Added Is 0 Or 1, Send It To Recipe Script. Otherwise, Reset Ingredients To 0 After Combining
            if (recipeScript.ingredientsNum == 0 || recipeScript.ingredientsNum == 1)
            {
                recipeScript.GetCurrentIngredient(this.gameObject.name, recipeScript.ingredientsNum);
            }
            else if (recipeScript.ingredientsNum == 2)
            {
                recipeScript.CombineIngredients();
                Debug.Log(recipeScript.CombineIngredients());
                recipeScript.ingredientsNum = 0;
            }

        }
    }



}
