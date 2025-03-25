using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSaver : MonoBehaviour
{
    [SerializeField]private SelectionSpriteSO selectionSprite;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(SaveSprite);
    }

    public void SaveSprite()
    {
        Sprite sprite = GetComponent<Image>().sprite;
        selectionSprite.SetSprite(sprite);
    }
}
