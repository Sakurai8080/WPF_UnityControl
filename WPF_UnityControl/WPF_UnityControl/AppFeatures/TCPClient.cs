using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace WPF_UnityControl
{
    public class TCPClient
    {
        private string _serverIP = "127.0.0.1";
        private int _port = 5000;
        private TcpClient? _client;
        private NetworkStream? _stream;
        private CancellationTokenSource? _cts;

        public async Task ConnectAsync()
        {
            try
            {
                _client = new TcpClient();
                await _client.ConnectAsync(_serverIP, _port);
                _stream = _client.GetStream();
                _cts = new CancellationTokenSource();

                _ = ListenForMessagesAsync(_cts.Token);

                MessageBox.Show("Unityに接続しました！");
            }
            catch (Exception e)
            {
                MessageBox.Show($"接続エラー: {e.Message}");
            }
        }

        private async Task ListenForMessagesAsync(CancellationToken token)
        {
            byte[] buffer = new byte[1024];

            while (!token.IsCancellationRequested && _client.Connected)
            {
                int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length, token);
                if (bytesRead == 0) break;

                string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                MessageBox.Show($"Unityからのメッセージ: {receivedData}");
            }
        }

        public async Task SendMessageAsync(string message)
        {
            if (_client == null || !_client.Connected) return;

            try
            {
                byte[] data = Encoding.UTF8.GetBytes(message);
                await _stream.WriteAsync(data, 0, data.Length);
            }
            catch (Exception e)
            {
                MessageBox.Show($"送信エラー: {e.Message}");
            }
        }

        public async Task<List<string>> GetSceneListAsync()
        {
            if (_client == null || !_client.Connected) return new List<string>();

            try
            {
                await SendMessageAsync("GET_SCENES");

                byte[] buffer = new byte[4096];  // バッファサイズを拡大
                StringBuilder responseBuilder = new StringBuilder();

                int bytesRead;
                do
                {
                    bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);
                    responseBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                } while (_stream.DataAvailable);

                string jsonResponse = responseBuilder.ToString();

                MessageBox.Show($"受信したシーンリスト: {jsonResponse}");

                SceneList sceneList = JsonConvert.DeserializeObject<SceneList>(jsonResponse);

                if (string.IsNullOrWhiteSpace(jsonResponse))
                {
                    MessageBox.Show("受信データが空です！");
                    return new List<string>();
                }
                return sceneList.scenes;
            }
            catch (Exception e)
            {
                MessageBox.Show($"受信エラー: {e.Message}");
                return new List<string>();
            }
        }


        public async Task LoadEditorSceneAsync(string sceneName)
        {
            if (_client == null || !_client.Connected) return;

            try
            {
                await SendMessageAsync($"EDITOR_LOAD_SCENE:{sceneName}");
                MessageBox.Show($"エディタでシーン {sceneName} をロードしました！");
            }
            catch (Exception e)
            {
                MessageBox.Show($"エディタシーンロードエラー: {e.Message}");
            }
        }

        public void Disconnect()
        {
            _cts?.Cancel();
            _stream?.Close();
            _client?.Close();
        }

        private class SceneList
        {
            public List<string> scenes { get; set; }
        }
    }
}