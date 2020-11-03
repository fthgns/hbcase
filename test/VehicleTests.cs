
using System;
using hb.Business;
using hb.Business.Types;
using Xunit;

namespace test
{
    public class VehicleTests
    {
        [Fact]
        public void Vehicle_ShouldArgumentNullException_WhenMovesIsNull()
        {
            var result = Record.Exception(()=> new Vehicle(new Position(1, 1, Enums.Direction.E), null));
        
            Assert.NotNull(result);
            var exception = Assert.IsType<ArgumentNullException>(result);
            var actual = exception.ParamName;
            const string expected = "moves";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Vehicle_ShouldArgumentNullException_WhenPositionIsNull()
        {
            var result = Record.Exception(() => new Vehicle(null, new MoveSet(string.Empty)));

            Assert.NotNull(result);
            var exception = Assert.IsType<ArgumentNullException>(result);
            var actual = exception.ParamName;
            const string expected = "pos";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void HandleMoves_ShouldArgumentNullException_WhenMovesIsNullOrEmpty()
        {
            var vehicle = new Vehicle(new Position(1, 1, Enums.Direction.E), new MoveSet(string.Empty));
            var result = Record.Exception(() => vehicle.HandleMoves());
            Assert.NotNull(result);
            var exception = Assert.IsType<ArgumentNullException>(result);
            var actual = exception.ParamName;
            const string expected = "moves";
            Assert.Equal(expected, actual);
        }
    }
}
