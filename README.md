
# ✅ 概要
UnityをWPFから外部制御するデスクトップアプリケーション
WPF側からUnityに対してデータや操作を送信し、
リアルタイムにUnity操作をする仕組みを構築しています。

<img width="1197" height="718" alt="スクリーンショット 2025-07-11 023007" src="https://github.com/user-attachments/assets/1197df9c-8bd1-4c5c-a40a-bced43a0fca1" />


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
- WPFのため、Windows 専用アプリケーションとして構築



## ✅ 実行方法

1. **Unity 側**  
   - 指定のシーンをビルドし、実行
   - Unity が TCP サーバーとして待機

2. **WPF 側**  
   - アプリケーション起動
   - Unity へ接続し、制御を開始

