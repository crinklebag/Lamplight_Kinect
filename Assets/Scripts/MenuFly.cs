using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuFly : MonoBehaviour {

	public float glowlevel = 0.0f;
    public float glowlevel2 = 0.0f;
	public float playtime = 3;
	public float wait = 2.0f;
	[SerializeField] Text countdown;
    Color tempcolor2;
    Image obj;
    bool glowing = false;
    // Use this for initialization

   

    void OnTriggerStay2D(Collider2D col)
	{
        if (col.gameObject.CompareTag ("Button"))
        {
            Debug.Log("Glowing");
            glowing = true;
            Glow(col.gameObject);
             obj = col.gameObject.GetComponent<Image>();
        }
        else
        {
            glowlevel = Mathf.Lerp(glowlevel, 0.0f, Time.deltaTime);
            tempcolor2 = col.gameObject.GetComponent<Image>().color;
        }
    }

	void OnTriggerExit2D(Collider2D col)
	{
        
        playtime = 3;
		countdown.gameObject.SetActive(false);
        glowlevel = Mathf.Lerp(glowlevel, 0.0f, Time.deltaTime);
    }
	// Update is called once per frame
	void Update () {
        
        Color tempColor = this.GetComponent<SpriteRenderer> ().color;
		tempColor.a = glowlevel;
		if (Input.GetKey ("up")) {
           // glowing = true;
            glowlevel2 = Mathf.Lerp(glowlevel, 1.0f, Time.deltaTime);
            glowlevel = Mathf.Lerp(glowlevel, 1.0f, Time.deltaTime);
        } else {
			glowlevel = Mathf.Lerp(glowlevel,0.0f, Time.deltaTime);
            glowing = false;
		}

		if (Input.GetKeyDown ("down")) 
		{
			glowlevel -= 0.05f;
		}

		this.GetComponent<SpriteRenderer> ().color = tempColor;
        if (obj == null)
        {
            return;
        }
        obj.color = tempColor;

       
    }

	void Glow(GameObject col)
    {
        //tempcolor2.a = glowlevel2;

        //glowlevel += 0.5f;
        glowlevel = Mathf.Lerp(glowlevel, 1.0f, Time.deltaTime);
            wait -= Time.deltaTime;
            glowlevel2 = Mathf.Lerp(glowlevel2, 1.0f, Time.deltaTime);
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
