using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDestroy : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private bool isSwiping = false;
    private float minSwipeDistance = 100f; // Distancia mínima para considerar un swipe válido

    private TrailRenderer trailRenderer;
    private Camera mainCamera;
    [SerializeField] private SelectionManager selectionManager;

    private float zDepth; // Profundidad del TrailRenderer en la cámara ortográfica

    private void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        mainCamera = Camera.main;
        trailRenderer.enabled = false; // Desactivado al inicio

        // Establecemos la profundidad Z en la que queremos que se dibuje el Trail
        zDepth = 0f; // Puedes cambiar esto si quieres que se dibuje en otra profundidad
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = mainCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, -mainCamera.transform.position.z + zDepth));

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchPosition = touch.position;
                    isSwiping = true;
                    trailRenderer.enabled = true;
                    trailRenderer.Clear();
                    transform.position = touchPosition;

                    if (selectionManager != null && selectionManager.SelectedColor != Color.white)
                    {
                        trailRenderer.startColor = selectionManager.SelectedColor;
                        trailRenderer.endColor = selectionManager.SelectedColor;
                    }
                    break;

                case TouchPhase.Moved:
                    if (isSwiping)
                    {
                        transform.position = touchPosition; // Actualiza la posición del TrailRenderer
                    }
                    break;

                case TouchPhase.Ended:
                    if (isSwiping)
                    {
                        Vector2 endTouchPosition = touch.position;
                        Vector2 swipeDirection = endTouchPosition - startTouchPosition;

                        if (swipeDirection.magnitude > minSwipeDistance)
                        {
                            EliminarTodosLosObjetos();
                        }
                    }
                    isSwiping = false;
                    trailRenderer.enabled = false; // Desactiva el TrailRenderer
                    break;
            }
        }
    }

    private void EliminarTodosLosObjetos()
    {
        GameObject[] objetos = GameObject.FindGameObjectsWithTag("ObjectSpawn");

        for (int i = 0; i < objetos.Length; i++)
        {
            Destroy(objetos[i]);
        }
    }
}
