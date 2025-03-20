using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragger : MonoBehaviour
{
    private bool isDragging = false;
    private Camera mainCamera;
    private float zDepth;

    private void Start()
    {
        mainCamera = Camera.main;
        zDepth = transform.position.z;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = mainCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, -mainCamera.transform.position.z + zDepth));

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = mainCamera.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        isDragging = true;
                    }
                }
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                transform.position = new Vector3(touchPosition.x, touchPosition.y, zDepth);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
            }
        }
    }
}
