<html>

<head>

<title>Sales Report DTS Package</title>

</head>

<body bgcolor="#FFFFFF">

<%

dim objDTSPackage

dim objDTSStep

dim strResult

dim blnSucceeded

const DTSSQLStgFlag_Default = 0

const DTSStepExecResult_Failure = 1

set objDTSPackage = Server.CreateObject("DTS.Package")

blnSucceeded = true

objDTSPackage.LoadFromSQLServer "win-sadia", "sa", "sa", DTSSQLStgFlag_Default, "", "", "", "SalesPkg"

objDTSPackage.GlobalVariables("gPaymentTerm").Value = "Net 30" 

objDTSPackage.Execute

for each objDTSStep in objDTSPackage.Steps

if objDTSStep.ExecutionResult = DTSStepExecResult_Failure then

strResult = strResult & "Package " & objDTSStep.Name & " failed.<br>" 

blnSucceeded = false

else

strResult = strResult & "Package " & objDTSStep.Name & " succeeded.<br>" 

end if

next

if blnSucceeded then

Response.Write "<h1>Package Succeeded</h1>"

else

Response.Write "<h1>Package Failed</h1>"

end if

Response.Write strResult



%>

</body>

</html>

