using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SelectionData", menuName = "ScriptableObjects/SelectionColor", order = 1)]
public class SelectionColorSO : ScriptableObject
{
    [SerializeField] private Color selectedColor = Color.black;
    public Color SelectedColor => selectedColor;

    public bool IsReadyToSpawn => selectedColor != Color.black;

    public void SetColor(Color color)
    {
        selectedColor = color;
    }

    public void ResetSelections()
    {
        selectedColor = Color.black;
    }
}
