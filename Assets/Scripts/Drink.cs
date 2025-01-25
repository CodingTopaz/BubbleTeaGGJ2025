using System.Collections.Generic;
using UnityEngine;

public class Drink 
{
    public enum DrinkBase
    {
        Milk, Fruit, Matcha
    }
    
    public DrinkBase drinkBase;
    public List<DrinkIngredient> drinkIngredients = new List<DrinkIngredient>();

    public void AddIngredient(DrinkIngredient ingredient)
    {
        drinkIngredients.Add(ingredient);
    }
    
    public float CalculateScore(Drink desiredDrink)
    {
        float score = 100;
        foreach (var ingredient in desiredDrink.drinkIngredients)
        {
            if (!drinkIngredients.Exists(i => i.IngredientName == ingredient.IngredientName))
            {
                score -= 20;
                Debug.Log(ingredient.IngredientName + "doesn't exist in the desired drink.");
            }
            else
            {
                Debug.Log(ingredient.IngredientName + "was scored.");
            }
        }
        return score > 0 ? score : 0;
    }
}
