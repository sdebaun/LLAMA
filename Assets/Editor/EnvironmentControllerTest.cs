﻿using UnityEngine;
using UnityEngine.Events;

using NUnit.Framework;
using NSubstitute;

[TestFixture]
public class EnvironmentControllerTest : UnityUnitTest {
    private TestableComponent<EnvironmentController> sut;

    [SetUp]
    public void BuildSut() {
        sut = new TestableComponent<EnvironmentController>();

        sut.component.dayNightSounds = Substitute.For<INetworkToggle>();
        sut.component.worldLight = Substitute.For<IWorldLightController>();
    }

    [Test]
    public void NightShouldSetSounds() {
        sut.component.TransitionTo(EnvironmentState.Night);
        sut.component.dayNightSounds.Received<INetworkToggle>().Set(false);
    }

    [Test]
    public void NightShouldTriggerLight() {
        sut.component.TransitionTo(EnvironmentState.Night);
        sut.component.worldLight.Received<IWorldLightController>().RotateToMidnight(3f);
    }

    [TearDown]
    public void TearDown() {
        TestableComponent<EnvironmentController>.CleanUp();
    }
}