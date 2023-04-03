using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] Animator transition;
    [SerializeField] float transitionTime = 1;
    [SerializeField] GameObject[] menuUI; // index 0: button, index 1: panel

    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void ShowMenu()
    {
        Time.timeScale = 0;
        menuUI[0].SetActive(false);
        menuUI[1].SetActive(true);
    }
    
    public void HideMenu()
    {
        Time.timeScale = 1;
        menuUI[0].SetActive(true);
        menuUI[1].SetActive(false);
    }

    void LoadNextLevel()
    {
        StartCoroutine(Load(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadLevel(int levelIndex)
    {
        HideMenu();
        StartCoroutine(Load(levelIndex));
    }

    IEnumerator Load(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
