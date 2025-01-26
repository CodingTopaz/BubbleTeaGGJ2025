using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class ToppingsButton : MonoBehaviour
{
    public GameManager gameManager;
    public CupButton cupButton;
    public int ingredientIndex;
    public GameObject[] toppingsDisplayObjects;
    
    public GameObject ingredientDisplay;
    
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        cupButton = GameObject.Find("CupButton").GetComponent<CupButton>();
    }

    private void OnMouseDown()
    {
        if (cupButton.isCup)
        {
            ClearIngredientDisplay();
            AddIngredientBackend();
            AddIngredientVisuals();
        }
        else
        {
            Debug.Log("no cup :(");
        }
        
    }

    private void AddIngredientBackend()
    {
        //Remove all topping ingredients
        gameManager.playerDrink.drinkIngredients.RemoveAll(x => x is Topping);
        //Add the new desired ingredient
        gameManager.drinkBuilder.AddIngredient(gameManager.orderManager.possibleToppings[ingredientIndex]);
        Debug.Log("Added Topping: " + gameManager.orderManager.possibleToppings[ingredientIndex].IngredientName);
    }

    private void AddIngredientVisuals()
    {
        if (ingredientDisplay != null)
        {
            ingredientDisplay.SetActive(true);
        }
        else
        {
            Debug.Log("No ingredient display");
        }
    }

    private void ClearIngredientDisplay()
    {
        foreach (GameObject obj in toppingsDisplayObjects)
        {
            obj.SetActive(false);
        }
    }
}
