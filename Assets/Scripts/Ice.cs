using UnityEngine;


    public class Ice : DrinkIngredient
    {
        public string iceLevel;
        
        //this is a constructor that lets us automatically set the properties of this ingredient when we create a new one.
        public Ice(string iceLevelSetting)
        {
            IngredientName = iceLevelSetting + "Ice";
            iceLevel = iceLevelSetting;
        }
    }
