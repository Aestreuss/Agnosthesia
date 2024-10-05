using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GiveSoul : MonoBehaviour
{
    public GameObject dialoguePanel; //references the whole dialogue panel
    public TextMeshProUGUI dialogueText;
    public string[] currentDialogue;
    public string[] dialogue; //contains the sentences
    public string[] altDialogue; //contains the sentences
    private int index; //helps find position within string

    public GameObject contButton; //references the continue button 

    public float wordspeed;
    public bool playerIsClose; //checks for when the player is in range

    PlayerMovement playerMovement; //references the player script
    PlayerStats playerStats; 

    public GameObject interactGUI;
    public bool interactClose;

    [Space]
    public bool isKeyNPC;
    public bool hasGivenSoul;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerIsClose)
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
                if (playerStats.hasKey)
                {
                    currentDialogue = altDialogue;

                }
                else
                {
                    currentDialogue = dialogue;
                }
                StartCoroutine(Typing(currentDialogue));

                playerMovement.canMove = false; //stops player from moving
            }
        }

        if (dialogueText.text == currentDialogue[index])
        {
            contButton.SetActive(true);
        }

        if (interactClose)
        {
            interactGUI.SetActive(true);
        }
        else
        {
            interactGUI.SetActive(false);
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);


    }
    IEnumerator Typing(string[] setDialogue)
    {
        foreach (char letter in setDialogue[index].ToCharArray())
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
            StartCoroutine(Typing(currentDialogue));
        }
        else
        {
            zeroText();
            playerMovement.canMove = true; //allows player to move again
            GiveSoulFromDialogue();
        }
    }

    public void GiveSoulFromDialogue()
    {
        if (playerStats.hasKey && isKeyNPC && !hasGivenSoul)
        {
            playerStats.uiManager.UpdateSoulAmount();
            hasGivenSoul = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactClose = true;
            playerIsClose = true;
            playerMovement = other.GetComponent<PlayerMovement>(); //grab ref of player movement upon coming closer
            playerStats = other.GetComponent<PlayerStats>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactClose = false;
            playerIsClose = false;
            playerMovement = null;
            zeroText();
        }
    }


}
