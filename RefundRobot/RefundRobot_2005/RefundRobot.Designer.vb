<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RefundRobot
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.timerPopulate = New System.Windows.Forms.Timer(Me.components)
        Me.progressRefundOrders = New System.Windows.Forms.ProgressBar
        Me.gridData = New System.Windows.Forms.DataGridView
        Me.btnExit = New System.Windows.Forms.Button
        Me.GridInProcess = New System.Windows.Forms.DataGridView
        Me.GridProcessed = New System.Windows.Forms.DataGridView
        Me.BtnCancellAll = New System.Windows.Forms.Button
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.QueryTimer = New System.Windows.Forms.Timer(Me.components)
        Me.InProcessTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Lbl = New System.Windows.Forms.Label
        Me.lblMin = New System.Windows.Forms.Label
        Me.Colon = New System.Windows.Forms.Label
        Me.lblSec = New System.Windows.Forms.Label
        Me.LblRefundOrder = New System.Windows.Forms.Label
        Me.LblInProcessOrder = New System.Windows.Forms.Label
        Me.LblProcessedOrder = New System.Windows.Forms.Label
        Me.BtnMinimize = New System.Windows.Forms.Button
        Me.TxtElapse = New System.Windows.Forms.TextBox
        Me.LblSetElapse = New System.Windows.Forms.Label
        Me.BtnOk = New System.Windows.Forms.Button
        Me.LblCurrentDate = New System.Windows.Forms.Label
        Me.lblDate = New System.Windows.Forms.Label
        Me.lblRefundLimit = New System.Windows.Forms.Label
        Me.lblLimit = New System.Windows.Forms.Label
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridInProcess, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridProcessed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'timerPopulate
        '
        Me.timerPopulate.Interval = 30000
        '
        'progressRefundOrders
        '
        Me.progressRefundOrders.Location = New System.Drawing.Point(23, 409)
        Me.progressRefundOrders.Name = "progressRefundOrders"
        Me.progressRefundOrders.Size = New System.Drawing.Size(589, 21)
        Me.progressRefundOrders.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.progressRefundOrders.TabIndex = 0
        '
        'gridData
        '
        Me.gridData.AllowUserToAddRows = False
        Me.gridData.AllowUserToDeleteRows = False
        Me.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridData.Location = New System.Drawing.Point(16, 24)
        Me.gridData.Name = "gridData"
        Me.gridData.ReadOnly = True
        Me.gridData.Size = New System.Drawing.Size(593, 113)
        Me.gridData.TabIndex = 1
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(541, 441)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'GridInProcess
        '
        Me.GridInProcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridInProcess.Location = New System.Drawing.Point(19, 174)
        Me.GridInProcess.Name = "GridInProcess"
        Me.GridInProcess.ReadOnly = True
        Me.GridInProcess.Size = New System.Drawing.Size(593, 87)
        Me.GridInProcess.TabIndex = 5
        '
        'GridProcessed
        '
        Me.GridProcessed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridProcessed.Location = New System.Drawing.Point(21, 292)
        Me.GridProcessed.Name = "GridProcessed"
        Me.GridProcessed.ReadOnly = True
        Me.GridProcessed.Size = New System.Drawing.Size(591, 101)
        Me.GridProcessed.TabIndex = 6
        '
        'BtnCancellAll
        '
        Me.BtnCancellAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancellAll.Location = New System.Drawing.Point(460, 441)
        Me.BtnCancellAll.Name = "BtnCancellAll"
        Me.BtnCancellAll.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancellAll.TabIndex = 7
        Me.BtnCancellAll.Text = "Cancel All"
        Me.BtnCancellAll.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.Location = New System.Drawing.Point(626, 238)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 8
        Me.BtnCancel.Text = "Cancel Order"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'QueryTimer
        '
        Me.QueryTimer.Interval = 10000
        '
        'InProcessTimer
        '
        '
        'Lbl
        '
        Me.Lbl.AutoSize = True
        Me.Lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl.Location = New System.Drawing.Point(331, 158)
        Me.Lbl.Name = "Lbl"
        Me.Lbl.Size = New System.Drawing.Size(184, 13)
        Me.Lbl.TabIndex = 9
        Me.Lbl.Text = "Time To  Elapse for Processing"
        '
        'lblMin
        '
        Me.lblMin.AutoSize = True
        Me.lblMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMin.Location = New System.Drawing.Point(521, 158)
        Me.lblMin.Name = "lblMin"
        Me.lblMin.Size = New System.Drawing.Size(21, 13)
        Me.lblMin.TabIndex = 10
        Me.lblMin.Text = "00"
        '
        'Colon
        '
        Me.Colon.AutoSize = True
        Me.Colon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Colon.Location = New System.Drawing.Point(557, 158)
        Me.Colon.Name = "Colon"
        Me.Colon.Size = New System.Drawing.Size(11, 13)
        Me.Colon.TabIndex = 11
        Me.Colon.Text = ":"
        '
        'lblSec
        '
        Me.lblSec.AutoSize = True
        Me.lblSec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSec.Location = New System.Drawing.Point(587, 158)
        Me.lblSec.Name = "lblSec"
        Me.lblSec.Size = New System.Drawing.Size(21, 13)
        Me.lblSec.TabIndex = 12
        Me.lblSec.Text = "00"
        '
        'LblRefundOrder
        '
        Me.LblRefundOrder.AutoSize = True
        Me.LblRefundOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRefundOrder.Location = New System.Drawing.Point(12, 9)
        Me.LblRefundOrder.Name = "LblRefundOrder"
        Me.LblRefundOrder.Size = New System.Drawing.Size(136, 13)
        Me.LblRefundOrder.TabIndex = 13
        Me.LblRefundOrder.Text = "Batch REFUND Orders"
        '
        'LblInProcessOrder
        '
        Me.LblInProcessOrder.AutoSize = True
        Me.LblInProcessOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInProcessOrder.Location = New System.Drawing.Point(18, 158)
        Me.LblInProcessOrder.Name = "LblInProcessOrder"
        Me.LblInProcessOrder.Size = New System.Drawing.Size(163, 13)
        Me.LblInProcessOrder.TabIndex = 14
        Me.LblInProcessOrder.Text = "In Process REFUND Orders"
        '
        'LblProcessedOrder
        '
        Me.LblProcessedOrder.AutoSize = True
        Me.LblProcessedOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProcessedOrder.Location = New System.Drawing.Point(20, 275)
        Me.LblProcessedOrder.Name = "LblProcessedOrder"
        Me.LblProcessedOrder.Size = New System.Drawing.Size(162, 13)
        Me.LblProcessedOrder.TabIndex = 15
        Me.LblProcessedOrder.Text = "Processed REFUND Orders"
        '
        'BtnMinimize
        '
        Me.BtnMinimize.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMinimize.Location = New System.Drawing.Point(379, 441)
        Me.BtnMinimize.Name = "BtnMinimize"
        Me.BtnMinimize.Size = New System.Drawing.Size(75, 23)
        Me.BtnMinimize.TabIndex = 16
        Me.BtnMinimize.Text = "Minimize"
        Me.BtnMinimize.UseVisualStyleBackColor = True
        '
        'TxtElapse
        '
        Me.TxtElapse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtElapse.Location = New System.Drawing.Point(626, 193)
        Me.TxtElapse.Name = "TxtElapse"
        Me.TxtElapse.Size = New System.Drawing.Size(49, 20)
        Me.TxtElapse.TabIndex = 17
        Me.TxtElapse.Text = "01:00"
        Me.TxtElapse.Visible = False
        '
        'LblSetElapse
        '
        Me.LblSetElapse.AutoSize = True
        Me.LblSetElapse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSetElapse.Location = New System.Drawing.Point(623, 174)
        Me.LblSetElapse.Name = "LblSetElapse"
        Me.LblSetElapse.Size = New System.Drawing.Size(99, 13)
        Me.LblSetElapse.TabIndex = 18
        Me.LblSetElapse.Text = "Set Elapse Time"
        Me.LblSetElapse.Visible = False
        '
        'BtnOk
        '
        Me.BtnOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOk.Location = New System.Drawing.Point(681, 193)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(41, 20)
        Me.BtnOk.TabIndex = 19
        Me.BtnOk.Text = "OK"
        Me.BtnOk.UseVisualStyleBackColor = True
        Me.BtnOk.Visible = False
        '
        'LblCurrentDate
        '
        Me.LblCurrentDate.AutoSize = True
        Me.LblCurrentDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCurrentDate.Location = New System.Drawing.Point(623, 24)
        Me.LblCurrentDate.Name = "LblCurrentDate"
        Me.LblCurrentDate.Size = New System.Drawing.Size(79, 13)
        Me.LblCurrentDate.TabIndex = 20
        Me.LblCurrentDate.Text = "Current Date"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(637, 41)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(65, 13)
        Me.lblDate.TabIndex = 21
        Me.lblDate.Text = "02/06/2008"
        '
        'lblRefundLimit
        '
        Me.lblRefundLimit.AutoSize = True
        Me.lblRefundLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRefundLimit.Location = New System.Drawing.Point(623, 76)
        Me.lblRefundLimit.Name = "lblRefundLimit"
        Me.lblRefundLimit.Size = New System.Drawing.Size(78, 13)
        Me.lblRefundLimit.TabIndex = 22
        Me.lblRefundLimit.Text = "Refund Limit"
        '
        'lblLimit
        '
        Me.lblLimit.AutoSize = True
        Me.lblLimit.Location = New System.Drawing.Point(675, 93)
        Me.lblLimit.Name = "lblLimit"
        Me.lblLimit.Size = New System.Drawing.Size(24, 13)
        Me.lblLimit.TabIndex = 23
        Me.lblLimit.Text = "_/_"
        '
        'RefundRobot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 473)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblLimit)
        Me.Controls.Add(Me.lblRefundLimit)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.LblCurrentDate)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.LblSetElapse)
        Me.Controls.Add(Me.TxtElapse)
        Me.Controls.Add(Me.BtnMinimize)
        Me.Controls.Add(Me.LblProcessedOrder)
        Me.Controls.Add(Me.LblInProcessOrder)
        Me.Controls.Add(Me.LblRefundOrder)
        Me.Controls.Add(Me.lblSec)
        Me.Controls.Add(Me.Colon)
        Me.Controls.Add(Me.lblMin)
        Me.Controls.Add(Me.Lbl)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnCancellAll)
        Me.Controls.Add(Me.GridProcessed)
        Me.Controls.Add(Me.GridInProcess)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.gridData)
        Me.Controls.Add(Me.progressRefundOrders)
        Me.Name = "RefundRobot"
        Me.Text = "RefundRobot"
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridInProcess, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridProcessed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents timerPopulate As System.Windows.Forms.Timer
    Friend WithEvents progressRefundOrders As System.Windows.Forms.ProgressBar
    Friend WithEvents gridData As System.Windows.Forms.DataGridView
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents GridInProcess As System.Windows.Forms.DataGridView
    Friend WithEvents GridProcessed As System.Windows.Forms.DataGridView
    Friend WithEvents BtnCancellAll As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents QueryTimer As System.Windows.Forms.Timer
    Friend WithEvents InProcessTimer As System.Windows.Forms.Timer
    Friend WithEvents Lbl As System.Windows.Forms.Label
    Friend WithEvents lblMin As System.Windows.Forms.Label
    Friend WithEvents Colon As System.Windows.Forms.Label
    Friend WithEvents lblSec As System.Windows.Forms.Label
    Friend WithEvents LblRefundOrder As System.Windows.Forms.Label
    Friend WithEvents LblInProcessOrder As System.Windows.Forms.Label
    Friend WithEvents LblProcessedOrder As System.Windows.Forms.Label
    Friend WithEvents BtnMinimize As System.Windows.Forms.Button
    Friend WithEvents TxtElapse As System.Windows.Forms.TextBox
    Friend WithEvents LblSetElapse As System.Windows.Forms.Label
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents LblCurrentDate As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblRefundLimit As System.Windows.Forms.Label
    Friend WithEvents lblLimit As System.Windows.Forms.Label
End Class
