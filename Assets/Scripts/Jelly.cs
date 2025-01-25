using UnityEngine;



public class Jelly : DrinkIngredient
{
    public string flavor;
    
    //this is a constructor that lets us automatically set the properties of this ingredient when we create a new one.
    public Jelly( string flavorSetting)
    {
        IngredientName = flavorSetting + "Jelly";
        flavor = flavorSetting;
    }
}
    
