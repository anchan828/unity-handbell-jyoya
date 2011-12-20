using UnityEngine;
using System.Collections;
using System.Collections.Specialized;
public class Acceleration : MonoBehaviour
{

	private Vector3 accele;
	private float oldAccle;
	private float num;
	private float abs = 0;
	private bool flag = false;
	public AudioClip sound;
	public Texture2D kane;
	private string status = "";
	private bool firstcall = false;

	void Start ()
	{
		num = 0.55f;
		oldAccle = 1f;
		abs = 0;
		flag = false;
		
	}
	void FixedUpdate ()
	{
		accele = Input.acceleration;
		if (firstcall) {
			abs = Mathf.Abs (accele.magnitude - oldAccle);
			if (abs > num && !flag) {
				audio.PlayOneShot (sound);
				StartCoroutine (Wait ());
			}
		} else
			firstcall = true;
		oldAccle = accele.magnitude;
	}
	IEnumerator Wait ()
	{
		flag = true;
		yield return new WaitForSeconds (sound.length);
		flag = false;
	}
	void OnGUI ()
	{
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height * 0.8f), kane);
	}
}
