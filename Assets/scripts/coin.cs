using UnityEngine;
using TMPro;

public class coin : MonoBehaviour
{
	private TextMeshProUGUI coinText;
	public int coins = 0;

	private void Start()
	{
		coinText = GameObject.FindWithTag("CoinText")?.GetComponent<TextMeshProUGUI>();
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			Player player = collision.GetComponentInParent<Player>();

			if (player == null)
			{
				Debug.LogError("Player component NOT found!");
				return;
			}

			player.coins += 1;

			if (coinText != null)
			{
				coinText.text = player.coins.ToString();
			}

			Destroy(gameObject);
		}
	}
}