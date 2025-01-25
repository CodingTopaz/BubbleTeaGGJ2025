using UnityEngine;

public class DrinkTypeButton : MonoBehaviour
{
    public GameManager gameManager;
    public Drink.DrinkBase drinkBase;

    private void OnMouseDown()
    {
        if (drinkBase == Drink.DrinkBase.Milk)
        {
            gameManager.playerDrink.drinkBase = Drink.DrinkBase.Milk;
            Debug.Log("set drink type to" + gameManager.playerDrink.drinkBase.ToString());
        } else if (drinkBase == Drink.DrinkBase.Fruit)
        {
            gameManager.playerDrink.drinkBase = Drink.DrinkBase.Fruit;
            Debug.Log("set drink type to" + gameManager.playerDrink.drinkBase.ToString());

        } else if (drinkBase == Drink.DrinkBase.Matcha)
        {
            gameManager.playerDrink.drinkBase = Drink.DrinkBase.Matcha;
            Debug.Log("set drink type to" + gameManager.playerDrink.drinkBase.ToString());

        } else
        {
            Debug.LogError("No drink base found with the desired name");
        }
    }

}
