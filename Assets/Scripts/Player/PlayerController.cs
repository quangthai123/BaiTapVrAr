using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    public Animator anim;
    private float currentVelocity = 0f;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float smoothRotateTime;
    private List<Transform> wayPoints;
    public int currentPoint = 0;
    private bool isMoving = false;
    private bool isBacking = false;
    void Awake()
    {
        if(Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }
    private void Start()
    {
        wayPoints = GameManager.Instance.wayPoints;
        anim = transform.Find("Model").GetComponent<Animator>();
    }
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.UpArrow))
        //{
        //    GoOn();
        //}
        //if(Input.GetKeyUp(KeyCode.DownArrow))
        //{
        //    GoBack();
        //}
    }
    private void FixedUpdate()
    {
        if (isMoving)
            MoveToTargetPoint(wayPoints[currentPoint].position);       
    }
    public void GoOn()
    {
        if (currentPoint < wayPoints.Count && !isMoving)
        {
            currentPoint++;
            isMoving = true;
        }
        else
            Debug.Log("Reached Max Point!");
    }
    public void GoBack()
    {
        isBacking = true;
        if(currentPoint > 0 && !isMoving)
        {
            currentPoint--;
            isMoving = true;
        }
        else
            Debug.Log("Reached Min Point!");
    }

    private void MoveToTargetPoint(Vector3 targetPoint)
    {
        float targerAngle = Mathf.Atan2(targetPoint.x - transform.position.x, targetPoint.z - transform.position.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targerAngle, ref currentVelocity, smoothRotateTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        if(Vector3.Distance(transform.position, targetPoint) > .01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, moveSpeed);
            anim.SetBool("Run", true);
        }
        else
        {
            if(isBacking)
            {
                isBacking = false;
                if(currentPoint > 0)
                    currentPoint--;
            } else
            {
                isMoving = false;
                anim.SetBool("Run", false);
                GameManager.Instance.SetNewQuestion();
            }
        }
    }
}
