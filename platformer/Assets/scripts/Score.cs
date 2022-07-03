using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private UnityEvent _pickUp;

    private int _score;

    public void AddScore()
    {
        _pickUp.Invoke();
        _score++;
    }

    private void Start()
    {
        _score = 0;
    }

    private void FixedUpdate()
    {
        _scoreText.text = "Счет: " + _score;
    }
}