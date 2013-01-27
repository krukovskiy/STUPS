﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17/02/2012
 * Time: 07:48 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.ComponentModel;
    using System.Linq;
    
    
    public delegate void TMXStructureChangedEventHandler(object sender, EventArgs e);
    public delegate void TMXDatabaseOperationCompletedEventHandler(object sender, EventArgs e);
    
    /// <summary>
    /// Description of TestSuitesCollection.
    /// </summary>
    public static class TestData
    {
        // ----------------- Variables ---------------------------
        
        public const string TestStateNotTested = "NOT TESTED";
        public const string TestStatePassed = "PASSED";
        public const string TestStateFailed = "FAILED";
        public const string TestStateKnownIssue = "KNOWN ISSUE";
        
        static TestData()
        {
            TestSuites = 
                new List<TestSuite > ();
            
//            try {
//                OnTMXNewTestResultClosed(1, new EventArgs());
//                OnTMXNewTestResultDetailAdded(1, new EventArgs());
//                OnTMXNewTestSuiteCreated(1, new EventArgs());
//                OnTMXNewTestScenarioAdded(1, new EventArgs());
//                OnTMXTestScenarioOpened(1, new EventArgs());
//                OnTMXTestSuiteOpened(1, new EventArgs());
//            }
//            catch {}
        }
        
        
        // ----------------- Properties --------------------------
        
        public static List<TestSuite> TestSuites {get; internal set; }
        //public string SourceId {get; internal set; }
        //public string Source {get; internal set; }

        //public static System.Collections.Generic.List<TestResult >  TestSuites { get; internal set; }
        //internal static System.Collections.Generic.List<TestResult >  TestScenarios { get; internal set; }
        //public static System.Collections.Generic.List<TestResult >  TestResults { get; internal set; }
        
        
        //public static System.Collections.Generic.List<ITestSuite >  TestResults { get; internal set; }
        
        //public static ITestSuite CurrentTestSuite { get; set; }
        public static TestSuite CurrentTestSuite { get; set; }
        //public static ITestScenario CurrentTestScenario { get; set; }
        public static TestScenario CurrentTestScenario { get; set; }
        public static ITestResult CurrentTestResult { get; set; } // ?? rewrite as the last item of the collection ??
        public static ITestResult LastTestResult // ?? rewrite as setting the previous on creating the current ??
        {
            get {
                ITestResult testResult = null;
                if (null != TestSuites && 0 < TestSuites.Count) {
                    
                    int suiteNumber = TestSuites.Count - 1;
                    
                    if (null != TestSuites[suiteNumber].TestScenarios &&
                        0 < TestSuites[suiteNumber].TestScenarios.Count) {
                        
                        int scenarioNumber = TestSuites[TestSuites.Count -1].TestScenarios.Count - 1;
                        
                        if (null != TestSuites[suiteNumber].TestScenarios[scenarioNumber].TestResults &&
                            0 < TestSuites[suiteNumber].TestScenarios[scenarioNumber].TestResults.Count) {
                            
                        testResult = TestSuites[suiteNumber].TestScenarios[scenarioNumber].TestResults[
                                TestSuites[suiteNumber].TestScenarios[scenarioNumber].TestResults.Count - 1];
                        }
                    }
                }
                
                return testResult;
            }
        }
        
        
        public static IDatabase CurrentStructureDB { get; set; }
        public static IDatabase CurrentRepositoryDB { get; set; }
        public static IDatabase CurrentResultsDB { get; set; }

        
        // ------------------ Events -----------------------------
        public static event TMXStructureChangedEventHandler TMXNewTestSuiteCreated;
        public static event TMXStructureChangedEventHandler TMXTestSuiteOpened;
        public static event TMXStructureChangedEventHandler TMXNewTestScenarioAdded;
        public static event TMXStructureChangedEventHandler TMXTestScenarioOpened;
        public static event TMXStructureChangedEventHandler TMXNewTestResultClosed;
        public static event TMXStructureChangedEventHandler TMXNewTestResultDetailAdded;
        
        public static event TMXDatabaseOperationCompletedEventHandler TMXBackUpTestResultsCompleted;
        public static event TMXDatabaseOperationCompletedEventHandler TMXRestoreTestResultsCompleted;
        
        public static event TMXDatabaseOperationCompletedEventHandler TMXTestBucketAdded;
        public static event TMXDatabaseOperationCompletedEventHandler TMXTestBucketRemoved;
        public static event TMXDatabaseOperationCompletedEventHandler TMXTestBucketChanged;
        
        public static event TMXDatabaseOperationCompletedEventHandler TMXTestConstantAdded;
        public static event TMXDatabaseOperationCompletedEventHandler TMXTestConstantRemoved;
        public static event TMXDatabaseOperationCompletedEventHandler TMXTestConstantChanged;
        
        public static event TMXDatabaseOperationCompletedEventHandler TMXTestCaseAdded;
        public static event TMXDatabaseOperationCompletedEventHandler TMXTestCaseRemoved;
        public static event TMXDatabaseOperationCompletedEventHandler TMXTestCaseChanged;
        
        internal static void OnTMXNewTestSuiteCreated(object sender, EventArgs e) 
        {
            if (TMXNewTestSuiteCreated != null) {
                TMXNewTestSuiteCreated(sender, e);
            }
        }
        
        internal static void OnTMXTestSuiteOpened(object sender, EventArgs e) 
        {
            if (TMXTestSuiteOpened != null) {
                TMXTestSuiteOpened(sender, e);
            }
        }
        
        internal static void OnTMXNewTestScenarioAdded(object sender, EventArgs e) 
        {
            if (TMXNewTestScenarioAdded != null) {
                TMXNewTestScenarioAdded(sender, e);
            }
        }
        
        internal static void OnTMXTestScenarioOpened(object sender, EventArgs e) 
        {
            if (TMXTestScenarioOpened != null) {
                TMXTestScenarioOpened(sender, e);
            }
        }
        
        internal static void OnTMXNewTestResultClosed(object sender, EventArgs e) 
        {
            if (TMXNewTestResultClosed != null) {
                TMXNewTestResultClosed(sender, e);
            }
        }
        
        internal static void OnTMXNewTestResultDetailAdded(object sender, EventArgs e) 
        {
            if (TMXNewTestResultDetailAdded != null) {
                TMXNewTestResultDetailAdded(sender, e);
            }
        }
        
        internal static void OnTMXBackUpTestResultsCompleted(object sender, EventArgs e) 
        {
            if (TMXBackUpTestResultsCompleted != null) {
                TMXBackUpTestResultsCompleted(sender, e);
            }
        }
        
        internal static void OnTMXRestoreTestResultsCompleted(object sender, EventArgs e) 
        {
            if (TMXRestoreTestResultsCompleted != null) {
                TMXRestoreTestResultsCompleted(sender, e);
            }
        }
        
        internal static void OnTMXTestBucketAdded(object sender, EventArgs e) 
        {
            if (TMXTestBucketAdded != null) {
                TMXTestBucketAdded(sender, e);
            }
        }
        
        internal static void OnTMXTestBucketRemoved(object sender, EventArgs e) 
        {
            if (TMXTestBucketRemoved != null) {
                TMXTestBucketRemoved(sender, e);
            }
        }
        
        internal static void OnTMXTestBucketChanged(object sender, EventArgs e) 
        {
            if (TMXTestBucketChanged != null) {
                TMXTestBucketChanged(sender, e);
            }
        }
        
        internal static void OnTMXTestConstantAdded(object sender, EventArgs e) 
        {
            if (TMXTestConstantAdded != null) {
                TMXTestConstantAdded(sender, e);
            }
        }
        
        internal static void OnTMXTestConstantRemoved(object sender, EventArgs e) 
        {
            if (TMXTestConstantRemoved != null) {
                TMXTestConstantRemoved(sender, e);
            }
        }
        
        internal static void OnTMXTestConstantChanged(object sender, EventArgs e) 
        {
            if (TMXTestConstantChanged != null) {
                TMXTestConstantChanged(sender, e);
            }
        }
        
        internal static void OnTMXTestCaseAdded(object sender, EventArgs e) 
        {
            if (TMXTestCaseAdded != null) {
                TMXTestCaseAdded(sender, e);
            }
        }
        
        internal static void OnTMXTestCaseRemoved(object sender, EventArgs e) 
        {
            if (TMXTestCaseRemoved != null) {
                TMXTestCaseRemoved(sender, e);
            }
        }
        
        internal static void OnTMXTestCaseChanged(object sender, EventArgs e) 
        {
            if (TMXTestCaseChanged != null) {
                TMXTestCaseChanged(sender, e);
            }
        }
        
        // ------------------ Methods ----------------------------
        public static void ResetData()
        {
            TestSuites.Clear();
            CurrentTestResult = null;
            CurrentTestScenario = null;
            CurrentTestSuite = null;
        }
        
        public static void CleanData()
        {
            foreach (TestSuite suite in TestSuites) {
                foreach (TestScenario scenario in suite.TestScenarios) {
                    scenario.TestResults.Clear();
                    scenario.enStatus = TestScenarioStatuses.NotTested;
                }
                suite.enStatus = TestSuiteStatuses.NotTested;
            }
            CurrentTestResult = null;
            CurrentTestScenario = null;
            CurrentTestSuite = null;
        }
        
        internal static void AddTestResult(string previousTestResultName,
                                           string previousTestResultId,
                                           bool? passed,
                                           bool isKnownIssue,
                                           bool generateNextResult,
                                           InvocationInfo myInvocation,
                                           ErrorRecord error,
                                           string testResultDescription,
                                           bool generated)
        {
            
            // 20121220
            TestData.InitCurrentTestScenario();
            
            // 20121224
            ITestResult currentTestResult;
            if (null != TestData.CurrentTestResult) {
                currentTestResult = TestData.CurrentTestResult;
            } else {
            
                // 20121220
                //ITestResult currentTestResult =
                currentTestResult =
                    new TestResult(
                        TestData.CurrentTestScenario.Id,
                        TestData.CurrentTestSuite.Id);
            }
            
            if (previousTestResultName != null &&
                previousTestResultName != string.Empty &&
                previousTestResultName.Length > 0 &&
                TMX.TestData.CurrentTestResult != null && 
                 previousTestResultName != TMX.TestData.CurrentTestResult.Name) {
                
                // 20121220
                //CurrentTestResult.Name = previousTestResultName;
                currentTestResult.Name = previousTestResultName;

            } else {
                
                // 20121220
                //CurrentTestResult.Name = "generated test result name";
                currentTestResult.Name = "generated test result name";
            }

            if (previousTestResultId != null &&
                previousTestResultId != string.Empty &&
                previousTestResultId.Length > 0 &&
                // 20121220
                null != TMX.TestData.CurrentTestResult &&
                previousTestResultId != TMX.TestData.CurrentTestResult.Id) {

                // 20121220
                //CurrentTestResult.Id = previousTestResultId;
                currentTestResult.Id = previousTestResultId;
            } else {
                
                // 20121220
                //CurrentTestResult.Id = GetTestResultId();
                currentTestResult.Id = GetTestResultId();
            }

            if (passed != null) {

                if ((bool)passed) {

                    // 20121220
                    //CurrentTestResult.enStatus = TestResultStatuses.Passed;
                    currentTestResult.enStatus = TestResultStatuses.Passed;
                } else {

                    // 20120922
                    // 20121220
                    //CurrentTestResult.enStatus = TestResultStatuses.Failed;
                    currentTestResult.enStatus = TestResultStatuses.Failed;
//                    if (isKnownIssue) {
//                        CurrentTestResult.enStatus = TestResultStatuses.KnownIssue;
//                    }
                }
                // 20120922
                if (isKnownIssue) {

                    // 20121220
                    //CurrentTestResult.enStatus = TestResultStatuses.KnownIssue;
                    currentTestResult.enStatus = TestResultStatuses.KnownIssue;
                }
            } else {

                // 20121220
                //CurrentTestResult.enStatus = TestResultStatuses.NotTested;
                currentTestResult.enStatus = TestResultStatuses.NotTested;
            }
            
            if (testResultDescription != null &&
                testResultDescription != string.Empty &&
                testResultDescription.Length > 0){
    
                // 20121220
                //CurrentTestResult.Description = testResultDescription;
                currentTestResult.Description = testResultDescription;

            }
            
            if (generated) {
                
                // 20121220
                //CurrentTestResult.SetGenerated();
                currentTestResult.SetGenerated();
            }

            // 20121224
//            if (TestData.TestSuites.Count == 0) {
//                InitTestData();
//            }
            if (TMXHelper.TestCaseStarted == System.DateTime.MinValue) {

                TMXHelper.TestCaseStarted = System.DateTime.Now;
            }
            
            // scenarioId and suiteId
//            TestData.CurrentTestResult.SuiteId = TestData.TestSuites[TestData.TestSuites.Count - 1].Id;
//            TestData.CurrentTestResult.ScenarioId = 
//                TestData.TestSuites[TestData.TestSuites.Count - 1].TestScenarios[TestData.TestSuites[TestData.TestSuites.Count - 1].TestScenarios.Count - 1].Id;

            // 20121220
            //TestData.CurrentTestResult.SetNow();
            currentTestResult.SetNow();
            // 20121220
            //TestData.CurrentTestResult.SetTimeSpent(
            currentTestResult.SetTimeSpent(
                //(System.DateTime.Now - TMXHelper.TestCaseStarted).TotalSeconds);
                // 20121224
                //(TestData.CurrentTestResult.Timestamp - TMXHelper.TestCaseStarted).TotalSeconds);
                (currentTestResult.Timestamp - TMXHelper.TestCaseStarted).TotalSeconds);
            
//            // 20121224
//            if (null != TestData.CurrentTestResult) {
//                if (null != TestData.CurrentTestResult.Details && 0 < TestData.CurrentTestResult.Details.Count) {
//                    currentTestResult.Details = TestData.CurrentTestResult.Details;
//                }
//            }
            
            // 20121220
            TestData.CurrentTestResult = currentTestResult;
            
            TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1] = 
                TestData.CurrentTestResult;
            
//            TestData.CurrentTestResult.SetScript(scriptName);
//            TestData.CurrentTestResult.SetLineNumber(lineNumber);
//            TestData.CurrentTestResult.SetPosition(position);

            #region Test Result's PowerShell data
            if (myInvocation != null) {

                TestData.CurrentTestResult.SetScriptName(TMXHelper.GetScriptName(myInvocation));
                TestData.CurrentTestResult.SetLineNumber(TMXHelper.GetScriptLineNumber(myInvocation));
                TestData.CurrentTestResult.SetPosition(TMXHelper.GetPipelinePosition(myInvocation));
                if (((bool)passed && Preferences.LogScriptName_Passed) || (!(bool)passed && Preferences.LogScriptName_Failed)) {
                    TestData.CurrentTestResult.Code += 
                        "script name: " + 
                        TestData.CurrentTestResult.ScriptName;
                }
                if (((bool)passed && Preferences.LogLineNumber_Passed) || (!(bool)passed && Preferences.LogLineNumber_Failed)) {
                    TestData.CurrentTestResult.Code +=
                        "\r\nline number: " +
                        TestData.CurrentTestResult.LineNumber.ToString();
                }
                if (((bool)passed && Preferences.LogCode_Passed) || (!(bool)passed && Preferences.LogCode_Failed)) {
                    TestData.CurrentTestResult.Code +=
                        "\r\ncode:\r\n" +
                        myInvocation.Line;
                }
            }
            
            if (error != null) {

                TestData.CurrentTestResult.SetError(error);
            }
            #endregion Test Result's PowerShell data
                      
            //string firedTestResultId = TestData.CurrentTestResult.Id;
            var sourceTestResult = TestData.CurrentTestResult;

            SetScenarioStatus();

            SetSuiteStatus();

            if (generateNextResult) {

                // write current time
                TMXHelper.TestCaseStarted =
                    System.DateTime.Now;
                TestData.CurrentTestScenario.TestResults.Add(
                    new TestResult(
                       TestData.CurrentTestScenario.Id,
                       TestData.CurrentTestScenario.SuiteId));
                TestData.CurrentTestResult = 
                    TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1];
            } else {

                // write zero time
                TMXHelper.TestCaseStarted =
                    System.DateTime.MinValue;
                TestData.CurrentTestResult = null;
            }
            OnTMXNewTestResultClosed(sourceTestResult, null);
        }
        

        
        internal static void InitTestData()
        {
            TMXHelper.TestCaseStarted =
                System.DateTime.Now;
            
            // 20120926
            if (null == TestData.TestSuites) {
                TestData.TestSuites = new List<TestSuite>();
            }
            
            // check that at least one suite exists
            if (TestData.TestSuites.Count == 0) {
                TMXHelper.NewTestSuite(
                    "autogenerated",
                    GetTestSuiteId(),
                    "This suite has been created automatically");
            }
            
            // check that at least one scenario exists
            if (TestData.CurrentTestSuite.TestScenarios.Count == 0) {
                TMX.Commands.AddTMXTestScenarioCommand cmdlet = 
                    new TMX.Commands.AddTMXTestScenarioCommand();
                cmdlet.Name = "autogenerated";
                cmdlet.Id = GetTestScenarioId();
                cmdlet.Description = 
                    "This scenario has been created automatically";
                cmdlet.TestSuiteName = 
                    TestData.CurrentTestSuite.Name;
                cmdlet.TestSuiteId =
                    TestData.CurrentTestSuite.Id;
                TMXHelper.AddTestScenario(cmdlet);
            }
        }
        
        internal static void InitCurrentTestSuite()
        {
            if (null == TestData.CurrentTestSuite) {
                
                if (null == TestData.TestSuites) {
                    
                    TestData.InitTestData();
                } else {
                    
                    if (0 == TestData.TestSuites.Count) {
                        
                        TestData.AddTestSuite(
                            "autogenerated",
                            TestData.GetTestSuiteId(),
                            string.Empty);
                    }
                }
                
                TestData.CurrentTestSuite =
                    TestData.TestSuites[TestData.TestSuites.Count - 1];
            }
        }
        
        internal static void InitCurrentTestScenario()
        {
            if (null == TestData.CurrentTestSuite) {
                TestData.InitCurrentTestSuite();
            }
            
            if (null == TestData.CurrentTestScenario) {
                
                if (null == TestData.CurrentTestSuite.TestScenarios) {
                    
                    // that's impossible...
                    TestData.CurrentTestSuite.TestScenarios =
                        new List<ITestScenario>();
                    
                } 
//                else {
//
//                }
                
                if (0 == TestData.CurrentTestSuite.TestScenarios.Count) {
                    
                    TestData.AddTestScenario(
                        TestData.CurrentTestSuite,
                        "autogenerated",
                        TestData.GetTestScenarioId(),
                        string.Empty,
                        string.Empty,
                        string.Empty);
                }
                
                TestData.CurrentTestScenario =
                    (TestScenario)TestData.CurrentTestSuite.TestScenarios[
                        TestData.CurrentTestSuite.TestScenarios.Count - 1];
            }
        }
        
        internal static TestStat RefreshScenarioStatistics(TestScenario scenario)
        {
            TestStat ts = new TestStat();
            ts.All = scenario.TestResults.Count;
            foreach (TestResult tr in scenario.TestResults) {
                if (tr.enStatus == TestResultStatuses.Passed ||
                    tr.enStatus == TestResultStatuses.KnownIssue) {
                    ts.Passed++;
                    if (tr.enStatus == TestResultStatuses.KnownIssue){
                        ts.PassedButWithBadSmell++;
                    }
                }
                if (tr.enStatus == TestResultStatuses.Failed) {
                    ts.Failed++;
                }
                ts.TimeSpent += tr.TimeSpent;
            }
            ts.NotTested = 
                ts.All - 
                ts.Passed -
                ts.Failed;
            scenario.Statistics = ts;
            return ts;
        }
        
        internal static TestStat RefreshSuiteStatistics(TestSuite suite)
        {
            TestStat ts = new TestStat();
            foreach (TestScenario tsc in suite.TestScenarios) {
                RefreshScenarioStatistics(tsc);
                ts.All += tsc.Statistics.All;
                ts.Passed += tsc.Statistics.Passed;
                ts.Failed += tsc.Statistics.Failed;
                ts.NotTested += tsc.Statistics.NotTested;
                ts.TimeSpent += tsc.Statistics.TimeSpent;
                ts.PassedButWithBadSmell += tsc.Statistics.PassedButWithBadSmell;
            }
            suite.Statistics = ts;
            return ts;
        }
        
        internal static void SetScenarioStatus()
        {
            if (TestData.CurrentTestScenario != null) {
                foreach (TestResult testResult in TestData.CurrentTestScenario.TestResults) {
                    if (testResult.enStatus == TestResultStatuses.Failed) {
                        TestData.CurrentTestScenario.enStatus = TestScenarioStatuses.Failed;
                        return;
                    }
                    if (testResult.enStatus == TestResultStatuses.Passed ||
                        testResult.enStatus == TestResultStatuses.KnownIssue){
                        TestData.CurrentTestScenario.enStatus = TestScenarioStatuses.Passed;
                    }
                }
            }
            
            // set statistics
            RefreshScenarioStatistics(TestData.CurrentTestScenario);
            
//            // set time elapsed
//            TestData.CurrentTestScenario.SetTimeSpent(
//                TestData.CurrentTestScenario.TimeSpent +
//                TestData.CurrentTestResult.TimeSpent);
        }
        
        internal static void SetSuiteStatus()
        {
            if (TestData.CurrentTestSuite != null) {
                foreach (TestScenario scenario in TestData.CurrentTestSuite.TestScenarios) {
                    if (scenario.enStatus == TestScenarioStatuses.Failed) {
                        TestData.CurrentTestSuite.enStatus = TestSuiteStatuses.Failed;
                        return;
                    }
                    if (scenario.enStatus == TestScenarioStatuses.Passed) {
                        TestData.CurrentTestSuite.enStatus = TestSuiteStatuses.Passed;
                    }
                }
            }
            
            // set statistics
            RefreshSuiteStatistics(TestData.CurrentTestSuite);
            
//            // set time elapsed
//            TestData.CurrentTestSuite.SetTimeSpent(
//                TestData.CurrentTestSuite.TimeSpent +
//                TestData.CurrentTestResult.TimeSpent);
        }
        
        internal static string GetTestSuiteId()
        {
            string result = string.Empty;            
            
            // read the last id used and generate a new one
            int testNumber = 
                TestData.TestSuites.Count; // + 1;
            bool noValidId = true;
            do {
                foreach (TestSuite suite in TestData.TestSuites) {
                    if (suite.Id == testNumber.ToString()) {
                        testNumber++;
                    }
                }
                noValidId = false;
                result = testNumber.ToString();
            } while (noValidId);
            
            return result;
        }
        
        internal static string GetTestScenarioId()
        {
            string result = string.Empty;            
            
            // 20121220
            int scNumber = 0;
            if (null != TestData.TestSuites && 0 < TestData.TestSuites.Count) {
                
                if (null != TestData.CurrentTestSuite.TestScenarios) {
                    
                    // read the last used id and generate a new one
                    scNumber = 
                        TestData.CurrentTestSuite.TestScenarios.Count; // + 1;
                    bool noValidId = true;
                    do {
                        foreach (TestScenario scenario in TestData.CurrentTestSuite.TestScenarios) {
                            if (scenario.Id == scNumber.ToString()) {
                                scNumber++;
                            }
                        }
                        noValidId = false;
                        result = scNumber.ToString();
                    } while (noValidId);
                    
                    
                    
                } else {
                    
                    result = scNumber.ToString();
                }
                
                
            } else {
                
                result = scNumber.ToString();
            }
            
//            // read the last used id and generate a new one
//            int testNumber = 
//                TestData.CurrentTestSuite.TestScenarios.Count; // + 1;
//            bool noValidId = true;
//            do {
//                foreach (TestScenario scenario in TestData.CurrentTestSuite.TestScenarios) {
//                    if (scenario.Id == testNumber.ToString()) {
//                        testNumber++;
//                    }
//                }
//                noValidId = false;
//                result = testNumber.ToString();
//            } while (noValidId);
            
            return result;
        }
        
        internal static string GetTestResultId()
        {
            string result = string.Empty;
            
            // 20121220
            int testNumber = 0;
            if (null != TestData.TestSuites && 0 < TestData.TestSuites.Count) {
                
                if (null != TestData.CurrentTestScenario) {
                    
                    if (null != TestData.CurrentTestScenario.TestResults) {
                        
                        // read the last used id and generate a new one
                        testNumber = 
                            TestData.CurrentTestScenario.TestResults.Count; // + 1;
                        bool noValidId = true;
                        do {
                            foreach (TestResult testResult in TestData.CurrentTestScenario.TestResults) {
                                if (testResult.Id == testNumber.ToString()) {
                                    testNumber++;
                                }
                            }
                            noValidId = false;
                            result = testNumber.ToString();
                        } while (noValidId);
                        
                    } else {
                        
                        result = testNumber.ToString();
                        
                    }
                    
                } else {
                    
                    result = testNumber.ToString();
                    
                }
            } else {
                
                result = testNumber.ToString();
                
            }
            
//            // read the last used id and generate a new one
//            int testNumber = 
//                TestData.CurrentTestScenario.TestResults.Count; // + 1;
//            bool noValidId = true;
//            do {
//                foreach (TestResult testResult in TestData.CurrentTestScenario.TestResults) {
//                    if (testResult.Id == testNumber.ToString()) {
//                        testNumber++;
//                    }
//                }
//                noValidId = false;
//                result = testNumber.ToString();
//            } while (noValidId);
            
            return result;
        }
        
        internal static bool AttachTestResultCode()
        {
            bool result = false;
            
            
            
            return result;
        }
        
        internal static void AddTestResultTextDetail(object detail)
        {
            ITestResultDetail testResultDetail = 
                new TestResultDetail();
            
            if (TestData.TestSuites.Count == 0) {
                InitTestData();
            }
//            if (TMXHelper.TestCaseStarted == 0) {
//                TMXHelper.TestCaseStarted = System.DateTime.Now;
//            }
            
            testResultDetail.AddTestResultDetail(
                TestResultDetailTypes.Comment,
                detail.ToString());
            CurrentTestResult.Details.Add(testResultDetail);
            OnTMXNewTestResultDetailAdded(testResultDetail, null);
        }
        
        internal static void AddTestResultErrorDetail(ErrorRecord detail)
        {
            ITestResultDetail testResultDetail = 
                new TestResultDetail();
            
            if (TestData.TestSuites.Count == 0) {
                InitTestData();
            }
            
            testResultDetail.AddTestResultDetail(
                TestResultDetailTypes.ErrorRecord,
                detail);
            CurrentTestResult.Details.Add(testResultDetail);
        }
        
        internal static void AddTestResultScreenshotDetail(object detail)
        {
            ITestResultDetail testResultDetail = 
                new TestResultDetail();
            
            if (TestData.TestSuites.Count == 0) {
                InitTestData();
            }
            
            testResultDetail.AddTestResultDetail(
                TestResultDetailTypes.Screenshot,
                detail.ToString());
            CurrentTestResult.Details.Add(testResultDetail);
            CurrentTestResult.SetScreenshot(detail.ToString());
        }
        
        internal static bool AddTestSuite(string testSuiteName, 
                                          string testSuiteId,
                                          string testSuiteDesctiption)
        {
            bool result = false;
            if (testSuiteId == null || testSuiteId == string.Empty) {
                testSuiteId = 
                    GetTestSuiteId();
            }
            
            // 20121219
            if (null != GetTestSuite(testSuiteName, testSuiteId)) {
                // the suite requested wonät be duplicated, exit
                return false;
            }
            
            TestSuites.Add(new TestSuite(testSuiteName, testSuiteId));
            if (testSuiteDesctiption != null && testSuiteDesctiption != string.Empty) {
                TestData.TestSuites[TestSuites.Count - 1].Description = 
                    testSuiteDesctiption;
            }
            
            TestData.CurrentTestSuite = 
                TestData.TestSuites[TestSuites.Count - 1];
            
            if (TestData.CurrentTestSuite != null) {
                OnTMXNewTestSuiteCreated(TestData.CurrentTestSuite, new EventArgs()); //null);
            } else {
                //
            }
            result = true;
            return result;
        }
        
        internal static TestSuite GetTestSuite(string testSuiteName, string testSuiteId)
        {
            TestSuite result = null;

            // 20121219
            //if (testSuiteName != string.Empty) {
            if (null != testSuiteName && string.Empty != testSuiteName) {
                foreach (TestSuite testSuite in TestSuites) {
                    if (testSuite.Name == testSuiteName) {
                        
                        // id does not match
                        if (testSuiteId != string.Empty && 
                            testSuiteId != null &&
                            testSuiteId != testSuite.Id) {

                            // 201212119
                            //return result;
                            continue;
                        }
                        if (testSuiteId != string.Empty && 
                            testSuiteId != null &&
                            testSuiteId == testSuite.Id) {

                            result = testSuite;
                        }
                        if (testSuiteId == string.Empty || testSuiteId == null) {

                            result = testSuite;
                        }
                        if (result != null) {

                            return result;
                        }
                    }
                }
            }
            
            // 20121219
            //if (testSuiteId != string.Empty) {
            if (null != testSuiteId && string.Empty != testSuiteId) {
                foreach (TestSuite testSuite in TestSuites) {
                    if (testSuite.Id == testSuiteId) {

                        result = testSuite;
                        return result;
                    }
                }
            }
            return result;
        }
        
        internal static bool AddTestScenario(TestSuite testSuite,
                                             string testScenarioName,
                                             string testScenarioId,
                                             string testScenarioDescription,
                                             string testSuiteName,
                                             string testSuiteId)
        {
            bool result = false;
            
            // clean up the last empty test result
            // in the previous scenario
            if (TestData.CurrentTestScenario != null) {
                if (TestData.CurrentTestScenario.TestResults.Count > 0) {
                    if (TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1].Details.Count == 0 &&
                        TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1].Status == TestStateNotTested) {
                        TestData.CurrentTestScenario.TestResults.RemoveAt(TestData.CurrentTestScenario.TestResults.Count - 1);
                    }
                }
            }
            
//            if (testSuite != null) {
//                TestData.CurrentTestSuite = testSuite;
//            }
//            if (testSuite == null && testSuiteName != string.Empty) {
//                TestSuite testSuite2 = 
//                    GetTestSuite(testSuiteName, testSuiteId);
//                if (testSuite2 != null) {
//                    TestData.CurrentTestSuite = testSuite2;
////                } else {
////                    return result;
//                }
//            }
//            if (testSuite == null && testSuiteId != string.Empty) {
//                TestSuite testSuite3 = 
//                    GetTestSuite(testSuiteName, testSuiteId);
//                if (testSuite3 != null) {
//                    TestData.CurrentTestSuite = testSuite3;
////                } else {
////                    return result;
//                }
//            }

            if (testSuite != null) {
                TestData.CurrentTestSuite = testSuite;
            } else if (testSuite == null && 
                       testSuiteName != string.Empty &&
                       testSuiteName != null) {
                TestSuite testSuite2 = 
                    GetTestSuite(testSuiteName, testSuiteId);
                if (testSuite2 != null) {
                    TestData.CurrentTestSuite = testSuite2;
                }
            } else if (testSuite == null && 
                       testSuiteId != string.Empty &&
                       testSuiteId != null) {
                TestSuite testSuite3 = 
                    GetTestSuite(testSuiteName, testSuiteId);
                if (testSuite3 != null) {
                    TestData.CurrentTestSuite = testSuite3;
                }
            }
            
            if (TestData.CurrentTestSuite == null) {
                return result;
            }
            
//            if (TestData.CurrentTestSuite != null) {
//                testSuite = TestData.CurrentTestSuite; // ?????????????
//            } else {
//                return result;
//            }
            
            if (testScenarioId == null || testScenarioId == string.Empty) {
                testScenarioId = 
                    GetTestScenarioId();
            }

            TestData.CurrentTestSuite.TestScenarios.Add(
                new TestScenario(testScenarioName, testScenarioId, TestData.CurrentTestSuite.Id)); //testSuiteId));
            
            // description
            if (testScenarioDescription != null && testScenarioDescription != string.Empty) {
                TestData.CurrentTestSuite.TestScenarios[CurrentTestSuite.TestScenarios.Count - 1].Description = 
                    testScenarioDescription;
            }
            TestData.CurrentTestScenario = 
                (TestScenario)TestData.CurrentTestSuite.TestScenarios[CurrentTestSuite.TestScenarios.Count - 1];
            OnTMXNewTestScenarioAdded(TestData.CurrentTestScenario, null);
            result = true;
            return result;
        }
        
        internal static TestScenario GetTestScenario(TestSuite testSuite, 
                                                     string testScenarioName, 
                                                     string testScenarioId,
                                                     string testSuiteName,
                                                     string testSuiteId)
        {
            TestScenario result = null;
            
//            if (testSuite != null) {
//                TestData.CurrentTestSuite = testSuite;
//            } else {
//                testSuite = GetTestSuite(testSuiteName, testSuiteId);
//                TestData.CurrentTestSuite = testSuite;
//            }
//            
//            if (testSuite == null) {
//                //return result;
//                if (TestData.CurrentTestSuite != null) {
//                    testSuite = TestData.CurrentTestSuite; // ?????????????
//                } else {
//                    return result;
//                }
//            }
            
            if (testSuite != null) {
                TestData.CurrentTestSuite = testSuite;
            } else if (testSuite == null && 
                       testSuiteName != string.Empty &&
                       testSuiteName != null) {
                TestSuite testSuite2 = 
                    GetTestSuite(testSuiteName, testSuiteId);
                if (testSuite2 != null) {
                    TestData.CurrentTestSuite = testSuite2;
                }
            } else if (testSuite == null && 
                       testSuiteId != string.Empty &&
                       testSuiteId != null) {
                TestSuite testSuite3 = 
                    GetTestSuite(testSuiteName, testSuiteId);
                if (testSuite3 != null) {
                    TestData.CurrentTestSuite = testSuite3;
                }
            }
            
            if (TestData.CurrentTestSuite == null) {
                return result;
            }
            
            if (testScenarioName != null && testScenarioName != string.Empty) {
                foreach (TestScenario testScenario in TestData.CurrentTestSuite.TestScenarios) {
                    if (testScenario.Name == testScenarioName) {
                        TestData.CurrentTestScenario = testScenario;
                        return testScenario;
                    }
                }
            }
            
            if (testScenarioId != null && testScenarioId != string.Empty) {
                foreach (TestScenario testScenario in TestData.CurrentTestSuite.TestScenarios) {
                    if (testScenario.Id == testScenarioId) {
                        TestData.CurrentTestScenario = testScenario;
                        return testScenario;
                    }
                }
            }

            return result;
        }
        
        internal static System.Linq.IOrderedEnumerable<TMX.TestSuite> SearchTestSuite(
        //internal static System.Linq.IQueryable<TMX.TestSuite> SearchTestSuite(
            Func<TestSuite, bool> query,
            //Func<TestSuite, object[]> ordering,
            Func<TestSuite, object> ordering,
            bool desc) //,
            //int count)
        {
            IOrderedEnumerable<TestSuite> result = null;
            //IQueryable<TestSuite> result = null;
            
            if (desc) {
                result =
                    from suite in TestData.TestSuites
                    where query(suite)
                    orderby ordering(suite) descending
                    select suite;
            } else {
                result =
                    from suite in TestData.TestSuites
                    where query(suite)
                    orderby ordering(suite) ascending
                    select suite;
            }
            return result;
        }
        
        private static System.Collections.Generic.List<TestScenario> getAllScenarios()
        {
            List<TestScenario> result = new List<TestScenario>();
            foreach (TestSuite suite in TestData.TestSuites) {
                foreach (TestScenario scenario in suite.TestScenarios) {
                    result.Add(scenario);
                }
            }
            return result;
        }
        
        internal static System.Linq.IOrderedEnumerable<TMX.TestScenario> SearchTestScenario(
            Func<TestScenario, bool> query,
            Func<TestScenario, object> ordering,
            bool desc) //,
            //int count)
        {
            IOrderedEnumerable<TestScenario> result = null;
            
            if (desc) {
                result =
                    from scenario in getAllScenarios()
                    where query(scenario)
                    orderby ordering(scenario) descending
                    select scenario;
            } else {
                result =
                    from scenario in getAllScenarios()
                    where query(scenario)
                    orderby ordering(scenario) ascending
                    select scenario;
            }
            
            return result;
        }
        
        private static System.Collections.Generic.List<TestResult> getAllTestResults()
        {
            List<TestResult> result = new List<TestResult>();
            foreach (TestSuite suite in TestData.TestSuites) {
                foreach (TestScenario scenario in suite.TestScenarios) {
                    foreach (TestResult testResult in scenario.TestResults) {
                        result.Add(testResult);
                    }
                }
            }
            return result;
        }
        
        internal static System.Linq.IOrderedEnumerable<TMX.TestResult> SearchTestResult(
            Func<TestResult, bool> query,
            Func<TestResult, object> ordering,
            bool desc) //,
            //int count)
        {
            IOrderedEnumerable<TestResult> result = null;
            
            if (desc) {
                result =
                    from testResult in getAllTestResults()
                    where query(testResult)
                    orderby ordering(testResult) descending
                    select testResult;
            } else {
                result =
                    from testResult in getAllTestResults()
                    where query(testResult)
                    orderby ordering(testResult) ascending
                    select testResult;
            }
            return result;
        }
    }
}