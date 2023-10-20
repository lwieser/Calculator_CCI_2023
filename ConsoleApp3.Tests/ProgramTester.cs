using System.Text;
using Moq;

namespace ConsoleApp3.Tests;

[TestClass]
public class ProgramTester
{
    private Mock<IReader> _readerMock;
    private ProgramRunner _prg;

    public ProgramTester()
    {
        _readerMock = new Mock<IReader>();
        _prg = new ProgramRunner(_readerMock.Object);
    }     

    [TestMethod]
    public void RunWriteSomethind()
    {
        _readerMock.Setup(x => x.Read()).Returns("stop");
        _prg.Run();
        _readerMock.Verify(x => x.Write(""));
    }

    [TestMethod]
    public void RunStopsOnStop()
    {
        _readerMock.Setup(x => x.Read()).Returns("stop");
        _prg.Run();
        _readerMock.Verify(x => x.Write("Le résultat est 0"));
    }
}