using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSaver : MonoBehaviour
{
    [SerializeField]private SelectionManager selectionManager;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(SaveSprite);
    }

    public void SaveSprite()
    {
        Sprite sprite = GetComponent<Image>().sprite;
        selectionManager.SetSprite(sprite);
    }
}
