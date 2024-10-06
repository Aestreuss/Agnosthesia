using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int soulsCollected;
    public UIManager uiManager;
    public bool hasKey;
    public Timer timer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            soulsCollected += 1;
            uiManager.UpdateSoulAmount();
            Destroy(collision.gameObject);
            timer.AddTime(10);
        }
        
        if (collision.CompareTag("Key"))
        {
            Debug.Log("key collide");

            hasKey = true;
            uiManager.KeyFound(hasKey);
            Destroy(collision.gameObject);
        }
    }



}
