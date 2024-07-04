using UnityEngine;

public class SelfRotation : MonoBehaviour
{
    public float rotationSpeed = 50f; // 旋转速度

    void Update()
    {
        // 在每一帧按照设定的速度绕着自身的Y轴旋转
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
