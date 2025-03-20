using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public Sprite SelectedSprite { get; private set; }
    public Color SelectedColor { get; private set; } = Color.white;

    public bool IsReadyToSpawn => SelectedSprite != null && SelectedColor != Color.white;

    public void SetSprite(Sprite sprite)
    {
        SelectedSprite = sprite;
    }

    public void SetColor(Color color)
    {
        SelectedColor = color;
    }

    public void ResetSelections()
    {
        SelectedSprite = null;
        SelectedColor = Color.white;
    }
}
