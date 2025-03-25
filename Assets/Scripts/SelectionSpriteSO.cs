using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SelectionData", menuName = "ScriptableObjects/SelectionSprite", order = 1)]
public class SelectionSpriteSO : ScriptableObject
{
    [SerializeField] private Sprite selectedSprite;

    public Sprite SelectedSprite => selectedSprite;

    public bool IsReadyToSpawn => selectedSprite != null;

    public void SetSprite(Sprite sprite)
    {
        selectedSprite = sprite;
    }

    public void ResetSelections()
    {
        selectedSprite = null;
    }
}
