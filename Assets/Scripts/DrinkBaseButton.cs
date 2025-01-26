using System;
using UnityEngine;

public class DrinkBaseButton : MonoBehaviour
{
    public GameManager gameManager;
    public Drink.DrinkBase drinkBase;
    public GameObject drinkBaseVisuals;
    public GameObject[] drinkBaseVisualList;
    public CupButton cupButton;


    private void Start()
    {
        cupButton = GameObject.Find("CupButton").GetComponent<CupButton>();
    }

    private void OnMouseDown()
    {
        if (cupButton.isCup)
        {
            gameManager.playerDrink.drinkBase = drinkBase;
            Debug.Log("set drink type to" + gameManager.playerDrink.drinkBase);
            ClearDrinkBaseVisuals();
            AddDrinkBaseVisuals();
        }
        else
        {
            Debug.Log("no cup :(");
        }

    }

    void AddDrinkBaseVisuals()
    {
        drinkBaseVisuals.SetActive(true);
        Debug.Log("set " +drinkBaseVisuals.name + "to active");
    }

    void ClearDrinkBaseVisuals()
    {
        foreach (GameObject drinkBaseVisual in drinkBaseVisualList)
        {
            drinkBaseVisual.SetActive(false);
            Debug.Log("set " +drinkBaseVisual.name + "to inactive");
        }
    }

}
