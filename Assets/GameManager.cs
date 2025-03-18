using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SpriteSaver spriteSaver;
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            touchPosition.z = 0f;

            if (spriteSaver.buttonsprite != null)
            {
                GameObject newSpriteObject = Instantiate(spriteSaver.prefabSprite, touchPosition, Quaternion.identity);
                SpriteRenderer spriteRenderer = newSpriteObject.GetComponent<SpriteRenderer>();

                if (spriteRenderer != null)
                {
                    spriteRenderer.sprite = spriteSaver.buttonsprite;
                }
            }
        }
    }
}
