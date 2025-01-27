using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerMovement;

public class PlayerAnimationsController : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Ref to Canvas PauseMenu")]
    [SerializeField] private PauseMenu _pauseMenu;
    private Animator _animator;
    private PlayerMovement _playerMovement;

    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        AnimationController();
    }

    private void AnimationController()
    {
        if(_playerMovement.state == MovementState.idle)
        {
            _animator.SetFloat("Speed", 0, 0.05f, Time.deltaTime);
        }
        else if(_playerMovement.state == MovementState.walking)
        {
            _animator.SetFloat("Speed", 0.5f, 0.05f, Time.deltaTime);
        }
        else if (_playerMovement.state == MovementState.running)
        {
            _animator.SetFloat("Speed", 1f, 0.05f, Time.deltaTime);

            if(_playerMovement._vInput > 0)
            {
                _animator.SetFloat("RunningDirection", 0, 0.05f, Time.deltaTime);
            }

            if (_playerMovement._vInput < 0)
            {
                _animator.SetFloat("RunningDirection", 1f, 0.05f, Time.deltaTime);
            }

            _animator.SetFloat("RunningDirection", 0, 0.05f, Time.deltaTime);
        }

        if(_playerMovement.state == MovementState.sliding)
        {
            _animator.SetBool("isSliding", true);
        }
        else if(_playerMovement.state == MovementState.sliding && _playerMovement.SlopeCheck())
        {
            _animator.SetBool("isOnSlope", true);
        }
        else
        {
            _animator.SetBool("isSliding", false);
            _animator.SetBool("isOnSlope", false);
        }

        if(_playerMovement.state == MovementState.jump)
        {
            _animator.SetBool("isJumping", true);
        }
        else
        {
            _animator.SetBool("isJumping", false);
        }

        if (_playerMovement.state == MovementState.air)
        {
            _animator.SetBool("isFalling", true);
        }
        else
        {
            _animator.SetBool("isFalling", false);
        }

        if(_playerMovement.state == MovementState.onWall)
        {
            _animator.SetBool("isOnWall", true);
        }
        else
        {
            _animator.SetBool("isOnWall", false);
        }

        /*if (_pauseMenu.EnablePauseMenu())
        {
            _animator.SetBool("PauseMenu", true);
        }*/
    }
}
