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
	public Texture2D map;
	private string status = "";
	public class Location
	{
		//32.674639,128.675308
		public float latitude;
		public float longitude;
	}

	public Location l = new Location ();
	IEnumerator Start ()
	{
		num = 0.7f;
		oldAccle = 1f;
		abs = 0;
		flag = false;
		iPhoneSettings.StartLocationServiceUpdates ();
		while (iPhoneSettings.locationServiceStatus.Equals (LocationServiceStatus.Initializing)) {
			yield return new WaitForEndOfFrame ();
		}
		l.latitude = iPhoneInput.lastLocation.latitude;
		l.longitude = iPhoneInput.lastLocation.longitude;
		iPhoneSettings.StopLocationServiceUpdates ();
	}
	void FixedUpdate ()
	{
		accele = Input.acceleration;
		abs = Mathf.Abs (accele.magnitude - oldAccle);
		if (abs > num && !flag) {
			audio.PlayOneShot (sound);
			StartCoroutine (Wait ());
		}
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
		float width = Screen.width * 0.3f;
		float height = Screen.height * 0.3f;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), map);
		GUI.DrawTexture (new Rect (0, 0, width, height), kane);
		GUILayout.BeginArea (new Rect (0, height, width, height));
		GUILayout.Box ("latitude" + l.latitude);
		GUILayout.Box ("longitude" + l.longitude);
		GUILayout.EndArea ();
	}
}
