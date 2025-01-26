using UnityEngine;
using UnityEngine.Serialization;

public class IceButton : MonoBehaviour
{
    public GameManager gameManager;
    public CupButton cupButton;
    public GameObject[] iceDisplayObjects;
    public int currentIceIndex;
    
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        cupButton = GameObject.Find("CupButton").GetComponent<CupButton>();
    }

    private void OnMouseDown()
    {
        if (cupButton.isCup)
        {
            if (currentIceIndex < (iceDisplayObjects.Length - 1))
            {
                currentIceIndex ++;
            }
            else
            {
                currentIceIndex = 0;
            }
            ClearIceDisplay();
            AddIceBackend();
            AddIceVisuals();
        }
        else
        {
            Debug.Log("no cup :(");
        }
    }

    private void AddIceBackend()
    {
        //Remove all Ice ingredients
        gameManager.playerDrink.drinkIngredients.RemoveAll(x => x is Ice);
        //Add the new Ice ingredient
        gameManager.drinkBuilder.AddIngredient(gameManager.orderManager.possibleIce[currentIceIndex]);
        Debug.Log("Added Topping: " + gameManager.orderManager.possibleIce[currentIceIndex].IngredientName);
    }

    private void AddIceVisuals()
    {
        if (iceDisplayObjects[currentIceIndex] != null)
        {
            iceDisplayObjects[currentIceIndex].SetActive(true);
        }
        else
        {
            Debug.Log("No ingredient display");
        }
    }

    private void ClearIceDisplay()
    {
        foreach (GameObject obj in iceDisplayObjects)
        {
            obj.SetActive(false);
        }
    }

    public void ResetIce()
    {
        currentIceIndex = 0;
        gameManager.drinkBuilder.AddIngredient(gameManager.orderManager.possibleIce[0]);
        Debug.Log("Added Topping: " + gameManager.orderManager.possibleIce[0].IngredientName);
    }
}
