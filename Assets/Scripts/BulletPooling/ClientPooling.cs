using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ClientPooling : MonoBehaviour
{
    private BulletPooling _pool;
    public int index;
    public int numberOfShots;
    public TextMeshProUGUI numberOfShotsText;
    public  static ClientPooling instance;
    
    private void Awake()
    {
        if (instance == null) { instance = this; }
    }
    void Start()
    {
        _pool = gameObject.AddComponent<BulletPooling>();
        PrintText();
    }
    private void Update()
    {
        if (GameManager.instance.gameSit == GameManager.GameSit.Started)
        {
            if (Input.GetMouseButtonDown(0) && numberOfShots > 0)
            {
                //text control
                numberOfShots--;
                PrintText();

                //Shot
                _pool.StartShot();
            }
        }
        
    }

    public void PrintText()
    {
        numberOfShotsText.SetText(numberOfShots.ToString());
        //UIManager.instance.OpengameOverPanel(numberOfShots);
    }
}