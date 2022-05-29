using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { mainMenu, pause, inGame, courseMenu, inShop, inEvent, gameOver };


public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    public GameState currentGameState;
    public GameObject CanvasCursos, CanvasMinijuegoQuiz, CanvasTienda;

    public AudioSource backgroundMusic;

    public int platziCoins;
    public int platziRank;



    // Start is called before the first frame update
    void Start()
    {
        platziCoins = 0;
        platziRank = 350;
        //Mas adelante este metodo debe cambiarse a MainMenu();
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        PauseCheck(currentGameState);
    }

    void PauseCheck(GameState gameState)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch(gameState)
            {
                case GameState.inGame:
                    PauseGame();
                    break;
                case GameState.pause:
                    StartGame();
                    break;
            }
        }
    }

    public void MainMenu()
    {
        SetGameState(GameState.mainMenu);
    }

    public void PauseGame()
    {
        SetGameState(GameState.pause);
    }

    public void StartGame()
    {
        SetGameState(GameState.inGame);
    }

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    void SetGameState(GameState newGameState)
    {
        switch (newGameState)
        {
            case GameState.mainMenu:
                currentGameState = GameState.mainMenu;
                PauseMenu.sharedInstance.BackToMainMenu();
                //Implementar logica de menu principal
                break;
            case GameState.pause:

                PauseMenu.sharedInstance.PauseGame();
                backgroundMusic.Pause();
                currentGameState = GameState.pause;
                break;
            case GameState.inGame:

                if (currentGameState == GameState.pause)
                {
                    PauseMenu.sharedInstance.ResumeGame();
                    backgroundMusic.Play();
                }
                else
                {
                    CursosManager.sharedInstance.HideCursosMenu();
                    ShopManager.sharedInstance.HideShop();
                }

                currentGameState = GameState.inGame;

                break;
            case GameState.gameOver:
                currentGameState = GameState.gameOver;
                //Implementar logica de game over

                break;
            case GameState.courseMenu:
                currentGameState = GameState.courseMenu;
                CursosManager.sharedInstance.ShowCursosMenu();

                break;
            case GameState.inShop:
                currentGameState = GameState.inShop;
                ShopManager.sharedInstance.ShowShop();

                break;

            case GameState.inEvent:
                currentGameState = GameState.inEvent;
                NarrativaManager.sharedInstance.ShowNarrativa();

                break;
        }

        currentGameState = newGameState;
    }

    public void CourseMenu()
    {
        SetGameState(GameState.courseMenu);
    }

    public void inShop()
    {
        SetGameState(GameState.inShop);
    }

    public void inEvent()
    {
        SetGameState(GameState.inEvent);
    }

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
