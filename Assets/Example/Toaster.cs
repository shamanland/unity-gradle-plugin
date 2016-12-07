using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toaster : MonoBehaviour {
	#if UNITY_ANDROID && !UNITY_EDITOR
	private AndroidJavaClass origin;
	#endif

	public void Toast(string text) {
		#if UNITY_ANDROID && !UNITY_EDITOR
		if (origin == null) {
			origin = new AndroidJavaClass ("xdroid.toaster.Toaster");
		}

		origin.CallStatic("toast", text);
		#else
		Debug.Log("Toast: " + text);
		#endif
	}

	void OnDestroy() {
		#if UNITY_ANDROID && !UNITY_EDITOR
		if (origin != null) {
			origin.Dispose ();
			origin = null;
		}
		#endif
	}
}
