using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    private int _score;

    public void AddScore()
    {
        _score++;
        _scoreText.text = "Счет: " + _score;
    }

    private void Start()
    {
        _score = 0;
        _scoreText.text = "Счет: " + _score;
    }
}