using UnityEngine;
//单例模式基类
//继承该类可以自动实现单例模式
namespace LuckGame { 
public class SingleInstanceAutoBase<T> : MonoBehaviour where T: MonoBehaviour
{
    private static T singletonauto ;
    protected SingleInstanceAutoBase() { }
   
    public static T Instance(bool isPersistence = true )
    {
           
            
            if (singletonauto == null)
            {
                singletonauto = FindObjectOfType<T>();
                GameObject obj = new GameObject(typeof(T).Name);
                if(isPersistence) obj.AddComponent<T>();
            }
        return singletonauto;
    }
}

}