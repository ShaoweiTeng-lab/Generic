using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
	//繼承後即可將該腳本變為單例
	#region Fields

	/// <summary>
	/// The instance.
	/// </summary>
	private static T _instance;

	#endregion

	#region Properties

	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <value>The instance.</value>
	public static T instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = UnityEngine.Object.FindObjectOfType(typeof(T)) as T;
				if (_instance == null)
				{
					GameObject obj = new GameObject(typeof(T).Name);
					_instance = obj.AddComponent<T>();
					DontDestroyOnLoad(obj);
					Debug.Log(obj.name+"實例化");

				}
			}
			return _instance;
		}
	}

	#endregion

	#region Methods

	/// <summary>
	///使用於初始化.
	/// </summary>
	/*protected virtual void Awake()
	{
		if (_instance == null)
		{
			_instance = this as T;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}*/

	#endregion

}