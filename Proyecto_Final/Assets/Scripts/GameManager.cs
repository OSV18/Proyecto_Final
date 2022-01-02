using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static float life;
    public static int score;
    public static float energy;
    private int scorInstanciado;

    public static int ID;
    public static string type;
    public static string description;
    public static Sprite icon;


    public enum typesItem { Firstaid, Fuel, Water, Flashlight, Mask, Food }
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;           
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
       
        
           
        
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerContoller.onDeath += GameOver;
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Setlife(float newLife)
    {
        life = newLife;
    }

    public float GetLife()
    {
        return life;
    }

    public void SetEnergy(float newEnergy)
    {
        energy = newEnergy;
    }

    public float GetEnergy()
    {
        return energy;
    }

    public void addScore()
    {
        Instance.scorInstanciado += 1;
    }

    public static int GetScore()
    {
        return Instance.scorInstanciado;
    }

    private void GameOver()
    {
        if (life == 0)
        {
            Debug.Log("GAME OVER");
            scorInstanciado = 0;
        }
    }

}
