using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class ShapeManager : MonoBehaviour
{
    [Tooltip("物件預置物")]
    public List<abstractPrefeb> shapePrefeb = new List<abstractPrefeb>();
    public List<abstractPrefeb> shapeInstantiate = new List<abstractPrefeb>();
    public Button SelectShape;
    public Button SelectCube;
    public Button SelectCapsule;

    public Button DelectShape;
    public Button DelectCube;
    public Button DelectCapsule;
    [Tooltip("長度")]
    [SerializeField] int lenghtx;
    [Tooltip("寬度")]
    [SerializeField] int lenghtz;
    [Tooltip("間隔")]
    [SerializeField] int spacing;
    void Start()
    {

        SelectShape.onClick.AddListener(() => { FindShape<Sphere>(); });
        SelectCube.onClick.AddListener(() => { FindShape<Cube>(); });
        SelectCapsule.onClick.AddListener(() => { FindShape<Capsule>(); });

        DelectShape.onClick.AddListener(() => { DestoryShape<Sphere>(); });
        DelectCube.onClick.AddListener(() => { DestoryShape<Cube>(); });
        DelectCapsule.onClick.AddListener(() => { DestoryShape<Capsule>(); });
        ///生成物件 並放入  shapeInstantiate
        for (int i = 0; i < lenghtx; i++)
        {
            for (int j = 0; j < lenghtz; j++)
            {

                GameObject ins = Instantiate(shapePrefeb[Random.Range(0, shapePrefeb.Count)].gameObject, new Vector3(i * spacing, 0, j * spacing), Quaternion.identity);
                shapeInstantiate.Add(ins.GetComponent<abstractPrefeb>());
                ins.GetComponent<Renderer>().material.color = Color.cyan;
                ins.transform.SetParent(this.transform);
            }
        }
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //    Debug.Log(IsShaperUnderMouse<Sphere>());
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Debug.Log(IsShaperUnderMouse<Cube>());
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //    Debug.Log(IsShaperUnderMouse<Capsule>());
    }
    /// <summary>
    /// 利用泛型約束 查詢 物件 ex :  : Component 代表該物件 需繼承自 Component
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void FindShape<T>() where T : abstractPrefeb
    {
        foreach (abstractPrefeb shape in shapeInstantiate)
        {
            if (shape is T)
            {
                shape.GetComponent<Renderer>().material.color = Color.red;

            }
            else
            {
                shape.GetComponent<Renderer>().material.color = Color.cyan;
            }
        }

    }
    /// <summary>
    /// 利用泛型約束 拿到所有 物件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public List<T> ReturnFindShape<T>() where T : abstractPrefeb
    {
        List<T> GetData = new List<T>();
        foreach (abstractPrefeb shape in shapeInstantiate)
        {
            if (shape is T)
            {
                GetData.Add(shape as T);//轉型後回傳
            }
        }
        return GetData;
    }
    /// <summary>
    /// 刪除物件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void DestoryShape<T>() where T : abstractPrefeb
    {
        List<T> GetData = ReturnFindShape<T>();
        foreach (T data in GetData)
        {
            shapeInstantiate.Remove(data);
            Destroy(data.transform.gameObject);
        }
    }

    /// <summary>
    /// 射線抓該物件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    bool IsShaperUnderMouse<T>() where T : abstractPrefeb
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider != null && hit.collider.GetComponent<T>() != null)
            {
                Debug.Log(hit.collider.name);
                return true;
            } 
        }
        return false;
    }

}
