using UnityEngine;
using UnityEngine.Events;

using NUnit.Framework;
using NSubstitute;

public class SampleController : ControllerBehaviour {
    new public static string baseInstanceName = "Sample";
}

[TestFixture]
public class BaseBehaviourTest : UnityUnitTest {
    private TestableComponent<BaseBehaviour> sut;
    private GameObject instance;

    [SetUp]
    public void SetUp() {
        sut = new TestableComponent<BaseBehaviour>();
    }

    [Test]
    public void ShouldSpawnGameObject() {
        instance = sut.component.InstantiateControlled<SampleController>();
        Assert.NotNull(instance);
    }

    [Test]
    public void ShouldSpawnGameObjectWithAttachedController() {
        instance = sut.component.InstantiateControlled<SampleController>();
        Assert.NotNull(instance.GetComponent<SampleController>());
    }

    [Test]
    public void ShouldHaveBaseInstanceName() {
        instance = sut.component.InstantiateControlled<SampleController>();
        Assert.AreEqual("Sample", instance.name);
    }

    [Test]
    public void ShouldSetDefaultTransform() {
        instance = sut.component.InstantiateControlled<SampleController>();
        Assert.AreEqual(Vector3.zero, instance.transform.position);
        Assert.AreEqual(Quaternion.identity, instance.transform.rotation);
    }

    [Test]
    public void ShouldUseSpecifiedTransform() {
        Vector3 pos = new Vector3(1f, 2f, 3f);
		Quaternion rot = Quaternion.Euler(10, 20, 30);
        instance = sut.component.InstantiateControlled<SampleController>(pos,rot);
        Assert.AreEqual(pos, instance.transform.position);
        Assert.AreEqual(rot, instance.transform.rotation);
    }

    [TearDown]
    public void TearDown() {
        TestableComponent<BaseBehaviour>.CleanUp();
        GameObject.DestroyImmediate(instance);
    }
}