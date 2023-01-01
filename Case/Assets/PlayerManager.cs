using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [Range(0f,1f)] [SerializeField] private float DistanceFactor, Radius;

    public int Score = 1;
    
    public void OnTriggered(Obstacle.Mode mode,int value)
    {
        switch (mode)
        {
            case Obstacle.Mode.Multiplication:
                MultiplicationBehaviour(value);
                break;
            case Obstacle.Mode.Addition:
                AdditionBehaviour(value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
        }
    }
    
    private void MultiplicationBehaviour(int value)
    {
        print(Score);
        int spawnCount = Score * value - 1;
        Debug.Log(value);
        SpawnCharacters(spawnCount);
    }

    private void AdditionBehaviour(int value)
    {
        SpawnCharacters(value);
    }
    
    private void SpawnCharacters(int count)
    {
        Score += count;
        for (int i = 0; i < count; i++)
        {
            Instantiate(prefab, transform.position , Quaternion.identity, transform);
        }
        OnScoreUpdate();
    }

    public void OnScoreUpdate()
    {
        FormatStickMan();
        ScoreText.Action?.Invoke(Score);
    }
    
    private void FormatStickMan()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            var x = DistanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * Radius);
            var z = DistanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * Radius);
            
            var NewPos = new Vector3(x,0,z);

            transform.GetChild(i).DOLocalMove(NewPos, 0.5f).SetEase(Ease.OutBack);
        }
    }
    
    
}
