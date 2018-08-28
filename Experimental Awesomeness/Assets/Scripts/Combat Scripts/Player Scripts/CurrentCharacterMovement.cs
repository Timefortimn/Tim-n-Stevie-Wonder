using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentCharacterMovement : MonoBehaviour {

	private CharacterController player;
	public int Speed = 3;
	private int[] direction;
	private int lastMove;

	// Use this for initialization
	void Start ()
	{
		player = GetComponent<CharacterController>();
		direction = new int[Speed];
	}
	
	// Update is called once per frame
	void Update()
	{
		
		// allows you to move for your maximum distance
		
		if (Speed > 0)
		{
			if (Input.GetKeyDown("w"))
			{
				player.Move(player.transform.forward * 10);
				Speed -= 1;
				direction[Speed] = 1;
			}

			if (Input.GetKeyDown("s"))
			{
				player.Move(player.transform.forward * -10);
				Speed -= 1;
				direction[Speed] = 2;
			}

			if (Input.GetKeyDown("d"))
			{
				player.Move(player.transform.right * 10);
				Speed -= 1;
				direction[Speed] = 3;
			}

			if (Input.GetKeyDown("a"))
			{
				player.Move(player.transform.right * -10);
				Speed -= 1;
				direction[Speed] = 4;
			}
		}

		// this will allow you to reverse your moves in the correct order
		
		if (Speed < direction.Length)
		{
			if (Input.GetKeyDown("z"))
			{
				lastMove = direction[Speed];
				Speed += 1;
				switch (lastMove)
				{
					case 1:
					{
						player.Move(player.transform.forward * -10);
						break;
					}
					case 2:
					{
						player.Move(player.transform.forward * 10);
						break;
					}
					case 3:
					{
						player.Move(player.transform.right * -10);
						break;
					}
					case 4:
					{
						player.Move(player.transform.right * 10);
						break;
					}
				}
			}
		}
	}
}
