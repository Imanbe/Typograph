using NUnit.Framework;
using System.Text;
using Typograph;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        // 1
        
        [Test]
        public void CheckSpaces1()
        {
            // arrange
            string str = "Hello    World!";
            string expected = "Hello World!";

            // act
            Parser.Check2Spaces(ref str);

            // assert
            Assert.That(str, Is.EqualTo(expected));
        }

        // 2
        
        [Test]
        public void CheckSpaces2()
        {
            // arrange
            string str = "Hello  1  World!";
            string expected = "Hello 1 World!";

            // act
            Parser.Check2Spaces(ref str);

            // assert
            Assert.That(str, Is.EqualTo(expected));
        }

        // 3
        
        [Test]
        public void CheckPlsMns1()
        {
            // arrange
            string str = "It's nearly +-2 points";
            string expected = "It's nearly ±2 points";

            // act
            Parser.CheckPlsMns(ref str);

            // assert
            Assert.That(str, Is.EqualTo(expected));
        }

        // 4

        [Test]
        public void CheckPlsMns2()
        {
            // arrange
            string str = "It's nearly (+,-)2 points";
            string expected = "It's nearly ±2 points";

            // act
            Parser.CheckPlsMns(ref str);

            // assert
            Assert.That(str, Is.EqualTo(expected));
        }

        // 5
        
        [Test]
        public void CheckPlsMns3()
        {
            // arrange
            string str = "It's nearly +,-2 points";
            string expected = "It's nearly ±2 points";

            // act
            Parser.CheckPlsMns(ref str);

            // assert
            Assert.That(str, Is.EqualTo(expected));
        }

        // 6
        
        [Test]
        public void Check3Dots()
        {
            // arrange
            string str = "I love snacks...";
            string expected = "I love snacks…";

            // act
            Parser.Check3Dots(ref str);

            // assert
            Assert.That(str, Is.EqualTo(expected));
        }

        // 7
        [Test]
        public void CheckDashAndSpace()
        {
            // arrange
            string str = "Ilnaz - friend";
            StringBuilder expected = new StringBuilder("Ilnaz - friend");
            expected[5] = (char)160;


            // act
            Parser.CheckDashAndSpace(ref str);

            // assert
            Assert.That(str, Is.EqualTo(expected.ToString()));
        }

        // 8

        [Test]
        public void CheckCoopyright1()
        {
            // arrange
            string str = "(c) Copyright by Imnabe";  // àíãëèéñêàÿ ðàñêëàäêà
            string expected = "© Copyright by Imnabe";

            // act
            Parser.CheckCoopyright(ref str);

            // assert
            Assert.That(str, Is.EqualTo(expected));
        }

        // 9

        [Test]
        public void CheckCoopyright2()
        {
            // arrange
            string str = "(ñ) Copyright by Imnabe";  // ðóññêàÿ ðàñêëàäêà
            string expected = "© Copyright by Imnabe";

            // act
            Parser.CheckCoopyright(ref str);

            // assert
            Assert.That(str, Is.EqualTo(expected));
        }

        // 10

        [Test]
        public void CheckUpperLower1()
        {
            // arrange
            string str = "Hello World!";
            string expected = "hELLO wORLD!";

            // act
            Parser.CheckUpperLower(ref str);

            // assert
            Assert.That(str, Is.EqualTo(expected));
        }

        // 11

        [Test]
        public void CheckUpperLower2()
        {
            // arrange
            string str = "HELLO MY FRIENDS";
            string expected = "hello my friends";

            // act
            Parser.CheckUpperLower(ref str);

            // assert
            Assert.That(str, Is.EqualTo(expected));
        }

        // 11

        [Test]
        public void Test1()
        {
            // arrange
            string str = "(c) Coopyright by John Sina...";
            string expected = "© cOOPYRIGHT BY jOHN sINA…";

            // act
            Parser.Pasring(ref str);

            // assert
            Assert.That(str, Is.EqualTo(expected));
        }

        // 12

        [Test]
        public void Test2()
        {
            // arrange
            string str = "(+,-) 3 Ilnaz must to have...";
            string expected = "± 3 iLNAZ MUST TO HAVE…";

            // act
            Parser.Pasring(ref str);

            // assert
            Assert.That(str, Is.EqualTo(expected));
        }

        // 13

        [Test]
        public void Test3()
        {
            // arrange
            string str = "(+,-) 3 Ilnaz must to have...";
            string expected = "± 3 iLNAZ MUST TO HAVE…";

            // act
            Parser.Pasring(ref str);

            // assert
            Assert.That(str, Is.EqualTo(expected));
        }

        // 14

        [Test]
        public void Test4()
        {
            // arrange
            string str = "...Okay, I'll give you +,-3 seconds to do this!";
            string expected = "…oKAY, i'LL GIVE YOU ±3 SECONDS TO DO THIS!";

            // act
            Parser.Pasring(ref str);

            // assert
            Assert.That(str, Is.EqualTo(expected));
        }

        // 15

        [Test]
        public void Test5()
        {
            // arrange
            string str = "Ilnaz - Who is this? This is my CAR!!!! ... Okay...";
            StringBuilder expected = new StringBuilder("iLNAZ - wHO IS THIS? tHIS IS MY car!!!! … oKAY…");
            expected[5] = (char)160;

            // act
            Parser.Pasring(ref str);

            // assert
            Assert.That(str, Is.EqualTo(expected.ToString()));
        }
    }
}