﻿using UIAutomation.Commands;
/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 29.11.2011
 * Time: 14:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    using System.Windows.Automation.Text;

    /// <summary>
    /// Description of PatternCmdletBase.
    /// </summary>
    //[Cmdlet(VerbsCommon.Set, "PatternCmdletBase")]
    //[Cmdlet]
    public class PatternCmdletBase : HasControlInputCmdletBase
    {
        #region Constructor
        public PatternCmdletBase()
        {
        }
        #endregion Constructor

        #region Parameters
        #endregion Parameters
        
        #region Properties
        protected string WhatToDo { get; set; }
        protected new PatternCmdletBase Child { get; set; }
        #endregion Properties
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!this.CheckControl(this)) { return; }
            
            
            System.Windows.Automation.AutomationElement _control = null;
            
            // 20120824
            foreach (AutomationElement inputObject in this.InputObject) {
                
                try {
                    _control =
                        // 20120824
                        //(System.Windows.Automation.AutomationElement)InputObject;
                        //(AutomationElement)InputObject[0];
                        inputObject;
                } catch (Exception eControlTypeException) {
                    WriteDebug("PatternCmdletBase: Control is not an AutomationElement");
                    WriteDebug("PatternCmdletBase: " + eControlTypeException.Message);
                    WriteObject(this, false);
                    return;
                }
                switch (WhatToDo)
                {
                        // not yet implemented
                        // case "Dock":
                        // pattern =
                        // (System.Windows.Automation.DockPattern)pt;
                        // break;
                    case "Expand":
                        
                        InvokeExpand(ref _control, inputObject);
                        break;
                    case "Collapse":
                        
                        InvokeCollapse(ref _control, inputObject);
                        break;
                    case "GridItem":
                        
                        InvokeGridItem(ref _control, inputObject);
                        break;
                        // not yet implemented
                    case "Grid":
                        
                        InvokeGrid(ref _control, inputObject);
                        
                        break;
                    case "Invoke":
                        
                        InvokeInvoke(ref _control, inputObject);
                        break;
                        // not yet implemented
                        // case "MultipleView":
                        // pattern =
                        // (System.Windows.Automation.MultipleViewPattern)pt;
                        // break;
                    case "RangeValueGet":
                        
                        InvokeRangeValueGet(ref _control, inputObject);
                        break;
                    case "RangeValueSet":
                        
                        InvokeRangeValueSet(ref _control, inputObject);
                        break;
                    case "ScrollItem":
                        
                        InvokeScrollItem(ref _control, inputObject);
                        break;
                    case "Scroll":
                        
                        InvokeScroll(ref _control, inputObject);
                        break;
                    case "SelectionItem":
                        
                        InvokeSelectionItem(ref _control, inputObject);
                        break;
                    case "SelectionItemState":
                        
                        InvokeSelectionItemState(ref _control, inputObject);
                        break;
                        // 20130108
                    case "SelectedItem": // return only elements that are selected
                        
                        InvokeSelectedItem(ref _control, inputObject);
                        break;
                    case "Selection":
                        
                        InvokeSelection(ref _control, inputObject);
                        break;
                        // not yet implemented
                    case "TableItem":
                        
                        InvokeTableItem(ref _control, inputObject);
                        // pattern =
                        // (System.Windows.Automation.TableItemPattern)pt;
                        break;
                        // not yet implemented
                    case "Table":
                        
                        InvokeTable(ref _control, inputObject);
                        // pattern =
                        // (System.Windows.Automation.TablePattern)pt;
                        break;
                        // not yet implemented
                        //case "Text":
                    case "TextGet":
                        // pattern =
                        // (System.Windows.Automation.TextPattern)pt;
                        // break;
                        
                        InvokeTextGet(ref _control, inputObject);
                        break;
                    case "TextSet":
                        
                        InvokeTextSet(ref _control, inputObject);
                        break;
                    case "Toggle":
                        
                        InvokeToggle(ref _control, inputObject);
                        break;
                    case "ToggleState":
                        
                        InvokeToggleState(ref _control, inputObject);
                        break;
                    case "TransformMove":
                        
                        InvokeTransformMove(ref _control, inputObject);
                        break;
                    case "TransformResize":
                        
                        InvokeTransformResize(ref _control, inputObject);
                        break;
                    case "TransformRotate":
                        
                        InvokeTransformRotate(ref _control, inputObject);
                        break;
                    case "ValueGet":
                        
                        InvokeValueGet(ref _control, inputObject);
                        break;
                    case "ValueSet":
                        
                        InvokeValueSet(ref _control, inputObject);
                        break;
                    case "Window":
                        
                        InvokeWindow(_control, inputObject);
                        break;
                    case "Annotation":
                        WriteVerbose(this, "Annotation");
                        break;
                    case "Drag":
                        WriteVerbose(this, "Drag");
                        break;
                    case "DropTarget":
                        WriteVerbose(this, "DropTarget");
                        break;
                    case "ItemContainer":
                        WriteVerbose(this, "ItemContainer");
                        break;
                    case "LegacyIAccessible":
                        WriteVerbose(this, "LegacyIAccessible");
                        break;
                    case "ObjectModel":
                        WriteVerbose(this, "ObjectModel");
                        break;
                    case "Spreadsheet":
                        WriteVerbose(this, "Spreadsheet");
                        break;
                    case "SpreadsheetItem":
                        WriteVerbose(this, "SpreadsheetItem");
                        break;
                    case "Styles":
                        WriteVerbose(this, "Styles");
                        break;
                    case "SynchronizedInput":
                        WriteVerbose(this, "SynchronizedInput");
                        break;
                    case "TextChild":
                        WriteVerbose(this, "TextChild");
                        break;
                    case "VirtualizedItem":
                        WriteVerbose(this, "VirtualizedItem");
                        break;
                }
                ////return;
                
                
                // 2012/04/10
                //            Annotation Control Pattern
                //            Dock Control Pattern
                //            Drag Control Pattern
                //            DropTarget Control Pattern
                //            ExpandCollapse Control Pattern
                //            Grid Control Pattern
                //            GridItem Control Pattern
                //            Invoke Control Pattern
                //            ItemContainer Control Pattern
                //            LegacyIAccessible Control Pattern
                //            MultipleView Control Pattern
                //            ObjectModel Control Pattern
                //            RangeValue Control Pattern
                //            Scroll Control Pattern
                //            ScrollItem Control Pattern
                //            Selection Control Pattern
                //            SelectionItem Control Pattern
                //            Spreadsheet Control Pattern
                //            SpreadsheetItem Control Pattern
                //            Styles Control Pattern
                //            SynchronizedInput Control Pattern
                //            Table Control Pattern
                //            TableItem Control Pattern
                //            Text and TextRange Control Patterns
                //            TextChild Control Pattern
                //            Toggle Control Pattern
                //            Transform Control Pattern
                //            Value Control Pattern
                //            VirtualizedItem Control Pattern
                //            Window Control Pattern
                
                
            } //20120824
        }

        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        //writev
        internal void InvokeWindow(System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                WindowPattern windowPattern = _control.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern;
                if (windowPattern != null) {

                    // Close windowPattern.Close
                    // get windowPattern.Current.CanMaximize
                    // get windowPattern.Current.CanMinimize
                    // get windowPattern.Current.IsModal
                    // get windowPattern.Current.IsTopmost
                    // get windowPattern.Current.WindowInteractionState
                    // get windowPattern.Current.WindowVisualState
                    // set windowPattern.SetWindowVisualState(WindowVisualState.Maximized
                    // set windowPattern.SetWindowVisualState(WindowVisualState.Mini
                    // set windowPattern.SetWindowVisualState(WindowVisualState.Normal
                    // invoke windowPattern.WaitForInputIdle(int ms)
                    
                    windowPattern.SetWindowVisualState(WindowVisualState.Minimized);
                    System.Threading.Thread.Sleep(1000);
                    windowPattern.SetWindowVisualState(WindowVisualState.Normal);
                    windowPattern.WaitForInputIdle(1000);
                    System.Threading.Thread.Sleep(1000);
                    windowPattern.SetWindowVisualState(WindowVisualState.Minimized);
                    System.Threading.Thread.Sleep(1000);
                    windowPattern.SetWindowVisualState(WindowVisualState.Normal);
                    if (this.PassThru && null != (inputObject as AutomationElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                } else {
                    WriteVerbose(this, "couldn't get WindowPattern");
                    WriteObject(this, false);
                }
            } catch (Exception eWindowPatternException) {
            }
        }

        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        //writev
        internal void InvokeValueSet(ref System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                ValuePattern valuePatternSet = _control.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                if (valuePatternSet != null) {
                    valuePatternSet.SetValue(((Commands.InvokeUIAValuePatternSetCommand)Child).Text);
                    if (this.PassThru && null != (inputObject as AutomationElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                } else {
                    WriteVerbose(this, "couldn't get ValuePattern. SendKeys is used");
                    _control.SetFocus();
                    System.Windows.Forms.SendKeys.SendWait(((Commands.InvokeUIAValuePatternSetCommand)Child).Text);
                    if (this.PassThru && null != (inputObject as AutomationElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                }
            } catch (Exception eValueSetPatternException) {
            }
        }

        //if (this.PassThru && CheckControl(this)) {
        //    WriteObject(this, inputObject);
        //} else {
        //    //WriteObject(this, true);
        //}
        //writev
        internal void InvokeValueGet(ref System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                ValuePattern valuePatternGet = _control.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                object result = null;
                if (valuePatternGet != null) {
                    result = valuePatternGet.Current.Value;
                    WriteVerbose(this, "the result is " + result);
                    WriteObject(this, result);
                } else {
                    WriteVerbose(this, "couldn't get ValuePattern");
                    WriteObject(this, result);
                }
            } catch (Exception eValueGetPatternException) {
            }
        }

        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        //writev
        internal void InvokeTransformRotate(ref System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                TransformPattern transformRotatePattern = _control.GetCurrentPattern(TransformPattern.Pattern) as TransformPattern;
                if (transformRotatePattern != null) {
                    transformRotatePattern.Rotate(((Commands.InvokeUIATransformPatternRotateCommand)Child).TransformRotateDegrees);
                    if (this.PassThru && null != (inputObject as AutomationElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                } else {
                    WriteVerbose(this, "couldn't get TransformPattern");
                    WriteObject(this, false);
                }
            } catch (Exception eTransformRotatePatternException) {
            }
        }

        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        //writev
        internal void InvokeTransformResize(ref System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                TransformPattern transformResizePattern = _control.GetCurrentPattern(TransformPattern.Pattern) as TransformPattern;
                if (transformResizePattern != null) {
                    transformResizePattern.Resize(((Commands.InvokeUIATransformPatternResizeCommand)Child).TransformResizeWidth, ((Commands.InvokeUIATransformPatternResizeCommand)Child).TransformResizeHeight);
                    if (this.PassThru && null != (inputObject as AutomationElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                } else {
                    WriteVerbose(this, "couldn't get TransformPattern");
                    WriteObject(this, false);
                }
            } catch (Exception eTransformResizePatternException) {
            }
        }

        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        //writev
        internal void InvokeTransformMove(ref System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                TransformPattern transformMovePattern = _control.GetCurrentPattern(TransformPattern.Pattern) as TransformPattern;
                if (transformMovePattern != null) {
                    transformMovePattern.Move(((Commands.InvokeUIATransformPatternMoveCommand)Child).TransformMoveX, ((Commands.InvokeUIATransformPatternMoveCommand)Child).TransformMoveY);
                    if (this.PassThru && null != (inputObject as AutomationElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                } else {
                    WriteVerbose(this, "couldn't get TransformPattern");
                    WriteObject(this, false);
                }
            } catch (Exception eTransformMovePatternException) {
            }
        }

        //writev
        internal void InvokeToggleState(ref System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                TogglePattern togglePattern1 = _control.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                if (togglePattern1 != null) {
                    bool toggleState = false;
                    if (togglePattern1.Current.ToggleState == ToggleState.On) {
                        toggleState = true;
                    }
                    WriteObject(this, toggleState);
                } else {
                    WriteVerbose(this, "couldn't get TogglePattern");
                    WriteObject(this, false);
                }
            } catch (Exception eToggleStatePatternException) {
            }
        }

        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        //writev
        internal void InvokeToggle(ref System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                TogglePattern togglePattern = _control.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                if (togglePattern != null) {
                    togglePattern.Toggle();
                    if (this.PassThru && null != (inputObject as AutomationElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                } else {
                    WriteVerbose(this, "couldn't get TogglePattern");
                    WriteObject(this, false);
                }
            } catch (Exception eTogglePatternException) {
            }
        }

        //writev
        internal void InvokeTextSet(ref System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                TextPattern textPatternSet = _control.GetCurrentPattern(TextPattern.Pattern) as TextPattern;
                if (textPatternSet != null) {
                    textPatternSet.GetSelection().SetValue(((Commands.InvokeUIATextPatternSetCommand)this).Text, 0);
                    WriteObject(this, true);
                } else {
                    WriteVerbose(this, "couldn't get TextPattern");
                    WriteObject(this, false);
                }
            } catch (Exception eTextSetPatternException) {
            }
        }

        // textPattern.DocumentRange.// temporarily
        //string resultText = string.Empty;
        //writev
        internal void InvokeTextGet(ref System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                TextPattern textPatternGet = _control.GetCurrentPattern(TextPattern.Pattern) as TextPattern;
                if (textPatternGet != null) {
                    int textLength = ((Commands.InvokeUIATextPatternGetCommand)this).TextLength;
                    if (((Commands.InvokeUIATextPatternGetCommand)this).VisibleArea) {
                        TextPatternRange[] textRanges = textPatternGet.GetVisibleRanges();
                        for (int i = 0; i < textRanges.Length; i++) {
                            WriteObject(this, textRanges[i]);
                        }
                    } else {
                        string resultText = textPatternGet.DocumentRange.GetText(textLength);
                        WriteObject(this, resultText);
                    }
                } else {
                    WriteVerbose(this, "couldn't get TextPattern");
                    WriteObject(this, false);
                }
            } catch (Exception eTextGetPatternException) {
            }
        }

        //tablePattern.GetItem

        internal void InvokeTable(ref System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                TablePattern tablePattern = _control.GetCurrentPattern(TablePattern.Pattern) as TablePattern;
                if (tablePattern != null) {
                }
            } catch (Exception eTablePatternException) {
            }
        }

        //tableItemPattern.Current.

        internal void InvokeTableItem(ref System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                TableItemPattern tableItemPattern = _control.GetCurrentPattern(TableItemPattern.Pattern) as TableItemPattern;
                if (tableItemPattern != null) {
                }
            } catch (Exception eTableItemPatternException) {
            }
        }

        // 20130108
        // deleted as useless
        //                            if (this.PassThru && CheckControl(this)) {
        //                                WriteObject(this, inputObject);
        //                            //} else {
        //                            // WriteObject(this, true);
        //                            }
        //writev
        internal void InvokeSelection(ref System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                SelectionPattern selPattern = _control.GetCurrentPattern(SelectionPattern.Pattern) as SelectionPattern;
                if (selPattern != null) {
                    System.Windows.Automation.AutomationElement[] selection = selPattern.Current.GetSelection();
                    WriteObject(this, selection);
                } else {
                    WriteVerbose(this, "couldn't get SelectionPattern");
                    WriteObject(this, false);
                }
            } catch (Exception eSelectionPatternException) {
            }
        }

        //WriteObject(this, selItemPattern1.Current.IsSelected);
        //                        else{
        //                            WriteVerbose(this, "couldn't get SelectionItemPattern");
        //                            WriteObject(this, false);
        //                        }
        //writev
        internal void InvokeSelectedItem(ref System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                SelectionItemPattern selItemPattern1 = _control.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                if (selItemPattern1 != null) {
                    if (selItemPattern1.Current.IsSelected) {
                        WriteObject(this, InputObject);
                    }
                }
            } catch (Exception eSeleItemStatePatternException) {
            }
        }

        //writev
        internal void InvokeSelectionItemState(ref System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                SelectionItemPattern selItemPattern1 = _control.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                if (selItemPattern1 != null) {
                    WriteObject(this, selItemPattern1.Current.IsSelected);
                } else {
                    WriteVerbose(this, "couldn't get SelectionItemPattern");
                    WriteObject(this, false);
                }
            } catch (Exception eSeleItemStatePatternException) {
            }
        }

        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        //writev
        internal void InvokeSelectionItem(ref System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                SelectionItemPattern selItemPattern = _control.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                if (selItemPattern != null) {
                    selItemPattern.Select();
                    if (this.PassThru && null != (inputObject as AutomationElement)) {
                        try {
                            SelectionPattern selPatternTemp = _control.GetCurrentPattern(SelectionPattern.Pattern) as SelectionPattern;
                            if (selPatternTemp != null) {
                                AutomationElement[] selection = selPatternTemp.Current.GetSelection();
                                WriteObject(this, selection);
                            } else {
                                WriteObject(this, true);
                            }
                        } catch {
                        }
                    } else {
                        WriteObject(this, true);
                    }
                } else {
                    WriteVerbose(this, "couldn't get SelectionItemPattern");
                    WriteObject(this, false);
                }
            } catch (Exception eSelePatternException) {
            }
        }

        //                                if (((InvokeUIAScrollPatternCommand)this).Large) {
        //                                    System.Windows.Automation.ScrollAmount.LargeIncrement = (System.Windows.Automation.ScrollAmount)10;
        //                                } else {
        //                                    System.Windows.Automation.ScrollAmount.SmallIncrement = (System.Windows.Automation.ScrollAmount)1;
        //                                }
        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        internal void InvokeScroll(ref System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                ScrollPattern scPattern = _control.GetCurrentPattern(ScrollPattern.Pattern) as ScrollPattern;
                if (scPattern != null) {
                    try {
                        bool horizontal = ((InvokeUIAScrollPatternCommand)this).Horizontal;
                        bool vertical = ((InvokeUIAScrollPatternCommand)this).Vertical;
                        int horPercent = ((InvokeUIAScrollPatternCommand)this).HorizontalPercent;
                        int verPercent = ((InvokeUIAScrollPatternCommand)this).VerticalPercent;
                        System.Windows.Automation.ScrollAmount horAmount, verAmount = System.Windows.Automation.ScrollAmount.NoAmount;
                        horAmount = (System.Windows.Automation.ScrollAmount)((InvokeUIAScrollPatternCommand)this).HorizontalAmount;
                        verAmount = (System.Windows.Automation.ScrollAmount)((InvokeUIAScrollPatternCommand)this).VerticalAmount;
                        if ((horPercent + verPercent) > 0) {
                            scPattern.SetScrollPercent(horPercent, verPercent);
                        }
                        if (horizontal) {
                            if (horAmount > 0) {
                                scPattern.ScrollHorizontal(horAmount);
                            }
                        }
                        if (vertical) {
                            if (verAmount > 0) {
                                scPattern.ScrollVertical(verAmount);
                            }
                        }
                        if (this.PassThru && null != (inputObject as AutomationElement)) {
                            WriteObject(this, inputObject);
                        } else {
                            WriteObject(this, true);
                        }
                    } catch {
                        WriteObject(this, false);
                    }
                }
            } catch {
                WriteObject(this, false);
            }
        }

        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        internal void InvokeScrollItem(ref System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                ScrollItemPattern sciPattern = _control.GetCurrentPattern(ScrollItemPattern.Pattern) as ScrollItemPattern;
                if (sciPattern != null) {
                    try {
                        sciPattern.ScrollIntoView();
                        if (this.PassThru && null != (inputObject as AutomationElement)) {
                            WriteObject(this, inputObject);
                        } else {
                            WriteObject(this, true);
                        }
                    } catch {
                        WriteObject(this, false);
                    }
                }
            } catch {
                WriteObject(this, false);
            }
        }

        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        //writev
        internal void InvokeRangeValueSet(ref System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                RangeValuePattern rvPatternSet = _control.GetCurrentPattern(RangeValuePattern.Pattern) as RangeValuePattern;
                if (rvPatternSet != null) {
                    try {
                        rvPatternSet.SetValue(((Commands.InvokeUIARangeValuePatternSetCommand)Child).Value);
                        if (this.PassThru && null != (inputObject as AutomationElement)) {
                            WriteObject(this, inputObject);
                        } else {
                            WriteObject(this, true);
                        }
                    } catch {
                        WriteObject(this, false);
                    }
                }
            } catch (Exception eRVSetPatternException) {
            }
        }

        // if (this.PassThru && CheckControl(this)) {
        // WriteObject(inputObject);
        //} else {
        // WriteObject(true);
        //}
        //writev
        internal void InvokeRangeValueGet(ref System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                RangeValuePattern rvPatternGet = _control.GetCurrentPattern(RangeValuePattern.Pattern) as RangeValuePattern;
                if (rvPatternGet != null) {
                    WriteObject(this, rvPatternGet.Current.Value);
                }
            } catch (Exception eRVGetPatternException) {
            }
        }


        // 20130109
        //if (this.PassThru && CheckControl(this)) {



        // 20130105

        //this.RightClick,
        //this.MidClick,
        //this.Alt,
        //this.Shift,
        //this.Ctrl,
        //this.DoubleClick,
        //this.X,
        //this.Y);
        //if (this.PassThru) {
        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        // 20130105
        //this.WriteObject(this, this.InputObject);




        //this.RightClick,
        //this.MidClick,
        //this.Alt,
        //this.Shift,
        //this.Ctrl,
        //this.DoubleClick,
        //this.X,
        //this.Y);
        //if (this.PassThru) {
        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        internal void InvokeInvoke(ref System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                InvokePattern invokePattern = _control.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                if (invokePattern != null) {

                    invokePattern.Invoke();

                    if (this.PassThru && null != (inputObject as AutomationElement)) {

                        WriteObject(this, inputObject);

                    } else {

                        WriteObject(this, true);

                    }
                } else {

                    if (Preferences.PerformWin32ClickOnFail) {

                        ClickControl(this, _control, false, false, false, false, false, false, false, 0,
                                     0);

                        if (this.PassThru && null != (inputObject as AutomationElement)) {

                            this.WriteObject(this, inputObject);

                        } else {

                            this.WriteObject(this, true);

                        }
                    } else {

                        WriteVerbose(this, "couldn't get InvokePattern");

                        WriteObject(this, false);

                    }
                }
            } catch (Exception eInvokePatternException) {

                this.WriteVerbose(this, eInvokePatternException.Message + "\r\n" + eInvokePatternException.GetType().Name);
                if (Preferences.PerformWin32ClickOnFail &&
                    "ElementNotAvailableException" != eInvokePatternException.GetType().Name) {

                    ClickControl(this, _control, false, false, false, false, false, false, false, 0,
                                 0);

                    if (this.PassThru && null != (inputObject as AutomationElement)) {

                        this.WriteObject(this, inputObject);

                    } else {

                        this.WriteObject(this, true);

                    }
                } else {

                }
                // no reaction

            }
        }

        //gridPattern.GetItem

        // GridPattern gridPattern =
        // _control.GetCurrentPattern(GridPattern.Pattern)
        // as GridPattern;
        // if (gridPattern != null)
        // {
        //  // invokePattern.Invoke();
        //  // gridPattern.Current.RowCount
        //  // gridPattern.Current.ColumnCount
        //  // gridPattern.GetItem(int row, int column);
        // WriteObject(true);
        // }
        // else{
        // WriteVerbose(this, "couldn't get GridPattern");
        // WriteObject(false);
        // }
        internal void InvokeGrid(ref System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                GridPattern gridPattern = _control.GetCurrentPattern(GridPattern.Pattern) as GridPattern;
                if (gridPattern != null) {
                }
            } catch (Exception eGridPatternException) {
            }
        }

        //gridItemPattern.Current.

        // not yet implemented
        // GridItemPattern giPattern =
        // _control.GetCurrentPattern(GridItemPattern.Pattern)
        // as GridItemPattern;
        // 
        // giPattern.Current.
        internal void InvokeGridItem(ref System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                GridItemPattern gridItemPattern = _control.GetCurrentPattern(GridItemPattern.Pattern) as GridItemPattern;
                if (gridItemPattern != null) {
                }
            } catch (Exception eGridItemPatternException) {
            }
        }

        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        //writev
        internal void InvokeCollapse(ref System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                ExpandCollapsePattern collapsePattern = _control.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
                if (collapsePattern != null) {
                    collapsePattern.Collapse();
                    if (this.PassThru && null != (inputObject as AutomationElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                } else {
                    WriteVerbose(this, "couldn't get ExpandCollapsePattern");
                    WriteObject(this, false);
                }
            } catch (Exception eCollPatternException) {
            }
        }

        // 20130109
        //if (this.PassThru && CheckControl(this)) {
        //writev
        //writev
        internal void InvokeExpand(ref System.Windows.Automation.AutomationElement _control, AutomationElement inputObject)
        {
            try {
                ExpandCollapsePattern expandPattern = _control.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
                if (expandPattern != null) {
                    expandPattern.Expand();
                    if (this.PassThru && null != (inputObject as AutomationElement)) {
                        WriteObject(this, inputObject);
                    } else {
                        WriteObject(this, true);
                    }
                } else {
                    WriteVerbose(this, "couldn't get ExpandCollapsePattern");
                    WriteObject(this, false);
                }
            } catch (Exception eExpPatternException) {
            }
        }
        
        protected override void EndProcessing()
        {
            this.Child = null;
        }
    }
}