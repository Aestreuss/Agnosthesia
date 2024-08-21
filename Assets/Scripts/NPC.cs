using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel; //references the whole dialogue panel
    public TextMeshProUGUI dialogueText;
    public string[] dialogue; //contains the sentences
    private int index; //helps find position within string

    public GameObject contButton; //references the continue button 

    public float wordspeed;
    public bool playerIsClose; //checks for when the player is in range

    PlayerMovement playerMovement; //references the player script



    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && playerIsClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
                
            }
            else
            {
                dialoguePanel.SetActive(true);
                dialogueText.text = "";
                StopAllCoroutines();
                StartCoroutine (Typing());

                playerMovement.canMove = false; //stops player from moving
            }
        }

        if(dialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);

        

    }
    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordspeed); //will set up how fast the words are typed out 
        }
    }

    public void NextLine()
    {

        contButton.SetActive(false);

        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine (Typing());
        }
        else
        {
            zeroText();
            playerMovement.canMove = true; //allows player to move again
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            playerMovement = other.GetComponent<PlayerMovement>(); //grab ref of player movement upon coming closer
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            playerMovement = null; 
            zeroText();
        }
    }
}
