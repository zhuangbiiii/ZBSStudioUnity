using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// test event and delegate
// event is a special type of delegate
// that can only be invoked from the class that it is declared in


namespace test.action
{
    public class controllerevent : MonoBehaviour
    {
        // action 01
        public event System.Action OnAction01;
        // action 02
        //public event System.Action OnAction02;

        // delegate 01
        public delegate void OnDelegate01(int index);
        public OnDelegate01 onDelegate01;
        // delegate 02
        //public delegate void OnDelegate02();
        //public OnDelegate02 onDelegate02;

        // gameobject
        public GameObject cube;
        public GameObject sphere;

        // color pool
        private Color[] colorPool;


        // Start is called before the first frame update
        void Start()
        {
            if (cube == null)
            {
                Debug.LogError("cube is null");
            }

            if (sphere == null)
            {
                Debug.LogError("sphere is null");
            }

            colorPool = new Color[5];
            colorPool[0] = Color.red;
            colorPool[1] = Color.green;
            colorPool[2] = Color.blue;
            colorPool[3] = Color.yellow;
            colorPool[4] = Color.cyan;

            // bind function to action
            OnAction01 += DebugFunc;

            // bind function to delegate
            onDelegate01 += DebugFunc0;
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetButtonDown("Debug0"))
            {
                // use action trigger DebugFunc
                OnAction01?.Invoke();

            }

            if (Input.GetButtonDown("Debug1"))
            {
                // use delegate trigger DebugFunc
                int index = Random.Range(0, 5);
                onDelegate01?.Invoke(index);
            }
        }

        public void DebugFunc0(int index)
        {
            // change color
            cube.GetComponent<Renderer>().material.color = colorPool[index];
            
            sphere.GetComponent<Renderer>().material.color = colorPool[index];
        }

        public void DebugFunc()
        {
            // change color
            cube.GetComponent<Renderer>().material.color = colorPool[Random.Range(0, 5)];
            sphere.GetComponent<Renderer>().material.color = colorPool[Random.Range(0, 5)];
        }
    }
}