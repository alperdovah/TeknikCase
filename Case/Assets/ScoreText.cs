using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public static Action<int> Action;
    [SerializeField] private Transform player;

    private TextMeshPro textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshPro>();

        Action += SetScore;
    }

    private void Update()
    {
        var transform1 = transform;
        var position = player.position;
        transform1.position = new Vector3(position.x, transform1.position.y, position.z);
    }

    private void SetScore(int score)
    {
        textMesh.text = score.ToString();
    }
}