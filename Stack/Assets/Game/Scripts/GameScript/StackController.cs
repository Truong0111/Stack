using Unity.VisualScripting;
using UnityEngine;

public class StackController : MonoBehaviour
{
    [SerializeField] private Stack stack;
    [SerializeField] private CameraOffSet camOffSet;
    [SerializeField] private GameController gc;
    [SerializeField ]private AnimController ac;
    private static Stack CurrentStack;
    private static Stack LastStack;
    private static Material CurrentMaterial;

    public void StartGame()
    {
        if (LastStack == null)
        {
            LastStack = GameObject.Find("FirstStack").GetComponent<Stack>();
            CurrentMaterial = LastStack.GetComponent<MeshRenderer>().material;
            camOffSet.SetDefaultCam();
            SpawnStack();
        }
    }
    public void GameOver()
    {
        LastStack = null;
        CurrentStack = null;
        
    }
    private float moveSpeedUp = 0.04f;
    public void GetTouchIn() //Hàm gọi khi chạm vào màn hình
    {
        CurrentStack.StopStack();
        CheckStackPosAfterTouch();
        if (gc.GetGameOver()) return;

        LastStack = CurrentStack;
        gc.ScoreIncreament();
        SpawnStack();
        CurrentStack.SetSpeed(CurrentStack.GetSpeed() + gc.GetScore() * moveSpeedUp);
        camOffSet.SetCamIncrease();
    }
    
    private float SpawnHeight = 0.2f;
    private float SpawnXStack = -1.5f;
    private float SpawnZStack = 1.5f;
    private float DefaultSpeed = 1.0f;
    public void SpawnStack() // Hàm spawn stack
    {
        float SpawnYPos = (gc.GetScore() + 0.5f) * SpawnHeight;
        float SpawnXPos = LastStack.transform.position.x;
        float SpawnZPos = LastStack.transform.position.z;
        Vector3 SpawnPos;
        if (gc.GetScore() % 2 == 0)
        {
            SpawnPos = new Vector3(SpawnXPos, SpawnYPos, SpawnZStack);
        }
        else SpawnPos = new Vector3(SpawnXStack, SpawnYPos, SpawnZPos);
        Stack NewStack = Instantiate(LastStack, SpawnPos, Quaternion.identity);
        CurrentStack = NewStack;
        CurrentStack.SetCheckCurrentStack(gc.GetScore() % 2 == 0);
        CurrentStack.SetSpeed(DefaultSpeed);
    }

    // Hàm cắt stack theo trục Z
    public void SplitStackOnZ(float hangOver, float direction) 
    {
        float NewZSize = LastStack.transform.localScale.z - Mathf.Abs(hangOver);
        float fallingStackSize = CurrentStack.transform.localScale.z - NewZSize;
        float NewZPos = LastStack.transform.position.z + (hangOver / 2);

        CurrentStack.transform.localScale 
            = new Vector3(CurrentStack.transform.localScale.x, CurrentStack.transform.localScale.y, NewZSize);
        CurrentStack.transform.position 
            = new Vector3(CurrentStack.transform.position.x, CurrentStack.transform.position.y, NewZPos);

        float cubeEdge = CurrentStack.transform.position.z + (NewZSize / 2f * direction);
        float fallingStackZPos = cubeEdge + fallingStackSize / 2f * direction;
        SpawnFallingStackOnZ(fallingStackZPos, fallingStackSize);
    }

    // Hàm cắt stack theo trục X
    public void SplitStackOnX(float hangOver, float direction) 
    {
        float NewXSize = LastStack.transform.localScale.x - Mathf.Abs(hangOver);
        float fallingStackSize = CurrentStack.transform.localScale.x - NewXSize;
        float NewXPos = LastStack.transform.position.x + (hangOver / 2);

        CurrentStack.transform.localScale 
            = new Vector3(NewXSize, CurrentStack.transform.localScale.y, CurrentStack.transform.localScale.z);
        CurrentStack.transform.position 
            = new Vector3(NewXPos, CurrentStack.transform.position.y, CurrentStack.transform.position.z);

        float cubeEdge = CurrentStack.transform.position.x + (NewXSize / 2f * direction);
        float fallingStackXPos = cubeEdge + fallingStackSize / 2f * direction;
        SpawnFallingStackOnX(fallingStackXPos, fallingStackSize);
    }

    // Hàm spawn stack thừa rơi xuống theo trục Z
    public void SpawnFallingStackOnZ(float fallingStackZPos, float fallingStackSize) 
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale 
            = new Vector3(CurrentStack.transform.localScale.x, CurrentStack.transform.localScale.y, fallingStackSize);
        cube.transform.position 
            = new Vector3(CurrentStack.transform.position.x, CurrentStack.transform.position.y, fallingStackZPos);
        cube.AddComponent<Rigidbody>();
        cube.gameObject.GetComponent<MeshRenderer>().material = CurrentMaterial;
        Destroy(cube.gameObject, 3f);
    }

    // Hàm spawn stack thừa rơi xuống theo trục X
    public void SpawnFallingStackOnX(float fallingStackXPos, float fallingStackSize) 
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale 
            = new Vector3(fallingStackSize, CurrentStack.transform.localScale.y, CurrentStack.transform.localScale.z);
        cube.transform.position 
            = new Vector3(fallingStackXPos, CurrentStack.transform.position.y, CurrentStack.transform.position.z);
        cube.AddComponent<Rigidbody>();
        cube.gameObject.GetComponent<MeshRenderer>().material = CurrentMaterial;
        Destroy(cube.gameObject, 3f);
    }

    //Kiểm tra stack sau khi ấn vào màn hình
    private float maxPosAccept = 0.02f;
    public void CheckStackPosAfterTouch()
    {
        if (gc.GetScore() % 2 == 0)
        {
            float hangOver = CurrentStack.transform.position.z - LastStack.transform.position.z;
            if (Mathf.Abs(hangOver) <= maxPosAccept)
            {
                VolumeController.Ins.StackComboEfx();
                gc.ComboIncreament();
                CurrentStack.transform.position = LastStack.transform.position + new Vector3(0, SpawnHeight, 0);
                RunAnim();
                return;
            }
            else if (Mathf.Abs(hangOver) >= LastStack.transform.localScale.z)
            {
                VolumeController.Ins.GameOverEfx();
                CurrentStack.AddComponent<Rigidbody>();
                gc.SetGameOver(true);
                return;
            }
            else
            {
                VolumeController.Ins.StackDropEfx();
                gc.SetCombo(0);
                float direction = hangOver > 0 ? 1f : -1f;
                SplitStackOnZ(hangOver, direction);
            }
        }
        else
        {
            float hangOver = CurrentStack.transform.position.x - LastStack.transform.position.x;
            if (Mathf.Abs(hangOver) <= maxPosAccept)
            {
                VolumeController.Ins.StackComboEfx();
                gc.ComboIncreament();
                CurrentStack.transform.position = LastStack.transform.position + new Vector3(0, SpawnHeight, 0);
                RunAnim();
                return;
            }
            else if (Mathf.Abs(hangOver) >= LastStack.transform.localScale.x)
            {
                VolumeController.Ins.GameOverEfx();
                CurrentStack.AddComponent<Rigidbody>();
                gc.SetGameOver(true);
                return;
            }
            else
            {
                VolumeController.Ins.StackDropEfx();
                gc.SetCombo(0);
                float direction = hangOver > 0 ? 1f : -1f;
                SplitStackOnX(hangOver, direction);
            }
        }
    }
    //Chạy animation
    public void RunAnim()
    {
        ac.SetAnimSpawn(CurrentStack.transform.position);
        ac.SetScaleAnim(CurrentStack.transform.localScale);
        ac.PlayAnim();
    }
}