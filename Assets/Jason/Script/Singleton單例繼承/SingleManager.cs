using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleManager : Singleton<SingleManager>
{
    // Start is called before the first frame update
    void Start()
    {
        Test t1 = new Test();
        t1.DoThing();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SendMessage()
    { 
        Debug.Log("SingleManager : SendMessage");
    }
}
public class Test
{
    public void DoThing()
    {
        SingleManager.instance.SendMessage();


    }

}
