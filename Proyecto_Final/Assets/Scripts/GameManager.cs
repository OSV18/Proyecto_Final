using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int score;
    private int scorInstanciado;
    
        
    public enum typesConsumables { Firstaid, Canned }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            score = 0;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addScore()
    {
        instance.scorInstanciado += 1;
    }

    public static int GetScore()
    {
        return instance.scorInstanciado;
    }

  

}
