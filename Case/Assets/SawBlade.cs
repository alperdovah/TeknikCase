using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SawBlade : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var unit = other.transform.parent;
        
        Transform parent = unit.parent;
        unit.DOKill();
        Destroy(unit.gameObject);
        
        if (parent.CompareTag("Player"))
        {
            var script = other.transform.parent.parent.GetComponent<PlayerManager>();
            script.Score--;
            script.OnScoreUpdate();
        }
    }

    private void Update()
    {
        transform.Rotate(0,0,3);
    }
}
