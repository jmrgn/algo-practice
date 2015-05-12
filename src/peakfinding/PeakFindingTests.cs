using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PeakFinding.Test
{
    /// <summary>
    /// Cheating a bit by putting a test harness in the same project to reduce project bloat
    /// </summary>
    [TestFixture]
    public class PeakFindingTests
    {

        [TestCase(0, true, 1)]
        [TestCase(0, false, 1, 2)]
        [TestCase(1, true, 1, 2)]
        [TestCase(0, true, 2, 1)]
        [TestCase(1, false, 2, 1)]
        [TestCase(1, false, 1, 2, 3)]
        [TestCase(1, true, 1, 4, 3)]
        public void ItShouldCheckForPeak(int targetIdx, bool isPeak, params int[] cases)
        {
            var testPeak = new StraightForward();
            Assert.That(testPeak.IsPeak(cases, targetIdx), Is.EqualTo(isPeak));
        }

        [TestCase(0)]
        [TestCase(1, 1)]
        public void ItShouldThrowException(int targetIdx, params int[] cases)
        {
            var testPeak = new StraightForward();
            Assert.Throws<ArgumentOutOfRangeException>(() => testPeak.IsPeak(cases, targetIdx));
        }

        [TestCase(0, 2)]
        [TestCase(0, 2, 1, 3)]
        [TestCase(2, 2, 3, 4)]
        [TestCase(3, 2, 3, 4, 5)]
        [TestCase(2, 2, 3, 4, 3)]
        [TestCase(2, 2, 3, 4, 4)]
        [TestCase(0, 10, 3, 2, 10)]
        [TestCase(4, 10, 0, 1, 2, 10)]
        public void ItShouldSearchArray(int peakIdx, params int[] toSearch)
        {
            var testPeak = new DivideAndConquer();
            var peak = testPeak.FindPeak(toSearch);
            Assert.That(peak, Is.EqualTo(peakIdx));
        }
    }
}
