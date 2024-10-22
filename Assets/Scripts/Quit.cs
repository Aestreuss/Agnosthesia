using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void GameQuit()
    {
        Debug.Log("quit check");
        Application.Quit();
    }
}
