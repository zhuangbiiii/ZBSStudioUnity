using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// different of yield and invoke
// yield: pause the function and continue after the delay, with maximum 1 parameter
// invoke: call the function after the delay, with no parameter

public class Controller : MonoBehaviour
{
    // defualt color
    [SerializeField] Color defaultColor = Color.white;

    // target object for test function
    [SerializeField] GameObject targetObject;

    // pure color material for visualization change
    private Material material;

    // 加载脚本实例时调用 Awake
    private void Awake()
    {
        Debug.Log("Controller Awake");
        material = GetComponent<MeshRenderer>().material;
        material.color = defaultColor;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // receive input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TestFunction();
        }

        // 1 key to active target object
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            targetObject.SetActive(true);
        }

        // 2 key to deactive target object
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            targetObject.SetActive(false);
        }

        // 3 key to enable target object
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            targetObject.GetComponent<LifeCycle>().enabled = true;
        }

        // 4 key to disable target object
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            targetObject.GetComponent<LifeCycle>().enabled = false;
        }

    }

    // receive message from LifeCycle
    public void ReceiveMessage(string message)
    {
        Debug.Log("Controller Receive Message: " + message);
    }

    // receive input
    public void TestFunction()
    {
        Debug.Log("Controller Test Function has receive input.");
        // send message to LifeCycle
        targetObject.SendMessage("ReceiveMessage", "Hello, I'm from Controller.");
        // change color to red
        material.color = Color.red;
        // start coroutine to change color back to white
        StartCoroutine(ChangeColorBack(2.5f));
    }

    // 2.5s later, change color back to white
    IEnumerator ChangeColorBack(float Delay)
    {
        Debug.Log("Coroutines start..");
        yield return new WaitForSeconds(Delay);
        material.color = defaultColor;
        Debug.Log("Coroutines end..");
    }
}
