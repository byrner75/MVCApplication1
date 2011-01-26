<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Gateway.Data.Entities.BranchGatewayProtocol>" %>
    <% using (Ajax.BeginForm("ASPEdit", "Protocol", new AjaxOptions { HttpMethod = "POST", InsertionMode = InsertionMode.Replace, UpdateTargetId = "Protocol_Edit" }, new { id = "Protocol_Edit" }))
       {%>
        <%= Html.HiddenFor(model => model.id)%>
        <fieldset>
            <h4>Edit Branch Configuration</h4>
            
            <div style="float: left; padding: 10px">            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.ClientApplicationName)%>=
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.ClientApplicationName)%>
                <%= Html.ValidationMessageFor(model => model.ClientApplicationName)%>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.GatewayId)%>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.GatewayId)%>                
                <%= Html.ValidationMessageFor(model => model.GatewayId)%>                
            </div>
            </div>
            
            <div style="float: left; padding: 10px">
            <div class="editor-label">
                <%= Html.LabelFor(model => model.FinancialInstitution)%>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.FinancialInstitution)%>
                <%= Html.ValidationMessageFor(model => model.FinancialInstitution)%>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.SourceType)%>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.SourceType)%>
                <%= Html.ValidationMessageFor(model => model.SourceType)%>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Branch)%>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Branch)%>
                <%= Html.ValidationMessageFor(model => model.Branch)%>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.SubOffice)%>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.SubOffice)%>
                <%= Html.ValidationMessageFor(model => model.SubOffice)%>
            </div>
            </div>
            
            <div style="float: left; padding: 10px">
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Protocol)%>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Protocol)%>
                <%= Html.ValidationMessageFor(model => model.Protocol)%>
            </div>
            </div>                      
        </fieldset>
        <%= Html.ValidationSummary(true)%>

    <% } %>