using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelect : MonoBehaviour
{
    [Header("In project folders")]
    public Character currentCharacter; // reference the scriptable object in project folder

    [Header("In the Hierarchy")]
    public Image characterImage; //reference to the image in the editor
    public TextMeshProUGUI characterNameText;//references to the text for name
    public TextMeshProUGUI characterDescriptionText; //reference to the text for description

    void Start()
    {
        UpdateCharacter();
    }

    public void UpdateCharacter()
    {
        characterImage.sprite = currentCharacter.characterSprite; //sets sprite
        characterNameText.text = currentCharacter.characterName; //sets name
        characterDescriptionText.text = currentCharacter.characterDescription; //sets description
    }
}
