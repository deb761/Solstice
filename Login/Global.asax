<%@ Application Language="C#" %>
<%@ Import Namespace="System.Data" %>

<script runat="server">
    /// <summary>
    /// Load required definitions at startup
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void Application_Start(object sender, EventArgs e)
    {
        Rules.Load(Server);
    }

    void Application_End(object sender, EventArgs e)
    {

    }

    void Application_Error(object sender, EventArgs e)
    {

    }

    void Session_Start(object sender, EventArgs e)
    {

    }

    void Session_End(object sender, EventArgs e)
    {
        Session["userName"] = String.Empty;
        Session["password"] = String.Empty;
    }

</script>
