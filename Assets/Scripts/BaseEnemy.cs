using System.Collections;
using UnityEngine;

[System.Serializable]
public class BaseEnemy
{
	public string name;

	public enum Type {
		grass,
		fire,
		water,
		electric
	}

	public enum Rarity {
		common,
		rare,
		legendary,
	}

	public Type EnemyType;
	public Rarity EnemyRarity;

	public float baseHP;
	public float curHP;

	public float baseMP;
	public float curMP;

	public float baseATK;
	public float curATK;

	public float baseDEF;
	public float curDEF;

}
