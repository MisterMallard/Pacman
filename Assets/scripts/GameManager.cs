using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GameObject gameOverUI;
	void Start()
	{

	}

	void Update()
	{

	}
	public void GameOver()
	{
		gameOverUI.SetActive(true);
		Time.timeScale = 0f;
	}

	
}