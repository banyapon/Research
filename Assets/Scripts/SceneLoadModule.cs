using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoadModule : MonoBehaviour
{
    public InputField inputName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScenefunction(string sceneName)
    {
        SceneManager.LoadScene(sceneName,LoadSceneMode.Single);
    }

    public void chooseFunction(string functionName)
    {
        PlayerPrefs.SetString("type", functionName);
        PlayerPrefs.SetString("player", inputName.text);
    }
}
