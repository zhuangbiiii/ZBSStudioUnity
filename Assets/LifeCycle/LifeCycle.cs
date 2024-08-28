using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    private string message = "from lifecycle test object:";

    // 加载脚本实例时调用 Awake
    private void Awake()
    {
        Debug.Log(message + "Awake..");
    }

    // 重置为默认值
    private void Reset()
    {
        Debug.Log(message + "Reset");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 当对象已启用并处于活动状态时调用此函数
    private void OnEnable()
    {
        Debug.Log(message + "OnEnable");
    }

    // 当行为被禁用或处于非活动状态时调用此函数
    private void OnDisable()
    {
        Debug.Log(message + "OnDisable");
    }

    // 当 MonoBehaviour 将被销毁时调用此函数
    private void OnDestroy()
    {
        Debug.Log(message + "OnDestroy");
    }

    // 如果启用 Behaviour，则在每一帧都将调用 LateUpdate
    private void LateUpdate()
    {

    }

    // 如果启用 MonoBehaviour，则每个固定帧速率的帧都将调用此函数
    private void FixedUpdate()
    {

    }

    // receive message from Controller
    public void ReceiveMessage(string message2)
    {
        Debug.Log(message + "Receive Message: " + message2);
    }

    // yield something
    // @param Delay: delay time
    IEnumerator TestCoroutine(float Delay)
    {
        Debug.Log(message + "TestCoroutine start..");
        yield return new WaitForSeconds(Delay);
        Debug.Log(message + "TestCoroutine end..");
    }

    // invoke something
    // @param Delay: delay time
    void TestInvoke(float Delay)
    {
        Debug.Log(message + "TestInvoke start..");
        Invoke("TestInvokeEnd", Delay);
    }

    // invoke something end
    void TestInvokeEnd()
    {
        Debug.Log(message + "TestInvoke end..");
    }
}
