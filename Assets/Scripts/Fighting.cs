using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fighting : MonoBehaviour
{

    public int summonedIndex = 0;
    public List<Sprite> summonedCharacterSprites = new List<Sprite>();
    public SpriteRenderer summonendCharacterSpriteRenderer;

    public void finalCheck()
    {

        //summonendCharacterSpriteRenderer.sprite = summonedCharacterSprites[summonedIndex];
        
        if (summonedIndex == 0)
        {
            //YOU WIN
        }
        else
        {
            //LOSE ANOTHER VILLAGE
        }
    }

    public void setSummonedIndex(int summonedIndex)
    {
        this.summonedIndex = summonedIndex;
    }
}
