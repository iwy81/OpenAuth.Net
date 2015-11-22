﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenAuth.App;
using OpenAuth.Domain;
using OpenAuth.Repository;

namespace OpenAuth.UnitTest
{
    /// <summary>
    /// TestModuleApp 的摘要说明
    /// </summary>
    [TestClass]
    public class TestModuleApp
    {
        

        private TestContext testContextInstance;
        private ModuleManagerApp _app = new ModuleManagerApp(new ModuleRepository());
        private string _time = DateTime.Now.ToString("HH_mm_ss_ms");
        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性: 
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestAddModule()
        {
            var root = Add();
            for (int i = 0; i < 30; i++)
            {
                Add(root.Id);
            }
        }

        [TestMethod]
        public void TestDelModule()
        {
            var root = Add(0);
            _app.Delete(root.Id);
        }



        [TestMethod]
        public void TestEdit()
        {
           
        }

        public Module Add(int parent = 0)
        {
            var module = new Module()
            {
                Name = "test_" + _time,
                ParentId = parent
            };
            _app.AddOrUpdate(module);
            return module;
        }
    }
}