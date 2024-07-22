using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject win;

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            // Player has collected the map, set the HUD object active
            win.SetActive(true);
            
        }
    }

    
    public void MenuButton(string levelname)
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
