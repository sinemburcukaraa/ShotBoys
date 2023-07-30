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
        GameManager.instance.NotStarted();
    }
    public void OpenStartPanel()
    {
        startPanel.SetActive(true);

    }
    public void WriteText()
    {

        enemyCountText.SetText(EnemyManager.instance.enemyCount.ToString() + "/" + totalEnemyCount.ToString());
        GameManager.instance.Win();
    }

    public void OpenWinPanel()
    {
        winPanel.gameObject.SetActive(true);
        ClosegamePanel();

    }
    public void OpengameOverPanel()
    {


        gameOverPanel.gameObject.SetActive(true);
        ClosegamePanel();


    }
    public void OpengamePanel()
    {
        gamePanel.gameObject.SetActive(true);
        totalEnemyCount = EnemyManager.instance.enemyCount;
        WriteText();

    }
    public void ClosegamePanel()
    {
        gamePanel.gameObject.SetActive(false);
    }

    //public void OpenStartPanel()
    //{
    //    startPanel.SetActive(false);
    //}

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
