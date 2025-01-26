using UnityEngine;
using UnityEngine.Serialization;


public class Bubble : DrinkIngredient
{
    public bool popping;
    public string flavor;

    //this is a constructor that lets us automatically set the properties of this ingredient when we create a new one.
    public Bubble(bool poppingSetting, string flavorSetting)
    {
        IngredientName = flavorSetting + "Bubble";
        popping = poppingSetting;
        flavor = flavorSetting;
       
    }
    
}
