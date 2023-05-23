using UnityEngine;

public class Stack : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private bool CheckMoveForward;
    private bool CheckStackCurrent;
    private void Start()
    {
        init();
    }
    private void Update()
    {
        Movement();
    }
    private void init()
    {
        CheckMoveForward = true;
    }
    //--------------- Movement của Stack ------------------//
    private void Movement()
    {
        if (CheckMoveForward)
            MoveStackForward();
        else MoveStackBackward();
    }
    private float moveLimit = 1.5f;
    private void MoveStackForward()
    {
        if(!CheckStackCurrent) 
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
            if (transform.position.x >= moveLimit) CheckMoveForward = false;
        }
        else
        {
            transform.position += new Vector3(0, 0, -moveSpeed * Time.deltaTime);
            if(transform.position.z <= -moveLimit) CheckMoveForward = false;
        }
        
    }
    private void MoveStackBackward()
    {
        if (!CheckStackCurrent) 
        {
            transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
            if (transform.position.x <= -moveLimit) CheckMoveForward = true;
        }
        else
        {
            transform.position -= new Vector3(0, 0, -moveSpeed * Time.deltaTime);
            if (transform.position.z >= moveLimit) CheckMoveForward = true;
        }    
    }
    //----------------------------------------------------//
    public void StopStack()
    {
        moveSpeed = 0;
    }
    public float GetSpeed()
    {
        return moveSpeed;
    }
    public void SetSpeed(float speed)
    {
        moveSpeed = speed;
    }
    public void SetCheckCurrentStack(bool check)
    {
        CheckStackCurrent = check;
    }
    
}
