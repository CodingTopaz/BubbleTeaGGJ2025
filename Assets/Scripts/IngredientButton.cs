using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class IngredientButton : MonoBehaviour
{
    public GameManager gameManager;
    public int ingredientIndex;
    public enum IngredientType
    {
        Ice,
        Topping
    }
    
    public IngredientType ingredientType;
    
    public GameObject ingredientDisplay;
    
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnMouseDown()
    {
        AddIngredientBackend();
    }

    private void AddIngredientBackend()
    {
        //THIS IS BAD! DON'T DO THIS! 
        //We gotta check which ingredient we're adding but because Angelo didn't think ahead we defined all the ingredients
        //as objects in the orderManager instead of using ScriptableObjects.
        if (ingredientType == IngredientType.Topping)
        {
            gameManager.drinkBuilder.AddIngredient(gameManager.orderManager.possibleToppings[ingredientIndex]);
            Debug.Log("Added Topping: " + gameManager.orderManager.possibleToppings[ingredientIndex].IngredientName);
        } else if (ingredientType == IngredientType.Ice)
        {
            gameManager.drinkBuilder.AddIngredient(gameManager.orderManager.possibleIce[ingredientIndex]);
            Debug.Log("Added Ice: " + gameManager.orderManager.possibleIce[ingredientIndex].IngredientName);
        }
        else
        {
            Debug.LogError("No ingredient found at the desired index");
        }
    }

    private void AddIngredientVisuals()
    {
        ingredientDisplay.SetActive(true);
    }
}
