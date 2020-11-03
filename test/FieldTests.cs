using System;
using System.Collections.Generic;
using System.Text;
using hb.Business;
using hb.Business.Types;
using Xunit;

namespace test
{
    public class FieldTests
    {
        [Fact]
        public void HandleMoves_ShouldArgumentNullException_WhenVehiclesIsNullOrEmpty()
        {
            var field = new Field(new Boundry(5, 5));
            var result = Record.Exception(() => field.HandleMoves());
            Assert.NotNull(result);
            var exception = Assert.IsType<ArgumentNullException>(result);
            var actual = exception.ParamName;
            const string expected = "Vehicles";
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void IsValid_ShouldAssertFalse_WhenAnyVehicleIsOutOfBoundry()
        {
            var field = new Field(new Boundry(5, 5));
            field.Vehicles.Add(new Vehicle(new Position(6, 6, Enums.Direction.E), new MoveSet("")));

            Assert.False(field.IsValid());
        }
    }
}
