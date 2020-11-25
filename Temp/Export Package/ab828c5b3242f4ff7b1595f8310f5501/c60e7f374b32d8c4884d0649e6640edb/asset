using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    private Vector3 offsetPosition;//位置偏移
    private Transform player;
    public float distance = 0;
    public float scrollspeed = 10;//鼠标滚轮拉近拉远的速度
    private bool isRotating = false;
    public float rotateSpeed = 2F;//摄像机绕着角色旋转时的旋转速度



    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(player);
        offsetPosition = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offsetPosition + player.position;

        //处理视野的旋转
        RotateView();
        //处理视野的拉近和拉远效果
        ScrollView();//这里的RotateView调用要放在SCrollView()前面，如果要放置在后面，则ScrollSpeed要设置很大，因为ScrollView和RotateView都在Update函数中，相对于一帧的时间，这两个函数的执行时间间隔小很多，在SCrollView的重置offsetPosition语句offsetPosition = offsetPosition.normalized * distance;执行后，很快就轮到RotateView的offsetPosition = transform.position - player.position，这句话取消了ScrollView的效果，使得我们有效的鼠标滑轮滑动时间变得很短，所以如果要将函数ScrollView放前面，则将ScrollSpeed设置很大。



    }


    void ScrollView()
    {
        //滑轮向前滑动(用于拉近视野)返回正值，向后滑动（用于拉远视野）返回负值
        distance = offsetPosition.magnitude;
        distance -= Input.GetAxis("Mouse ScrollWheel") * scrollspeed;
        distance = Mathf.Clamp(distance, 1, 18);//Clamp函数控制distance的距离在5到18之间
        offsetPosition = offsetPosition.normalized * distance;
    }


    void RotateView()
    {
        //Input.GetAxis("Mouse X");//得到鼠标在水平方向的滑动,向左时返回负数，向右返回正数
        //Input.GetAxis("Mouse Y");//得到鼠标在垂直方向的滑动,向下时返回负数，向上返回正数


        if (Input.GetMouseButtonDown(1))//你需要在Update方法中调用这个方法，此后每一帧重置状态时，它将不会返回true除非用户释放这个鼠标按钮然后重 	//新按下它。按钮值设定为 0对应左键 ， 1对应右键 ， 2对应中键。
        {
            isRotating = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }


        if (isRotating)
        {                           //某位置           //某轴            //旋转度数
            transform.RotateAround(player.position, transform.up, rotateSpeed * Input.GetAxis("Mouse X"));//简单的说，在世界坐标的某位置的某轴按照旋转度数旋转调用这个函数的物体。
            Vector3 originalPos = transform.position; Quaternion originalRotation = transform.rotation;
            transform.RotateAround(player.position, transform.right, -rotateSpeed * Input.GetAxis("Mouse Y"));//影响本物体transform的属性有两个，一个是position 一个是rotation
            float x = transform.eulerAngles.x;
            if (x < 0 || x > 90)//垂直方向角度限制:不论怎么旋转都限制在10到80度之间
            {
                transform.position = originalPos;
                transform.rotation = originalRotation;
            }
            x = Mathf.Clamp(x, 10, 80);//限制x的值在10和80之间， 如果x小于10，返回10。 如果x大于80，返回80，否则返回value 
            transform.eulerAngles = new Vector3(x, transform.eulerAngles.y, transform.eulerAngles.z);//测试过之后发现上面两句的没什么影响，可能是因为有了下面transform.LookAt(player);这句的存在
        }
        offsetPosition = transform.position - player.position;//因为旋转后相对位置变了，要保持相对位置，原来的offsetposition已经不适用
        transform.LookAt(player);//保证不论怎么旋转都是角色在摄像机视野的正中心,如果去掉则会出现角色不在正中心的现象
    }

}