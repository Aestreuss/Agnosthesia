using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int soulsCollected;
    public UIManager uiManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            soulsCollected += 1;
            uiManager.UpdateSoulAmount(soulsCollected);
            Destroy(collision.gameObject);
        }
        
    }

}
