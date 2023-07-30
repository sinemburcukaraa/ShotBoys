using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public enum GameSit { notStarted, Started, Win, GameOver }

    public GameSit gameSit;

    private void Awake()
    {
        if (!instance)
            instance = this;
    }

    public void Win()
    {
        if (gameSit == GameSit.Started && EnemyManager.instance.enemyCount == 0)
        {
            gameSit = GameSit.Win;
            PlayerPrefs.SetInt("LevelCount", PlayerPrefs.GetInt("LevelCount") + 1);
            PlayerPrefs.SetInt("nextLevel", PlayerPrefs.GetInt("nextLevel") + 1);

            UIManager.instance.OpenWinPanel();
        }
    }

    public void GameOver()
    {
        if (gameSit == GameSit.Started && ClientPooling.instance.numberOfShots == 0 && EnemyManager.instance.enemyCount > 0)
        {
            gameSit = GameSit.GameOver;
            PlayerPrefs.SetInt("LevelCount", PlayerPrefs.GetInt("LevelCount"));
            PlayerPrefs.SetInt("nextLevel", PlayerPrefs.GetInt("nextLevel"));

            UIManager.instance.OpengameOverPanel();

        }
    }
    public void Started()
    {
        gameSit = GameSit.Started;

        UIManager.instance.OpengamePanel();
        LevelManager.instance.LevelTextControl();

    }

    public void NotStarted()
    {

        if (gameSit != GameSit.Started)
        {
            gameSit = GameSit.notStarted;
            Debug.Log("not");

            UIManager.instance.OpenStartPanel();
            LevelManager.instance.NextLevel();
            if (Input.GetMouseButtonUp(0))
            {
                print("dsfv");
                //Invoke("Win", 2.0f);
                UIManager.instance.startPanel.SetActive(false); 
                Started();
            }

        }
    }

}
