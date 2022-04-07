using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] UIViewer uiViewer;

    public float Time => uiViewer.TimeSlider;
    public float MaxHeight => uiViewer.MaxHeightSlider;
    public void Initialize()
    {    
        uiViewer.Initialize();
    }

}
