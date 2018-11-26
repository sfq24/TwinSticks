using UnityEngine;

public class Replay : MonoBehaviour
{
    private GameManager gameManager;

    private const int bufferFrames = 200;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];

    private Rigidbody rigidBody;

    // Use this for initialization
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        //gameManager = new GameManager();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameManager.IsRecording)
        {
            Record();
        }
        else
        {
            PlayBack();
        }
    }

    private void PlayBack()
    {
        rigidBody.isKinematic = true;
        int frame = Time.frameCount % bufferFrames;
        Debug.Log("Load frame: " + frame);
        transform.position = keyFrames[frame].Position;
        transform.rotation = keyFrames[frame].Rotation;
    }

    private void Record()
    {
        rigidBody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;
        Debug.Log("Write frame: " + frame);
        //keyFrames[frame] = new MyKeyFrame(time, rigidBody.position, rigidBody.rotation);
        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
}

public class MyKeyFrame
{
    public float FrameTime { get; set; }
    public Vector3 Position { get; set; }
    public Quaternion Rotation { get; set; }

    public MyKeyFrame(float time, Vector3 pos, Quaternion rot)
    {
        FrameTime = time;
        Position = pos;
        Rotation = rot;
    }
}