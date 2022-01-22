using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Title_Screen : MonoBehaviour
{
    // var to load level (string)
    public string newGameString;
    // var to load options
    public string loadOptions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // when clicked it should load into sample scene 
    public void NewGame() 
    {
        // debug
        Debug.Log("button has been clicked");
        SceneManager.LoadScene(newGameString);
    
    }
    // quit game function
    public void QuitGame()
    {
        Application.Quit();
       
    }
    public void LoadOptions()
    {

        SceneManager.LoadScene(loadOptions);
    }
}
