﻿using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;

[RequireComponent(typeof(Key))]
[RequireComponent(typeof(PlayerState))]
[RequireComponent(typeof(PlayerConfig))]
[RequireComponent(typeof(PlayerMotion))]
public partial class PlayerPresenter : MonoBehaviour
{
    PlayerState PlayerState;
    PlayerConfig PlayerConfig;
    PlayerMotion PlayerMotion;
    Key Key;
    Rigidbody2D Rigidbody2D;
    SpriteRenderer SpriteRenderer;

    void Awake()
    {
        PlayerState = GetComponent<PlayerState>();
        PlayerConfig = GetComponent<PlayerConfig>();
        PlayerMotion = GetComponent<PlayerMotion>();
        Key = GetComponent<Key>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Basics();
        Guards();
        KnockBacks();
    }

    void Basics()
    {
        TurnPresenter();
        RunPresenter();
        JumpPresenter();
        ClimbPresenter();
        DamagePresenter();
        CrouchPresenter();
        CreepPresenter();
    }

    void Guards()
    {
        StandingGuardPresenter();
    }

    void KnockBacks()
    {
        StandingGuardBackPresenter();
    }
}