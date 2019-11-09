namespace EducatAR
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using GoogleARCore;
    using UnityEngine;
    using UnityEngine.UI;

    public class AugmentedImageExampleController : MonoBehaviour
    {
        public List<AugmentedImageVisualizer> AugmentedImageVisualizerPrefab = new List<AugmentedImageVisualizer>();
        public GameObject FitToScanOverlay;
        private Dictionary<int, AugmentedImageVisualizer> m_Visualizers
        = new Dictionary<int, AugmentedImageVisualizer>();
        private List<AugmentedImage> m_TempAugmentedImages = new List<AugmentedImage>();

        // Update is called once per frame
        void Update()
        {   
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
            if (Session.Status != SessionStatus.Tracking)
            {
                return;
            }
            Session.GetTrackables<AugmentedImage>(m_TempAugmentedImages, TrackableQueryFilter.Updated);
            foreach (var image in m_TempAugmentedImages)
            {
                AugmentedImageVisualizer visualizer = null;
                m_Visualizers.TryGetValue(image.DatabaseIndex, out visualizer);
                if (image.TrackingState == TrackingState.Tracking && visualizer == null)
                {
                    Anchor anchor = image.CreateAnchor(image.CenterPose);
                    visualizer = (AugmentedImageVisualizer)Instantiate(AugmentedImageVisualizerPrefab[image.DatabaseIndex], anchor.transform);
                    visualizer.Image = image;
                    m_Visualizers.Add(image.DatabaseIndex, visualizer);
                }
                else if (image.TrackingState == TrackingState.Stopped && visualizer != null)
                {
                    m_Visualizers.Remove(image.DatabaseIndex);
                    GameObject.Destroy(visualizer.gameObject);
                }
            }
            foreach (var visualizer in m_Visualizers.Values)
            {
                if (visualizer.Image.TrackingState == TrackingState.Tracking)
                {
                    FitToScanOverlay.SetActive(false);
                    return;
                }
            }
            FitToScanOverlay.SetActive(true);
        }
    }
}

