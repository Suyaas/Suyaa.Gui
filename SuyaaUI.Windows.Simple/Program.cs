using SuyaaUI;
using SuyaaUI.Windows;

// 创建一个窗口
SWindow window = new();
window.NativeWindow.SetIcon($"{egg.IO.GetExecutionPath("app.png")}");
window.NativeWindow.UpdateDisplay();
window.Show();

