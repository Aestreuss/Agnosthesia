using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Characters", fileName = "New Character")]
public class Character : ScriptableObject
{
    //what data is needed
    public string characterName;
    public Sprite characterSprite;
    [TextArea]
    public string characterDescription;
}
