using UnityEngine;

public class DrinkBuilder : MonoBehaviour
{
    public GameManager gameManager;
    
    public void AddIngredient(DrinkIngredient ingredient)
    {
        gameManager.playerDrink.AddIngredient(ingredient);
    }
}
