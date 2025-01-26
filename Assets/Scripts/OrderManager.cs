using System;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using Random = UnityEngine.Random;


public class OrderManager : MonoBehaviour
{
    public GameManager gameManager;
   // public List<Bubble> possibleBubbles = new List<Bubble>();
    // public List<Jelly> possibleJellies = new List<Jelly>();
    public List<Topping> possibleToppings = new List<Topping>();
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

        //Toppings List
            //Bubble List
            possibleToppings.Add(new Topping (false, "tapioca", Topping.ToppingType.Bubble)); //Index 0 
            possibleToppings.Add(new Topping(true, "strawberry", Topping.ToppingType.Bubble)); //Index 1 
            possibleToppings.Add(new Topping(true, "blueberry", Topping.ToppingType.Bubble)); //Index 2
            possibleToppings.Add(new Topping(true, "melon", Topping.ToppingType.Bubble)); //Index 3
            
            //Jelly List
            possibleToppings.Add(new Topping(false, "grass", Topping.ToppingType.Jelly)); //Index 4
            possibleToppings.Add(new Topping(false, "coffee", Topping.ToppingType.Jelly)); //Index 5
            possibleToppings.Add(new Topping(false, "rainbow", Topping.ToppingType.Jelly)); //Index 6
            
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

        desiredDrink.AddIngredient(possibleToppings[Random.Range(0, possibleToppings.Count)]);
        // desiredDrink.drinkIngredients.Add(possibleJellies[Random.Range(0, possibleJellies.Count)]);
        desiredDrink.drinkIngredients.Add(possibleIce[Random.Range(0, possibleIce.Count)]);
    }

    public void ClearDrinkOrder()
    {
        if (desiredDrink != null)
        {
            desiredDrink.drinkBase = Drink.DrinkBase.None;
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


     