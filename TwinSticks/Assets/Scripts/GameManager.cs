using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour
{
    public bool IsRecording = true;

    // Update is called once per frame
    private void Update()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            IsRecording = false;
        }
        else
        {
            IsRecording = true;
        }
    }
}