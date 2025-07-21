using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LuckGame {
    /// <summary>
    /// 对象池管理器
    /// </summary>
    public class PoolManager : SingleInstanceAutoBase<PoolManager>
    {
        private void PoolsInit() { }

        Dictionary<String, List<GameObject>> poolDict = new();


        //创建对象池
        /// <summary>
        /// 获取对象池中的对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GameObject GetObj(string name)
        {
            GameObject obj = null;
            if (poolDict.ContainsKey(name)&& poolDict[name].Count > 0)
            {
                obj = poolDict[name][0];
                poolDict[name].Remove(obj);
            }
            else
            {
                obj = GameObject.Instantiate(Resources.Load<GameObject>((name)));
            }
            obj.SetActive(true);
            return obj;

        }




        public void PushObj(string name, GameObject obj)
        {
            obj.SetActive(false);
            if (!poolDict.ContainsKey(name))
            {
                poolDict.Add(name, new List<GameObject>() { obj });
            }
            poolDict[name].Add(obj);
        }

    }
}
