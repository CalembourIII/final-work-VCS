using Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    internal class BaseTests
    {
        [SetUp]
        public void SetUp()
        {
            Driver.CreateDriver();
        }

        [TearDown]
        public virtual void TearDown()
        {
            //if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            //{
            //    Driver.TakeScreenshot(TestContext.CurrentContext.Test.MethodName);
            //}
            //Driver.CloseDriver();
        }
    }
}
