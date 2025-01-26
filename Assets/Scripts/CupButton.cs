using UnityEngine;

public class CupButton : MonoBehaviour
{
    public GameObject cupDisplay;
    public bool isCup;
    private void Start()
    {
        DisableCup();
    }

    private void OnMouseDown()
    {
        EnableCup();
    }

    public void EnableCup()
    {
        cupDisplay.SetActive(true);
        isCup = true;
    }

    public void DisableCup()
    {
        cupDisplay.SetActive(false);
        isCup = false;
    }
}
