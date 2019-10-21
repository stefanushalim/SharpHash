﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpHash.Base;
using SharpHash.Interfaces;
using SharpHash.Tests;
using SharpHash.Utils;
using System;
using System.Text;

namespace SharpHash
{
    [TestClass]
    public class HashTests
    {
        private IHash hash = HashFactory.Crypto.CreateMD5();
        private readonly string ExpectedHashOfDefaultData = "462EC1E50C8F2D5C387682E98F9BC842";
        private readonly string ExpectedHashOfEmptyData = "D41D8CD98F00B204E9800998ECF8427E";

        [TestMethod]
        public void TestNullStreamThrowException()
        {
            Assert.ThrowsException<ArgumentNilHashLibException>(() => hash.ComputeStream(null));

            //
            hash.Initialize();

            Assert.ThrowsException<ArgumentNilHashLibException>(() => hash.TransformStream(null));

            hash.TransformFinal();
        }

        [TestMethod]
        public unsafe void TestUntypedDataComputation()
        {
            string ActualString;

            //
            byte[] data = Converters.ConvertStringToBytes(TestConstants.DefaultData,
                Encoding.UTF8);

            fixed (byte* bPtr = data)
            {
                ActualString = hash.ComputeUntyped((IntPtr)bPtr, data.Length).ToString();
            }

            //
            Assert.AreEqual(ExpectedHashOfDefaultData, ActualString,
                String.Format("Expected {0} but got {1}.",
                ExpectedHashOfDefaultData, ActualString));

            // Second
            hash.Initialize();

            fixed (byte* bPtr = data)
            {
                hash.TransformUntyped((IntPtr)bPtr, data.Length);
            }

            ActualString = hash.TransformFinal().ToString();

            //
            Assert.AreEqual(ExpectedHashOfDefaultData, ActualString,
                String.Format("Expected {0} but got {1}.",
                ExpectedHashOfDefaultData, ActualString));
        } // end function

        [TestMethod]
        public void TestForNullString()
        {
            string ActualString;

            //
            ActualString = hash.ComputeString(null, Encoding.UTF8).ToString();

            //
            Assert.AreEqual(ExpectedHashOfEmptyData, ActualString,
                String.Format("Expected {0} but got {1}.",
                ExpectedHashOfEmptyData, ActualString));

            //
            hash.Initialize();
            hash.TransformString(null, Encoding.UTF8);
            ActualString = hash.TransformFinal().ToString();

            //
            Assert.AreEqual(ExpectedHashOfEmptyData, ActualString,
                String.Format("Expected {0} but got {1}.",
                ExpectedHashOfEmptyData, ActualString));
        } // end function

        [TestMethod]
        public void TestForNullBytes()
        {
            string ActualString;

            //
            ActualString = hash.ComputeBytes(null).ToString();

            //
            Assert.AreEqual(ExpectedHashOfEmptyData, ActualString,
                String.Format("Expected {0} but got {1}.",
                ExpectedHashOfEmptyData, ActualString));

            //
            hash.Initialize();
            hash.TransformBytes(null);
            hash.TransformBytes(null, 0);
            hash.TransformBytes(null, 0, 0);

            hash.TransformBytes(new byte[0]);
            hash.TransformBytes(new byte[0], 0);
            hash.TransformBytes(new byte[0], 0, 0);

            ActualString = hash.TransformFinal().ToString();

            //
            Assert.AreEqual(ExpectedHashOfEmptyData, ActualString,
                String.Format("Expected {0} but got {1}.",
                ExpectedHashOfEmptyData, ActualString));
        }

        [TestMethod]
        public void TestForFileComputation()
        {
            string ActualString;
            string file_path = "../../../default_data.txt";

            //
            ActualString = hash.ComputeFile(file_path).ToString();

            //
            Assert.AreEqual(ExpectedHashOfDefaultData, ActualString,
                String.Format("Expected {0} but got {1}.",
                ExpectedHashOfDefaultData, ActualString));

            //
            hash.Initialize();
            hash.TransformFile(file_path);
            ActualString = hash.TransformFinal().ToString();

            //
            Assert.AreEqual(ExpectedHashOfDefaultData, ActualString,
                String.Format("Expected {0} but got {1}.",
                ExpectedHashOfDefaultData, ActualString));
        }
    }
}