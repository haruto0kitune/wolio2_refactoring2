﻿using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    public Transform GroundCheck;
    public Transform CeilingCheck;
    private PlayerConfig PlayerConfig;
    private SpriteRenderer SpriteRenderer;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;

    [InspectorDisplay]
    public IntReactiveProperty Hp;

    public ReactiveProperty<bool> IsDead;
    public ReactiveProperty<bool> IsGrounded;
    public ReactiveProperty<bool> IsDashing;
    public ReactiveProperty<bool> IsRunning;
    public ReactiveProperty<bool> IsJumping;
    public ReactiveProperty<bool> IsCrouching;
    public ReactiveProperty<bool> IsCreeping;
    public ReactiveProperty<bool> IsTouchingWall;
    public ReactiveProperty<bool> IsClimbing;
    public ReactiveProperty<bool> IsClimbable;
    public ReactiveProperty<bool> IsStandingLightAttack;
    public ReactiveProperty<bool> IsStandingMiddleAttack;
    public ReactiveProperty<bool> IsStandingHighAttack;
    public ReactiveProperty<bool> IsCrouchingLightAttack;
    public ReactiveProperty<bool> IsCrouchingMiddleAttack;
    public ReactiveProperty<bool> IsCrouchingHighAttack;
    public ReactiveProperty<bool> IsJumpingLightAttack;
    public ReactiveProperty<bool> IsJumpingMiddleAttack;
    public ReactiveProperty<bool> IsJumpingHighAttack;
    public ReactiveProperty<bool> IsStandingGuard;
    public ReactiveProperty<bool> IsCrouchingGuard;
    public ReactiveProperty<bool> IsJumpingGuard;
    public ReactiveProperty<bool> IsStandingDamage;
    public ReactiveProperty<bool> IsCrouchingDamage;
    public ReactiveProperty<bool> IsJumpingDamage;
    public ReactiveProperty<bool> IsStandingHitBack; 
    public ReactiveProperty<bool> IsCrouchingHitBack; 
    public ReactiveProperty<bool> IsJumpingHitBack; 
    public ReactiveProperty<bool> IsStandingGuardBack; 
    public ReactiveProperty<bool> IsCrouchingGuardBack; 
    public ReactiveProperty<bool> IsJumpingGuardBack; 
    public ReactiveProperty<bool> FacingRight;

    void Awake()
    {
        GroundCheck = transform.Find("GroundCheck");
        CeilingCheck = transform.Find("CeilingCheck");
        PlayerConfig = GetComponent<PlayerConfig>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

        IsGrounded = this.ObserveEveryValueChanged(x => (bool)Physics2D.Linecast(GroundCheck.position, GroundCheck.position, PlayerConfig.WhatIsGround)).ToReactiveProperty();
        IsDead = Hp.Select(x => transform.position.y <= -5 || x <= 0).ToReactiveProperty();
        IsDashing = new ReactiveProperty<bool>(false);
        IsRunning = new ReactiveProperty<bool>(false);
        IsJumping = new ReactiveProperty<bool>(false);
        IsCrouching = new ReactiveProperty<bool>(false);
        IsCreeping = new ReactiveProperty<bool>(false);
        IsTouchingWall = new ReactiveProperty<bool>(false);
        IsClimbing = new ReactiveProperty<bool>(false);
        IsClimbable = new ReactiveProperty<bool>(false);
        IsStandingLightAttack = this.ObserveEveryValueChanged(x => Animator.GetBool("IsStandingLightAttack")).ToReactiveProperty();
        IsStandingMiddleAttack = this.ObserveEveryValueChanged(x => Animator.GetBool("IsStandingMiddleAttack")).ToReactiveProperty();
        IsStandingHighAttack = this.ObserveEveryValueChanged(x => Animator.GetBool("IsStandingHighAttack")).ToReactiveProperty();
        IsCrouchingLightAttack = this.ObserveEveryValueChanged(x => Animator.GetBool("IsCrouchingLightAttack")).ToReactiveProperty();
        IsCrouchingMiddleAttack = this.ObserveEveryValueChanged(x => Animator.GetBool("IsCrouchingMiddleAttack")).ToReactiveProperty();
        IsCrouchingHighAttack = this.ObserveEveryValueChanged(x => Animator.GetBool("IsCrouchingHighAttack")).ToReactiveProperty();
        IsJumpingLightAttack = this.ObserveEveryValueChanged(x => Animator.GetBool("IsJumpingLightAttack")).ToReactiveProperty();
        IsJumpingMiddleAttack = this.ObserveEveryValueChanged(x => Animator.GetBool("IsJumpingMiddleAttack")).ToReactiveProperty();
        IsJumpingHighAttack = this.ObserveEveryValueChanged(x => Animator.GetBool("IsJumpingHighAttack")).ToReactiveProperty();
        IsStandingGuard = this.ObserveEveryValueChanged(x => Animator.GetBool("IsStandingGuard")).ToReactiveProperty();
        IsCrouchingGuard = this.ObserveEveryValueChanged(x => Animator.GetBool("IsCrouchingGuard")).ToReactiveProperty();
        IsJumpingGuard = this.ObserveEveryValueChanged(x => Animator.GetBool("IsJumpingGuard")).ToReactiveProperty();
        IsStandingDamage = this.ObserveEveryValueChanged(x => Animator.GetBool("IsStandingDamage")).ToReactiveProperty();
        IsCrouchingDamage = this.ObserveEveryValueChanged(x => Animator.GetBool("IsCrouchingDamage")).ToReactiveProperty();
        IsJumpingDamage = this.ObserveEveryValueChanged(x => Animator.GetBool("IsJumpingDamage")).ToReactiveProperty();
        IsStandingHitBack = new ReactiveProperty<bool>(false);
        IsCrouchingHitBack = new ReactiveProperty<bool>(false);
        IsJumpingHitBack = new ReactiveProperty<bool>(false);
        IsStandingGuardBack = new ReactiveProperty<bool>(false);
        IsCrouchingGuardBack = new ReactiveProperty<bool>(false);
        IsJumpingGuardBack = new ReactiveProperty<bool>(false);
        FacingRight = SpriteRenderer.ObserveEveryValueChanged(x => x.flipX).ToReactiveProperty();
    }

    void Start()
    {
        // Fall velocity limit
        this.ObserveEveryValueChanged(x => Rigidbody2D.velocity.y)
            .Where(x => x <= -6)
            .Subscribe(_ => Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, PlayerConfig.FallVelocityLimit));
    }
}