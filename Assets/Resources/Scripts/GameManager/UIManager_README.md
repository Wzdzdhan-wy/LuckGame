# 泛型UI管理器使用说明

## 概述
新的泛型UI管理器允许你使用类型而不是字符串来管理UI组件，这样可以：
- 避免输入错误
- 获得更好的IDE支持（自动补全、类型检查）
- 提高代码的可维护性

## 主要功能

### 1. 泛型UI显示
```csharp
// 旧方式 - 需要输入字符串
EventCenterManager.Instance.TriggerEvent(UIController.ShowUi, "UiTest");

// 新方式 - 使用泛型，不需要输入名称
UiManager.Instance().ShowUIForm<UiTest>();
```

### 2. 泛型UI隐藏
```csharp
// 旧方式
EventCenterManager.Instance.TriggerEvent(UIController.HideUIForm, "UiTest");

// 新方式
UiManager.Instance().HideUIForm<UiTest>();
```

### 3. 泛型UI关闭
```csharp
// 旧方式
EventCenterManager.Instance.TriggerEvent(UIController.CloseUIForm, "UiTest");

// 新方式
UiManager.Instance().CloseUIForm<UiTest>();
```

### 4. 获取UI实例
```csharp
// 获取特定类型的UI实例
UiTest uiInstance = UiManager.Instance().GetUI<UiTest>();
if (uiInstance != null)
{
    // 可以直接访问UI组件
    uiInstance.testButton.onClick.AddListener(OnButtonClick);
}
```

### 5. 检查UI状态
```csharp
// 检查UI是否已注册
bool isRegistered = UiManager.Instance().IsUIRegistered<UiTest>();

// 检查UI是否正在显示
bool isShowing = UiManager.Instance().IsUIShowing<UiTest>();
```

## 如何创建新的UI类

### 1. 继承UIFromBase
```csharp
public class MyCustomUI : UIFromBase
{
    [Header("UI组件")]
    public Button myButton;
    public Text myText;
    
    private void Start()
    {
        // 初始化UI组件
        if (myButton != null)
        {
            myButton.onClick.AddListener(OnMyButtonClick);
        }
    }
    
    private void OnMyButtonClick()
    {
        Debug.Log("按钮被点击");
    }
}
```

### 2. 自动注册
UI类会在Awake时自动注册到UiManager中，无需手动注册。

### 3. 使用泛型方法调用
```csharp
// 显示你的UI
UiManager.Instance().ShowUIForm<MyCustomUI>();

// 隐藏你的UI
UiManager.Instance().HideUIForm<MyCustomUI>();

// 关闭你的UI
UiManager.Instance().CloseUIForm<MyCustomUI>();
```

## 优势对比

### 旧方式的问题
- 需要记住UI的名称字符串
- 容易出现拼写错误
- 重构时容易遗漏
- 没有IDE的智能提示

### 新方式的优势
- 类型安全，编译时检查
- IDE自动补全支持
- 重构时自动更新
- 更好的代码可读性

## 兼容性
新的泛型UI管理器完全兼容原有的字符串方式，你可以：
- 继续使用原有的字符串方式
- 逐步迁移到新的泛型方式
- 两种方式混合使用

## 注意事项
1. UI类必须继承自`UIFromBase`
2. UI类会在Awake时自动注册
3. 确保UI类名与GameObject名称一致（用于字符串方式）
4. 泛型方式使用类型名，不依赖GameObject名称

## 示例代码
参考 `Assets/Resources/Scripts/Test/StartTest.cs` 和 `Assets/Resources/Scripts/Test/UiTest.cs` 文件中的示例。 