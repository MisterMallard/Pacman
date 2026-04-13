using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public int coins = 0;

	private void Update()
	{
		CheckWin();
	}

	private void CheckWin()
	{
		if (coins >= 50)
		{
			SceneManager.LoadScene("win");
		}
	}
}