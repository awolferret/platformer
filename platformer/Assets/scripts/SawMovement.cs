using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SawMovement : MonoBehaviour
{
    [SerializeField] private Transform _destinationPoint;

    private void Start()
    {
        transform.DOMove(CreateDetination(_destinationPoint), 3).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    private Vector2 CreateDetination(Transform destionation)
    {
        float xPosition = destionation.position.x;
        float yPosition = destionation.position.y;
        Vector2 destinationPoint = new Vector2(xPosition, yPosition);
        return destinationPoint;
    }
}