using UnityEngine;

public class CupButton : MonoBehaviour
{
    public GameObject cupDisplay;
    private void Start()
    {
        cupDisplay.SetActive(false);
    }

    private void OnMouseDown()
    {
        cupDisplay.SetActive(true);
    }
}
