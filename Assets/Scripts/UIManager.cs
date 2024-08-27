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
    public int key;

    public void UpdateSoulAmount(int soulsAmount)
    {
        soulAmount += 1;
        soulAmount_Text.text = "Souls: " + soulsAmount.ToString();       
    }

    public void KeyFound(int keyCollected)
    {
        key += 1;
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
