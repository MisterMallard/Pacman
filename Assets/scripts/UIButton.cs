using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
	// Call this from your UI Button
	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
	}
