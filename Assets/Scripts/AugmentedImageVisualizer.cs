namespace EducatAR
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using GoogleARCore;
    using GoogleARCoreInternal;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;

    public class AugmentedImageVisualizer : MonoBehaviour
    {

        public AugmentedImage Image;
        public GameObject[] Models;
        // public GameObject FitToScanOverlay;
        // public GameObject AugmentedImageVisualizerPrefab;

        // Start is called before the first frame update
        void Start()
        {
            
        }
        public void ResetScreen()
        {
            // FitToScanOverlay.SetActive(true);
            // AugmentedImageVisualizerPrefab.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
        // Update is called once per frame
        void Update()
        {
            if (Image == null || Image.TrackingState != TrackingState.Tracking)
            {
                Models[Image.DatabaseIndex].SetActive(false);
                //Models[0].SetActive(false);
                //Models[1].SetActive(false);
                return;
            }
            if (Image == null || Image.TrackingState == TrackingState.Stopped)
            {
                Models[Image.DatabaseIndex].SetActive(false);
                //Models[0].SetActive(false);
                //Models[1].SetActive(false);
                return;
            }
            if (Image == null || Image.TrackingState == TrackingState.Paused)
            {
                Models[Image.DatabaseIndex].SetActive(false);
                //Models[0].SetActive(false);
                //Models[1].SetActive(false);
                return;
            }
            Pose _centerPose = Image.CenterPose;
            Models[Image.DatabaseIndex].transform.localPosition = _centerPose.position;
            Models[Image.DatabaseIndex].transform.localScale = new Vector3(0.1f,0.1f,0.1f);
            Models[Image.DatabaseIndex].SetActive(true);
        }
    }
}

