﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/19/2012
 * Time: 2:52 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TestScenario.
    /// </summary>
    public class TestScenario : ITestScenario
    {
        public TestScenario()
        {
            this.TestResults = new List<ITestResult>();
            this.TestCases = new List<ITestCase>();
            this.Statistics = new TestStat();
            this.enStatus = TestScenarioStatuses.NotTested;
            try{
                if (TestData.CurrentTestResult.Details.Count > 0) {
                    TMX.TestData.AddTestResult(
                        "autoclosed", 
                        TestData.GetTestResultId(), 
                        null, 
                        false, // isKnownIssue
                        false, // generateNextResult
                        null, // MyInvocation
                        null, // Error
                        string.Empty,
                        // 20130322
                        //true);
                        // 20130626
                        //true,
                        TestResultOrigins.Automatic,
                        false);
                } else {
                    TestData.CurrentTestResult = null;
                }
            }
            catch {}
            
            // 20130301
            this.SetNow();
            
            this.TestResults.Add(
                new TestResult(
                    TestData.TestSuites[TestData.TestSuites.Count - 1].TestScenarios[TestData.TestSuites[TestData.TestSuites.Count - 1].TestScenarios.Count - 1].Id, // "???",
                    TestData.TestSuites[TestData.TestSuites.Count - 1].Id)); // "???"));
            TestData.CurrentTestResult = 
                this.TestResults[TestResults.Count - 1];
        }
        
        public TestScenario(
            string testScenarioName, 
            string testScenarioId,
            string testSuiteId)
        {
            this.TestResults = new List<ITestResult>();
            this.TestCases = new List<ITestCase>();
            this.Statistics = new TestStat();
            this.enStatus = TestScenarioStatuses.NotTested;
            this.Name = testScenarioName;
            if (testScenarioId != string.Empty && testScenarioId != null) {
                this.Id = testScenarioId;
            } else {
                this.Id = 
                    TestData.GetTestScenarioId();
            }
            
            // suiteId
            this.SuiteId = testSuiteId;
            
            try{
TestData.dumpTestStructure("TestScenario #1");
                if (TestData.CurrentTestResult.Details.Count > 0) {
                    TMX.TestData.AddTestResult(
                        "autoclosed", 
                        TestData.GetTestResultId(), 
                        null, 
                        false, // isKnownIssue
                        false, // generateNextResult
                        null, // MyInvocation
                        null, // Error
                        string.Empty,
                        // 20130322
                        //true);
                        // 20130626
                        //true,
                        TestResultOrigins.Automatic,
                        false);
TestData.dumpTestStructure("TestScenario #2");
                } else {
TestData.dumpTestStructure("TestScenario #3");
                    TestData.CurrentTestResult = null;
                }
            }
            catch {}
            
            // 20130301
            this.SetNow();
TestData.dumpTestStructure("TestScenario #4");
            this.TestResults.Add(
                new TestResult(
                   this.Id,
                   this.SuiteId));
TestData.dumpTestStructure("TestScenario #5");
            
            // 20130407
            try {
TestData.dumpTestStructure("TestScenario #5.1");
                if ((null != TestData.CurrentTestResult.Name ||
                    null != TestData.CurrentTestResult.Id) &&
                    null != TestData.CurrentTestResult.Details &&
                    0 < TestData.CurrentTestResult.Details.Count) {
TestData.dumpTestStructure("TestScenario #5.3");
                    TestData.CurrentTestScenario.TestResults.Add(TestData.CurrentTestResult);
TestData.dumpTestStructure("TestScenario #5.5");
                }
            }
            catch (Exception eeeee) {
                //Console.WriteLine(eeeee.Message);
            }
TestData.dumpTestStructure("TestScenario #5.9");
            TestData.CurrentTestResult = 
                TestResults[TestResults.Count - 1];
TestData.dumpTestStructure("TestScenario #6");
        }
        
        //public virtual int DbId { get; protected set; }
        public virtual int DbId { get; set; }
        public virtual string Name { get; protected internal set; }
        public virtual string Id { get; protected internal set; }
        public virtual System.Collections.Generic.List<ITestResult> TestResults {get; protected internal set; }
        public virtual string Description { get; set; }

        private string status;
        public virtual string Status { get { return this.status; } }
        private TestScenarioStatuses _enStatus;
        protected internal virtual TestScenarioStatuses enStatus
        { 
            get { return this._enStatus; }
            set{
                this._enStatus = value;

                switch (value) {
                    case TestScenarioStatuses.Passed:
                        this.status = TMX.TestData.TestStatePassed;
                        break;
                    case TestScenarioStatuses.Failed:
                        this.status = TMX.TestData.TestStateFailed;
                        break;
                    case TestScenarioStatuses.NotTested:
                        this.status = TMX.TestData.TestStateNotTested;
                        break;
                    case TestScenarioStatuses.KnownIssue:
                        this.status = TMX.TestData.TestStateKnownIssue;
                        break;
                    default:
                        // 20130428
                        //throw new Exception("Invalid value for TestScenarioStatuses");
                        this.status = TMX.TestData.TestStateNotTested;
                        break;
                }
            }
        }
        
        public virtual TestStat Statistics { get; set; }
        
        public virtual string SuiteId { get; protected internal set; }
        
        // 20130301
        public virtual System.DateTime Timestamp { get; protected internal set; }
        public virtual void SetNow()
        {
            this.Timestamp = System.DateTime.Now;
        }
        public virtual double TimeSpent { get; protected internal set; }
        public virtual void SetTimeSpent(double timeSpent)
        {
            this.TimeSpent = timeSpent;
        }
        
        public virtual string Tags { get; set; }
        public virtual string PlatformId { get; set; }
        
        // 20130615
        public virtual ScriptBlock[] BeforeTest { get; set; }
        public virtual ScriptBlock[] AfterTest { get; set; }
        //public virtual ScriptBlock[] AlternateBeforeScenario { get; set; }
        //public virtual ScriptBlock[] AlternateAfterScenario { get; set; }
        public virtual object[] BeforeTestParameters { get; set; }
        public virtual object[] AfterTestParameters { get; set; }
        public virtual List<ITestCase> TestCases { get; set; }
    }
}
