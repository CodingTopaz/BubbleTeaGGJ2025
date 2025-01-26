using TMPro;
using UnityEngine;

public class UiHandler : MonoBehaviour
{
    public TextMeshPro desiredOrderDisplay;

    public void UpdateDesiredOrderDisplay(string order)
    {
        desiredOrderDisplay.text = order;
    }
}
