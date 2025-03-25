using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField] private SelectionColorSO selectionColor;
    [SerializeField] private SelectionSpriteSO selectionSprite;

    public void OnTap(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (selectionSprite.IsReadyToSpawn && selectionColor.IsReadyToSpawn)
            {
                Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, 0));
                worldPosition.z = 0f;

                GameObject newObject = Instantiate(prefab, worldPosition, Quaternion.identity);
                SpriteRenderer sr = newObject.GetComponent<SpriteRenderer>();
                sr.sprite = selectionSprite.SelectedSprite;
                sr.color = selectionColor.SelectedColor;

                selectionSprite.ResetSelections();
                selectionColor.ResetSelections();
            }
        }
    }
}
