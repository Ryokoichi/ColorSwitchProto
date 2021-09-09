using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

	public float jumpForce = 10f;

	public Rigidbody2D rb;
	public SpriteRenderer sr;

	public string currentColor;

	public Color colorCyan;
	public Color colorYellow;
	public Color colorMagenta;
	public Color colorPink;

	void Start()
	{
		SetRandomColor();
		
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
		{
			rb.velocity = Vector2.up * jumpForce;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "ColorChanger")
		{
			SetRandomColor();
			Destroy(col.gameObject);
			Debug.Log(col.tag);
			return;
			
		}

		if (col.tag != currentColor && col.tag != "ColorChanger")
		{
			Debug.Log("GAME OVER!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			Debug.Log(col.tag);
		}
	}

	void SetRandomColor()
	{
		int index = Random.Range(0, 4);

		switch (index)
		{
			case 0:
				currentColor = "Cyan";
				sr.material.color = colorCyan;
				break;
			case 1:
				currentColor = "Yellow";
				sr.material.color = colorYellow;
				break;
			case 2:
				currentColor = "Magenta";
				sr.material.color = colorMagenta;
				break;
			case 3:
				currentColor = "Pink";
				sr.material.color = colorPink;
				break;
		}

		/* if (index == 0)
        {
			currentColor = "Cyan";
			sr.material.color = colorCyan;
		}
		else if (index == 1)
        {
			currentColor = "Yellow";
			sr.material.color = colorYellow; 
		}
		else if (index == 2)
        {
			currentColor = "Magenta";
			sr.material.color = colorMagenta;
        }
		else if (index == 3)
        {
			currentColor = "Pink";
			sr.material.color = colorPink;
        }
	} */
	}
}