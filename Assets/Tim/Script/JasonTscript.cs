using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
public class JasonTscript : MonoBehaviour
{   //https://www.youtube.com/watch?v=7VlykMssZzk&t=691s
    // Start is called before the first frame update
    public GameObject prefeb;
    public GameObject prefeb2;
    public List<Transform> insprefeb;
    void Start()
    {

        int[] GetintArry = createArry(1, 10);
        Debug.Log(GetintArry[0] + " " + GetintArry[1]);
        string[] GetStringArry = createArry("String1", "String2");
        Debug.Log(GetStringArry[0] + " " + GetStringArry[1]);
        differentGenerics("Hellow", 10);
        //只能抓到 myclass的方法 有點像 父名子體
        myClass<Enemy1> myClass_ = new myClass<Enemy1>(new Enemy1());
        myClass_.SendMessage();
        myClass<Enemy2> myClass00 = new myClass<Enemy2>(new Enemy2());
        myClass00.SendMessage();

        Genericesclass<GenericesInterface> Genericesclass_ = new Genericesclass<GenericesInterface>(new GenericesInterface());
        Genericesclass_.InterfaceFunction(11);
        Pool<Transform>.SetPrefeb(prefeb);
        Pool<prefeb>.SetPrefeb(prefeb2);
        for (int i = 0; i < 10; i++) {
            Transform instence = Pool<Transform>.GetObjFromPool();
            insprefeb.Add(instence);
        }
        for (int i = 0; i < insprefeb.Count; i++)
        {
            Pool<Transform>.ReturnObjectToPool(insprefeb[i]);
        }
        insprefeb.Clear();
        Debug.Log("count : " + Pool<Transform>.objectQueue.Count);
       
        
    }
    #region 泛型 回傳 及方法
    public T[] createArry<T>(T Element, T Element2) {
        return new T[] { Element, Element2 };
    }

    public void differentGenerics<T1, T2>(T1 t1, T2 t2) {
        Debug.Log(t1 + " " + t2);

    }

    #endregion
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
            Pool<Transform>.GetObjFromPool();
    } 
       
}


#region 泛型 class 條件約束
//限制條件約束 ， 每當實現 mclass則必續實作 interface
public class  myClass<T> where T : IEnemy
{
    public T  value;// 根據型別做定義
    public myClass(T value) {
        this.value = value; 
    }
    public void SendMessage() {
        value.damage();//因為判定實作 IEnemy 所以可使用 其方法 
    }
}

public interface IEnemy {
    void damage(); 
}
public class Enemy1 : IEnemy
{
    public void damage()
    {
        Debug.Log("Enemy1 Attack");
    }
}
public class Enemy2 : IEnemy
{
    public void damage()
    {
        Debug.Log("Enemy2 Attack");
    }
    public void EnemyGet() {
        Debug.Log("EnemyGet Attack");
    
    }
}
#endregion



#region 泛型 interface
//約束 繼承於某interface  
public class Genericesclass<T> where T : interfaceGenerices<int>, new()
{
    T value;
    public Genericesclass (T t) {
        value = t;


    }
    public void InterfaceFunction( int index) {
        value.SendMessage(index);
    
    }

}
public interface  interfaceGenerices<T>{
    void SendMessage(T t); 
}
public class GenericesInterface : interfaceGenerices<int>
{
    public void SendMessage(int t)
    {
        Debug.Log(t);
    }
}
#endregion