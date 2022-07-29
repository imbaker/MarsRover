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
        [TestCase("N", ExpectedResult = "N")]
        [TestCase("E", ExpectedResult = "E")]
        [TestCase("S", ExpectedResult = "S")]
        [TestCase("W", ExpectedResult = "W")]
        public string Plateau_ShouldUpdateCurrentDirection_WhenDirectionSet(string orientation)
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
        [TestCase(1, 3, "N", 1, 4)]
        [TestCase(1, 3, "E", 2, 3)]
        [TestCase(1, 3, "S", 1, 2)]
        [TestCase(1, 3, "W", 0, 3)]
        public void Plateau_ShouldMoveInTheRightDirection_WhenDirectionSet(int startX, int startY, string orientation, int expectedX, int expectedY)
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
        [TestCase("N", ExpectedResult = "E")]
        [TestCase("E", ExpectedResult = "S")]
        [TestCase("S", ExpectedResult = "W")]
        [TestCase("W", ExpectedResult = "N")]
        public string Plateau_ShouldIncrementOrientation_WhenRight(string orientation)
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
        [TestCase("N", ExpectedResult = "W")]
        [TestCase("E", ExpectedResult = "N")]
        [TestCase("S", ExpectedResult = "E")]
        [TestCase("W", ExpectedResult = "S")]
        public string Plateau_ShouldDecrementOrientation_WhenRight(string orientation)
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