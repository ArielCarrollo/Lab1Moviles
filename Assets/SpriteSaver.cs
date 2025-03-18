using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSaver : MonoBehaviour
{
    public Sprite buttonsprite;
    public GameObject prefabSprite;
    public void SaveSprite()
    {
        buttonsprite = this.GetComponent<Image>().sprite;
        prefabSprite.GetComponent<SpriteRenderer>().sprite = buttonsprite;
    }
}
