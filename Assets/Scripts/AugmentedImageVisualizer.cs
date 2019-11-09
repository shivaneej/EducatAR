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

    public class AugmentedImageVisualizer : MonoBehaviour
    {

        public AugmentedImage Image;
        public GameObject[] Models;

        // Start is called before the first frame update
        void Start()
        {
            
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

