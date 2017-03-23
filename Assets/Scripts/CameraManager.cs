using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {
	public float mouseMovementPadding = 0.1f;
	public float minHeight = 1;
	public float maxHeight = 15;
	public float zoomSpeed = 5;
	public float minScrollSpeed = .3f;

	void Update () {
		Vector3 selectedObjectPosition;
		Vector3 viewportPoint;
		float horizontalScroll;
		float verticalScroll;
		float zoom;
		int zoomDirection;

		if (Input.GetKey (KeyCode.Space) && (GameManager.instance.getSelectedObject() != null)) {
			selectedObjectPosition = GameManager.instance.getSelectedObject().transform.position;
			transform.position = new Vector3 (selectedObjectPosition.x, gameObject.transform.position.y, selectedObjectPosition.z - 3);
		} else {
			viewportPoint = Camera.main.ScreenToViewportPoint (Input.mousePosition);
			horizontalScroll = Input.GetAxis ("Mouse X");
			verticalScroll = Input.GetAxis ("Mouse Y");
			zoom = Input.GetAxis ("Mouse ScrollWheel");
			if (Input.GetKey (KeyCode.D) || (viewportPoint.x > (1 - mouseMovementPadding))) {
				transform.Translate (new Vector3 (Mathf.Max (horizontalScroll, minScrollSpeed), 0, 0), Space.World);
			}
			if (Input.GetKey (KeyCode.A) || (viewportPoint.x < mouseMovementPadding)) {
				transform.Translate (new Vector3 (Mathf.Min (horizontalScroll, -minScrollSpeed), 0, 0), Space.World);
			}
			if (Input.GetKey (KeyCode.W) || (viewportPoint.y > (1 - mouseMovementPadding))) {
				transform.Translate (new Vector3 (0, 0, Mathf.Max (verticalScroll, minScrollSpeed)), Space.World);
			}
			if (Input.GetKey (KeyCode.S) || ((viewportPoint.y < mouseMovementPadding * 3) && (viewportPoint.y > mouseMovementPadding * 2))) {
				transform.Translate (new Vector3 (0, 0, Mathf.Min (verticalScroll, -minScrollSpeed)), Space.World);
			}
			if (zoom != 0) {
				zoomDirection = (zoom > 0 ? 1 : -1);
				if (((transform.position.y > minHeight) || (zoomDirection < 0)) && ((transform.position.y < maxHeight) || (zoomDirection > 0))) {
					transform.Translate (Vector3.forward * zoomDirection * zoomSpeed * Time.deltaTime);
				}
			}
		}
	}
}
