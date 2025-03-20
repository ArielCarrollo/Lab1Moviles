using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefab : MonoBehaviour
{
    private float lastTapTime = 0f;
    private float doubleTapThreshold = 0.3f; // Tiempo máximo entre toques para considerarlo un doble tap

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    if (Time.time - lastTapTime <= doubleTapThreshold)
                    {
                        Destroy(gameObject); // Destruye el objeto si se detecta un doble tap
                    }
                    lastTapTime = Time.time;
                }
            }
        }
    }
}
