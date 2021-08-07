using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TScript : MonoBehaviour {
    public int i;
    public string s;
    public bool b;
    public List<int> lInt;
    public PlayerData _PlayerData;

    // Use this for initialization
    void Start () {
        #region TTest
        TTest<int>();
        TTest<string>();
        #endregion

        #region TEvent
        TEvent(99);
        TEvent("哈哈");
        TEvent(true);

        List<int> list = new List<int>();
        list.Add(100);
        list.Add(200);
        list.Add(300);
        TEvent(list);

        PlayerData pd = new PlayerData(9999);
        TEvent(pd);
        #endregion
    }

    private void TTest<T>()//T為任意名稱
    {
        if (Types.Equals(typeof(T), typeof(int)))
        {
            Debug.Log("调用的类型是  int");
        }
        else if (Types.Equals(typeof(T), typeof(string)))
        {
            Debug.Log("调用的类型是  string");
        }
    }

    void TEvent<T>(T t)//兩者T 一樣 <T> 及(T)   ==  <X>(X x)
    {
        if (Types.Equals(typeof(T), typeof(int)))
        {
            Debug.Log("類型:" + "int");
            i = (int)(object)t;
        }
        else if (Types.Equals(typeof(T), typeof(string)))
        {
            Debug.Log("類型:" + "string");
            s = (string)(object)t;
            //s = t as string;//可以為Null的類型才能使用as轉型
        }
        else if (Types.Equals(typeof(T), typeof(bool)))
        {
            Debug.Log("類型:" + "bool");
            b = (bool)(object)t;
        }
        else if (Types.Equals(typeof(T), typeof(List<int>)))
        {
            Debug.Log("類型:" + "List<int>");
            lInt = (List<int>)(object)t;
        }
        else if (Types.Equals(typeof(T), typeof(PlayerData)))
        {
            Debug.Log("類型:" + "PlayerData");
            _PlayerData = (PlayerData)(object)t;
        }
        else
            Debug.LogWarning("無符合的類型");
    }


    [System.Serializable]
    public class PlayerData
    {
        public PlayerData(int hp)
        {
            this.hp = hp;
        }

        public int hp;
    }
}

