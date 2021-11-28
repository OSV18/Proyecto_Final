using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileManager : MonoBehaviour
{
    public static ProfileManager instance;

    [SerializeField] private string playerName;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetPlayerName(string newName)
    {
        playerName = newName;
    }

    public string GetplayerName()
    {
        return playerName;
    }

}
