using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : Component
{
    private static T _instance = null;

    public static T Instance
    {
        get
        {
            //��������δ������
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(T)) as T;
                //������δ�ҵ��õ��������´���һ�����ص����ű�������
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    _instance = (T)obj.AddComponent<T>();

                    obj.hideFlags = HideFlags.DontSave;
                    obj.name = typeof(T).Name;
                }
            }
            return _instance;
        }
    }

    //��ʼ��
    public virtual void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (_instance == null)
        {
            _instance = this as T;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}