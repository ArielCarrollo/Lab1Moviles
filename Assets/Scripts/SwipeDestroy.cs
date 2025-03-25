using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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

    public void OnTouchStart(InputAction.CallbackContext context)
    {
        if (context.started && Touchscreen.current != null)
        {
            startTouchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            isSwiping = true;
            trailRenderer.enabled = true;
            trailRenderer.Clear();

            Vector3 touchPosition = mainCamera.ScreenToWorldPoint(new Vector3(startTouchPosition.x, startTouchPosition.y, -mainCamera.transform.position.z + zDepth));
            touchPosition.z = 0f;
            transform.position = touchPosition;

            if (selectionColor != null && selectionColor.SelectedColor != Color.white)
            {
                trailRenderer.startColor = selectionColor.SelectedColor;
                trailRenderer.endColor = selectionColor.SelectedColor;
            }
        }
    }

    public void OnTouchMove(InputAction.CallbackContext context)
    {
        if (context.performed && isSwiping && Touchscreen.current != null)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, -mainCamera.transform.position.z + zDepth));
            worldPosition.z = 0f;
            transform.position = worldPosition;
        }
    }

    public void OnTouchEnd(InputAction.CallbackContext context)
    {
        if (context.canceled && isSwiping && Touchscreen.current != null)
        {
            Vector2 endTouchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector2 swipeDirection = endTouchPosition - startTouchPosition;

            if (swipeDirection.magnitude > minSwipeDistance)
            {
                EliminarTodosLosObjetos();
            }
            isSwiping = false;
            trailRenderer.enabled = false;
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

