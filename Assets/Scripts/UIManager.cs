using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI soulAmount_Text;
    public int soulAmount;

    public void UpdateSoulAmount()
    {
        soulAmount += 1;
    }
}
