<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
    <table id="list"></table>
    <div id="pager"></div>
    <div id="details"></div>
    
    <ul>
    <li><a href="#" id="a1">Edit</a></li>    
    </ul>   

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <link href="/Content/ui.jqgrid.css" rel="stylesheet" type="text/css">

    <script src="/Scripts/jquery.form.js" type="text/javascript"></script>
    <script src="/Scripts/i18n/grid.locale-en.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.jqGrid.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $("document").ready(function() {
            $('#a1').click(function() {
                var rowid;
                rowid = $("#list").jqGrid('getGridParam', 'selrow');
                if (rowid)
                    crud('/Protocol/Edit/' + rowid);
                else
                    alert('Please select a row');
            });

            $('#a2').click(function() {
                var rowid;
                rowid = $("#list").jqGrid('getGridParam', 'selrow');
                if (rowid)
                    crud('/Protocol/ASPEdit/' + rowid);
                else
                    alert('Please select a row');
            });

            setup();
        });
      
        function setup() {
            $("#list").jqGrid({
                url: '/Protocol/List',
                datatype: 'json',
                mtype: 'GET',
                colNames: ['id', 'Application', 'GatewayId', 'Book Code', 'Source Type', 'Branch', 'SubOffice', 'Protocol'],
                colModel: [
                    { name: 'id', index: 'invid', hidden: true },
                    { name: 'ClientApplicationName', index: 'ClientApplicationName', width: 120 },
                    { name: 'GatewayId', index: 'GatewayId', width: 80, align: 'center' },
                    { name: 'FinancialInstitution', index: 'FinancialInstitution', width: 120, align: 'center' },
                    { name: 'SourceType', index: 'SourceType', width: 100, align: 'center' },
                    { name: 'Branch', index: 'Branch', width: 110, align: 'center', sortable: false },
                    { name: 'SubOffice', index: 'Sub Office', width: 110, align: 'center', sortable: false },
                    { name: 'Protocol', index: 'Protocol', width: 110, align: 'center', sortable: false }
                ],
                pager: '#pager',
                rowNum: 5,
                rowList: [10, 20, 30],
                sortname: 'id',
                sortorder: 'asc',
                viewrecords: true,
                caption: 'My first grid'
            }); 
        }
        
        
        
        
        function crud(url) {
            $.ajax(
            {
                url: url,
                success: function(data, textStatus, xhr) {
                    $('#details').html(data);                        
                    $('#details').dialog(
                    {
                        autoOpen: true,
                        width: 750,
                        modal: true,
                        resizable: false,
                        show: 'slide',
                        hide: 'slide',
                        buttons:
                        {
                            "Save": function() {
                                $('form', $(this)).submit();
                            },
                            "Close": function() {
                                $(this).dialog('close');
                            }
                        }
                    });
                }
            });
        }
        
        
        
        
    
    </script>
</asp:Content>