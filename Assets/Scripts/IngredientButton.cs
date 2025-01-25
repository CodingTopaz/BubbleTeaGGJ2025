using System;
using UnityEngine;
using UnityEngine.UI;


public class IngredientButton : MonoBehaviour
{
    public GameManager gameManager;
    public int ingredientIndex;
    public enum IngredientType
    {
        Base,
        Bubble,
        Jelly,
        Ice
    }
    
    public IngredientType ingredientType;
    
    public GameObject ingredientPrefab;
    
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnMouseDown()
    {
        
        //THIS IS BAD! DON'T DO THIS! 
        //We gotta check which ingredient we're adding but because Angelo didn't think ahead we defined all the ingredients
        //as objects in the orderManager instead of using ScriptableObjects.
        if (ingredientType == IngredientType.Bubble)
        {
            gameManager.drinkBuilder.AddIngredient(gameManager.orderManager.possibleBubbles[ingredientIndex]);
            Debug.Log("Added ingredient: " + gameManager.orderManager.possibleBubbles[ingredientIndex].IngredientName);
        } else if (ingredientType == IngredientType.Jelly)
        {
            gameManager.drinkBuilder.AddIngredient(gameManager.orderManager.possibleJellies[ingredientIndex]);
            Debug.Log("Added ingredient: " + gameManager.orderManager.possibleJellies[ingredientIndex].IngredientName);

        } else if (ingredientType == IngredientType.Ice)
        {
            gameManager.drinkBuilder.AddIngredient(gameManager.orderManager.possibleIce[ingredientIndex]);
            Debug.Log("Added ingredient: " + gameManager.orderManager.possibleIce[ingredientIndex].IngredientName);
        }
        else
        {
            Debug.LogError("No ingredient found at the desired index");
        }

    }
}
