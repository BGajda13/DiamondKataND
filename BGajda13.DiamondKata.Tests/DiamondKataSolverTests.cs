using FluentAssertions;

namespace BGajda13.DiamondKata.Tests;

public class DiamondKataSolverTests
{
    [Theory]
    [InlineData('a')]
    [InlineData('§')]
    [InlineData('@')]
    [InlineData('c')]
    [InlineData('!')]
    public void Solver_IncorrectChar_ShouldThrow(char input)
    {
        //Arrange
        
        //Act
        Action act = () => Solver.DiamondKata.Solve(input);
        
        //Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }
    
    [Theory]
    [InlineData('A')]
    [InlineData('B')]
    [InlineData('F')]
    [InlineData('G')]
    [InlineData('X')]
    public void Solver_CorrectChar_ShouldHaveProperLinesCount(char input)
    {
        //Arrange
        var result = "";
        
        //Act
        Action act = () => result = Solver.DiamondKata.Solve(input);

        //Assert
        act.Should().NotThrow();
        result.Should().Contain(Environment.NewLine, Exactly.Times((input - 65) * 2));
    }

    [Fact]
    public void Solver_InputA_ShouldPrintA()
    {
        //Arrange
        var result = "";
           
        //Act
        Action act = () => result = Solver.DiamondKata.Solve('A');

        //Assert
        act.Should().NotThrow();
        result.Should().Be("A");
    }
    
    [Fact]
    public void Solver_InputB_ShouldPrintDiamond()
    {
        //Arrange
        var expected = 
         @" A
B B
 A";
        var result = "";
           
        //Act
        Action act = () => result = Solver.DiamondKata.Solve('B');

        //Assert
        act.Should().NotThrow();
        result.Should().Be(expected);
    }
    
    [Fact]
    public void Solver_InputJ_ShouldPrintDiamond()
    {
        //Arrange
        var expected =
@"         A
        B B
       C   C
      D     D
     E       E
    F         F
   G           G
  H             H
 I               I
J                 J
 I               I
  H             H
   G           G
    F         F
     E       E
      D     D
       C   C
        B B
         A";
        
        var result = "";
           
        //Act
        Action act = () => result = Solver.DiamondKata.Solve('J');

        //Assert
        act.Should().NotThrow();
        result.Should().Be(expected);
    }
    
    [Fact]
    public void Solver_InputX_ShouldPrintDiamond()
    {
        //Assert
        var expected =
@"                       A
                      B B
                     C   C
                    D     D
                   E       E
                  F         F
                 G           G
                H             H
               I               I
              J                 J
             K                   K
            L                     L
           M                       M
          N                         N
         O                           O
        P                             P
       Q                               Q
      R                                 R
     S                                   S
    T                                     T
   U                                       U
  V                                         V
 W                                           W
X                                             X
 W                                           W
  V                                         V
   U                                       U
    T                                     T
     S                                   S
      R                                 R
       Q                               Q
        P                             P
         O                           O
          N                         N
           M                       M
            L                     L
             K                   K
              J                 J
               I               I
                H             H
                 G           G
                  F         F
                   E       E
                    D     D
                     C   C
                      B B
                       A";
        
        var result = "";
           
        //Act
        Action act = () => result = Solver.DiamondKata.Solve('X');

        //Assert
        act.Should().NotThrow();
        result.Should().Be(expected);
    }
}