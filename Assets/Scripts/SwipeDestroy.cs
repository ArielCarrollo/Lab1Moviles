using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDestroy : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private bool isSwiping = false;
    private float minSwipeDistance = 100f; 

    private TrailRenderer trailRenderer;
    private Camera mainCamera;
    [SerializeField] private SelectionColorSO selectionColor;

    private float zDepth;

    private void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        mainCamera = Camera.main;
        trailRenderer.enabled = false; 

        zDepth = 0f; 
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

                    if (selectionColor != null && selectionColor.SelectedColor != Color.white)
                    {
                        trailRenderer.startColor = selectionColor.SelectedColor;
                        trailRenderer.endColor = selectionColor.SelectedColor;
                    }
                    break;

                case TouchPhase.Moved:
                    if (isSwiping)
                    {
                        transform.position = touchPosition;
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
                    trailRenderer.enabled = false;
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
