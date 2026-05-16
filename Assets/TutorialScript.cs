using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class TutorialScript : MonoBehaviour
{
    // Start is called before the first frame update
    public State currentState;
    public enum State
    {
        Movement,
        Dash,
        Spear,
        Harpoon,
        GL,
        Inactive
    }
    public GameObject panel;
    public TextMeshProUGUI text;
    public float timer;
    void Start()
    {
        currentState = State.Movement;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.Movement:
                panel.SetActive(true);
                text.text = "Press WASD to move";
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                {
                    currentState = State.Dash;
                }
                break;
            case State.Dash:
                
                text.text = "Press Left Shift to dash. \nDashing consumes stamina. \nIf you run out, you get tired and can't move";
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    currentState = State.Spear;
                }
                break;
            case State.Spear:
                
                text.text = "Left click to attack with a spear. \nAttacking consumes stamina.";
                if (Input.GetMouseButton(0))
                {
                    currentState = State.Harpoon;
                }
                break;
            case State.Harpoon:
                
                text.text = "Right click to attack far away with a harpoon. \nIt consumes more stamina than the spear.";
                if (Input.GetMouseButton(1))
                {
                    currentState = State.GL;
                }
                break;
            case State.GL:
                text.text = "Good luck!";
                timer += Time.deltaTime;
                if (timer > 3f)
                {
                    panel.SetActive(false);
                    currentState = State.Inactive;
                }
                break;
            case State.Inactive:
                
                break;
                
        }
    }

    public IEnumerator WaitMove(float time)
    {
        yield return new WaitForSeconds(time);
        panel.SetActive(false);
    }
}
