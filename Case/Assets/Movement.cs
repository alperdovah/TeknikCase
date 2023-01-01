using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private const float X_LIMIT = 2f;
    [SerializeField] private float zSpeed , speedMultiplier, maxSwerveDelta;

    private Rigidbody _rigidbody;
    private float _prevX;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 pos = transform.position;
        Vector3 speed = Vector3.zero;
        if (Input.GetMouseButtonDown(0))
        {
            _prevX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            float _newX = Input.mousePosition.x;
            float moveXDelta = _newX - _prevX;
            float xDeltaClamped = Mathf.Clamp(moveXDelta * speedMultiplier, -maxSwerveDelta, maxSwerveDelta);
            if (xDeltaClamped > 0 && pos.x < X_LIMIT)
            {
                speed += new Vector3(xDeltaClamped, 0, 0);
                _prevX = _newX;
            }
            else if (pos.x > -X_LIMIT)
            {
                speed += new Vector3(xDeltaClamped, 0, 0);
                _prevX = _newX;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _prevX = 0;
        }

        speed += new Vector3(0, 0, zSpeed);
        _rigidbody.velocity = speed;
    }

    private void OnDisable()
    {
        _rigidbody.velocity = Vector3.zero;
    }
}