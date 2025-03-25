using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSaver : MonoBehaviour
{
    [SerializeField]private SelectionColorSO selectionColor;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(SaveColor);
    }

    public void SaveColor()
    {
        Color color = GetComponent<Image>().color;
        selectionColor.SetColor(color);
    }
}
