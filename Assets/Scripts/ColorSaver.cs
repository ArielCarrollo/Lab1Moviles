using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSaver : MonoBehaviour
{
    [SerializeField]private SelectionManager selectionManager;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(SaveColor);
    }

    public void SaveColor()
    {
        Color color = GetComponent<Image>().color;
        selectionManager.SetColor(color);
    }
}
