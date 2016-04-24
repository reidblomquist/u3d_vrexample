using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

namespace Shounds.IObj
{
    // The intro scene takes users through the basics
    // of interacting through VR in the other scenes.
    // This manager controls the steps of the intro
    // scene.
    public class IObjManager : MonoBehaviour
    {
        [SerializeField] private Reticle m_Reticle;                         // The scene only uses SelectionSliders so the reticle should be shown.
        [SerializeField] private SelectionRadial m_Radial;                  // Likewise, since only SelectionSliders are used, the radial should be hidden.
        [SerializeField] private IObj m_IObjTarget;                  // IObj to manipulate.
        [SerializeField] private IObjUIFader m_IObjUIFader;                   // This fader controls the UI showing how to use SelectionSliders.
        [SerializeField] private SelectionSlider m_IObjUISlider;          // This is the slider that is used to demonstrate how to use them.
        [SerializeField] private UIFader m_ReturnFader;                     // The final instructions are controlled using this fader.


        private IEnumerator Start ()
        {
            m_Reticle.Show ();
            
            m_Radial.Hide ();

            // In order, fade in the UI on how to use sliders, wait for the slider to be filled then fade out the UI.
            //yield return StartCoroutine (m_IObjUIFader.InteruptAndFadeIn ());
            //yield return StartCoroutine (m_IObjUISlider.WaitForBarToFill ());
            yield return null;
            // Coroutine for Movement goes here
            //yield return StartCoroutine (m_IObjUIFader.InteruptAndFadeIn ());

            // In order, fade in the UI on confirming the use of sliders, wait for the slider to be filled, then fade out the UI.
            //yield return StartCoroutine(m_HowToUseConfirmFader.InteruptAndFadeIn());
            //yield return StartCoroutine(m_HowToUseConfirmSlider.WaitForBarToFill());
            //yield return StartCoroutine(m_HowToUseConfirmFader.InteruptAndFadeOut());

            // Fade in the final UI.
//            yield return StartCoroutine (m_ReturnFader.InteruptAndFadeIn ());
        }
    }
}