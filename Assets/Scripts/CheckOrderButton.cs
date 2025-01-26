using UnityEngine;

public class CheckOrderButton : MonoBehaviour
{
    public OrderManager orderManager;
    public ClearDrink drinkClear;
    
    private void OnMouseDown()
    {
        orderManager.CompareDrink();
        drinkClear.ClearDrinkOrderAndVisuals();
    }
}
