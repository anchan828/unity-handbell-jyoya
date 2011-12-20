using UnityEngine;
using System.Collections;

public class MapView : MonoBehaviour
{
	public GUISkin skin;
	public class Location
	{
		public float latitude;
		public float longitude;
	}

	public Location l = new Location ();
	// Use this for initialization
	IEnumerator Start ()
	{
		AndroidJavaClass unityPlayer = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject> ("currentActivity");
//		activity.Call ("mapView");
		iPhoneSettings.StartLocationServiceUpdates ();
		while (iPhoneSettings.locationServiceStatus.Equals (LocationServiceStatus.Initializing)) {
			yield return new WaitForEndOfFrame ();
		}
		l.latitude = iPhoneInput.lastLocation.latitude;
		l.longitude = iPhoneInput.lastLocation.longitude;
		iPhoneSettings.StopLocationServiceUpdates ();
		
		activity.Call ("setLocation", l.latitude, l.longitude);
	}

	// Update is called once per frame
	void Update ()
	{
		
	}
	void OnGUI ()
	{
		GUI.skin = skin;
		float height = Screen.height * 0.3f;
		GUILayout.BeginArea (new Rect (0, Screen.height - 70, Screen.width, 70));
		GUILayout.Box ("latitude : " + l.latitude);
		GUILayout.Box ("longitude : " + l.longitude);
		GUILayout.EndArea ();
	}
}
