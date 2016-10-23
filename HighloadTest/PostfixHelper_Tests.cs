//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using HighloadTest.Tools;
//using NUnit.Framework;

//namespace HighloadTest
//{
//    public class PostfixHelper_Tests
//    {
//        [TestCase(9, 1)]
//        [TestCase(99, 2)]
//        [TestCase(100, 3)]
//        [TestCase(999, 3)]
//        [TestCase(1000, 4)]
//        public void GetDigitsCount_Called_ReturnsDigitCount(int count, int expected)
//        {
//            int actual = PostfixHelper.GetDigitsCount(count);

//            Assert.AreEqual(expected, actual);
//        }

//        [Test]
//        public void CreatePostfixes_Called_CreatesRequestedCount()
//        {
//            int expected = 100;

//            var postfixes = PostfixHelper.CreatePostfixes(expected);

//            Assert.AreEqual(expected, postfixes.Count);
//        }

//        [Test]
//        public void CreatePostfixes_Called_CreatesPostfixesOfEqualLength()
//        {
//            int expected = 100;

//            var postfixes = PostfixHelper.CreatePostfixes(expected);

//            Assert.IsTrue(postfixes.Any(p => p.Length == 3));
//        }
//    }
//}
