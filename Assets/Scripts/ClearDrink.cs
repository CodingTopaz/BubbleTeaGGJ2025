using UnityEngine;
using UnityEngine.Serialization;

public class ClearDrink : MonoBehaviour
{
    public DrinkBuilder drinkBuilder;
    public GameObject[] drinkVisuals;

    void OnMouseDown()
    {
        ClearDrinkOrderAndVisuals();
    }

    public void ClearDrinkOrderAndVisuals()
    {
        drinkBuilder.ClearDrinkOrder();
        foreach (GameObject i in drinkVisuals)
        {
            i.SetActive(false);
        }
        Debug.Log("Drink order cleared");
    }
}
