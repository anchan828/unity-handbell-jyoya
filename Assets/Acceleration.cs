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
	void Start ()
	{
		num = 0.7f;
		oldAccle = 0.7f;
		abs = 0;
		flag = false;
	}
	void FixedUpdate ()
	{
		accele = Input.acceleration;
		abs = Mathf.Abs (accele.magnitude - oldAccle);
		print ("abs : " + abs);
		if (abs > num && !flag) {
			print ("call");
			audio.PlayOneShot (sound);
			StartCoroutine (Wait ());
		}
		oldAccle = accele.magnitude;
	}
	IEnumerator Wait ()
	{
		flag = true;
		yield return new WaitForSeconds (7);
		flag = false;
	}
	void OnGUI ()
	{
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), kane);
	}
}
