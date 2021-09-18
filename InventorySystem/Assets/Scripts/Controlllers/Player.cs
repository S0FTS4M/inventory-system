using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public Inventory Inventory { get; private set; }

    [SerializeField, Range(0, 100)]
    private float Health = 50;

    private float MaxHealth = 100;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 10.0f;
    private float jumpHeight = 10.0f;
    private float gravityValue = -9.81f;
    private Vector3 moveDirection;

    private int inventoryCapacity = 3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();

        Inventory = new Inventory(inventoryCapacity);
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= playerSpeed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpHeight;

        }
        else
            moveDirection.y += gravityValue * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);
    }

    public void Heal(float amount)
    {
        Health += amount;

        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ItemController itemController = other.GetComponent<ItemController>();

        if(itemController == null)
        {
            return;
        }

        bool added = Inventory.AddItem(itemController.Item);
        
        if(added)
            Destroy(other.gameObject);
        else
            Debug.LogError("Inventory is full");
    }
}
