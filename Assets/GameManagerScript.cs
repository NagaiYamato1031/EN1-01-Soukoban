using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

	// �z��̐錾
	int[] map;

	// Start is called before the first frame update
	void Start()
	{
		// �z��̃C���X�^���X���Ə�����
		map = new int[] { 0, 0, 0, 1, 0, 2, 0, 0, 0 };

		PrintArray();

	}

	// Update is called once per frame
	void Update()
	{
		int playerIndex = GetPlayerIndex();
		// �E����
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			MoveNumber(1, playerIndex, playerIndex + 1);
			PrintArray();
		}
		// ������
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			MoveNumber(1, playerIndex, playerIndex - 1);
			PrintArray();
		}
	}

	// �z��̏o��
	private void PrintArray()
	{

		string debugString = "";

		for (int i = 0; i < map.Length; i++)
		{
			// �v�f��������
			debugString += map[i].ToString() + ",";
		}

		Debug.Log(debugString);

	}

	// �v���C���[�̓Y�������擾
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

	// ����v���C���[�̈ړ�����
	private bool MoveNumber(int num, int moveFrom, int moveTo)
	{

		if (moveTo < 0 || map.Length - 1 < moveTo)
		{
			return false;
		}
		// �ړ���ɔ������邩
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
