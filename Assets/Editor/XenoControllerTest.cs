using UnityEngine;
using UnityEngine.Events;

using NUnit.Framework;
using NSubstitute;

[TestFixture]
public class XenoControllerTest : UnityUnitTest {
    private TestableComponent<XenoController> sut;

    [SetUp]
    public void BuildSut() {
        sut = new TestableComponent<XenoController>();
        //sut.component.getComponent = Substitute.For<ChildComponentFinderDelegate>();

        //sut.component.dayNightSounds = Substitute.For<INetworkToggle>();
        //sut.component.worldLight = Substitute.For<IWorldLightController>();
    }

    //[Test]
    //public void StartShouldConnectChildren() {
    //    sut.component.Start();

    //    sut.component.getComponent.Received<ChildComponentFinderDelegate>().Invoke(typeof(NetworkToggle));
    //    sut.component.getComponent.Received<ChildComponentFinderDelegate>().Invoke(typeof(WorldLightController));
    //}

    //[Test]
    //public void NightShouldSetSounds() {
    //    sut.component.TransitionTo(EnvironmentState.Night);
    //    sut.component.dayNightSounds.Received<INetworkToggle>().Set(false);
    //}

    //[Test]
    //public void NightShouldTriggerLight() {
    //    sut.component.TransitionTo(EnvironmentState.Night);
    //    sut.component.worldLight.Received<IWorldLightController>().RotateToMidnight(3f);
    //}

    [TearDown]
    public void TearDown() {
        TestableComponent<XenoController>.CleanUp();
    }
}