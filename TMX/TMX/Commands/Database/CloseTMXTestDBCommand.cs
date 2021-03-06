﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/8/2012
 * Time: 2:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of CloseTMXTestDBCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Close, "TMXTestDB")]
    [OutputType(typeof(bool))]
    public class CloseTMXTestDBCommand : DatabaseFileCmdletBase
    {
        public CloseTMXTestDBCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new string FileName { get; set; }
        #endregion Parameters
        
        //protected override void BeginProcessing()
        protected override void ProcessRecord()
        {
            // check input
            //if (! this.StructureDB && ! this.ResultsDB) {
            //    this.StructureDB = true;
            //    this.ResultsDB = true;
            //}
            
            SQLiteHelper.CloseDatabase(this, this.Name);
        }
    }
}
