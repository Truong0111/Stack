using UnityEngine;

public class CameraOffSet : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameController gc;

    private Vector3 DefaultCamOffSet = new Vector3(1.4f, 2.22f, -1.4f);
    private Vector3 CamOffSetHeightUp = new Vector3(0, 0.2f, 0);
    private void LateUpdate() // Dành cho khi game over
    {
        Vector3 GameOverCamOffSet = DefaultCamOffSet + new Vector3(gc.GetScore() * 0.06f, gc.GetScore() * 0.08f, -gc.GetScore() * 0.06f);
        if (gc.GetGameOver())
        {
            if (cam.transform.position.x <= GameOverCamOffSet.x
            || cam.transform.position.y <= GameOverCamOffSet.y
            || cam.transform.position.z >= GameOverCamOffSet.z)
            {
                cam.transform.position += new Vector3(0.01f, 0.02f ,-0.01f);
            }
        }
    }
    public void SetDefaultCam()
    {
        cam.transform.position = DefaultCamOffSet;
    }

    public void SetCamIncrease()
    {
        cam.transform.position += CamOffSetHeightUp;
    }
    public Vector3 GetCurrentOffSet()
    {
        return cam.transform.position;
    }
}
