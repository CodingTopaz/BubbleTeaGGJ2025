using System;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Rendering.UI;
using Random = UnityEngine.Random;


public class OrderManager : MonoBehaviour
{
    public GameManager gameManager;
    public UiHandler uiHandler;

    public List<Topping> possibleToppings = new List<Topping>();
    public List<Ice> possibleIce = new List<Ice>();

    public List<Drink.DrinkBase> possibleDrinks = new List<Drink.DrinkBase>();

    public Drink desiredDrink;
    
    /// <summary>
    /// Populates all the ingredient lists with pre-defined ingredients.
    /// </summary>
    public void InitializeIngredients()
    {
        //Base Drinks List
        possibleDrinks.Add(Drink.DrinkBase.MilkTea);
        possibleDrinks.Add(Drink.DrinkBase.FruitTea);
        possibleDrinks.Add(Drink.DrinkBase.Matcha);

        //Toppings List
            //Bubble List
            possibleToppings.Add(new Topping (false, "Tapioca", Topping.ToppingType.Bubble)); //Index 0 
            possibleToppings.Add(new Topping(true, "Strawberry", Topping.ToppingType.Bubble)); //Index 1 
            possibleToppings.Add(new Topping(true, "Blueberry", Topping.ToppingType.Bubble)); //Index 2
            possibleToppings.Add(new Topping(true, "Melon", Topping.ToppingType.Bubble)); //Index 3
            
            //Jelly List
            possibleToppings.Add(new Topping(false, "Grass", Topping.ToppingType.Jelly)); //Index 4
            possibleToppings.Add(new Topping(false, "Coffee", Topping.ToppingType.Jelly)); //Index 5
            possibleToppings.Add(new Topping(false, "Rainbow", Topping.ToppingType.Jelly)); //Index 6
            
        //Ice List
        possibleIce.Add(new Ice("No"));
        possibleIce.Add(new Ice("Lite"));
        possibleIce.Add(new Ice("Regular"));
        possibleIce.Add(new Ice("Extra"));
    }

    public void CreateDrinkOrder()
    {
     
        //create a new drink and initlizae it's base with a random base.
        desiredDrink = new Drink { };
        desiredDrink.drinkBase = possibleDrinks[Random.Range(0, possibleDrinks.Count)];
        string desiredDrinkBase = desiredDrink.drinkBase.ToString();
        uiHandler.UpdateDesiredOrderDisplay(desiredDrinkBase);

        //get a random ingredient from the toppings list (bubbles, jellies, ice)
        //Add each ingredient to desiredDrink's drinkIngredients list
        DrinkIngredient desiredTopping = possibleToppings[Random.Range(0, possibleToppings.Count)];
        desiredDrink.AddIngredient(desiredTopping);
        string desiredToppingName = desiredTopping.IngredientName;
        uiHandler.UpdateDesiredOrderDisplay(desiredToppingName);

        DrinkIngredient desiredIce = possibleIce[Random.Range(0, possibleIce.Count)];
        desiredDrink.AddIngredient(desiredIce);
        string desiredIceName = desiredIce.IngredientName;
        uiHandler.UpdateDesiredOrderDisplay(desiredIceName);
        
        string desiredOrderText = "-" + desiredDrinkBase + "\n" + "-" + desiredToppingName + "\n" + "-" + desiredIceName;
        uiHandler.UpdateDesiredOrderDisplay(desiredOrderText);
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
        gameManager.UpdateScoreText();
    }
}


     