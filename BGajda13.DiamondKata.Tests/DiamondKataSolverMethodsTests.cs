using BGajda13.DiamondKata.Solver;
using FluentAssertions;
using static BGajda13.DiamondKata.Solver.DiamondKata;

namespace BGajda13.DiamondKata.Tests;

public class DiamondKataSolverMethodsTests
{
    [Theory]
    [InlineData('A', 1)]
    [InlineData('N', 14)]
    [InlineData('Z', 26)]
    public void SolverCalculateNumberOfLevels_GivenInput_CorrectNumberOfLevels(char input, int expectedNumberOfLevels)
    {
        //Arrange
        
        //Act
        var result = CalculateNumberOfLevels(input);

        //Assert
        result.Should().Be(expectedNumberOfLevels);
    }
    
    [Theory]
    [InlineData('A', "A")]
    [InlineData('N', "ABCDEFGHIJKLMN")]
    [InlineData('Z', "ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
    public void SolverGenerateLevelsSequence_GivenInput_CorrectSequence(char input, string expectedSequence)
    {
        //Arrange
        
        //Act
        var result = string.Concat(GenerateLevelsSequence(input));

        //Assert
        result.Should().Be(expectedSequence);
    }
    
    [Theory]    
    [InlineData('A', 5, 0, "     A")]
    [InlineData('D', 0, 5, "D     D")]
    [InlineData('C', 3, 7, "   C       C")]
    public void SolverBuildLevel_GivenInput_CorrectLevel(char input, int leftPadding, int innerSpace, string expectedLevel)
    {
        //Arrange
        
        //Act
        var result = BuildLevel(input, leftPadding, innerSpace);

        //Assert
        result.Should().Be(expectedLevel);
    }
    
    [Fact]
    public void SolverMirrorVertically_GivenList_MirroredVertically()
    {
        //Arrange
        var inputList = new List<int> { 1, 2, 3 };
        var expectedResult = new List<int> { 1, 2, 3, 2, 1 };
        
        //Act
        inputList.MirrorVertically();
        
        //Assert
        inputList.Should().ContainInOrder(expectedResult);
    }
    
    [Fact]
    public void SolverMirrorVertically_OnlyOneItemInList_OneItem()
    {
        //Arrange
        var inputList = new List<int> { 1 };
        var expectedResult = new List<int> { 1 };
        
        //Act
        inputList.MirrorVertically();
        
        //Assert
        inputList.Should().ContainInOrder(expectedResult);
    }
}