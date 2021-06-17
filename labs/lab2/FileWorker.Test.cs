using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using IIG.FileWorker;

namespace lab2
{
    [TestClass]
    public class FileWorkerTest
    {
        #region ReadLines
        [TestMethod]
        public void TestReadLinesExistingFile()
        {
            string path = "existing.txt";
            string[] result = BaseFileWorker.ReadLines(path);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestReadLinesNonExistentFile()
        {
            string path = "non-existant.txt";
            string[] result = BaseFileWorker.ReadLines(path);
            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestReadLinesNullPath()
        {
            string path = null;
            string[] result = BaseFileWorker.ReadLines(path);
            Assert.IsNull(result);
        }
        #endregion
        #region ReadAll
        [TestMethod]
        public void TestReadAllExistingFile()
        {
            string path = "existing.txt";
            string result = BaseFileWorker.ReadAll(path);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestReadAllNonExistentFile()
        {
            string path = "non-existant.txt";
            string result = BaseFileWorker.ReadAll(path);
            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestReadAllPathNull()
        {
            string path = null;
            string result = BaseFileWorker.ReadAll(path);
            Assert.IsNull(result);
        }
        #endregion
        #region Write
        [TestMethod]
        public void TestWriteValidInput()
        {
            string text = "Lorem ipsum dolor sit amet";
            string path = "existing.txt";
            bool result = BaseFileWorker.Write(text, path);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestWriteEmptyPath()
        {
            string text = "Lorem ipsum dolor sit amet";
            string path = "";
            bool result = BaseFileWorker.Write(text, path);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestWritePathNull()
        {
            string text = "Lorem ipsum dolor sit amet";
            string path = null;
            bool result = BaseFileWorker.Write(text, path);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestWriteEmptyText()
        {
            string text = "";
            string path = "existing.txt";
            bool result = BaseFileWorker.Write(text, path);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestWriteTextNull()
        {
            string text = null;
            string path = "existing.txt";
            bool result = BaseFileWorker.Write(text, path);
            Assert.IsTrue(result); // ?
        }
        [TestMethod]
        public void TestWriteThenReadAllEqual()
        {
            string text = "Lorem ipsum dolor sit amet";
            string path = "existing.txt";
            BaseFileWorker.Write(text, path);
            string result = BaseFileWorker.ReadAll(path);
            Assert.IsNotNull(result);
            Assert.AreEqual(text, result);
        }
        #endregion
        #region GetFullPath
        [TestMethod]
        public void TestGetFullPathExistingFile()
        {
            string path = "existing.txt";
            string result = BaseFileWorker.GetFullPath(path);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestGetFullPathNonExistentFile()
        {
            string path = "non-existent.txt";
            string result = BaseFileWorker.GetFullPath(path);
            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestGetFullPathNullPath()
        {
            string path = null;
            string result = BaseFileWorker.GetFullPath(path);
            Assert.IsNull(result);
        }
        #endregion
        #region GetFileName
        [TestMethod]
        public void TestGetFileNameExistingPath()
        {
            string path = "existing.txt";
            string result = BaseFileWorker.GetFileName(path);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestGetFileNameNonExistentPath()
        {
            string path = "@%$/17";
            string result = BaseFileWorker.GetFileName(path);
            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestGetFileNameNullPath()
        {
            string path = null;
            string result = BaseFileWorker.GetFileName(path);
            Assert.IsNull(result);
        }

        #endregion
        #region GetPath
        [TestMethod]
        public void TestGetPathExistingFile()
        {
            string path = "existing.txt";
            string result = BaseFileWorker.GetPath(path);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestGetPathNonExistentFile()
        {
            string path = "@%$/17";
            string result = BaseFileWorker.GetPath(path);
            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestGetPathNullFile()
        {
            string path = null;
            string result = BaseFileWorker.GetPath(path);
            Assert.IsNull(result);
        }
        #endregion
        #region MkDir
        [TestMethod]
        public void TestMkDirValidName()
        {
            string name = "New Dir";
            string result = BaseFileWorker.MkDir(name);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestMkDirInvalidName()
        {
            string name = "?";
            Action action = () => BaseFileWorker.MkDir(name);
            Assert.ThrowsException<ArgumentException>(action);
        }
        [TestMethod]
        public void TestMkDirEmptyName()
        {
            string name = "";
            Action action = () => BaseFileWorker.MkDir(name);
            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void TestMkDirNullName()
        {
            string name = null;
            Action action = () => BaseFileWorker.MkDir(name);
            Assert.ThrowsException<ArgumentNullException>(action);
        }
        #endregion
        #region TryWrite
        [TestMethod]
        public void TestTryWriteValidPath()
        {
            string text = "Lorem ipsum dolor sit amet";
            string path = "try-write.txt";
            int tries = 5;
            bool result = BaseFileWorker.TryWrite(text, path, tries);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestTryWriteZeroTries()
        {
            string text = "Lorem ipsum dolor sit amet";
            string path = "try-write.txt";
            int tries = 0;
            bool result = BaseFileWorker.TryWrite(text, path, tries);
            Assert.IsFalse(result);
        }
        public void TestTryWriteDefaultTries()
        {
            string text = "Lorem ipsum dolor sit amet";
            string path = "try-write.txt";
            bool result = BaseFileWorker.TryWrite(text, path);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestTryWriteInvalidPath()
        {
            string text = "Lorem ipsum dolor sit amet";
            string path = "?";
            int tries = 5;
            bool result = BaseFileWorker.TryWrite(text, path, tries);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestTryWriteNullPath()
        {
            string text = "Lorem ipsum dolor sit amet";
            string path = null;
            int tries = 5;
            bool result = BaseFileWorker.TryWrite(text, path, tries);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestTryWriteNullText()
        {
            string text = null;
            string path = "try-write.txt";
            int tries = 5;
            bool result = BaseFileWorker.TryWrite(text, path, tries);
            Assert.IsTrue(result); // ?
        }
        #endregion
        #region TryCopy
        [TestMethod]
        public void TestTryCopy()
        {
            string from = "existing.txt";
            string to = "try-copy.txt";
            bool rewrite = true;
            int tries = 5;
            bool result = BaseFileWorker.TryCopy(from, to, rewrite, tries);
            Assert.IsTrue(result);
            rewrite = false;
            Action action = () => BaseFileWorker.TryCopy(from, to, rewrite);
            Assert.ThrowsException<System.IO.IOException>(action);
        }
        [TestMethod]
        public void TestTryCopyZeroTries()
        {
            string from = "existing.txt";
            string to = "try-copy.txt";
            bool rewrite = true;
            int tries = 0;
            bool result = BaseFileWorker.TryCopy(from, to, rewrite, tries);
            Assert.IsFalse(result);            
        }
        [TestMethod]
        public void TestTryCopyEmptyFrom()
        {
            string from = "";
            string to = "try-copy.txt";
            bool rewrite = true;
            bool result = BaseFileWorker.TryCopy(from, to, rewrite);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestTryCopyNonExistantFrom()
        {
            string from = "non-existant.txt";
            string to = "try-copy.txt";
            bool rewrite = true;
            Action action = () => BaseFileWorker.TryCopy(from, to, rewrite);
            Assert.ThrowsException<System.IO.FileNotFoundException>(action);
        }
        [TestMethod]
        public void TestTryCopyNullFrom()
        {
            string from = null;
            string to = "try-copy.txt";
            bool rewrite = true;
            bool result = BaseFileWorker.TryCopy(from, to, rewrite);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestTryCopyEmptyTo()
        {
            string from = "existing.txt";
            string to = "";
            bool rewrite = true;
            bool result = BaseFileWorker.TryCopy(from, to, rewrite);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestTryCopyNonExistantTo()
        {
            string from = "existing.txt";
            string to = "try-copy-non-existant.txt";
            bool rewrite = true;
            bool result = BaseFileWorker.TryCopy(from, to, rewrite);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestTryCopyNull()
        {
            string from = "existing.txt";
            string to = null;
            bool rewrite = true;
            bool result = BaseFileWorker.TryCopy(from, to, rewrite);
            Assert.IsFalse(result);
        }
        #endregion
    }
}
