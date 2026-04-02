using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton örneði
    public static GameManager instance;
    public AudioSource deadSound;
    public string[] scenes;
    public int sceneIndex = 0;
    string currentScene;


    void Awake()
    {
        // Eðer daha önceden bir GameManager varsa, bu yeni geleni yok et
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Bu nesneyi Singleton yap ve sahneler arasý koru
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        UpdateCurrentScene();
    }

    public void RestartLevel()
    {
        deadSound.Play();
        SceneManager.LoadScene(currentScene);
    }

    public void LevelUp()
    {
        if (sceneIndex < scenes.Length - 1)
        {          
            sceneIndex++;
            UpdateCurrentScene();
            SceneManager.LoadScene(currentScene);
        }
        else
        {
            Debug.Log("Oyun bitti, baþka sahne yok!");
        }
    }

    void UpdateCurrentScene()
    {
        currentScene = scenes[sceneIndex];
    }
}
