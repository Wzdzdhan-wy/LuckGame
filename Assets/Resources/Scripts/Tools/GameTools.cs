using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace LuckGame {

    //游戏工具类的基类
    //游戏工具类都继承自这个类
    //用于提供一些工具方法
    //使用单例模式
    //部分方法可以直接调用，不需要实例化对象
    public static class GameTools
    {

        public static void ShiftElementsBackward<T>(this List<T> list)
        {
            if (list == null || list.Count <= 1) return;
            T lastItem = list[list.Count - 1];
            for (int i = list.Count - 2; i >= 0; i--)
            {
                list[i + 1] = list[i];
            }
            // 将原最后一个元素放到首位
            list[0] = lastItem;
        }



    }

}