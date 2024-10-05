using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI soulAmount_Text;
    public int soulAmount;
    public GameObject keyImage;
    public bool key;

    public void UpdateSoulAmount()
    {
        soulAmount += 1;
        soulAmount_Text.text = "Souls: " + soulAmount.ToString();       
    }

    public void KeyFound(bool keyCollected)
    {
        key = true;
        keyImage.SetActive(true);
    }

    void Update()
    {
        if (soulAmount == 13)
        {
            SceneManager.LoadScene("End");
        }
    }
}
