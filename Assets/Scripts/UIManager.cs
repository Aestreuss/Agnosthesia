using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI soulAmount_Text;
    public int soulAmount;

    public void UpdateSoulAmount(int soulsAmount)
    {
        soulAmount += 1;
        soulAmount_Text.text = "Souls: " + soulsAmount.ToString();       
    }
}
