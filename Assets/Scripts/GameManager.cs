using System;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public OrderManager orderManager;
    public DrinkBuilder drinkBuilder;
    public Drink playerDrink;

    public float score;
    public TMP_Text scoreText;

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
        drinkBuilder.AddIngredient(orderManager.possibleIce[0]);
    }

    public void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
