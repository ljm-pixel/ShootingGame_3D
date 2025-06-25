using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    //摄像机要看向的目标对象
    public Transform target;
    //摄像机相对目标对象 在xyz上的偏移位置
    public Vector3 offsetPos;
    //看向位置的y偏移值
    public float bodyHeight;

    //移动和旋转速度
    public float moveSpeed;
    public float rotationSpeed;

    public float rotationY;

    private Vector3 targetPos;
    private Quaternion targetRotation;

    private float xRotation;
    public Quaternion rotationMax;
    public Quaternion rotationMin;

    private float currentAngle;
    public float minAngle;
    public float maxAngle;

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        //根据目标对象 来计算 摄像机当前的位置和角度
        //位置的计算
        //向后偏移Z坐标
        targetPos = target.position + target.forward * offsetPos.z;
        //向上偏移Y坐标
        targetPos += Vector3.up * offsetPos.y;
        //左右偏移X坐标
        targetPos += target.right * offsetPos.x;
        //插值运算 让摄像机 不停向目标点靠拢
        this.transform.position = Vector3.Lerp(this.transform.position, targetPos, moveSpeed * Time.deltaTime);

        //旋转的计算
        //得到最终要看向某个点时的四元数
        targetRotation = Quaternion.LookRotation(target.position + Vector3.up * bodyHeight - this.transform.position);
        //让摄像机不停的向目标角度靠拢
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // 更新当前旋转角度并限制在最小和最大角度之间
        currentAngle = Mathf.Clamp(currentAngle + -Input.GetAxis("Mouse Y") * rotationSpeed, minAngle, maxAngle);

        // 应用旋转到物体
        target.localEulerAngles = new Vector3(currentAngle, target.localEulerAngles.y,
             target.localEulerAngles.z);
    }
}
