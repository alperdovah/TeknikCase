using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float distance;
    
    private void LateUpdate()
    {
        Transform tf = transform;
        Vector3 currentPos = tf.position;
        Vector3 newPos = new Vector3(currentPos.x, currentPos.y, player.position.z + distance);
        tf.position = newPos;
    }
}
