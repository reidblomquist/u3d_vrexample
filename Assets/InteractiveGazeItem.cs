using UnityEngine;
using VRStandardAssets.Utils;


public class InteractiveGazeItem : MonoBehaviour
	{

		[SerializeField] private Material m_NormalMaterial; //base material of shape 
		[SerializeField] private Material m_OverMaterial; //what material to apply to shape when gaze is on shape 
		[SerializeField] private Material m_ClickedMaterial; //what material to apply to shape when clicke
		[SerializeField] private Material m_DoubleClickedMaterial;  //what material to apply to shape when double clicked
		[SerializeField] private VRInteractiveItem m_InteractiveItem; //which shape is being applied
		[SerializeField] private Renderer m_Renderer; //what mesh render to apply to the shape
		[SerializeField] private float m_Speed; //speed that we want to move the shape

		private void Awake() 
		{
			m_Renderer.material = m_NormalMaterial;
		}
		private void OnEnable()
		{
			m_InteractiveItem.OnOver += HandleOver;
			m_InteractiveItem.OnOut += HandleOut;
			m_InteractiveItem.OnClick += HandleClick;
			m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
		}


		private void OnDisable()
		{
			m_InteractiveItem.OnOver -= HandleOver;
			m_InteractiveItem.OnOut -= HandleOut;
			m_InteractiveItem.OnClick -= HandleClick;
			m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
		}


		//Handle the Over event
		private void HandleOver()
		{
			Debug.Log("Show over state");
			m_Renderer.material = m_OverMaterial;
		}


		//Handle the Out event
		private void HandleOut()
		{
			Debug.Log("Show out state");
			m_Renderer.material = m_NormalMaterial;
		}


		//Handle the Click event
		private void HandleClick()
		{
			Debug.Log("Show click state");
			m_Renderer.material = m_ClickedMaterial;
		}


		//Handle the DoubleClick event
		private void HandleDoubleClick()
		{
			Debug.Log("Show double click");
			m_Renderer.material = m_DoubleClickedMaterial;
		}
	}
