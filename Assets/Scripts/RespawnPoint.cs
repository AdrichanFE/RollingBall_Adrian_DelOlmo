using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public Vector3 position;

    public void SetPosition(Vector3 newPosition)
    {
        position= newPosition;
    }
}
