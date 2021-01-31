using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    void GameOver(bool timeout)
    {
        ScoreStatus.Timeout = timeout;
        SceneManager.LoadScene(1);
    }

    void GainPoint()
    {
        ScoreStatus.Score += 1;
    }
}
