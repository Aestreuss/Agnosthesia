using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI soulAmount_Text;
    public int soulAmount;

    public void UpdateSoulAmount(int soulsAmount)
    {
        soulAmount += 1;
        soulAmount_Text.text = "Souls: " + soulsAmount.ToString();       
    }

    void Update()
    {
        if (soulAmount == 13)
        {
            SceneManager.LoadScene("End");
        }
    }
}
