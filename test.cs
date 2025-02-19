using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UniWebView;

public class WebViewInputLoader : MonoBehaviour
{
    public TMP_InputField urlInputField;
    public Button confirmButton;
    private UniWebView webView;

    void Start()
    {

        webView = gameObject.AddComponent<UniWebView>();
        webView.Frame = new Rect(0, 0, Screen.width, Screen.height); // 全屏显示

        // 为确认按钮添加点击事件监听器
        confirmButton.onClick.AddListener(LoadUrlFromInput);

        // 注册 WebView 事件监听
        webView.OnPageFinished += OnPageFinished;
        webView.OnPageErrorReceived += OnPageErrorReceived;
    }

    void LoadUrlFromInput()
    {
        // 获取输入框中的 URL
        string url = urlInputField.text;
        if (!string.IsNullOrEmpty(url))
        {
            // 加载输入的 URL
            webView.Load(url);
            // 显示 WebView
            webView.Show();
        }
    }

    private void OnPageFinished(UniWebView webView, int statusCode, string url)
    {
        Debug.Log($"Web page loaded successfully. Status code: {statusCode}, URL: {url}");
    }

    private void OnPageErrorReceived(UniWebView webView, int errorCode, string errorMessage)
    {
        Debug.LogError($"Web page loading error. Error code: {errorCode}, Error message: {errorMessage}");
    }
}