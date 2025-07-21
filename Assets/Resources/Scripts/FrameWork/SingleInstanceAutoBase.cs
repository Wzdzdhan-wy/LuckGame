using UnityEngine;
//单例模式基类
//继承该类可以自动实现单例模式
//继承MonoBehaviour的单例，
//在Awake()方法中，自动初始化单例。推荐使用
//手动调用Instance()方法获取单例。
namespace LuckGame { 
public class SingleInstanceAutoBase<T> : MonoBehaviour where T: MonoBehaviour
{
    private static T singletonAuto ;
    protected SingleInstanceAutoBase() { }
    //isPersistence 是否保持持久性 true保持 false不保持
    public static T Instance(bool isPersistence = true )
    {
           
            
            if (singletonAuto == null)
            {
                singletonAuto = FindObjectOfType<T>();
                GameObject obj = new GameObject(typeof(T).Name);
                if(isPersistence) DontDestroyOnLoad(obj);
            }
        return singletonAuto;
    }
}

}