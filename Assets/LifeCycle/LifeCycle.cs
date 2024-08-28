using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    private string message = "from lifecycle test object:";

    // ���ؽű�ʵ��ʱ���� Awake
    private void Awake()
    {
        Debug.Log(message + "Awake..");
    }

    // ����ΪĬ��ֵ
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

    // �����������ò����ڻ״̬ʱ���ô˺���
    private void OnEnable()
    {
        Debug.Log(message + "OnEnable");
    }

    // ����Ϊ�����û��ڷǻ״̬ʱ���ô˺���
    private void OnDisable()
    {
        Debug.Log(message + "OnDisable");
    }

    // �� MonoBehaviour ��������ʱ���ô˺���
    private void OnDestroy()
    {
        Debug.Log(message + "OnDestroy");
    }

    // ������� Behaviour������ÿһ֡�������� LateUpdate
    private void LateUpdate()
    {

    }

    // ������� MonoBehaviour����ÿ���̶�֡���ʵ�֡�������ô˺���
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
