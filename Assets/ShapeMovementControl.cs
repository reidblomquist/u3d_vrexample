using UnityEngine;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;
using UnityEngine.VR;
using VRStandardAssets.Examples;

namespace VRStandardAssets.Examples
{
	public class ShapeMovementControl : MonoBehaviour
	{
		[SerializeField] private float m_speed = 50f; //the speed that the shapes are initially moving
		[SerializeField] private float m_Damping = 0.5f; //the amound of damping applied to the shape
		[SerializeField] private Transform m_shape;  //reference to the transform of the shape
		[SerializeField] private Transform m_TargetMarker; //reference to the transform the shape is moving towards 

		private bool m_ShapeIsMoving;    //whether or not the shape is selected to be moved 
		private Vector3 m_ShapeStartPos;    // These positions and rotations are stored at Start so the shape can be reset each game.
		private Quaternion m_ShapeStartRot; 
		private Vector3 m_TargetStartPos; //These positions and rotations represent the target point of where you want the shape to move to
		private Quaternion m_TargetStartRot; 

		private const float k_ExpDampingCoef = -20f;                // The coefficient used to damp the movement of the shape.
		private const float k_BankingCoef = 3f;   

		// Use this for initialization
		private void Start ()
		{
			m_ShapeStartPos = m_shape.position;
			m_ShapeStartRot = m_shape.rotation;
			m_TargetStartPos = m_TargetMarker.position;
			m_TargetStartRot = m_TargetMarker.rotation;
		
		}

		public void StartMovement ()
		{
			m_ShapeIsMoving = true;  //the shape is now moving

			StartCoroutine (MoveShape ()); //kickoff the coroutine to move the shape 
		}

		public void StopMovement ()
		{
			m_ShapeIsMoving = false; //the shape is frozen
		}

		public void ResetPosition()
		{
			m_ShapeIsMoving = false; //the shape is frozen
			m_shape.position = m_ShapeStartPos;
			m_shape.rotation = m_ShapeStartRot;
			m_TargetMarker.position = m_TargetStartPos;
			m_TargetMarker.rotation = m_TargetStartRot;
		}

		private IEnumerator MoveShape ()
		{
			while (m_ShapeIsMoving)
			{
				// Set the target marker position to a point forward of the shape based on the head rotation
				Quaternion headRotation = InputTracking.GetLocalRotation (VRNode.Head);
				//Quaternion mouseRotation = InputTracking.GetLo
				m_TargetMarker.position = m_shape.position + (headRotation * Vector3.forward);

				// Move the camera container forward.
				//m_CameraContainer.Translate (Vector3.forward * Time.deltaTime * m_Speed);

				// Move the shape towards the target marker.
				m_shape.position = Vector3.Lerp(m_shape.position, m_TargetMarker.position,
					m_Damping * (1f - Mathf.Exp (k_ExpDampingCoef * Time.deltaTime)));

				// Calculate the vector from the target marker to the flyer.
				Vector3 dist = m_shape.position - m_TargetMarker.position;

				// Base the target markers pitch (x rotation) on the distance in the y axis and it's roll (z rotation) on the distance in the x axis.
				m_TargetMarker.eulerAngles = new Vector3 (dist.y, 0f, dist.x) * k_BankingCoef;

				// Make the flyer bank towards the marker.
				m_shape.rotation = Quaternion.Lerp(m_shape.rotation, m_TargetMarker.rotation,
					m_Damping * (1f - Mathf.Exp (k_ExpDampingCoef * Time.deltaTime)));


				// Wait until next frame.
				yield return null;
			}
		}
		// Update is called once per frame
		void Update ()
		{
		
		}
	}
}
