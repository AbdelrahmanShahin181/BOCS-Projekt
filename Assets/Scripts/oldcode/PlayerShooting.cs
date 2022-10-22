using System.Collections;
using Unity.Netcode;
using UnityEngine;

public class PlayerShooting : NetworkBehaviour {
    [SerializeField] private GameObject _animator;
    [SerializeField] private Transform _spawner;

    private void Update() {
        if (!IsOwner) return;
            // Send off the request to be executed on all clients
        RequestFireServerRpc();

            // Fire locally immediately
        ExecuteShoot();
        StartCoroutine(ToggleLagIndicator());
        
    }

    [ServerRpc]
    private void RequestFireServerRpc() {
        FireClientRpc();
    }

    [ClientRpc]
    private void FireClientRpc() {
        if (!IsOwner) ExecuteShoot();
    }

    private void ExecuteShoot() {
        var animator = Instantiate(_animator, _spawner.position, Quaternion.identity);
        animator.transform.parent = _spawner;

    }

    private IEnumerator ToggleLagIndicator() {
        yield return new WaitForSeconds(0.1f);
        _animator.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _animator.SetActive(false);
    }


    
}