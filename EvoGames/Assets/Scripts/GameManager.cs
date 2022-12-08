using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Fields
    private PickUpAnimals pickUpAnimals;
    public float t;
    public float tiger, chicken, cow, sheep, straw;
    [Header("Lists")]
    [SerializeField] internal List<GameObject> farm1, farm2, farm3, farm4 = new List<GameObject>();
    [Header("Objects")]
    [SerializeField] private GameObject winScreen, loseScreen, openingCam, openingText;
    public GameObject animal;
    [Header("Bools")]
    public bool cowCompleted, sheepCompleted, tigerCompleted, chickenCompleted, strawCompleted;
    public bool isExit;
    #endregion

    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }
    #endregion

    private void Awake()
    {
        pickUpAnimals = GetComponent<PickUpAnimals>();
    }
    private void Start()
    {
        //Using the tags of the animals, we find out how many they are on the map at the beginning.
        cow = GameObject.FindGameObjectsWithTag("Cow").Length;
        tiger = GameObject.FindGameObjectsWithTag("Tiger").Length;
        chicken = GameObject.FindGameObjectsWithTag("Chicken").Length;
        sheep = GameObject.FindGameObjectsWithTag("Sheep").Length;
        straw = GameObject.FindGameObjectsWithTag("Straw").Length;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            openingCam.SetActive(false);
            openingText.SetActive(false);
        }
        if (cowCompleted && chickenCompleted && strawCompleted && sheepCompleted && tigerCompleted)
        {
            CompleteGame();
        }

    }

    #region Complete/Lose
    public void CompleteGame()
    {
        winScreen.SetActive(true);
    }
    public void LoseGame()
    {
        loseScreen.SetActive(true);
    }
    #endregion

    #region Buttons
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
        Application.Quit();
    }
    #endregion
}
