using UnityEngine;
using UnityEngine.Events;

using NUnit.Framework;
using NSubstitute;

// Test for Damageable class.
[TestFixture]
public class NightPhaseTest : UnityUnitTest {
    private TestableComponent<NightPhase> sut;
    private NightPhase.PathfindingScanDelegate mockScanner;
    private NightPhase.NextPhaseDelegate mockNextPhase;

    [SetUp]
    public void BuildSut() {
        sut = new TestableComponent<NightPhase>();
        sut.component.creepSpawnCountBase = 7;
        sut.component.creepSpawnPerDay = 3;
        sut.component.spawnDurationBase = 3f;
        sut.component.spawnDurationPerDay = 1f;

        sut.component.environ = Substitute.For<IEnvironmentController>();

        sut.component.game = Substitute.For<IGameController>();
        sut.component.game.turn = 1;

        sut.component.xenos = Substitute.For<IXenoController>();

        mockScanner = Substitute.For<NightPhase.PathfindingScanDelegate>();
        sut.component.pathfindingScan = mockScanner;

        mockNextPhase = Substitute.For<NightPhase.NextPhaseDelegate>();
        sut.component.goNextPhase = mockNextPhase;
    }

    // should have test to prove that it finds dependent components - but not until done right

    [Test]
    public void ShouldInitializeCreepCounts() {
        Assert.AreEqual(0, sut.component.spawnedCreeps);
        Assert.AreEqual(0, sut.component.unspawnedCreeps);
    }

    [Test]
    public void OnBeginShouldTriggerNightEnvironment() {
        sut.component.OnBegin();
        sut.component.environ.Received().TransitionTo(EnvironmentState.Night);
    }

    [Test]
    public void OnBeginShouldSetUnspawnedCreeps() {
        sut.component.OnBegin();
        Assert.AreEqual(10, sut.component.unspawnedCreeps);
    }

    [Test]
    public void OnBeginShouldTellXenosToSpawn() {
        sut.component.OnBegin();
        sut.component.xenos.Received().StartSpawning(10,4f);
    }

    [Test]
    public void OnBeginShouldRunPathfinderScan() {
        sut.component.OnBegin();
        mockScanner.Received<NightPhase.PathfindingScanDelegate>().Invoke();
    }

    [Test]
    public void ShouldTrackSpawns() {
        sut.component.OnBegin();
        Assert.AreEqual(10, sut.component.unspawnedCreeps);
        Assert.AreEqual(0, sut.component.spawnedCreeps);
        sut.component.CountSpawn();
        Assert.AreEqual(9, sut.component.unspawnedCreeps);
        Assert.AreEqual(1, sut.component.spawnedCreeps);
        sut.component.CountSpawn();
        Assert.AreEqual(8, sut.component.unspawnedCreeps);
        Assert.AreEqual(2, sut.component.spawnedCreeps);
    }

    [Test]
    public void ShouldTrackDeaths() {
        sut.component.OnBegin();
        sut.component.spawnedCreeps = 10;
        sut.component.unspawnedCreeps = 0;
        sut.component.CountDeath();
        Assert.AreEqual(0, sut.component.unspawnedCreeps);
        Assert.AreEqual(9, sut.component.spawnedCreeps);
    }

    [Test]
    public void ShouldEndPhaseOnLastDeath() {
        sut.component.spawnedCreeps = 1;
        sut.component.unspawnedCreeps = 0;
        sut.component.CountDeath();
        mockNextPhase.Received<NightPhase.NextPhaseDelegate>().Invoke();
    }
    //[Test]
    //public void ShouldUpdateCurrentHealthWhenDamaged() {
    //    Assert.AreEqual(100f, sut.component.currentHealth);
    //    sut.component.takeDamage(10f);
    //    Assert.AreEqual(90f, sut.component.currentHealth);
    //}

    //[Test]
    //public void ShouldAnnounceDamage() {
    //    UnityAction<float> listener = Substitute.For<UnityAction<float>>();

    //    sut.component.onHealthChange.AddListener(listener);
    //    sut.component.takeDamage(10f);
    //    listener.Received<UnityAction<float>>().Invoke(90f);
    //}

    //[Test]
    //public void ShouldAnnounceDeath() {
    //    UnityAction<GameObject> listener = Substitute.For<UnityAction<GameObject>>();

    //    sut.component.onDeath.AddListener(listener);
    //    sut.component.takeDamage(100f);
    //    listener.Received<UnityAction<GameObject>>().Invoke(sut.gameObject);
    //}

    //[Test]
    //public void ShouldAnnounceDeathOnlyOnce() {
    //    UnityAction<GameObject> listener = Substitute.For<UnityAction<GameObject>>();

    //    sut.component.onDeath.AddListener(listener);
    //    sut.component.takeDamage(100f);
    //    sut.component.takeDamage(100f);
    //    listener.Received<UnityAction<GameObject>>().Invoke(sut.gameObject);
    //}

    //[Test]
    //public void ShouldCallDestroyOnDeath() {
    //    sut.component.takeDamage(100f);
    //    mockDestroy.Received<DestroyDelegate>().Invoke(sut.gameObject);
    //}

    [TearDown]
    public void TearDown() {
        TestableComponent<NightPhase>.CleanUp();
    }
}