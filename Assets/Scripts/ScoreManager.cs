using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreManager: MonoBehaviour {

    int currentScore = 0;
    int maxScore = 0;
    Text maxScoreText;
    Text currentScoreText;
    Transform maxLabel;

    private bool _isHighScore = false;
    private void Awake()
    {
        var character = FindObjectOfType<MainCharacterController>();
        character.OnPlayerDead += OnPlayerDead;

        var texts = GetComponentsInChildren<Text>();
        currentScoreText = texts[0];
        maxScoreText = texts[1];
        maxLabel = texts[2].transform;

        maxScore = PlayerPrefs.GetInt( "Max", 0 );
        maxScoreText.text =ScoreToText(maxScore);

        currentScoreText.text = ScoreToText(currentScore);

    }

    public void OnScoreUp(int value)
    {
        currentScore += value;
        currentScoreText.text = ScoreToText( currentScore );
        if(!_isHighScore)
        {
            if(currentScore > maxScore)
            {
                _isHighScore = true;
                maxLabel.transform.DOLocalMoveX( -120, 1 );
                maxScoreText.gameObject.SetActive( false );
                maxScore = currentScore;
            }
        }
        else 
        {
            maxScore = currentScore;
        }
    }

    private string ScoreToText(int score)
    {
        var scoreText = score.ToString();
        var zerosCount = Mathf.Max(4, scoreText.Length + 1);
        scoreText = score.ToString( ).PadLeft( zerosCount, '0' );

        return scoreText;
    }


    void OnPlayerDead()
    {
        PlayerPrefs.SetInt( "Max", maxScore );
    }


}
