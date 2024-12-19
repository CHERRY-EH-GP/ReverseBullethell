using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class joypad : MonoBehaviour
{
    public Canvas canvas;

    public Camera camera;

    public RectTransform joypadArea;

    public RectTransform joypadBounds;

    public RectTransform joypadDot;

    public bool dynamicJoypad = true;

    public float joypadMaxDistance;

    [Header("Input values")]
    public Vector2 direction;

    public float strength;

    private  Vector2 mousePos;

    private void Awake()
    {
        joypadBounds.gameObject.SetActive(!dynamicJoypad);
        joypadDot.gameObject.SetActive(!dynamicJoypad);
    }

    //Start
    public void OnDragBegin()
    {
        mousePos = Input.mousePosition;

        if(dynamicJoypad)
        {
            joypadBounds.gameObject.SetActive(true);
            joypadDot.gameObject.SetActive(true);
            joypadBounds.anchoredPosition = ScreenPointToLocalRectPoint(mousePos, joypadArea);
        }


    }

    //Update
    public void OnDrag()
    {
        Vector2 mousePos = (Vector2)Input.mousePosition;

        direction = mousePos - LocalRectPointToScreenPoint(joypadBounds);

        float magnitude = direction.magnitude;

        if (magnitude > 0)
        {
            direction.Normalize();
        }

        if (magnitude < joypadMaxDistance)
        {
            joypadDot.anchoredPosition = ScreenPointToLocalRectPoint(mousePos, joypadBounds);
        }
        else
        {
            //Vector2 screenPosJoypadBounds = LocalRectPointToScreenPoint(joypadBounds);
            //Vector2 dir = (mousePos - screenPosJoypadBounds) * joypadMaxDistance;
            //joypadDot.anchoredPosition = ScreenPointToLocalRectPoint(screenPosJoypadBounds + dir, joypadBounds);
        }

        strength = Mathf.Clamp(magnitude / joypadMaxDistance, 0f, 1f);
    }

    public void OnDragEnd()
    {
        if (dynamicJoypad)
        {
            joypadBounds.gameObject.SetActive(false);
            joypadDot.gameObject.SetActive(false);  
        }
    }

    public Vector2 ScreenPointToLocalRectPoint(Vector2 mousePos, RectTransform parent)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parent,
            mousePos,
            Camera.main,
            out Vector2 localPoint
            );
        return localPoint;
    }

    public Vector2 LocalRectPointToScreenPoint(RectTransform target)
    {
        Vector3 targetWorldPos = target.position;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(targetWorldPos);

        return screenPos;
    }


}
