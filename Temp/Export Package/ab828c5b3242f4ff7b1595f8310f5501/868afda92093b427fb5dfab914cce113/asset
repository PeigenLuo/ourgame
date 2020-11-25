using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D coll;
    public Animator anim;
    public float jumpforce, speed;
    public Transform CameraTrans;
    public Transform groundCheck;
    public LayerMask ground;//碰撞体过滤 

    public bool isGround, isJump;

    bool jumpPressed;
    int jumpCount;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpPressed = true;
        }

    }

    //每秒固定执行的操作，与设备无关
    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.18f, ground);//判断是否在地面
        GroundMovement();
        SwitchAnim();
        Jump();
    }

    //根据输入控制水平方向的移动和以及方向变化
    void GroundMovement()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");//只有0 -1 1 三个数字
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);

        if (horizontalMove != 0)
        {
            transform.localScale = new Vector3(horizontalMove, 1, 1);//控制翻转
        }

    }

    void Jump()
    {

        if (isGround)
        {
            jumpCount = 2;//在地面的时候就恢复可跳跃次数
            isJump = false;
        }

        if (jumpPressed && isGround)
        {
            isJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            jumpCount--;
            jumpPressed = false;//每0.02秒检测按键是否松开

        }

        else if (jumpPressed && jumpCount > 0 && !isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            jumpCount--;
            jumpPressed = false;

        }
    }

    //控制动画转移
    void SwitchAnim()
    {
        //判断是否跑
        anim.SetFloat("running", Mathf.Abs(rb.velocity.x));
        //判断下落还是上跳
        anim.SetFloat("jumping", rb.velocity.y);
        //判断是否返回静止状态
        if (isGround)
        {
            anim.SetBool("idle", true);
            Vector3 pos = CameraTrans.position;
            pos.x = transform.position.x + 0.87f;
            CameraTrans.position = pos;
        }
        else
            anim.SetBool("idle", false);


    }



}