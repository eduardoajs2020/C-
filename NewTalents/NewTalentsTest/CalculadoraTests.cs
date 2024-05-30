using NewTalents.Services;

namespace NewTalentsTest;


public class CalculadoraTests
{
    private readonly Calculadora _calc;
    

    public CalculadoraTests()
    {
        _calc = new Calculadora();
       
    }



    [Theory]
    [InlineData(5, 10, 15)]
    [InlineData(10, 10, 20)]
    [InlineData(2, 8, 10)]
    [InlineData(6, 7, 13)]
    public void TesteSomar(int num1, int num2, int resultado)
    {

        //Arrange

        //Act
        int resultadoCalculadora = _calc.Somar(num1, num2);

        //Assert
        Assert.Equal(resultado, resultadoCalculadora);
    }      

    [Theory]
    [InlineData(5, 10, -5)]
    [InlineData(10, 10, 0)]
    [InlineData(2, 8, -6)]
    [InlineData(6, 7, -1)]

    public void TesteSubtrair(int num1, int num2, int resultado)
    {
        
        //Arrange
        //Act
        int resultadoCalculadora = _calc.Subtrair(num1, num2);

        //Assert
        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(5, 10, 50)]
    [InlineData(10, 10, 100)]
    [InlineData(2, 8, 16)]
    [InlineData(6, 7, 42)]

    public void TesteMultiplicar(int num1, int num2, int resultado)
    {
        
        //Arrange
        //Act
        int resultadoCalculadora = _calc.Multiplicar(num1, num2);

        //Assert
        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(10, 5, 2)]
    [InlineData(10, 10, 1)]
    [InlineData(8, 2, 4)]
    [InlineData(17, 6, 2)]
    public void TesteDividir(int num1, int num2, int resultado)
    {
        
        //Arrange
        //Act
        int resultadoCalculadora = _calc.Dividir(num1, num2);

        //Assert
        Assert.Equal(resultado, resultadoCalculadora);
    }
    [Fact]
    public void TestarDivisaoPorZero()
    {
        Assert.Throws<DivideByZeroException>
        (() => _calc.Dividir(3, 0));
    }

    [Fact]
    public void TestarHistorico()
    {
    
        _calc.Somar(1, 2);
        _calc.Somar(2, 8);
        _calc.Somar(3, 7);
        _calc.Somar(4, 1);

        var lista = _calc.historico();

        Assert.NotEmpty(lista);
        Assert.Equal(3, lista.Count);
       

        
    }

}