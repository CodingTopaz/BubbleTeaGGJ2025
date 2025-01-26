using UnityEngine;

public class CupButton : MonoBehaviour
{
    public GameObject cupDisplay;
    public bool isCup;
    private void Start()
    {
        cupDisplay.SetActive(false);
        isCup = false;
    }

    private void OnMouseDown()
    {
        cupDisplay.SetActive(true);
        isCup = true;
    }
}
