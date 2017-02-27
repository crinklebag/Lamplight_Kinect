using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuFly : MonoBehaviour {

	public float glowlevel = 0.0f;
	public float playtime = 3;
	public float wait = 2.0f;
	[SerializeField] Text countdown;
	// Use this for initialization

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Play")
		{
			Debug.Log ("Glowing");
			Glow ();
		}
		else
			glowlevel = Mathf.Lerp(glowlevel,0.0f, Time.deltaTime);	
	}

	void OnTriggerExit2D(Collider2D col)
	{
		playtime = 3;
		countdown.gameObject.SetActive(false);

	}
	// Update is called once per frame
	void Update () {


		Color tempColor = this.GetComponent<SpriteRenderer> ().color;
		tempColor.a = glowlevel;
		if (Input.GetKey ("up")) {
			glowlevel = Mathf.Lerp (glowlevel, 1.0f, Time.deltaTime);
		} else {
			glowlevel = Mathf.Lerp(glowlevel,0.0f, Time.deltaTime);	
		}

		if (Input.GetKeyDown ("down")) 
		{
			glowlevel -= 0.05f;
		}

		this.GetComponent<SpriteRenderer> ().color = tempColor;
}

	void Glow(){
		//glowlevel += 0.5f;
		glowlevel = Mathf.Lerp(glowlevel,1.0f, Time.deltaTime);
		wait -= Time.deltaTime;

		if (wait <= 0) 
		{
			countdown.gameObject.SetActive(true);
			playtime -=Time.deltaTime;
			int Tempplaytime = (int)playtime +1; 
			countdown.text = Tempplaytime.ToString ();
			Debug.Log ("Load Scene");

			if (Tempplaytime <= 0) {
				countdown.text = "Play";
			}

		}

	}
}
