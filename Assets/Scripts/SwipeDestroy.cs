using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDestroy : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private bool isSwiping = false;
    private float minSwipeDistance = 100f; // Distancia mínima para considerar un swipe válido

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
                isSwiping = true;
            }
            else if (touch.phase == TouchPhase.Ended && isSwiping)
            {
                Vector2 endTouchPosition = touch.position;
                Vector2 swipeDirection = endTouchPosition - startTouchPosition;

                if (swipeDirection.magnitude > minSwipeDistance) // Deslizar en cualquier dirección
                {
                    EliminarTodosLosObjetos();
                }
                isSwiping = false;
            }
        }
    }

    private void EliminarTodosLosObjetos()
    {
        GameObject[] objetos = GameObject.FindGameObjectsWithTag("ObjectSpawn");

        // Usamos un for tradicional por eficiencia
        for (int i = 0; i < objetos.Length; i++)
        {
            Destroy(objetos[i]);
        }
    }
}
