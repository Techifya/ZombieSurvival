using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour
{

    public GameObject fadeOut;
    public GameObject loadText;
    public AudioSource buttonClick;
    public AudioSource mainSound;
    public GameObject storyText;

  
    void Start(){
        Cursor.visible = true;
        Time.timeScale = 1;
        AudioListener.pause = false;
        
    }
    // Start is called before the first frame update
    
    public void NewGameButton()
    {
        StartCoroutine(NewGameStart());
    }

    private IEnumerator NewGameStart(){
        fadeOut.SetActive(true);
        buttonClick.Play();
        yield return new WaitForSeconds(3);

        
        SceneManager.LoadScene(1);
        
    }

    public void ExitGameButton(){
    
        StartCoroutine(ExitGame());
        
        
    }

    private IEnumerator ExitGame(){
        fadeOut.SetActive(true);
        buttonClick.Play();
        yield return new WaitForSeconds(3);
        Application.Quit();
    }

    public void StoryGameButton(){
    
        StartCoroutine(StoryGame());
        
        
    }

    private IEnumerator StoryGame(){
        fadeOut.SetActive(true);
        buttonClick.Play();
        yield return new WaitForSeconds(2);
        storyText.SetActive(true);
        yield return new WaitForSeconds(10);
        storyText.SetActive(false);
        fadeOut.SetActive(false);
    }
    
}
