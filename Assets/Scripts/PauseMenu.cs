using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    LevelSystem levelSystem;

    [SerializeField] private GameObject pauseMenuUI;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        levelSystem = GetComponent<LevelSystem>();
    }

    // Update is called once per frame
    void Update()
    {
    
        if(Input.GetKeyDown(KeyCode.Escape)){
            if (!isPaused){
                StartCoroutine(PauseGame());
            }
            else{
                isPaused = false;
            }
            
          
        }
        if(isPaused){
            
            ActivateMenu();
        }
        else{
            DeactivateMenu();
        }
       
    }

    private IEnumerator PauseGame(){
        Cursor.visible = true;
        yield return new WaitForSeconds(0.2f);
        isPaused = true;
        
        
    }

    void ActivateMenu(){
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);
       
    }

    public void DeactivateMenu(){
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

    public void showCursor(){
        
        Cursor.visible = true;

       
    }

    public void GoToMainMenu(){
        SceneManager.LoadScene(0);
    }
}
