using System;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using Random = UnityEngine.Random;


public class OrderManager : MonoBehaviour
{
    public GameManager gameManager;
    public List<Bubble> possibleBubbles = new List<Bubble>();
    public List<Jelly> possibleJellies = new List<Jelly>();
    public List<Ice> possibleIce = new List<Ice>();

    public List<Drink.DrinkBase> possibleDrinks = new List<Drink.DrinkBase>();

    public Drink desiredDrink;

    private void Start()
    {

    }

    /// <summary>
    /// Populates all the ingredient lists with pre-defined ingredients.
    /// </summary>
    public void InitializeIngredients()
    {
        //Base Drinks List
        possibleDrinks.Add(Drink.DrinkBase.Milk);
        possibleDrinks.Add(Drink.DrinkBase.Fruit);
        possibleDrinks.Add(Drink.DrinkBase.Matcha);

        //Bubble List
        possibleBubbles.Add(new Bubble(false, "tapioca")); //Index 0 
        possibleBubbles.Add(new Bubble(true, "strawberry")); //Index 1 
        possibleBubbles.Add(new Bubble(true, "blueberry")); //Index 2
        possibleBubbles.Add(new Bubble(true, "melon")); //Index 3
        
        //Jelly List
        possibleJellies.Add(new Jelly("grass"));
        possibleJellies.Add(new Jelly("coffee"));
        possibleJellies.Add(new Jelly("rainbow"));
        
        //Ice List
        possibleIce.Add(new Ice("none"));
        possibleIce.Add(new Ice("light"));
        possibleIce.Add(new Ice("regular"));
        possibleIce.Add(new Ice("extra"));
    }

    public void CreateDrinkOrder()
    {
        //get a random ingredient from each ingreduent list (bubbles, jellies, ice)
        //Add each ingredient to desiredDrink's drinkIngredients list
        desiredDrink = new Drink
        {
            drinkBase = possibleDrinks[Random.Range(0, possibleDrinks.Count)],
        };

        desiredDrink.AddIngredient(possibleBubbles[Random.Range(0, possibleBubbles.Count)]);
        desiredDrink.drinkIngredients.Add(possibleJellies[Random.Range(0, possibleJellies.Count)]);
        desiredDrink.drinkIngredients.Add(possibleIce[Random.Range(0, possibleIce.Count)]);
    }

    public void ClearDrinkOrder()
    {
        if (desiredDrink != null)
        {
            desiredDrink.drinkIngredients.Clear();
        }
    }

    public void CompareDrink()
    {
        float drinkScore = gameManager.playerDrink.CalculateScore(desiredDrink);
        if (drinkScore >= 80)
        {
            Debug.Log("Nice Job!");
            gameManager.NewRound();
        } else if (drinkScore >= 50)
        {
            Debug.Log("Not bad, but could be better."); 
            gameManager.NewRound();
        }
        else
        {
            Debug.Log("Try Again!");
            gameManager.NewRound();
        }
        
        gameManager.score += drinkScore;
    }
}


     