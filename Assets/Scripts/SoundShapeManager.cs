using UnityEngine;
using System.Collections;

public class SoundShapeManager : MonoBehaviour {

	public Transform currentShape;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (currentShape == null)
			return;
		//if (Input.GetMouseButton (0) && currentShape != null) {
		#if !UNITY_EDITOR
			var delta = Input.GetAxis ("Mouse Y");
		#else
			var delta = Input.GetAxis("Mouse ScrollWheel");
		#endif

			currentShape.Translate (new Vector3 (0f, 0f, delta), transform);
		//}


	}


}
