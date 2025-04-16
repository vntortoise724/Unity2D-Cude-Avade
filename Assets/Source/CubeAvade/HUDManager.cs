using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private TMP_Text health;

    public void UpdateHealthText(int healthText)
    {
        health.text = "Health: " + healthText; 
    }
}
