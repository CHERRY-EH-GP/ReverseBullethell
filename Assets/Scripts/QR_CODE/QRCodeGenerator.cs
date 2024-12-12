using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;
using UnityEngine.UI;
using TMPro;

public class QRCodeGenerator : MonoBehaviour
{
    [SerializeField] private RawImage _rawImageReceiver;
    [SerializeField] private TMP_InputField _textInputField;
    private Texture2D _storeEncodedTexture;
    
    void Start()
    {
        _storeEncodedTexture = new Texture2D(256, 256);
    }

  

    public void OnClickEncode()
    {
        EncodeTextToQRCode();
    }

    public void EncodeTextToQRCode()
    {
        string textWrite = string.IsNullOrEmpty(_textInputField.text) ? "Write something to encode" : _textInputField.text;
        Color32[] _convertPixelToTexture = Encode(textWrite, _storeEncodedTexture.width, _storeEncodedTexture.height);
        _storeEncodedTexture.SetPixels32(_convertPixelToTexture);
        _storeEncodedTexture.Apply();

        _rawImageReceiver.texture = _storeEncodedTexture;
    }

    private Color32[] Encode(string textForEncoding, int width, int height)
    {
        BarcodeWriter writer = new BarcodeWriter()
        {
            Format = BarcodeFormat.QR_CODE,
            Options =
            {
                Height = height,
                Width = width
            }
        };

        return writer.Write(textForEncoding);
    }
}
