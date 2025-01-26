using System.Collections.Generic;
using UnityEngine;

public class Drink 
{
    public enum DrinkBase
    {
        MilkTea, FruitTea, Matcha, None
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

        if (drinkBase == desiredDrink.drinkBase)
        {
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
        }
        else
        {
            score -= 100;
            Debug.Log("Wrong drink base! 0 Points!");
        }
        return score > 0 ? score : 0;
    }
}
