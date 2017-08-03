using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestApi.Service;
using static UnitTestApi.Service.CrudService;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestApiTest
{
    //test driven design 
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("1234", "1234");
        }

        
        public class MockStorage : IDataStorage
        {
            List<string> names = new List<string>();

            public List<string> NameList
            {
                get
                {
                    return names;
                }
            }

            public int Insert(string name)
            {
                names.Add(name);
                return names.Count;
            }

            public string Read()
            {
                return "Tiana";
            }


            public int Update(string oldName, string newName)
            {
                string existing = names.Where(n => n == oldName).FirstOrDefault();

                if (!string.IsNullOrEmpty(existing))
                {
                    names = names.Select(n => n.Replace(existing, newName)).ToList();
                }
                return names.Count;
            }

            public void Delete(string name)
            {             
                  names.Remove(name);
                                      
            }
        }
        [TestMethod]
        public void TestCrudService()
        {

            int expectedId = 3;
            string expectedString = "Tiana";
            string newName = "John";
            int count = 2;
            MockStorage ms = new MockStorage();
            CrudService cs = new CrudService(ms);
            cs.Create("Tiana");
            cs.Create("Adan");
            cs.Create("Britto");


            Assert.AreEqual(expectedString, ms.Read());

            Assert.AreEqual(expectedId, ms.Update(expectedString, newName));
            Assert.AreEqual(newName, ms.NameList.Where(n => n == "John").FirstOrDefault());

            cs.Delete("Britto");
            Assert.AreEqual(count, ms.NameList.Count);

        }

    }
}
