namespace VSMinifier
{
	partial class OptionControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose ( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose( );
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ( )
		{
			this.TabControl = new System.Windows.Forms.TabControl();
			this.CommonTab = new System.Windows.Forms.TabPage();
			this.CTGroup = new System.Windows.Forms.GroupBox();
			this.CTManual = new System.Windows.Forms.CheckBox();
			this.CTMixed = new System.Windows.Forms.RadioButton();
			this.CTDefault = new System.Windows.Forms.RadioButton();
			this.BAGroup = new System.Windows.Forms.GroupBox();
			this.BACustomMinified = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.BACustomOriginal = new System.Windows.Forms.ComboBox();
			this.BACustom = new System.Windows.Forms.RadioButton();
			this.BACopy = new System.Windows.Forms.RadioButton();
			this.BADefault = new System.Windows.Forms.RadioButton();
			this.JSTab = new System.Windows.Forms.TabPage();
			this.JSYUI = new System.Windows.Forms.GroupBox();
			this.JSYDisableOptimizations = new System.Windows.Forms.CheckBox();
			this.JSYPreserveAllSemicolons = new System.Windows.Forms.CheckBox();
			this.JSYObfuscateJavascript = new System.Windows.Forms.CheckBox();
			this.JSGoogle = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.JSGCompilationLevel = new System.Windows.Forms.ComboBox();
			this.JSMsMinifier = new System.Windows.Forms.GroupBox();
			this.JSMsRemoveFunctionExpressionNames = new System.Windows.Forms.CheckBox();
			this.JSMsPreserveFunctionNames = new System.Windows.Forms.CheckBox();
			this.JSMsRemoveUnneededCode = new System.Windows.Forms.CheckBox();
			this.JSMsPreserveImportantComments = new System.Windows.Forms.CheckBox();
			this.JSMsOutputMode = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.JSMsLocalRename = new System.Windows.Forms.ComboBox();
			this.JSEngine = new System.Windows.Forms.ComboBox();
			this.JSEngLabel = new System.Windows.Forms.Label();
			this.JSExt = new System.Windows.Forms.TextBox();
			this.JSMinExtLabel = new System.Windows.Forms.Label();
			this.CSSTab = new System.Windows.Forms.TabPage();
			this.CSSYUI = new System.Windows.Forms.GroupBox();
			this.CSSYRemoveComments = new System.Windows.Forms.CheckBox();
			this.CSSMsMinifier = new System.Windows.Forms.GroupBox();
			this.CSSMsOutputMode = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.CSSMsCssType = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.CSSMsMinifyExpressions = new System.Windows.Forms.CheckBox();
			this.CSSMsCommentMode = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.CSSMsColorNames = new System.Windows.Forms.ComboBox();
			this.CSSEngine = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.CSSExt = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.HelpText = new System.Windows.Forms.RichTextBox();
			this.TabControl.SuspendLayout();
			this.CommonTab.SuspendLayout();
			this.CTGroup.SuspendLayout();
			this.BAGroup.SuspendLayout();
			this.JSTab.SuspendLayout();
			this.JSYUI.SuspendLayout();
			this.JSGoogle.SuspendLayout();
			this.JSMsMinifier.SuspendLayout();
			this.CSSTab.SuspendLayout();
			this.CSSYUI.SuspendLayout();
			this.CSSMsMinifier.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// TabControl
			// 
			this.TabControl.Controls.Add(this.CommonTab);
			this.TabControl.Controls.Add(this.JSTab);
			this.TabControl.Controls.Add(this.CSSTab);
			this.TabControl.Controls.Add(this.tabPage1);
			this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TabControl.Location = new System.Drawing.Point(0, 0);
			this.TabControl.Name = "TabControl";
			this.TabControl.SelectedIndex = 0;
			this.TabControl.Size = new System.Drawing.Size(675, 650);
			this.TabControl.TabIndex = 0;
			// 
			// CommonTab
			// 
			this.CommonTab.Controls.Add(this.CTGroup);
			this.CommonTab.Controls.Add(this.BAGroup);
			this.CommonTab.Location = new System.Drawing.Point(4, 22);
			this.CommonTab.Name = "CommonTab";
			this.CommonTab.Size = new System.Drawing.Size(667, 624);
			this.CommonTab.TabIndex = 2;
			this.CommonTab.Text = "Common";
			this.CommonTab.UseVisualStyleBackColor = true;
			// 
			// CTGroup
			// 
			this.CTGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CTGroup.Controls.Add(this.CTManual);
			this.CTGroup.Controls.Add(this.CTMixed);
			this.CTGroup.Controls.Add(this.CTDefault);
			this.CTGroup.Location = new System.Drawing.Point(3, 127);
			this.CTGroup.Name = "CTGroup";
			this.CTGroup.Size = new System.Drawing.Size(661, 88);
			this.CTGroup.TabIndex = 1;
			this.CTGroup.TabStop = false;
			this.CTGroup.Text = "Compilation Target";
			// 
			// CTManual
			// 
			this.CTManual.AutoSize = true;
			this.CTManual.Location = new System.Drawing.Point(6, 65);
			this.CTManual.Name = "CTManual";
			this.CTManual.Size = new System.Drawing.Size(113, 17);
			this.CTManual.TabIndex = 3;
			this.CTManual.Text = "Enable manual set";
			this.CTManual.UseVisualStyleBackColor = true;
			this.CTManual.Click += new System.EventHandler(this.CTManual_Click);
			// 
			// CTMixed
			// 
			this.CTMixed.AutoSize = true;
			this.CTMixed.Location = new System.Drawing.Point(6, 42);
			this.CTMixed.Name = "CTMixed";
			this.CTMixed.Size = new System.Drawing.Size(267, 17);
			this.CTMixed.TabIndex = 2;
			this.CTMixed.Text = "Set original file to Debug and minifed file to Release";
			this.CTMixed.UseVisualStyleBackColor = true;
			this.CTMixed.Click += new System.EventHandler(this.CTMixed_Click);
			// 
			// CTDefault
			// 
			this.CTDefault.AutoSize = true;
			this.CTDefault.Checked = true;
			this.CTDefault.Location = new System.Drawing.Point(6, 19);
			this.CTDefault.Name = "CTDefault";
			this.CTDefault.Size = new System.Drawing.Size(123, 17);
			this.CTDefault.TabIndex = 1;
			this.CTDefault.TabStop = true;
			this.CTDefault.Text = "Use default behavior";
			this.CTDefault.UseVisualStyleBackColor = true;
			this.CTDefault.Click += new System.EventHandler(this.CTDefault_Click);
			// 
			// BAGroup
			// 
			this.BAGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.BAGroup.Controls.Add(this.BACustomMinified);
			this.BAGroup.Controls.Add(this.label4);
			this.BAGroup.Controls.Add(this.BACustomOriginal);
			this.BAGroup.Controls.Add(this.BACustom);
			this.BAGroup.Controls.Add(this.BACopy);
			this.BAGroup.Controls.Add(this.BADefault);
			this.BAGroup.Location = new System.Drawing.Point(3, 3);
			this.BAGroup.Name = "BAGroup";
			this.BAGroup.Size = new System.Drawing.Size(661, 118);
			this.BAGroup.TabIndex = 0;
			this.BAGroup.TabStop = false;
			this.BAGroup.Text = "Build Action";
			// 
			// BACustomMinified
			// 
			this.BACustomMinified.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.BACustomMinified.FormattingEnabled = true;
			this.BACustomMinified.Items.AddRange(new object[] {
            "None",
            "Content",
            "EmbeddedResource"});
			this.BACustomMinified.Location = new System.Drawing.Point(135, 91);
			this.BACustomMinified.Name = "BACustomMinified";
			this.BACustomMinified.Size = new System.Drawing.Size(125, 21);
			this.BACustomMinified.TabIndex = 6;
			this.BACustomMinified.SelectedIndexChanged += new System.EventHandler(this.BACustomMinified_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(38, 94);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(91, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "and minified file to";
			// 
			// BACustomOriginal
			// 
			this.BACustomOriginal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.BACustomOriginal.FormattingEnabled = true;
			this.BACustomOriginal.Items.AddRange(new object[] {
            "None",
            "Content",
            "EmbeddedResource"});
			this.BACustomOriginal.Location = new System.Drawing.Point(135, 64);
			this.BACustomOriginal.Name = "BACustomOriginal";
			this.BACustomOriginal.Size = new System.Drawing.Size(125, 21);
			this.BACustomOriginal.TabIndex = 4;
			this.BACustomOriginal.SelectedIndexChanged += new System.EventHandler(this.BACustomOriginal_SelectedIndexChanged);
			// 
			// BACustom
			// 
			this.BACustom.AutoSize = true;
			this.BACustom.Location = new System.Drawing.Point(6, 65);
			this.BACustom.Name = "BACustom";
			this.BACustom.Size = new System.Drawing.Size(105, 17);
			this.BACustom.TabIndex = 3;
			this.BACustom.Text = "Set original file to";
			this.BACustom.UseVisualStyleBackColor = true;
			this.BACustom.Click += new System.EventHandler(this.BACustom_Click);
			// 
			// BACopy
			// 
			this.BACopy.AutoSize = true;
			this.BACopy.Location = new System.Drawing.Point(6, 42);
			this.BACopy.Name = "BACopy";
			this.BACopy.Size = new System.Drawing.Size(124, 17);
			this.BACopy.TabIndex = 2;
			this.BACopy.Text = "Copy from original file";
			this.BACopy.UseVisualStyleBackColor = true;
			this.BACopy.Click += new System.EventHandler(this.BACopy_Click);
			// 
			// BADefault
			// 
			this.BADefault.AutoSize = true;
			this.BADefault.Checked = true;
			this.BADefault.Location = new System.Drawing.Point(6, 19);
			this.BADefault.Name = "BADefault";
			this.BADefault.Size = new System.Drawing.Size(123, 17);
			this.BADefault.TabIndex = 1;
			this.BADefault.TabStop = true;
			this.BADefault.Text = "Use default behavior";
			this.BADefault.UseVisualStyleBackColor = true;
			this.BADefault.Click += new System.EventHandler(this.BADefault_Click);
			// 
			// JSTab
			// 
			this.JSTab.Controls.Add(this.JSYUI);
			this.JSTab.Controls.Add(this.JSGoogle);
			this.JSTab.Controls.Add(this.JSMsMinifier);
			this.JSTab.Controls.Add(this.JSEngine);
			this.JSTab.Controls.Add(this.JSEngLabel);
			this.JSTab.Controls.Add(this.JSExt);
			this.JSTab.Controls.Add(this.JSMinExtLabel);
			this.JSTab.Location = new System.Drawing.Point(4, 22);
			this.JSTab.Name = "JSTab";
			this.JSTab.Padding = new System.Windows.Forms.Padding(3);
			this.JSTab.Size = new System.Drawing.Size(667, 624);
			this.JSTab.TabIndex = 0;
			this.JSTab.Text = "JavaScript";
			this.JSTab.UseVisualStyleBackColor = true;
			this.JSTab.Resize += new System.EventHandler(this.Tab_Resize);
			// 
			// JSYUI
			// 
			this.JSYUI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.JSYUI.Controls.Add(this.JSYDisableOptimizations);
			this.JSYUI.Controls.Add(this.JSYPreserveAllSemicolons);
			this.JSYUI.Controls.Add(this.JSYObfuscateJavascript);
			this.JSYUI.Location = new System.Drawing.Point(9, 262);
			this.JSYUI.Name = "JSYUI";
			this.JSYUI.Size = new System.Drawing.Size(652, 120);
			this.JSYUI.TabIndex = 6;
			this.JSYUI.TabStop = false;
			this.JSYUI.Text = "YUI Compressor";
			// 
			// JSYDisableOptimizations
			// 
			this.JSYDisableOptimizations.AutoSize = true;
			this.JSYDisableOptimizations.Location = new System.Drawing.Point(6, 19);
			this.JSYDisableOptimizations.Name = "JSYDisableOptimizations";
			this.JSYDisableOptimizations.Size = new System.Drawing.Size(126, 17);
			this.JSYDisableOptimizations.TabIndex = 11;
			this.JSYDisableOptimizations.Text = "Disable Optimizations";
			this.JSYDisableOptimizations.UseVisualStyleBackColor = true;
			this.JSYDisableOptimizations.CheckedChanged += new System.EventHandler(this.JSYDisableOptimizations_CheckedChanged);
			// 
			// JSYPreserveAllSemicolons
			// 
			this.JSYPreserveAllSemicolons.AutoSize = true;
			this.JSYPreserveAllSemicolons.Location = new System.Drawing.Point(6, 42);
			this.JSYPreserveAllSemicolons.Name = "JSYPreserveAllSemicolons";
			this.JSYPreserveAllSemicolons.Size = new System.Drawing.Size(139, 17);
			this.JSYPreserveAllSemicolons.TabIndex = 10;
			this.JSYPreserveAllSemicolons.Text = "Preserve All Semicolons";
			this.JSYPreserveAllSemicolons.UseVisualStyleBackColor = true;
			this.JSYPreserveAllSemicolons.CheckedChanged += new System.EventHandler(this.JSYPreserveAllSemicolons_CheckedChanged);
			// 
			// JSYObfuscateJavascript
			// 
			this.JSYObfuscateJavascript.AutoSize = true;
			this.JSYObfuscateJavascript.Location = new System.Drawing.Point(6, 65);
			this.JSYObfuscateJavascript.Name = "JSYObfuscateJavascript";
			this.JSYObfuscateJavascript.Size = new System.Drawing.Size(126, 17);
			this.JSYObfuscateJavascript.TabIndex = 9;
			this.JSYObfuscateJavascript.Text = "Obfuscate Javascript";
			this.JSYObfuscateJavascript.UseVisualStyleBackColor = true;
			this.JSYObfuscateJavascript.CheckedChanged += new System.EventHandler(this.JSYObfuscateJavascript_CheckedChanged);
			// 
			// JSGoogle
			// 
			this.JSGoogle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.JSGoogle.Controls.Add(this.label3);
			this.JSGoogle.Controls.Add(this.JSGCompilationLevel);
			this.JSGoogle.Location = new System.Drawing.Point(9, 401);
			this.JSGoogle.Name = "JSGoogle";
			this.JSGoogle.Size = new System.Drawing.Size(652, 120);
			this.JSGoogle.TabIndex = 5;
			this.JSGoogle.TabStop = false;
			this.JSGoogle.Text = "Google Closure Compiler";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(93, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Compilation Level:";
			// 
			// JSGCompilationLevel
			// 
			this.JSGCompilationLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.JSGCompilationLevel.FormattingEnabled = true;
			this.JSGCompilationLevel.Items.AddRange(new object[] {
            "Whitespace only",
            "Simple Optimization",
            "Advanced Optimization"});
			this.JSGCompilationLevel.Location = new System.Drawing.Point(99, 19);
			this.JSGCompilationLevel.Name = "JSGCompilationLevel";
			this.JSGCompilationLevel.Size = new System.Drawing.Size(121, 21);
			this.JSGCompilationLevel.TabIndex = 3;
			this.JSGCompilationLevel.SelectedIndexChanged += new System.EventHandler(this.JSGCompilationLevel_SelectedIndexChanged);
			// 
			// JSMsMinifier
			// 
			this.JSMsMinifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.JSMsMinifier.Controls.Add(this.JSMsRemoveFunctionExpressionNames);
			this.JSMsMinifier.Controls.Add(this.JSMsPreserveFunctionNames);
			this.JSMsMinifier.Controls.Add(this.JSMsRemoveUnneededCode);
			this.JSMsMinifier.Controls.Add(this.JSMsPreserveImportantComments);
			this.JSMsMinifier.Controls.Add(this.JSMsOutputMode);
			this.JSMsMinifier.Controls.Add(this.label2);
			this.JSMsMinifier.Controls.Add(this.label1);
			this.JSMsMinifier.Controls.Add(this.JSMsLocalRename);
			this.JSMsMinifier.Location = new System.Drawing.Point(9, 60);
			this.JSMsMinifier.Name = "JSMsMinifier";
			this.JSMsMinifier.Size = new System.Drawing.Size(652, 187);
			this.JSMsMinifier.TabIndex = 4;
			this.JSMsMinifier.TabStop = false;
			this.JSMsMinifier.Text = "Microsoft Ajax Minifier";
			// 
			// JSMsRemoveFunctionExpressionNames
			// 
			this.JSMsRemoveFunctionExpressionNames.AutoSize = true;
			this.JSMsRemoveFunctionExpressionNames.Location = new System.Drawing.Point(9, 142);
			this.JSMsRemoveFunctionExpressionNames.Name = "JSMsRemoveFunctionExpressionNames";
			this.JSMsRemoveFunctionExpressionNames.Size = new System.Drawing.Size(200, 17);
			this.JSMsRemoveFunctionExpressionNames.TabIndex = 8;
			this.JSMsRemoveFunctionExpressionNames.Text = "Remove Function-Expression Names";
			this.JSMsRemoveFunctionExpressionNames.UseVisualStyleBackColor = true;
			this.JSMsRemoveFunctionExpressionNames.CheckedChanged += new System.EventHandler(this.JSMsRemoveFunctionExpressionNames_CheckedChanged);
			// 
			// JSMsPreserveFunctionNames
			// 
			this.JSMsPreserveFunctionNames.AutoSize = true;
			this.JSMsPreserveFunctionNames.Location = new System.Drawing.Point(9, 119);
			this.JSMsPreserveFunctionNames.Name = "JSMsPreserveFunctionNames";
			this.JSMsPreserveFunctionNames.Size = new System.Drawing.Size(148, 17);
			this.JSMsPreserveFunctionNames.TabIndex = 7;
			this.JSMsPreserveFunctionNames.Text = "Preserve Function Names";
			this.JSMsPreserveFunctionNames.UseVisualStyleBackColor = true;
			this.JSMsPreserveFunctionNames.CheckedChanged += new System.EventHandler(this.JSMsPreserveFunctionNames_CheckedChanged);
			// 
			// JSMsRemoveUnneededCode
			// 
			this.JSMsRemoveUnneededCode.AutoSize = true;
			this.JSMsRemoveUnneededCode.Location = new System.Drawing.Point(9, 96);
			this.JSMsRemoveUnneededCode.Name = "JSMsRemoveUnneededCode";
			this.JSMsRemoveUnneededCode.Size = new System.Drawing.Size(147, 17);
			this.JSMsRemoveUnneededCode.TabIndex = 6;
			this.JSMsRemoveUnneededCode.Text = "Remove Unneeded Code";
			this.JSMsRemoveUnneededCode.UseVisualStyleBackColor = true;
			this.JSMsRemoveUnneededCode.CheckedChanged += new System.EventHandler(this.JSMsRemoveUnneededCode_CheckedChanged);
			// 
			// JSMsPreserveImportantComments
			// 
			this.JSMsPreserveImportantComments.AutoSize = true;
			this.JSMsPreserveImportantComments.Location = new System.Drawing.Point(9, 73);
			this.JSMsPreserveImportantComments.Name = "JSMsPreserveImportantComments";
			this.JSMsPreserveImportantComments.Size = new System.Drawing.Size(167, 17);
			this.JSMsPreserveImportantComments.TabIndex = 5;
			this.JSMsPreserveImportantComments.Text = "Preserve Important Comments";
			this.JSMsPreserveImportantComments.UseVisualStyleBackColor = true;
			this.JSMsPreserveImportantComments.CheckedChanged += new System.EventHandler(this.JSMsPreserveImportantComments_CheckedChanged);
			// 
			// JSMsOutputMode
			// 
			this.JSMsOutputMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.JSMsOutputMode.FormattingEnabled = true;
			this.JSMsOutputMode.Items.AddRange(new object[] {
            "Single Line",
            "Multiple Lines"});
			this.JSMsOutputMode.Location = new System.Drawing.Point(99, 46);
			this.JSMsOutputMode.Name = "JSMsOutputMode";
			this.JSMsOutputMode.Size = new System.Drawing.Size(121, 21);
			this.JSMsOutputMode.TabIndex = 4;
			this.JSMsOutputMode.SelectedIndexChanged += new System.EventHandler(this.JSMsOutputMode_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Output Mode:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Local Renaming:";
			// 
			// JSMsLocalRename
			// 
			this.JSMsLocalRename.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.JSMsLocalRename.FormattingEnabled = true;
			this.JSMsLocalRename.Items.AddRange(new object[] {
            "Keep All",
            "Keep Localization Variables",
            "Crunch All"});
			this.JSMsLocalRename.Location = new System.Drawing.Point(99, 19);
			this.JSMsLocalRename.Name = "JSMsLocalRename";
			this.JSMsLocalRename.Size = new System.Drawing.Size(121, 21);
			this.JSMsLocalRename.TabIndex = 1;
			this.JSMsLocalRename.SelectedIndexChanged += new System.EventHandler(this.JSMsLocalRename_SelectedIndexChanged);
			// 
			// JSEngine
			// 
			this.JSEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.JSEngine.FormattingEnabled = true;
			this.JSEngine.Items.AddRange(new object[] {
            "YUI Compressor",
            "Microsoft Ajax Minifier",
            "Google Closure Compiler"});
			this.JSEngine.Location = new System.Drawing.Point(137, 33);
			this.JSEngine.Name = "JSEngine";
			this.JSEngine.Size = new System.Drawing.Size(240, 21);
			this.JSEngine.TabIndex = 3;
			this.JSEngine.SelectedIndexChanged += new System.EventHandler(this.JSEngine_SelectedIndexChanged);
			// 
			// JSEngLabel
			// 
			this.JSEngLabel.AutoSize = true;
			this.JSEngLabel.Location = new System.Drawing.Point(6, 36);
			this.JSEngLabel.Name = "JSEngLabel";
			this.JSEngLabel.Size = new System.Drawing.Size(43, 13);
			this.JSEngLabel.TabIndex = 2;
			this.JSEngLabel.Text = "Engine:";
			// 
			// JSExt
			// 
			this.JSExt.Location = new System.Drawing.Point(137, 6);
			this.JSExt.Name = "JSExt";
			this.JSExt.Size = new System.Drawing.Size(120, 20);
			this.JSExt.TabIndex = 1;
			this.JSExt.TextChanged += new System.EventHandler(this.JSExt_TextChanged);
			// 
			// JSMinExtLabel
			// 
			this.JSMinExtLabel.AutoSize = true;
			this.JSMinExtLabel.Location = new System.Drawing.Point(6, 9);
			this.JSMinExtLabel.Name = "JSMinExtLabel";
			this.JSMinExtLabel.Size = new System.Drawing.Size(125, 13);
			this.JSMinExtLabel.TabIndex = 0;
			this.JSMinExtLabel.Text = "Extension for minified file:";
			// 
			// CSSTab
			// 
			this.CSSTab.Controls.Add(this.CSSYUI);
			this.CSSTab.Controls.Add(this.CSSMsMinifier);
			this.CSSTab.Controls.Add(this.CSSEngine);
			this.CSSTab.Controls.Add(this.label7);
			this.CSSTab.Controls.Add(this.CSSExt);
			this.CSSTab.Controls.Add(this.label8);
			this.CSSTab.Location = new System.Drawing.Point(4, 22);
			this.CSSTab.Name = "CSSTab";
			this.CSSTab.Padding = new System.Windows.Forms.Padding(3);
			this.CSSTab.Size = new System.Drawing.Size(667, 624);
			this.CSSTab.TabIndex = 1;
			this.CSSTab.Text = "CSS";
			this.CSSTab.UseVisualStyleBackColor = true;
			this.CSSTab.Resize += new System.EventHandler(this.Tab_Resize);
			// 
			// CSSYUI
			// 
			this.CSSYUI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CSSYUI.Controls.Add(this.CSSYRemoveComments);
			this.CSSYUI.Location = new System.Drawing.Point(9, 262);
			this.CSSYUI.Name = "CSSYUI";
			this.CSSYUI.Size = new System.Drawing.Size(652, 120);
			this.CSSYUI.TabIndex = 13;
			this.CSSYUI.TabStop = false;
			this.CSSYUI.Text = "YUI Compressor";
			// 
			// CSSYRemoveComments
			// 
			this.CSSYRemoveComments.AutoSize = true;
			this.CSSYRemoveComments.Location = new System.Drawing.Point(6, 19);
			this.CSSYRemoveComments.Name = "CSSYRemoveComments";
			this.CSSYRemoveComments.Size = new System.Drawing.Size(118, 17);
			this.CSSYRemoveComments.TabIndex = 11;
			this.CSSYRemoveComments.Text = "Remove Comments";
			this.CSSYRemoveComments.UseVisualStyleBackColor = true;
			this.CSSYRemoveComments.CheckedChanged += new System.EventHandler(this.CSSYRemoveComments_CheckedChanged);
			// 
			// CSSMsMinifier
			// 
			this.CSSMsMinifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CSSMsMinifier.Controls.Add(this.CSSMsOutputMode);
			this.CSSMsMinifier.Controls.Add(this.label10);
			this.CSSMsMinifier.Controls.Add(this.CSSMsCssType);
			this.CSSMsMinifier.Controls.Add(this.label9);
			this.CSSMsMinifier.Controls.Add(this.CSSMsMinifyExpressions);
			this.CSSMsMinifier.Controls.Add(this.CSSMsCommentMode);
			this.CSSMsMinifier.Controls.Add(this.label5);
			this.CSSMsMinifier.Controls.Add(this.label6);
			this.CSSMsMinifier.Controls.Add(this.CSSMsColorNames);
			this.CSSMsMinifier.Location = new System.Drawing.Point(9, 60);
			this.CSSMsMinifier.Name = "CSSMsMinifier";
			this.CSSMsMinifier.Size = new System.Drawing.Size(652, 187);
			this.CSSMsMinifier.TabIndex = 11;
			this.CSSMsMinifier.TabStop = false;
			this.CSSMsMinifier.Text = "Microsoft Ajax Minifier";
			// 
			// CSSMsOutputMode
			// 
			this.CSSMsOutputMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CSSMsOutputMode.FormattingEnabled = true;
			this.CSSMsOutputMode.Items.AddRange(new object[] {
            "Single Line",
            "Multiple Lines"});
			this.CSSMsOutputMode.Location = new System.Drawing.Point(99, 100);
			this.CSSMsOutputMode.Name = "CSSMsOutputMode";
			this.CSSMsOutputMode.Size = new System.Drawing.Size(121, 21);
			this.CSSMsOutputMode.TabIndex = 9;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(6, 103);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(72, 13);
			this.label10.TabIndex = 8;
			this.label10.Text = "Output Mode:";
			// 
			// CSSMsCssType
			// 
			this.CSSMsCssType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CSSMsCssType.FormattingEnabled = true;
			this.CSSMsCssType.Items.AddRange(new object[] {
            "FullStyleSheet",
            "DeclarationList"});
			this.CSSMsCssType.Location = new System.Drawing.Point(99, 73);
			this.CSSMsCssType.Name = "CSSMsCssType";
			this.CSSMsCssType.Size = new System.Drawing.Size(121, 21);
			this.CSSMsCssType.TabIndex = 7;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 76);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(54, 13);
			this.label9.TabIndex = 6;
			this.label9.Text = "Css Type:";
			// 
			// CSSMsMinifyExpressions
			// 
			this.CSSMsMinifyExpressions.AutoSize = true;
			this.CSSMsMinifyExpressions.Location = new System.Drawing.Point(9, 127);
			this.CSSMsMinifyExpressions.Name = "CSSMsMinifyExpressions";
			this.CSSMsMinifyExpressions.Size = new System.Drawing.Size(112, 17);
			this.CSSMsMinifyExpressions.TabIndex = 5;
			this.CSSMsMinifyExpressions.Text = "Minify Expressions";
			this.CSSMsMinifyExpressions.UseVisualStyleBackColor = true;
			// 
			// CSSMsCommentMode
			// 
			this.CSSMsCommentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CSSMsCommentMode.FormattingEnabled = true;
			this.CSSMsCommentMode.Items.AddRange(new object[] {
            "Important",
            "None",
            "All",
            "Hacks"});
			this.CSSMsCommentMode.Location = new System.Drawing.Point(99, 46);
			this.CSSMsCommentMode.Name = "CSSMsCommentMode";
			this.CSSMsCommentMode.Size = new System.Drawing.Size(121, 21);
			this.CSSMsCommentMode.TabIndex = 4;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 49);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(84, 13);
			this.label5.TabIndex = 3;
			this.label5.Text = "Comment Mode:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 22);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(70, 13);
			this.label6.TabIndex = 2;
			this.label6.Text = "Color Names:";
			// 
			// CSSMsColorNames
			// 
			this.CSSMsColorNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CSSMsColorNames.FormattingEnabled = true;
			this.CSSMsColorNames.Items.AddRange(new object[] {
            "Strict",
            "Hex",
            "Major"});
			this.CSSMsColorNames.Location = new System.Drawing.Point(99, 19);
			this.CSSMsColorNames.Name = "CSSMsColorNames";
			this.CSSMsColorNames.Size = new System.Drawing.Size(121, 21);
			this.CSSMsColorNames.TabIndex = 1;
			// 
			// CSSEngine
			// 
			this.CSSEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CSSEngine.FormattingEnabled = true;
			this.CSSEngine.Items.AddRange(new object[] {
            "YUI Compressor",
            "Microsoft Ajax Minifier"});
			this.CSSEngine.Location = new System.Drawing.Point(137, 33);
			this.CSSEngine.Name = "CSSEngine";
			this.CSSEngine.Size = new System.Drawing.Size(240, 21);
			this.CSSEngine.TabIndex = 10;
			this.CSSEngine.SelectedIndexChanged += new System.EventHandler(this.CSSEngine_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 36);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(43, 13);
			this.label7.TabIndex = 9;
			this.label7.Text = "Engine:";
			// 
			// CSSExt
			// 
			this.CSSExt.Location = new System.Drawing.Point(137, 6);
			this.CSSExt.Name = "CSSExt";
			this.CSSExt.Size = new System.Drawing.Size(120, 20);
			this.CSSExt.TabIndex = 8;
			this.CSSExt.TextChanged += new System.EventHandler(this.CSSExt_TextChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 9);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(125, 13);
			this.label8.TabIndex = 7;
			this.label8.Text = "Extension for minified file:";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.HelpText);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(667, 624);
			this.tabPage1.TabIndex = 3;
			this.tabPage1.Text = "Help";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// HelpText
			// 
			this.HelpText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.HelpText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.HelpText.Cursor = System.Windows.Forms.Cursors.Default;
			this.HelpText.Location = new System.Drawing.Point(3, 3);
			this.HelpText.Name = "HelpText";
			this.HelpText.ReadOnly = true;
			this.HelpText.Size = new System.Drawing.Size(661, 618);
			this.HelpText.TabIndex = 0;
			this.HelpText.Text = "";
			// 
			// OptionControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.TabControl);
			this.Name = "OptionControl";
			this.Size = new System.Drawing.Size(675, 650);
			this.Load += new System.EventHandler(this.OptionControl_Load);
			this.TabControl.ResumeLayout(false);
			this.CommonTab.ResumeLayout(false);
			this.CTGroup.ResumeLayout(false);
			this.CTGroup.PerformLayout();
			this.BAGroup.ResumeLayout(false);
			this.BAGroup.PerformLayout();
			this.JSTab.ResumeLayout(false);
			this.JSTab.PerformLayout();
			this.JSYUI.ResumeLayout(false);
			this.JSYUI.PerformLayout();
			this.JSGoogle.ResumeLayout(false);
			this.JSGoogle.PerformLayout();
			this.JSMsMinifier.ResumeLayout(false);
			this.JSMsMinifier.PerformLayout();
			this.CSSTab.ResumeLayout(false);
			this.CSSTab.PerformLayout();
			this.CSSYUI.ResumeLayout(false);
			this.CSSYUI.PerformLayout();
			this.CSSMsMinifier.ResumeLayout(false);
			this.CSSMsMinifier.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl TabControl;
		private System.Windows.Forms.TabPage JSTab;
		private System.Windows.Forms.TextBox JSExt;
		private System.Windows.Forms.Label JSMinExtLabel;
		private System.Windows.Forms.TabPage CSSTab;
		private System.Windows.Forms.Label JSEngLabel;
		private System.Windows.Forms.ComboBox JSEngine;
		private System.Windows.Forms.GroupBox JSMsMinifier;
		private System.Windows.Forms.GroupBox JSYUI;
		private System.Windows.Forms.GroupBox JSGoogle;
		private System.Windows.Forms.CheckBox JSMsRemoveFunctionExpressionNames;
		private System.Windows.Forms.CheckBox JSMsPreserveFunctionNames;
		private System.Windows.Forms.CheckBox JSMsRemoveUnneededCode;
		private System.Windows.Forms.CheckBox JSMsPreserveImportantComments;
		private System.Windows.Forms.ComboBox JSMsOutputMode;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox JSMsLocalRename;
		private System.Windows.Forms.CheckBox JSYDisableOptimizations;
		private System.Windows.Forms.CheckBox JSYPreserveAllSemicolons;
		private System.Windows.Forms.CheckBox JSYObfuscateJavascript;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox JSGCompilationLevel;
		private System.Windows.Forms.GroupBox CSSYUI;
		private System.Windows.Forms.CheckBox CSSYRemoveComments;
		private System.Windows.Forms.GroupBox CSSMsMinifier;
		private System.Windows.Forms.CheckBox CSSMsMinifyExpressions;
		private System.Windows.Forms.ComboBox CSSMsCommentMode;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox CSSMsColorNames;
		private System.Windows.Forms.ComboBox CSSEngine;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox CSSExt;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox CSSMsOutputMode;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox CSSMsCssType;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TabPage CommonTab;
		private System.Windows.Forms.GroupBox BAGroup;
		private System.Windows.Forms.ComboBox BACustomMinified;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox BACustomOriginal;
		private System.Windows.Forms.RadioButton BACustom;
		private System.Windows.Forms.RadioButton BACopy;
		private System.Windows.Forms.RadioButton BADefault;
		private System.Windows.Forms.GroupBox CTGroup;
		private System.Windows.Forms.CheckBox CTManual;
		private System.Windows.Forms.RadioButton CTMixed;
		private System.Windows.Forms.RadioButton CTDefault;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.RichTextBox HelpText;
	}
}
