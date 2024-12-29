using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntityView
{
    void UpdateHealthColor(Vector3 health);
    void UpdatePositionAndRotation(Vector3 position, Vector3 lookDir);
    
    void SetActive(bool isActive);
}
