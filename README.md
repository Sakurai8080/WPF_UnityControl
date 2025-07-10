
# ✅ 概要
UnityをWPFから外部制御するデスクトップアプリケーション。  
WPF側からUnityに対してデータや操作を送信し、  
リアルタイムにUnity操作をする仕組みを構築しています。  
 

<img width="1205" height="726" alt="スクリーンショット 2025-07-11 024213" src="https://github.com/user-attachments/assets/142b3d0f-0add-4881-823a-7041c73a9326" />


## ✅ 開発環境

- OS：Windows 10 / 11
- IDE：Visual Studio 2022
- .NET：8.0
- Unity：6.0.37f1


## ✅ 主な使用技術

1. Prism - MVVMアーキテクチャ支援
2. ReacticeProperty - 状態管理・リアクティブUI
3. MaterialDesing - モダンUI構築



## ✅ アプリケーション構成

### 1. 接続方法

- WPF と Unity 間は **TCP ソケット通信** により接続されます。
- WPF 側がクライアント、Unity 側がサーバーとして通信を管理します。

### 2. データ送受信

- WPF から Unity にコマンド送信（例：オブジェクトのトランスフォーム変更、シーン変更など）
- Unity 側からも受信コマンドに応じて通知（例：ゲームオブジェクトデータ、シーン情報など）


##  ✅ アーキテクチャ
・MVVM


## ✅ プラットフォーム
- WPFのため、Windows 専用アプリケーション。



## ✅ 実行方法

1. **Unity 側**  
   - 指定のシーンをビルドし、実行
   - Unity が TCP サーバーとして待機

2. **WPF 側**  
   - アプリケーション起動
   - Unity へ接続し、制御を開始

