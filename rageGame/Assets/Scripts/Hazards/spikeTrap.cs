using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeTrap : Trap
{
    [SerializeField] public GameObject spike;
    [SerializeField] private Transform loc;
    private Vector2 initialPosition;
    private bool on;

    private void Start() {
        initialPosition = spike.transform.position;
    }
    public void Update() {
        if (on) {
            spike.transform.position = Vector2.Lerp(spike.transform.position, loc.position, 15 * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            SpikeUp();
        }
    }
    /// <summary>
    /// Release the spike!
    /// </summary>
    public void SpikeUp() {
        on = true;
    }

    public override void ResetTrap() {
        on = false;
        spike.transform.position = initialPosition;
    }
}
