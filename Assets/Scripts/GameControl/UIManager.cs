using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI enemyCountText;
    public static UIManager instance;
    public GameObject winPanel, gameOverPanel, gamePanel, startPanel;
    int totalEnemyCount;
    private void Awake()
    {
        if (!instance)
            instance = this;
    }
    void Start()
    {
        OpengamePanel();
        totalEnemyCount = EnemyManager.instance.enemyCount;

        WriteText();
    }

    public void WriteText()
    {
        enemyCountText.SetText(EnemyManager.instance.enemyCount.ToString() + "/" + totalEnemyCount.ToString());
        OpenWinPanel();
    }
    
    public void OpenWinPanel()
    {
        if (EnemyManager.instance.enemyCount == 0)
        {
            winPanel.gameObject.SetActive(true);
            ClosegamePanel();
            GameManager.instance.Win();

        }

    }
    public void OpengameOverPanel()
    {
        if (ClientPooling.instance.numberOfShots == 0 && EnemyManager.instance.enemyCount > 0)
        {
            gameOverPanel.gameObject.SetActive(true);
            ClosegamePanel();
            GameManager.instance.GameOver();
        }

    }
    public void OpengamePanel()
    {
        gamePanel.gameObject.SetActive(true);
    }
    public void ClosegamePanel()
    {
        gamePanel.gameObject.SetActive(false);
    }

    //public void OpenStartPanel()
    //{
    //    startPanel.SetActive(false);
    //}

    //public void restartLevel()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}


}
