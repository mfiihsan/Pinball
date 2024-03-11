using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project_Pinball.UI
{
    public class GameStateController : MonoBehaviour
    {
        [SerializeField] GameState currentState;
        [SerializeField] GameObject gameOverPanel;
        [SerializeField] GameObject pausePanel;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                switch (currentState)
                {
                    case GameState.Play: pauseGame();break;
                    case GameState.Pause: resumeGame(); break;
                    default: break;
                }
            }
        }

        public void resumeGame()
        {
            if (currentState != GameState.Pause) return;
            pausePanel?.SetActive(false);
            currentState = GameState.Play;
            Time.timeScale = 1;
        }

        public void pauseGame()
        {
            if (pausePanel == null) return;
            if (currentState != GameState.Play) return;
            pausePanel?.SetActive(true);
            currentState = GameState.Pause;
            Time.timeScale = 0;
        }

        public void restartGame()
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void setGameOver()
        {
            SceneManager.LoadScene("GameOverScene");
        }

        public void changeSceneByName(string name)
        {
            SceneManager.LoadScene(name);
        }

        public void quitGame()
        {
            Application.Quit();
        }
    }

    public enum GameState
    {
        Play,
        Pause,
        Over
    }
}
