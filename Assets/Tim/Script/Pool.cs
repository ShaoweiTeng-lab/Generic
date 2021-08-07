using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=6ED4Qo0Yi6o
public static class Pool<T> where T : Component
{
    public static Queue<T> objectQueue = new Queue<T>();
    public static GameObject prefeb;
    public static void SetPrefeb(GameObject prefeb) {
        Pool<T>.prefeb = prefeb;
    }
    public static void ReturnObjectToPool(T obj) {//��^ queue��
        objectQueue.Enqueue(obj);
        obj.gameObject.SetActive(false);
    }
    public static T GetObjFromPool() //�Y��������X �Y�L�h�ͦ�����
    {
        if (objectQueue.Count > 0)
        { T Objget = objectQueue.Dequeue();
            Objget.gameObject.SetActive(true);
            return Objget; //return�ᤣ�|���U
        }
        return GameObject.Instantiate(prefeb).GetComponent<T>();

    }
    
}
 