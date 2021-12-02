using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Character", menuName = "Character Creation/Player Units")]
public class CharStats : ScriptableObject
{
    public string charName;
	[HideInInspector]
	public float duration;
	public float durationMin;
	public float durationMax;
	[HideInInspector]
	public float runWait;
	public float startRunWait;
	public float endRunWait;


	public void RandomizeStats()
	{
		duration = Random.Range(durationMin, durationMin);
		runWait = Random.Range(startRunWait, endRunWait);
	}


	
}
