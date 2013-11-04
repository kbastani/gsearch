using gSearch.Core.Graph.Services.Time;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using gSearch.Core.Graph.Services.Time.Interfaces;

namespace gSearch.Core.Tests
{   
    /// <summary>
    ///This is a test class for TimeScaleVertexTest and is intended
    ///to contain all TimeScaleVertexTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TimeScaleVertexTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
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

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for TimeScaleVertex Constructor
        ///</summary>
        [TestMethod()]
        public void TimeScaleVertexConstructorTest()
        {
            TimeScale timeScaleTest = new TimeScale();

            List<ITimeScaleVertex> timeScaleVertices = new List<ITimeScaleVertex>();

            // Vertex 1
            timeScaleVertices.Add(
                new TimeScaleVertex(

                    timeScaleTest.GlobalCallback()
                ));

            Assert.IsNotNull(timeScaleVertices[0]);

            // Vertex 2
            timeScaleVertices.Add(
                new TimeScaleVertex(

                    timeScaleTest.GlobalCallback()
                ));

            Assert.IsNotNull(timeScaleVertices[1]);

            // Vertex 3
            timeScaleVertices.Add(
                new TimeScaleVertex(

                    timeScaleTest.GlobalCallback()
                ));

            Assert.IsNotNull(timeScaleVertices[2]);
        }

        /// <summary>
        ///A test for TimeScaleVertex Constructor
        ///</summary>
        [TestMethod()]
        public void TimeScaleVertexConstructorTest1()
        {
            TimeScale timeScaleTest = new TimeScale();

            List<ITimeScaleVertex> timeScaleVertices = new List<ITimeScaleVertex>();

            // Vertex 1
            timeScaleVertices.Add(
                new TimeScaleVertex(
                    new List<ITimeScaleNode>() 
                    { 
                        new TimeScaleNode() { NodeId = 0, Bit = 0, Interval = 50 } as ITimeScaleNode, 
                        new TimeScaleNode() { NodeId = 1, Bit = 0, Interval = 50 } as ITimeScaleNode, 
                        new TimeScaleNode() { NodeId = 2, Bit = 1, Interval = 50 } as ITimeScaleNode 
                    },
                    timeScaleTest.GlobalCallback()
                ));

            Assert.IsNotNull(timeScaleVertices[0].Nodes);

            // Vertex 2
            timeScaleVertices.Add(
                new TimeScaleVertex(
                    new List<ITimeScaleNode>() 
                    { 
                        new TimeScaleNode() { NodeId = 3, Bit = 0, Interval = 50 } as ITimeScaleNode, 
                        new TimeScaleNode() { NodeId = 4, Bit = 0, Interval = 50 } as ITimeScaleNode, 
                        new TimeScaleNode() { NodeId = 5, Bit = 1, Interval = 50 } as ITimeScaleNode 
                    },
                    timeScaleTest.GlobalCallback()
                ));

            Assert.IsNotNull(timeScaleVertices[1].Nodes);

            // Vertex 3
            timeScaleVertices.Add(
                new TimeScaleVertex(
                    new List<ITimeScaleNode>() 
                    { 
                        new TimeScaleNode() { NodeId = 6, Bit = 0, Interval = 50 } as ITimeScaleNode, 
                        new TimeScaleNode() { NodeId = 7, Bit = 0, Interval = 50 } as ITimeScaleNode, 
                        new TimeScaleNode() { NodeId = 8, Bit = 1, Interval = 50 } as ITimeScaleNode 
                    },
                    timeScaleTest.GlobalCallback()
                ));

            Assert.IsNotNull(timeScaleVertices[2].Nodes);
        }

        /// <summary>
        ///A test for TimeScaleVertex Constructor
        ///</summary>
        [TestMethod()]
        public void TimeScaleVertexConstructorTest2()
        {
            TimeScale timeScaleTest = new TimeScale();

            List<ITimeScaleVertex> timeScaleVertices = new List<ITimeScaleVertex>();

            // Vertex 1
            timeScaleVertices.Add(
                new TimeScaleVertex(
                    new List<ITimeScaleNode>() 
                    { 
                        new TimeScaleNode() { NodeId = 0, Bit = 0, Interval = 50 } as ITimeScaleNode, 
                        new TimeScaleNode() { NodeId = 1, Bit = 0, Interval = 50 } as ITimeScaleNode, 
                        new TimeScaleNode() { NodeId = 2, Bit = 1, Interval = 50 } as ITimeScaleNode 
                    },
                    new List<ITimeScaleRelationship>()
                    {
                        new TimeScaleRelationship() { StartId = 0, EndId = 1 } as ITimeScaleRelationship, 
                        new TimeScaleRelationship() { StartId = 0, EndId = 2 } as ITimeScaleRelationship,
                        new TimeScaleRelationship() { StartId = 1, EndId = 3 } as ITimeScaleRelationship,
                        new TimeScaleRelationship() { StartId = 2, EndId = 6 } as ITimeScaleRelationship
                    },
                    timeScaleTest.GlobalCallback()
                ));

            Assert.IsNotNull(timeScaleVertices[0].Nodes);
            Assert.IsNotNull(timeScaleVertices[0].Relationships);


            // Vertex 2
            timeScaleVertices.Add(
                new TimeScaleVertex(
                    new List<ITimeScaleNode>() 
                    { 
                        new TimeScaleNode() { NodeId = 3, Bit = 0, Interval = 50 } as ITimeScaleNode, 
                        new TimeScaleNode() { NodeId = 4, Bit = 0, Interval = 50 } as ITimeScaleNode, 
                        new TimeScaleNode() { NodeId = 5, Bit = 1, Interval = 50 } as ITimeScaleNode 
                    },
                    new List<ITimeScaleRelationship>()
                    {
                        new TimeScaleRelationship() { StartId = 3, EndId = 4 } as ITimeScaleRelationship, 
                        new TimeScaleRelationship() { StartId = 3, EndId = 5 } as ITimeScaleRelationship
                    },
                    timeScaleTest.GlobalCallback()
                ));

            Assert.IsNotNull(timeScaleVertices[1].Nodes);
            Assert.IsNotNull(timeScaleVertices[1].Relationships);

            // Vertex 3
            timeScaleVertices.Add(
                new TimeScaleVertex(
                    new List<ITimeScaleNode>() 
                    { 
                        new TimeScaleNode() { NodeId = 6, Bit = 0, Interval = 50 } as ITimeScaleNode, 
                        new TimeScaleNode() { NodeId = 7, Bit = 0, Interval = 50 } as ITimeScaleNode, 
                        new TimeScaleNode() { NodeId = 8, Bit = 1, Interval = 50 } as ITimeScaleNode 
                    },
                    new List<ITimeScaleRelationship>()
                    {
                        new TimeScaleRelationship() { StartId = 6, EndId = 7 } as ITimeScaleRelationship, 
                        new TimeScaleRelationship() { StartId = 6, EndId = 8 } as ITimeScaleRelationship
                    },
                    timeScaleTest.GlobalCallback()
                ));

            Assert.IsNotNull(timeScaleVertices[2].Nodes);
            Assert.IsNotNull(timeScaleVertices[2].Relationships);
        }

        /// <summary>
        ///A test for InitializeTimeScaleInstance
        ///</summary>
        [TestMethod()]
        public void InitializeTimeScaleInstanceTest()
        {
            TimeScale timeScale = new TimeScale();

            Func<ITimeScaleRelationship, List<ITimeScaleVertex>> callback = timeScale.GlobalCallback();

            TimeScaleVertex target = new TimeScaleVertex(callback); 

            List<ITimeScaleNode> nodes = new List<ITimeScaleNode>() 
                    { 
                        new TimeScaleNode() { NodeId = 0, Bit = 0, Interval = 50 } as ITimeScaleNode, 
                        new TimeScaleNode() { NodeId = 1, Bit = 0, Interval = 50 } as ITimeScaleNode, 
                        new TimeScaleNode() { NodeId = 2, Bit = 1, Interval = 50 } as ITimeScaleNode 
                    };

            List<ITimeScaleRelationship> relationships = new List<ITimeScaleRelationship>()
                    {
                        new TimeScaleRelationship() { StartId = 0, EndId = 1 } as ITimeScaleRelationship, 
                        new TimeScaleRelationship() { StartId = 0, EndId = 2 } as ITimeScaleRelationship,
                        new TimeScaleRelationship() { StartId = 1, EndId = 3 } as ITimeScaleRelationship,
                    };

            Func<ITimeScaleRelationship, List<ITimeScaleVertex>> callback1 = target.Callback; 
            target.InitializeTimeScaleInstance(nodes, relationships, callback1);

            Assert.IsNotNull(target);
        }
    }
}
