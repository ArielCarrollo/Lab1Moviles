using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField]private SelectionColorSO selectionColor;
    [SerializeField] private SelectionSpriteSO selectionSprite;
    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (selectionSprite.IsReadyToSpawn && selectionColor.IsReadyToSpawn)
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                touchPosition.z = 0f;

                GameObject newObject = Instantiate(prefab, touchPosition, Quaternion.identity);
                SpriteRenderer sr = newObject.GetComponent<SpriteRenderer>();
                sr.sprite = selectionSprite.SelectedSprite;
                sr.color = selectionColor.SelectedColor;

                selectionSprite.ResetSelections();
                selectionColor.ResetSelections();
            }
        }
    }
}
