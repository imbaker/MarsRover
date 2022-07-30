namespace MarsRover.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Plateau_ShouldInit_WhenValidDimensionsPassed()
        {
            // Arrange
            var x = 10;
            var y = 20;

            // Act
            var sut = new Plateau(x, y);

            // Assert
            Assert.That(sut.x, Is.EqualTo(x));
            Assert.That(sut.y, Is.EqualTo(y));
        }

        [Test]
        public void Plateau_ShouldUpdateCurrentPos_WhenPositionSet()
        {
            // Arrange
            var plateau = new Plateau(10, 20);

            // Act
            plateau.SetPosition(1, 3);

            // Assert
            Assert.That(plateau.GetPosition().x, Is.EqualTo(1));
            Assert.That(plateau.GetPosition().y, Is.EqualTo(3));
        }

        [Test]
        public void Plateau_ShouldIncrementY_WhenMoveNorthCalled()
        {
            // Arrange
            var plateau = new Plateau(10, 20);
            plateau.SetPosition(1, 3);

            // Act
            plateau.MoveNorth();

            // Assert
            Assert.That(plateau.GetPosition().x, Is.EqualTo(1));
            Assert.That(plateau.GetPosition().y, Is.EqualTo(4));
        }

        [Test]
        public void Plateau_ShouldIncrementX_WhenMoveEastCalled()
        {
            // Arrange
            var plateau = new Plateau(10, 20);
            plateau.SetPosition(1, 3);

            // Act
            plateau.MoveEast();

            // Assert
            Assert.That(plateau.GetPosition().x, Is.EqualTo(2));
            Assert.That(plateau.GetPosition().y, Is.EqualTo(3));
        }

        [Test]
        public void Plateau_ShouldDecrementY_WhenMoveSouthCalled()
        {
            // Arrange
            var plateau = new Plateau(10, 20);
            plateau.SetPosition(1, 3);

            // Act
            plateau.MoveSouth();

            // Assert
            Assert.That(plateau.GetPosition().x, Is.EqualTo(1));
            Assert.That(plateau.GetPosition().y, Is.EqualTo(2));
        }

        [Test]
        public void Plateau_ShouldDecrementX_WhenMoveWestCalled()
        {
            // Arrange
            var plateau = new Plateau(10, 20);
            plateau.SetPosition(1, 3);

            // Act
            plateau.MoveWest();

            // Assert
            Assert.That(plateau.GetPosition().x, Is.EqualTo(0));
            Assert.That(plateau.GetPosition().y, Is.EqualTo(3));
        }

        [Test]
        public void Plateau_ShouldNotBeAbleToMoveOffThePlateau_WhenMoveNorthCalled()
        {
            // Arrange
            var plateau = new Plateau(10, 20);
            plateau.SetPosition(10, 20);

            // Act
            plateau.MoveNorth();

            // Assert
            Assert.That(plateau.GetPosition().x, Is.EqualTo(10));
            Assert.That(plateau.GetPosition().y, Is.EqualTo(20));
        }

        [Test]
        public void Plateau_ShouldNotBeAbleToMoveOffThePlateau_WhenMoveEastCalled()
        {
            // Arrange
            var plateau = new Plateau(10, 20);
            plateau.SetPosition(10, 20);

            // Act
            plateau.MoveEast();

            // Assert
            Assert.That(plateau.GetPosition().x, Is.EqualTo(10));
            Assert.That(plateau.GetPosition().y, Is.EqualTo(20));
        }

        [Test]
        public void Plateau_ShouldNotBeAbleToMoveOffThePlateau_WhenMoveSouthCalled()
        {
            // Arrange
            var plateau = new Plateau(10, 20);
            plateau.SetPosition(0, 0);

            // Act
            plateau.MoveSouth();

            // Assert
            Assert.That(plateau.GetPosition().x, Is.EqualTo(0));
            Assert.That(plateau.GetPosition().y, Is.EqualTo(0));
        }

        [Test]
        public void Plateau_ShouldNotBeAbleToMoveOffThePlateau_WhenMoveWestCalled()
        {
            // Arrange
            var plateau = new Plateau(10, 20);
            plateau.SetPosition(0, 0);

            // Act
            plateau.MoveWest();

            // Assert
            Assert.That(plateau.GetPosition().x, Is.EqualTo(0));
            Assert.That(plateau.GetPosition().y, Is.EqualTo(0));
        }

        [Test]
        [TestCase(Plateau.Orientation.North, ExpectedResult = Plateau.Orientation.North)]
        [TestCase(Plateau.Orientation.East, ExpectedResult = Plateau.Orientation.East)]
        [TestCase(Plateau.Orientation.South, ExpectedResult = Plateau.Orientation.South)]
        [TestCase(Plateau.Orientation.West, ExpectedResult = Plateau.Orientation.West)]
        public Plateau.Orientation Plateau_ShouldUpdateCurrentDirection_WhenDirectionSet(Plateau.Orientation orientation)
        {
            // Arrange
            var plateau = new Plateau(10, 20);
            plateau.SetPosition(0, 0);

            // Act
            plateau.SetDirection(orientation);

            // Assert
            return plateau.GetDirection();
        }

        [Test]
        [TestCase(1, 3, Plateau.Orientation.North, 1, 4)]
        [TestCase(1, 3, Plateau.Orientation.East, 2, 3)]
        [TestCase(1, 3, Plateau.Orientation.South, 1, 2)]
        [TestCase(1, 3, Plateau.Orientation.West, 0, 3)]
        public void Plateau_ShouldMoveInTheRightDirection_WhenDirectionSet(int startX, int startY, Plateau.Orientation orientation, int expectedX, int expectedY)
        {
            // Arrange
            var plateau = new Plateau(10, 20);
            plateau.SetPosition(startX, startY);
            plateau.SetDirection(orientation);

            // Act
            plateau.Move();

            // Assert
            Assert.That(plateau.GetPosition().x, Is.EqualTo(expectedX));
            Assert.That(plateau.GetPosition().y, Is.EqualTo(expectedY));
        }

        [Test]
        [TestCase(Plateau.Orientation.North, ExpectedResult = Plateau.Orientation.East)]
        [TestCase(Plateau.Orientation.East, ExpectedResult = Plateau.Orientation.South)]
        [TestCase(Plateau.Orientation.South, ExpectedResult = Plateau.Orientation.West)]
        [TestCase(Plateau.Orientation.West, ExpectedResult = Plateau.Orientation.North)]
        public Plateau.Orientation Plateau_ShouldIncrementOrientation_WhenRight(Plateau.Orientation orientation)
        {
            // Arrange
            var plateau = new Plateau(10, 20);
            plateau.SetPosition(1, 3);
            plateau.SetDirection(orientation);

            // Act
            plateau.Right();

            return plateau.GetDirection();
        }

        [Test]
        [TestCase(Plateau.Orientation.North, ExpectedResult = Plateau.Orientation.West)]
        [TestCase(Plateau.Orientation.East, ExpectedResult = Plateau.Orientation.North)]
        [TestCase(Plateau.Orientation.South, ExpectedResult = Plateau.Orientation.East)]
        [TestCase(Plateau.Orientation.West, ExpectedResult = Plateau.Orientation.South)]
        public Plateau.Orientation Plateau_ShouldDecrementOrientation_WhenRight(Plateau.Orientation orientation)
        {
            // Arrange
            var plateau = new Plateau(10, 20);
            plateau.SetPosition(1, 3);
            plateau.SetDirection(orientation);

            // Act
            plateau.Left();

            return plateau.GetDirection();
        }
    }
}