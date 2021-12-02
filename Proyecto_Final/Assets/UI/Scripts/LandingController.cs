using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class LandingController : MonoBehaviour
{
    [SerializeField] private InputField inputUserName;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnChangeInputUserName()
    {
        Debug.Log("CHANGE");
        Debug.Log(inputUserName.text);

    }

    public void OnEndEditInputUsername()
    {
        Debug.Log("END EDIT");
        ProfileManager.instance.SetPlayerName(inputUserName.text);
        Debug.Log("USERNAME GUADADO" + ProfileManager.instance.GetplayerName());
    }

    public void OnChangeToggleName(bool newStatus)
    {

    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene("Level 1");
    }

}
