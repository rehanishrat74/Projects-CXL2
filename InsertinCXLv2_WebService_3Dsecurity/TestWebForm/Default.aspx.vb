
Partial Class TestWebForm_Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim service As New InsertInCXLV2
        Dim service_response As New InsertInCXLV2.InsertOrderResult
        service_response = service.InsertSuspendedOrder(115161, "793510", 2222, 56.6, "M", "4444333322221111", "amex card", "abc", "abc", Date.Now, "111", "12", "cc", "234", "US", Date.Now, "AC", 234, "192.168.4.65", "5", "www.abc.com", "D04100", "0025783745272836254732517283", "00030245342217862123", "0025783745272836254732517283", "123456789012", "abc", "abczp", "N", "card not part")

        Dim errorCode = service_response.ERRORCODE
        Dim errorDesc = service_response.ERRORDESC
        Dim error_rerport As String = errorCode & "**" & errorDesc
        lblError.Text = error_rerport
        
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
