﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using WidgetsRepository.DAL;
using System.Collections.Generic;

namespace WidgetsRepository.UnitTest
{
    [TestClass]
    public class FileQueryTests
    {
        private const string _directoryName = "FileQueryTest";
        private const string _fileName = "filequery.txt";
        private const string _fileData = "<html> Hello </html>";
        private string _workDirectory;
        private FileQuery _fileQuery;

        public FileQueryTests() 
        {
            _workDirectory = Path.Combine(Directory.GetCurrentDirectory(), _directoryName);
            DirectoryInfo directoryInfo = new DirectoryInfo(_workDirectory);
            if (!directoryInfo.Exists) 
            {
                directoryInfo.Create();
            }

            _fileQuery = new FileQuery(_workDirectory);
        }

        [TestMethod]
        public void TestAdd()
        {
            FileData fd = new FileData() { Name = _fileName, Data = _fileData };
            _fileQuery.Insert(fd);
            FileInfo fi = new FileInfo(Path.Combine(_workDirectory,_fileName));
            Assert.IsTrue(fi.Exists);
        }

        [TestMethod]
        public void TestFind()
        {
            FileData fd = (FileData)_fileQuery.Find(_fileName);

            Assert.IsNotNull(fd);
            Assert.AreEqual(fd.Name, _fileName);
            Assert.AreEqual(fd.Data, _fileData);
        }

        [TestMethod]
        public void TestFindNotExist()
        {
            FileData fd = (FileData)_fileQuery.Find("somefilethatdoesnotexist.txt");
            Assert.IsNull(fd);
        }

        [TestMethod]
        public void TestGetAll()
        {
            List<FileData> fdList = _fileQuery.GetAll();
            Assert.IsTrue(fdList.Count == 1);
        }

        [TestMethod]
        public void TestDelete()
        {
            FileData fd = new FileData() { Name = _fileName, Data = _fileData };
            _fileQuery.Delete(fd);

            Assert.IsFalse(new FileInfo(Path.Combine(_workDirectory, _fileName)).Exists);
        }

        [TestMethod]
        public void TestDeleteNotExist()
        {
            FileData fd = new FileData() { Name = "somefilethatdoesnotexist.txt", Data = _fileData };
            _fileQuery.Delete(fd);

            Assert.IsFalse(new FileInfo(Path.Combine(_workDirectory, _fileName)).Exists);
        }

        [TestMethod]
        public void TestGetAllNotExist()
        {
            List<FileData> fdList = _fileQuery.GetAll();
            Assert.IsTrue(fdList.Count == 0);
        }
    }
}