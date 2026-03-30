using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Transform A;
	[SerializeField] private Transform B;
	[SerializeField] private Transform Player;

	Vector3 differenceVector;
	float magnitude;
	Vector3 direction;
	float time = 0f;

	void Start()
	{
		differenceVector = B.position - A.position;
		magnitude = differenceVector.magnitude;
		direction = differenceVector.normalized;

		Debug.Log("Difference Vector: " + differenceVector);
		Debug.Log("Magnitude: " + magnitude);
		Debug.Log("Direction: " + direction);

		Player.position = A.position;
	}

	void Update()
	{
		Player.position += direction * Time.deltaTime;

		time += Time.deltaTime;

		if (time >= 15f)
		{
			time = 0f;
			Player.position = A.position;
		}
	}
}