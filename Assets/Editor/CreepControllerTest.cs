using UnityEngine;
using UnityEngine.Events;

using NUnit.Framework;
using NSubstitute;

[TestFixture]
public class CreepControllerServerTest : UnityUnitTest {
    private TestableComponent<CreepController> sut;

    [SetUp]
    public void SetUp() {
        sut = new TestableComponent<CreepController>();
        //sut.component.Start();
    }

    [Test]
    public void ShouldAddDamageableComponent() {
        Assert.NotNull(sut.gameObject.GetComponent<Damageable>());
    }

    //[Test]
    //public void ShouldSpawnGameObjectWithAttachedController() {
    //    instance = sut.component.InstantiateControlled<SampleController>();
    //    Assert.NotNull(instance.GetComponent<SampleController>());
    //}

    //[Test]
    //public void ShouldHaveBaseInstanceName() {
    //    instance = sut.component.InstantiateControlled<SampleController>();
    //    Assert.AreEqual("Sample", instance.name);
    //}

    //[Test]
    //public void ShouldSetDefaultTransform() {
    //    instance = sut.component.InstantiateControlled<SampleController>();
    //    Assert.AreEqual(Vector3.zero, instance.transform.position);
    //    Assert.AreEqual(Quaternion.identity, instance.transform.rotation);
    //}

    //[Test]
    //public void ShouldUseSpecifiedTransform() {
    //    Vector3 pos = new Vector3(1f, 2f, 3f);
    //    Quaternion rot = Quaternion.Euler(10, 20, 30);
    //    instance = sut.component.InstantiateControlled<SampleController>(pos, rot);
    //    Assert.AreEqual(pos, instance.transform.position);
    //    Assert.AreEqual(rot, instance.transform.rotation);
    //}

    [TearDown]
    public void TearDown() {
        TestableComponent<CreepController>.CleanUp();
    }
}