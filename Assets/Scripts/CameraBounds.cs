using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public float deadzone = 3f;
    public Rect bounds; // min x, max x, min y, max y - bounds

    private void FixedUpdate()
    {
        float orthoSize = Camera.main.orthographicSize;
        float aspectRatio = (float)Screen.width / (float)Screen.height;

        float viewHeight = 2 * orthoSize;
        float viewWidth = viewHeight * aspectRatio;

        Vector3 camPos = transform.position;

        float x = camPos.x - (viewWidth / 2 + deadzone); // -x
        float y = camPos.y - (viewHeight / 2 + deadzone); // +y

        bounds = new Rect(x, y, viewWidth, viewHeight);
        
        Draw();
    }

    private void Draw()
    {
        Debug.DrawLine(new Vector3(bounds.xMin, bounds.yMin, 0f), new Vector3(bounds.xMin, bounds.yMax, 0f), Color.magenta, Time.deltaTime);
        Debug.DrawLine(new Vector3(bounds.xMin, bounds.yMin, 0f), new Vector3(bounds.xMax, bounds.yMin, 0f), Color.magenta, Time.deltaTime);
        Debug.DrawLine(new Vector3(bounds.xMax, bounds.yMin, 0f), new Vector3(bounds.xMax, bounds.yMax, 0f), Color.magenta, Time.deltaTime);
        Debug.DrawLine(new Vector3(bounds.xMax, bounds.yMax, 0f), new Vector3(bounds.xMin, bounds.yMax, 0f), Color.magenta, Time.deltaTime);
    }
}
