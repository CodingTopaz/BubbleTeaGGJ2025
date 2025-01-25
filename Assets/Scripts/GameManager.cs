using System;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public OrderManager orderManager;
    public DrinkBuilder drinkBuilder;
    public Drink playerDrink;

    public float score;

    private void Start()
    {
        GameStart();
        NewRound();
    }

    public void GameStart()
    {
        playerDrink = new Drink();
        orderManager.InitializeIngredients();
        orderManager.ClearDrinkOrder();
        orderManager.CreateDrinkOrder();
    }

    public void NewRound()
    {
        orderManager.ClearDrinkOrder();
        orderManager.CreateDrinkOrder();

        Debug.Log(orderManager.desiredDrink.drinkBase);

        foreach (DrinkIngredient ingredient in orderManager.desiredDrink.drinkIngredients)
        {
            Debug.Log(ingredient.IngredientName);
        }
    }
}
