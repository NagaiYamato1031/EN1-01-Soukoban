using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

	// 配列の宣言
	int[] map;

	// Start is called before the first frame update
	void Start()
	{
		// 配列のインスタンス化と初期化
		map = new int[] { 0, 0, 0, 1, 0, 2, 0, 0, 0 };

		PrintArray();

	}

	// Update is called once per frame
	void Update()
	{
		int playerIndex = GetPlayerIndex();
		// 右入力
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			MoveNumber(1, playerIndex, playerIndex + 1);
			PrintArray();
		}
		// 左入力
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			MoveNumber(1, playerIndex, playerIndex - 1);
			PrintArray();
		}
	}

	// 配列の出力
	private void PrintArray()
	{

		string debugString = "";

		for (int i = 0; i < map.Length; i++)
		{
			// 要素数を結合
			debugString += map[i].ToString() + ",";
		}

		Debug.Log(debugString);

	}

	// プレイヤーの添え字を取得
	private int GetPlayerIndex()
	{
		for (int i = 0; i < map.Length; i++)
		{
			if (map[i].Equals(1))
			{
				return i;
			}
		}
		return -1;
	}

	// 箱やプレイヤーの移動処理
	private bool MoveNumber(int num, int moveFrom, int moveTo)
	{

		if (moveTo < 0 || map.Length - 1 < moveTo)
		{
			return false;
		}
		// 移動先に箱があるか
		if (map[moveTo] == 2)
		{
			int velocity = moveTo - moveFrom;
			if( !MoveNumber(2, moveTo, moveTo + velocity))
			{
				return false;
			}
		}
		map[moveTo] = num;
		map[moveFrom] = 0;
		return true;
	}

}
