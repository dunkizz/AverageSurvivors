using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private Player player;
    [SerializeField]private GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.currentUnitHealth <= 0)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScence");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScence");
    }
}
