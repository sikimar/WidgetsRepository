using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WidgetsRepository.DAL;
using System.IO;
using System.Collections.Generic;

namespace WidgetsRepository.UnitTest
{
    [TestClass]
    public class DirectoryQueryTests
    {
        private const string _directoryName = "DirectoryQueryInside";
        private const string _workDirectoryName = "DirectoryQueryTest";
        private string _workDirectory;
        private DirectoryQuery _directoryQuery;

        public DirectoryQueryTests() 
        {
            _workDirectory = Path.Combine(Directory.GetCurrentDirectory(), _workDirectoryName);
            DirectoryInfo di = new DirectoryInfo(_workDirectory);
            if (!di.Exists) 
            {
                di.Create();
            }

            _directoryQuery = new DirectoryQuery(_workDirectory);
        }
        [TestMethod]
        public void TestAddDirectory()
        {
            DirectoryData dd = new DirectoryData(){Name = _directoryName};
            _directoryQuery.Insert(dd);

            Assert.IsTrue(new DirectoryInfo(Path.Combine(_workDirectory, _directoryName)).Exists);
        }

        [TestMethod]
        public void TestAddDirectoryExisting()
        {
            DirectoryData dd = new DirectoryData() { Name = _directoryName };
            _directoryQuery.Insert(dd);

            Assert.IsTrue(new DirectoryInfo(Path.Combine(_workDirectory, _directoryName)).Exists);
        }

        [TestMethod]
        public void TestFindDirectory()
        {
            DirectoryData dd = (DirectoryData)_directoryQuery.Find(_directoryName);

            Assert.AreEqual(dd.Name, new DirectoryInfo(Path.Combine(_workDirectory, _directoryName)).Name);
        }

        [TestMethod]
        public void TestFindDirectoryNotExisting()
        {
            DirectoryData dd = (DirectoryData)_directoryQuery.Find("NotExistingDirectory");

            Assert.IsNull(dd);
            Assert.IsFalse(new DirectoryInfo(Path.Combine(_workDirectory, "NotExistingDirectory")).Exists);
        }

        [TestMethod]
        public void TestGetAllDirectories()
        {
            List<DirectoryData> ddList =  _directoryQuery.GetAll();

            Assert.IsTrue(ddList.Count == 1);
        }

        [TestMethod]
        public void TestDeleteDirectory()
        {
            DirectoryData dd = new DirectoryData() { Name = _directoryName };
            _directoryQuery.Delete(dd);

            Assert.IsFalse(new DirectoryInfo(Path.Combine(_workDirectory, _directoryName)).Exists);
        }

        [TestMethod]
        public void TestDeleteDirectoryNotExisting()
        {
            DirectoryData dd = new DirectoryData() { Name = "NotExistingDirectory" };
            _directoryQuery.Delete(dd);

            Assert.IsFalse(new DirectoryInfo(Path.Combine(_workDirectory, "NotExistingDirectory")).Exists);
        }

        [TestMethod]
        public void TestGetAllDirectoriesNotExisting()
        {
            List<DirectoryData> ddList = _directoryQuery.GetAll();

            Assert.IsTrue(ddList.Count == 0);
        }
    }
}
