using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CharacterController : MonoBehaviour{
    [SerializeField] private LevelManager levelManager;

    [SerializeField] private float movementSpeed;
    private string direction = "";

    [SerializeField] private DialogueRunner dialogueRunner;

    //Attached components
    private Rigidbody2D rigi;

    public string Direction { get => direction; set => this.direction = value; }
    public bool MovementEnabled { get => movementEnabled; set => movementEnabled = value; }

    void Start() {
        rigi = transform.GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            RaycastHit2D hit;
            if(direction == "up"){
                hit = Physics2D.Raycast(transform.position, Vector2.up);
            }else if(direction == "down"){
                hit = Physics2D.Raycast(transform.position, -Vector2.up);
            }else if(direction == "right"){
                hit = Physics2D.Raycast(transform.position, Vector2.right);
            }else{
                hit = Physics2D.Raycast(transform.position, -Vector2.right);
            }
            if(hit.collider != null){
                float distance = Mathf.Abs(Vector2.Distance(hit.point, transform.position));
                if(distance <= 10 && hit.collider.tag == "NPC") {
                    dialogueRunner.StartDialogue(hit.collider.transform.GetComponent<NPC>().Node);
                    hit.collider.transform.GetComponent<NPC>().OnEnterDialogue.Invoke();
                    dialogueRunner.onDialogueComplete.AddListener(hit.collider.transform.GetComponent<NPC>().OnExitDialogue.Invoke);
                    movementEnabled = false;
                }
            }
        }
    }

    void FixedUpdate() {
        float dx = Input.GetAxisRaw("Horizontal") * movementSpeed;
        float dy = Input.GetAxisRaw("Vertical") * movementSpeed;

        if(dx > 0) {
            direction = "right";
        }else if(dx < 0) {
            direction = "left";
        }else if(dy > 0) {
            direction = "up";
        }else if(dy < 0) {
            direction = "down";
        }

        if(movementEnabled){
            rigi.velocity = new Vector3(dx, dy, 0);
        } else {
            rigi.velocity = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.transform.GetComponent<Door>() != null) {
            levelManager.hitDoor(col.gameObject, transform.gameObject);
        }
    }

    private bool movementEnabled = true;
}
