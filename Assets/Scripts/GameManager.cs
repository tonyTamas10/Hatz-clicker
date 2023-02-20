using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static float timer;
    public static readonly int GameSceneIndex = 1;
    public static readonly int SplashSceneIndex = 0;
    public int CurrentSceneIndex = 0;

    void Awake()
    {
        
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentSceneIndex == SplashSceneIndex) {
            if (timer >= 3)
            {
                LoadScene(GameSceneIndex);
                CurrentSceneIndex = GameSceneIndex;
                timer = 0;
            }
            else
                timer += Time.deltaTime;
        }
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
