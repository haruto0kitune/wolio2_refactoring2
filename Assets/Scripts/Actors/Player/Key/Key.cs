﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UniRx;
using UniRx.Triggers;

public class Key : MonoBehaviour
{
    public ReactiveProperty<float> Horizontal;
    public ReactiveProperty<float> Vertical;

    public bool A;
    public bool S;
    public bool D;
    public bool Z;
    public bool X;
    public bool C;
    public bool LeftShift;

    public bool Space;

    private void Awake()
    {
        Horizontal = new ReactiveProperty<float>();
        Vertical = new ReactiveProperty<float>();
    }

    private void Start()
    {
        UpdateAsObservables();
    }

    private void UpdateAsObservables()
    {
        this.UpdateAsObservable()
            .Subscribe(_ => Horizontal.Value = CrossPlatformInputManager.GetAxisRaw("Horizontal"));

        this.UpdateAsObservable()
            .Subscribe(_ => Vertical.Value = CrossPlatformInputManager.GetAxisRaw("Vertical"));

        this.UpdateAsObservable()
            .Subscribe(_ => A = CrossPlatformInputManager.GetButtonDown("A"));

        this.UpdateAsObservable()
            .Subscribe(_ => S = CrossPlatformInputManager.GetButtonDown("S"));

        this.UpdateAsObservable()
            .Subscribe(_ => D = CrossPlatformInputManager.GetButtonDown("D"));

        this.UpdateAsObservable()
            .Subscribe(_ => Z = CrossPlatformInputManager.GetButtonDown("Z"));

        this.UpdateAsObservable()
            .Subscribe(_ => X = CrossPlatformInputManager.GetButtonDown("X"));

        this.UpdateAsObservable()
            .Subscribe(_ => C = CrossPlatformInputManager.GetButtonDown("C"));

        this.UpdateAsObservable()
            .Subscribe(_ => LeftShift = CrossPlatformInputManager.GetButton("LeftShift"));

        this.UpdateAsObservable()
            .Subscribe(_ => Space = CrossPlatformInputManager.GetButton("Space"));
    }
}