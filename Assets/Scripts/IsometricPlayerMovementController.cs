using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovementController : MonoBehaviour
{
	
	protected Joystick joystick;
	protected JoyButton joybutton;
	private GameObject bullet;
	public Transform firepoint;
	[SerializeField] public float movementSpeed = 1f;
	[SerializeField] public float angle;
	[SerializeField] public Vector2 diraxis;

	protected bool shoot;

	IsometricCharacterRenderer isoRenderer;
    Rigidbody2D rbody;

    private void Awake()
	{
		joystick = FindObjectOfType<Joystick>();
		joybutton = FindObjectOfType<JoyButton>();
		rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }

    void FixedUpdate()
    {
		Move();
		Shoot();
    }

	void Move()
	{
		Vector2 currentPos = rbody.position;
		float horizontalInput = joystick.Horizontal;
		float verticalInput = joystick.Vertical;
		Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
		inputVector = Vector2.ClampMagnitude(inputVector, 1);
		Vector2 movement = inputVector * movementSpeed;
		Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
		isoRenderer.SetDirection(movement);
		rbody.MovePosition(newPos);

		MathfCalculate.DegreeFromVector2(inputVector);
		//Debug.Log(inputVector +" Degree : "+ MathfCalculate.DegreeFromVector2(inputVector).ToString());
		diraxis = inputVector;
		angle = MathfCalculate.DegreeFromVector2(inputVector);
	}

	void Shoot()
	{
		if (!shoot && joybutton.Pressed && diraxis.x != 0)
		{
			shoot = true;
			var weapon = GetComponentInChildren<Weapon>();
			weapon.Shoot();
		}
		if (shoot && !joybutton.Pressed)
		{
			shoot = false;
		}
	}
}
