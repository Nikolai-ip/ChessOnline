using System;
using Infrastructure.Events;
using Infrastructure.Services.ServiceLocator;
using Network;
using Signals;
using TMPro;
using UnityEngine;

public class Test:MonoBehaviour
{
    private INetworkDataReceiver _receiver;
    private INetworkDataSender _sender;
    private IRoomService _roomService;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TextMeshProUGUI _textUI;
    private void Awake()
    {
        EventBus.Subscribe<SceneLoaded>(OnSceneLoad);
    }

    private void OnSceneLoad(SceneLoaded signal)
    {
        var sendMessageController = FindObjectOfType<SendMessageController>();
        Init(sendMessageController.GetComponent<INetworkDataReceiver>(),
            sendMessageController.GetComponent<INetworkDataSender>());
    }

    private void Init(INetworkDataReceiver receiver, INetworkDataSender sender)
    {
        _receiver = receiver;
        _sender = sender;
        _inputField.onValueChanged.AddListener(OnValueChanged);
        _receiver.RegisterHandler<InputFiledData>(OnInputFieldDataChanged);
        
    }
    private void OnValueChanged(string text)
    {
        _sender.SendAll(new InputFiledData(){Text = text});
    }
    private void OnInputFieldDataChanged(InputFiledData data)
    {
        _textUI.text = data.Text;
    }
}

[Serializable]
public class InputFiledData:INetworkData
{
    public string Text;
}
