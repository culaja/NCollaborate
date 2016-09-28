using NSubstitute;
using NUnit.Framework;

namespace Samples.TypePlayer
{
    [TestFixture]
    public class PlayerTests
    {
        private readonly ITypeHolder _typeHolderStub = Substitute.For<ITypeHolder>();

        [Test]
        public void Constructor_ObjectCreated_StateSetToStopped()
        {
            // Act
            var sut = CreatePlayer();

            // Assert
            Assert.AreEqual(PlayerState.Stopped, sut.State);
        }

        [Test]
        public void Play_ReadyTypeInPlayer_StateIsPlaying()
        {
            // Arrange
            var typeStub = Substitute.For<IType>();
            typeStub.Play().Returns(true);
            _typeHolderStub.GetTypeInstance().Returns(typeStub);

            // Act
            var sut = CreatePlayer();
            sut.Play();

            // Assert
            Assert.AreEqual(PlayerState.Playing, sut.State);
        }

        [Test]
        public void Play_NonReadyTypeInPlayer_StateIsStopped()
        {
            // Arrange
            var typeStub = Substitute.For<IType>();
            typeStub.Play().Returns(false);
            _typeHolderStub.GetTypeInstance().Returns(typeStub);

            // Act
            var sut = CreatePlayer();
            sut.Play();

            // Assert
            Assert.AreEqual(PlayerState.Stopped, sut.State);
        }

        [Test]
        public void Play_NoTypeInPlayer_StateIsStopped()
        {
            // Arrange
            _typeHolderStub.GetTypeInstance().Returns(default(IType));

            // Act
            var sut = CreatePlayer();
            sut.Play();

            // Assert
            Assert.AreEqual(PlayerState.Stopped, sut.State);
        }

        [Test]
        public void Play_StateIsPlaying_TypeNotTriggeredToPlay()
        {
            // Arrange
            var typeMock = Substitute.For<IType>();
            _typeHolderStub.GetTypeInstance().Returns(typeMock);
            var sut = CreatePlayer();
            sut.State = PlayerState.Playing;

            // Act
            sut.Play();

            // Assert
            typeMock.DidNotReceive().Play();
        }

        [Test]
        public void Rewind_StateIsStoppedAndReadyTypeInPlayer_PlayerStateIsRewinding()
        {
            // Arrange
            var typeStub = Substitute.For<IType>();
            typeStub.Rewind().Returns(true);
            _typeHolderStub.GetTypeInstance().Returns(typeStub);

            // Act
            var sut = CreatePlayer();
            sut.Rewind();

            // Assert
            Assert.AreEqual(PlayerState.Rewinding, sut.State);
        }

        [Test]
        public void Rewind_StateIsStoppedAndTypeInPlayerCantBeRewined_PlayerStateIsStopped()
        {
            // Arrange
            var typeStub = Substitute.For<IType>();
            typeStub.Rewind().Returns(false);
            _typeHolderStub.GetTypeInstance().Returns(typeStub);

            // Act
            var sut = CreatePlayer();
            sut.Rewind();

            // Assert
            Assert.AreEqual(PlayerState.Stopped, sut.State);
        }

        [Test]
        public void Rewind_NoTypeInPlayer_PlayerStateIsStopped()
        {
            // Arrange
            _typeHolderStub.GetTypeInstance().Returns(default(IType));

            // Act
            var sut = CreatePlayer();
            sut.Rewind();

            // Assert
            Assert.AreEqual(PlayerState.Stopped, sut.State);
        }

        [Test]
        public void Rewind_TypeIsRewindig_TypeNotTriggeredToRewind()
        {
            // Arrange
            var typeMock = Substitute.For<IType>();
            _typeHolderStub.GetTypeInstance().Returns(typeMock);
            var sut = CreatePlayer();
            sut.State = PlayerState.Rewinding;

            // Act
            sut.Rewind();

            // Assert
            typeMock.DidNotReceive().Rewind();
        }

        [Test]
        public void Stop_StateIsPlaying_StateChangedToStop()
        {
            // Arrange
            var typeStub = Substitute.For<IType>();
            typeStub.Play().Returns(true);
            _typeHolderStub.GetTypeInstance().Returns(typeStub);
            var sut = CreatePlayer();
            sut.Play();

            // Act
            sut.Stop();

            // Assert
            Assert.AreEqual(PlayerState.Stopped, sut.State);
        }

        [Test]
        public void Stop_StateIsPlaying_TypeStopTriggered()
        {
            // Arrange
            var typeMock = Substitute.For<IType>();
            _typeHolderStub.GetTypeInstance().Returns(typeMock);
            var sut = CreatePlayer();
            sut.State = PlayerState.Playing;

            // Act
            sut.Stop();

            // Assert
            typeMock.Received(1).Stop();
        }

        [Test]
        public void Stop_TypeNotInThePlayer_StateIsStopped()
        {
            // Arrange
            _typeHolderStub.GetTypeInstance().Returns(default(IType));

            // Act
            var sut = CreatePlayer();
            sut.Stop();

            // Assert
            Assert.AreEqual(PlayerState.Stopped, sut.State);
        }

        [Test]
        public void Play_TypeIsRewinding_StateChangedToStop()
        {
            // Arrange
            var typeStub = Substitute.For<IType>();
            typeStub.Rewind().Returns(true);
            _typeHolderStub.GetTypeInstance().Returns(typeStub);
            var sut = CreatePlayer();
            sut.Rewind();

            // Act
            sut.Play();

            // Assert
            Assert.AreEqual(PlayerState.Stopped, sut.State);
        }

        [Test]
        public void Play_TypeIsRewinding_TypePlayNotTriggered()
        {
            // Arrange
            var typeMock = Substitute.For<IType>();
            _typeHolderStub.GetTypeInstance().Returns(typeMock);
            var sut = CreatePlayer();
            sut.State = PlayerState.Rewinding;

            // Act
            sut.Play();

            // Assert
            typeMock.DidNotReceive().Play();
        }

        [Test]
        public void Play_TypeIsRewinding_TypeStopCalled()
        {
            // Arrange
            var typeMock = Substitute.For<IType>();
            _typeHolderStub.GetTypeInstance().Returns(typeMock);
            var sut = CreatePlayer();
            sut.State = PlayerState.Rewinding;

            // Act
            sut.Play();

            // Assert
            typeMock.Received().Stop();
        }

        [Test]
        public void Rewind_TypeIsPlaying_StateChangedToStop()
        {
            // Arrange
            var typeStub = Substitute.For<IType>();
            typeStub.Play().Returns(true);
            _typeHolderStub.GetTypeInstance().Returns(typeStub);
            var sut = CreatePlayer();
            sut.Play();

            // Act
            sut.Rewind();

            // Assert
            Assert.AreEqual(PlayerState.Stopped, sut.State);
        }

        [Test]
        public void Rewind_TypeIsPlaying_TypeRewindNotTriggered()
        {
            // Arrange
            var typeMock = Substitute.For<IType>();
            _typeHolderStub.GetTypeInstance().Returns(typeMock);
            var sut = CreatePlayer();
            sut.State = PlayerState.Playing;

            // Act
            sut.Rewind();

            // Assert
            typeMock.DidNotReceive().Rewind();
        }

        [Test]
        public void Rewind_TypeIsPlaying_TypeStopCalled()
        {
            // Arrange
            var typeMock = Substitute.For<IType>();
            _typeHolderStub.GetTypeInstance().Returns(typeMock);
            var sut = CreatePlayer();
            sut.State = PlayerState.Playing;

            // Act
            sut.Rewind();

            // Assert
            typeMock.Received().Stop();
        }

        private Player CreatePlayer()
        {
            return new Player(_typeHolderStub);
        }
    }
}
