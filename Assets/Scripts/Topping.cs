using UnityEngine;

public class Topping : DrinkIngredient
{

    public enum ToppingType
    {
        Bubble,
        Jelly
    }
    
    public ToppingType toppingType;
    public bool popping;
    public string flavor;

    //this is a constructor that lets us automatically set the properties of this ingredient when we create a new one.
    public Topping(bool poppingSetting, string flavorSetting, ToppingType toppingTypeSetting)
    {
        IngredientName = flavorSetting + toppingTypeSetting.ToString();
        popping = poppingSetting;
        flavor = flavorSetting;
       
    }
}
